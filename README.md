This version works with the actual backend (localhost:5000/api/)

# Installation

1. Install [Node.js](https://nodejs.org/en/)
2. Clone the project
3. Install npm in project folder - `npm install`
4. Compile and run - `npm start`
5. Go to [http://localhost:4200](http://localhost:4200) to start working

# Structure

### Services

* `rest.service` - service for CRUD and mapping the data (done)

### Interfaces

* `metadata.model` - set of interfaces that are used for mapping the metadata (done)

### Components

* `datastore-list` - view to list of datastores (done)
* `global-view` - overall view to datastore (done)
* `database-view` - view to singular PostgreSQL database with schemas and tables (done)
* `mongo-database-view` - view to singular MongoDB database with schemas and tables (done)
* `schema-view` - view to schema with fields (done)

# To Do

* Datastore. database, schema, table renaming (PUT)
* Editing fields and keys (PUT)
* Adding, deleting, editing and assigning annotations to fields, files, collections and tables
* CSS refactoring and documentation
