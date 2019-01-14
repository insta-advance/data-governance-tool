This version works with the actual backend (localhost:5000/api/)

# Installation

1. Install [Node.js](https://nodejs.org/en/)
2. Clone the project
3. Install npm in project folder - `npm install`
4. Compile and run - `ng serve` or `npm start`
5. Go to [http://localhost:4200](http://localhost:4200) to start working on datastore

# Structure

### Services

* `rest.service` - service for CRUD and mapping the data (done)

### Interfaces

* `metadata.model` - set of interfaces that are used for mapping the metadata (done)

### Components

* `global-view` - overall view to datastore (WIP)
* `database-view` - view to singular database with schemas and tables (WIP)
* `schema-view` - view to schema with fields (WIP)
* `table-view` - view to table and fields (WIP)

# To Do

* POST and PUT for each entity
* datastore selection
* testing: adding -> editing -> deletion
