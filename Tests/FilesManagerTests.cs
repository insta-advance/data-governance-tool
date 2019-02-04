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
    public class FilesManagerTests : BaseTest
    {
        private StructuredFilesManager structuredFilesManager;
        private UnstructuredFilesManager unstructuredFilesManager;
        private DatastoresManager datastoresManager;

        public FilesManagerTests() : base()
        {
        }

        [SetUp]
        public void CreateFieldsManager()
        {
           structuredFilesManager = new StructuredFilesManager(new StructuredFilesRepository(DBContext));            
           unstructuredFilesManager = new UnstructuredFilesManager(new UnstructuredFilesRepository(DBContext));            
           datastoresManager = new DatastoresManager(new DatastoresRepository(DBContext));            
        }

        [Test]
        public void UniqueFiles() 
        {
            var datastore = datastoresManager.CreateAsync(new Datastore {Name = "testStore"}).Result;
            var file1 = structuredFilesManager.CreateAsync(new StructuredFile {DatastoreId = datastore.Id, FilePath = "t"}).Result;
            try 
            {
                var file_unique = unstructuredFilesManager.CreateAsync(new UnstructuredFile {DatastoreId = datastore.Id, FilePath = "t"}).Result;
                Assert.IsTrue(false, "Failure: created two files with the same name.");
            } catch {}
            Assert.Pass();
        }

        [Test]
        public void NonEmptyFilePath() 
        {
            var datastore = datastoresManager.CreateAsync(new Datastore {Name = "testStore"}).Result;
            var file1 = structuredFilesManager.CreateAsync(new StructuredFile {DatastoreId = datastore.Id, FilePath = "t",}).Result;
            var file2 = unstructuredFilesManager.CreateAsync(new UnstructuredFile {DatastoreId = datastore.Id, FilePath = "tt"}).Result;
            Assert.IsTrue(structuredFilesManager.GetAsync(file1.Id).Result.FilePath == "t", "Failed to GET file1.");
            Assert.IsTrue(unstructuredFilesManager.GetAsync(file2.Id).Result.FilePath == "tt", "Failed to GET file2.");
            try 
            {
                var file3 = structuredFilesManager.CreateAsync(new StructuredFile {DatastoreId = datastore.Id, FilePath = ""}).Result;
                Assert.IsTrue(false, "Created a file with and empty name.");
            } catch {}
            Assert.Pass();
        }
    }
}