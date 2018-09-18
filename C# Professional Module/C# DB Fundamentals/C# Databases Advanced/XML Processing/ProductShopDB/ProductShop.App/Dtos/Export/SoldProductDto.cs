namespace ProductShop.App.Dtos.Export
{
    using System.Collections.Generic;
    using System.Xml.Serialization;

    [XmlType("sold-products")]
    public class SoldProductDto
    {
        [XmlAttribute("count")]
        public int Count { get; set; }

        [XmlElement("product")]
        public List<ProductUdto> ProductUdtos { get; set; }
    }
}