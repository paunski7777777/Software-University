
namespace Instagraph.DataProcessor.Dtos.Import
{
    using System.Xml.Serialization;
    
    public class CommentPostDto
    {
        [XmlAttribute("id")]
        public string Id { get; set; }
    }
}