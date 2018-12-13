using DataGovernanceTool.Data.Models.Metadata.Structure;

namespace DataGovernanceTool.Data
{
    public class Annotation
    {
        public int AnnotationId { get; set; }
        public string Description { get; set; }
	    public Base Base { get; set; }
    }
}