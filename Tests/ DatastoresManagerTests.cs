using System;
using System.Collections.Generic;
using System.Linq;
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
    public class DatastoresManagerTests : BaseTest
    {
        private DatastoresManager datastoresManager;

        public DatastoresManagerTests() : base()
        {
        }

        [SetUp]
        public void CreateFieldsManager()
        {
           datastoresManager = new DatastoresManager(new DatastoresRepository(DBContext));            
        }

        [Test]
        public void EmptyDatastores()
        {
            var all = datastoresManager.GetAsync().Result;
            Assert.IsTrue(all.Count() == 0);
            Assert.Pass();
        }

        [Test]
        public void CreateAndGetDatastores()
        {
            var datastore = datastoresManager.CreateAsync(new Datastore {Name = "testStore"}).Result;
            var datastore2 = datastoresManager.CreateAsync(new Datastore {Name = "testStore2"}).Result;
            Assert.IsTrue(datastoresManager.GetAsync(datastore.Id).Result.Name == "testStore", "Failed to GET testStore.");
            Assert.IsTrue(datastoresManager.GetAsync(datastore2.Id).Result.Name == "testStore2", "Failed to GET testStore2.");
            var all = datastoresManager.GetAsync().Result;
            Assert.IsTrue(all.Count() == 2, "Doesn't contain 2 datastores.");
            Assert.IsTrue(all.Contains(datastore), "GET all failed to return an datastore.");
            Assert.IsTrue(all.Contains(datastore2), "GET all failed to return an datastore.");
            Assert.Pass();
        }

        [Test]
        public void UniqueDatastores() 
        {
            var datastore = datastoresManager.CreateAsync(new Datastore {Name = "testStore"}).Result;
            try 
            {
                var datastore2 = datastoresManager.CreateAsync(new Datastore {Name = "testStore"}).Result;
                Assert.IsTrue(false, "Failure: created two datastores with the same name.");
            } catch {}
            Assert.Pass();
        }

        [Test]
        public void NonEmptyName() 
        {
            var datastore = datastoresManager.CreateAsync(new Datastore {Name = "t"}).Result;
            var datastore2 = datastoresManager.CreateAsync(new Datastore {Name = "tt"}).Result;
            Assert.IsTrue(datastoresManager.GetAsync(datastore.Id).Result.Name == "t", "Failed to GET testStore.");
            Assert.IsTrue(datastoresManager.GetAsync(datastore2.Id).Result.Name == "tt", "Failed to GET testStore2.");
            try 
            {
                var datastore3 = datastoresManager.CreateAsync(new Datastore {Name = ""}).Result;
                Assert.IsTrue(false, "Failed to created a datastore with empty name.");
            } catch {}
            Assert.Pass();
        }

        [Test]
        public void PutValues()
        {
            var datastore = datastoresManager.CreateAsync(new Datastore {Name = "testStore"}).Result;
            try
            {
                var modifiedDatastore = datastoresManager.ReplaceAsync(datastore.Id, new Datastore {Name = "testoStoren"}).Result;
                var datastore2 = datastoresManager.GetAsync(datastore.Id).Result;
                Assert.IsTrue(datastore2.Name == "testoStoren", "Failed to change name of a datastore.");
                modifiedDatastore = datastoresManager.ReplaceAsync(datastore.Id, new Datastore {}).Result;
                Assert.IsTrue(datastore2.Name == "testoStoren", "Failed to keep the value of a datastore.");
            } 
            catch
            {
                Assert.IsTrue(false, "Failed to change the name of a datastore.");
            }
        }

        [Test]
        public void DeleteDatastore() 
        {
            var datastore = datastoresManager.CreateAsync(new Datastore {Name = "testStore"}).Result;
            datastoresManager.DeleteAsync(datastore.Id).Wait();
            try
            {
                var deleted = datastoresManager.GetAsync(datastore.Id).Result;
                Assert.IsTrue(false, "Failed to delete datastore.");
            } catch {}
        }
    }
}