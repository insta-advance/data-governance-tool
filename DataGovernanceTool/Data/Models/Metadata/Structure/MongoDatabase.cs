using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations; 

namespace DataGovernanceTool.Data.Models.Metadata.Structure
{
    public class MongoDatabase : Database 
    {
        public List<Collection> Collections { get; set; }
    }
}