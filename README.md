# Pierre's Bakery Revisited

#### A website for logging various bakery delights in associated with a series of flavors describing the foods. The site prompts the user for an authorized login or to create an account and begin cataloguing their delicious meals.

## Authored by:
Quin Asselin, January 2023

***

## Table of Contents
1. [Repository Description](#repository-description)
2. [Technologies Used](#technologies-used)
3. [Setup Instructions](#installation-and-setup)
4. [API Documentation](#api-documentation)
4. [Known Bugs](#known-bugs)
5. [License Information](#license)

## Repository Description
This project was written and compiled in C-Sharp. It is an API that the user can access via a API platform such as Swagger in the browser or POSTman as a standalone app. Upon running, the user will be able view, add to, edit, and remove both various entries from a locally constructed database of State and National Parks. Each park contains a name, a location and a municipality. Items in the database can be returned as an index or filtered via search queries detailed in the API documentation below.

This project was hand-built in tandem with a programming class taught by Epicodus. It contains use the technologies and programs listed below.

## Technologies Used

- C#
- .NET
- Git
- Github
- Markdown
- MySQL Workbench w/MySQL
- Razor
- VSCode
- Swashbuckle
- Swagger

## Installation And Setup

### Preparatory Installation Steps
1. To begin, the user must install a compatible version of .NET 6. An acceptable version can be found [here](https://dotnet.microsoft.com/en-us/download/dotnet/6.0).
2. Follow the prompts throught the installation of the program. Using default settings as they originally appear in the setup.
3. In the terminal (ex: Git Bash) install dotnet-script by runing the following command
```bash
$ dotnet tool install -g dotnet-script
```
this will install "dotnet-script"
4. Configure your local environment to use this. Details for which can be found [here](https://www.learnhowtoprogram.com/c-and-net/getting-started-with-c/installing-dotnet-script).
5. Then, install MySQL. Follow further detailed instructions on accomplishing that [here](https://www.learnhowtoprogram.com/c-and-net/getting-started-with-c/installing-and-configuring-mysql).

### Repository Setup
1. Clone this repository.
2. Open your shell (e.g. Terminal or GitBash) and navigate to this project's production directory called "Parks".
3. Within the Parks folder, create a file titled appsettings.json
4. Open your file editor and navigate to appsettings.json
5. In the appsettings.json file, paste the following code:
```javascript
{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft": "Warning",
      "Microsoft.Hosting.Lifetime": "Information"
    }
  },
  "ConnectionStrings": {
      "DefaultConnection": "Server=localhost;Port=5001;database=Parks;uid=[uid];pwd=[pwd];"
  }
}
```
6. Replace [uid] and [pwd] with your created SQL username and password respectively (including the braces).
7. Additionally, you will need to install some packages in order to run this code. Within the same directory please run the following commands:
```bash
dotnet add package Microsoft.EntityFrameworkCore -v 6.0.0 
```
```bash
dotnet add package Pomelo.EntityFarmeworkCore.MySql -v 6.0.0
```
```bash
dotnet add package Microsoft.AspNetCore.Mvc.Versioning
```
```bash
dotnet add package Microsoft.AspNetCore.Mvc.Versioning.ApiExplorer
```

### Creating the Initial Database
*To create and instantiate a database with preseeded values we will be required to execute a brief series of commands*
1. Within bash/terminal navigate to the project's root directory which is housed in the Parks.Solution Folder.
2. Execute the proceeding commands the sequence displayed below:
```bash
dotnet ef migrations add Initial
```
then:
```bash
dotnet ef database update
```
*This will instantiate our database with pre-seeded values.*
*__To ensure no loss of data occurs, please use MySQl Workbench to determine if you already have a database on your local machine that uses the name "Parks" if that is the case, please consider renaming it temporarily during use of this program.__*
### Execute the Program
1. Open the terminal and navigate to the production directory titled "Parks.Solution."
2. Run `dotnet watch run` in the command line to start the project in development mode with a watcher.
3. Open the browser to _https:localhost:5001/swagger/index.html_. If you cannot access localhost:5001 it is likely because you have not configured a .NET developer security certificate for HTTPS. To learn about this, review this lesson: [Redirecting to HTTPS and Issuing a Security Certificate](https://www.learnhowtoprogram.com/c-and-net/basic-web-applications/redirecting-to-https-and-issuing-a-security-certificate).

## API Documentation
- This API is open and all existing endpoints can be examined and reached without limitation, metering, or additional credential validation.
- This API is best examined with Postman, Swagger, or any API interaction platform you prefer.

### API Endpoints
- At present, there are two API versions available with negligible divergence and as such can be used interchangeably in endpoint construction.
  - These endpoints are labeled v1 and v2 and when being used in urls will be denoted as 'v[#]' though the default version will be v2
  - '[id]' will refer to the specific database entry id for that item. '[id]' is replaced with a number and (like 'v[#]') does not include the brackets or quotes in its final construction

  - API endpoints follow basic database CRUD and request structure parameters after the URL ''https://localhost:5001' with no spaces:

- GET(full index):
  - /api/[v#]/Parks
- GET(individual):
  - /api/[v#]/Parks/[id]
- POST:
  - /api/[v#]/Parks
- PUT:
    - /api/[v#]/Parks/[id]
- DELETE(permanent):
  - /api/[v#]/Parks/[id]

- additionally, a search can be performed using a GET request with the following generalized structure:

https://localhost:5001/api/v[#]/Parks?[parkName or parkState or municipality]=[SearchTerm]&[parkName or parkState or municipality]=[SearchTerm]

Example Search URL:
https://localhost:5001/api/v2/Parks?municipality=State

## Known Bugs
- There is currently a working issue with some instances of the search functionality tied to the API and as such filtering database entries along certain criteria does not work as intended.
- Additionally, certain search queries using special characters (such as punctuation or a space) will need to be formatted by an API platform or customized by hand 


## License
*Quin Asselin, February 2023. Available for distribution, modification, inspection, and application under [GPLv3 License](https://www.gnu.org/licenses/gpl-3.0.en.html)*

This application makes previous work from the Epicodus staff as a reference for learning material. It has been used with permission of the staff.