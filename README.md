# QuizApp 🎯

QuizApp is a full-stack application that allows users to create, manage, and participate in quizzes. With an intuitive user interface and robust backend, users can answer quiz questions, track their progress, and manage quiz content. It provides features for both quiz participants and administrators.

---

## 🚀 Features

### Frontend Features
- **Quiz Participation**: Users can play quizzes and answer a series of questions, receiving instant feedback on their answers.
- **Question Management**: Admin users can easily create, modify, and delete quiz questions through an intuitive interface.
- **Real-time Feedback**: Correct answers are shown immediately after each submission, enhancing the learning experience.
- **Score Calculation**: After completing the quiz, users can view their final score along with the correct answers.

### Backend Features
- **Authentication & Authorization**: Secure user authentication using JWT. Only authorized users can perform certain actions such as viewing user lists or modifying quiz data.
- **Quiz CRUD Operations**: APIs are provided for creating, reading, updating, and deleting quizzes, enabling dynamic quiz management.
- **Question CRUD Operations**: Full functionality to create, read, update, and delete quiz questions.
- **User Management**: APIs for managing user data, including creating, updating, and deleting user accounts.

---

## 🛠️ Tech Stack

### Frontend
- **HTML**: Used for creating the structure and content of the web pages.
- **CSS**: Custom styles to ensure a visually appealing and responsive UI.
- **JavaScript**: Adds dynamic functionality to the frontend for user interaction.

### Backend
- **.NET Core**: A powerful framework for building the backend APIs and handling the logic for managing quizzes and questions.
- **Entity Framework Core**: An ORM used to interact with the PostgreSQL database in a seamless manner.

### Database
- **PostgreSQL**: A reliable, open-source relational database used to store quiz, question, and user data.

### Containerization
- The entire project is containerized using **Docker**, making it easy to set up and deploy across different environments.

---

## 📋 Prerequisites

Before running the application, make sure you have the following installed:

- [**.NET SDK**](https://dotnet.microsoft.com/download) for building and running the backend.
- [**PostgreSQL**](https://www.postgresql.org/download/) for the database.
- [**Docker**](https://www.docker.com/get-started) for containerizing the application.

---

## How to run
- Create .env file and add these required environment variables:
  - POSTGRES_USER=<your_postgres_user>
  - POSTGRES_PASSWORD=<your_postgres_password>
  - POSTGRES_DB=<your_postgres_db_name>
- Start and build docker image by command: docker compose up --build -d
- To access QuizApp UI: http://localhost:8000/

---

## To-do
- Authentication on FE, restrict access based on authorization.
- Save records to database.
- More error handling.
- Timer for participating quiz.
- Logger.
- Docker.
- Unit test.
- Random questions for quizzes, random answer's positions.
- FE for delete questions, quizzes.
