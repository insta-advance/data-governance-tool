using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace System_for_data_governance
{
    public class Table
    {
        public int TableId { get; set; }
        public string TableType { get; set; }
        public string TableName { get; set; }
        public Schema schema { get; set; }

        public List<Field> Fields { get; set; }

        public List<RelationshipTable> RelationshipTables { get; set; }
    }
}