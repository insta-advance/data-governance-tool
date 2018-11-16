using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace System_for_data_governance
{
    public class Schema
    {
        public int SchemaId { get; set; }
        public string TableType { get; set; }
        public string SchemaName{ get; set; }
        public Database Databases { get; set; }
        public List<Table> Tables { get; set; }
        public List<RelationshipTable> RelationshipTables { get; set; }
    }
}