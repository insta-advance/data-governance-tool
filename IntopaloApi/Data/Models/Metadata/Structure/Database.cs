using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations; 

namespace IntopaloApi.System_for_data_governance
{
    public class Database : Base
    {
        public string Type { get; set; }
        public List<Schema> Schemas { get; set; }
        public List<Collection> Collections { get; set; }
        public Datastore Datastore { get; set; }
        public int DatastoreId { get; set; }
    }
}