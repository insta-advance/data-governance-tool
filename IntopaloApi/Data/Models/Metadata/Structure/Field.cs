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
        public string Type { get; set; }
        /* Field is either part of Collection, Table, StructuredFile or Field (nested!). */
        public int StructuredId { get; set; }
        public Structured Structured { get; set; }
        public List<CompositeKeyField> CompositeKeyFields { get; set; }
    }
}