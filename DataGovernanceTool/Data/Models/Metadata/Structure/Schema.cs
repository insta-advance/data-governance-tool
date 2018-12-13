using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DataGovernanceTool.Data.Models.Metadata.Structure
{
    public class Schema : Base
    {
        public string SchemaName { get; set; }
        public Database Database { get; set; }
        public int DatabaseId { get; set; }
        public List<Table> Tables { get; set; }
    }
}