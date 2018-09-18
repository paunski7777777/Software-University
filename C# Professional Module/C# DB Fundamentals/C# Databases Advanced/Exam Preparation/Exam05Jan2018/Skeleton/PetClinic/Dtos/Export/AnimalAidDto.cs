using System.Xml.Serialization;

namespace PetClinic.Dtos.Export
{
    [XmlType("AnimalAid")]
    public class AnimalAidDto
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
    }
}