namespace PetClinic.Dtos.Import
{
    using System.Xml.Serialization;

    [XmlType("AnimalAid")]
    public class AnimalAidProcedureDto
    {
        public string Name { get; set; }
    }
}