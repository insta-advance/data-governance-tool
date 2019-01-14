using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DataGovernanceTool.Data.Models.Metadata.Relationships;

namespace DataGovernanceTool.Data.Models.Metadata.Structure
{
    public class Table : Structured
    {
        public string TableName { get; set; }
        public Schema Schema { get; set; }
        public int SchemaId { get; set; }
        public CompositeKey PrimaryKey { get; set; }
        public List<CompositeKey> ForeignKeys { get; set; }
    }
}