Issues
=======

## <span style="color:green">(Solved)</span> Functionality issue: SQL server 
"Introducing FOREIGN KEY constraint 'FK_RelationshipTables_Bases_BaseToId' on table 
'RelationshipTables' may cause cycles or multiple cascade paths. Specify ON DELETE NO 
ACTION or ON UPDATE NO ACTION, or modify other FOREIGN KEY constraints."

If metadata is deleted and it contains a foreign key you cannot automatically
delete the relationship from the KeyRelationship table because SQL server is 
over paranoid about cascading loops. Either we have to do this on backend or use postgresql.

Solved by migrating to postgresql.

---

## <span style="color:green">(Solved)</span> Functionality issue: Certificate

Proper certificate handling should be looked into.

Solved by ignoring http. Use https proxy in development or just run locally.

---

## <span style="color:green">(Solved)</span> Functionality issue: KeyRelationship POST not working

Won't be able to post without specifying Id because of conflicting primary keys:
Id and (FromId, ToId).

Solved by making (FromId, ToId) an alternate key.

---

## <span style="color:green">(Solved)</span> Semantic issue: Database is both Mongo and Postgres

Database has a type and two Navigation properties to Schemas and Collections.

Fixed by making Types MongoDatabase and PostgresDatabase.

---

## <span style="color:green">(Solved)</span> Usability issue: Can't know the derived type of the Base type.

When using the API especially KeyRelationships the derived type of the other Base type is not known.

Fix: So that you don't have to guess from structure (impossible in some cases) or check in what endpoint
the id exists at, a new endpoint Bases is introduced with a api/bases/gettype/{id} endpoint.

---

## <span style="color:green">(Solved)</span> Functionality issue: It's possible to have two files with same name.

Because files exists both in UnstructuredFiles and StructuredFiles they have separate constraints preventing
a datostore from having two files with a same path. This means there could exists a StructuredFile
and a UnstructuredFile with identical names in the same datastore.

Fix: Common base table File from which Structured-/UnstructuredFiles are derived.

---

## <span style="color:green">(Solved)</span> Usability issue: Can't get easily the fields belonging to a composite key.

API is missing a way to get the fields of a composite key:w.

Fixed by adding business logic that includes the fields in GET requests.

---

## <span style="color:green">(Solved)</span> Functional issue: Tests.DatastoresManager.NoEmptyName()

Possible to add Datastore with an empty name.

Fix: Added a database constraint. Also for file names, names of a base type and for field types.

---

## <span style="color:green">(Solved)</span> Functional issue: Tests.DatastoresManager.PutValues()

Name is alternate key and cannot be changed in PUT.

Fix: Make it an unique index.

---

## <span style="color:green">(Solved)</span> Functional issue: Tests.DatabasesManager.Delete()

Delete doesn't work because foreign key from table to schema isn't configured.

Fix: add foreign key.

---

## <span style="color:green">(Solved)</span> Functional issue: Deleting a foreign key deletes a table

Deleting a foreign key deletes the table and everything below it's hierarchy.

Fix: correct delete behaviour restrict.

---

## <span style="color:red">(TODO)</span> Usability issue: PUT in KeyRelationships/CompositeKeyField

You can't change a primary key (composite) to update a relationship.

TODO: custom update.

---