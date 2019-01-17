using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DataGovernanceTool.Data.Models.Metadata.Relationships;
using DataGovernanceTool.Data.Models.Metadata;

namespace DataGovernanceTool.Data.Models.Metadata.Structure
{
    public class JsonData
    {
        public List<Collection> jsonCollections;
        public List<MongoDatabase> jsonMongoDatabases;
        public List<PostgresDatabase> jsonPostgresDatabases;
        public List<Field> jsonFields;
        public List<KeyRelationship> jsonKeyRelationships;
        public List<Schema> jsonSchemas;
        public List<StructuredFile> jsonStructuredFiles;
        public List<Table> jsonTables;
        public List<UnstructuredFile> jsonUnstructuredFiles;


    }
}