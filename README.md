# 🚀 Employment Magnet

- 📚 [Overview]
- ✨ [Features]
- 🚀 [Getting Started]
- 📖 [Usage]
- 🔧 [Dependencies and Design Patterns]
- 👥 [Contributors]
- 📄 [License]

## 📚 Overview
This project is a console application developed using C# and .NET 6. It implements an API using ASP.NET for creating and managing custom internship, full-time, or part-time programs. With this application, users can design and configure their own programs, including the program's structure, questions, styles, and various features.

## ✨ Features
- **Program Creation**: Create custom internship, full-time, or part-time programs.
- **Program Management**: Manage every aspect of your program, including structure, content, and styling.
- **Question Customization**: Configure different types of questions, such as multiple choice, short answer, etc., and apply various features to them like hiding a question, making it mandatory, or marking it as internal.
- **Workflow Control**: Split your program into stages and specify each stage's name, type, and the data it contains.
- **Database**: Utilizes Cosmos Azure as the database for storing program data.
- **Unit Testing**: Unit testing is implemented using xUnit (still under development).
- **Program Details**: Users have the freedom to specify program details according to their requirements.

## 🚀 Getting Started
1. Clone the repository to your local machine.
2. Make sure you have .NET 6 installed.
3. Open the solution in your preferred IDE.
4. Configure your Cosmos Azure database connection in the secrets.json file.
5. Build and run the application.

## 📖 Usage
1. Launch the application.
2. Use the API to create and manage your custom programs.
3. Customize program structure, questions, and features to suit your needs.
4. Organize your program into stages and define their attributes.
5. Save and retrieve program data from the Cosmos Azure database.
6. Conduct unit testing (if available) to ensure functionality.
   
## ⚙️ Dependencies and Design Patterns

This project relies on several key dependencies to function properly and follows established design patterns for improved maintainability and scalability:

### Dependencies

- **CosmosDB**: The project utilizes Cosmos Azure as the primary database for storing program data.

- **xUnit**: xUnit is used for unit testing the application, ensuring code reliability and correctness.

- **ASP.NET Core**: ASP.NET Core powers the API in this project, providing robust web application capabilities and routing.

- **Fluent Assertion**: Fluent Assertion is used for writing more readable and fluent assertions in unit tests, enhancing test code's clarity and maintainability.

- **Fake It Easy**: Fake It Easy is a mocking library used for creating mock objects and simplifying unit testing by isolating components from their dependencies.

### Design Patterns

The project incorporates the following design patterns:

- **Factory Pattern**: The Factory Pattern is used to create instances of objects based on user preferences and requirements. It provides a flexible way to instantiate various components used in the program.

- **Repository Pattern**: The Repository Pattern is implemented to separate the logic that retrieves data from the database. It provides an abstraction layer between the application and the data source, enhancing code maintainability and testability.

These design patterns contribute to the project's maintainability, scalability, and overall architectural integrity. They promote code reuse and separation of concerns, making it easier to extend and enhance the application in the future.



## 👥 Contributors

<table>
  <tr>
    <td align="center">
    <a href="https://github.com/AbdelrahmanNoaman" target="_black">
    <img src="https://avatars.githubusercontent.com/u/76150639?s=400&u=4f3894f139c1383fadc15efdbed6207e936a2a20&v=4"   width="150px;" alt="Abdelrahman Noaman"/>
    <br />
    <sub><b>Abdelrahman Noaman</b></sub></a>
    </td>
  </tr>
 </table>

 ## 📄 License
This project is licensed under the [MIT License](LICENSE.md).

