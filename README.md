## Project Introduction

**"DataGate"** project is consisted of two parts: **DataGate Web Platform** and **DataGate Report Processor**
![Project-Architecture](Documentation/Presentation/Project-Architecture.JPG)

## Table of contents
* [DataGate Web Platform](#datagate-web-platform)
  * [General Info](#general-info)
  * [Registration](#registration)
  * [Technologies](#technologies)
  * [Security](#security)
  * [Functionality](#functionality)
* [DataGate Report Processor](#datagate-report-processor)
* [Documentation](#documentation)
* [History](#history)
* [Contact](#contact)

## DataGate Web Platform 

https://pharusdatagate.com <br />

![HomePage](Documentation/Screenshots/App/HomePage.png)
![UserPanel](Documentation/Screenshots/App/UserPanel.png)

A private web application for managing more than 250 funds. <br />
It is developed to be used by Pharus Management Lux S.A in order to <br />
centralize internal data and allow each user to be able to <br />
find relevant information in a fast way, saving time, reducing operational errors <br />
and automating some parts of the Risk and Legal department.

  ## Status
  [![Build Status](https://dev.azure.com/philshishov/DataGate/_apis/build/status/DataGate-CI?branchName=master)](https://dev.azure.com/philshishov/DataGate/_build/latest?definitionId=1&branchName=master) [![Build status](https://ci.appveyor.com/api/projects/status/thvsvj1du6d595m6?svg=true)](https://ci.appveyor.com/project/PhilShishov/datagate)

## General Info

The application can display NAV reports on chosen time period and <br />
detailed information about the UCITS and AIF handled by the management company such as: 
* General related entity view
* Sub entities
* Timeline changes
* Timeseries AuM charts
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
* IDE - Visual Studio 2019, VS Code
* Framework - ASP.NET Core 3.1
* Version Control - Git, TortoiseGit, GitHub
* DevOps - Application Insights, Azure Pipelines
* Hosting and File Storage - GoDaddy WebWiz
* Project Management - Jira, Trello - https://trello.com/pharusit
* Code review, StyleCop

### Database 
* MSSQL Server, mylittleadmin - Diagrams
* Entity Framework Core 3.1, Scaffold, LINQ

### Backend
* C# .NET Core 3.1
* Design Pattern - DAO, DI, TAP, MVC, REST, Repository, SOLID
* SendGrid, AutoMapper, IStringLocalizer/IHtmlLocalizer, EPPlus, itext7

### Client-side
* RAZOR, JavaScript ES6, jQuery, Bootstrap
* JS/jQuery - DataTable, Chart, Chosen, Moment, Slick, SweetAlert, Browser-Update, Cookie
* Libman, Bundle, WebCompiler
* UI/UX design - Photoshop, HTML5 (SVG, Canvas), SCSS/CSS3

### Security
 * ASP.NET Core
 * X-CSRF
 * Cross-site Scripting (XSS)
 * Antiforgery
 * Overposting
 * HTML Sanitization
 * SQL Injection
 * SSL
 * ReCaptcha
 * Browser Update
 
 ### GDPR

## Functionality 
### Logged in Users
 - [Manage Account](https://github.com/PhilShishov/DataGate/blob/master/Documentation/Screenshots/App/ManageAccount.png)
 - Consult libraries - Fund, Sub Fund, Share Class, Agreements
 - Consult particular view - [Sub entities and their connections](https://github.com/PhilShishov/DataGate/blob/master/Documentation/Screenshots/App/DetailFundView.png), 
 [Time Series](https://github.com/PhilShishov/DataGate/blob/master/Documentation/Screenshots/App/TimeSeries.png), 
 [Documents](https://github.com/PhilShishov/DataGate/blob/master/Documentation/Screenshots/App/Documents.png), 
 [Agreements](https://github.com/PhilShishov/DataGate/blob/master/Documentation/Screenshots/App/Agreements.png), 
 [Timeline](https://github.com/PhilShishov/DataGate/blob/master/Documentation/Screenshots/App/Timeline.png), 
 Fees
 - Manage tool menu - Layout, Toogle inactive entities, Update views by date
 - Extract view tables as [PDF](https://github.com/PhilShishov/DataGate/blob/master/Documentation/Screenshots/Extraction/Funds.pdf) 
 and [Excel](https://github.com/PhilShishov/DataGate/blob/master/Documentation/Screenshots/Extraction/Funds.xlsx)
 - Consult AuM NAV [Fund](https://github.com/PhilShishov/DataGate/blob/master/Documentation/Screenshots/App/FundReports.png) / [Sub Fund](https://github.com/PhilShishov/DataGate/blob/master/Documentation/Screenshots/App/SubFundReports.png) and Time Series reports
 - Choose and sort header columns for large table views
 - Perform a global [share class search](https://github.com/PhilShishov/DataGate/blob/master/Documentation/Screenshots/App/SearchView.png)
 - Slide through recent share classes
 - Two language support - 
 [English](https://github.com/PhilShishov/DataGate/blob/master/Documentation/Screenshots/App/UserPanel.png) and 
 [Italian](https://github.com/PhilShishov/DataGate/blob/master/Documentation/Screenshots/App/Italian.png)
 ### Users in role "Legal"
  - All the functionalities of logged in user
  - Upload
   [document](https://github.com/PhilShishov/DataGate/blob/master/Documentation/Screenshots/App/UploadDocument.png),
   [agreement](https://github.com/PhilShishov/DataGate/blob/master/Documentation/Screenshots/App/UploadAgreement.png) and
   fees
 -  Delete document, agreement
  - [Create Entity](https://github.com/PhilShishov/DataGate/blob/master/Documentation/Screenshots/App/Create.png)
  / [Official Update](https://github.com/PhilShishov/DataGate/blob/master/Documentation/Screenshots/App/OfficialUpdate.png)
 ### Administrators
 - All the functionalities of legal user
 - Create, edit and delete user
 - Have access to view users panel
 
   ## DataGate Report Processor
 
  [Report Processor](https://github.com/PhilShishov/ReportProcessor) - .NET Core application running on SFTP Server.  </br>

The main function is automatic feeding of data into an internal database by the Fund Admin (Asset under management, Subscription, Redeption, Net asset value, Fee)
![Data-Manipulation-Layer](Documentation/Presentation/Data-Manipulation-Layer.JPG)

## Documentation

[Code Metrics Processor](https://github.com/PhilShishov/DataGate/blob/master/Documentation/DataGate_CodeMetricsAnalyzis_20200720.xlsx)

[Responsive Web Design](https://github.com/PhilShishov/DataGate/tree/master/Documentation/Screenshots/App/Responsive)


![Application-Architecture](Documentation/Presentation/Application-Architecture.JPG)
![Application-Structure](Documentation/Presentation/Application-Structure.JPG)
  
  ## History
**2020-10-30** Updated to ASP.NET Core 3.1.9
  
**2020-10-12** SFTP Data Manipulation Layer - [Report Processor](https://github.com/PhilShishov/ReportProcessor)

**2020-09-02** Updated to ASP.NET Core 3.1.7

**2020-07-14** Updated to ASP.NET Core 3.1.6

**2020-06-22** Released DataGate v2.0

**2020-02-28** Released DataGate v1.0 with ASP.NET Core 2.1
  
  ## Contact
Created by [Philip Shishov](https://github.com/PhilShishov) - feel free to contact me!
