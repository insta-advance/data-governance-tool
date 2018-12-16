using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using DataGovernanceTool.Data.Models.Metadata;
using DataGovernanceTool.Data.Models.Metadata.Relationships;
using DataGovernanceTool.Data.Models;

namespace DataGovernanceTool.Data.Models.Metadata.Structure
{
    public abstract class SuperBase
    {
        /* Id for all tables containing metadata elements.*/
        [Key]
        public int Id { get; set; }
        
        
    }
}