# StudentService
ASP.NET Core Angular web application

## Build 
### Pre-requisites
- .NET Core 3.1 SDK
- NPM
### Run Application
- open Command Prompt
- cd StudentService
- dotnet build
- dotnet run –project src/StudentService.WEB/StudentService.WEB
- open browser 
- search "localhost:5000"
### Run Angular Tests
- open Command Prompt
- cd StudentService/StudentService.WEB/ClientApp
- npm test
### Run Unit Tests
- open Command Prompt
- cd StudentService
- dotnet test

## About Application
You can login as an User, Admin and as a Manager:
- User: username - user, password - 111. User can check the list of students out.
- Admin: username - admin, password - 222. Admin can check the list out, edit and add a student.
- Manager: username - manager, password - 333. Manager can check the list out, edit, add and delete a student. 
