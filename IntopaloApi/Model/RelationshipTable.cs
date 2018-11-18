using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations; 

namespace IntopaloApi.System_for_data_governance
{
    public class RelationshipTable
    {
        [Key]
        public int RTId { get; set; }
        public int TableId { get; set; }
        public string TableType { get; set; }
        public string TypeofRelation { get; set; }

        /*public Collection Collection { get; set; }
        public Table Table { get; set; }
        public Structured_File Structured_File { get; set; }
        public Field Field { get; set; }
        public Database Database { get; set; }
        public Unstructured_File Unstructured_File { get; set; }
        public Schema Schema { get; set; }
        */
    }
}