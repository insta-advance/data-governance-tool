using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations; 

namespace IntopaloApi.System_for_data_governance
{
    public class CompositeKeyField
    {
        /* PK in metadata */
        public int FieldId { get; set; }
        public Field Field { get; set; }

        /* FK in metadata */
        public int CompositeKeyId { get; set; }
        public CompositeKey CompositeKey { get; set; }
    }
}