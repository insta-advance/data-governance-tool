using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IntopaloApi.System_for_data_governance
{
    public class Schema : Base
    {
        public string SchemaName { get; set; }
        public Database Database { get; set; }
        public List<Table> Tables { get; set; }
    }
}