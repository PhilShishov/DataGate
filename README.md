# DataGate Web Platform 

https://pharusdatagate.com <br />

A private web application for managing more than 300 funds. <br />
It is developed to be used by Pharus Management Lux S.A in order to <br />
centralize internal data and allow each user to be able to <br />
find relevant information in a fast way, saving time, reducing operational errors <br />
and automating some parts of the Risk and Legal department.

  ## Status
  [![Build Status](https://dev.azure.com/philshishov/DataGate/_apis/build/status/DataGate-CI?branchName=master)](https://dev.azure.com/philshishov/DataGate/_build/latest?definitionId=1&branchName=master) [![Build status](https://ci.appveyor.com/api/projects/status/thvsvj1du6d595m6?svg=true)](https://ci.appveyor.com/project/PhilShishov/datagate)


## Table of contents
* [General Info](#general-info)
* [Registration](#registration)
* [Technologies](#technologies)
* [Security](#security)
* [Functionality](#functionality)
* [Documentation](#documentation)
* [Data Manipulation Layer](#data-manipulation-layer)
* [Status](#status)
* [History](#history)
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
 
 ## Registration
Registration is only possible through email invitation and confirmation. <br />
A guest account has been set-up for free use. <br />

Username: **datagate_guest** <br />
Password: **datagate_guest** <br />
https://pharusdatagate.com <br />
 
 ## Technologies
* Frameworks - ASP.NET Core 3.1, Bootstrap
* Project Management - Jira, Trello
* Version Control - Git, TortoiseGit, GitHub
* DevOps - Application Insights, Azure Pipelines
* Hosting and File Storage - GoDaddy WebWiz

### Backend 
* C# .NET Core 3.1, MVC, REST
* Database - MSSQL Server, SQL Lite, Entity Framework Core 3.1
* Testing - xUnit, MyTested.AspNetCore.Mvc
* SendGrid, AutoMapper, EPPlus, itext7

### Frontend
* RAZOR, CSS, JavaScript ES6, jQuery
* JS/jQuery - DataTable, Chart, Chosen, Moment, Slick, SweetAlert
* HTML5 - SVG, Canvas
* UI/UX design - Photoshop, HTML/CSS, Bootstrap

### Security
 * ASP.Net Core
 * ReCaptcha
 * X-CSRF
 * XSS
 * Antiforgery
 * Overposting
 * HTML Sanitization
 * SQL Injection
 * SSL

## Functionality 
### Logged in Users
 - Slide through recent share classes
 - Consult libraries and agreements
 - Consult particular view - sub entities, timeseries, documents, agreements, timelines, fees
 - View active and unactive entities
 - Consult NAV reports
 - Update views by chosen date
 - Choose and sort header columns for large table views
 - Perform a global share class search
 - Extract view tables as PDF and Excel
 - Two language support - English and Italian
 ### Users in role "Legal"
  - All the functionalities of logged in user
  - Upload and delete documents, agreements and fees
  - Create/edit fund
 ### Administrators
 - All the functionalities of legal user
 - Create, edit and delete user
 - Have access to view users panel
 
 ## Data Manipulation Layer
 
.Net Core console application running on Ubuntu 20.04 SFTP Linux Server.  </br>
 [Report Processor](https://github.com/PhilShishov/ReportProcessor)
Main function:
 1. Receive input from client AuM reports: EDR, NT and CACEIS
 2. Manipulate data through an SFTP Server
 3. Send processed data to DataGate DB to be displayed in web platform

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
  
  ## History  
**2020-10-12** SFTP Data Manipulation Layer - [Report Processor](https://github.com/PhilShishov/ReportProcessor)

**2020-09-02** Updated to ASP.NET Core 3.1.7

**2020-07-14** Updated to ASP.NET Core 3.1.6

**2020-06-22** Released DataGate v2.0

**2020-02-28** Released DataGate v1.0 with ASP.NET Core 2.1
  
  ## Contact
Created by [Philip Shishov](https://github.com/PhilShishov) - feel free to contact me!
