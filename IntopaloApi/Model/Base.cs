using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IntopaloApi.System_for_data_governance
{
    public class Base
    {
        /* Id for all tables containing metadata elements.*/
        public int BaseID { get; set; }
        /* Many-to-Many between PK and FK in metadata. */
        public ICollection<KeyRelationship> KeyRelationshipFrom { get; set; }
        public ICollection<KeyRelationship> KeyRelationshipTo { get; set; }
    }
}