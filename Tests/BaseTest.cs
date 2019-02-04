using System;
using System.IO;
using System.Reflection;
using NUnit.Framework;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using DataGovernanceTool.BusinessLogic.IManagers;
using DataGovernanceTool.BusinessLogic.Managers;
using DataGovernanceTool.Data.Access.IRepositories;
using DataGovernanceTool.Data.Access.Repositories;
using DataGovernanceTool.Data.Access;

namespace Tests 
{
    public class BaseTest {
        public DataGovernanceDBContext DBContext { get; set; }

        [SetUp]
        public void PrepareTestDatabase()
        {
            Console.WriteLine("Setting up database.");
            //Connect & ensure creation
            DBContext = new DataGovernanceDBContext(
                new DbContextOptionsBuilder<DataGovernanceDBContext>()
                .UseNpgsql("Host=localhost;Database=DataGovernanceToolTestDB;Username=datagovernancetool;Password=datagovernancetool")
                .Options);
        }

        [TearDown]
        public void DisposeTestDatabase()
        {
            DBContext.Database.ExecuteSqlCommand("DELETE FROM \"AnnotationBases\"   ");
            DBContext.Database.ExecuteSqlCommand("DELETE FROM \"Annotations\"       ");
            DBContext.Database.ExecuteSqlCommand("DELETE FROM \"Bases\"             ");
            DBContext.Database.ExecuteSqlCommand("DELETE FROM \"CompositeKeyFields\"");
            DBContext.Database.ExecuteSqlCommand("DELETE FROM \"KeyRelationships\"  ");
            DBContext.Database.ExecuteSqlCommand("DELETE FROM \"Datastores\"        ");
        }
    }
}