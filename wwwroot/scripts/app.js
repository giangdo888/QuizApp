async function fetchQuizzes() {
    try {
        const response = await fetch(API_BASE_URL + '/quizzes');
        const allQuizzes = await response.json();

        document.getElementById("main-content").classList.add("hidden");
        document.getElementById("home-list-container").innerHTML = `
            <h2>Please select a quiz set</h2>
            <ul>
                ${allQuizzes.map(quiz =>
                    `<li><button class="quiz-set-btn" data-quiz-id="${quiz.id}">${quiz.name}</button></li>`
                ).join('')}
            </ul>`;

        document.querySelectorAll(".quiz-set-btn").forEach(btn => {
            btn.addEventListener("click", (e) => {
                const id = e.currentTarget.getAttribute('data-quiz-id');
                window.location.href = `playQuiz.html?id=${id}`;
            });
        });
    } catch (error) {
        console.error("Error fetching quizzes:", error);
    }
}

async function fetchQuestions() {
    try {
        const response = await fetch(API_BASE_URL + '/questions')
        const allQuestions = await response.json();

        document.getElementById("main-content").classList.add("hidden");
        document.getElementById("home-header").innerHTML = `Select question to edit`;
        document.getElementById("home-list-container").innerHTML = `
            <div class="question-list-container">
                <ul class="question-list">
                    ${allQuestions.map(question =>
            `<li class="question-item">
                            <button class="question-btn" data-question-id="${question.id}">
                                <span class="question-id">Q${question.id}</span>
                                <span class="question-text">${question.text}</span>
                            </button>
                        </li>`
        ).join('')}
                </ul>
            </div>`;

    } catch (error) {
        console.error("Error fetching questions:", error);
    }
}

