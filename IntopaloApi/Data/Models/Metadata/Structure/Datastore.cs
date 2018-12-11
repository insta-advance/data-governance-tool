using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IntopaloApi.System_for_data_governance
{
    public class Datastore
    {   
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Database> Databases { get; set; }
        public List<StructuredFile> StructuredFiles  { get; set; }
        public List<UnstructuredFile> UnstructuredFiles  { get; set; }
    }
}