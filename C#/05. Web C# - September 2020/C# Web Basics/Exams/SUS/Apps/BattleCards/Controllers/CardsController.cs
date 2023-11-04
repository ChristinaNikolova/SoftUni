using BattleCards.Services.Cards;
using BattleCards.ViewModels.Cards;
using SUS.HTTP;
using SUS.MvcFramework;
using System;

namespace BattleCards.Controllers
{
    public class CardsController : Controller
    {
        private readonly ICardsService cardsService;

        public CardsController(ICardsService cardsService)
        {
            this.cardsService = cardsService;
        }

        public HttpResponse All()
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }

            var cards = this.cardsService.GetAll();

            return this.View(cards);
        }

        public HttpResponse Collection()
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }

            var userId = this.GetUserId();

            var cards = this.cardsService.GetUsersCards(userId);

            return this.View(cards);
        }

        public HttpResponse Add()
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }

            return this.View();
        }

        [HttpPost]
        public HttpResponse Add(AddCardInputModel input)
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }

            if (string.IsNullOrWhiteSpace(input.Name) || input.Name.Length < 5 || input.Name.Length > 15)
            {
                return this.Redirect("/Cards/Add");
            }

            if (string.IsNullOrWhiteSpace(input.Image))
            {
                return this.Redirect("/Cards/Add");
            }

            if (string.IsNullOrWhiteSpace(input.Keyword))
            {
                return this.Redirect("/Cards/Add");
            }

            if (string.IsNullOrWhiteSpace(input.Description) || input.Description.Length > 200)
            {
                return this.Redirect("/Cards/Add");
            }

            if (input.Attack < 0)
            {
                return this.Redirect("/Cards/Add");
            }

            if (input.Health < 0)
            {
                return this.Redirect("/Cards/Add");
            }

            if (!Uri.TryCreate(input.Image, UriKind.Absolute, out _))
            {
                return this.Redirect("/Cards/Add");
            }

            var cardId = this.cardsService.AddCard(input.Name, input.Description, input.Keyword, input.Image, input.Attack, input.Health);

            var userId = this.GetUserId();

            this.cardsService.AddToCollection(cardId, userId);

            return this.Redirect("/Cards/All");
        }

        public HttpResponse AddToCollection(int cardId)
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }

            var userId = this.GetUserId();

            var isSuccess = this.cardsService.AddToCollection(cardId, userId);

            if (!isSuccess)
            {
                return this.Redirect("/Cards/All");
            }

            return this.Redirect("/Cards/All");
        }

        public HttpResponse RemoveFromCollection(int cardId)
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }

            var userId = this.GetUserId();

            var isSuccess = this.cardsService.RemoveFromCollection(cardId, userId);

            if (!isSuccess)
            {
                return this.Redirect("/Cards/Collection");
            }

            return this.Redirect("/Cards/Collection");
        }
    }
}
