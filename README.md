This version works with the local `test.json` file to test GET calls from UI.

# Installation

1. Install [Node.js](https://nodejs.org/en/)
2. Clone the project
3. Use Node.js command prompt and navigate to the project folder
4. Install npm - `npm install`
5. Compile and run - `ng serve`
6. Go to [http://localhost:4200](http://localhost:4200) to start work

# Structure

### Services

* `rest.service` - service for CRUD and mapping the data (WIP)

### Interfaces

* `metadata.model` - set of interfaces that are used for mapping the metadata (WIP)
s
### Components

* `global-view` - gets the test JSON and displays the list of schemas, databases, their tables and collections and files (WIP)
* `schema-view` - view to singular schema (WIP)
* `database-view` - view to singular database (WIP)
* `relational-view` - view to all schemas in relational (PosgreSQL) datastore (WIP)
* `nonrelational-view` - view to all databases in nonrelational (MongoDB) datastore (WIP)

# To-Do

### Services

* `rest.service` - metadata mapping to model, PUT, POST and DELETE

### Components

* forms to add and edit schemas/databases, tables/collections, fields
* item deletion
* finish routing

# Issues and notes
* Currently json looping on global-view is super junky and redundant and heavily relies on order of the json arrays. Will be fixed when model is set and is properly mapped.
* [PH] in some of the titles / prompts are placeholders and are subjects to change when model is done
