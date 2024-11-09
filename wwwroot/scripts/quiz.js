const urlParams = new URLSearchParams(window.location.search);
const id = urlParams.get('id');

async function fetchQuizData(quizId) {
    try {
        const response = await fetch(API_BASE_URL + `/quizzes/${id}?type=noanswers`)
        if (!response.ok) {
            console.error("Failed to fetch data with given id");
            return;
        }

        const quizData = await response.json();
        displayQuizData(quizData);
    } catch (error) {
        console.error("Error fetching quiz data:", error);
    }
}

function displayQuizData(quizData) {
    try {
        document.getElementById("quiz-title").innerText = quizData.name;
        const quizContent = document.getElementById("quiz-content");
        quizContent.innerHTML = ''; // Clear any existing content

        // Loop through each question and add to quiz-content
        quizData.questions.forEach((question, index) => {
            const questionElement = document.createElement("div");
            questionElement.classList.add("question");

            // Add question text
            const questionText = document.createElement("h2");
            questionText.innerText = `${index + 1}. ${question.text}`;
            questionElement.appendChild(questionText);

            // Add answer buttons
            question.answers.forEach(answer => {
                const answerBtn = document.createElement("button");
                answerBtn.classList.add("answer-btn");
                answerBtn.innerText = answer.text;
                answerBtn.setAttribute("data-question-id", question.id);
                answerBtn.setAttribute("data-answer-id", answer.id);

                // Toggle selected state on click
                answerBtn.addEventListener("click", () => {
                    // Clear previous selection for this question
                    document.querySelectorAll(`[data-question-id="${question.id}"]`).forEach(btn => btn.classList.remove("selected"));

                    // Mark the clicked answer as selected
                    answerBtn.classList.add("selected");
                });

                questionElement.appendChild(answerBtn);
            });

            quizContent.appendChild(questionElement);
        });
    } catch (error) {
        console.error("Error displaying quiz data:", error);
    }
}

async function submitQuiz() {
    const questionNum = document.querySelectorAll(".question").length;
    const selectedAnswers = document.querySelectorAll(".selected");
    if (selectedAnswers.length < questionNum) {
        alert("please select all answers");
        return;
    }

    document.querySelectorAll(".answer-btn").forEach(btn => {
        btn.disabled = true;
    });

    //fetch correct answers
    const response = await fetch(API_BASE_URL + `/quizzes/${id}?type=withanswers`)
    const quizAnswers = await response.json();

    //compare with selected ones
    let scoreCounter = 0; /* a counter to count score */
    selectedAnswers.forEach(btn => {
        const questionId = btn.getAttribute("data-question-id");
        const answerId = btn.getAttribute("data-answer-id");

        for (const playerResponse of quizAnswers.questions) {
            if (Number(playerResponse.id) === Number(questionId)) {
                if (Number(playerResponse.correctAnswerId) === Number(answerId)) {
                    scoreCounter++;
                    btn.style.backgroundColor = "#4CAF50"; // Correct answer: Green
                } else {
                    btn.style.backgroundColor = "#F44336"; // Incorrect answer: Red
                }
                break;
            }
        }
    });

    document.getElementById("submit-quiz").classList.add("hidden");
    document.getElementById("home-btn").classList.remove("hidden");

    //scroll back to top
    document.getElementById("quiz-content").scrollTo({ top: 0, behavior: 'smooth' });

    // Show final score
    const finalScore = document.getElementById("final-score");
    finalScore.classList.remove("hidden");
    finalScore.classList.add("visible");
    finalScore.innerHTML = `Score: ${scoreCounter}/${questionNum}`;
}

// Fetch quiz data when the page loads
if (id) {
    fetchQuizData(id);
} else {
    console.error("Quiz ID is required but not provided.");
}