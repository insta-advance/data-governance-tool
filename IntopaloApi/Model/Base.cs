using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IntopaloApi.System_for_data_governance
{
    public class Base
    {
        /* Id for all tables containing metadata elements.*/
        public int Id { get; set; }
        public string Name { get; set; }
        /* Many-to-Many between PK and FK in metadata. */
        public List<KeyRelationship> PrimaryKeyTo { get; set; }
        public List<KeyRelationship> ForeignKeyTo { get; set; }
        public List<Annotation> Annotations { get; set; }
    }
}