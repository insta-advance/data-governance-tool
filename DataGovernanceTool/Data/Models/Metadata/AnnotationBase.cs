using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations; 
using DataGovernanceTool.Data.Models.Metadata;
using DataGovernanceTool.Data.Models.Metadata.Structure;

namespace DataGovernanceTool.Data.Models.Metadata
{
    public class AnnotationBase : SuperBase
    {
        /* Annotation */
        public int AnnotationId { get; set; }
        public Annotation Annotation { get; set; }

        /* Base that has a annotation. */
        public int BaseId { get; set; }
        public Base Base { get; set; }
    }
}