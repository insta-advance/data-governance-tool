using System.ComponentModel.DataAnnotations; 

namespace DataGovernanceTool.Data.Models.Metadata.Structure
{
    public class File : Structured
    {
        public string FilePath { get; set; }
        public Datastore Datastore { get; set; }
        public int DatastoreId { get; set; }
    }
}