# A Scheduling program that assigns randomly selected employees to different shifts in a day following some business rules.

Repo contains the following components- 
1. ``Schedular.API`` : The API project for getting schedule 
2. ``Scheduling.Lib`` : A class Library project for handling underlying logics
2. ``Schedular.Tests`` : Unit test project covering the tests of SchedulingService.
3. ``SchedularUI``:  An Agular 6 UI application with twitter bootstrap for displaying the schedule by calling the API

Technology Used:

1. ``Schedular.API ,Scheduling.Lib and Schedular.Tests ``:  ASP.NET Core Mvc Web API (.NET CORE V 2.0), MediatR,  Swagger Api Docs 
for API documentation ,Dependency Injection : .NET Core Build in service container,
Unit Tests: MSTests for .NET Core,
2. ``SchedularUI``: Angular 6 , Bootstrap, TypeScript etc

Since the schedling process needs to follow different business rules e.g. 
 - An engineer can do at most one-half day shift in a day.
 - An engineer cannot have two afternoon shifts on consecutive days. 
 - Each engineer should have completed one whole day of support in any 2 week period. 
 - If an engineer work on two consecutive days are eligible to get two days exemption.


keeping in mind the fact that there might be requirements in future to add more business rules the implementation follows ``Chain-of
-resonsibility`` design pattern to decouple the business rules and making it easy to plug in and also keeping the ability to add new rules.
The implemntation follow some abstractions regarding Services. I have used MediatR for sending different request command from controller .
This way it makes it more clean and readable , also reduces the complexity regarding dependencies.





