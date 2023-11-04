using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

using Newtonsoft.Json;
using Formatting = Newtonsoft.Json.Formatting;

using MusicHub.Data;
using MusicHub.DataProcessor.ExportDtos;

namespace MusicHub.DataProcessor
{
    public class Serializer
    {
        public static string ExportAlbumsInfo(MusicHubDbContext context, int producerId)
        {
            var albums = context
                .Albums
                .Where(a => a.ProducerId == producerId)
                .OrderByDescending(a => a.Price)
                .Select(a => new
                {
                    AlbumName = a.Name,
                    ReleaseDate = a.ReleaseDate.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture),
                    ProducerName = a.Producer.Name,
                    Songs = a.Songs
                    .OrderByDescending(s => s.Name)
                    .ThenBy(s => s.Writer.Name)
                    .Select(s => new
                    {
                        SongName = s.Name,
                        Price = s.Price.ToString("F2"),
                        Writer = s.Writer.Name,
                    })
                    .ToList(),
                    AlbumPrice = a.Price.ToString("F2")
                })
                .ToList();

            string jsonResult = JsonConvert.SerializeObject(albums, new JsonSerializerSettings()
            {
                Formatting = Formatting.Indented,
            });

            return jsonResult.TrimEnd();
        }

        public static string ExportSongsAboveDuration(MusicHubDbContext context, int duration)
        {
            var songs = context
                .Songs
                .Where(s => s.Duration.TotalSeconds > duration)
                .Select(s => new ExportSongsAboveDurationDto
                {
                    SongName = s.Name,
                    Writer = s.Writer.Name,
                    Performer = s.SongPerformers.Select(sp => sp.Performer.FirstName + " " + sp.Performer.LastName).FirstOrDefault(),
                    AlbumProducer = s.Album.Producer.Name,
                    Duration = s.Duration.ToString("c", CultureInfo.InvariantCulture),
                })
                .OrderBy(s => s.SongName)
                .ThenBy(s => s.Writer)
                .ThenBy(s => s.Performer)
                .ToList();

            XmlSerializer xmlSerializer =
                new XmlSerializer(typeof(List<ExportSongsAboveDurationDto>), new XmlRootAttribute("Songs"));

            StringBuilder sb = new StringBuilder();

            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces(new[]
            {
                XmlQualifiedName.Empty,
            });

            using (StringWriter writer = new StringWriter(sb))
            {
                xmlSerializer.Serialize(writer, songs, namespaces);

                return sb.ToString().TrimEnd();
            }
        }
    }
}