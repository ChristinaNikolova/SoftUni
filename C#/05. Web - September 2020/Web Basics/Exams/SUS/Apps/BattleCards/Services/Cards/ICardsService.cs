using BattleCards.ViewModels.Cards;
using System.Collections.Generic;

namespace BattleCards.Services.Cards
{
    public interface ICardsService
    {
        IEnumerable<AllCardsViewModel> GetAll();

        IEnumerable<AllCardsViewModel> GetUsersCards(string userId);

        int AddCard(string name, string description, string keyword, string image, int attack, int health);

        bool AddToCollection(int cardId, string userId);

        bool RemoveFromCollection(int cardId, string userId);
    }
}
