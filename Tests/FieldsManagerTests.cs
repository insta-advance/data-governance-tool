using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NUnit.Framework;
using DataGovernanceTool.BusinessLogic.IManagers;
using DataGovernanceTool.BusinessLogic.Managers;
using DataGovernanceTool.Data;
using DataGovernanceTool.Data.Access;
using DataGovernanceTool.Data.Access.IRepositories;
using DataGovernanceTool.Data.Access.Repositories;
using DataGovernanceTool.Data.Models.Metadata;
using DataGovernanceTool.Data.Models.Metadata.Structure;
using DataGovernanceTool.Data.Models.Metadata.Relationships;

namespace Tests 
{
    [TestFixture]
    public class FieldsManagerTests : BaseTest
    {
        private FieldsManager fieldsManager;
        private TablesManager tablesManager;
        private SchemasManager schemasManager;
        private PostgresDatabasesManager databasesManager;
        private DatastoresManager datastoresManager;

        public FieldsManagerTests() : base()
        {
        }

        [SetUp]
        public void CreateFieldsManager()
        {
           fieldsManager = new FieldsManager(new FieldsRepository(DBContext));            
           tablesManager = new TablesManager(new TablesRepository(DBContext));            
           schemasManager = new SchemasManager(new SchemasRepository(DBContext));            
           databasesManager = new PostgresDatabasesManager(new PostgresDatabasesRepository(DBContext));            
           datastoresManager = new DatastoresManager(new DatastoresRepository(DBContext));            
        }

        [Test]
        public void CreateFieldBasic()
        {
            var datastore = datastoresManager.CreateAsync(new Datastore {Name = "testStore"}).Result;
            var database = databasesManager.CreateAsync(new PostgresDatabase {Name = "TestDB", DatastoreId = datastore.Id}).Result;
            var schema = schemasManager.CreateAsync(new Schema {Name = "private", DatabaseId = database.Id}).Result;
            var table = tablesManager.CreateAsync(new Table {Name = "TestTable", SchemaId = schema.Id}).Result;
            var field = fieldsManager.CreateAsync(new Field {Name = "Id", Type = "Int", StructuredId = table.Id}).Result;
            Assert.IsTrue(datastore.Id == database.DatastoreId && datastore.Name == "testStore", "");
            Assert.IsTrue(database.Id == schema.DatabaseId && database.Name == "TestDB", "");
            Assert.IsTrue(schema.Id == table.SchemaId && schema.Name == "private", "");
            Assert.IsTrue(table.Id == field.StructuredId && table.Name == "TestTable", "");
            Assert.IsTrue(field.Name == "Id" && field.Type == "Int", "");
            Assert.Pass();
        }

        [Test]
        public void ExistingEntity() {
            var datastore = datastoresManager.CreateAsync(new Datastore {Name = "testStore"}).Result;
            var database = databasesManager.CreateAsync(new PostgresDatabase {Name = "TestDB", DatastoreId = datastore.Id}).Result;
            var schema = schemasManager.CreateAsync(new Schema {Name = "private", DatabaseId = database.Id}).Result;
            var table = tablesManager.CreateAsync(new Table {Name = "TestTable", SchemaId = schema.Id}).Result;
            var field = fieldsManager.CreateAsync(new Field {Name = "Id", Type = "Int", StructuredId = table.Id}).Result;
            try
            {
                var field_dublicate = fieldsManager.CreateAsync(new Field {Name = "Id", Type = "Int", StructuredId = table.Id}).Result;
                Assert.IsTrue(false, "Created two fields with same name.");
            } catch {}
            Assert.Pass();
        }

        [Test]
        public void PutFunctionality() {

        }

        [Test]
        public void TypeConstraints() {
            var datastore = datastoresManager.CreateAsync(new Datastore {Name = "testStore"}).Result;
            var database = databasesManager.CreateAsync(new PostgresDatabase {Name = "TestDB", DatastoreId = datastore.Id}).Result;
            var schema = schemasManager.CreateAsync(new Schema {Name = "private", DatabaseId = database.Id}).Result;
            var table = tablesManager.CreateAsync(new Table {Name = "TestTable", SchemaId = schema.Id}).Result;
            try
            {
                var field = fieldsManager.CreateAsync(new Field {Name = "Id", Type = "", StructuredId = table.Id}).Result;
                Assert.IsTrue(false, "Created a field with an empty type.");
            } catch {}
            Assert.Pass();
        }

        [Test]
        public void NameConstraints() {
            var datastore = datastoresManager.CreateAsync(new Datastore {Name = "testStore"}).Result;
            var database = databasesManager.CreateAsync(new PostgresDatabase {Name = "TestDB", DatastoreId = datastore.Id}).Result;
            var schema = schemasManager.CreateAsync(new Schema {Name = "private", DatabaseId = database.Id}).Result;
            var table = tablesManager.CreateAsync(new Table {Name = "TestTable", SchemaId = schema.Id}).Result;
            try
            {
                var field = fieldsManager.CreateAsync(new Field {Name = "", Type = "Int", StructuredId = table.Id}).Result;
                Assert.IsTrue(false, "Created a fields with an empty name.");
            } catch {}
            Assert.Pass();
        }
    }
}