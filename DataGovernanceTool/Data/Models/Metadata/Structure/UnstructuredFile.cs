using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations; 

namespace DataGovernanceTool.Data.Models.Metadata.Structure
{
    public class UnstructuredFile : Base
    {
        public string FilePath { get; set; }
        public Datastore Datastore { get; set; }
        public int DatastoreId { get; set; }
    }
}