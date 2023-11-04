using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Heroes
{
    public class HeroRepository
    {
        private List<Hero> data;

        public HeroRepository()
        {
            this.data = new List<Hero>();
        }

        public int Count => this.data.Count;

        public void Add(Hero hero)
        {
            this.data.Add(hero);
        }

        public void Remove(string name)
        {
            int indexHero = this.data.FindIndex(x => x.Name == name);

            if (indexHero != -1)
            {
                this.data.RemoveAt(indexHero);
            }
        }

        public Hero GetHeroWithHighestStrength()
        {
            Hero heroToReturn = this.data
                .OrderByDescending(x => x.Item.Strength)
                .FirstOrDefault();

            return heroToReturn;
        }

        public Hero GetHeroWithHighestAbility()
        {
            Hero heroToReturn = this.data
                .OrderByDescending(x => x.Item.Ability)
                .FirstOrDefault();

            return heroToReturn;
        }

        public Hero GetHeroWithHighestIntelligence()
        {
            Hero heroToReturn = this.data
                .OrderByDescending(x => x.Item.Intelligence)
                .FirstOrDefault();

            return heroToReturn;
        }

        public override string ToString()
        {
            StringBuilder message = new StringBuilder();

            foreach (Hero hero in this.data)
            {
                message.AppendLine(hero.ToString());
            }

            return message.ToString().TrimEnd();
        }
    }
}
