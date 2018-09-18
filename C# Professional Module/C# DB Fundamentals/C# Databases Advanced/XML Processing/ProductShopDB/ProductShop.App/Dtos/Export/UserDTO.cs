namespace ProductShop.App.Dtos.Export
{
    using System.Collections.Generic;
    using System.Xml.Serialization;

    [XmlType("user")]
    public class UserDTO
    {
        [XmlAttribute("first-name")]
        public string FirstName { get; set; }

        [XmlAttribute("last-name")]
        public string LastName { get; set; }

        [XmlElement("sold-products")]
        public List<SoldProduct> SoldProducts { get; set; }
    }
}