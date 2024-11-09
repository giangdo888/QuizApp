import { openQuestionModal } from './questionModal.js';

export async function fetchQuizzes() {
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

export async function fetchQuestions() {
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
            </div>`

        document.getElementById("home-footer").innerHTML = `
            <button id="new-question-btn">+</button>
            <button id="home-btn" onclick="window.location.href='index.html'">Back To Home Page</button>`;

        document.querySelectorAll(".question-btn").forEach(btn => {
            btn.addEventListener("click", async (e) => {
                const id = e.currentTarget.getAttribute('data-question-id');
                openQuestionModal("edit", id);
            });
        });

        document.getElementById("new-question-btn").addEventListener("click", () => {
            openQuestionModal("create");
        });

        document.getElementById("new-question-btn").classList.remove("hidden");
    } catch (error) {
        console.error("Error fetching questions:", error);
    }
}

document.addEventListener("DOMContentLoaded", () => {
    document.getElementById("start-quiz-btn").addEventListener("click", fetchQuizzes);
    document.getElementById("open-question-pool-btn").addEventListener("click", fetchQuestions);
});

