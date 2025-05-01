pipeline {
    agent any
    stages {
        stage('Restore dependencies') {
            steps {
                bat 'dotnet restore'
            }
        }
        stage('Build the application') {
            steps {
                bat 'dotnet build'
            }
        }
        stage('Run the tests') {
            steps {
                bat 'dotnet test'
            }
        }
    }
}