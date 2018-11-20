using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations; 

namespace IntopaloApi.System_for_data_governance
{
    public class KeyRelationship
    {
        /* PK in metadata */
        public int BaseFromId { get; set; }
        public Base BaseFrom { get; set; }

        /* FK in metadata */
        public int BaseToId { get; set; }
        public Base BaseTo { get; set; }

        /* "exact" or "regex" */
        public string Type { get; set; }
    }
}