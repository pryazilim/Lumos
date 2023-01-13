# Project Lumos

This project developed for Lumos Danismanlik

## To prepare the dev environment

Please foolow the guideline below;

- Run `dotnet new mvc`
- Run `dotnet add package Microsoft.EntityFrameworkCore`
- Run `dotnet add package Microsoft.EntityFrameworkCore.SqlServer`
- Remove unneeded files
- Add Data Context by creating a file in `Database/` folder

## To run the project

Please follow the guideline below;

- Clone the project on your computer
- Open the project in your IDE
- Run `dotnet dev-certs https`
- Run `export Lumos_Database_ConnectionString="SQL_CONNECTION_STRING"`
- Run `dotnet watch run`
