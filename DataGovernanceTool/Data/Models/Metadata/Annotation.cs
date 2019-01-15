using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DataGovernanceTool.Data.Models.Metadata;
using DataGovernanceTool.Data.Models.Metadata.Structure;

namespace DataGovernanceTool.Data.Models.Metadata
{
    public class Annotation : SuperBase
    {
        public string Description { get; set; }
        public List<AnnotationBase> AnnotationBases { get; set; }
    }
}