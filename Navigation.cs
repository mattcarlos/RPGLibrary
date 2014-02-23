using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGlibrary {
    public class Navigation {
        private bool isEnemyHere, enemyHereOnNextNorth, enemyHereOnNextWest, enemyHereOnNextEast;
        private int entireJourneyLength, movesSinceLastEncounter;
        Random random;

        public bool IsEnemyHere {
            get {
                return isEnemyHere;
            }
            set {
                isEnemyHere = value;
            }
        }
        public bool EnemyHereOnNextNorth {
            get {
                return enemyHereOnNextNorth;
            }
            set {
                enemyHereOnNextNorth = value;
            }
        }
        public bool EnemyHereOnNextWest {
            get {
                return enemyHereOnNextWest;
            }
            set {
                enemyHereOnNextWest = value;
            }
        }
        public bool EnemyHereOnNextEast {
            get {
                return enemyHereOnNextEast;
            }
            set {
                enemyHereOnNextEast = value;
            }
        }
        public int EntireJourneyLength {
            get {
                return entireJourneyLength;
            }
            set {
                entireJourneyLength = value;
            }
        }
        public int MovesSinceLastEncounter {
            get {
                return movesSinceLastEncounter;
            }
            set {
                movesSinceLastEncounter = value;
            }
        }

        public Navigation() {
            this.IsEnemyHere = false;
            this.EnemyHereOnNextNorth = false;
            this.EnemyHereOnNextWest = false;
            this.EnemyHereOnNextEast = false;
            this.EntireJourneyLength = 0;
            this.MovesSinceLastEncounter = 0;
            random = new Random();
        }

        public string NavigateNorth() {
            this.EntireJourneyLength++;
            this.MovesSinceLastEncounter++;
            //reset any 'on next move' encounters
            this.EnemyHereOnNextWest = false;
            this.EnemyHereOnNextEast = false;

            //if it has been 5 moves since last encounter
            //raise chance of encounter to 80%
            if ((movesSinceLastEncounter > 5) && (random.Next(1, 101) > 20)) {
                this.IsEnemyHere = true;
                this.MovesSinceLastEncounter = 0;
                return "An enemy has ambushed you!";
            }

            //10% chance of running into an enemy with no warning
            //also if this is the turn after enemy here on next move
            if ((random.Next(1, 101) > 90) || (this.EnemyHereOnNextNorth == true)) {
                this.EnemyHereOnNextNorth = false;
                this.IsEnemyHere = true;
                this.MovesSinceLastEncounter = 0;
                return "You've encountered an enemy!";
            }

            //30% chance of hearing an enemy in the distance
            if (random.Next(1, 101) > 70) {
                this.EnemyHereOnNextNorth = true;
                this.MovesSinceLastEncounter = 0;
                return "You hear skittering to the north.";
            }
            return "Nothing here.";
        }

        public string NavigateWest() {
            this.EntireJourneyLength++;
            this.MovesSinceLastEncounter++;
            //reset any 'on next move' encounters
            this.EnemyHereOnNextNorth = false;
            this.EnemyHereOnNextEast = false;

            //if it has been 5 moves since last encounter
            //raise chance of encounter to 80%
            if ((movesSinceLastEncounter > 5) && (random.Next(1, 101) > 20)) {
                this.IsEnemyHere = true;
                this.MovesSinceLastEncounter = 0;
                return "An enemy has ambushed you!";
            }

            //10% chance of running into an enemy with no warning
            //also if this is the turn after enemy here on next move
            if ((random.Next(1, 101) > 90) || (this.EnemyHereOnNextWest == true)) {
                this.EnemyHereOnNextWest = false;
                this.IsEnemyHere = true;
                this.MovesSinceLastEncounter = 0;
                return "You've encountered an enemy!";
            }

            //30% chance of hearing an enemy in the distance
            if (random.Next(1, 101) > 70) {
                this.EnemyHereOnNextWest = true;
                this.MovesSinceLastEncounter = 0;
                return "You hear rustling to the west.";
            }
            return "Nothing here.";
        }

        public string NavigateEast() {
            this.EntireJourneyLength++;
            this.MovesSinceLastEncounter++;
            //reset any 'on next move' encounters
            this.EnemyHereOnNextNorth = false;
            this.EnemyHereOnNextWest = false;

            //if it has been 5 moves since last encounter
            //raise chance of encounter to 80%
            if ((movesSinceLastEncounter > 5) && (random.Next(1, 101) > 20)) {
                this.IsEnemyHere = true;
                this.MovesSinceLastEncounter = 0;
                return "An enemy has ambushed you!";
            }

            //10% chance of running into an enemy with no warning
            //also if this is the turn after enemy here on next move
            if ((random.Next(1, 101) > 90) || (this.EnemyHereOnNextEast == true)) {
                this.EnemyHereOnNextEast = false;
                this.IsEnemyHere = true;
                this.MovesSinceLastEncounter = 0;
                return "You've encountered an enemy!";
            }

            //30% chance of hearing an enemy in the distance
            if (random.Next(1, 101) > 70) {
                this.EnemyHereOnNextEast = true;
                this.MovesSinceLastEncounter = 0;
                return "You hear something coming from the east";
            }
            return "Nothing here.";
        }
    }
}
