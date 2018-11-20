using System.ComponentModel.DataAnnotations; 

namespace IntopaloApi.System_for_data_governance
{
    public class Database : Base
    {
        public string DBName { get; set; }
        public string DBType { get; set; }
    }
}