namespace ProductShop.App.Dtos.Export
{
    using System.Xml.Serialization;

    [XmlType("user")]
    public class UserPdto
    {
        [XmlAttribute("first-name")]
        public string FirstName { get; set; }

        [XmlAttribute("last-name")]
        public string LastName { get; set; }

        [XmlAttribute("age")]
        public string Age { get; set; }

        [XmlElement("sold-products")]
        public SoldProductDto SoldProducts { get; set; }
    }
}