UserInfoRegistrationAPIData Process flow


This project is developed by using ASP.net MVC WebAPI with .netframework 4.8 with IIS configuration.
Required
SQL server
ASP.net MVC WebAPI 
Servicedbaccess & Entity Framework

SQL Server 2019:
Created a database with name of SampleDB" ünder windows authentication mode
Created a table name as üsers with primarykey identity with autoincrement

ASP.net MVC WebAPI project:
Created ASP.net mvc webAPI project using dotnet framework 4.8 version and configured with IIS and given project url : http://localhost:50688/
Created models ,clsEntity ,view for homepage and controllers
Created connectionstring with dbaccess under wedconfig file
Created verbs (Get,Post, delete) methods for data access
configured swagger to test the webapi methods using web page

Servicedbaccess project2 & Entity Framework
Added another project for database connections 
created dbaccess file code first model file (RegistrationAPI.edmx) and configuration database by using sqlserver name with login credentials.
Then update model from database and display the all the tables on edmx page.Mapped required tables

Once done the servicedbaccess project creation and edmx table mapping.
Created getmethod to retrieve the userwise data from database 
created postmethod to save and update the existing data to database
created deletemethod to delete the data from database

Once complete the above setup process run the application, the page by default display as homepage, for testing purpose we need to include swagger/ui/index# (http://localhost:50688/swagger/ui/index#/)
then only API controller name will display 






