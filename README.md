# DataGate Platform
A private web application for managing more than 300 funds. It is developed to be used by Pharus Management Lux S.A 
in order to improve the efficiency and automate some parts of Risk and Legal department.

[![Build Status](https://dev.azure.com/philshishov/DataGate/_apis/build/status/DataGate-CI?branchName=master)](https://dev.azure.com/philshishov/DataGate/_build/latest?definitionId=1&branchName=master)

## Description
The application can display NAV reports on chosen time period and 
detailed information about the UCITS and AIF handled by the management company such as: 
* General related entity view
* Sub entities
* Timeline changes
* Timeseries AuM charts
* Distinct related documents and agreements
* All related documents
* All related agreements
* Fees related to agreements

Other features: 
 * Create and edit fund
 * Excel and PDF extraction
 * Upload documents and agreements 

## Documentation
You can read the documentation [here](https://youtu.be/SEKTWCcHH-k).
You can watch videos about the platform:
* In [this]() video you can watch the presentation of DataGate.
* In [this]() video you can watch how users use the system.
* In [this]() video you can watch how legal users can work in the system.
* In [this]() video you can watch how administrators can work in the system.
* In [this]() video you can watch how users can create/edit an entity.
* In [this]() video you can watch how users can upload a document or agreement.
* In [this]() video you can watch how users can add fees to an agreement.

## Getting Started
### Prerequisites
You will need the following tools:

* [Visual Studio](https://www.visualstudio.com/downloads/)
* [Microsoft SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads)
* [.NET Core SDK 3.1.6](https://www.microsoft.com/net/download/dotnet-core/3.1)

## Technologies
* .NET Core 3.1
* ASP.NET Core 3.1
* ASP.NET Core MVC
* Entity Framework Core 3.1
* GoogleDrive (test purposes)
* xUnit, MyTested.AspNetCore.Mvc
* jQuery, Bootstrap, JavaScript

## Third-parties 
- EPPlus 5.2
- itext7 7.1.11
- Automapper 10.0
- SendGrid 9.18

  
## Project Architecture
![Architecture](Documentation/Architecture.jpg)
* Data access layer - works with the database using Entity Franework Core 2.2, this layer is independent from the others. It consists of two other layers:
  * Domain Layer - contains all entities, enums. Classes which represent tables in the database
  * Persistence Layer - contains database context, all configurations, migrations and data seeding logic. It is responsible for data persistance. Here is implmented Repository desing pattern which help us to accomplish more abstraction between data access logic and business logic. As a result we can our database provider without making so many changes to the code. For example we can chnage MS SQL with MongoDB without changing some business logic.
* Business Layer - main logic of the appliaction. It depends only on Data access layer but it uses repositories to access data so the coupling is very loose. It can be reuced in multiple appliactions. For example if we want to create some mobile version of the system, can reuse logic in this layer and we should also implement the new user intreface.
* Application Layer - consists of those elements that are specific to this application. It do the binding between the application and your business layer. It depends on business layer. It uses specific technologies and conceptions like: ASP.NET CORE, Middlewares and others. In our situation it's main functionality is to receive the request and send response to the clients.
* Presentation Layer -  contains all presentation logic. It used Razor view engine to generate html and also use technologies like: JavaScript, jQuery, AJAX.
* Common Layer - contains all the logic which is shared in the application. Contains global constants, custom exceptions and extension methods.
* Workers - .NET Standard class libraries which contains some more complicated logic. They are used by the business layer in order to keep the code simple there. The most compilacted logic in the appllication is related to complication and execution of submissions. So this logic is implemented here in two differnet projects.
* Tests - the system is tested with a lot of automated tests - unit tests and integration tests. We use libraries like Moq, xUnit and Microsoft.EntityFrameworkCore.InMemory to the all the logic in business layer.
* Code quality - project follows SOLID principles and all other principles of high quality code. Also there are ```.editorconfig``` file in which are defained all code styles and conventions in order the code of the project to be consistent.

## Functionality
### Guest Users
 - Login, Register
 - View all courses and lessons in this course
 - View home page with all active and previous contests
 
### Logged in Users
 - Submit solution and receive instant responese about how many points he has received
 - Submit solutions only in practice mode
 - Activate student profile using special activation key
 - View information about error, which occurs during excecution only of trial tests
 - View input and output data only of trial tests
 - Cannot view information about error, which occurs during excecution of official test
 - View execution result of tests
 - View their practice results
 - Download resources
 
 ## Users in role "Student"
  - All the functionalities of logged in user
  - Take part of competitions(Send solutions in compete mode)
  - Take part in exam and receive grade
  - Informtion about all passed exams is available in their profile
  - Participate in all contests available in the home page
  - View their compete and practice results
 
### Administrators(Teachers in school)
 - Add student profile to the system
 - Create, edit and delete course (Each course combines some lectures)
 - Create, edit and delete lectures
 - Have access to all contests' results
 - Filter contests' results by username, student class, contest start and end time etc.
 - Create contest for specific lecture with start and end time
 - Edit and delete contests
 - Create, delete and edit problem for specific lecture
 - Add, edit and delete resources for specific lecture
 - Create, edit and delete test for specific problem
 - View input and output data of each tests
 - View information about error, which occurs during excecution of some test

## Breif description of main functionalities
### Student profile
 - When student profile is added to the database, activation key is automatically generated, that is sent to the student's email
 - When the user enter this activation key, he becomes student and role "Student" is added to his roles
 - In this way he obtain full name, student email, number in class, name of class and some other privileges
 
 ### Submissions
  - If there is compile time error, the user can see what is the error
  - If solution is compiled successfully, all tests for this problem are executed over this solution
  - Execution results of tests are: (Success, Run time error, Memory limit, Time limit).
  - User can receive points in range 0 to problem's max points for his solution
  - The system finds user's best solution when process contests' results
  
  ### Lectures
  - Each lecture can be one of the tree types(Homework, Exercise or Exam)
  - Lecture can be added with some password which is really convenient for exam lecture
  
  ## Authors

- [Philip Shishov](https://github.com/PhilShishov)
