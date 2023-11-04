using System;
using System.Collections.Generic;
using System.Text;

namespace ViceCity.Models.Guns
{
    public class Pistol : Gun
    {
        private const int DefaultBulletsPerBarrel = 10;
        private const int DefaultTotalBarrels = 100;
        private const int DefaultBulletsPerShoot = 1;

        public Pistol(string name)
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
