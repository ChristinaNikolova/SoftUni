pipeline {
    agent any
    environment {
        CHROME_VERSION = '127.0.6533.73'
        CHROMEDRIVER_VERSION = '100.0.4896.20'
        CHROME_INSTALL_PATH = 'C:\\Program Files\\Google\\Chrome\\Application'
        CHROMEDRIVER_PATH = '"C:\\Program Files\\Google\\Chrome\\Application\\chromedriver.exe"'
    }
    stages {
        stage('Checkout the repo') {
            steps {
                git branch: 'master', url: 'https://github.com/ChristinaNikolova/06-SeleniumWebDriver-Jenkinsfile'
            }
        }
        stage('Install Chocolatey') {
            steps {
                script {
                    def chocoInstalled = bat(script: 'choco --version', returnStatus: true) == 0
                    if (!chocoInstalled) {
                        echo 'Chocolatey is not installed. Installing Chocolatey...'
                        bat '''
                        powershell -Command "Invoke-WebRequest -Uri https://chocolatey.org/install.ps1 -OutFile install.ps1"
                        powershell -Command "Set-ExecutionPolicy Bypass -Scope Process -Force; iex ((Get-Content .\\install.ps1 -Raw))"
                        '''
                    } else {
                        echo 'Chocolatey is already installed.'
                    }
                }
            }
        }
        stage('Setup .NET Core') {
            steps {
                echo 'Installing .NET SDK...'
                bat 'choco install dotnet-6.0-sdk -y'
            }
        }
        stage('Uninstall current Google Chrome') {
            steps {
               script {
                    def chromeInstalled = bat(script: 'choco list --local-only googlechrome', returnStatus: true) == 0
                    if (chromeInstalled) {
                        echo 'Uninstalling Google Chrome...'
                        bat 'choco uninstall googlechrome -y'
                    } else {
                        echo 'Google Chrome is not installed. Skipping uninstallation.'
                    }
                }
            }
        }
        stage('Install Google Chrome') {
            steps {
                bat '''
                echo Installing Google Chrome
                choco install googlechrome -y
                '''
            }
        }
        stage('Download and Install ChromeDriver') {
            steps {
                bat '''
                echo Downloading ChromeDriver version %CHROMEDRIVER_VERSION%
                powershell -command "Invoke-WebRequest -Uri https://chromedriver.storage.googleapis.com/%CHROMEDRIVER_VERSION%/chromedriver_win32.zip -OutFile chromedriver.zip -UseBasicParsing"
                powershell -command "Expand-Archive -Path chromedriver.zip -DestinationPath ."
                powershell -command "Move-Item -Path .\\chromedriver.exe -Destination '%CHROME_INSTALL_PATH%\\chromedriver.exe' -Force"
                '''
            }
        }
        stage('Restore dependencies') {
            steps {
                bat 'dotnet restore SeleniumBasicExercise.sln'
            }
        }
        stage('Build the application') {
            steps {
                bat 'dotnet build SeleniumBasicExercise.sln --configuration Release'
            }
        }
        stage('Run tests for Project1') {
            steps {
                bat ' dotnet test TestProject1/TestProject1.csproj'
            }
        }
        stage('Run tests for Project2') {
            steps {
                bat ' dotnet test TestProject2/TestProject2.csproj'
            }
        }
        stage('Run tests for Project3') {
            steps {
                bat ' dotnet test TestProject3/TestProject3.csproj'
            }
        }
    }
}