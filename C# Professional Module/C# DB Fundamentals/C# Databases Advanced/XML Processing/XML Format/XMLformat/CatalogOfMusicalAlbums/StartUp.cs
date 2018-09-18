namespace CatalogOfMusicalAlbums
{
    using CatalogOfMusicalAlbums.Models;

    using System.Collections.Generic;
    using System.IO;
    using System.Xml;
    using System.Xml.Serialization;

    public class StartUp
    {
        public static void Main()
        {
            var serializer = new XmlSerializer(typeof(List<AlbumDto>), new XmlRootAttribute("albums"));
            var namespaces = new XmlSerializerNamespaces(new[] { new XmlQualifiedName("", "") });

            var albums = GetAlbums();

            using (TextWriter writer = new StreamWriter("../../../catalog.xml"))
            {
                serializer.Serialize(writer, albums, namespaces);
            }
        }
        private static List<AlbumDto> GetAlbums()
        {
            AlbumDto firstAlbum = new AlbumDto
            {
                Name = "Name1",
                Artist = "Artist1",
                Year = 2018,
                Producer = "Producer1",
                Price = 99.99m,
                Songs = new SongSection
                {
                    Songs = new List<SongDto>
                    {
                        new SongDto
                        {
                            Title = "Title1",
                            Duration = "99:99"
                        }
                    }
                }
            };

            AlbumDto secondAlbum = new AlbumDto
            {
                Name = "Name2",
                Artist = "Artist2",
                Year = 2017,
                Producer = "Producer2",
                Price = 88.99m,
                Songs = new SongSection
                {
                    Songs = new List<SongDto>
                    {
                        new SongDto
                        {
                            Title = "Title2",
                            Duration = "88:88"
                        }
                    }
                }
            };

            AlbumDto tirthAlbum = new AlbumDto
            {
                Name = "Name3",
                Artist = "Artist3",
                Year = 2016,
                Producer = "Producer3",
                Price = 77.99m,
                Songs = new SongSection
                {
                    Songs = new List<SongDto>
                    {
                        new SongDto
                        {
                            Title = "Title3",
                            Duration = "77:77"
                        }
                    }
                }
            };

            return new List<AlbumDto> { firstAlbum, secondAlbum, tirthAlbum };
        }
    }
}