using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace System_for_data_governance
{
    public class Structured_File
    {
        public int SFId { get; set; }
        public string TableType { get; set; }
        public string FilePath { get; set; }

        public List<Field> Field { get; set; }

        public List<RelationshipTable> RelationshipTables { get; set; }

    }
}