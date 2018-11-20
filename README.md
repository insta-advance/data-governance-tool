This version works with the local `test.json` file to test CRUD calls from UI. Currently. works fine with GET.

# Installation

1. Install [Node.js](https://nodejs.org/en/)
2. Clone the project
3. Use Node.js command prompt and navigate to the project folder
4. Install - `npm install`
5. Run the server - `ng serve --host 0.0.0.0 --port 4200`
6. Go to [http://localhost:4200/block](http://localhost:4200/block) to start work

# Structure so far...

### Services

* `rest.service` - service for all CRUD functions

### Components

* `block` - gets the test JSON and displays the list of tables
* `block-add` - view to adding a new table 
* `block-details` - view to single table contents
* `block-edit` - edit selected table

### JSON structure

```
[
  {
    "id": 1,
    "name": "Table 1",
    "fields": [
        {
          "field_1":"Employee",
          "field_2":"Salary",
          "field_3":"Hours"
        }
    ]
  },
  ...
]
```