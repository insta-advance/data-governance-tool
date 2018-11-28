README
=======

### Installation
Install following software:

  * dotnet-host    – A generic driver for the .NET Core Command Line Interface.
  * dotnet-runtime – The .NET Core runtime.
  * dotnet-sdk     – The .NET Core SDK.
  * code           – The Open Source build of Visual Studio Code (vscode) editor.

From vscode install extensions:

  * C#
  * Dotnet core commands
  * NuGet Packet Manager

[Install SQL Server for linux] [l0].  
[l0]: https://docs.microsoft.com/en-us/sql/linux/quickstart-install-connect-ubuntu?view=sql-server-2017

You need to create your own database and modify "DefaultConnection" -string found 
in file appsettings.json to match your own database or setup your database with 
user SA and password Intopal0. 

mssql-tools will crash if you for some reason don't have a locale `en_US.utf-8` in 
your locales to fall back on. Add it into `/etc/locale.gen` or equivalent and run 
`locale-gen`.

Remember to open ports locally in iptables.rules (should be there on default):  
`-A INPUT -i lo -j ACCEPT`

Create database (it will automatically create IntopaloDB not only tables):  
`$ dotnet ef database update`

If database script has changed run first:  
`$ dotnet ef database drop`

Show SQL script used to create DB:  
`$ dotnet ef migrations script`

Compile and run the project  
`$ dotnet run`

If you are using NuGet check that the packets exist with versions in IntopaloApi.csproj.
Installing from NuGet (ctrl+P+>nuget) will automatically update the project file.

If tools for making the dev certificate fail. Don't waste your time & remove
the https://localhost:5001 from your launchSettings.json and use http for development.

The metadata can be read from:

  * http://localhost:5000/api/intopalo
  * https://localhost:5001/api/intopalo

### Development
  * [Basic guide to REST Api][l1].
[l1]: https://docs.microsoft.com/en-us/aspnet/core/tutorials/web-api-vsc?view=aspnetcore-2.1#create-the-database-context
  
  * [Entity Framework Core][l2].
[l2]: https://docs.microsoft.com/en-us/ef/#pivot=efcore


Http request body needs to have following JSON structure:

{
  "<name of the item list>":
  [
	{
		"Key":  "Value",
		"Key2": "Value2
	},
	{
		"Key":  "Value3",
		"Key2": "Value4"
	}
  ],
  "<name of the item list 2 >": 
  [
	{
		"Key":  "Value",
		"Key2": "Value2
	},
	{
		"Key":  "Value3",
		"Key2": "Value4"
	}
  ],
	
	
Names of the item lists can be found in the file Model/JsonData.cs.


Examples of JSON bodies for basic REST Api calls:

(CREATE)
POST /api/intopalo:
{
    "jsonCollections":
    [
        {
            "CollectionName": "NewItem8"
        },
        {
            "CollectionName": "NewItem9"
        }
    ],
    "jsonUnstructuredFiles":
    [
    	{
    		"FilePath": "/home/Intopalo"
       	},
       	{
       		"FilePath": "/home/datagovernance/Intopalo"
       	}
    ]
}

(UPDATE)
PUT /api/intopalo:
{
	"jsonCollections":
    [
        {
            "CollectionName": "NewItem10",
            "BaseID" : 2014
        },
        {
            "CollectionName": "NewItem11",
            "BaseID" : 2015
        }
    ],
    "jsonUnstructuredFiles":
    [
    	{
    		"FilePath": "/home/Intopalo/changed",
    		"BaseID" : 2016
       	},
       	{
       		"FilePath": "/home/datagovernance/Intopalo/changed",
       		"BaseID" : 2017
       	}
    ]
}

(DELETE)
DELETE /api/intopalo:

{
    "jsonCollections":
    [
        {
            "BaseID" : 2009
        },
        {
            "BaseID" : 2010
        }
    ],
    "jsonUnstructuredFiles":
    [
    	{
    		"BaseID" : 2016
       	},
       	{
       		"BaseID" : 2017
       	}
    ]
}
