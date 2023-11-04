using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;


using Newtonsoft.Json;

using VaporStore.Data;
using VaporStore.DataProcessor.Dto.Export;

namespace VaporStore.DataProcessor
{
    public static class Serializer
    {
        public static string ExportGamesByGenres(VaporStoreDbContext context, string[] genreNames)
        {
            var genres = context
                .Genres
                .ToList()
                .Where(g => genreNames.Contains(g.Name)
                            && g.Games.Any(ga => ga.Purchases.Any()))
                .Select(g => new
                {
                    g.Id,
                    Genre = g.Name,
                    Games = g.Games
                    .Where(ga => ga.Purchases.Any())
                    .Select(ga => new
                    {
                        ga.Id,
                        Title = ga.Name,
                        Developer = ga.Developer.Name,
                        Tags = string.Join(", ", ga.GameTags.Select(gt => gt.Tag.Name)),
                        Players = ga.Purchases.Count(),
                    })
                    .OrderByDescending(ga => ga.Players)
                    .ThenBy(ga => ga.Id)
                    .ToList(),
                    TotalPlayers = g.Games.Sum(ga => ga.Purchases.Count())
                })
                .OrderByDescending(g => g.TotalPlayers)
                .ThenBy(g => g.Id)
                .ToList();

            string jsonResult = JsonConvert
                .SerializeObject(genres, new JsonSerializerSettings()
                {
                    Formatting = Newtonsoft.Json.Formatting.Indented,
                });

            return jsonResult.TrimEnd();
        }

        public static string ExportUserPurchasesByType(VaporStoreDbContext context, string storeType)
        {
            var users = context
                .Users
                .ToList()
                .Where(u => u.Cards.Any(c => c.Purchases.Any(p => p.Type.ToString() == storeType)))
                .Select(u => new ExportUserPurchasesByTypeDto
                {
                    Username = u.Username,
                    Purchases = u.Cards
                      .SelectMany(c => c.Purchases)
                       .Where(p => p.Type.ToString() == storeType)
                       .OrderBy(p => p.Date)
                       .Select(p => new ExportPurchaseDto
                       {
                           CardNumber = p.Card.Number,
                           CardCvc = p.Card.Cvc,
                           PurchaseDate = p.Date.ToString("yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture),
                           Game = new ExportGameDto
                           {
                               GameName = p.Game.Name,
                               Genre = p.Game.Genre.Name,
                               Price = p.Game.Price
                           }
                       })
                       .ToArray(),
                    TotalSpent = u.Cards.Sum(c => c.Purchases.Where(p => p.Type.ToString() == storeType).Sum(p => p.Game.Price))
                })
                .OrderByDescending(u => u.TotalSpent)
                .ThenBy(u => u.Username)
                .ToList();

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<ExportUserPurchasesByTypeDto>), new XmlRootAttribute("Users"));

            StringBuilder sb = new StringBuilder();

            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces(new[]
            {
                XmlQualifiedName.Empty
            });

            xmlSerializer.Serialize(new StringWriter(sb), users, namespaces);

            return sb.ToString().TrimEnd();
        }
    }
}