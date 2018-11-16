using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace System_for_data_governance
{
    public class Field
    {
        public int FieldId { get; set; }
        public string FieldName { get; set; }
        public string FieldType { get; set; }
        public string KeyType { get; set; }

        public string TableType { get; set; }
        public string OwnerType { get; set; }
        public int OwnerId { get; set; }
        public Collection Collection { get; set; }
        public Table Table { get; set; }
        public Structured_File Structured_File { get; set; }

        public List<RelationshipTable> RelationshipTables { get; set; }
    }
}