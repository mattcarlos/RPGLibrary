using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGlibrary {
    public class Archer:Player {
        //archer default attributes
        public Archer() {
            Random random = new Random();
            this.Level = 1;
            this.MaxHitPoints = random.Next(60, 100);
            this.CurrentHitPoints = this.MaxHitPoints;
            this.Speed = random.Next(5, 10);
            this.Armour = random.Next(30, 40);
            this.Damage = random.Next(60, 75);
            this.HasPoison = true;
        }

        //archer version of level up
        //increases attributes by a constrained random percentage
        public override void LevelUp() {
            Random random = new Random();
            this.Level++;
            //increases hit points by 12-24%
            this.MaxHitPoints = this.MaxHitPoints + (int)Math.Ceiling((double)this.MaxHitPoints * ((double)random.Next(13, 25) / 100));
            //increases speed by 8-16%
            this.Speed = this.Speed + (int)Math.Ceiling((double)this.Speed * ((double)random.Next(8, 17) / 100));
            //increases damage by 8-16%
            this.Damage = this.Damage + (int)Math.Ceiling((double)this.Damage * ((double)random.Next(8, 17) / 100));
            //increases damage scaling beyond level 10 by 5-10%
            if (this.Level >= 10) {
                this.Damage = this.Damage + (int)Math.Ceiling((double)this.Damage * ((double)random.Next(5, 11) / 100));
            }
            this.CurrentHitPoints = this.MaxHitPoints;
        }
    }
}
