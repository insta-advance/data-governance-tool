using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations; 
using DataGovernanceTool.Data.Models.Metadata.Structure;

namespace DataGovernanceTool.Data.Models.Metadata.Relationships
{
    public class CompositeKeyField : SuperBase
    {
        /* PK in metadata */
        public int FieldId { get; set; }
        public Field Field { get; set; }

        /* FK in metadata */
        public int CompositeKeyId { get; set; }
        public CompositeKey CompositeKey { get; set; }
    }
}