using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DataGovernanceTool.Data.Models.Metadata.Structure
{
    public class Structured : Base
    {
        public List<Field> Fields { get; set; }
    }
}