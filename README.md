`# Raetselloeser

**Raetselloeser** is a C# console application designed to solve specific tasks related to puzzles or crosswords. This README provides instructions for setting up and running the project.

## Prerequisites

Before setting up the project, ensure you have the following installed:

- [.NET SDK](https://dotnet.microsoft.com/download) (version 6.0 or later)

- [Visual Studio](https://visualstudio.microsoft.com/) or any other IDE that supports C# and .NET

- [Git](https://git-scm.com/)

## Setup

### 1. Clone the Repository

Start by cloning the repository to your local machine:

```bash
git clone https://github.com/your-username/Raetselloeser.git
```

Replace `your-username` with your GitHub username.

### 2\. Configure the Application

#### Option 1: Using `appsettings.json` (for development)

Create an `appsettings.json` file in the root directory of the project with the following structure:

```bash
{

  "ConnectionStrings": {

    "DefaultConnection": "your-database-connection-string"

  },

  "OtherSettings": {

    // Add other settings here as needed

  }

}
```

-   Replace `"your-database-connection-string"` with your actual MongoDB connection string.

#### Option 2: Using Environment Variables (for production)

Set up environment variables to configure the application. This is recommended for production environments where sensitive data like connection strings should not be hard-coded.

-   **Windows (Command Prompt or PowerShell):**

    ```bash
    setx ConnectionStrings__DefaultConnection "your-database-connection-string"
    ```

-   **Linux/macOS (Terminal):**

    ```bash
    export ConnectionStrings__DefaultConnection="your-database-connection-string"
    ```

Make sure to replace `"your-database-connection-string"` with the actual values.

### 3\. Open and Build the Project

1\.  Open the solution file (`Raetselloeser.sln`) in Visual Studio or your preferred C# IDE.

2\.  Build the solution to restore NuGet packages and compile the project:

    -   In Visual Studio: Click on **Build** > **Build Solution**.

    -   Using the command line:

        ```bash
        dotnet build
        ```

3\.  Ensure there are no build errors before proceeding.

### 4\. Run the Project

You can run the project using Visual Studio's debugging tools:

-   Press **F5** to start debugging.

-   Alternatively, run the project without debugging by pressing **Ctrl + F5**.

For command-line execution:

```bash
dotnet run --project ./Raetselloeser
```

The application should now be up and running.

Contributing

------------

If you would like to contribute to this project, please follow these steps:

1\.  Fork the repository on GitHub.

2\.  Create a new branch from the `main` branch.

3\.  Make your changes and commit them with clear messages.

4\.  Push your changes to your fork.

5\.  Create a pull request to the `main` branch of this repository.

License

-------

This project is licensed under the MIT License - see the LICENSE file for details.

Contact

-------

For any questions or suggestions, feel free to reach out at mace.christop@mm-bbs.de.
