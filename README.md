# C# JSON Task Manager

A simple command-line Task Manager built with C# and .NET to practise file handling, JSON serialization, and asynchronous programming.

## Features

* Add new tasks.
* View all saved tasks.
* Mark tasks as completed.
* Store task data in a JSON file.
* Load saved tasks when the application restarts.
* Perform asynchronous file operations.
* Handle file-related errors and invalid JSON data.

## Technologies Used

* **Language:** C#
* **Framework:** .NET
* **JSON Processing:** System.Text.Json
* **File Handling:** FileStream
* **Asynchronous Programming:** async/await
* **Version Control:** Git and GitHub

## Getting Started

### Prerequisites

* .NET SDK installed.
* Git installed (optional, for cloning the repository).

### Installation

Clone the repository:

```bash
git clone https://github.com/Kelvinjaston/JsonFileManager.git
```

Navigate to the project directory:

```bash
cd JsonFileManager
```

Run the application:

```bash
dotnet run
```

## How to Use

When you run the application, you will see a menu similar to this:

```text
=== JSON TASK MANAGER ===
1. Add task
2. View tasks
3. Mark task completed
4. Exit
```

Choose an option from the menu to manage your tasks.

Tasks are saved in a local `tasks.json` file, allowing the application to load them again when restarted.

**Note:** The local `tasks.json` file is excluded from Git tracking, so your personal task data is not uploaded to the repository.

## What I Learned

This project helped me practise:

* Reading and writing files in C#.
* Serializing objects into JSON.
* Deserializing JSON into C# objects.
* Using `FileStream` for file operations.
* Working with asynchronous methods using `async` and `await`.
* Managing collections of objects.
* Handling exceptions and validating user input.
* Using Git and GitHub to manage source code.

## Future Improvements

* Add the ability to delete tasks.
* Add task editing functionality.
* Improve input validation and error handling.
* Add task search and filtering.
* Write unit tests.

## Repository

[View the project on GitHub](https://github.com/Kelvinjaston/JsonFileManager)

---

*Built as a hands-on C# and .NET learning project.*
