using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DataGovernanceTool.Data.Models.Metadata.Structure
{
    public class Collection : Structured
    {
        public MongoDatabase Database { get; set; }
        public int DatabaseId { get; set; }
    }
}