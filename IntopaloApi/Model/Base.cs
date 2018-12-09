using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations; 


namespace IntopaloApi.System_for_data_governance
{
    public class Base
    {
        /* Id for all tables containing metadata elements.*/
        public int Id { get; set; }
        [Required]
        // StringLength doesn't seem to have any effect, possibly due the Sqlite TEXT type.
        [StringLength(20, MinimumLength = 5, ErrorMessage = "The length of the name is incorrect")]
        public string Name { get; set; }
        /* Many-to-Many between PK and FK in metadata. */
        public List<KeyRelationship> PrimaryKeyTo { get; set; }
        public List<KeyRelationship> ForeignKeyTo { get; set; }
        public List<Annotation> Annotations { get; set; }
    }
}