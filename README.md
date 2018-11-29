This version works with the local `test.json` file to test CRUD calls from UI. Currently, works fine with GET.

# Installation

1. Install [Node.js](https://nodejs.org/en/)
2. Clone the project
3. Use Node.js command prompt and navigate to the project folder
4. Install - `npm install`
5. Compile and run - `ng serve`
6. Go to [http://localhost:4200/block](http://localhost:4200/block) to start work

# Structure so far...

### Services

* `rest.service` - service for all CRUD functions

### Components

* `block` - gets the test JSON and displays the list of tables (wip)
* `block-add` - view to adding a new table (to-do)
* `block-details` - view to single table contents (to-do)
* `block-edit` - edit selected table (to-do)

### JSON structure

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

