async function fetchQuizzes() {
    try {
        const response = await fetch(API_BASE_URL + '/quizzes');
        const allQuizzes = await response.json();

        document.getElementById("main-content").classList.add("hidden");
        const quizListContainer = document.getElementById("quiz-list-container");
        quizListContainer.innerHTML = `
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


