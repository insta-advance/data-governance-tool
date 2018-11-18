using System.ComponentModel.DataAnnotations; 

namespace IntopaloApi.System_for_data_governance
{
    public class Structured_File
    {
        [Key]
        public int SFId { get; set; }
        public string TableType { get; set; }
        public string FilePath { get; set; }

        //public List<Field> Field { get; set; }

        //public List<RelationshipTable> RelationshipTables { get; set; }

    }
}