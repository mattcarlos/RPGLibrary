using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGlibrary {
    public class Warrior:Player {
        //warrior default attributes
        public Warrior() {
            Random random = new Random();
            this.Level = 1;
            this.MaxHitPoints = random.Next(70, 110);
            this.CurrentHitPoints = this.MaxHitPoints;
            this.Speed = random.Next(3, 5);
            this.Armour = random.Next(60, 75);
            this.Damage = random.Next(45, 60);
            this.HasPoison = true;
        }

        //warrior version of level up
        //increases attributes by a constrained random percentage
        public override void LevelUp() {
            Random random = new Random();
            this.Level++;
            //increases hit points by 15-25%
            this.MaxHitPoints = this.MaxHitPoints + (int)Math.Ceiling((double)this.MaxHitPoints * ((double)random.Next(15, 26) / 100));
            //increases speed by 6-12%
            this.Speed = this.Speed + (int)Math.Ceiling((double)this.Speed * ((double)random.Next(6, 13) / 100));
            //increases damage by 7-15%
            this.Damage = this.Damage + (int)Math.Ceiling((double)this.Damage * ((double)random.Next(7, 16) / 100));
            //increases damage scaling beyond level 10 by 5-10%
            if (this.Level >= 10) {
                this.Damage = this.Damage + (int)Math.Ceiling((double)this.Damage * ((double)random.Next(5, 11) / 100));
            }
            this.CurrentHitPoints = this.MaxHitPoints;
        }
    }
}
