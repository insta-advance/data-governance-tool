using System.ComponentModel.DataAnnotations; 

namespace IntopaloApi.System_for_data_governance
{
    public class StructuredFile : Structured
    {
        public string FilePath { get; set; }
        public Datastore Datastore { get; set; }
        public int DatastoreId { get; set; }
    }
}