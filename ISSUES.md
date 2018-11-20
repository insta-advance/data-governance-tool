Issues
=======

## SQL server
"Introducing FOREIGN KEY constraint 'FK_RelationshipTables_Bases_BaseToId' on table 
'RelationshipTables' may cause cycles or multiple cascade paths. Specify ON DELETE NO 
ACTION or ON UPDATE NO ACTION, or modify other FOREIGN KEY constraints."

If metadata is deleted and it contains a foreign key you cannot automatically
delete the relationship from the KeyRelationship table because SQL server is 
over paranoid about cascading loops. Either we have to do this on backend or use postgresql.

---

## Certificate

Proper certificate handling should be looked into.

---