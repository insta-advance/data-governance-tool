This version works with the local `test.json` file to test GET calls from UI.

# Installation

1. Install [Node.js](https://nodejs.org/en/)
2. Clone the project
3. Use Node.js command prompt and navigate to the project folder
4. Install - `npm install`
5. Compile and run - `ng serve`
6. Go to [http://localhost:4200](http://localhost:4200) to start work

# Structure

### Services

* `rest.service` - service for fetching and mapping the data (WIP)

### Interfaces

* `metadata.model` - set of interfaces that are used for mapping of the metadata (WIP)

### Components

* `global-view` - gets the test JSON and displays the list of schemas, databases, their tables and collections and files (WIP)
* `schema-view` - view to singular schema (WIP)
* `database-view` - view to singular database (WIP)
* `relational-view` - view to all schemas in relational datastore (WIP)
* `nonrelational-view` - view to all databases in nonrelational datastore (WIP)

# To-Do

### Services

* `rest.service` - data mapping

### Components

* POST, PUT and DELETE calls
* views to add and edit schemas/databases, tables/collections, fields
* view to item deletion
* routing

# Proposed routing structure

`/api/intopalo/` - global view (`global-view` component)

`/api/intopalo/schemas` - schemas view  (`relational-view` component)
`/api/intopalo/schemas/add` - to add new schema
`/api/intopalo/schemas/1` - schema 1 view  (`schema-view` component)
`/api/intopalo/schemas/1/edit` - to edit schema 1
`/api/intopalo/schemas/1/add` - to add one table in schema 1
`/api/intopalo/schemas/1/1/edit` - to edit table 1 in schema 1

`/api/intopalo/databases` - databases view  (`nonrelational-view` component)
`/api/intopalo/collections/add` - to add new database
`/api/intopalo/collections/1` - database 1 view  (`database-view` component)
`/api/intopalo/collections/1/edit` - to edit database 1
`/api/intopalo/collections/1/add `- to add one collection to database 1
`/api/intopalo/collections/1/1/edit` - to edit collection 1 in database 1

`/api/intopalo/unstrcutured` - unstructured files view
`/api/intopalo/unstrcutured/add` - to add a file
`/api/intopalo/unstrcutured/1/edit` - to edit file 1

`/api/intopalo/strcutured` - structured files view
`/api/intopalo/strcutured/add` - to add a file
`/api/intopalo/strcutured/1/edit` - to edit file 1

# Current JSON structure

```
[
  {
    "Key": "Collections",
    "Value": [
      {
        "CollectionName": "IntopaloCollection1",
        "BaseID": 1
      },
      {
        "CollectionName": "NewItem1",
        "BaseID": 1002
      },
      {
        "CollectionName": "NewItem2",
        "BaseID": 1003
      },
      {
        "CollectionName": "NewItem3",
        "BaseID": 1004
      },
      {
        "CollectionName": "NewItem4",
        "BaseID": 1005
      },
      {
        "CollectionName": "NewItem5",
        "BaseID": 1006
      },
      {
        "CollectionName": "NewItem6",
        "BaseID": 2002
      },
      {
        "CollectionName": "NewItem7",
        "BaseID": 2003
      },
      {
        "CollectionName": "NewItem8",
        "BaseID": 2004
      },
      {
        "CollectionName": "NewItem9",
        "BaseID": 2005
      },
      {
        "CollectionName": "NewItem10",
        "BaseID": 2014
      },
      {
        "CollectionName": "NewItem11",
        "BaseID": 2015
      },
      {
        "CollectionName": "NewItem12",
        "BaseID": 2018
      },
      {
        "CollectionName": "NewItem13",
        "BaseID": 2019
      }
    ]
  },
  {
    "Key": "Databases",
    "Value": []
  },
  {
    "Key": "Schemas",
    "Value": [
      {
        "SchemaName": "private",
        "Tables": [
          {
            "TableName": "User",
            "Fields": [
              {
                "FieldName": "UserId",
                "FieldType": "int",
                "BaseID": 5,
                "KeyRelationshipFrom": [
                  {
                    "BaseFromId": 5,
                    "BaseToId": 8,
                    "Type": "exact"
                  }
                ]
              },
              {
                "FieldName": "UserName",
                "FieldType": "nvarchar(max)",
                "BaseID": 6,
                "KeyRelationshipFrom": []
              }
            ],
            "BaseID": 3
          },
          {
            "TableName": "Car",
            "Fields": [
              {
                "FieldName": "CarId",
                "FieldType": "int",
                "BaseID": 7,
                "KeyRelationshipFrom": []
              },
              {
                "FieldName": "OwnerId",
                "FieldType": "int",
                "BaseID": 8,
                "KeyRelationshipFrom": [],
                "KeyRelationshipTo": [
                  {
                    "BaseFromId": 5,
                    "BaseToId": 8,
                    "Type": "exact"
                  }
                ]
              },
              {
                "FieldName": "CarBrand",
                "FieldType": "nvarchar(max)",
                "BaseID": 9,
                "KeyRelationshipFrom": []
              }
            ],
            "BaseID": 4
          }
        ],
        "BaseID": 2
      }
    ]
  },
  {
    "Key": "StructuredFiles",
    "Value": []
  },
  {
    "Key": "Tables",
    "Value": [
      {
        "TableName": "User",
        "Schema": {
          "SchemaName": "private",
          "Tables": [
            {
              "TableName": "Car",
              "Fields": [
                {
                  "FieldName": "CarId",
                  "FieldType": "int",
                  "BaseID": 7,
                  "KeyRelationshipFrom": []
                },
                {
                  "FieldName": "OwnerId",
                  "FieldType": "int",
                  "BaseID": 8,
                  "KeyRelationshipFrom": [],
                  "KeyRelationshipTo": [
                    {
                      "BaseFromId": 5,
                      "BaseToId": 8,
                      "Type": "exact"
                    }
                  ]
                },
                {
                  "FieldName": "CarBrand",
                  "FieldType": "nvarchar(max)",
                  "BaseID": 9,
                  "KeyRelationshipFrom": []
                }
              ],
              "BaseID": 4
            }
          ],
          "BaseID": 2
        },
        "Fields": [
          {
            "FieldName": "UserId",
            "FieldType": "int",
            "BaseID": 5,
            "KeyRelationshipFrom": [
              {
                "BaseFromId": 5,
                "BaseToId": 8,
                "Type": "exact"
              }
            ]
          },
          {
            "FieldName": "UserName",
            "FieldType": "nvarchar(max)",
            "BaseID": 6,
            "KeyRelationshipFrom": []
          }
        ],
        "BaseID": 3
      },
      {
        "TableName": "Car",
        "Schema": {
          "SchemaName": "private",
          "Tables": [
            {
              "TableName": "User",
              "Fields": [
                {
                  "FieldName": "UserId",
                  "FieldType": "int",
                  "BaseID": 5,
                  "KeyRelationshipFrom": [
                    {
                      "BaseFromId": 5,
                      "BaseToId": 8,
                      "Type": "exact"
                    }
                  ]
                },
                {
                  "FieldName": "UserName",
                  "FieldType": "nvarchar(max)",
                  "BaseID": 6,
                  "KeyRelationshipFrom": []
                }
              ],
              "BaseID": 3
            }
          ],
          "BaseID": 2
        },
        "Fields": [
          {
            "FieldName": "CarId",
            "FieldType": "int",
            "BaseID": 7,
            "KeyRelationshipFrom": []
          },
          {
            "FieldName": "OwnerId",
            "FieldType": "int",
            "BaseID": 8,
            "KeyRelationshipFrom": [],
            "KeyRelationshipTo": [
              {
                "BaseFromId": 5,
                "BaseToId": 8,
                "Type": "exact"
              }
            ]
          },
          {
            "FieldName": "CarBrand",
            "FieldType": "nvarchar(max)",
            "BaseID": 9,
            "KeyRelationshipFrom": []
          }
        ],
        "BaseID": 4
      }
    ]
  },
  {
    "Key": "Unstructuredfiles",
    "Value": [
      {
        "FilePath": "/home/Intopalo",
        "BaseID": 2006
      },
      {
        "FilePath": "/home/datagovernance/Intopalo",
        "BaseID": 2007
      },
      {
        "FilePath": "/home/Intopalo/changed",
        "BaseID": 2012
      },
      {
        "FilePath": "/home/datagovernance/Intopalo/changed",
        "BaseID": 2013
      },
      {
        "FilePath": "/home/Intopallo",
        "BaseID": 2020
      },
      {
        "FilePath": "/home/datagovernance/Intopallo",
        "BaseID": 2021
      }
    ]
  }
]

