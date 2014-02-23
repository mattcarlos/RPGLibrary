using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGlibrary {
    public class Wizard:Player {
        //wizard default attributes
        public Wizard() {
            Random random = new Random();
            this.Level = 1;
            this.MaxHitPoints = random.Next(50, 70);
            this.CurrentHitPoints = this.MaxHitPoints;
            this.Speed = random.Next(7, 14);
            this.Armour = random.Next(20, 40);
            this.Damage = random.Next(70, 95);
            this.HasPoison = true;
        }

        //wizard version of level up
        //increases attributes by a constrained random percentage
        public override void LevelUp() {
            Random random = new Random();
            this.Level++;
            //increases hit points by 12-20%
            this.MaxHitPoints = this.MaxHitPoints + (int)Math.Ceiling((double)this.MaxHitPoints * ((double)random.Next(12, 21) / 100));
            //increases speed by 10-18%
            this.Speed = this.Speed + (int)Math.Ceiling((double)this.Speed * ((double)random.Next(10, 19) / 100));
            //increases damage by 10-20%
            this.Damage = this.Damage + (int)Math.Ceiling((double)this.Damage * ((double)random.Next(10, 21) / 100));
            //increases damage scaling beyond level 10 by 5-10%
            if (this.Level >= 10) {
                this.Damage = this.Damage + (int)Math.Ceiling((double)this.Damage * ((double)random.Next(5, 11) / 100));
            }
            this.CurrentHitPoints = this.MaxHitPoints;
        }
    }
}
