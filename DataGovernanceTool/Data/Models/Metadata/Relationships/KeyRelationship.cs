using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations; 
using DataGovernanceTool.Data.Models.Metadata.Structure;

namespace DataGovernanceTool.Data.Models.Metadata.Relationships
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