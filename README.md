## Using Entity Framework w. Repository & Unit Of Work design patterns  
  
### Table of contents
+ Introduction
+ Requirements
+ Tech stack
+ Key takeaways
+ Run locally  

### Introduction
Assignment #4 in the course Database development and management. The assignment had two parts, this here console application, and a series of SQL queries that can be [found here](https://gist.github.com/qvarnstr0m/faedfabdf9161ea0dae4eaa73028cfb9). In short, the assignment was to create a DB in Microsoft SQL Server Managment Studio for a high school with tables for students, staff, grades and courses amongst others. Then with the DB first Entity Framework method in Visual Studio create models for all the entities and then create a console app that connects to the DB.

### Short summary of requirements:  
The application should have features such as a menu to select data, ability to save information about staff and students, display information about staff, students, courses and monthly salaries, average salary of departments, and retrieve information about a specific student. The system should also allow for setting grades for a student with a transaction feature in case of errors.
  
### Tech stack
+ .NET 6.0  
+ C# 10.0  
  
Nuget packages:  
+ Microsoft.Entity.FrameworkCore.V. 7.0.2  
+ Microsoft.Entity.FrameworkCore.SqlServer V. 7.0.2  
+ Microsoft.Entity.FrameworkCore.Design V. 7.0.2  
+ Microsoft.Entity.FrameworkCore.Tools V. 7.0.2  
  
### Key takeaways
+ Learnt to implement design patterns
+ SQL is a versatile and useful language
+ Entity Framework can save time when syncing a DB to an application
+ Using EF with linq makes the code more readable imo
+ EF abstracts some of work when working with a DB, not always a good thing
+ Learnt to separate files and have a clear file structure

### Run locally
To create a replica of the DB run [this script](https://gist.github.com/qvarnstr0m/faedfabdf9161ea0dae4eaa73028cfb9) in SSMS.  
  
  Make sure you have dotnet installed.  
    
  Note that you will probably have to change the path to your local DB in Data/FbgGymnDbContext.cs  
    
Clone the project  
```git clone https://github.com/qvarnstr0m/UsingEntityFramework/```  
  
Move to the project folder    
```cd UsingEntityFramework```
  
Run the application  
```dotnet run```  




