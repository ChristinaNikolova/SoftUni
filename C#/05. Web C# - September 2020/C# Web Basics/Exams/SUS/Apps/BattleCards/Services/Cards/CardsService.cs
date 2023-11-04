using BattleCards.Data;
using BattleCards.Models;
using BattleCards.ViewModels.Cards;
using System.Collections.Generic;
using System.Linq;

namespace BattleCards.Services.Cards
{
    public class CardsService : ICardsService
    {
        private readonly ApplicationDbContext db;

        public CardsService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public int AddCard(string name, string description, string keyword, string image, int attack, int health)
        {
            var card = new Card()
            {
                Name = name,
                Description = description,
                Keyword = keyword,
                ImageUrl = image,
                Attack = attack,
                Health = health,
            };

            this.db.Cards.Add(card);
            this.db.SaveChanges();

            return card.Id;
        }

        public bool AddToCollection(int cardId, string userId)
        {
            var isSuccess = true;

            var isCardAlreadyAdded = this.db
                .UserCards
                .Any(uc => uc.CardId == cardId && uc.UserId == userId);

            if (isCardAlreadyAdded)
            {
                isSuccess = false;
                return isSuccess;
            }

            var userCard = new UserCard()
            {
                CardId = cardId,
                UserId = userId,
            };

            this.db.UserCards.Add(userCard);
            this.db.SaveChanges();

            return isSuccess;
        }

        public IEnumerable<AllCardsViewModel> GetAll()
        {
            var cards = this.db
                .Cards
                .Select(c => new AllCardsViewModel()
                {
                    Id = c.Id,
                    Name = c.Name,
                    Description = c.Description,
                    Keyword = c.Keyword,
                    ImageUrl = c.ImageUrl,
                    Attack = c.Attack,
                    Health = c.Health,
                })
                .ToList();

            return cards;
        }

        public IEnumerable<AllCardsViewModel> GetUsersCards(string userId)
        {
            var cards = this.db
               .Cards
               .Where(c => c.UserCards.Any(uc => uc.UserId == userId))
               .Select(c => new AllCardsViewModel()
               {
                   Id = c.Id,
                   Name = c.Name,
                   Description = c.Description,
                   Keyword = c.Keyword,
                   ImageUrl = c.ImageUrl,
                   Attack = c.Attack,
                   Health = c.Health,
               })
               .ToList();

            return cards;
        }

        public bool RemoveFromCollection(int cardId, string userId)
        {
            var isSuccess = true;

            var userCard = this.db
                .UserCards
                .FirstOrDefault(uc => uc.UserId == userId && uc.CardId == cardId);

            this.db.UserCards.Remove(userCard);
            var affectedRows = this.db.SaveChanges();

            return affectedRows != 0 ? isSuccess : !isSuccess;
        }
    }
}
