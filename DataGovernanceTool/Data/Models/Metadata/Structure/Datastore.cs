using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DataGovernanceTool.Data.Models.Metadata.Structure
{
    public class Datastore : SuperBase
    {   
        public string Name { get; set; }
        public List<Database> Databases { get; set; }
        public List<StructuredFile> StructuredFiles  { get; set; }
        public List<UnstructuredFile> UnstructuredFiles  { get; set; }
    }
}