namespace ProductShop.App.Dtos.Export
{
    using System.Xml.Serialization;

    [XmlType("product")]
    public class ProductDTO
    {
        [XmlAttribute("name")]
        public string Name { get; set; }

        [XmlAttribute("price")]
        public decimal Price { get; set; }

        [XmlAttribute("buyer")]
        public string Buyer { get; set; }
    }
}