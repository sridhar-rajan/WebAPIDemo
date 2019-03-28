# Web API CRUD Demo

One Web API to be consumed by Console App project and MVC project

### Software Development Summary
- Technology: C#
- ORM Framework: Entity Framework 6.2 (Code-First Approach)
- Framework: .NET Framework 4.6.1, .NET Standard 2.0.3
- Total Projects: 5 (1 Web API MVC Project, 2 Class Library Project, 1 MVC Project, 1 Console App Project)
- Solution Architecture/Structure Design: 
1. Domain Entity Model layer
2. Infrastructure layer 
3. Application layer (Web API)
4. Presentation layer: MVC Web Application and Console App.
- IDE: Visual Studio Community 2017
- Paradigm or pattern of programming: Object-Oriented Programming (OOP)
- Data: Data of this demo program are stored in SQL Server database using Entity Framework ORM.
- NuGet and JS Libraries: jQuery.js, bootstrap.js,  alertify.js, Popper.js, respond.js
- Notes: Client to consume Web API needs System.Net.Http.Formatting.dll. Install by running "Install-Package Microsoft.AspNet.WebApi.Client" in Package Manager Console.
- Font: Font Awesome
- LINQ syntax: LINQ Method and Lambda expression

#### Solution Architecture/Structure Design:
![DomainDrivenDesignMicroServiceLayers](https://user-images.githubusercontent.com/21274590/55128855-0edb5700-5150-11e9-9ea1-58d45c353dff.png)

![DomainDrivenDesignMicroServiceDependencies](https://user-images.githubusercontent.com/21274590/55128850-0aaf3980-5150-11e9-89e2-148c3f1a8b15.png)

[Reference](https://docs.microsoft.com/en-us/dotnet/standard/microservices-architecture/microservice-ddd-cqrs-patterns/ddd-oriented-microservice)

#### Enhancement (To Do):
- [ ] Repository (General and Specific) layer with interface

### Video Demo
- [Sample Web API CRUD Demo with Console App Project](https://youtu.be/Zm0Jtel_n0k)
- [Sample Web API CRUD Demo with MVC Project](https://youtu.be/GUwu5k1ZLD4)

[If this content is helpful to you, consider to support and buy me a cup of coffee :) ](https://ko-fi.com/V7V2PN67)
