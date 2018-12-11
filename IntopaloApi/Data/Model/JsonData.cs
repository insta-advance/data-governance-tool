using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IntopaloApi.System_for_data_governance
{
    public class JsonData
    {
        public List<Collection> jsonCollections;
        public List<Database> jsonDatabases;
        public List<Field> jsonFields;
        public List<KeyRelationship> jsonKeyRelationships;
        public List<Schema> jsonSchemas;
        public List<StructuredFile> jsonStructuredFiles;
        public List<Table> jsonTables;
        public List<UnstructuredFile> jsonUnstructuredFiles;


    }
}