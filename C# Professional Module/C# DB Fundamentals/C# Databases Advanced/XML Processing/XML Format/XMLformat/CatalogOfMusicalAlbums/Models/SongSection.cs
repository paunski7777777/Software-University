namespace CatalogOfMusicalAlbums.Models
{
    using System.Collections.Generic;
    using System.Xml.Serialization;

    [XmlType("songs")]
    public class SongSection
    {
        [XmlElement("song")]
        public List<SongDto> Songs { get; set; }
    }
}