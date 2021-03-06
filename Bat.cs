﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGlibrary {
    public class Bat:Bird {
        public Bat() {
        }
        public Bat(int playerLevel) {
            Random random = new Random();
            int enemyLevel = initializeEnemyLevel(playerLevel);
            //levels the enemy up one at a time to match enemyLevel set in Enemy.cs
            while (this.Level != enemyLevel) {
                //increases hit points by 8-16%
                this.MaxHitPoints = this.MaxHitPoints + (int)Math.Ceiling((double)this.MaxHitPoints * ((double)random.Next(8, 17) / 100));
                //increases speed by 10-20%
                this.Speed = this.Speed + (int)Math.Ceiling((double)this.Speed * ((double)random.Next(10, 21) / 100));
                //increases damage by 6-12%
                this.Damage = this.Damage + (int)Math.Ceiling((double)this.Damage * ((double)random.Next(6, 13) / 100));
                //increases damage scaling beyond level 10 by 5-10%
                if (this.Level >= 10) {
                    this.Damage = this.Damage + (int)Math.Ceiling((double)this.Damage * ((double)random.Next(5, 11) / 100));
                }
                this.Level++;
            }
            this.CurrentHitPoints = this.MaxHitPoints;
            this.HasPoison = false;
        }
    }
}
