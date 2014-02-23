using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace RPGlibrary {
    public class TakeATurn {
        //when a turn is called, currentAttacker and currentReciever are updated
        private string currentAttacker, currentReciever, player, enemy;

        //enemy and player stats
        private int eLvl, eSpeed, eArmour, eHp, playerLevel, pSpeed, pArmour, pHp, pDmg, experienceCount;

        private bool isFightOver;

        //initialize all objects
        Random random;
        Warrior warrior;
        Wizard wizard;
        Archer archer;
        Scorpion scorpion;
        ArmouredScorpion armouredScorpion;
        Spider spider;
        PoisonSpider poisonSpider;
        Boar boar;
        ArmouredBoar armouredBoar;
        HulkingBoar hulkingBoar;
        Bat bat;
        Hawk hawk;
        GiantHawk giantHawk;

        public int PlayerLevel {
            get {
                return playerLevel;
            }
            set {
                playerLevel = value;
            }
        }
        public int ELvl {
            get {
                return eLvl;
            }
            set {
                eLvl = value;
            }
        }
        public int ESpeed {
            get {
                return eSpeed;
            }
            set {
                eSpeed = value;
            }
        }
        public int EArmour {
            get {
                return eArmour;
            }
            set {
                eArmour = value;
            }
        }
        public int EHp {
            get {
                return eHp;
            }
            set {
                eHp = value;
            }
        }
        public int PSpeed {
            get {
                return pSpeed;
            }
            set {
                pSpeed = value;
            }
        }
        public int PArmour {
            get {
                return pArmour;
            }
            set {
                pArmour = value;
            }
        }
        public int PHp {
            get {
                return pHp;
            }
            set {
                pHp = value;
            }
        }
        public int PDmg {
            get {
                return pDmg;
            }
            set {
                pDmg = value;
            }
        }
        public int ExperienceCount {
            get {
                return experienceCount;
            }
            set {
                experienceCount = value;
            }
        }
        public string Player {
            get {
                return player;
            }
            set {
                player = value;
            }
        }
        public string Enemy {
            get {
                return enemy;
            }
            set {
                enemy = value;
            }
        }
        public string CurrentAttacker {
            get {
                return currentAttacker;
            }
            set {
                currentAttacker = value;
            }
        }
        public string CurrentReciever {
            get {
                return currentReciever;
            }
            set {
                currentReciever = value;
            }
        }
        public bool IsFightOver {
            get {
                return isFightOver;
            }
            set {
                isFightOver = value;
            }
        }

        //constructs the object
        public TakeATurn() {
            this.IsFightOver = false;
            random = new Random();
            warrior = new Warrior();
            wizard = new Wizard();
            archer = new Archer();
            this.PlayerLevel =  warrior.Level;
            scorpion = new Scorpion(this.PlayerLevel);
            armouredScorpion = new ArmouredScorpion(this.PlayerLevel);
            spider = new Spider(this.PlayerLevel);
            poisonSpider = new PoisonSpider(this.PlayerLevel);
            boar = new Boar(this.PlayerLevel);
            armouredBoar = new ArmouredBoar(this.PlayerLevel);
            hulkingBoar = new HulkingBoar(this.PlayerLevel);
            bat = new Bat(this.PlayerLevel);
            hawk = new Hawk(this.PlayerLevel);
            giantHawk = new GiantHawk(this.PlayerLevel);
        }

        //makes the called character attack, and returns damage done
        public int WarriorTurn() {
            return warrior.Attack(warrior.Damage, warrior.Level,
                warrior.Speed, this.ELvl, this.ESpeed, this.EArmour);
        }
        public int WizardTurn() {
            return wizard.Attack(wizard.Damage, wizard.Level,
                wizard.Speed, this.ELvl, this.ESpeed, this.EArmour);
        }
        public int ArcherTurn() {
            return archer.Attack(archer.Damage, archer.Level,
                archer.Speed, this.ELvl, this.ESpeed, this.EArmour);
        }
        public int ScorpionTurn() {
            return scorpion.Attack(scorpion.Damage, scorpion.Level,
                scorpion.Speed, this.PlayerLevel, this.PSpeed, this.PArmour);
        }
        public int ArmouredScorpionTurn() {
            return armouredScorpion.Attack(armouredScorpion.Damage, armouredScorpion.Level,
                armouredScorpion.Speed, this.PlayerLevel, this.PSpeed, this.PArmour);
        }
        public int SpiderTurn() {
            return spider.Attack(spider.Damage, spider.Level,
                spider.Speed, this.PlayerLevel, this.PSpeed, this.PArmour);
        }
        public int PoisonSpiderTurn() {
            return poisonSpider.Attack(poisonSpider.Damage, poisonSpider.Level,
                poisonSpider.Speed, this.PlayerLevel, this.PSpeed, this.PArmour);
        }
        public int BoarTurn() {
            return boar.Attack(boar.Damage, boar.Level,
                boar.Speed, this.PlayerLevel, this.PSpeed, this.PArmour);
        }
        public int ArmouredBoarTurn() {
            return armouredBoar.Attack(armouredBoar.Damage, armouredBoar.Level,
                armouredBoar.Speed, this.PlayerLevel, this.PSpeed, this.PArmour);
        }
        public int HulkingBoarTurn() {
            return hulkingBoar.Attack(hulkingBoar.Damage, hulkingBoar.Level,
                hulkingBoar.Speed, this.PlayerLevel, this.PSpeed, this.PArmour);
        }
        public int BatTurn() {
            return bat.Attack(bat.Damage, bat.Level,
                bat.Speed, this.PlayerLevel, this.PSpeed, this.PArmour);
        }
        public int HawkTurn() {
            return hawk.Attack(hawk.Damage, hawk.Level,
                hawk.Speed, this.PlayerLevel, this.PSpeed, this.PArmour);
        }
        public int GiantHawkTurn() {
            return giantHawk.Attack(giantHawk.Damage, giantHawk.Level,
                giantHawk.Speed, this.PlayerLevel, this.PSpeed, this.PArmour);
        }

        //completes a turn
        public int Turn(string attacker, string reciever) {

            //local variable that stores health pre-attack
            int currentHealth;

            //currently only works for warrior and scorpion turns
            switch (attacker) {
                case "Warrior":
                    //set pre-attack health
                    currentHealth = this.EHp;

                    //performs the turn and updates health
                    this.EHp = this.EHp - WarriorTurn();

                    //return damage done
                    return currentHealth - this.EHp;
                case "Wizard":
                    currentHealth = this.EHp;
                    this.EHp = this.EHp - WizardTurn();
                    return currentHealth - this.EHp;
                case "Archer":
                    currentHealth = this.EHp;
                    this.EHp = this.EHp - ArcherTurn();
                    return currentHealth - this.EHp;
                case "Scorpion":
                    currentHealth = this.PHp;
                    this.PHp = this.PHp - ScorpionTurn();
                    return currentHealth - this.PHp;
                case "Armoured Scorpion":
                    currentHealth = this.PHp;
                    this.PHp = this.PHp - ArmouredScorpionTurn();
                    return currentHealth - this.PHp;
                case "Spider":
                    currentHealth = this.PHp;
                    this.PHp = this.PHp - SpiderTurn();
                    return currentHealth - this.PHp;
                case "Poison Spider":
                    currentHealth = this.PHp;
                    this.PHp = this.PHp - PoisonSpiderTurn();
                    return currentHealth - this.PHp;
                case "Boar":
                    currentHealth = this.PHp;
                    this.PHp = this.PHp - BoarTurn();
                    return currentHealth - this.PHp;
                case "Armoured Boar":
                    currentHealth = this.PHp;
                    this.PHp = this.PHp - ArmouredBoarTurn();
                    return currentHealth - this.PHp;
                case "Hulking Boar":
                    currentHealth = this.PHp;
                    this.PHp = this.PHp - HulkingBoarTurn();
                    return currentHealth - this.PHp;
                case "Bat":
                    currentHealth = this.PHp;
                    this.PHp = this.PHp - BatTurn();
                    return currentHealth - this.PHp;
                case "Hawk":
                    currentHealth = this.PHp;
                    this.PHp = this.PHp - HawkTurn();
                    return currentHealth - this.PHp;
                case "Giant Hawk":
                    currentHealth = this.PHp;
                    this.PHp = this.PHp - GiantHawkTurn();
                    return currentHealth - this.PHp;

                //shouldn't ever occur, but if it does the -1 should help identify the error
                default:
                    return -1;
            }
        }

        public override string ToString() {
            string returnString = this.CurrentReciever + " has "
                + this.eHp + " remaining.";
            return returnString;
        }

        //Levels up everything
        public int LevelUp() {
            warrior.LevelUp();
            archer.LevelUp();
            wizard.LevelUp();
            this.PlayerLevel = warrior.Level;
            scorpion = new Scorpion(playerLevel);
            armouredScorpion = new ArmouredScorpion(playerLevel);
            spider = new Spider(playerLevel);
            poisonSpider = new PoisonSpider(playerLevel);
            boar = new Boar(playerLevel);
            armouredBoar = new ArmouredBoar(playerLevel);
            hulkingBoar = new HulkingBoar(playerLevel);
            bat = new Bat(playerLevel);
            hawk = new Hawk(playerLevel);
            giantHawk = new GiantHawk(playerLevel);
            return this.PlayerLevel;
        }

        //brings the enemy stats into generic local variables
        //as opposed to enemy type specific variables
        public void SetEnemyStats(string enemystring) {
            this.IsFightOver = false;
            this.Enemy = enemystring;
            switch (enemystring) {
                case "Scorpion":
                    this.EHp = scorpion.CurrentHitPoints;
                    this.ELvl = scorpion.Level;
                    this.EArmour = scorpion.Armour;
                    this.ESpeed = scorpion.Speed;
                    break;
                case "Armoured Scorpion":
                    this.EHp = armouredScorpion.CurrentHitPoints;
                    this.ELvl = armouredScorpion.Level;
                    this.EArmour = armouredScorpion.Armour;
                    this.ESpeed = armouredScorpion.Speed;
                    break;
                case "Spider":
                    this.EHp = spider.CurrentHitPoints;
                    this.ELvl = spider.Level;
                    this.EArmour = spider.Armour;
                    this.ESpeed = spider.Speed;
                    break;
                case "Poison Spider":
                    this.EHp = poisonSpider.CurrentHitPoints;
                    this.ELvl = poisonSpider.Level;
                    this.EArmour = poisonSpider.Armour;
                    this.ESpeed = poisonSpider.Speed;
                    break;
                case "Boar":
                    this.EHp = boar.CurrentHitPoints;
                    this.ELvl = boar.Level;
                    this.EArmour = boar.Armour;
                    this.ESpeed = boar.Speed;
                    break;
                case "Armoured Boar":
                    this.EHp = armouredBoar.CurrentHitPoints;
                    this.ELvl = armouredBoar.Level;
                    this.EArmour = armouredBoar.Armour;
                    this.ESpeed = armouredBoar.Speed;
                    break;
                case "Hulking Boar":
                    this.EHp = hulkingBoar.CurrentHitPoints;
                    this.ELvl = hulkingBoar.Level;
                    this.EArmour = hulkingBoar.Armour;
                    this.ESpeed = hulkingBoar.Speed;
                    break;
                case "Bat":
                    this.EHp = bat.CurrentHitPoints;
                    this.ELvl = bat.Level;
                    this.EArmour = bat.Armour;
                    this.ESpeed = bat.Speed;
                    break;
                case "Hawk":
                    this.EHp = hawk.CurrentHitPoints;
                    this.ELvl = hawk.Level;
                    this.EArmour = hawk.Armour;
                    this.ESpeed = hawk.Speed;
                    break;
                case "Giant Hawk":
                    this.EHp = giantHawk.CurrentHitPoints;
                    this.ELvl = giantHawk.Level;
                    this.EArmour = giantHawk.Armour;
                    this.ESpeed = giantHawk.Speed;
                    break;
                default:
                    break;
            }
        }

        //brings the player stats into generic local variables
        //as opposed to enemy type specific variables
        public void SetPlayerStats(string player) {
            this.IsFightOver = false;
            switch (player) {
                case "Warrior":
                    this.Player = "Warrior";
                    this.PSpeed = warrior.Speed;
                    this.PArmour = warrior.Armour;
                    this.PHp = warrior.CurrentHitPoints;
                    this.PDmg = warrior.Damage;
                    break;
                case "Wizard":
                    this.Player = "Wizard";
                    this.PSpeed = wizard.Speed;
                    this.PArmour = wizard.Armour;
                    this.PHp = wizard.CurrentHitPoints;
                    this.PDmg = wizard.Damage;
                    break;
                case "Archer":
                    this.Player = "Archer";
                    this.PSpeed = archer.Speed;
                    this.PArmour = archer.Armour;
                    this.PHp = archer.CurrentHitPoints;
                    this.PDmg = archer.Damage;
                    break;
                default:
                    break;
            }
        }
            
        public string OnKill(string killer) {
            this.IsFightOver = true;
            if (killer == this.Player) {
                if (PlayerLevel < 10) {
                    this.LevelUp();
                    return "Congratulations, you've reached level " + this.PlayerLevel;
                }
                if ((PlayerLevel < 20) && (this.ExperienceCount == 2)) {
                    this.LevelUp();
                    this.ExperienceCount = 0;
                    return "Congratulations, you've reached level " + this.PlayerLevel;
                }
                if ((PlayerLevel < 30) && (this.ExperienceCount == 4)) {
                    this.LevelUp();
                    this.ExperienceCount = 0;
                    return "Congratulations, you've reached level " + this.PlayerLevel;
                }
                else if (this.ExperienceCount == 6) {
                    this.LevelUp();
                    this.ExperienceCount = 0;
                    return "Congratulations, you've reached level " + this.PlayerLevel;
                }
                else {
                    this.EHp = 1;
                    this.ExperienceCount++;
                    return "";
                }
            }
            this.EHp = 1;
            return "";
        }

        public string EnemySelector() {
            int rand = random.Next(1, 11);
            switch (rand) {
                case 1:
                    this.SetEnemyStats("Scorpion");
                    return "Scorpion";
                case 2:
                    this.SetEnemyStats("Armoured Scorpion");
                    return "Armoured Scorpion";
                case 3:
                    this.SetEnemyStats("Spider");
                    return "Spider";
                case 4:
                    this.SetEnemyStats("Poison Spider");
                    return "Poison Spider";
                case 5:
                    this.SetEnemyStats("Boar");
                    return "Boar";
                case 6:
                    this.SetEnemyStats("Armoured Boar");
                    return "Armoured Boar";
                case 7:
                    this.SetEnemyStats("Hulking Boar");
                    return "Hulking Boar";
                case 8:
                    this.SetEnemyStats("Bat");
                    return "Bat";
                case 9:
                    this.SetEnemyStats("Hawk");
                    return "Hawk";
                case 10:
                    this.SetEnemyStats("Giant Hawk");
                    return "Giant Hawk";
                default:
                    return "";
            }
        }

        public void SetPlayerHPToMax() {
            switch (player) {
                case "Warrior":
                    this.Player = "Warrior";
                    this.PHp = warrior.MaxHitPoints;
                    break;
                case "Wizard":
                    this.Player = "Wizard";
                    this.PHp = wizard.MaxHitPoints;
                    break;
                case "Archer":
                    this.Player = "Archer";
                    this.PHp = archer.MaxHitPoints;
                    break;
                default:
                    break;
            }
        }
    }
}
