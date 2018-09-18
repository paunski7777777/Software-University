namespace ProductShop.App.Dtos.Export
{
    using System.Collections.Generic;
    using System.Xml.Serialization;

    [XmlRoot("users")]
    public class UserRootDto
    {
        [XmlAttribute("count")]
        public int Count { get; set; }

        [XmlElement("user")]
        public List<UserPdto> Users { get; set; }
    }
}