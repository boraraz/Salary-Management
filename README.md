# Salary Management
 
In this project SQLite were used. You may need to install the application to run this program. 
Official SQLite download page link: https://sqlitebrowser.org/dl/

If database connection cannot work properly you may need to add migrations and update database on your computer.
To do this you neet to install some dotnet tool which can be done from this link below
https://learn.microsoft.com/en-us/ef/core/cli/dotnet

after installing tools 
you have to add migrations with a name for example 
$ dotnet ef add migrations [random-name]
after this step is done you need to update database with
$ dotnet ef update database

there are few NuGet packages already downloaded, if you need to install those packages again you can install from NuGet package manager on visual studio. Downloaded packages are:
 - Microsoft.AspNetCore.Diagnostics.EntityFrameworkCore
 - Microsoft.AspNetCore.Identity.EntityFrameWork
 - Microsoft.AspNetCore.Identity.UI
 - Microsoft.Data.Sqlite.Core
 - Microsoft.EntityFrameworkCore
 - Microsoft.EntityFrameworkCore.Design
 - Microsoft.EntityFrameworkCore.Sqlite
 - Microsoft.EntityFrameworkCore.SqlServer
 !!All packages' version is (6.0.11)
