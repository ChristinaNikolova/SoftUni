using System;
using System.Collections.Generic;
using System.Text;

namespace ViceCity.Models.Guns
{
    public class Rifle : Gun
    {
        private const int DefaultBulletsPerBarrel = 50;
        private const int DefaultTotalBarrels = 500;
        private const int DefaultBulletsPerShoot = 5;
        public Rifle(string name) 
            : base(name, DefaultBulletsPerBarrel, DefaultTotalBarrels)
        {
        }

        public override int Fire()
        {
            if (this.BulletsPerBarrel - DefaultBulletsPerShoot > 0)
            {
                this.BulletsPerBarrel -= DefaultBulletsPerShoot;

                return DefaultBulletsPerShoot;
            }

            if (this.TotalBullets == 0)
            {
                return 0;
            }

            this.BulletsPerBarrel += DefaultBulletsPerBarrel;
            this.TotalBullets -= DefaultBulletsPerBarrel;

            this.BulletsPerBarrel -= DefaultBulletsPerShoot;

            return DefaultBulletsPerShoot;
        }
    }
}
