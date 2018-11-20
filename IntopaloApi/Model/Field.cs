using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IntopaloApi.System_for_data_governance
{
    public class Field : Base
    {
        public string FieldName { get; set; }
        public string FieldType { get; set; }
        /* Field is either part of Collection, Table or StructuredFile. */
        public StructuredBase StructuredBase { get; set; }
    }
}