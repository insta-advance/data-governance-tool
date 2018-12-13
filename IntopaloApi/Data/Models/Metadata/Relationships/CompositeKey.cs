using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations; 

namespace IntopaloApi.System_for_data_governance
{
    public class CompositeKey : Base
    {
        public List<CompositeKeyField> CompositeKeyFields { get; set; }
    }
}