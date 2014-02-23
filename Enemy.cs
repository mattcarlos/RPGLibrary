using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGlibrary {
    public abstract class Enemy:Character {
        //gives the enemy a level based on the player's level
        public int initializeEnemyLevel(int playerLevel) {
            Random random = new Random();
            //randomizes the enemy's level up
            if (random.Next(1, 100) > 50) {
                if (random.Next(1, 100) > 50) {
                    playerLevel += 2;
                }
                else {
                    playerLevel += 1;
                }
            }
            //randomizes the enemy's level down
            if (random.Next(1, 100) > 50) {
                if (random.Next(1, 100) > 50) {
                    playerLevel -= 2;
                }
                else {
                    playerLevel -= 1;
                }
            }
            if (playerLevel < 1) {
                playerLevel = 1;
            }
            return playerLevel;
        }
    }
}
