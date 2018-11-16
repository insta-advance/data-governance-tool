using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace System_for_data_governance
{
    public class Collection
    {
        public int CollectionId { get; set; }
        public string TableType { get; set; }
        public string CollectionName { get; set; }
        public Database Database { get; set; }

        public List<Field> Fields { get; set; }
        public List<RelationshipTable> RelationshipTables { get; set; }
    }
}