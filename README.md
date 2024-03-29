# Sprout Developer Exam

This repository contains code and resources related to the Sprout Developer Exam. It includes solutions to coding challenges and other relevant files.

## Prerequisites

This project runs on .NET 5 SDK

## Configurations

Change the value of the default connection depending on your setup and local environment
``` bash
{
  "ConnectionStrings": {
    "DefaultConnection": "Data Source=(local);Initial Catalog=SproutExamDb;Integrated Security=true"
  },
}
```

Install dependencies on the client
``` bash
cd Sprout.Exam.WebApp/ClientApp
npm install
```

Restore updated database using the SproutDbExamUpdated.bak

## Task Accomplished

- Create, Read, Update and Delete two types of employees
- Calculate salary of regular and contractual employee
- Implemented Factory Design Pattern for employee types
- Unit Testing
- Validation for the client and the server

## Improvements needed to deploy to production

- Update to the latest version of .NET
- Update react class to functional components and use vite + react for faster development server
- Update nuget and npm packages
- Strongly implement separation of concerns (use CQRS design pattern, group services in the dependency injection, etc)
- Add applicable tests for client and server (unit test, integration tests and e2e tests)
- Add CI/CD pipeline



