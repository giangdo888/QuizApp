import { fetchQuestions } from './app.js'

export async function openQuestionModal(mode, id = 0) {
    document.getElementById("question-modal-overlay").classList.add("visible");
    document.getElementById("question-modal").classList.add("visible");

    const modal = document.getElementById("question-modal");
    const modalTitle = document.getElementById("modal-title");
    const questionText = document.getElementById("question-text");
    const answersContainer = document.getElementById("answers-container");
    const saveButton = document.getElementById("save-btn");

    const res = await fetch(API_BASE_URL + `/questions/${id}`);
    const questionData = await res.json();

    // Set up the modal based on mode
    if (mode === 'edit') {
        modalTitle.innerText = "Edit Question";
        questionText.value = questionData.text;

        // Populate answers with existing data
        questionData.answers.forEach((answer, index) => {
            const answerInput = document.querySelector(`#answer-${index + 1}`);
            const radioBtn = document.querySelector(`#correct-${index + 1}`);
            answerInput.value = answer.text;
            radioBtn.checked = answer.isCorrect;
        });
    } else {
        modalTitle.innerText = "Create New Question";
        questionText.value = "";

        // Clear all answers
        Array.from(answersContainer.children).forEach((answerField, index) => {
            answerField.querySelector('input[type="text"]').value = "";
            answerField.querySelector('input[type="radio"]').checked = false;
        });
    }

    // Configure save button to handle create or update
    saveButton.onclick = async () => {
        const updatedAnswers = Array.from(answersContainer.children).map((answerField, index) => ({
            text: answerField.querySelector('input[type="text"]').value,
            isCorrect: answerField.querySelector('input[type="radio"]').checked
        }));

        const payload = {
            text: questionText.value,
            answers: updatedAnswers
        };

        if (mode === 'edit') {
            // Call the update API
            await fetch(API_BASE_URL + `/questions/${questionData.id}`, {
                method: 'PUT',
                headers: { 'Content-Type': 'application/json' },
                body: JSON.stringify(payload)
            });
        } else {
            // Call the create API
            await fetch(API_BASE_URL + `/questions`, {
                method: 'POST',
                headers: { 'Content-Type': 'application/json' },
                body: JSON.stringify(payload)
            });

        }
        fetchQuestions();
        closeQuestionModal();
    };

    modal.classList.add("visible"); // Show the modal
}

// Function to close the modal
export function closeQuestionModal() {
    document.getElementById("question-modal-overlay").classList.remove("visible");
    document.getElementById("question-modal").classList.remove("visible");
}

document.addEventListener("DOMContentLoaded", () => {
    document.getElementById("close-btn").addEventListener("click", closeQuestionModal);
});
