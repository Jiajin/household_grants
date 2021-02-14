# household_grants
Simple API on a fictional household grant system

Postman static link for test methods:
https://www.getpostman.com/collections/9d31181fb741927fcea7


Software Used:

Compiler: Visual Studio Community 2019
https://visualstudio.microsoft.com/vs/

Database: 
SQL Server Express Version
https://www.microsoft.com/en-sg/sql-server/sql-server-downloads

Microsoft SQL Server Management Studio
https://docs.microsoft.com/en-us/sql/ssms/download-sql-server-management-studio-ssms?view=sql-server-ver15


Setup instructions after installing the necessary software above:

Source Code
1. Open Visual Studio  -> File -> Clone Repo and select this github Repository

Database.

You can either:
1. Create your own database and run the create table scripts included in the repo
OR
2. Run the entire DB script included in the repo (To be mindful of physical location names)


Option 1:
A. Create a database in MS SQL Server management Studio
B. Run both table scripts in folder "Table with Data" (test data included). Schema without data is also provided in folder "Table Schema"

Option 2:
A. Run the database creation script in folder DB_Scripts/Entire DB. A version without data is provided as well.