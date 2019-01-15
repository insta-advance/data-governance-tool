README
=======

### Install dotnet core 2.1+
Install following software:

  * dotnet-host    – A generic driver for the .NET Core Command Line Interface.
  * dotnet-runtime – The .NET Core runtime.
  * dotnet-sdk     – The .NET Core SDK.
  * code           – The Open Source build of Visual Studio Code (vscode) editor.

From vscode install extensions:

  * C#
  * Dotnet core commands
  * NuGet Packet Manager

### Install PostgreSQL
Following packages:

  * postgresql
  * postgresql-libs
  * (pgadmin)

 Installation should create a user for pg. Change to it and configure pg. (May depend on distro.)  
`$ sudo -u postgres -i`  
`$ initdb -d '/var/lib/postgres/data'`  

Create user 'datagovernancetool' and set it as superuser:   
`$ createuser --interactive`  
`$ createdb DataGovernanceToolDB`  

Connect to database and set password for the user:   
`$ pqsl DataGovernanceToolDB`  
`$ alter user datagovernancetool with password 'datagovernancetool';`  

As a normal user set pg up as a system service.  
`$ systemctl enable postgresql`
`$ systemctl start postgresql`

Check if service is active (running).  
`$ systemctl status postgresql`

### Install SQLite (Not for production)
Install SQLite libraries and uncomment the `UseSqlite(...)` in the Startup.cs.

### Create migrations 
Create database (it will automatically create Db not only tables):  
`$ dotnet ef database update --context DataGovernanceDBContext`

If database script has changed run first:  
`$ dotnet ef database drop --context DataGovernanceDBContext`

Show SQL script used to create DB:  
`$ dotnet ef migrations script --context DataGovernanceDBContext`

Make life easy:  
`dotnet ef migrations remove --context DataGovernanceDBContext \`  
`&& dotnet ef migrations add initial --context DataGovernanceDBContext \`  
`&& dotnet ef database drop --context DataGovernanceDBContext \`  
`&& dotnet ef database update --context DataGovernanceDBContext \`  

### Compilation
Compile and run the project  
`$ dotnet run`

If you are using NuGet check that the packets exist with versions in IntopaloApi.csproj.
Installing from NuGet (ctrl+P+>nuget) will automatically update the project file.

If tools for making the dev certificate fail. Don't waste your time & remove
the https://localhost:5001 from your launchSettings.json and use http for development.

The metadata can be accessed from:

  * http://localhost:5000/api/datagt
  * http://localhost:5000/api/\<Controller\>\[/\<id\>\]


### Docker
Run the following commands in the folder '/DataGovernanceTool'.

Starts up Postgresql in a separate container:  
`$ docker run -d --name my-postgres -e POSTGRES_PASSWORD=password postgres`

Builds the image of DataGovernanceTool called datagt:   
`$ docker build -t datagt .`

Starts the DataGovernanceTool docker and links it to Postgresql container:  
`$ docker run -it -p 5000:5000 --link my-postgres:postgres datagt`


### Swagger
Swagger documentation of API can be found from:

  * http://localhost:5000/swagger


### Development
  * [Basic guide to REST Api](https://docs.microsoft.com/en-us/aspnet/core/tutorials/web-api-vsc?view=aspnetcore-2.1#create-the-database-context).
  * [Entity Framework Core](https://docs.microsoft.com/en-us/ef/#pivot=efcore).
