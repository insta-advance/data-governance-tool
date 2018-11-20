using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace IntopaloApi.System_for_data_governance
{
    public class Table : StructuredBase
    {
        public string TableName { get; set; }
        public Schema Schema { get; set; }
    }
}