using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations; 

namespace DataGovernanceTool.Data.Models.Metadata.Structure
{
    public class PostgresDatabase : Database
    {
        public List<Schema> Schemas { get; set; }
    }
}