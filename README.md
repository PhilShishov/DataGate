# DataGate Platform 
https://pharusdatagate.com/ <br />

A private web application for managing more than 300 funds. <br />
It is developed to be used by Pharus Management Lux S.A in order to <br />
improve the efficiency and automate some parts of Risk and Legal department.


## Table of contents
* [General Info](#general-info)
* [Guest Account](#guest-account)
* [Technologies](#technologies)
* [Functionality](#functionality)
* [Documentation](#documentation)
* [Status](#status)
* [Contact](#contact)

## General Info

The application can display NAV reports on chosen time period and <br />
detailed information about the UCITS and AIF handled by the management company such as: 
* General related entity view
* Sub entities
* Timeline changes
* Timeseries AuM charts
* Distinct related documents and agreements
* All related documents
* All related agreements
* Fees related to agreements
 
 ## Guest Account
https://pharusdatagate.com/ <br />
Username: datagate_guest <br />
Password: datagate_guest <br />
 
 ## Technologies
* Backend - C# .NET Core 3.1, MVC, REST
* Frontend - RAZOR, CSS, JavaScript ES6, jQuery
* Frameworks - ASP.NET Core 3.1, Bootstrap
* Database - MSSQL Server, Entity Framework Core 3.1
* Testing - xUnit, MyTested.AspNetCore.Mvc
* Project Management - Jira, Trello
* Version Control - Git, TortoiseGit, GitHub
* DevOps - Azure Pipelines
* Hosting and File Storage - GoDaddy WebWiz
* UI/UX design - Photoshop, HTML/CSS, Bootstrap 

## Functionality 
### Logged in Users
 - Manage account(GDPR) - email, password, two-factor, personal data
 - Consult global libraries and agreements
 - Consult particular view - sub entities, timeseries, documents, agreements, timelines, fees
 - View active and unactive entities
 - Consult NAV reports
 - Update views by chosen date
 - Choose and sort header columns for large table views
 - Perform a global search for a share class
 - Extract view tables as PDF and Excel 
 ### Users in role "Legal"
  - All the functionalities of logged in user
  - Upload and delete documents, agreements and fees
  - Create/edit fund
 ### Administrators
 - All the functionalities of legal user
 - Create, edit and delete user
 - Have access to view users panel

## Documentation
You can read the documentation [here]().
You can watch videos about the platform:
* [Presentation of DataGate]()
* [DataGate guide]()
* [Legal users guide]()
* [Adminstrators guide]()
* [Create/edit a fund]()
* [Upload a document or agreement]()
* [Add agreement fees ]()

![Project-Architecture](Documentation/Resources/Project-Architecture.JPG)
![Application-Architecture](Documentation/Resources/Application-Architecture.JPG)
![Application-Structure](Documentation/Resources/Application-Structure.JPG)
![ResponsiveDesign](Documentation/Resources/ResponsiveDesign.JPG)
  
  ## Status
  [![Build Status](https://dev.azure.com/philshishov/DataGate/_apis/build/status/DataGate-CI?branchName=master)](https://dev.azure.com/philshishov/DataGate/_build/latest?definitionId=1&branchName=master)
  
  ## Contact
Created by [@philshishov](https://github.com/PhilShishov) - feel free to contact me!
