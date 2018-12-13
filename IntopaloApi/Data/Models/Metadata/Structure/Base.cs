using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace IntopaloApi.System_for_data_governance
{
    public abstract class Base
    {
        /* Id for all tables containing metadata elements.*/
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        /* Many-to-Many between PK and FK in metadata. */
        public List<KeyRelationship> PrimaryKeyTo { get; set; }
        public List<KeyRelationship> ForeignKeyTo { get; set; }
        public List<Annotation> Annotations { get; set; }
    }
}