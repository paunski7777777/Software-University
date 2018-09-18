namespace SoftJail.DataProcessor.ExportDto
{
    using System.Collections.Generic;
    using System.Xml.Serialization;

    [XmlType("Prisoner")]
    public class PrisonerDto
    {
        [XmlElement("Id")]
        public int Id { get; set; }

        [XmlElement("Name")]
        public string Name { get; set; }

        [XmlElement("IncarcerationDate")]
        public string IncarcerationDate { get; set; }

        [XmlArray("EncryptedMessages")]
        public List<MessageDto> EncryptedMessages { get; set; }
    }
}