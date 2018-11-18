using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations; 

namespace IntopaloApi.System_for_data_governance
{
    public class Unstructured_File
    {
        [Key]
        public int USFId { get; set; }
        public string FilePath { get; set; }
        public string TableType { get; set; }

        //public List<RelationshipTable> RelationshipTables { get; set; }
    }
}