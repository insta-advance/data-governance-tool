Issues
=======

## <span style="color:green">(Solved)</span> Functionality issue: SQL server 
"Introducing FOREIGN KEY constraint 'FK_RelationshipTables_Bases_BaseToId' on table 
'RelationshipTables' may cause cycles or multiple cascade paths. Specify ON DELETE NO 
ACTION or ON UPDATE NO ACTION, or modify other FOREIGN KEY constraints."

If metadata is deleted and it contains a foreign key you cannot automatically
delete the relationship from the KeyRelationship table because SQL server is 
over paranoid about cascading loops. Either we have to do this on backend or use postgresql.

Solved by migrating to postgresql

---

## <span style="color:green">(Solved)</span> Functionality issue: Certificate

Proper certificate handling should be looked into.

Solved by ignoring http. Use https proxy in development or just run locally.

---

## <span style="color:green">(Solved)</span> Functionality issue: KeyRelationship POST not working

Won't be able to post without specifying Id because of conflicting primary keys:
Id and (FromId, ToId).

Solved byt making (FromId, ToId) a alternate key.

---

## <span style="color:green">(Solved)</span> Semantic issue: Database is both Mongo and Postgres

Database has a type and two Navigation properties to Schemas and Collections.

Fixed by making Types MongoDatabase and PostgresDatabase.

---
## <span style="color:red">(TODO)</span> Usability issue: PUT in KeyRelationships/CompositeKeyField

You can't change a primary key (composite) to update a relationship.

TODO: custom update.

---