using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGlibrary {
    public abstract class Character {
        //speed is the dodging and attacking speed of the character
        //level is the characters level
        //maxHitPoints is the character's maximum hit points
        //currentHitPoints is the character's current HP
        //damage is the characters damage when attacking
        //hasPoison allows sub classes to implement poison attacks
        private int level, currentHitPoints, maxHitPoints, speed, armour, damage;
        private bool hasPoison;

        public int Level {
            get {
                return level;
            }
            set {
                level = value;
            }
        }
        public int MaxHitPoints {
            get {
                return maxHitPoints;
            }
            set {
                maxHitPoints = value;
            }
        }
        public int CurrentHitPoints {
            get {
                return currentHitPoints;
            }
            set {
                currentHitPoints = value;
            }
        }
        public int Speed {
            get {
                return speed;
            }
            set {
                speed = value;
            }
        }
        public int Armour {
            get {
                return armour;
            }
            set {
                armour = value;
            }
        }
        public int Damage {
            get {
                return damage;
            }
            set {
                damage = value;
            }
        }
        public bool HasPoison {
            get {
                return hasPoison;
            }
            set {
                hasPoison = value;
            }
        }

        public Character() {
            Random random = new Random();
            this.Level = 1;
            this.MaxHitPoints = random.Next(50, 101);
            this.CurrentHitPoints = this.MaxHitPoints;
            this.Speed = random.Next(5, 11);
            this.Armour = random.Next(0, 21);
            this.Damage = random.Next(20, 41);
            this.HasPoison = false;
        }

        //basic public method for attacks
        //accepts the attackers damage, level and speed
        //accepts the recievers level, speed and armor
        public int Attack(int attkDmg, int attkLvl, int attkSpeed, int recLvl, int recSpeed, int recArmour) {
            ////variable for total damage done with this attack, default 0 for no damage done
            int totalDamageDone = 0;
            bool wasAnyDamageDone = false;
            //converts armour to a point value, ex 40% armor = 0.6
            double armour = (100 - (double) recArmour) / 100;
            //random number generator for miss chances
            Random random = new Random();

            //if the attacker's speed is more than 5 points ahead of the reciever,
            //and the attacker is no less than one level below the reciever
            if (((attkSpeed - 5) > recSpeed) && (attkLvl >= (recLvl - 1))) {
                wasAnyDamageDone = true;
                //5% miss chance
                if (random.Next(0, 100) >= 5) {
                    totalDamageDone = (int) (attkDmg * armour);
                }
            }

            //if the attacker's speed is lower than the recievers,
            //and the attacker is 2 levels or more above the reciever
            if ((attkSpeed <= recSpeed) && (attkLvl >= (recLvl + 2)) && (wasAnyDamageDone == false)) {
                wasAnyDamageDone = true;
                //10% miss chance
                if (random.Next(0, 100) >= 10) {
                    totalDamageDone = (int)(attkDmg * armour);
                }
            }

            //if the attacker's speed is no less than 15 lower than the recievers and,
            //the attacker's level is no less than 3 lower than the recievers
            if ((attkSpeed >= (recSpeed - 15)) && (attkLvl >= (recLvl - 3)) && (wasAnyDamageDone == false)) {
                wasAnyDamageDone = true;
                //50% miss chance
                if (random.Next(0, 100) >= 50) {
                    totalDamageDone = (int)(attkDmg * armour);
                }
            }

            //default chance to miss is 40%
            else {
                if (random.Next(0, 100) >= 40) {
                    totalDamageDone = (int)(attkDmg * armour);
                    wasAnyDamageDone = true;
                }
            }
            return totalDamageDone;
        }

        public override string ToString() {
            string toStringReturn = "";
            toStringReturn = "Level: " + this.Level + "\n"
                                + "Current Hit Points: " + this.CurrentHitPoints + "\n"
                                + "Speed: " + this.Speed + "\n"
                                + "Armor: " + this.Armour + "\n"
                                + "Damage: " + this.Damage;
            return toStringReturn;
        }
    }
}
