namespace CatalogOfMusicalAlbums.Models
{
    using System.Collections.Generic;
    using System.Xml.Serialization;

    [XmlType("album")]
    public class AlbumDto
    {
        [XmlElement("name")]
        public string Name { get; set; }

        [XmlElement("artist")]
        public string Artist { get; set; }

        [XmlElement("year")]
        public int Year { get; set; }

        [XmlElement("producer")]
        public string Producer { get; set; }

        [XmlElement("price")]
        public decimal Price { get; set; }

        [XmlElement("songs")]
        public SongSection Songs { get; set; }
    }
}