using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGlibrary {
    public abstract class Player:Character {
        //levels up the player character based on constrained random percentages
        public abstract void LevelUp();
        //    //default LevelUp implementation:
        //    Random random = new Random();
        //    this.Level++;
        //    //increases hit points by 10-20%
        //    this.HitPoints = this.HitPoints + (int)Math.Ceiling((double)this.HitPoints * ((double)random.Next(10, 20) / 100));
        //    //increases speed by 10-15%
        //    this.Speed = this.Speed + (int)Math.Ceiling((double)this.Speed * ((double)random.Next(10, 15) / 100));
        //    //increases damage by 5-10%
        //    this.Damage = this.Damage + (int)Math.Ceiling((double)this.Damage * ((double)random.Next(5, 10) / 100));
        //    //increases damage scaling beyond level 10 by 5-10%
        //    if (this.Level >= 10) {
        //        this.Damage = this.Damage + (int)Math.Ceiling((double)this.Damage * ((double)random.Next(5, 10) / 100));
        //    }
        //    this.CurrentHitPoints = this.MaxHitPoints;
    }
}
