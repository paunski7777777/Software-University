namespace CarDealer.App.DTOs.Import
{
    using System.Xml.Serialization;

    [XmlType("supplier")]
    public class SupplierDTO
    {
        [XmlAttribute("name")]
        public string Name { get; set; }

        [XmlAttribute("is-importer")]
        public bool IsImporter { get; set; }
    }
}