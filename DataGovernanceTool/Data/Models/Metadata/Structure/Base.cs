using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using DataGovernanceTool.Data.Models.Metadata;
using DataGovernanceTool.Data.Models.Metadata.Relationships;
using DataGovernanceTool.Data.Models;

namespace DataGovernanceTool.Data.Models.Metadata.Structure
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