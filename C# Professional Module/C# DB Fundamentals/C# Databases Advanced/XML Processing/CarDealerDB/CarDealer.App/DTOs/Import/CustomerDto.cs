namespace CarDealer.App.DTOs.Import
{
    using System.Xml.Serialization;

    [XmlType("customer")]
    public class CustomerDTO
    {
        [XmlAttribute("name")]
        public string Name { get; set; }

        [XmlElement("birth-date")]
        public string BirthDate { get; set; }

        [XmlElement("is-young-driver")]
        public bool IsYoungDriver { get; set; }
    }
}