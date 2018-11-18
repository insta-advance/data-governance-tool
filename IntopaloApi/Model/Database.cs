using System.ComponentModel.DataAnnotations; 

namespace IntopaloApi.System_for_data_governance
{
    public class Database
    {
        [Key]
        public int DBId { get; set; }
        public string TableType { get; set; }
        public string DBName { get; set; }
        public string DBType { get; set; }
        //public List<Schema> Schemas { get; set; }
        //public List<Collection> Collections { get; set; }
        //public List<RelationshipTable> RelationshipTables { get; set; }

    }
}