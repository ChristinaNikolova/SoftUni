using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;


using Newtonsoft.Json;

using VaporStore.Data;
using VaporStore.Data.Models;
using VaporStore.Data.Models.Enums;
using VaporStore.DataProcessor.Dto.Import;

namespace VaporStore.DataProcessor
{
    public static class Deserializer
    {
        public static string ImportGames(VaporStoreDbContext context, string jsonString)
        {
            StringBuilder sb = new StringBuilder();

            List<ImportGameDto> importGameDtos = JsonConvert
                .DeserializeObject<List<ImportGameDto>>(jsonString)
                .ToList();

            List<Game> games = new List<Game>();
            List<GameTag> gameTags = new List<GameTag>();

            foreach (ImportGameDto importGameDto in importGameDtos)
            {
                if (!IsValid(importGameDto))
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }

                if (importGameDto.Tags.Length <= 0)
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }

                Developer developer = context.Developers
                    .FirstOrDefault(d => d.Name == importGameDto.Developer);

                if (developer == null)
                {
                    developer = new Developer()
                    {
                        Name = importGameDto.Developer,
                    };

                    context.Developers.Add(developer);
                    context.SaveChanges();
                }

                Genre genre = context.Genres
                    .FirstOrDefault(g => g.Name == importGameDto.Genre);

                if (genre == null)
                {
                    genre = new Genre()
                    {
                        Name = importGameDto.Genre,
                    };

                    context.Genres.Add(genre);
                    context.SaveChanges();
                }

                Game game = new Game()
                {
                    Name = importGameDto.Name,
                    Price = importGameDto.Price,
                    ReleaseDate = DateTime.ParseExact(importGameDto.ReleaseDate, "yyyy-MM-dd", CultureInfo.InvariantCulture),
                    Developer = developer,
                    Genre = genre
                };

                games.Add(game);

                foreach (string currentTagName in importGameDto.Tags)
                {
                    Tag tag = context.Tags
                        .FirstOrDefault(t => t.Name == currentTagName);

                    if (tag == null)
                    {
                        tag = new Tag()
                        {
                            Name = currentTagName,
                        };

                        context.Tags.Add(tag);
                        context.SaveChanges();
                    }

                    GameTag gameTag = new GameTag()
                    {
                        Tag = tag,
                        Game = game,
                    };

                    game.GameTags.Add(gameTag);
                    gameTags.Add(gameTag);
                }

                sb.AppendLine($"Added {game.Name} ({game.Genre.Name}) with {game.GameTags.Count()} tags");
            }

            context.Games.AddRange(games);
            context.GameTags.AddRange(gameTags);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportUsers(VaporStoreDbContext context, string jsonString)
        {
            StringBuilder sb = new StringBuilder();

            List<ImportUserDto> importUserDtos = JsonConvert
                .DeserializeObject<List<ImportUserDto>>(jsonString)
                .ToList();

            List<User> users = new List<User>();
            List<Card> cards = new List<Card>();

            foreach (ImportUserDto importUserDto in importUserDtos)
            {
                if (!IsValid(importUserDto))
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }

                if (importUserDto.Cards.Length <= 0)
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }

                User user = new User()
                {
                    FullName = importUserDto.FullName,
                    Username = importUserDto.Username,
                    Age = importUserDto.Age,
                    Email = importUserDto.Email,
                };

                bool hasToAddUser = true;

                foreach (ImportCardDto importCardDto in importUserDto.Cards)
                {
                    if (!IsValid(importCardDto))
                    {
                        sb.AppendLine("Invalid Data");
                        hasToAddUser = false;
                        break;
                    }

                    bool isCardTypeValid = Enum.TryParse<CardType>(importCardDto.Type, out CardType cardType);

                    if (!isCardTypeValid)
                    {
                        sb.AppendLine("Invalid Data");
                        hasToAddUser = false;
                        break;
                    }

                    Card card = new Card()
                    {
                        Cvc = importCardDto.Cvc,
                        Number = importCardDto.Number,
                        Type = cardType,
                    };

                    user.Cards.Add(card);
                }

                if (!hasToAddUser)
                {
                    continue;
                }

                users.Add(user);
                cards.AddRange(user.Cards);

                sb.AppendLine($"Imported {user.Username} with {user.Cards.Count()} cards");
            }

            context.Users.AddRange(users);
            context.Cards.AddRange(cards);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportPurchases(VaporStoreDbContext context, string xmlString)
        {
            StringBuilder sb = new StringBuilder();

            XmlSerializer xmlSerializer =
                new XmlSerializer(typeof(List<ImportPurchaseDto>), new XmlRootAttribute("Purchases"));

            List<ImportPurchaseDto> importPurchaseDtos =
                  (List<ImportPurchaseDto>)xmlSerializer.Deserialize(new StringReader(xmlString));

            List<Purchase> purchases = new List<Purchase>();

            foreach (ImportPurchaseDto importPurchaseDto in importPurchaseDtos)
            {
                if (!IsValid(importPurchaseDto))
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }

                Game game = context.Games
                    .FirstOrDefault(g => g.Name == importPurchaseDto.GameName);

                if (game == null)
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }

                bool isPurchaseTypeValid = Enum.TryParse<PurchaseType>(importPurchaseDto.Type, out PurchaseType purchaseType);

                if (!isPurchaseTypeValid)
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }

                Card card = context.Cards
                    .FirstOrDefault(c => c.Number == importPurchaseDto.CardNumber);

                if (card == null)
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }

                bool isDateValid = DateTime.TryParseExact(importPurchaseDto.Date, "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime date);

                if (!isDateValid)
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }

                Purchase purchase = new Purchase()
                {
                    Type = purchaseType,
                    ProductKey = importPurchaseDto.ProductKey,
                    Date = date,
                    Card = card,
                    Game = game,
                };

                purchases.Add(purchase);

                sb.AppendLine($"Imported {game.Name} for {card.User.Username}");
            }

            context.Purchases.AddRange(purchases);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        private static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
    }
}