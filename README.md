# todo-api-ef
This is a web api that I used .net entity framework, C# and postgre sql database.

This is how you can run this project:
--Open project in VS
--make ToDo.Api project as startup
--Change Connection String from appsettings.Development.json in "ToDo.Api" project
--Build the project
--Go to Package Manager Console
--Then select "ToDo.Infrastructure" from default project dropdown
--execute command "Update-Database"
--go to the project folder from File Explorer
--in folder "DatabaseManagement" you will find a sql file, run this script on PostgreSql server
--Run the project
--after running the project api will work on the swagger
--you can create an account and sign in using this account
--after sign in, you will get a token. you need to authanticate yourself using the token. use 'Bearer' before the token.
--Now you can make the crud operations.

