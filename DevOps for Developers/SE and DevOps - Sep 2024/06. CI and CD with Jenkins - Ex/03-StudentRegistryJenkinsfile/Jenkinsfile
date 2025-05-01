pipeline {
    agent any
    stages {
        stage('Checkout the repo') {
            steps {
                checkout scm
            }
        }
        stage('Set up Node.js') {
            steps {
                bat 'npm -v'
            }
         }
        stage('Install dependencies') {
            steps {
                bat 'npm install'
            }
        }
        stage('Start the application') {
            steps {
                bat 'start /B npm run start'
            }
        }
        stage('Run the tests') {
            steps {
                bat 'npm run test'
            }
        }
    }
}