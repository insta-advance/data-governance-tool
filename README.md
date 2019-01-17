This version works with the actual backend (localhost:5000/api/)

# Installation

1. Install [Node.js](https://nodejs.org/en/)
2. Clone the project
3. Install npm in project folder - `npm install`
4. Compile and run - `npm start`
5. Go to [http://localhost:4200](http://localhost:4200) to start working on datastore

# Structure

### Services

* `rest.service` - service for CRUD and mapping the data (done)

### Interfaces

* `metadata.model` - set of interfaces that are used for mapping the metadata (done)

### Components

* `datastore-list` - view to list of datastores (fetching, displaying, adding and deleting datastores done)
* `global-view` - overall view to datastore (fetching, displaying datastore's content, adding databases done)
* `database-view` - view to singular database with schemas and tables (fetching, displaying database's content, deleting database, adding schemas done)
* `schema-view` - view to schema with fields (fetching, displaying database's content, deleting schema, adding and deleting tables done)

# To Do

* Entity renaming (PUT for each entity)
* Adding, deleting and editing fields and keys
* Adding, deleting, editing and assigning annotations
* Minor style and forms visibility fixes
* CSS refactoring and documentation
