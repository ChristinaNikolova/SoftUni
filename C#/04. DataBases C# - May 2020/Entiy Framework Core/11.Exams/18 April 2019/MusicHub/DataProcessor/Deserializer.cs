using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

using Newtonsoft.Json;

using MusicHub.Data;
using MusicHub.Data.Models;
using MusicHub.Data.Models.Enums;
using MusicHub.DataProcessor.ImportDtos;

namespace MusicHub.DataProcessor
{
    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data";

        private const string SuccessfullyImportedWriter
            = "Imported {0}";
        private const string SuccessfullyImportedProducerWithPhone
            = "Imported {0} with phone: {1} produces {2} albums";
        private const string SuccessfullyImportedProducerWithNoPhone
            = "Imported {0} with no phone number produces {1} albums";
        private const string SuccessfullyImportedSong
            = "Imported {0} ({1} genre) with duration {2}";
        private const string SuccessfullyImportedPerformer
            = "Imported {0} ({1} songs)";

        public static string ImportWriters(MusicHubDbContext context, string jsonString)
        {
            StringBuilder sb = new StringBuilder();

            List<ImportWriterDto> importWriterDtos = JsonConvert
                .DeserializeObject<List<ImportWriterDto>>(jsonString)
                .ToList();

            List<Writer> writers = new List<Writer>();

            foreach (ImportWriterDto importWriterDto in importWriterDtos)
            {
                if (!IsValid(importWriterDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Writer writer = new Writer()
                {
                    Name = importWriterDto.Name,
                    Pseudonym = importWriterDto.Pseudonym,
                };

                writers.Add(writer);

                sb.AppendLine(String.Format(SuccessfullyImportedWriter, writer.Name));
            }

            context.Writers.AddRange(writers);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportProducersAlbums(MusicHubDbContext context, string jsonString)
        {
            StringBuilder sb = new StringBuilder();

            List<ImportProducerDto> importProducerDtos = JsonConvert
                .DeserializeObject<List<ImportProducerDto>>(jsonString)
                .ToList();

            List<Producer> producers = new List<Producer>();
            List<Album> albums = new List<Album>();

            foreach (ImportProducerDto importProducerDto in importProducerDtos)
            {
                if (!IsValid(importProducerDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Producer producer = new Producer()
                {
                    Name = importProducerDto.Name,
                    Pseudonym = importProducerDto.Pseudonym,
                    PhoneNumber = importProducerDto.PhoneNumber,
                };

                bool hasToAddProducer = true;

                foreach (ImportAlbumDto importAlbumDto in importProducerDto.Albums)
                {
                    if (!IsValid(importAlbumDto))
                    {
                        sb.AppendLine(ErrorMessage);
                        hasToAddProducer = false;
                        break;
                    }

                    Album album = new Album()
                    {
                        Name = importAlbumDto.Name,
                        ReleaseDate = DateTime.ParseExact(importAlbumDto.ReleaseDate, "dd/MM/yyyy", CultureInfo.InvariantCulture),
                    };

                    producer.Albums.Add(album);
                }

                if (!hasToAddProducer)
                {
                    continue;
                }

                producers.Add(producer);
                albums.AddRange(producer.Albums);

                if (producer.PhoneNumber != null)
                {
                    sb.AppendLine(string.Format(SuccessfullyImportedProducerWithPhone, producer.Name, producer.PhoneNumber, producer.Albums.Count()));
                }
                else
                {
                    sb.AppendLine(string.Format(SuccessfullyImportedProducerWithNoPhone, producer.Name, producer.Albums.Count()));
                }
            }

            context.Producers.AddRange(producers);
            context.Albums.AddRange(albums);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportSongs(MusicHubDbContext context, string xmlString)
        {
            StringBuilder sb = new StringBuilder();

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<ImportSongDto>), new XmlRootAttribute("Songs"));

            using (StringReader reader = new StringReader(xmlString))
            {
                List<ImportSongDto> importSongDtos =
                    (List<ImportSongDto>)xmlSerializer.Deserialize(reader);

                List<Song> songs = new List<Song>();

                foreach (ImportSongDto importSongDto in importSongDtos)
                {
                    if (!IsValid(importSongDto))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    string[] validGenres = new[]
                    {
                        "Blues",
                        "Rap",
                        "PopMusic",
                        "Rock",
                        "Jazz",
                    };

                    bool isGenreValid = Enum.TryParse<Genre>(importSongDto.Genre, out Genre genre);

                    Album album = context.Albums.Find(importSongDto.AlbumId);
                    Writer writer = context.Writers.Find(importSongDto.WriterId);

                    if (album == null || writer == null || !validGenres.Contains(genre.ToString()))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    Song song = new Song()
                    {
                        Name = importSongDto.Name,
                        Duration = TimeSpan.ParseExact(importSongDto.Duration, "c", CultureInfo.InvariantCulture),
                        CreatedOn = DateTime.ParseExact(importSongDto.CreatedOn, "dd/MM/yyyy", CultureInfo.InvariantCulture),
                        Genre = genre,
                        Price = importSongDto.Price,
                        AlbumId = importSongDto.AlbumId,
                        WriterId = importSongDto.WriterId,
                    };

                    songs.Add(song);

                    sb.AppendLine(string.Format(SuccessfullyImportedSong, song.Name, song.Genre.ToString(), song.Duration));
                }

                context.Songs.AddRange(songs);
                context.SaveChanges();

                return sb.ToString().TrimEnd();
            }
        }

        public static string ImportSongPerformers(MusicHubDbContext context, string xmlString)
        {
            StringBuilder sb = new StringBuilder();

            XmlSerializer xmlSerializer =
                new XmlSerializer(typeof(List<ImportPerformerDto>), new XmlRootAttribute("Performers"));

            using (StringReader reader = new StringReader(xmlString))
            {
                List<ImportPerformerDto> importPerformerDtos =
                    (List<ImportPerformerDto>)xmlSerializer.Deserialize(reader);

                List<Performer> performers = new List<Performer>();
                List<SongPerformer> songPerformers = new List<SongPerformer>();

                foreach (ImportPerformerDto importPerformerDto in importPerformerDtos)
                {
                    if (!IsValid(importPerformerDto))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    Performer performer = new Performer()
                    {
                        FirstName = importPerformerDto.FirstName,
                        LastName = importPerformerDto.LastName,
                        Age = importPerformerDto.Age,
                        NetWorth = importPerformerDto.NetWorth,
                    };

                    bool hasToAddProducer = true;

                    foreach (ImportPerformerSongDto importPerformerSongDto in importPerformerDto.PerformersSongs)
                    {
                        Song song = context.Songs.Find(importPerformerSongDto.Id);

                        if (song == null)
                        {
                            sb.AppendLine(ErrorMessage);
                            hasToAddProducer = false;
                            break;
                        }

                        SongPerformer songPerformer = new SongPerformer()
                        {
                            SongId = song.Id,
                            PerformerId = performer.Id,
                        };

                        performer.PerformerSongs.Add(songPerformer);
                    }

                    if (!hasToAddProducer)
                    {
                        continue;
                    }

                    performers.Add(performer);
                    songPerformers.AddRange(performer.PerformerSongs);

                    sb.AppendLine(string.Format(SuccessfullyImportedPerformer, performer.FirstName, performer.PerformerSongs.Count()));
                }

                context.Performers.AddRange(performers);
                context.SongsPerformers.AddRange(songPerformers);
                context.SaveChanges();

                return sb.ToString().TrimEnd();
            }
        }

        private static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
    }
}