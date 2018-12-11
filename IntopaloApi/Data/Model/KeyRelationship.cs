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
        public int FromId { get; set; }
        public Base From { get; set; }

        /* FK in metadata */
        public int ToId { get; set; }
        public Base To { get; set; }

        /* "exact" or "regex" */
        public string Type { get; set; }
    }
}