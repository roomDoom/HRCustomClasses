﻿// the ai :D
//please ask/write me if you use this in your project

using System;
using System.Collections.Generic;
using System.Text;



//TODO:

//test wichtelmeisterin, befehlsruf

//tueftlermeisteroberfunks
//verrückter bomber ( 3 damage to random chars)
//nozdormu (for computing time :D)
//faehrtenlesen
// lehrensucher cho
//scharmuetzel kills all :D
//hoggersmash




namespace HREngine.Bots
{

    public class Action
    {
        public bool cardplay = false;
        public bool heroattack = false;
        public bool useability = false;
        public bool minionplay = false;
        public Handmanager.Handcard handcard;
        public int cardEntitiy = -1;
        public int owntarget = -1; //= target where card/minion is placed
        public int ownEntitiy = -1;
        public int enemytarget = -1; // target where red arrow is placed
        public int enemyEntitiy = -1;
        public int druidchoice = 0; // 1 left card, 2 right card
        public int numEnemysBeforePlayed = 0;
        public bool comboBeforePlayed = false;

        public void print()
        {
            Helpfunctions help = Helpfunctions.Instance;
            help.logg("current Action: ");
                if (this.cardplay)
                {
                    help.logg("play " + this.handcard.card.name);
                    if (this.druidchoice >= 1) help.logg("choose choise " + this.druidchoice);
                    help.logg("with entityid " + this.cardEntitiy);
                    if (this.owntarget >= 0)
                    {
                        help.logg("on position " + this.owntarget);
                    }
                    if (this.enemytarget >= 0)
                    {
                        help.logg("and target to " + this.enemytarget + " " + this.enemyEntitiy);
                    }
                }
                if (this.minionplay)
                {
                    help.logg("attacker: " + this.owntarget + " enemy: " + this.enemytarget);
                    help.logg("targetplace " + this.enemyEntitiy);
                }
                if (this.heroattack)
                {
                    help.logg("attack with hero, enemy: " + this.enemytarget);
                    help.logg("targetplace " + this.enemyEntitiy);
                }
                if (this.useability)
                {
                    help.logg("useability ");
                    if (this.enemytarget >= 0)
                    {
                        help.logg("on enemy: " + this.enemytarget + "targetplace " + this.enemyEntitiy);
                    }
                }
                help.logg("");
        }

    }

    public class Playfield
    {
        public bool logging = false;
        public bool sEnemTurn = false;

        public int attackFaceHP = 15;

        public int evaluatePenality = 0;
        public int ownController = 0;

        public int ownHeroEntity = -1;
        public int enemyHeroEntity = -1;

        public int value = Int32.MinValue;
        public int guessingHeroDamage = 0;

        public int mana = 0;
        public int enemyHeroHp = 30;
        public HeroEnum ownHeroName = HeroEnum.druid;
        public HeroEnum enemyHeroName = HeroEnum.druid;
        public bool ownHeroReady = false;
        public bool enemyHeroReady = false;
        public int ownHeroNumAttackThisTurn = 0;
        public int enemyHeroNumAttackThisTurn = 0;
        public bool ownHeroWindfury = false;
        public bool enemyHeroWindfury = false;

        public List<string> ownSecretsIDList = new List<string>();
        public int enemySecretCount = 0;

        public int ownHeroHp = 30;
        public int ownheroAngr = 0;
        public int enemyheroAngr = 0;
        public bool ownHeroFrozen = false;
        public bool enemyHeroFrozen = false;
        public bool heroImmuneWhileAttacking = false;
        public bool enemyheroImmuneWhileAttacking = false;
        public bool heroImmune = false;
        public bool enemyHeroImmune = false;
        public int ownWeaponDurability = 0;
        public int ownWeaponAttack = 0;
        public string ownWeaponName = "";
        public string enemyWeaponName = "";
        
        public int enemyWeaponAttack = 0;
        public int enemyWeaponDurability = 0;
        public List<Minion> ownMinions = new List<Minion>();
        public List<Minion> enemyMinions = new List<Minion>();
        public List<Handmanager.Handcard> owncards = new List<Handmanager.Handcard>();
        public List<Action> playactions = new List<Action>();
        public bool complete = false;
        public int owncarddraw = 0;
        public int ownHeroDefence = 0;
        public int enemycarddraw = 0;
        public int enemyAnzCards = 0;
        public int enemyHeroDefence = 0;
        
        public int doublepriest = 0;
        public int spellpower = 0;
        public bool auchenaiseelenpriesterin = false;

        public bool playedmagierinderkirintor = false;
        public bool playedPreparation = false;

        public int winzigebeschwoererin = 0;
        public int startedWithWinzigebeschwoererin = 0;
        public int zauberlehrling = 0;
        public int startedWithZauberlehrling = 0;
        public int managespenst = 0;
        public int startedWithManagespenst = 0;
        public int soeldnerDerVenture = 0;
        public int startedWithsoeldnerDerVenture = 0;
        public int beschwoerungsportal = 0;
        public int startedWithbeschwoerungsportal = 0;

        public int ownWeaponAttackStarted = 0;
        public int ownMobsCountStarted = 0;
        public int ownCardsCountStarted = 0;
        public int ownHeroHpStarted = 30;
        public int enemyHeroHpStarted = 30;

        public int mobsplayedThisTurn = 0;
        public int startedWithMobsPlayedThisTurn = 0;

        public int cardsPlayedThisTurn = 0;
        public int ueberladung = 0; //=recall

        public int ownMaxMana = 0;
        public int enemyMaxMana = 0;

        public int lostDamage = 0;
        public int lostHeal = 0; 
        public int lostWeaponDamage = 0;

        public int ownDeckSize = 30;
        public int enemyDeckSize = 30;
        public int ownHeroFatigue = 0;
        public int enemyHeroFatigue = 0;

        public bool ownAbilityReady = false;
        public CardDB.Card ownHeroAblility;
        public bool enemyAbilityReady = false;
        public CardDB.Card enemyHeroAblility;

        //Helpfunctions help = Helpfunctions.Instance;

        private void addMinionsReal(List<Minion> source, List<Minion> trgt)
        {
            foreach (Minion m in source)
            {
                trgt.Add(new Minion(m));
            }

        }

        private void addCardsReal(List<Handmanager.Handcard> source)
        {

            foreach (Handmanager.Handcard m in source)
            {
                this.owncards.Add(new Handmanager.Handcard(m));
            }

        }

        public Playfield()
        {
            //this.simulateEnemyTurn = Ai.Instance.simulateEnemyTurn;
            this.ownController = Hrtprozis.Instance.getOwnController();
            this.ownHeroEntity = Hrtprozis.Instance.ownHeroEntity;
            this.enemyHeroEntity = Hrtprozis.Instance.enemyHeroEntitiy;
            this.mana = Hrtprozis.Instance.currentMana;
            this.ownMaxMana = Hrtprozis.Instance.ownMaxMana;
            this.enemyMaxMana = Hrtprozis.Instance.enemyMaxMana;
            this.evaluatePenality = 0;
            this.ownSecretsIDList = Hrtprozis.Instance.ownSecretList;
            this.enemySecretCount = Hrtprozis.Instance.enemySecretCount;

            this.heroImmune = Hrtprozis.Instance.heroImmune;
            this.enemyHeroImmune = Hrtprozis.Instance.enemyHeroImmune;

            this.attackFaceHP = Hrtprozis.Instance.attackFaceHp;

            addMinionsReal(Hrtprozis.Instance.ownMinions, ownMinions);
            addMinionsReal(Hrtprozis.Instance.enemyMinions, enemyMinions);
            addCardsReal(Handmanager.Instance.handCards);
            this.enemyHeroHp = Hrtprozis.Instance.enemyHp;
            this.ownHeroName = Hrtprozis.Instance.heroname;
            this.enemyHeroName = Hrtprozis.Instance.enemyHeroname;
            this.ownHeroHp = Hrtprozis.Instance.heroHp;
            this.complete = false;
            this.ownHeroReady = Hrtprozis.Instance.ownheroisread;
            this.ownHeroWindfury = Hrtprozis.Instance.ownHeroWindfury;
            this.ownHeroNumAttackThisTurn = Hrtprozis.Instance.ownHeroNumAttacksThisTurn;

            this.ownHeroFrozen = Hrtprozis.Instance.herofrozen;
            this.enemyHeroFrozen = Hrtprozis.Instance.enemyfrozen;
            this.ownheroAngr = Hrtprozis.Instance.heroAtk;
            this.heroImmuneWhileAttacking = Hrtprozis.Instance.heroImmuneToDamageWhileAttacking;
            this.ownWeaponDurability = Hrtprozis.Instance.heroWeaponDurability;
            this.ownWeaponAttack = Hrtprozis.Instance.heroWeaponAttack;
            this.ownWeaponName = Hrtprozis.Instance.ownHeroWeapon;
            this.owncarddraw = 0;
            this.ownHeroDefence = Hrtprozis.Instance.heroDefence;
            this.enemyHeroDefence = Hrtprozis.Instance.enemyDefence;
            this.enemyWeaponAttack = Hrtprozis.Instance.enemyWeaponAttack;//dont know jet
            this.enemyWeaponName = Hrtprozis.Instance.enemyHeroWeapon;
            this.enemyWeaponDurability = Hrtprozis.Instance.enemyWeaponDurability;
            this.enemycarddraw = 0;
            this.enemyAnzCards = Handmanager.Instance.enemyAnzCards;
            this.ownAbilityReady = Hrtprozis.Instance.ownAbilityisReady;
            this.ownHeroAblility = Hrtprozis.Instance.heroAbility;
            this.enemyHeroAblility = Hrtprozis.Instance.enemyAbility;
            this.doublepriest = 0;
            this.spellpower = 0;
            this.mobsplayedThisTurn = Hrtprozis.Instance.numMinionsPlayedThisTurn;
            this.startedWithMobsPlayedThisTurn = Hrtprozis.Instance.numMinionsPlayedThisTurn;// only change mobsplayedthisturm
            this.cardsPlayedThisTurn = Hrtprozis.Instance.cardsPlayedThisTurn;
            this.ueberladung = Hrtprozis.Instance.ueberladung;

            this.ownHeroFatigue = Hrtprozis.Instance.ownHeroFatigue;
            this.enemyHeroFatigue = Hrtprozis.Instance.enemyHeroFatigue;
            this.ownDeckSize = Hrtprozis.Instance.ownDeckSize;
            this.enemyDeckSize = Hrtprozis.Instance.enemyDeckSize;

            //need the following for manacost-calculation
            this.ownHeroHpStarted = this.ownHeroHp;
            this.enemyHeroHpStarted = this.enemyHeroHp;
            this.ownWeaponAttackStarted = this.ownWeaponAttack;
            this.ownCardsCountStarted = this.owncards.Count;
            this.ownMobsCountStarted = this.ownMinions.Count + this.enemyMinions.Count;


            this.playedmagierinderkirintor = false;
            this.playedPreparation = false;

            this.zauberlehrling = 0;
            this.winzigebeschwoererin = 0;
            this.managespenst = 0;
            this.soeldnerDerVenture = 0;
            this.beschwoerungsportal = 0;

            this.startedWithbeschwoerungsportal = 0;
            this.startedWithManagespenst = 0;
            this.startedWithWinzigebeschwoererin = 0;
            this.startedWithZauberlehrling = 0;
            this.startedWithsoeldnerDerVenture = 0;

            foreach (Minion m in this.ownMinions)
            {
                if (m.silenced) continue;

                if (m.name == "prophetvelen") this.doublepriest++;
                spellpower = spellpower + m.handcard.card.spellpowervalue;
                if (m.name == "auchenaisoulpriest") this.auchenaiseelenpriesterin = true;

                if (m.name == "pint-sizedsummoner")
                {
                    this.winzigebeschwoererin++;
                    this.startedWithWinzigebeschwoererin++;
                }
                if (m.name == "sorcerersapprentice")
                {
                    this.zauberlehrling++;
                    this.startedWithZauberlehrling++;
                }
                if (m.name == "manawraith")
                {
                    this.managespenst++;
                    this.startedWithManagespenst++;
                }
                if (m.name == "venturecomercenary")
                {
                    this.soeldnerDerVenture++;
                    this.startedWithsoeldnerDerVenture++;
                }
                if (m.name == "summoningportal")
                {
                    this.beschwoerungsportal++;
                    this.startedWithbeschwoerungsportal++;
                }

                foreach (Enchantment e in m.enchantments)// only at first init needed, after that its copied
                {
                    if (e.CARDID == "NEW1_036e" || e.CARDID == "NEW1_036e2") m.cantLowerHPbelowONE = true;
                }
            }

            foreach (Minion m in this.enemyMinions)
            {
                if (m.silenced) continue;
                if (m.name == "manawraith")
                {
                    this.managespenst++;
                    this.startedWithManagespenst++;
                }
            }


        }

        public Playfield(Playfield p)
        {
            this.sEnemTurn = p.sEnemTurn;
            this.ownController = p.ownController;
            this.ownHeroEntity = p.ownHeroEntity;
            this.enemyHeroEntity = p.enemyHeroEntity;

            this.evaluatePenality = p.evaluatePenality;

            foreach(string s in p.ownSecretsIDList)
            { this.ownSecretsIDList.Add(s); }
            this.enemySecretCount = p.enemySecretCount;
            this.mana = p.mana;
            this.ownMaxMana = p.ownMaxMana;
            this.enemyMaxMana = p.enemyMaxMana;
            addMinionsReal(p.ownMinions, ownMinions);
            addMinionsReal(p.enemyMinions, enemyMinions);
            addCardsReal(p.owncards);
            this.enemyHeroHp = p.enemyHeroHp;
            this.ownHeroName = p.ownHeroName;
            this.enemyHeroName = p.enemyHeroName;
            this.ownHeroHp = p.ownHeroHp;
            this.playactions.AddRange(p.playactions);
            this.complete = false;
            this.ownHeroReady = p.ownHeroReady;
            this.enemyHeroReady = p.enemyHeroReady;
            this.ownHeroNumAttackThisTurn = p.ownHeroNumAttackThisTurn;
            this.enemyHeroNumAttackThisTurn = p.enemyHeroNumAttackThisTurn;
            this.ownHeroWindfury = p.ownHeroWindfury;

            this.attackFaceHP = p.attackFaceHP;

            this.heroImmune = p.heroImmune;
            this.enemyHeroImmune = p.enemyHeroImmune;

            this.ownheroAngr = p.ownheroAngr;
            this.enemyheroAngr = p.enemyheroAngr;
            this.ownHeroFrozen = p.ownHeroFrozen;
            this.enemyHeroFrozen = p.enemyHeroFrozen;
            this.heroImmuneWhileAttacking = p.heroImmuneWhileAttacking;
            this.enemyheroImmuneWhileAttacking = p.enemyheroImmuneWhileAttacking;
            this.owncarddraw = p.owncarddraw;
            this.ownHeroDefence = p.ownHeroDefence;
            this.enemyWeaponAttack = p.enemyWeaponAttack;
            this.enemyWeaponDurability = p.enemyWeaponDurability;
            this.enemyWeaponName = p.enemyWeaponName;
            this.enemycarddraw = p.enemycarddraw;
            this.enemyAnzCards = p.enemyAnzCards;
            this.enemyHeroDefence = p.enemyHeroDefence;
            this.ownWeaponDurability = p.ownWeaponDurability;
            this.ownWeaponAttack = p.ownWeaponAttack;
            this.ownWeaponName = p.ownWeaponName;

            this.lostDamage = p.lostDamage;
            this.lostWeaponDamage = p.lostWeaponDamage;
            this.lostHeal = p.lostHeal;

            this.ownAbilityReady = p.ownAbilityReady;
            this.enemyAbilityReady = p.enemyAbilityReady;
            this.ownHeroAblility = p.ownHeroAblility;
            this.enemyHeroAblility = p.enemyHeroAblility;
            this.doublepriest = 0;
            this.spellpower = 0;
            this.mobsplayedThisTurn = p.mobsplayedThisTurn;
            this.startedWithMobsPlayedThisTurn = p.startedWithMobsPlayedThisTurn;
            this.cardsPlayedThisTurn = p.cardsPlayedThisTurn;
            this.ueberladung = p.ueberladung;

            this.ownDeckSize = p.ownDeckSize;
            this.enemyDeckSize = p.enemyDeckSize;
            this.ownHeroFatigue = p.ownHeroFatigue;
            this.enemyHeroFatigue = p.enemyHeroFatigue;

            //need the following for manacost-calculation
            this.ownHeroHpStarted = p.ownHeroHpStarted;
            this.enemyHeroHp = p.enemyHeroHp;
            this.ownWeaponAttackStarted = p.ownWeaponAttackStarted;
            this.ownCardsCountStarted = p.ownCardsCountStarted;
            this.ownMobsCountStarted = p.ownMobsCountStarted;

            this.startedWithWinzigebeschwoererin = p.startedWithWinzigebeschwoererin;
            this.playedmagierinderkirintor = p.playedmagierinderkirintor;

            this.startedWithZauberlehrling = p.startedWithZauberlehrling;
            this.startedWithWinzigebeschwoererin = p.startedWithWinzigebeschwoererin;
            this.startedWithManagespenst = p.startedWithManagespenst;
            this.startedWithsoeldnerDerVenture = p.startedWithsoeldnerDerVenture;
            this.startedWithbeschwoerungsportal = p.startedWithbeschwoerungsportal;

            this.zauberlehrling = 0;
            this.winzigebeschwoererin = 0;
            this.managespenst = 0;
            this.soeldnerDerVenture = 0;
            foreach (Minion m in this.ownMinions)
            {
                if (m.silenced) continue;
                if (m.handcard.card.specialMin == CardDB.specialMinions.prophetvelen) this.doublepriest++;
                spellpower = spellpower + m.handcard.card.spellpowervalue;
                if (m.handcard.card.specialMin == CardDB.specialMinions.auchenaisoulpriest) this.auchenaiseelenpriesterin = true;
                if (m.handcard.card.specialMin == CardDB.specialMinions.pintsizedsummoner) this.winzigebeschwoererin++;
                if (m.handcard.card.specialMin == CardDB.specialMinions.sorcerersapprentice) this.zauberlehrling++;
                if (m.handcard.card.specialMin == CardDB.specialMinions.manawraith) this.managespenst++;
                if (m.handcard.card.specialMin == CardDB.specialMinions.venturecomercenary) this.soeldnerDerVenture++;
                if (m.handcard.card.specialMin == CardDB.specialMinions.summoningportal) this.beschwoerungsportal++;


            }

            foreach (Minion m in this.enemyMinions)
            {
                if (m.silenced) continue;
                if (m.handcard.card.specialMin == CardDB.specialMinions.manawraith) this.managespenst++;
            }

        }

        public bool isEqual(Playfield p, bool logg)
        {
            if (logg)
            {
                if (this.value != p.value) return false;
            }
            if (this.enemySecretCount != p.enemySecretCount)
            {
                
                if(logg) Helpfunctions.Instance.logg("enemy secrets changed ");
                return false;
            }

            if (this.mana != p.mana || this.enemyMaxMana != p.enemyMaxMana || this.ownMaxMana != p.ownMaxMana)
            {
                if (logg) Helpfunctions.Instance.logg("mana changed " + this.mana + " " + p.mana + " " + this.enemyMaxMana + " " + p.enemyMaxMana + " " + this.ownMaxMana + " " + p.ownMaxMana);
                return false;
            }

            if (this.ownDeckSize != p.ownDeckSize || this.enemyDeckSize != p.enemyDeckSize || this.ownHeroFatigue != p.ownHeroFatigue || this.enemyHeroFatigue != p.enemyHeroFatigue)
            {
                if (logg) Helpfunctions.Instance.logg("deck/fatigue changed " + this.ownDeckSize + " " + p.ownDeckSize + " " + this.enemyDeckSize + " " + p.enemyDeckSize + " " + this.ownHeroFatigue + " " + p.ownHeroFatigue + " " + this.enemyHeroFatigue + " " + p.enemyHeroFatigue);
            }

            if (this.cardsPlayedThisTurn != p.cardsPlayedThisTurn || this.mobsplayedThisTurn != p.mobsplayedThisTurn || this.ueberladung != p.ueberladung)
            {
                if (logg) Helpfunctions.Instance.logg("stuff changed " + this.cardsPlayedThisTurn + " " + p.cardsPlayedThisTurn + " " + this.mobsplayedThisTurn + " " + p.mobsplayedThisTurn + " " + this.ueberladung + " " + p.ueberladung);
                return false;
            }
                
            if (this.ownHeroName != p.ownHeroName || this.enemyHeroName != p.enemyHeroName)
            {
                if (logg) Helpfunctions.Instance.logg("hero name changed ");
                return false;
            }

            if (this.ownHeroHp != p.ownHeroHp || this.ownheroAngr != p.ownheroAngr || this.ownHeroDefence != p.ownHeroDefence || this.ownHeroFrozen != p.ownHeroFrozen || this.heroImmuneWhileAttacking != p.heroImmuneWhileAttacking || this.heroImmune!=p.heroImmune)
            {
                if (logg) Helpfunctions.Instance.logg("ownhero changed " + this.ownHeroHp + " " + p.ownHeroHp + " " + this.ownheroAngr + " " + p.ownheroAngr + " " + this.ownHeroDefence + " " + p.ownHeroDefence + " " + this.ownHeroFrozen + " " + p.ownHeroFrozen + " " + this.heroImmuneWhileAttacking + " " + p.heroImmuneWhileAttacking + " " + this.heroImmune + " " + p.heroImmune);
                return false;
            }
            if (this.ownHeroReady != p.ownHeroReady || this.ownWeaponAttack != p.ownWeaponAttack || this.ownWeaponDurability != p.ownWeaponDurability || this.ownHeroNumAttackThisTurn != p.ownHeroNumAttackThisTurn || this.ownHeroWindfury != p.ownHeroWindfury)
            {
                if (logg) Helpfunctions.Instance.logg("weapon changed " + this.ownHeroReady + " " + p.ownHeroReady + " " + this.ownWeaponAttack + " " + p.ownWeaponAttack + " " + this.ownWeaponDurability + " " + p.ownWeaponDurability + " " + this.ownHeroNumAttackThisTurn + " " + p.ownHeroNumAttackThisTurn + " " + this.ownHeroWindfury + " " + p.ownHeroWindfury);
                return false;
            }
            if (this.enemyHeroHp != p.enemyHeroHp || this.enemyWeaponAttack != p.enemyWeaponAttack || this.enemyHeroDefence != p.enemyHeroDefence || this.enemyWeaponDurability != p.enemyWeaponDurability || this.enemyHeroFrozen != p.enemyHeroFrozen || this.enemyHeroImmune != p.enemyHeroImmune)
            {
                if (logg) Helpfunctions.Instance.logg("enemyhero changed " + this.enemyHeroHp + " " + p.enemyHeroHp + " " + this.enemyWeaponAttack + " " + p.enemyWeaponAttack + " " + this.enemyHeroDefence + " " + p.enemyHeroDefence + " " + this.enemyWeaponDurability + " " + p.enemyWeaponDurability + " " + this.enemyHeroFrozen + " " + p.enemyHeroFrozen + " " + this.enemyHeroImmune + " " + p.enemyHeroImmune);
                return false;
            }

            /*if (this.auchenaiseelenpriesterin != p.auchenaiseelenpriesterin || this.winzigebeschwoererin != p.winzigebeschwoererin || this.zauberlehrling != p.zauberlehrling || this.managespenst != p.managespenst || this.soeldnerDerVenture != p.soeldnerDerVenture || this.beschwoerungsportal != p.beschwoerungsportal || this.doublepriest != p.doublepriest)
            {
                Helpfunctions.Instance.logg("special minions changed " + this.auchenaiseelenpriesterin + " " + p.auchenaiseelenpriesterin + " " + this.winzigebeschwoererin + " " + p.winzigebeschwoererin + " " + this.zauberlehrling + " " + p.zauberlehrling + " " + this.managespenst + " " + p.managespenst + " " + this.soeldnerDerVenture + " " + p.soeldnerDerVenture + " " + this.beschwoerungsportal + " " + p.beschwoerungsportal + " " + this.doublepriest + " " + p.doublepriest);
                return false;
            }*/

            if (this.ownHeroAblility.name != p.ownHeroAblility.name)
            {
                if (logg) Helpfunctions.Instance.logg("hero ability changed ");
                return false;
            }
            
            if (this.spellpower != p.spellpower)
            {
                if (logg) Helpfunctions.Instance.logg("spellpower changed");
                return false;
            }
            
            if (this.ownMinions.Count != p.ownMinions.Count || this.enemyMinions.Count != p.enemyMinions.Count || this.owncards.Count != p.owncards.Count)
            {
                if (logg) Helpfunctions.Instance.logg("minions count or hand changed");
                return false;
            }

            bool minionbool = true;
            for (int i = 0; i < this.ownMinions.Count; i++)
            {
                Minion dis = this.ownMinions[i]; Minion pis = p.ownMinions[i];
                //if (dis.entitiyID == 0) dis.entitiyID = pis.entitiyID;
                //if (pis.entitiyID == 0) pis.entitiyID = dis.entitiyID;
                if (dis.entitiyID != pis.entitiyID) minionbool= false;
                if (dis.Angr != pis.Angr || dis.Hp != pis.Hp || dis.maxHp != pis.maxHp || dis.numAttacksThisTurn != pis.numAttacksThisTurn) minionbool = false;
                if (dis.Ready != pis.Ready) minionbool = false; // includes frozen, exhaunted
                if (dis.playedThisTurn != pis.playedThisTurn || dis.numAttacksThisTurn != pis.numAttacksThisTurn) minionbool = false;
                if (dis.silenced != pis.silenced || dis.stealth != pis.stealth || dis.taunt != pis.taunt || dis.windfury != pis.windfury || dis.wounded != pis.wounded || dis.zonepos != pis.zonepos) minionbool = false;
                if (dis.divineshild != pis.divineshild || dis.cantLowerHPbelowONE != pis.cantLowerHPbelowONE || dis.immune != pis.immune) minionbool = false;
               
            }
            if (minionbool == false)
            {
                if (logg) Helpfunctions.Instance.logg("ownminions changed");
                return false;
            }
            
            for (int i = 0; i < this.enemyMinions.Count; i++)
            {
                Minion dis = this.enemyMinions[i]; Minion pis = p.enemyMinions[i];
                //if (dis.entitiyID == 0) dis.entitiyID = pis.entitiyID;
                //if (pis.entitiyID == 0) pis.entitiyID = dis.entitiyID;
                if (dis.entitiyID != pis.entitiyID) minionbool = false;
                if (dis.Angr != pis.Angr || dis.Hp != pis.Hp || dis.maxHp != pis.maxHp || dis.numAttacksThisTurn != pis.numAttacksThisTurn) minionbool = false;
                if (dis.Ready != pis.Ready) minionbool = false; // includes frozen, exhaunted
                if (dis.playedThisTurn != pis.playedThisTurn || dis.numAttacksThisTurn != pis.numAttacksThisTurn) minionbool = false;
                if (dis.silenced != pis.silenced || dis.stealth != pis.stealth || dis.taunt != pis.taunt || dis.windfury != pis.windfury || dis.wounded != pis.wounded || dis.zonepos != pis.zonepos) minionbool = false;
                if (dis.divineshild != pis.divineshild || dis.cantLowerHPbelowONE != pis.cantLowerHPbelowONE || dis.immune != pis.immune) minionbool = false;
            }
            if (minionbool == false)
            {
                if (logg) Helpfunctions.Instance.logg("enemyminions changed");
                return false;
            }

            for (int i = 0; i < this.owncards.Count; i++)
            {
                Handmanager.Handcard dishc = this.owncards[i]; Handmanager.Handcard pishc = p.owncards[i];
                if ( dishc.position != pishc.position || dishc.entity != pishc.entity || dishc.getManaCost(this) != pishc.getManaCost(p))
                {
                    if (logg) Helpfunctions.Instance.logg("handcard changed: " + dishc.card.name);
                    return false;
                }
            }

            return true;
        }

        public void simulateEnemysTurn()
        {
            int maxwide = 20;

            this.enemyAbilityReady = true;
            this.enemyHeroNumAttackThisTurn = 0;
            this.enemyHeroWindfury = false;
            if (this.enemyWeaponName == "doomhammer") this.enemyHeroWindfury = true;
            this.enemyheroImmuneWhileAttacking = false;
            if (this.enemyWeaponName == "gladiatorslongbow") this.enemyheroImmuneWhileAttacking = true;
            if (!this.enemyHeroFrozen && this.enemyWeaponDurability > 0) this.enemyHeroReady = true;
            this.enemyheroAngr = this.enemyWeaponAttack;
            bool havedonesomething = true;
            List<Playfield> posmoves = new List<Playfield>();
            posmoves.Add(new Playfield(this));
            List<Playfield> temp = new List<Playfield>();
            int deep = 0;
            

            while (havedonesomething)
            {

                temp.Clear();
                temp.AddRange(posmoves);
                havedonesomething = false;
                Playfield bestold = null;
                int bestoldval = 20000000;
                foreach (Playfield p in temp)
                {

                    if (p.complete)
                    {
                        continue;
                    }
                    List<Minion> playedMinions = new List<Minion>(8);

                    foreach (Minion m in p.enemyMinions)
                    {

                        if (m.Ready && m.Angr >= 1 && !m.frozen)
                        {
                            //BEGIN:cut (double/similar) attacking minions out#####################################
                            // DONT LET SIMMILAR MINIONS ATTACK IN ONE TURN (example 3 unlesh the hounds-hounds doesnt need to simulated hole)
                            List<Minion> tempoo = new List<Minion>(playedMinions);
                            bool dontattacked = true;
                            bool isSpecial = PenalityManager.Instance.specialMinions.ContainsKey(m.name);
                            foreach (Minion mnn in tempoo)
                            {
                                // special minions are allowed to attack in silended and unsilenced state!
                                //help.logg(mnn.silenced + " " + m.silenced + " " + mnn.name + " " + m.name + " " + penman.specialMinions.ContainsKey(m.name));

                                bool otherisSpecial = PenalityManager.Instance.specialMinions.ContainsKey(mnn.name);

                                if ((!isSpecial || (isSpecial && m.silenced)) && (!otherisSpecial || (otherisSpecial && mnn.silenced))) // both are not special, if they are the same, dont add
                                {
                                    if (mnn.Angr == m.Angr && mnn.Hp == m.Hp && mnn.divineshild == m.divineshild && mnn.taunt == m.taunt && mnn.poisonous == m.poisonous) dontattacked = false;
                                    continue;
                                }

                                if (isSpecial == otherisSpecial && !m.silenced && !mnn.silenced) // same are special
                                {
                                    if (m.name != mnn.name) // different name -> take it
                                    {
                                        continue;
                                    }
                                    // same name -> test whether they are equal
                                    if (mnn.Angr == m.Angr && mnn.Hp == m.Hp && mnn.divineshild == m.divineshild && mnn.taunt == m.taunt && mnn.poisonous == m.poisonous) dontattacked = false;
                                    continue;
                                }

                            }

                            if (dontattacked)
                            {
                                playedMinions.Add(m);
                            }
                            else
                            {
                                //help.logg(m.name + " doesnt need to attack!");
                                continue;
                            }
                            //END: cut (double/similar) attacking minions out#####################################

                            //help.logg(m.name + " is going to attack!");
                            List<targett> trgts = p.getAttackTargets(false);



                            if (true)//(this.useCutingTargets)
                            {
                                trgts = Ai.Instance.cutAttackTargets(trgts, p, false);
                            }

                            foreach (targett trgt in trgts)
                            {

                                Playfield pf = new Playfield(p);
                                havedonesomething = true;
                                pf.ENEMYattackWithMinion(m, trgt.target, trgt.targetEntity);
                                posmoves.Add(pf);


                            }
                            if (trgts.Count == 1 && trgts[0].target == 100)//only enemy hero is available als attack
                            {
                                break;
                            }
                        }

                    }
                    // attacked with minions done
                    // attack with hero
                    if (p.enemyHeroReady)
                    {
                        List<targett> trgts = p.getAttackTargets(false);

                        havedonesomething = true;


                        if (true)//(this.useCutingTargets)
                        {
                            trgts = Ai.Instance.cutAttackTargets(trgts, p, false);
                        }

                        foreach (targett trgt in trgts)
                        {
                            Playfield pf = new Playfield(p);
                            pf.ENEMYattackWithWeapon(trgt.target, trgt.targetEntity, 0);
                            posmoves.Add(pf);
                        }
                    }

                    // use ability
                    /// TODO check if ready after manaup
                    
                    if (p.enemyAbilityReady && p.enemyHeroAblility.canplayCard(p, 0))
                    {
                        int abilityPenality = 0;

                        havedonesomething = true;
                        // if we have mage or priest, we have to target something####################################################
                        if (p.enemyHeroName == HeroEnum.mage || p.enemyHeroName == HeroEnum.priest)
                        {

                            List<targett> trgts = p.enemyHeroAblility.getTargetsForCard(p);
                            foreach (targett trgt in trgts)
                            {
                                    Playfield pf = new Playfield(p);
                                    havedonesomething = true;
                                    pf.ENEMYactivateAbility(p.enemyHeroAblility, trgt.target, trgt.targetEntity);
                                    posmoves.Add(pf);
                            }
                        }
                        else
                        {
                            // the other classes dont have to target####################################################
                            Playfield pf = new Playfield(p);

                                havedonesomething = true;
                                pf.ENEMYactivateAbility(p.enemyHeroAblility, -1, -1);
                                posmoves.Add(pf);
                        }

                    }

                    p.endEnemyTurn();

                    if (Ai.Instance.botBase.getPlayfieldValue(p) < bestoldval) // want the best enemy-play-> worst for us
                    {
                        bestoldval = Ai.Instance.botBase.getPlayfieldValue(p);
                        bestold = p;
                    }
                    posmoves.Remove(p);

                    if (posmoves.Count >= maxwide) break;
                }

                if ( bestoldval <= 10000 && bestold != null)
                {
                    posmoves.Add(bestold);
                }

                deep++;
                if (posmoves.Count >= maxwide) break;
            }

            foreach (Playfield p in posmoves)
            {
                if (!p.complete) p.endEnemyTurn();
            }

            int bestval = int.MaxValue;
            Playfield bestplay = posmoves[0];
            foreach (Playfield p in posmoves)
            {
                int val = Ai.Instance.botBase.getPlayfieldValue(p);
                if (bestval > val)// we search the worst value
                {
                    bestplay = p;
                    bestval = val;
                }
            }

            this.value = bestplay.value;

        }

        public List<targett> getAttackTargets(bool own)
        {
            List<targett> trgts = new List<targett>();
            List<targett> trgts2 = new List<targett>();
            bool hastanks = false;
            if (own)
            {
                trgts2.Add(new targett(200, this.enemyHeroEntity));
                foreach (Minion m in this.enemyMinions)
                {
                    if (m.stealth) continue; // cant target stealth

                    if (m.taunt)
                    {
                        hastanks = true;
                        trgts.Add(new targett(m.id + 10, m.entitiyID));
                    }
                    else
                    {
                        trgts2.Add(new targett(m.id + 10, m.entitiyID));
                    }
                }
            }
            else
            {
                trgts2.Add(new targett(100, this.ownHeroEntity));
                foreach (Minion m in this.ownMinions)
                {
                    if (m.stealth) continue; // cant target stealth

                    if (m.taunt)
                    {
                        hastanks = true;
                        trgts.Add(new targett(m.id, m.entitiyID));
                    }
                    else
                    {
                        trgts2.Add(new targett(m.id, m.entitiyID));
                    }
                }
            }

            if (hastanks) return trgts;

            return trgts2;


        }

        public int getBestPlace(CardDB.Card card, bool lethal)
        {
            if (card.type != CardDB.cardtype.MOB) return 0;
            if (this.ownMinions.Count == 0) return 0;
            if (this.ownMinions.Count == 1) return 1;

            int[] places = new int[this.ownMinions.Count];
            int i = 0;
            int tempval = 0;
            if (lethal && card.specialMin == CardDB.specialMinions.defenderofargus)
            {
                i = 0;
                foreach (Minion m in this.ownMinions)
                {

                    places[i] = 0;
                    tempval = 0;
                    if (m.Ready)
                    {
                        tempval -= m.Angr -1;
                        if(m.windfury) tempval-=m.Angr -1;
                    }
                    places[i] = tempval;

                    i++;
                }


                i = 0;
                int bestpl = 7;
                int bestval = 10000;
                foreach (Minion m in this.ownMinions)
                {
                    int prev = 0;
                    int next = 0;
                    if (i >= 1) prev = places[i - 1];
                    next = places[i];
                    if (bestval > prev + next)
                    {
                        bestval = prev + next;
                        bestpl = i;
                    }
                    i++;
                }
                return bestpl;
            }
            if (card.specialMin == CardDB.specialMinions.sunfuryprotector || card.specialMin == CardDB.specialMinions.defenderofargus) // bestplace, if right and left minions have no taunt + lots of hp, dont make priority-minions to taunt
            {
                i = 0;
                foreach (Minion m in this.ownMinions)
                {

                    places[i] = 0;
                    tempval = 0;
                    if (!m.taunt)
                    {
                        tempval -= m.Hp;
                    }
                    else
                    {
                        tempval -= m.Hp+2;
                    }

                    if (m.handcard.card.specialMin == CardDB.specialMinions.flametonguetotem) tempval += 50;
                    if (m.handcard.card.specialMin == CardDB.specialMinions.raidleader) tempval += 10;
                    if (m.handcard.card.specialMin == CardDB.specialMinions.grimscaleoracle) tempval += 10;
                    if (m.handcard.card.specialMin == CardDB.specialMinions.direwolfalpha) tempval += 50;
                    if (m.handcard.card.specialMin == CardDB.specialMinions.murlocwarleader) tempval += 10;
                    if (m.handcard.card.specialMin == CardDB.specialMinions.southseacaptain) tempval += 10;
                    if (m.handcard.card.specialMin == CardDB.specialMinions.stormwindchampion) tempval += 10;
                    if (m.handcard.card.specialMin == CardDB.specialMinions.timberwolf) tempval += 10;
                    if (m.handcard.card.specialMin == CardDB.specialMinions.leokk) tempval += 10;
                    if (m.handcard.card.specialMin == CardDB.specialMinions.northshirecleric) tempval += 10;
                    if (m.handcard.card.specialMin == CardDB.specialMinions.sorcerersapprentice) tempval += 10;
                    if (m.handcard.card.specialMin == CardDB.specialMinions.pintsizedsummoner) tempval += 10;
                    if (m.handcard.card.specialMin == CardDB.specialMinions.summoningportal) tempval += 10;
                    if (m.handcard.card.specialMin == CardDB.specialMinions.scavenginghyena) tempval += 10;

                    places[i] = tempval;

                    i++;
                }


                i = 0;
                int bestpl = 7;
                int bestval = 10000;
                foreach (Minion m in this.ownMinions)
                {
                    int prev = 0;
                    int next = 0;
                    if (i >= 1) prev = places[i - 1];
                    next = places[i];
                    if(bestval > prev + next) 
                    {
                        bestval = prev + next;
                        bestpl = i;
                    }
                    i++;
                }
                return bestpl;
            }
            // normal placement
            int cardvalue = card.Attack * 2 + card.Health;
            if (card.tank)
            {
                cardvalue += 5;
                cardvalue += card.Health;
            }

            if (card.specialMin == CardDB.specialMinions.flametonguetotem) cardvalue += 50;
            if (card.specialMin == CardDB.specialMinions.raidleader) cardvalue += 10;
            if (card.specialMin == CardDB.specialMinions.grimscaleoracle) cardvalue += 10;
            if (card.specialMin == CardDB.specialMinions.direwolfalpha) cardvalue += 50;
            if (card.specialMin == CardDB.specialMinions.murlocwarleader) cardvalue += 10;
            if (card.specialMin == CardDB.specialMinions.southseacaptain) cardvalue += 10;
            if (card.specialMin == CardDB.specialMinions.stormwindchampion) cardvalue += 10;
            if (card.specialMin == CardDB.specialMinions.timberwolf) cardvalue += 10;
            if (card.specialMin == CardDB.specialMinions.leokk) cardvalue += 10;
            if (card.specialMin == CardDB.specialMinions.northshirecleric) cardvalue += 10;
            if (card.specialMin == CardDB.specialMinions.sorcerersapprentice) cardvalue += 10;
            if (card.specialMin == CardDB.specialMinions.pintsizedsummoner) cardvalue += 10;
            if (card.specialMin == CardDB.specialMinions.summoningportal) cardvalue += 10;
            if (card.specialMin == CardDB.specialMinions.scavenginghyena) cardvalue += 10;
            cardvalue += 1;

            i = 0;
            foreach(Minion m in this.ownMinions)
            {
                places[i] = 0;
                tempval = m.Angr * 2 + m.maxHp;
                if (m.taunt)
                {
                    tempval += 6;
                    tempval += m.maxHp;
                }

                if (m.handcard.card.specialMin == CardDB.specialMinions.flametonguetotem) tempval += 50;
                if (m.handcard.card.specialMin == CardDB.specialMinions.raidleader) tempval += 10;
                if (m.handcard.card.specialMin == CardDB.specialMinions.grimscaleoracle) tempval += 10;
                if (m.handcard.card.specialMin == CardDB.specialMinions.direwolfalpha) tempval += 50;
                if (m.handcard.card.specialMin == CardDB.specialMinions.murlocwarleader) tempval += 10;
                if (m.handcard.card.specialMin == CardDB.specialMinions.southseacaptain) tempval += 10;
                if (m.handcard.card.specialMin == CardDB.specialMinions.stormwindchampion) tempval += 10;
                if (m.handcard.card.specialMin == CardDB.specialMinions.timberwolf) tempval += 10;
                if (m.handcard.card.specialMin == CardDB.specialMinions.leokk) tempval += 10;
                if (m.handcard.card.specialMin == CardDB.specialMinions.northshirecleric) tempval += 10;
                if (m.handcard.card.specialMin == CardDB.specialMinions.sorcerersapprentice) tempval += 10;
                if (m.handcard.card.specialMin == CardDB.specialMinions.pintsizedsummoner) tempval += 10;
                if (m.handcard.card.specialMin == CardDB.specialMinions.summoningportal) tempval += 10;
                if (m.handcard.card.specialMin == CardDB.specialMinions.scavenginghyena) tempval += 10;

                places[i] = tempval;

                i++;
            }

            //bigminion if >=10
            int bestplace = 0;
            int bestvale = 0;
            tempval=0;
            i=0;
            for (int j = 0; j <= this.ownMinions.Count; j++ )
            {
                int prev = cardvalue;
                int next = cardvalue;
                if (i >= 1) prev = places[i - 1];
                if (i < this.ownMinions.Count) next = places[i];


                if (cardvalue >= prev && cardvalue >= next)
                {
                    tempval = 2 * cardvalue - prev - next;
                    if (tempval > bestvale)
                    {
                        bestplace = i;
                        bestvale = tempval;
                    }
                }
                if (cardvalue <= prev && cardvalue <= next)
                {
                    tempval = -2 * cardvalue + prev + next;
                    if (tempval > bestvale)
                    {
                        bestplace = i ;
                        bestvale = tempval;
                    }
                }

                i++;
            }

            return bestplace;
        }

        public int getBestPlacePrint(CardDB.Card card)
        {
            if (card.type != CardDB.cardtype.MOB) return 0;
            if (this.ownMinions.Count == 0) return 0;
            if (this.ownMinions.Count == 1) return 1;

            int[] places = new int[this.ownMinions.Count];
            int i = 0;
            int tempval = 0;
            if (card.name == "sunfuryprotector" || card.name == "defenderofargus") // bestplace, if right and left minions have no taunt + lots of hp, dont make priority-minions to taunt
            {
                i = 0;
                foreach (Minion m in this.ownMinions)
                {

                    places[i] = 0;
                    tempval = 0;
                    if (!m.taunt)
                    {
                        tempval -= m.Hp;
                    }
                    else
                    {
                        tempval = 30;
                    }

                    if (m.name == "flametonguetotem") tempval += 50;
                    if (m.name == "raidleader") tempval += 10;
                    if (m.name == "grimscaleoracle") tempval += 10;
                    if (m.name == "direwolfalpha") tempval += 50;
                    if (m.name == "murlocwarleader") tempval += 10;
                    if (m.name == "southseacaptain") tempval += 10;
                    if (m.name == "stormwindchampion") tempval += 10;
                    if (m.name == "timberwolf") tempval += 10;
                    if (m.name == "leokk") tempval += 10;
                    if (m.name == "northshirecleric") tempval += 10;
                    if (m.name == "sorcerersapprentice") tempval += 10;
                    if (m.name == "pint-sizedsummoner") tempval += 10;
                    if (m.name == "summoningportal") tempval += 10;
                    if (m.name == "scavenginghyena") tempval += 10;

                    places[i] = tempval;

                    i++;
                }


                i = 0;
                int bestpl = 7;
                int bestval = 10000;
                foreach (Minion m in this.ownMinions)
                {
                    Helpfunctions.Instance.logg(places[i] + "");
                    int prev = 0;
                    int next = 0;
                    if (i >= 1) prev = places[i - 1];
                    next = places[i];
                    if (bestval > prev + next)
                    {
                        bestval = prev + next;
                        bestpl = i ;
                    }
                    i++;
                }
                return bestpl;
            }

            // normal placement
            int cardvalue = card.Attack * 2 + card.Health;
            if (card.tank)
            {
                cardvalue += 5;
                cardvalue += card.Health;
            }

            if (card.name == "flametonguetotem") cardvalue += 50;
            if (card.name == "raidleader") cardvalue += 10;
            if (card.name == "grimscaleoracle") cardvalue += 10;
            if (card.name == "direwolfalpha") cardvalue += 50;
            if (card.name == "murlocwarleader") cardvalue += 10;
            if (card.name == "southseacaptain") cardvalue += 10;
            if (card.name == "stormwindchampion") cardvalue += 10;
            if (card.name == "timberwolf") cardvalue += 10;
            if (card.name == "leokk") cardvalue += 10;
            if (card.name == "northshirecleric") cardvalue += 10;
            if (card.name == "sorcerersapprentice") cardvalue += 10;
            if (card.name == "pint-sizedsummoner") cardvalue += 10;
            if (card.name == "summoningportal") cardvalue += 10;
            if (card.name == "scavenginghyena") cardvalue += 10;
            cardvalue += 1;

            i = 0;
            foreach (Minion m in this.ownMinions)
            {
                places[i] = 0;
                tempval = m.Angr * 2 + m.maxHp;
                if (m.taunt)
                {
                    tempval += 6;
                    tempval += m.maxHp;
                }

                if (m.name == "flametonguetotem") tempval += 50;
                if (m.name == "raidleader") tempval += 10;
                if (m.name == "grimscaleoracle") tempval += 10;
                if (m.name == "direwolfalpha") tempval += 50;
                if (m.name == "murlocwarleader") tempval += 10;
                if (m.name == "southseacaptain") tempval += 10;
                if (m.name == "stormwindchampion") tempval += 10;
                if (m.name == "timberwolf") tempval += 10;
                if (m.name == "leokk") tempval += 10;
                if (m.name == "northshirecleric") tempval += 10;
                if (m.name == "sorcerersapprentice") tempval += 10;
                if (m.name == "pint-sizedsummoner") tempval += 10;
                if (m.name == "summoningportal") tempval += 10;
                if (m.name == "scavenginghyena") tempval += 10;

                places[i] = tempval;
                Helpfunctions.Instance.logg(places[i] + "");

                i++;
            }

            //bigminion if >=10
            int bestplace = 0;
            int bestvale = 0;
            tempval = 0;
            i = 0;
            Helpfunctions.Instance.logg(cardvalue + " (own)");
            i = 0;
            for (int j = 0; j <= this.ownMinions.Count; j++)
            {
                int prev = cardvalue;
                int next = cardvalue;
                if (i >= 1) prev = places[i - 1];
                if (i < this.ownMinions.Count)
                {
                    next = places[i];
                }


                if (cardvalue >= prev && cardvalue >= next)
                {
                    tempval = 2 * cardvalue - prev - next;
                    if (tempval > bestvale)
                    {
                        bestplace = i ;
                        bestvale = tempval;
                    }
                }
                if (cardvalue <= prev && cardvalue <= next)
                {
                    tempval = -2 * cardvalue + prev + next;
                    if (tempval > bestvale)
                    {
                        bestplace = i;
                        bestvale = tempval;
                    }
                }

                i++;
            }
            Helpfunctions.Instance.logg(bestplace + " (best)");
            return bestplace;
        }

        private void endEnemyTurn()
        {
            endTurnEffect(false);//own turn ends
            endTurnBuffs(false);//end enemy turn
            startTurnEffect(true);//start your turn
            this.complete = true;
            //Ai.Instance.botBase.getPlayfieldValue(this);

        }

        public void endTurn()
        {
            this.value = int.MinValue;

            //penalty for destroying combo

            this.evaluatePenality += ComboBreaker.Instance.checkIfComboWasPlayed(this.playactions);

            if (this.complete) return;
            endTurnEffect(true);//own turn ends
            endTurnBuffs(true);//end own buffs 
            startTurnEffect(false);//enemy turn begins
            simulateTraps();
            if (!sEnemTurn)
            {
                guessHeroDamage();
                endTurnEffect(false);//own turn ends
                endTurnBuffs(false);//end enemy turn
                startTurnEffect(true);//start your turn
                this.complete = true;
            }
            else
            {
                simulateEnemysTurn();
                this.complete = true;
            }
            
        }


        private void guessHeroDamage()
        {
            int ghd = 0;
            foreach (Minion m in this.enemyMinions)
            {
                if (m.frozen) continue;
                ghd += m.Angr;
                if (m.windfury) ghd += m.Angr;
            }

            if (this.enemyHeroName == HeroEnum.druid) ghd++;
            if (this.enemyHeroName == HeroEnum.mage) ghd++;
            if (this.enemyHeroName == HeroEnum.thief) ghd++;
            if (this.enemyHeroName == HeroEnum.hunter) ghd += 2;
            ghd += enemyWeaponAttack;

            foreach (Minion m in this.ownMinions)
            {
                if (m.frozen) continue;
                if (m.taunt) ghd -= m.Hp;
                if (m.taunt && m.divineshild) ghd -= 1;
            }

            this.guessingHeroDamage = Math.Max(0, ghd);
        }

        private void simulateTraps()
        {
            // DONT KILL ENEMY HERO (cause its only guessing)
            foreach (string secretID in this.ownSecretsIDList)
            {
                //hunter secrets############
                if (secretID == "EX1_554") //snaketrap
                {

                    //call 3 snakes (if possible)
                    int posi = this.ownMinions.Count - 1;
                    CardDB.Card kid = CardDB.Instance.getCardData("snake");
                    callKid(kid, posi, true);
                    callKid(kid, posi, true);
                    callKid(kid, posi, true);
                }
                if (secretID == "EX1_609") //snipe
                {
                    //kill weakest minion of enemy
                    List<Minion> temp = new List<Minion>(this.enemyMinions);
                    temp.Sort((a, b) => a.Angr.CompareTo(b.Angr));//take the weakest
                    if (temp.Count == 0) continue;
                    Minion m = temp[0];
                    minionGetDamagedOrHealed(m, 4, 0, false);
                }
                if (secretID == "EX1_610") //explosive trap
                {
                    //take 2 damage to each enemy
                    List<Minion> temp = new List<Minion>(this.enemyMinions);
                    foreach (Minion m in temp)
                    {
                        minionGetDamagedOrHealed(m, 2, 0,false);
                    }
                    attackEnemyHeroWithoutKill(2);
                }
                if (secretID == "EX1_611") //freezing trap
                {
                    //return weakest enemy minion to hand
                    List<Minion> temp = new List<Minion>(this.enemyMinions);
                    temp.Sort((a, b) => a.Angr.CompareTo(b.Angr));//take the weakest
                    if (temp.Count == 0) continue;
                    Minion m = temp[0];
                    minionReturnToHand(m, false,0);
                }
                if (secretID == "EX1_533") // missdirection
                {
                    // first damage to your hero is nulled -> lower guessingHeroDamage
                    List<Minion> temp = new List<Minion>(this.enemyMinions);
                    temp.Sort((a, b) => a.Angr.CompareTo(b.Angr));//take the weakest
                    if (temp.Count == 0) continue;
                    Minion m = temp[0];
                    m.Angr = 0;
                    this.evaluatePenality -= this.enemyMinions.Count;// the more the enemy minions has on board, the more the posibility to destroy something other :D
                }

                //mage secrets############
                if (secretID == "EX1_287") //counterspell
                {
                    // what should we do?
                    this.evaluatePenality -= 8;
                }

                if (secretID == "EX1_289") //ice barrier
                {
                    this.ownHeroDefence += 8;
                }

                if (secretID == "EX1_295") //ice barrier
                {
                    //set the guessed Damage to zero
                    foreach (Minion m in this.enemyMinions)
                    {
                        m.Angr = 0;
                    }
                }

                if (secretID == "EX1_294") //mirror entity
                {
                    //summon snake ( a weak minion)
                    int posi = this.ownMinions.Count - 1;
                    CardDB.Card kid = CardDB.Instance.getCardData("snake");
                    callKid(kid, posi, true);
                }
                if (secretID == "tt_010") //spellbender
                {
                    //whut???
                    // add 2 to your defence (most attack-buffs give +2, lots of damage spells too)
                    this.evaluatePenality -= 4;
                }
                if (secretID == "EX1_594") // vaporize
                {
                    // first damage to your hero is nulled -> lower guessingHeroDamage and destroy weakest minion
                    List<Minion> temp = new List<Minion>(this.enemyMinions);
                    temp.Sort((a, b) => a.Angr.CompareTo(b.Angr));//take the weakest
                    if (temp.Count == 0) continue;
                    Minion m = temp[0];
                    minionGetDestroyed(m, false);
                }
                //pala secrets############
                if (secretID == "EX1_132") // eye for an eye
                {
                    // enemy takes one damage
                    List<Minion> temp = new List<Minion>(this.enemyMinions);
                    temp.Sort((a, b) => a.Angr.CompareTo(b.Angr));//take the weakest
                    if (temp.Count == 0) continue;
                    Minion m = temp[0];
                    attackEnemyHeroWithoutKill(m.Angr);
                }
                if (secretID == "EX1_130") // noble sacrifice
                {
                    //spawn a 2/1 taunt!
                    int posi = this.ownMinions.Count - 1;
                    CardDB.Card kid = CardDB.Instance.getCardData("frostwolfgrunt");
                    callKid(kid, posi, true);
                    this.ownMinions[this.ownMinions.Count - 1].maxHp = 1;
                    this.ownMinions[this.ownMinions.Count - 1].Hp = 1;

                }

                if (secretID == "EX1_136") // redemption
                {
                    // we give our weakest minion a divine shield :D
                    List<Minion> temp = new List<Minion>(this.ownMinions);
                    temp.Sort((a, b) => a.Hp.CompareTo(b.Hp));//take the weakest
                    if (temp.Count == 0) continue;
                    foreach (Minion m in temp)
                    {
                        if (m.divineshild) continue;
                        m.divineshild = true;
                        break;
                    }
                }

                if (secretID == "EX1_379") // repentance
                {
                    // set his current lowest hp minion to x/1
                    List<Minion> temp = new List<Minion>(this.enemyMinions);
                    temp.Sort((a, b) => a.Hp.CompareTo(b.Hp));//take the weakest
                    if (temp.Count == 0) continue;
                    Minion m = temp[0];
                    m.Hp = 1;
                    m.maxHp = 1;
                }
            }

            
        }

        private void endTurnBuffs(bool own)
        {

            List<Minion> temp = new List<Minion>();

            if (own)
            {
                temp.AddRange(this.ownMinions);
            }
            else
            {
                temp.AddRange(this.enemyMinions);
            }
            // end buffs
            foreach (Minion m in temp)
            {
                m.cantLowerHPbelowONE = false;
                m.immune = false;
                List<Enchantment> tempench = new List<Enchantment>(m.enchantments);
                foreach (Enchantment e in tempench)
                {
                    if (e.CARDID == "EX1_316e")//ueberwaeltigende macht
                    {
                        minionGetDestroyed(m, own);
                    }

                    if (e.CARDID == "CS2_046e")//kampfrausch
                    {
                        debuff(m, e,own);
                    }

                    if (e.CARDID == "CS2_045e")// waffe felsbeiser
                    {
                        debuff(m, e, own);
                    }

                    if (e.CARDID == "EX1_046e")// dunkeleisenzwerg
                    {
                        debuff(m, e, own);
                    }
                    if (e.CARDID == "CS2_188o")// ruchloserunteroffizier
                    {
                        debuff(m, e, own);
                    }
                    if (e.CARDID == "EX1_055o")//  manasuechtige
                    {
                        debuff(m, e, own);
                    }
                    if (e.CARDID == "EX1_549o")//zorn des wildtiers
                    {
                        debuff(m, e, own);
                    }
                    if (e.CARDID == "EX1_334e")// dunkler wahnsin (control minion till end of turn)
                    {
                        //"uncontrol minion"
                        minionGetControlled(m, !own, true);
                    }

                }
            }

            temp.Clear();
            if (own)
            {
                temp.AddRange(this.enemyMinions);
                
            }
            else
            {
                temp.AddRange(this.ownMinions);  
            }

            foreach (Minion m in temp)
            {
                m.cantLowerHPbelowONE = false;
                m.immune = false;
                List<Enchantment> tempench = new List<Enchantment>(m.enchantments);
                foreach (Enchantment e in tempench)
                {

                    if (e.CARDID == "EX1_046e")// dunkeleisenzwerg
                    {
                        debuff(m, e,!own);
                    }
                    if (e.CARDID == "CS2_188o")// ruchloserunteroffizier
                    {
                        debuff(m, e, !own);
                    }
                    if (e.CARDID == "EX1_549o")//zorn des wildtiers
                    {
                        debuff(m, e, !own);
                    }

                }
            }

        }


        private void endTurnEffect(bool own)
        {

            List<Minion> temp = new List<Minion>();
            List<Minion> ownmins = new List<Minion>();
            List<Minion> enemymins = new List<Minion>();
            if (own)
            {
                temp.AddRange(this.ownMinions);
                ownmins.AddRange(this.ownMinions);
                enemymins.AddRange(this.enemyMinions);
            }
            else
            {
                temp.AddRange(this.enemyMinions);
                ownmins.AddRange(this.enemyMinions);
                enemymins.AddRange(this.ownMinions);
            }

     

            foreach (Minion m in temp)
            {
                if (m.silenced) continue;

                if (m.name == "barongeddon") // all other chards get dmg get 2 dmg
                {
                    List<Minion> temp2 = new List<Minion>(this.ownMinions);
                    foreach (Minion mm in temp2)
                    {
                        if (mm.entitiyID != m.entitiyID)
                        {
                            minionGetDamagedOrHealed(mm, 2, 0, true);
                        }
                    }
                    temp2.Clear();
                    temp2.AddRange(this.enemyMinions);
                    foreach (Minion mm in temp2)
                    {
                        if (mm.entitiyID != m.entitiyID)
                        {
                            minionGetDamagedOrHealed(mm, 2, 0, false);
                        }
                    }
                    attackOrHealHero(2, true);
                    attackOrHealHero(2, false);

                }

                if (m.name == "bloodimp" || m.name == "youngpriestess") // buff a minion
                {
                    List<Minion> temp2 = new List<Minion>(ownmins);
                    temp2.Sort((a, b) => a.Hp.CompareTo(b.Hp));//buff the weakest
                    foreach (Minion mins in Helpfunctions.TakeList(temp2, 1))
                    {
                        minionGetBuffed(mins, 0, 1, own);
                    }
                }

                if (m.name == "masterswordsmith") // buff a minion
                {
                    List<Minion> temp2 = new List<Minion>(ownmins);
                    temp2.Sort((a, b) => a.Angr.CompareTo(b.Angr));//buff the weakest
                    foreach (Minion mins in Helpfunctions.TakeList(temp2, 1))
                    {
                        minionGetBuffed(mins, 1, 0, own);
                    }
                }

                if (m.name == "emboldener3000") // buff a minion
                {
                    List<Minion> temp2 = new List<Minion>(this.enemyMinions);
                    temp2.Sort((a, b) => -a.Angr.CompareTo(b.Angr));//buff the strongest enemy
                    foreach (Minion mins in Helpfunctions.TakeList(temp2, 1))
                    {
                        minionGetBuffed(mins, 1, 0, false);//buff alyways enemy :D
                    }
                }

                if (m.name == "gruul") // gain +1/+1
                {
                    minionGetBuffed(m, 1, 1, own);
                }

                if (m.name == "etherealarcanist") // gain +2/+2
                {
                    if (own && this.ownSecretsIDList.Count>=1)
                    {
                        minionGetBuffed(m, 2, 2, own);
                    }
                    if (!own && this.enemySecretCount >= 1)
                    {
                        minionGetBuffed(m, 2, 2, own);
                    }
                }


                if (m.name == "manatidetotem") // draw card
                {
                    if (own)
                    {
                        //this.owncarddraw++;
                        this.drawACard("", own);
                    }
                    else
                    {
                        //this.enemycarddraw++;
                        this.drawACard("", own);
                    }
                }

                if (m.name == "healingtotem") // heal
                {
                    List<Minion> temp2 = new List<Minion>(ownmins);
                    foreach (Minion mins in temp2)
                    {
                        minionGetDamagedOrHealed(mins, 0, 1, own);
                    }
                }

                if (m.name == "hogger") // summon
                {
                    int posi = m.id;
                    CardDB.Card kid = CardDB.Instance.getCardData("gnoll");
                    callKid(kid, posi, own);
                }

                if (m.name == "impmaster") // damage itself and summon 
                {
                    int posi = m.id;
                    if (m.Hp == 1) posi--;
                    minionGetDamagedOrHealed(m, 1, 0, own);

                    CardDB.Card kid = CardDB.Instance.getCardData("imp");
                    callKid(kid, posi, own);
                }

                if (m.name == "natpagle") // draw card
                {
                    if (own)
                    {
                        //this.owncarddraw++;
                        this.drawACard("",own);
                    }
                    else
                    {
                        //this.enemycarddraw++;
                        this.drawACard("", own);
                    }
                }

                if (m.name == "ragnarosthefirelord") // summon
                {
                    if (this.enemyMinions.Count >= 1)
                    {
                        List<Minion> temp2 = new List<Minion>(enemymins);
                        temp2.Sort((a, b) => -a.Hp.CompareTo(b.Hp));//damage the stronges
                        foreach (Minion mins in Helpfunctions.TakeList(temp2, 1))
                        {
                            minionGetDamagedOrHealed(mins, 8, 0, !own);
                        }
                    }
                    else
                    {
                        attackOrHealHero(8, !own);
                    }
                }


                if (m.name == "repairbot") // heal damaged char
                {

                    attackOrHealHero(-6, false);
                }
                if (m.handcard.card.CardID == "EX1_tk9") //treant which is destroyed
                {
                    minionGetDestroyed(m, own);
                }

                if (m.name == "ysera") // draw card
                {
                    if (own)
                    {
                        //this.owncarddraw++;
                        this.drawACard("yseraawakens",own);
                    }
                    else
                    {
                        //this.enemycarddraw++;
                        this.drawACard("yseraawakens", own);
                    }
                }
            }

        }

        private void startTurnEffect(bool own)
        {
            List<Minion> temp = new List<Minion>();
            List<Minion> ownmins = new List<Minion>();
            List<Minion> enemymins = new List<Minion>();
            if (own)
            {
                temp.AddRange(this.ownMinions);
                ownmins.AddRange(this.ownMinions);
                enemymins.AddRange(this.enemyMinions);
            }
            else
            {
                temp.AddRange(this.enemyMinions);
                ownmins.AddRange(this.enemyMinions);
                enemymins.AddRange(this.ownMinions);
            }

            bool untergang=false;
            foreach (Minion m in temp)
            {
                if (m.silenced) continue;
                if (m.name == "demolisher") // deal 2 dmg
                {
                    List<Minion> temp2 = new List<Minion>(enemymins);
                    foreach (Minion mins in temp2)
                    {
                        minionGetDamagedOrHealed(mins, 2, 0, !own);
                    }
                }

                if (m.name == "doomsayer") // destroy
                {
                    untergang = true;
                }

                if (m.name == "homingchicken") // ok
                {
                    minionGetDestroyed(m, own);
                    if (own)
                    {
                        //this.owncarddraw += 3;
                        this.drawACard("",own);
                        this.drawACard("", own);
                        this.drawACard("", own);
                    }
                    else
                    {
                        //this.enemycarddraw += 3 ;
                        this.drawACard("", own);
                        this.drawACard("", own);
                        this.drawACard("", own);
                    }
                }

                if (m.name == "lightwell") // heal
                {
                    if (ownmins.Count >= 1)
                    {
                        List<Minion> temp2 = new List<Minion>(ownmins);
                        bool healed = false;
                        foreach (Minion mins in temp2)
                        {
                            if (mins.wounded)
                            {
                                minionGetDamagedOrHealed(mins, 0, 3, own);
                                healed = true;
                                break;
                            }
                        }

                        if (!healed) attackOrHealHero(-3, own);
                    }
                    else 
                    {
                        attackOrHealHero(-3, own);
                    }
                }

                if (m.name == "poultryizer") // 
                {
                    if (this.ownMinions.Count >= 1)
                    {
                        List<Minion> temp2 = new List<Minion>(this.ownMinions);
                        temp2.Sort((a, b) => -a.Hp.CompareTo(b.Hp));//damage the stronges
                        foreach (Minion mins in temp2)
                        {
                            CardDB.Card c = CardDB.Instance.getCardDataFromID("Mekka4t");
                            minionTransform(mins, c, true);
                            break;
                        }
                    }
                    else
                    {
                        List<Minion> temp2 = new List<Minion>(this.enemyMinions);
                        temp2.Sort((a, b) => a.Hp.CompareTo(b.Hp));//damage the lowest
                        foreach (Minion mins in temp2)
                        {
                            CardDB.Card c = CardDB.Instance.getCardDataFromID("Mekka4t");
                            minionTransform(mins, c, false);
                            break;
                        }
                    }
                }
                

            }


            foreach (Minion m in enemymins) // search for corruption in other minions
            {
                List<Enchantment> elist = new List<Enchantment>(m.enchantments);
                foreach (Enchantment e in elist)
                {

                    if (e.CARDID == "CS2_063e")//corruption
                    {
                        if (own && e.controllerOfCreator == this.ownController) // own turn + we owner of curruption
                        {
                            minionGetDestroyed(m, false);
                        }
                        if (!own && e.controllerOfCreator != this.ownController)
                        {
                            minionGetDestroyed(m, true);
                        }
                    }
                }
            }

            if (untergang)
            {
                foreach (Minion mins in ownmins)
                {
                    minionGetDestroyed(mins, own);
                    
                }
                foreach (Minion mins in enemymins)
                {
                    minionGetDestroyed(mins, !own);
                }
            }

            this.drawACard("", own);
        }

        private int getSpellDamageDamage(int dmg)
        {
            int retval = dmg;
            retval += this.spellpower;
            if (this.doublepriest >= 1) retval *= (2 * this.doublepriest);
            return retval;
        }

        private int getSpellHeal(int heal)
        {
            int retval = heal;
            retval += this.spellpower;
            if (this.auchenaiseelenpriesterin) retval *= -1;
            if (this.doublepriest >= 1) retval *= (2 * this.doublepriest);
            return retval;
        }

        private void attackEnemyHeroWithoutKill(int dmg)
        {
            if (this.enemyHeroImmune && dmg > 0) return;
            int oldHp = this.enemyHeroHp;
            if (dmg < 0 && this.enemyHeroHp <= 0) return;
            if (this.enemyHeroDefence <= 0)
            {
                this.enemyHeroHp = Math.Min(30, this.enemyHeroHp - dmg);
            }
            else
            {
                if (this.enemyHeroDefence > 0)
                {

                    int rest = enemyHeroDefence - dmg;
                    if (rest < 0)
                    {
                        this.enemyHeroHp += rest;
                    }
                    this.enemyHeroDefence = Math.Max(0, this.enemyHeroDefence - dmg);

                }
            }

            if (oldHp >= 1 && this.enemyHeroHp == 0) this.enemyHeroHp = 1;
        }

        private void attackOrHealHero(int dmg, bool own) // negative damage is heal
        {
            if (own)
            {
                if (this.heroImmune && dmg > 0) return;
                if (dmg < 0 || this.ownHeroDefence <= 0)
                {
                    if (dmg < 0 && this.ownHeroHp <= 0) return;
                    //heal
                    int copy = this.ownHeroHp;

                    if (dmg < 0 && this.ownHeroHp - dmg > 30) this.lostHeal += this.ownHeroHp - dmg - 30;

                    this.ownHeroHp = Math.Min(30, this.ownHeroHp - dmg);
                    if (copy < this.ownHeroHp)
                    {
                        triggerAHeroGetHealed(own);
                    }
                }
                else
                {
                    if (this.ownHeroDefence > 0 && dmg > 0)
                    {

                        int rest = this.ownHeroDefence - dmg;
                        if (rest < 0)
                        {
                            this.ownHeroHp += rest;
                        }
                        this.ownHeroDefence = Math.Max(0, this.ownHeroDefence - dmg);

                    }
                }


            }
            else
            {
                if (this.enemyHeroImmune && dmg > 0) return;
                if (dmg < 0 || this.enemyHeroDefence <= 0)
                {
                    if (dmg < 0 && this.enemyHeroHp <= 0) return;
                    int copy = this.enemyHeroHp;
                    if (dmg < 0 && this.enemyHeroHp - dmg > 30) this.lostHeal += this.enemyHeroHp - dmg - 30;
                    this.enemyHeroHp = Math.Min(30, this.enemyHeroHp - dmg);
                    if (copy < this.enemyHeroHp)
                    {
                        triggerAHeroGetHealed(own);
                    }
                }
                else
                {
                    if (this.enemyHeroDefence > 0 && dmg > 0)
                    {

                        int rest = enemyHeroDefence - dmg;
                        if (rest < 0)
                        {
                            this.enemyHeroHp += rest;
                        }
                        this.enemyHeroDefence = Math.Max(0, this.enemyHeroDefence - dmg);

                    }
                }

            }

        }

        private void debuff(Minion m, Enchantment e, bool own)
        {
            int anz = m.enchantments.RemoveAll(x => x.creator == e.creator && x.CARDID == e.CARDID);
            if (anz >= 1)
            {
                for (int i = 0; i < anz; i++)
                {

                    if (e.charge && !m.handcard.card.Charge && m.enchantments.FindAll(x => x.charge == true).Count == 0)
                    {
                        m.charge = false;
                    }
                    if (e.taunt && !m.handcard.card.tank && m.enchantments.FindAll(x => x.taunt == true).Count == 0)
                    {
                        m.taunt = false;
                    }
                    if (e.divineshild && m.enchantments.FindAll(x => x.divineshild == true).Count == 0)
                    {
                        m.divineshild = false;
                    }
                    if (e.windfury && !m.handcard.card.windfury && m.enchantments.FindAll(x => x.windfury == true).Count == 0)
                    {
                        m.divineshild = false;
                    }
                    if (e.imune && m.enchantments.FindAll(x => x.imune == true).Count == 0)
                    {
                        m.immune = false;
                    }
                    minionGetBuffed(m, -e.angrbuff, -e.hpbuff,own);
                }
            }
        }

        private void deleteEffectOf(string CardID, int creator)
        {
            // deletes the effect of the cardID with creator from all minions 
            Enchantment e = CardDB.getEnchantmentFromCardID(CardID);
            e.creator = creator;
            List<Minion> temp = new List<Minion>(this.ownMinions);
            foreach (Minion m in temp)
            {
                debuff(m, e,true);
            }
            temp.Clear();
            temp.AddRange(this.enemyMinions);
            foreach (Minion m in temp)
            {
                debuff(m, e,false);
            }
        }

        private void deleteEffectOfWithExceptions(string CardID, int creator, List<int> exeptions)
        {
            // deletes the effect of the cardID with creator from all minions 
            Enchantment e = CardDB.getEnchantmentFromCardID(CardID);
            e.creator = creator;
            foreach (Minion m in this.ownMinions)
            {
                if (!exeptions.Contains(m.id))
                {
                    debuff(m, e,true);
                }
            }

            foreach (Minion m in this.enemyMinions)
            {
                if (!exeptions.Contains(m.id))
                {
                    debuff(m, e,false);
                }
            }
        }

        private void addEffectToMinionNoDoubles(Minion m, Enchantment e, bool own)
        {
            foreach (Enchantment es in m.enchantments)
            {
                if ( es.CARDID == e.CARDID && es.creator == e.creator) return;
            }
            m.enchantments.Add(e);
            if (e.angrbuff >= 1 || e.hpbuff >= 1)
            {
                minionGetBuffed(m, e.angrbuff, e.hpbuff, own);
            }
            if (e.charge) minionGetCharge(m);
            if (e.divineshild) m.divineshild = true;
            if (e.taunt) m.taunt = true;
            if (e.windfury) minionGetWindfurry(m);
            if (e.imune) m.immune = true;
        }

        private void adjacentBuffer(Minion m, string enchantment, int before, int after, bool own)
        {
            List<Minion> lm = new List<Minion>();
            if (own)
            {
                lm.AddRange(this.ownMinions);
            }
            else
            {
                lm.AddRange(this.enemyMinions);
            }
            List<int> exeptions = new List<int>();
            exeptions.Add(before);
            exeptions.Add(after);
            deleteEffectOfWithExceptions(enchantment, m.entitiyID, exeptions);
            Enchantment e = CardDB.getEnchantmentFromCardID(enchantment);
            e.creator = m.entitiyID;
            e.controllerOfCreator = this.ownController;
            if (before >= 0)
            {
                Minion bef = lm[before];
                addEffectToMinionNoDoubles(bef, e, own);
            }
            if (after < lm.Count)
            {
                Minion bef = lm[after];
                addEffectToMinionNoDoubles(bef, e, own);
            }
        }

        private void adjacentBuffUpdate(bool own)
        {
            int before = -1;
            int after = 1;
            List<Minion> lm = new List<Minion>();
            if (own)
            {
                lm.AddRange(this.ownMinions);
            }
            else
            {
                lm.AddRange(this.enemyMinions);
            }
            foreach (Minion m in lm)
            {
                /*
                if (m.name == "direwolfalpha")
                {
                    string enchantment = "EX1_162o";
                    //help.logg("buffupdate " + m.entitiyID);
                    adjacentBuffer(m, enchantment, before, after, own);
                }
                if (m.name == "flametonguetotem")
                {
                    string enchantment = "EX1_565o";
                    adjacentBuffer(m, enchantment, before, after, own);
                }
                before++;
                after++;
                */
                getNewEffects(m, own, m.id, false);


            }

        }

        private void endEffectsDueToDeath(Minion m, bool own)
        { // minion which grants effect died
            if (m.handcard.card.specialMin == CardDB.specialMinions.raidleader) // if he dies, lower attack of all minions of his side
            {
                deleteEffectOf("CS2_122e", m.entitiyID);
            }

            if (m.handcard.card.specialMin == CardDB.specialMinions.grimscaleoracle)
            {
                deleteEffectOf("EX1_508o", m.entitiyID);
            }

            if (m.handcard.card.specialMin == CardDB.specialMinions.direwolfalpha)
            {
                deleteEffectOf("EX1_162o", m.entitiyID);
            }
            if (m.handcard.card.specialMin == CardDB.specialMinions.murlocwarleader)
            {
                deleteEffectOf("EX1_507e", m.entitiyID);
            }
            if (m.handcard.card.specialMin == CardDB.specialMinions.southseacaptain)
            {
                deleteEffectOf("NEW1_027e", m.entitiyID);
            }
            if (m.handcard.card.specialMin == CardDB.specialMinions.stormwindchampion)
            {
                deleteEffectOf("CS2_222o", m.entitiyID);
            }
            if (m.handcard.card.specialMin == CardDB.specialMinions.timberwolf)
            {
                deleteEffectOf("DS1_175o", m.entitiyID);
            }
            if (m.handcard.card.specialMin == CardDB.specialMinions.leokk)
            {
                deleteEffectOf("NEW1_033o", m.entitiyID);
            }

            //lowering truebaugederalte

            foreach (Minion mnn in this.ownMinions)
            {
                if (mnn.handcard.card.specialMin == CardDB.specialMinions.oldmurkeye && m.handcard.card.race == 14)
                {
                    minionGetBuffed(mnn, -1, 0, true);
                }
            }
            foreach (Minion mnn in this.enemyMinions)
            {
                if (mnn.handcard.card.specialMin == CardDB.specialMinions.oldmurkeye && m.handcard.card.race == 14)
                {
                    minionGetBuffed(mnn, -1, 0, false);
                }
            }

            //no deathrattle, but lowering the weapon
            if (m.handcard.card.specialMin == CardDB.specialMinions.spitefulsmith && m.wounded)// remove weapon changes form hasserfuelleschmiedin
            {
                if (own && this.ownWeaponDurability >= 1)
                {
                    this.ownWeaponAttack -= 2;
                    this.ownheroAngr -= 2;
                }
                if (!own && this.enemyWeaponDurability >= 1)
                {
                    this.enemyWeaponAttack -= 2;
                    this.enemyheroAngr -= 2;
                }
            }
        }

        private void getNewEffects(Minion m, bool own, int placeOfNewMob, bool isSummon)
        {
            bool havekriegshymnenanfuehrerin = false;
            List<Minion> temp = new List<Minion>(this.ownMinions);
            int controller = this.ownController;
            if (!own)
            {
                temp.Clear();
                temp.AddRange(this.enemyMinions);
                controller = 0;
            }
            int ownanz = temp.Count;

            if (own && isSummon && this.ownWeaponName == "swordofjustice")
            {
                minionGetBuffed(m, 1, 1, own);
                this.lowerWeaponDurability(1, true);
            }

            int adjacentplace = 1;
            if (isSummon) adjacentplace = 0;

            foreach (Minion ownm in temp)
            {
                if (ownm.silenced) continue; // silenced minions dont buff

                if (isSummon && ownm.handcard.card.specialMin == CardDB.specialMinions.warsongcommander)
                {
                    havekriegshymnenanfuehrerin = true;
                }

                if (ownm.handcard.card.specialMin == CardDB.specialMinions.raidleader && ownm.entitiyID != m.entitiyID)
                {
                    Enchantment e = CardDB.getEnchantmentFromCardID("CS2_122e");
                    e.creator = ownm.entitiyID;
                    e.controllerOfCreator = controller;
                    addEffectToMinionNoDoubles(m, e, own);

                }
                if (ownm.handcard.card.specialMin == CardDB.specialMinions.leokk && ownm.entitiyID != m.entitiyID)
                {
                    Enchantment e = CardDB.getEnchantmentFromCardID("NEW1_033o");
                    e.creator = ownm.entitiyID;
                    e.controllerOfCreator = controller;
                    addEffectToMinionNoDoubles(m, e, own);

                }
                if (ownm.handcard.card.specialMin == CardDB.specialMinions.stormwindchampion && ownm.entitiyID != m.entitiyID)
                {
                    Enchantment e = CardDB.getEnchantmentFromCardID("CS2_222o");
                    e.creator = ownm.entitiyID;
                    e.controllerOfCreator = controller;
                    addEffectToMinionNoDoubles(m, e, own);
                }
                if (ownm.handcard.card.specialMin == CardDB.specialMinions.grimscaleoracle && m.handcard.card.race == 14 && ownm.entitiyID != m.entitiyID)
                {
                    Enchantment e = CardDB.getEnchantmentFromCardID("EX1_508o");
                    e.creator = ownm.entitiyID;
                    e.controllerOfCreator = controller;
                    addEffectToMinionNoDoubles(m, e, own);
                }
                if (ownm.handcard.card.specialMin == CardDB.specialMinions.murlocwarleader && m.handcard.card.race == 14 && ownm.entitiyID != m.entitiyID)
                {
                    Enchantment e = CardDB.getEnchantmentFromCardID("EX1_507e");
                    e.creator = ownm.entitiyID;
                    e.controllerOfCreator = controller;
                    addEffectToMinionNoDoubles(m, e, own);
                }
                if (ownm.handcard.card.specialMin == CardDB.specialMinions.southseacaptain && m.handcard.card.race == 23)
                {
                    Enchantment e = CardDB.getEnchantmentFromCardID("NEW1_027e");
                    e.creator = ownm.entitiyID;
                    e.controllerOfCreator = controller;
                    addEffectToMinionNoDoubles(m, e, own);
                }


                if (ownm.handcard.card.specialMin == CardDB.specialMinions.timberwolf && (TAG_RACE)m.handcard.card.race == TAG_RACE.PET)
                {
                    Enchantment e = CardDB.getEnchantmentFromCardID("DS1_175o");
                    e.creator = ownm.entitiyID;
                    e.controllerOfCreator = controller;
                    addEffectToMinionNoDoubles(m, e, own);
                }

                if (isSummon && ownm.handcard.card.specialMin == CardDB.specialMinions.tundrarhino && (TAG_RACE)m.handcard.card.race == TAG_RACE.PET)
                {
                    minionGetCharge(m);
                }

                if (ownm.handcard.card.specialMin == CardDB.specialMinions.direwolfalpha)
                {
                    if (ownm.id == placeOfNewMob + 1 || ownm.id == placeOfNewMob - adjacentplace)
                    {
                        Enchantment e = CardDB.getEnchantmentFromCardID("EX1_162o");
                        e.creator = ownm.entitiyID;
                        e.controllerOfCreator = controller;
                        addEffectToMinionNoDoubles(m, e, own);
                    }
                    else
                    {
                        //remove effect!!
                        Enchantment e = CardDB.getEnchantmentFromCardID("EX1_162o");
                        e.creator = ownm.entitiyID;
                        e.controllerOfCreator = controller;
                        debuff(m, e, own);
                    }
                }
                if (ownm.handcard.card.specialMin == CardDB.specialMinions.flametonguetotem)
                {
                    if (ownm.id == placeOfNewMob + 1 || ownm.id == placeOfNewMob - adjacentplace)
                    {
                        Enchantment e = CardDB.getEnchantmentFromCardID("EX1_565o");
                        e.creator = ownm.entitiyID;
                        e.controllerOfCreator = controller;
                        addEffectToMinionNoDoubles(m, e, own);
                    }
                    else 
                    {
                        //remove effect!!
                        Enchantment e = CardDB.getEnchantmentFromCardID("EX1_565o");
                        e.creator = ownm.entitiyID;
                        e.controllerOfCreator = controller;
                        debuff(m, e, own);
                    }

                }
            }
            //buff oldmurk
            if (isSummon && m.handcard.card.specialMin == CardDB.specialMinions.oldmurkeye && own)
            {
                int murlocs = 0;
                foreach (Minion mnn in this.ownMinions)
                {
                    if (mnn.handcard.card.race == 14) murlocs++;
                }
                foreach (Minion mnn in this.enemyMinions)
                {
                    if (mnn.handcard.card.race == 14) murlocs++;
                }

                minionGetBuffed(m, murlocs, 0, true);
            }

            // minions that gave ALL minions buffs
            temp.Clear();
            if (own)
            {
                temp.AddRange(this.enemyMinions);
                controller = 0;
            }
            else
            {
                temp.AddRange(this.ownMinions);
                controller = this.ownController;
            }

            foreach (Minion ownm in temp) // the enemy grimmschuppenorakel!
            {
                if (ownm.silenced) continue; // silenced minions dont buff

                if (ownm.handcard.card.specialMin == CardDB.specialMinions.grimscaleoracle && m.handcard.card.race == 14 && ownm.entitiyID != m.entitiyID)
                {
                    Enchantment e = CardDB.getEnchantmentFromCardID("EX1_508o");
                    e.creator = ownm.entitiyID;
                    e.controllerOfCreator = controller;
                    addEffectToMinionNoDoubles(m, e, own);
                }
                if (ownm.handcard.card.specialMin == CardDB.specialMinions.murlocwarleader && m.handcard.card.race == 14 && ownm.entitiyID != m.entitiyID)
                {
                    Enchantment e = CardDB.getEnchantmentFromCardID("EX1_507e");
                    e.creator = ownm.entitiyID;
                    e.controllerOfCreator = controller;
                    addEffectToMinionNoDoubles(m, e, own);
                }

            }

            if (isSummon && havekriegshymnenanfuehrerin && m.Angr <= 3)
            {
                minionGetCharge(m);
            }

        }

        private void deathrattle(Minion m, bool own)
        {

            if (!m.silenced)
            {

                //real deathrattles
                if (m.handcard.card.CardID == "EX1_534")//m.name == "savannenhochmaehne"
                {
                    CardDB.Card c = CardDB.Instance.getCardData("hyena");
                    callKid(c, m.id - 1, own);
                    callKid(c, m.id - 1, own);
                }

                if (m.name == "harvestgolem")
                {
                    CardDB.Card c = CardDB.Instance.getCardData("damagedgolem");
                    callKid(c, m.id - 1, own);
                }

                if (m.name == "cairnebloodhoof")
                {
                    CardDB.Card c = CardDB.Instance.getCardData("bainebloodhoof");
                    callKid(c, m.id - 1, own);
                    //penaltity for summon this thing :D (so we dont kill it only to have a new minion)
                    this.evaluatePenality += 5;


                }

                if (m.name == "thebeast")
                {
                    CardDB.Card c = CardDB.Instance.getCardData("finkleeinhorn");
                    callKid(c, m.id - 1, own);

                }

                if (m.name == "lepergnome")
                {
                    attackOrHealHero(2, !own);
                }

                if (m.name == "loothoarder")
                {
                    if (own)
                    {
                        //this.owncarddraw++;
                        this.drawACard("", own);
                    }
                    else
                    {
                        this.drawACard("", own);
                        //this.enemycarddraw++;
                    }
                }




                if (m.name == "bloodmagethalnos")
                {
                    if (own)
                    {
                        //this.owncarddraw++;
                        this.drawACard("", own);
                    }
                    else
                    {
                        //this.enemycarddraw++;
                        this.drawACard("", own);
                    }
                }

                if (m.name == "abomination")
                {
                    if (logging) Helpfunctions.Instance.logg("deathrattle monstrositaet:");
                    attackOrHealHero(2, false);
                    attackOrHealHero(2, true);
                    List<Minion> temp = new List<Minion>(this.ownMinions);
                    foreach (Minion mnn in temp)
                    {
                        minionGetDamagedOrHealed(mnn, 2, 0, true);
                    }
                    temp.Clear();
                    temp.AddRange(this.enemyMinions);
                    foreach (Minion mnn in temp)
                    {
                        minionGetDamagedOrHealed(mnn, 2, 0, false);
                    }

                }


                if (m.name == "tirionfordring")
                {
                    if (own)
                    {
                        CardDB.Card c = CardDB.Instance.getCardData("ashbringer");
                        this.equipWeapon(c);
                    }
                    else
                    {
                        this.enemyWeaponAttack = 5;
                        this.enemyWeaponDurability = 3;
                    }
                }

                if (m.name == "sylvanaswindrunner")
                {
                    List<Minion> temp = new List<Minion>();
                    if (own)
                    {
                        List<Minion> temp2 = new List<Minion>(this.enemyMinions);
                        temp2.Sort((a, b) => a.Angr.CompareTo(b.Angr));
                        temp.AddRange(Helpfunctions.TakeList(temp2, Math.Min(2, this.enemyMinions.Count)));
                    }
                    else
                    {
                        List<Minion> temp2 = new List<Minion>(this.ownMinions);
                        temp2.Sort((a, b) => -a.Angr.CompareTo(b.Angr));
                        temp.AddRange(temp2);
                    }
                    if (temp.Count >= 1)
                    {
                        if (own)
                        {
                            Minion target = new Minion();
                            target = temp[0];
                            if (target.taunt && !temp[1].taunt) target = temp[1];
                            minionGetControlled(target, true, false);
                        }
                        else
                        {
                            Minion target = new Minion();

                            target = temp[0];
                            foreach (Minion mnn in temp)
                            {
                                if (mnn.Ready)
                                {
                                    target = mnn;
                                    break;
                                }
                            }
                            minionGetControlled(target, false, false);
                        }
                    }
                }

            }

            //deathrattle enchantments // these can be triggered after an silence (if they are casted after the silence)
            bool geistderahnen = false;
            foreach (Enchantment e in m.enchantments)
            {
                if (e.CARDID == "CS2_038e" && !geistderahnen)
                {
                    //revive minion due to "geist der ahnen"
                    CardDB.Card kid = m.handcard.card;
                    int pos = this.ownMinions.Count - 1;
                    if (!own) pos = this.enemyMinions.Count - 1;
                    callKid(kid, pos, own);
                    geistderahnen = true;
                }
                //Seele des Waldes
                if (e.CARDID == "EX1_158e")
                {
                    //revive minion due to "geist der ahnen"
                    CardDB.Card kid = CardDB.Instance.getCardDataFromID("EX1_158t");//Treant
                    int pos = this.ownMinions.Count - 1;
                    if (!own) pos = this.enemyMinions.Count - 1;
                    callKid(kid, pos, own);
                }
            }


        }

        private void triggerAMinionDied(Minion m, bool own)
        {
            List<Minion> temp = new List<Minion>();
            List<Minion> temp2 = new List<Minion>();
            if (own)
            {
                temp.AddRange(this.ownMinions);
                temp2.AddRange(this.enemyMinions);
            }
            else
            {
                temp.AddRange(this.enemyMinions);
                temp2.AddRange(this.ownMinions);
            }

            foreach (Minion mnn in temp)
            {
                if (mnn.silenced) continue;

                if (mnn.handcard.card.specialMin == CardDB.specialMinions.scavenginghyena && m.handcard.card.race == 20)
                {
                    mnn.Angr += 2; mnn.Hp += 1;
                }
                if (mnn.handcard.card.specialMin == CardDB.specialMinions.flesheatingghoul)
                {
                    mnn.Angr += 1;
                }
                if (mnn.handcard.card.specialMin == CardDB.specialMinions.cultmaster)
                {
                    if (own)
                    {
                        //this.owncarddraw++;
                        this.drawACard("", own);
                    }
                    else
                    {
                        //this.enemycarddraw++;
                        this.drawACard("", own);
                    }
                }
            }

            foreach (Minion mnn in temp2)
            {
                if (mnn.silenced) continue;
                if (mnn.handcard.card.specialMin == CardDB.specialMinions.flesheatingghoul)
                {
                    mnn.Angr += 1;
                }
            }

        }

        private void minionGetDestroyed(Minion m, bool own)
        {

            if (own)
            {
                removeMinionFromList(m, this.ownMinions, true);

            }
            else
            {
                removeMinionFromList(m, this.enemyMinions, false);
            }

        }

        private void minionReturnToHand(Minion m, bool own, int manachange)
        {

            if (own)
            {
                removeMinionFromListNoDeath(m, this.ownMinions, true);
                CardDB.Card c = m.handcard.card;
                Handmanager.Handcard hc = new Handmanager.Handcard();
                hc.card = c;
                hc.position = this.owncards.Count + 1;
                hc.entity = m.entitiyID;
                hc.manacost = c.calculateManaCost(this) + manachange ;
                this.owncards.Add(hc);
            }
            else
            {
                removeMinionFromListNoDeath(m, this.enemyMinions, false);
            }

        }

        private void minionTransform(Minion m, CardDB.Card c, bool own)
        {
            Handmanager.Handcard hc = new Handmanager.Handcard(c);
            hc.entity = m.entitiyID;
            Minion tranform = createNewMinion(hc, m.id, own);
            Minion temp = new Minion();
            temp.setMinionTominion(m);
            m.setMinionTominion(tranform);
            m.entitiyID = -2;
            this.endEffectsDueToDeath(temp, own);
            adjacentBuffUpdate(own);
            if (logging) Helpfunctions.Instance.logg("minion got sheep" + m.name + " " + m.Angr);
        }


        private void minionGetSilenced(Minion m, bool own)
        {
            //TODO
            
            m.taunt = false;
            m.stealth = false;
            m.charge = false;
            
            m.divineshild = false;
            m.poisonous = false;

            //delete enrage (if minion is silenced the first time)
            if (m.wounded && m.handcard.card.Enrage && !m.silenced)
            {
                deleteWutanfall(m, own);
            }

            //delete enrage (if minion is silenced the first time)

            if (m.frozen && m.numAttacksThisTurn == 0 && !(m.name == "ancientwatcher" || m.name == "ragnarosthefirelord") && !m.playedThisTurn)
            {
                m.Ready = true;
            }


            m.frozen = false;

            if (!m.silenced && (m.name == "ancientwatcher" || m.name == "ragnarosthefirelord") && !m.playedThisTurn && m.numAttacksThisTurn == 0)
            {
                m.Ready = true;
            }

            endEffectsDueToDeath(m, own);//the minion doesnt die, but its effect is ending

            m.enchantments.Clear();

            m.Angr = m.handcard.card.Attack;
            if (m.maxHp < m.handcard.card.Health)//minion has lower maxHp as his card -> heal his hp
            {
                m.Hp += m.handcard.card.Health - m.maxHp; //heal minion

            }
            m.maxHp = m.handcard.card.Health;
            if (m.Hp > m.maxHp) m.Hp = m.maxHp;

            getNewEffects(m, own, m.id, false);// minion get effects of others 

            m.silenced = true;
        }

        private void minionGetControlled(Minion m, bool newOwner, bool canAttack)
        {
            List<Minion> newOwnerList = new List<Minion>();

            if (newOwner) { newOwnerList = new List<Minion>(this.ownMinions); }
            else { newOwnerList.AddRange(this.enemyMinions); }

            if (newOwnerList.Count >= 7) return;

            if (newOwner)
            {
                removeMinionFromListNoDeath(m, this.enemyMinions, !newOwner);
                m.Ready = false;
                m.playedThisTurn = true;
                this.getNewEffects(m, newOwner, newOwnerList.Count, false);

                addMiniontoList(m, this.ownMinions, newOwnerList.Count, newOwner);
                if (m.charge || canAttack)
                {
                    m.charge = false;
                    minionGetCharge(m);
                }

            }
            else
            {
                removeMinionFromListNoDeath(m, this.ownMinions, !newOwner);
                //m.Ready=false;
                addMiniontoList(m, this.enemyMinions, newOwnerList.Count, newOwner);
                //if (m.charge) minionGetCharge(m);
            }

        }


        private void minionGetWindfurry(Minion m)
        {
            if (m.windfury) return;
            m.windfury = true;
            if (m.frozen) return;
            if (!m.playedThisTurn && m.numAttacksThisTurn <= 1)
            {
                m.Ready = true;
            }
            if (!m.charge && m.numAttacksThisTurn <= 1)
            {
                m.Ready = true;
            }
        }

        private void minionGetCharge(Minion m)
        {
            if (m.charge) return;
            m.charge = true;
            if (m.playedThisTurn && (m.numAttacksThisTurn == 0 || (m.numAttacksThisTurn == 1 && m.windfury)))
            {
                m.Ready = true;
            }
        }

        private void minionGetReady(Minion m) // minion get ready due to attack-buff
        {
            if (!m.silenced && (m.name == "ancientwatcher" || m.name == "ragnarosthefirelord")) return;

            if (!m.playedThisTurn && !m.frozen && (m.numAttacksThisTurn == 0 || (m.numAttacksThisTurn == 1 && m.windfury)))
            {
                m.Ready = true;
            }
        }

        private void minionGetBuffed(Minion m, int attackbuff, int hpbuff, bool own)
        {
            if (m.Angr == 0 && attackbuff >= 1) minionGetReady(m);

            m.Angr = Math.Max(0, m.Angr + attackbuff);
            
            if (hpbuff >= 1)
            {
                m.Hp = m.Hp + hpbuff;
                m.maxHp = m.maxHp + hpbuff;
            }
            else
            {
                //debuffing hp, lower only maxhp (unless maxhp < hp)
                m.maxHp = m.maxHp + hpbuff;
                if (m.maxHp < m.Hp)
                {
                    m.Hp = m.maxHp;
                }
            }


            if (m.maxHp == m.Hp)
            {
                m.wounded = false;
            }
            else
            {
                m.wounded = true;
            }

            if (m.name == "lightspawn" && !m.silenced)
            {
                m.Angr = m.Hp;
            }

            if (m.Hp <= 0)
            {
                if (own)
                {
                    this.removeMinionFromList(m, this.ownMinions, true);
                    if (logging) Helpfunctions.Instance.logg("own " + m.name + " died");
                }
                else
                {
                    this.removeMinionFromList(m, this.enemyMinions, false);
                    if (logging) Helpfunctions.Instance.logg("enemy " + m.name + " died");
                }
            }
        }


        private void deleteWutanfall(Minion m, bool own)
        {
            if (m.name == "angrychicken")
            {
                minionGetBuffed(m, -5, 0, own);
            }
            if (m.name == "amaniberserker")
            {
                minionGetBuffed(m, -3, 0, own);
            }
            if (m.name == "taurenwarrior")
            {
                minionGetBuffed(m, -3, 0, own);
            }
            if (m.name == "grommashhellscream")
            {
                minionGetBuffed(m, -6, 0, own);
            }
            if (m.name == "ragingworgen")
            {
                minionGetBuffed(m, -1, 0, own);
                minionGetWindfurry(m);
            }
            if (m.name == "spitefulsmith")
            {
                if (own && this.ownWeaponDurability >= 1)
                {
                    this.ownWeaponAttack -= 2;
                    this.ownheroAngr -= 2;
                }
                if (!own && this.enemyWeaponDurability >= 1)
                {
                    this.enemyWeaponAttack -= 2;
                    this.enemyheroAngr -= 2;
                }
            }
        }

        private void wutanfall(Minion m, bool woundedBefore, bool own) // = enrange effects
        {
            if (!m.handcard.card.Enrage) return; // if minion has no enrange, do nothing
            if (woundedBefore == m.wounded || m.silenced) return; // if he was wounded, and still is (or was unwounded) do nothing

            if (m.wounded && m.Hp >= 1) //is wounded, wasnt wounded before, grant wutanfall
            {
                if (m.name == "angrychicken")
                {
                    minionGetBuffed(m, 5, 0, own);
                }
                if (m.name == "amaniberserker")
                {
                    minionGetBuffed(m, 3, 0, own);
                }
                if (m.name == "taurenwarrior")
                {
                    minionGetBuffed(m, 3, 0, own);
                }
                if (m.name == "grommashhellscream")
                {
                    minionGetBuffed(m, 6, 0, own);
                }
                if (m.name == "ragingworgen")
                {
                    minionGetBuffed(m, 1, 0, own);
                    minionGetWindfurry(m);
                }
                if (m.name == "spitefulsmith")
                {
                    if (own && this.ownWeaponDurability >= 1)
                    {
                        this.ownWeaponAttack += 2;
                        this.ownheroAngr += 2;
                    }
                    if (!own && this.enemyWeaponDurability >= 1)
                    {
                        this.enemyWeaponAttack += 2;
                        this.enemyheroAngr += 2;
                    }
                }

            }

            if (!m.wounded) // reverse buffs
            {
                deleteWutanfall(m, own);
            }
        }

        private void triggerAHeroGetHealed(bool own)
        {
            foreach (Minion mnn in this.ownMinions)
            {
                if (mnn.silenced) continue;
                if (mnn.handcard.card.specialMin == CardDB.specialMinions.lightwarden)
                {
                    minionGetBuffed(mnn, 2, 0, true);
                }
            }
            foreach (Minion mnn in this.enemyMinions)
            {
                if (mnn.silenced) continue;
                if (mnn.handcard.card.specialMin == CardDB.specialMinions.lightwarden)
                {
                    minionGetBuffed(mnn, 2, 0, false);
                }
            }
        }

        private void triggerAMinionGetHealed(Minion m, bool own)
        {
            foreach (Minion mnn in this.ownMinions)
            {
                if (mnn.silenced) continue;
                if (mnn.handcard.card.specialMin == CardDB.specialMinions.northshirecleric)
                {
                    //this.owncarddraw++;
                    this.drawACard("", true);
                }
                if (mnn.handcard.card.specialMin == CardDB.specialMinions.lightwarden)
                {
                    minionGetBuffed(mnn, 2, 0, true);
                }
            }
            foreach (Minion mnn in this.enemyMinions)
            {
                if (mnn.silenced) continue;
                if (mnn.handcard.card.specialMin == CardDB.specialMinions.northshirecleric)
                {
                    //this.enemycarddraw++;
                    this.drawACard("", false);
                }
                if (mnn.handcard.card.specialMin == CardDB.specialMinions.lightwarden)
                {
                    minionGetBuffed(mnn, 2, 0, false);
                }
            }

        }

        private void triggerAMinionGetDamage(Minion m, bool own)
        {
            //minion take dmg
            if (m.handcard.card.specialMin == CardDB.specialMinions.acolyteofpain && !m.silenced)
            {
                if (own)
                {
                    //this.owncarddraw++;
                    this.drawACard("", own);
                }
                else
                {
                    //this.enemycarddraw++;
                    this.drawACard("", own);
                }
            }
            if (m.handcard.card.specialMin == CardDB.specialMinions.gurubashiberserker && !m.silenced)
            {
                minionGetBuffed(m, 3, 0, own);
            }
            foreach (Minion mnn in this.ownMinions)
            {
                if (mnn.silenced) continue;
                if (mnn.handcard.card.specialMin == CardDB.specialMinions.frothingberserker)
                {
                    mnn.Angr++;
                }
                if (own)
                {
                    if (mnn.handcard.card.specialMin == CardDB.specialMinions.armorsmith)
                    {
                        this.ownHeroDefence++;
                    }
                }
            }
            foreach (Minion mnn in this.enemyMinions)
            {
                if (mnn.silenced) continue;
                if (mnn.handcard.card.specialMin == CardDB.specialMinions.frothingberserker)
                {
                    mnn.Angr++;
                }
                if (!own)
                {
                    if (mnn.handcard.card.specialMin == CardDB.specialMinions.armorsmith)
                    {
                        this.enemyHeroDefence++;
                    }
                }
            }
        }

        /*private void minionGetDamagedOrHealed(Minion m, int damages, int heals, bool own)
        {
            minionGetDamagedOrHealed(m, damages, heals, own, false);
        }*/

        private void minionGetDamagedOrHealed(Minion m, int damages, int heals, bool own ,  bool dontCalcLostDmg=false, bool isMinionattack=false)
        {
            int damage = damages;
            int heal = heals;

            bool woundedbefore = m.wounded;
            if (heal < 0) // heal was shifted in damage
            {
                damage = -1 * heal;
                heal = 0;
            }

            if (damage >= 1 && m.divineshild)
            {
                m.divineshild = false;
                if (!own && !dontCalcLostDmg)
                {
                    if (isMinionattack)
                    {
                        this.lostDamage += damage;
                    }
                    else
                    {
                        this.lostDamage += damage * damage;
                    }
                } 
                return;
            }

            if (m.cantLowerHPbelowONE && damage >= 1 && damage >= m.Hp) damage = m.Hp - 1;

            if (!own && !dontCalcLostDmg && m.Hp < damage)
            {
                if (isMinionattack)
                {
                    this.lostDamage += (damage - m.Hp);
                }
                else
                {
                    this.lostDamage += (damage - m.Hp) * (damage - m.Hp);
                }
            }

            int hpcopy = m.Hp;

            if (damage >= 1)
            {
                m.Hp = m.Hp - damage;
            }
            
            if (heal >= 1)
            {
                if (own && !dontCalcLostDmg && heal <= 999 && m.Hp + heal > m.maxHp) this.lostHeal += m.Hp + heal - m.maxHp;
                
                m.Hp = m.Hp + Math.Min(heal, m.maxHp - m.Hp);
            }



            if (m.Hp >  hpcopy)
            {
                //minionWasHealed
                triggerAMinionGetHealed(m, own);
            }

            if (m.Hp < hpcopy)
            {
                triggerAMinionGetDamage(m, own);
            }

            if (m.maxHp == m.Hp)
            {
                m.wounded = false;
            }
            else
            {
                m.wounded = true;
            }

            this.wutanfall(m, woundedbefore, own);

            if (m.name == "lightspawn" && !m.silenced)
            {
                m.Angr = m.Hp;
            }


            if (m.Hp <= 0)
            {
                if (own)
                {
                    this.removeMinionFromList(m, this.ownMinions, true);
                    if (logging) Helpfunctions.Instance.logg("own " + m.name + " died");
                }
                else
                {
                    this.removeMinionFromList(m, this.enemyMinions, false);
                    if (logging) Helpfunctions.Instance.logg("enemy " + m.name + " died");
                }
            }
        }

        private void copyMinion(Minion target, Minion source)
        {
            target.name = source.name;
            target.Angr = source.Angr;
            target.handcard.card = CardDB.Instance.getCardDataFromID(source.handcard.card.CardID);
            target.charge = source.charge;
            target.divineshild = source.divineshild;
            target.exhausted = source.exhausted;
            target.frozen = source.frozen;
            target.Hp = source.Hp;
            target.immune = source.immune;
            target.maxHp = source.maxHp;
            target.playedThisTurn = source.playedThisTurn;
            target.poisonous = source.poisonous;
            target.silenced = source.silenced;
            target.stealth = source.stealth;
            target.taunt = source.taunt;
            target.windfury = source.windfury;
            target.wounded = source.wounded;
            target.Ready = false;
            if (target.charge) target.Ready = true;
            foreach (Enchantment e in source.enchantments)
            {
                Enchantment ne = CardDB.getEnchantmentFromCardID(e.CARDID);
                target.enchantments.Add(ne);
            }
        }

        private void removeMinionFromListNoDeath(Minion m, List<Minion> l, bool own)
        {
            l.Remove(m);
            int i = 0;
            foreach (Minion mnn in l)
            {
                mnn.id = i;
                mnn.zonepos = i + 1;
                i++;
            }
            this.endEffectsDueToDeath(m, own);
            adjacentBuffUpdate(own);
        }

        private void removeMinionFromList(Minion m, List<Minion> l, bool own)
        {
            l.Remove(m);
            int i = 0;
            foreach (Minion mnn in l)
            {
                mnn.id = i;
                mnn.zonepos = i + 1;
                i++;
            }

            this.endEffectsDueToDeath(m, own);
            this.deathrattle(m, own);
            this.triggerAMinionDied(m, own);
            adjacentBuffUpdate(own);

        }

        private void attack(int attacker, int target, bool dontcount)
        {
            Minion m = new Minion();
            bool attackOwn = true;
            if (attacker < 10)
            {
                m = this.ownMinions[attacker];
                attackOwn = true;
            }
            if (attacker >= 10 && attacker < 20)
            {
                m = this.enemyMinions[attacker - 10];
                attackOwn = false;
            }

            if (!dontcount)
            {
                m.numAttacksThisTurn++;
                if (m.windfury && m.numAttacksThisTurn == 2)
                {
                    m.Ready = false;
                }
                if (!m.windfury)
                {
                    m.Ready = false;
                }
            }

            if (logging) Helpfunctions.Instance.logg(".attck with" + m.name + " A " + m.Angr + " H " + m.Hp);
            
            if (target == 200)//target is hero
            {
                attackOrHealHero(m.Angr, false);
                return;
            }

            bool enemyOwn = false;
            Minion enemy = new Minion();
            if (target < 10)
            {
                enemy = this.ownMinions[target];
                enemyOwn = true;
            }

            if (target >= 10 && target < 20)
            {
                enemy = this.enemyMinions[target - 10];
                enemyOwn = false;
            }




            int ownAttack = m.Angr;
            int enemyAttack = enemy.Angr;
            // defender take damage
            if (m.handcard.card.poisionous)
            {
                minionGetDestroyed(enemy, enemyOwn);
            }
            else
            {
                int oldHP = enemy.Hp;
                minionGetDamagedOrHealed(enemy, ownAttack, 0, enemyOwn,false,true);
                if (!m.silenced && oldHP > enemy.Hp && m.handcard.card.specialMin == CardDB.specialMinions.waterelemental) enemy.frozen = true;
            }


            //attacker take damage
            if (!m.immune && !dontcount)
            {
                if (enemy.handcard.card.poisionous)
                {
                    minionGetDestroyed(m, attackOwn);
                }
                else
                {
                    int oldHP = m.Hp;
                    minionGetDamagedOrHealed(m, enemyAttack, 0, attackOwn,false,true);
                    if (!enemy.silenced && oldHP > m.Hp && enemy.handcard.card.specialMin == CardDB.specialMinions.waterelemental) m.frozen = true;
                }
            }
        }

        public void attackWithMinion(Minion ownMinion, int target, int targetEntity, int penality)
        {
            this.evaluatePenality += penality;
            Action a = new Action();
            a.minionplay = true;
            a.owntarget = ownMinion.id;
            a.ownEntitiy = ownMinion.entitiyID;
            a.enemytarget = target;
            a.enemyEntitiy = targetEntity;
            a.numEnemysBeforePlayed = this.enemyMinions.Count;
            a.comboBeforePlayed = (this.cardsPlayedThisTurn >= 1) ? true : false;
            this.playactions.Add(a);
            if (logging) Helpfunctions.Instance.logg("attck with" + ownMinion.name + " " + ownMinion.id + " trgt " + target + " A " + ownMinion.Angr + " H " + ownMinion.Hp);


            attack(ownMinion.id, target, false);

            //draw a card if the minion has enchantment from: Segen der weisheit 
            int segenderweisheitAnz = 0;
            foreach (Enchantment e in ownMinion.enchantments)
            {
                if (e.CARDID == "EX1_363e2" && e.controllerOfCreator == this.ownController)
                {
                    segenderweisheitAnz++;
                }
            }
            this.owncarddraw += segenderweisheitAnz;
            for (int i = 0; i < segenderweisheitAnz; i++)
            {
                this.drawACard("", true);
            }
        }

        public void ENEMYattackWithMinion(Minion ownMinion, int target, int targetEntity)
        {
            
            if (logging) Helpfunctions.Instance.logg("ennemy attck with" + ownMinion.name + " " + ownMinion.id + " trgt " + target + " A " + ownMinion.Angr + " H " + ownMinion.Hp);
            attack(ownMinion.id+10, target, false);
            //draw a card if the minion has enchantment from: Segen der weisheit 
            int segenderweisheitAnz = 0;
            foreach (Enchantment e in ownMinion.enchantments)
            {
                if (e.CARDID == "EX1_363e2" && e.controllerOfCreator != this.ownController)
                {
                    segenderweisheitAnz++;
                }
            }
            this.enemycarddraw += segenderweisheitAnz;
            for (int i = 0; i < segenderweisheitAnz; i++)
            {
                this.drawACard("", false);
            }
        }

        private void addMiniontoList(Minion m, List<Minion> l, int pos, bool own)
        {
            List<Minion> newmins = new List<Minion>(l);
            l.Clear();

            int i = 0;
            foreach (Minion mnn in newmins)
            {

                if (pos == i)
                {
                    m.id = i;
                    m.zonepos = i + 1;
                    l.Add(m);
                    i++;
                }
                mnn.id = i;
                mnn.zonepos = i + 1;
                l.Add(mnn);
                i++;
            }
            // maybe he is last mob
            if (pos == i)
            {
                m.id = i;
                m.zonepos = i + 1;
                l.Add(m);
                i++;
            }
            adjacentBuffUpdate(own);
            triggerPlayedAMinion(m.handcard, own);

        }

        private Minion createNewMinion(Handmanager.Handcard hc, int placeOfNewMob, bool own)
        {
            Minion m = new Minion();
            m.handcard = new Handmanager.Handcard(hc);
            m.entitiyID = hc.entity;
            m.Posix = 0;
            m.Posiy = 0;
            m.Angr = hc.card.Attack;
            m.Hp = hc.card.Health;
            m.maxHp = hc.card.Health;
            m.name = hc.card.name;
            m.playedThisTurn = true;
            m.numAttacksThisTurn = 0;
            m.id = placeOfNewMob;
            m.zonepos = placeOfNewMob + 1;


            if (hc.card.windfury) m.windfury = true;
            if (hc.card.tank) m.taunt = true;
            if (hc.card.Charge)
            {
                m.Ready = true;
                m.charge = true;
            }
            if (hc.card.Shield) m.divineshild = true;
            if (hc.card.poisionous) m.poisonous = true;

            if (hc.card.Stealth) m.stealth = true;

            if (m.name == "lightspawn" && !m.silenced)
            {
                m.Angr = m.Hp;
            }

            this.getNewEffects(m, own, placeOfNewMob,true);

            return m;
        }

        private void doBattleCryWithTargeting(Minion c, int target, int choice)
        {

            //target is the target AFTER spawning mobs
            int attackbuff = 0;
            int hpbuff = 0;
            int heal = 0;
            int damage = 0;
            bool spott = false;
            bool divineshild = false;
            bool windfury = false;
            bool silence = false;
            bool destroy = false;
            bool frozen = false;
            bool stealth = false;
            bool backtohand = false;
            int backtoHandManaChange = 0;

            bool own = true;

            if (target >= 10 && target < 20)
            {
                own = false;
            }
            Minion m = new Minion();
            if (target < 10)
            {
                m = this.ownMinions[target];
            }
            if (target >= 10 && target < 20)
            {
                m = this.enemyMinions[target - 10];
            }


            if (c.name == "ancientoflore")
            {
                if (choice == 2)
                {
                    heal = 5;
                }
            }


            if (c.name == "keeperofthegrove")
            {
                if (choice == 1)
                {
                    damage = 2;
                }

                if (choice == 2)
                {
                    silence = true;
                }
            }

            if (c.name == "crazedalchemist")
            {
                if (target < 10)
                {
                    bool woundedbef = m.wounded;
                    int temp = m.Angr;
                    m.Angr = m.Hp;
                    m.Hp = temp;
                    m.maxHp = temp;
                    m.wounded = false;
                    wutanfall(m, woundedbef, true);
                    if (m.Hp <= 0) minionGetDestroyed(m, true);
                }

                if (target >= 10 && target < 20)
                {
                    bool woundedbef = m.wounded;
                    int temp = m.Angr;
                    m.Angr = m.Hp;
                    m.Hp = temp;
                    m.maxHp = temp;
                    m.wounded = false;
                    wutanfall(m, woundedbef, false);
                    if (m.Hp <= 0) minionGetDestroyed(m, false);
                }

            }

            if (c.name == "si7agent" && this.cardsPlayedThisTurn >= 1)
            {
                damage = 2;
            }
            if (c.name == "kidnapper" && this.cardsPlayedThisTurn >= 1)
            {
                backtohand = true;
                backtoHandManaChange = 0;
            }
            if (c.name == "masterofdisguise")
            {
                stealth = true;
            }

            if (c.name == "cabalshadowpriest")
            {
                minionGetControlled(m, true, false);
            }


            if (c.name == "ironbeakowl" || c.name == "spellbreaker") //eisenschnabeleule, zauberbrecher
            {
                silence = true;
            }

            if (c.name == "shatteredsuncleric")
            {
                attackbuff = 1;
                hpbuff = 1;
            }

            if (c.name == "ancientbrewmaster")
            {
                backtohand = true;
                backtoHandManaChange = 0;
            }
            if (c.name == "youthfulbrewmaster")
            {
                backtohand = true;
                backtoHandManaChange = 0;
            }

            if (c.name == "darkirondwarf")
            {
                //attackbuff = 2;
                Enchantment e = CardDB.getEnchantmentFromCardID("EX1_046e");
                e.creator = c.entitiyID;
                e.controllerOfCreator = this.ownController;
                addEffectToMinionNoDoubles(m, e, own);
            }

            if (c.name == "hungrycrab")
            {
                destroy = true;
                /*Enchantment e = CardDB.getEnchantmentFromCardID("NEW1_017e");
                e.creator = c.entitiyID;
                e.controllerOfCreator = this.ownController;
                addEffectToMinionNoDoubles(c, e, true);//buff own hungrige krabbe*/
                minionGetBuffed(c, 2, 2, true);
            }

            if (c.name == "abusivesergeant")
            {
                Enchantment e = CardDB.getEnchantmentFromCardID("CS2_188o");
                e.creator = c.entitiyID;
                e.controllerOfCreator = this.ownController;
                addEffectToMinionNoDoubles(m, e, own);
            }
            if (c.name == "crueltaskmaster")
            {
                attackbuff = 2;
                damage = 1;
            }

            if (c.name == "frostelemental")
            {
                frozen = true;
            }

            if (c.name == "elvenarcher")
            {
                damage = 1;
            }
            if (c.name == "voodoodoctor")
            {
                if (this.auchenaiseelenpriesterin)
                { damage = 2; }
                else { heal = 2; }
            }
            if (c.name == "templeenforcer")
            {
                hpbuff = 3;
            }
            if (c.name == "ironforgerifleman")
            {
                damage = 1;
            }
            if (c.name == "stormpikecommando")
            {
                damage = 2;
            }
            if (c.name == "houndmaster")
            {
                attackbuff = 2;
                hpbuff = 2;
                spott = true;
            }

            if (c.name == "aldorpeacekeeper")
            {
                attackbuff = 1 - m.Angr;
            }

            if (c.name == "theblackknight")
            {
                destroy = true;
            }

            if (c.name == "argentprotector")
            {
                divineshild = true; // Grants NO buff
            }

            if (c.name == "windspeaker")
            {
                windfury = true;
            }
            if (c.name == "fireelemental")
            {
                damage = 3;
            }
            if (c.name == "earthenringfarseer")
            {
                if (this.auchenaiseelenpriesterin)
                { damage = 3; }
                else { heal = 3; }
            }
            if (c.name == "biggamehunter")
            {
                destroy = true;
            }

            if (c.name == "alexstrasza")
            {
                if (target == 100)
                {
                    this.ownHeroHp = 15;

                }
                if (target == 200)
                {
                    this.enemyHeroHp = 15;
                }
            }

            if (c.name == "facelessmanipulator")
            {//todo, test this :D

                copyMinion(c, m);
            }

            //make effect on target
            //ownminion
            if (target < 10)
            {
                if (attackbuff != 0 || hpbuff != 0)
                {
                    minionGetBuffed(m, attackbuff, hpbuff, true);
                }
                if (damage != 0 || heal != 0)
                {
                    minionGetDamagedOrHealed(m, damage, heal, true);
                }
                if (spott) m.taunt = true;
                if (windfury) minionGetWindfurry(m);
                if (divineshild) m.divineshild = true;
                if (destroy) minionGetDestroyed(m, true);
                if (frozen) m.frozen = true;
                if (stealth) m.stealth = true;
                if (backtohand) minionReturnToHand(m, true, backtoHandManaChange);
                if (silence) minionGetSilenced(m, true);

            }
            //enemyminion
            if (target >= 10 && target < 20)
            {
                if (attackbuff != 0 || hpbuff != 0)
                {
                    minionGetBuffed(m, attackbuff, hpbuff, false);
                }
                if (damage != 0 || heal != 0)
                {
                    minionGetDamagedOrHealed(m, damage, heal, false);
                }
                if (spott) m.taunt = true;
                if (windfury) minionGetWindfurry(m);
                if (divineshild) m.divineshild = true;
                if (destroy) minionGetDestroyed(m, false);
                if (frozen) m.frozen = true;
                if (stealth) m.stealth = true;
                if (backtohand) minionReturnToHand(m, false,backtoHandManaChange);
                if (silence) minionGetSilenced(m, false);
            }
            if (target == 100)
            {
                if (frozen) this.ownHeroFrozen = true;
                if (damage >= 1) attackOrHealHero(damage, true);
                if (heal >= 1) attackOrHealHero(-heal, true);
            }
            if (target == 200)
            {
                if (frozen) this.enemyHeroFrozen = true;
                if (damage >= 1) attackOrHealHero(damage, false);
                if (heal >= 1) attackOrHealHero(-heal, false);
            }

        }

        private void doBattleCryWithoutTargeting(Minion c, int position, bool own, int choice)
        {
            //only nontargetable battlecrys!

            //druid choices

            //urtum des krieges:
            if (c.name == "ancientofwar")
            {
                if (choice == 1)
                {
                    minionGetBuffed(c, 5, 0, true);
                }
                if (choice == 2)
                {
                    minionGetBuffed(c, 0, 5, true);
                    c.taunt = true;
                }
            }

            if (c.name == "ancientoflore")
            {
                if (choice == 1)
                {
                    //this.owncarddraw += 2;
                    this.drawACard("", own);
                    this.drawACard("", own);
                }

            }

            if (c.name == "druidoftheclaw")
            {
                if (choice == 1)
                {
                    minionGetCharge(c);
                }
                if (choice == 2)
                {
                    minionGetBuffed(c, 0, 2, true);
                    c.taunt = true;
                }
            }

            if (c.name == "cenarius")
            {
                if (choice == 1)
                {
                    foreach (Minion m in this.ownMinions)
                    {
                        minionGetBuffed(m, 2, 2, true);
                    }
                }
                //choice 2 = spawn 2 kids
            }

            //normal ones

            if (c.name == "mindcontroltech")
            {
                if (this.enemyMinions.Count >= 4)
                {
                    List<Minion> temp = new List<Minion>();

                    List<Minion> temp2 = new List<Minion>(this.enemyMinions);
                    temp2.Sort((a, b) => a.Angr.CompareTo(b.Angr));//we take the weekest

                    temp.AddRange(Helpfunctions.TakeList(temp2, 2));
                    Minion target = new Minion();
                    target = temp[0];
                    if (target.taunt && !temp[1].taunt) target = temp[1];
                    minionGetControlled(target, true, false);

                }
            }

            if (c.name == "felguard")
            {
                this.ownMaxMana--;
            }
            if (c.name == "arcanegolem")
            {
                this.enemyMaxMana++;
            }

            if (c.name == "edwinvancleef" && this.cardsPlayedThisTurn >= 1)
            {
                minionGetBuffed(c, this.cardsPlayedThisTurn * 2, this.cardsPlayedThisTurn * 2, own);
            }

            if (c.name == "doomguard")
            {
                this.owncarddraw -= Math.Min(2, this.owncards.Count);
                this.owncards.RemoveRange(0, Math.Min(2, this.owncards.Count));
            }

            if (c.name == "succubus")
            {
                this.owncarddraw -= Math.Min(1, this.owncards.Count);
                this.owncards.RemoveRange(0, Math.Min(1, this.owncards.Count));
            }

            if (c.name == "lordjaraxxus")
            {
                this.ownHeroAblility = CardDB.Instance.getCardDataFromID("EX1_tk33");
                this.ownHeroName = HeroEnum.lordjaraxxus;
                this.ownHeroHp = c.Hp;
            }

            if (c.name == "flameimp")
            {
                attackOrHealHero(3, own);
            }
            if (c.name == "pitlord")
            {
                attackOrHealHero(5, own);
            }

            if (c.name == "voidterror")
            {
                List<Minion> temp = new List<Minion>();
                if (own)
                {
                    temp.AddRange(this.ownMinions);
                }
                else
                {
                    temp.AddRange(this.enemyMinions);
                }

                int angr = 0;
                int hp = 0;
                foreach (Minion m in temp)
                {
                    if (m.id == position || m.id == position - 1)
                    {
                        angr += m.Angr;
                        hp += m.Hp;
                    }
                }
                foreach (Minion m in temp)
                {
                    if (m.id == position || m.id == position - 1)
                    {
                        minionGetDestroyed(m, own);
                    }
                }
                minionGetBuffed(c, angr, hp, own);

            }

            if (c.name == "frostwolfwarlord")
            {
                minionGetBuffed(c, this.ownMinions.Count, this.ownMinions.Count, own);
            }
            if (c.name == "bloodsailraider")
            {
                c.Angr += this.ownWeaponAttack;
            }

            if (c.name == "southseadeckhand" && this.ownWeaponDurability >= 1)
            {
                minionGetCharge(c);
            }



            if (c.name == "bloodknight")
            {
                int shilds = 0;
                foreach (Minion m in this.ownMinions)
                {
                    if (m.divineshild)
                    {
                        m.divineshild = false;
                        shilds++;
                    }
                }
                foreach (Minion m in this.enemyMinions)
                {
                    if (m.divineshild)
                    {
                        m.divineshild = false;
                        shilds++;
                    }
                }
                minionGetBuffed(c, 3 * shilds, 3 * shilds, own);

            }

            if (c.name == "kingmukla")
            {
                this.enemycarddraw += 2;
            }

            if (c.name == "coldlightoracle")
            {
                //this.enemycarddraw += 2;
                //this.owncarddraw += 2;
                this.drawACard("", true);
                this.drawACard("", true);
                this.drawACard("", false);
                this.drawACard("", false);
            }

            if (c.name == "arathiweaponsmith")
            {
                CardDB.Card wcard = CardDB.Instance.getCardData("battleaxe");
                this.equipWeapon(wcard);
                

            }
            if (c.name == "bloodsailcorsair")
            {
                this.lowerWeaponDurability(1, false);
            }

            if (c.name == "acidicswampooze")
            {
                this.lowerWeaponDurability(1000, false);
            }
            if (c.name == "noviceengineer")
            {
                //this.owncarddraw++;
                drawACard("",true);
            }
            if (c.name == "gnomishinventor")
            {
                //this.owncarddraw++;
                drawACard("", true);
            }

            if (c.name == "darkscalehealer")
            {
                List<Minion> temp = new List<Minion>(this.ownMinions);
                foreach (Minion m in temp)
                {

                    if (this.auchenaiseelenpriesterin)
                    { minionGetDamagedOrHealed(m, 2, 0, true); }
                    else { minionGetDamagedOrHealed(m, 0, 2, true); }

                }
                if (this.auchenaiseelenpriesterin)
                { attackOrHealHero(2, true); }
                else { attackOrHealHero(-2, true); }
                
            }
            if (c.name == "nightblade")
            {
                attackOrHealHero(3, !own);
            }

            if (c.name == "twilightdrake")
            {
                minionGetBuffed(c, 0, this.owncards.Count, true);
            }

            if (c.name == "azuredrake")
            {
                //this.owncarddraw++;
                drawACard("", true);
            }

            if (c.name == "harrisonjones")
            {
                this.enemyWeaponAttack = 0;
                //this.owncarddraw += enemyWeaponDurability;
                for (int i = 0; i < enemyWeaponDurability; i++)
                {
                    drawACard("", true);
                }
                this.enemyWeaponDurability = 0;
            }

            if (c.name == "guardianofkings")
            {
                attackOrHealHero(-6, true);
            }

            if (c.name == "captaingreenskin")
            {
                if (this.ownWeaponName != "")
                {
                    this.ownheroAngr += 1;
                    this.ownWeaponAttack++;
                    this.ownWeaponDurability++;
                }
            }

            if (c.name == "priestessofelune")
            {
                attackOrHealHero(-4, true);
            }
            if (c.name == "injuredblademaster")
            {
                minionGetDamagedOrHealed(c, 4, 0, true);
            }

            if (c.name == "dreadinfernal")
            {
                List<Minion> temp = new List<Minion>(this.ownMinions);
                foreach (Minion m in temp)
                {
                    minionGetDamagedOrHealed(m, 1, 0, true);
                }
                temp.Clear();
                temp.AddRange(this.enemyMinions);
                foreach (Minion m in temp)
                {
                    minionGetDamagedOrHealed(m, 1, 0, false);
                }
                attackOrHealHero(1, false);
                attackOrHealHero(1, true);
            }

            if (c.name == "tundrarhino")
            {
                minionGetCharge(c);
                List<Minion> temp = new List<Minion>(this.ownMinions);
                foreach (Minion m in temp)
                {
                    if ((TAG_RACE)m.handcard.card.race == TAG_RACE.PET)
                    {
                        minionGetCharge(m);
                    }
                }
            }

            if (c.name == "stampedingkodo")
            {
                List<Minion> temp = new List<Minion>();
                List<Minion> temp2 = new List<Minion>(this.enemyMinions);
                temp2.Sort((a, b) => a.Hp.CompareTo(b.Hp));//destroys the weakest
                temp.AddRange(temp2);
                foreach (Minion enemy in temp)
                {
                    if (enemy.Angr <= 2)
                    {
                        minionGetDestroyed(enemy, false);
                        break;
                    }
                }
            }

            if (c.name == "sunfuryprotector")
            {
                List<Minion> temp = new List<Minion>(this.ownMinions);
                foreach (Minion m in temp)
                {
                    if (m.id == position - 1 || m.id == position)
                    {
                        m.taunt = true;
                    }
                }
            }

            if (c.name == "ancientmage")
            {
                List<Minion> temp = new List<Minion>(this.ownMinions);
                foreach (Minion m in temp)
                {
                    if (m.id == position - 1 || m.id == position )
                    {
                        m.handcard.card.spellpowervalue++;
                    }
                }
            }

            if (c.name == "defenderofargus")
            {
                List<Minion> temp = new List<Minion>(this.ownMinions);
                foreach (Minion m in temp)
                {
                    if (m.id == position - 1 || m.id == position)//position and position -1 because its not placed jet
                    {
                        Enchantment e = CardDB.getEnchantmentFromCardID("EX1_093e");
                        e.creator = c.entitiyID;
                        e.controllerOfCreator = this.ownController;
                        addEffectToMinionNoDoubles(m, e, own);
                    }
                }
            }

            if (c.name == "coldlightseer")
            {
                List<Minion> temp = new List<Minion>(this.ownMinions);
                foreach (Minion m in temp)
                {
                    if ((TAG_RACE)m.handcard.card.race == TAG_RACE.MURLOC)
                    {
                        minionGetBuffed(m, 0, 2, true);
                    }
                }
                temp.Clear();
                temp.AddRange(this.enemyMinions);
                foreach (Minion m in temp)
                {
                    if ((TAG_RACE)m.handcard.card.race == TAG_RACE.MURLOC)
                    {
                        minionGetBuffed(m, 0, 2, false);
                    }
                }
            }

            if (c.name == "deathwing")
            {
                List<Minion> temp = new List<Minion>(this.ownMinions);
                foreach (Minion enemy in temp)
                {
                    minionGetDestroyed(enemy, true);
                }
                temp.Clear();
                temp.AddRange(this.enemyMinions);
                foreach (Minion enemy in temp)
                {
                    minionGetDestroyed(enemy, false);
                }
                this.owncards.Clear();
                this.owncarddraw = 0;
                this.enemyAnzCards = 0;
                this.enemycarddraw = 0;

            }

            if (c.name == "captainsparrot")
            {
                //this.owncarddraw++;
                drawACard("", true);

            }



        }

        private int spawnKids(CardDB.Card c, int position, bool own, int choice)
        {
            int kids = 0;
            if (c.name == "murloctidehunter")
            {
                kids = 1;
                CardDB.Card kid = CardDB.Instance.getCardData("murlocscout");
                callKid(kid, position, own);

            }
            if (c.name == "razorfenhunter")
            {
                kids = 1;
                CardDB.Card kid = CardDB.Instance.getCardData("boar");
                callKid(kid, position, own);

            }
            if (c.name == "dragonlingmechanic")
            {
                kids = 1;
                CardDB.Card kid = CardDB.Instance.getCardData("mechanicaldragonling");
                callKid(kid, position, own);

            }
            if (c.name == "leeroyjenkins")
            {
                kids = 2;
                CardDB.Card kid = CardDB.Instance.getCardData("whelp");
                int pos = this.ownMinions.Count - 1;
                if (own) pos = this.enemyMinions.Count - 1;
                callKid(kid, pos, !own);
                callKid(kid, pos, !own);

            }

            if (c.name == "cenarius" && choice == 2)
            {
                kids = 2;
                CardDB.Card kid = CardDB.Instance.getCardDataFromID("EX1_573t"); //special treant
                int pos = this.ownMinions.Count - 1;
                if (!own) pos = this.enemyMinions.Count - 1;
                callKid(kid, pos, own);
                callKid(kid, pos, own);

            }
            if (c.name == "silverhandknight")
            {
                kids = 1;
                CardDB.Card kid = CardDB.Instance.getCardData("squire");
                callKid(kid, position, own);

            }
            if (c.name == "gelbinmekkatorque")
            {
                kids = 1;
                CardDB.Card kid = CardDB.Instance.getCardData("homingchicken");
                callKid(kid, position, own);

            }

            if (c.name == "defiasringleader" && this.cardsPlayedThisTurn >= 1) //needs combo for spawn
            {
                kids = 1;
                CardDB.Card kid = CardDB.Instance.getCardData("defiasbandit");
                callKid(kid, position, own);

            }
            if (c.name == "onyxia")
            {
                kids = 7 - this.ownMinions.Count;
                CardDB.Card kid = CardDB.Instance.getCardData("whelp");
                for (int i = 0; i < kids; i++)
                {
                    callKid(kid, position, own);
                }


            }
            return kids;
        }

        private void callKid(CardDB.Card c, int placeoffather, bool own)
        {
            if (own && this.ownMinions.Count >= 7) return;
            if (!own && this.enemyMinions.Count >= 7) return;
            int mobplace = placeoffather + 1;
            /*if (own && this.ownMinions.Count >= 1)
            {
                retval.X = ownMinions[mobplace - 1].Posix + 85;
                retval.Y = ownMinions[mobplace - 1].Posiy;
            }
            if (!own && this.enemyMinions.Count >= 1)
            {
                retval.X = enemyMinions[mobplace - 1].Posix + 85;
                retval.Y = enemyMinions[mobplace - 1].Posiy;
            }*/

            Minion m = createNewMinion(new Handmanager.Handcard(c), mobplace, own);

            if (own)
            {
                addMiniontoList(m, this.ownMinions, mobplace, own);// additional minions span next to it!
            }
            else
            {
                addMiniontoList(m, this.enemyMinions, mobplace, own);// additional minions span next to it!
            }

        }

        private Action placeAmobSomewhere(Handmanager.Handcard hc, int cardpos, int target, int choice, int placepos)
        {

            Action a = new Action();
            a.cardplay = true;
            //a.card = new CardDB.Card(c);
            a.numEnemysBeforePlayed = this.enemyMinions.Count;
            a.comboBeforePlayed = (this.cardsPlayedThisTurn >= 1) ? true : false;

            //we place him on the right!
            int mobplace = placepos;


            //create the minion out of the card + effects from other minions, which higher his hp/angr


            // but before additional minions span next to it! (because we buff the minion in createNewMinion and swordofjustice gives summeond minons his buff first!
            int spawnkids = spawnKids(hc.card, mobplace-1, true, choice); //  if a mob targets something, it doesnt spawn minions!?
            

            //create the new minion
            Minion m = createNewMinion(hc, mobplace, true);




            //do the battlecry (where you dont need a target)
            doBattleCryWithoutTargeting(m, mobplace, true, choice);
            if (target >= 0)
            {
                doBattleCryWithTargeting(m, target, choice);

            }


            addMiniontoList(m, this.ownMinions, mobplace, true);
            if (logging) Helpfunctions.Instance.logg("added " + m.handcard.card.name);

            //only for fun :D
            if (target >= 0)
            {
                // the OWNtargets right of the placed mobs are going up :D
                if (target < 10 && target > mobplace + spawnkids) target++;
            }

            a.enemytarget = target;
            a.owntarget = mobplace + 1; //1==before the 1.minion on board , 2 ==before the 2. minion o board (from left)
            return a;
        }

        private void lowerWeaponDurability(int value, bool own)
        {
            if (own)
            {
                this.ownWeaponDurability -= value;
                if (this.ownWeaponDurability <= 0)
                {
                    this.ownheroAngr -= this.ownWeaponAttack;
                    this.ownWeaponDurability = 0;
                    this.ownWeaponAttack = 0;
                    this.ownWeaponName = "";

                    foreach (Minion m in this.ownMinions)
                    {
                        if (m.playedThisTurn && m.name == "southseadeckhand")
                        {
                            m.Ready = false;
                            m.charge = false;
                        }
                    }
                }
            }
            else
            {
                this.enemyWeaponDurability -= value;
                if (this.enemyWeaponDurability <= 0)
                {
                    this.enemyheroAngr -= this.enemyWeaponAttack;
                    this.enemyWeaponDurability = 0;
                    this.enemyWeaponAttack = 0;
                    this.enemyWeaponName = "";
                }
            }
        }


        private void equipWeapon(CardDB.Card c)
        {
            if (this.ownWeaponDurability >= 1) this.lostWeaponDamage += this.ownWeaponDurability * this.ownWeaponAttack * this.ownWeaponAttack;
            this.ownheroAngr = c.Attack;
            this.ownWeaponAttack = c.Attack;
            this.ownWeaponDurability = c.Durability;
            this.ownWeaponName = c.name;
            if (c.name == "doomhammer")
            {
                this.ownHeroWindfury = true;
            }
            else
            {
                this.ownHeroWindfury = false;
            }
            if ((this.ownHeroNumAttackThisTurn == 0 || (this.ownHeroWindfury && this.ownHeroNumAttackThisTurn == 1)) && !this.ownHeroFrozen) 
            {
                this.ownHeroReady = true;
            }
            if (c.name == "gladiatorslongbow")
            {
                this.heroImmuneWhileAttacking = true;
            }
            else
            {
                this.heroImmuneWhileAttacking = false;
            }

            foreach (Minion m in this.ownMinions)
            {
                if (m.playedThisTurn && m.name == "southseadeckhand")
                {
                    minionGetCharge(m);
                }
            }

        }

        private void playCardWithTarget(Handmanager.Handcard hc, int target, int choice)
        {
            CardDB.Card c = hc.card;
            //play card with target
            int attackbuff = 0;
            int hpbuff = 0;
            int heal = 0;
            int damage = 0;
            bool spott = false;
            bool divineshild = false;
            bool windfury = false;
            bool silence = false;
            bool destroy = false;
            bool frozen = false;
            bool stealth = false;
            bool backtohand = false;
            int backtoHandManaChange = 0;
            bool charge = false;
            bool setHPtoONE = false;
            bool immune = false;
            int adjacentDamage = 0;
            bool sheep = false;
            bool frogg = false;
            //special
            bool geistderahnen = false;
            bool ueberwaeltigendemacht = false;

            bool own = true;

            if (target >= 10 && target < 20)
            {
                own = false;
            }
            Minion m = new Minion();
            if (target < 10)
            {
                m = this.ownMinions[target];
            }
            if (target >= 10 && target < 20)
            {
                m = this.enemyMinions[target - 10];
            }


            //warrior###########################################################################

            if (c.name == "execute")
            {
                destroy = true;
            }

            if (c.name == "innerrage")
            {
                damage = 1;
                attackbuff = 2;
            }

            if (c.name == "slam")
            {
                damage = 2;
                if (m.Hp >= 3)
                {
                    //this.owncarddraw++;
                    drawACard("", true);
                }
            }

            if (c.name == "mortalstrike")
            {
                damage = 4;
                if (ownHeroHp <= 12) damage = 6;
            }

            if (c.name == "shieldslam")
            {
                damage = this.ownHeroDefence;
            }

            if (c.name == "charge")
            {
                charge = true;
                attackbuff = 2;
            }

            if (c.name == "rampage")
            {
                attackbuff = 3;
                hpbuff = 3;
            }

            //hunter#################################################################################

            if (c.name == "huntersmark")
            {
                setHPtoONE = true;
            }
            if (c.name == "arcaneshot")
            {
                damage = 2;
            }
            if (c.name == "killcommand")
            {
                damage = 3;
                foreach (Minion mnn in this.ownMinions)
                {
                    if ((TAG_RACE)mnn.handcard.card.race == TAG_RACE.PET)
                    {
                        damage = 5;
                    }
                }
            }
            if (c.name == "bestialwrath")
            {

                Enchantment e = CardDB.getEnchantmentFromCardID("EX1_549o");
                e.creator = hc.entity;
                e.controllerOfCreator = this.ownController;
                addEffectToMinionNoDoubles(m, e, own);
            }

            if (c.name == "explosiveshot")
            {
                damage = 5;
                adjacentDamage = 2;
            }

            //mage###############################################################################

            if (c.name == "icelance")
            {
                if (target >= 0 && target <= 19)
                {
                    if (m.frozen)
                    { 
                        damage = 4; 
                    }
                    else { frozen = true; }
                }
                else
                {
                    if (target ==100)
                    {
                        if (this.ownHeroFrozen)
                        {
                            damage = 4; 
                        }
                        else
                        {
                            frozen = true;
                        }
                    }
                    if (target == 200)
                    {
                        if (this.enemyHeroFrozen)
                        {
                            damage = 4;
                        }
                        else
                        {
                            frozen = true;
                        }
                    }
                }
            }

            if (c.name == "coneofcold")
            {
                damage = 1;
                adjacentDamage = 1;
                frozen = true;
            }
            if (c.name == "fireball")
            {
                damage = 6;
            }
            if (c.name == "polymorph")
            {
                sheep = true;
            }

            if (c.name == "pyroblast")
            {
                damage = 10;
            }

            if (c.name == "frostbolt")
            {
                damage = 3;
                frozen = true;
            }

            //pala######################################################################

            if (c.name == "humility")
            {
                m.Angr = 1;
            }
            if (c.name == "handofprotection")
            {
                divineshild = true;
            }
            if (c.name == "blessingofmight")
            {
                attackbuff = 3;
            }
            if (c.name == "holylight")
            {
                heal = 6;
            }

            if (c.name == "hammerofwrath")
            {
                damage = 3;
                //this.owncarddraw++;
                drawACard("", true);
            }

            if (c.name == "blessingofkings")
            {
                attackbuff = 4;
                hpbuff = 4;
            }

            if (c.name == "blessingofwisdom")
            {
                Enchantment e = CardDB.getEnchantmentFromCardID("EX1_363e2");
                e.creator = hc.entity;
                e.controllerOfCreator = this.ownController;
                m.enchantments.Add(e);
            }

            if (c.name == "blessedchampion")
            {
                m.Angr *= 2;
            }
            if (c.name == "holywrath")
            {
                damage = 2;
                //this.owncarddraw++;
                drawACard("", true);
            }
            if (c.name == "layonhands")
            {
                for (int i = 0; i < 3; i++)
                {
                    //this.owncarddraw++;
                    drawACard("", true);
                }
                heal = 8;
            }

            //priest ##########################################

            if (c.name == "shadowmadness")
            {

                Enchantment e = CardDB.getEnchantmentFromCardID("EX1_334e");
                e.creator = hc.entity;
                e.controllerOfCreator = this.ownController;
                addEffectToMinionNoDoubles(m, e, own);
                this.minionGetControlled(m, true, true);
            }

            if (c.name == "mindcontrol")
            {
                this.minionGetControlled(m, true, false);
            }

            if (c.name == "holysmite")
            {
                damage = 2;
            }
            if (c.name == "powerwordshield")
            {
                hpbuff = 2;
                //this.owncarddraw++;
                drawACard("", true);
            }
            if (c.name == "silence")
            {
                silence = true;
            }
            if (c.name == "divinespirit")
            {
                hpbuff = m.Hp;
            }
            if (c.name == "innerfire")
            {
                m.Angr = m.Hp;
            }
            if (c.name == "holyfire")
            {
                damage = 5;
                int ownheal = getSpellHeal(5);
                attackOrHealHero(-ownheal, true);
            }
            if (c.name == "shadowwordpain")
            {
                destroy = true;
            }
            if (c.name == "shadowworddeath")
            {
                destroy = true;
            }
            //rogue ##########################################
            if (c.name == "shadowstep")
            {
                backtohand = true;
                backtoHandManaChange = -2;
                //m.handcard.card.cost = Math.Max(0, m.handcard.card.cost -= 2);
            }
            if (c.name == "sap")
            {
                backtohand = true;
                backtoHandManaChange = 0;
            }
            if (c.name == "shiv")
            {
                damage = 1;
                //this.owncarddraw++;
                drawACard("", true);
            }
            if (c.name == "coldblood")
            {
                attackbuff = 2;
                if (this.cardsPlayedThisTurn >= 1) attackbuff = 4;
            }
            if (c.name == "conceal")
            {
                stealth = true;
            }
            if (c.name == "eviscerate")
            {
                damage = 2;
                if (this.cardsPlayedThisTurn >= 1) damage = 4;
            }
            if (c.name == "betrayal")
            {
                //attack right neightbor
                if (target >= 10 && target < 20 && target < this.enemyMinions.Count + 10 - 1)
                {
                    attack(target, target + 1, true);
                }
                if (target < 10 && target < this.ownMinions.Count - 1)
                {
                    attack(target, target + 1, true);
                }

                //attack left neightbor
                if (target >= 11 || (target < 10 && target >= 1))
                {
                    attack(target, target - 1, true);
                }

            }

            if (c.name == "perditionsblade")
            {
                damage = 1;
                if (this.cardsPlayedThisTurn >= 1) damage = 2;
            }

            if (c.name == "backstab")
            {
                damage = 2;
            }

            if (c.name == "assassinate")
            {
                destroy = true;
            }
            //shaman ##########################################
            if (c.name == "lightningbolt")
            {
                damage = 3;
            }
            if (c.name == "frostshock")
            {
                frozen = true;
                damage = 1;
            }
            if (c.name == "rockbiterweapon")
            {
                if (target <= 20)
                {
                    Enchantment e = CardDB.getEnchantmentFromCardID("CS2_045e");
                    e.creator = hc.entity;
                    e.controllerOfCreator = this.ownController;
                    addEffectToMinionNoDoubles(m, e, own);
                }
                else
                {
                    if (target == 100)
                    {
                        this.ownheroAngr += 3;
                        if ((this.ownHeroNumAttackThisTurn == 0 || (this.ownHeroWindfury && this.ownHeroNumAttackThisTurn == 1)) && !this.ownHeroFrozen)
                        {
                            this.ownHeroReady = true;
                        }
                    }
                }
            }
            if (c.name == "windfury")
            {
                windfury = true;
            }
            if (c.name == "hex")
            {
                frogg = true;
            }
            if (c.name == "earthshock")
            {
                silence = true;
                damage = 1;
            }
            if (c.name == "ancestralspirit")
            {
                geistderahnen = true;
            }
            if (c.name == "lavaburst")
            {
                damage = 5;
            }

            if (c.name == "ancestralhealing")
            {
                heal = 1000;
                spott = true;
            }

            //hexenmeister ##########################################

            if (c.name == "sacrificialpact")
            {
                destroy = true;
                this.attackOrHealHero(getSpellHeal(5), true); // heal own hero
            }

            if (c.name == "soulfire")
            {
                damage = 4;
                this.owncarddraw--;
                this.owncards.RemoveRange(0, Math.Min(1, this.owncards.Count));
                

            }
            if (c.name == "poweroverwhelming")
            {
                //only to own mininos
                Enchantment e = CardDB.getEnchantmentFromCardID("EX1_316e");
                e.creator = hc.entity;
                e.controllerOfCreator = this.ownController;
                addEffectToMinionNoDoubles(m, e, true);
            }
            if (c.name == "corruption")
            {
                //only to enemy mininos
                Enchantment e = CardDB.getEnchantmentFromCardID("CS2_063e");
                e.creator = hc.entity;
                e.controllerOfCreator = this.ownController;
                addEffectToMinionNoDoubles(m, e, false);
            }
            if (c.name == "mortalcoil")
            {
                damage = 1;
                if (getSpellDamageDamage(1) >= m.Hp && !m.divineshild && !m.immune)
                {
                    //this.owncarddraw++;
                    drawACard("", true);
                }
            }
            if (c.name == "drainlife")
            {
                damage = 2;
                attackOrHealHero(2, true);
            }
            if (c.name == "shadowbolt")
            {
                damage = 4;
            }
            if (c.name == "shadowflame")
            {
                int damage1 = getSpellDamageDamage(m.Angr);
                List<Minion> temp = new List<Minion>(this.enemyMinions);
                foreach (Minion mnn in temp)
                {
                    minionGetDamagedOrHealed(mnn, damage1, 0, false);
                }
                //destroy own mininon
                destroy = true;
            }

            if (c.name == "demonfire")
            {
                if (m.handcard.card.race == 15 && own)
                {
                    attackbuff = 2;
                    hpbuff = 2;
                }
                else
                {
                    damage = 2;
                }
            }
            if (c.name == "baneofdoom")
            {
                damage = 2;
                if (getSpellDamageDamage(2) >= m.Hp && !m.divineshild && !m.immune)
                {
                    int posi = this.ownMinions.Count - 1;
                    CardDB.Card kid = CardDB.Instance.getCardData("bloodimp");
                    callKid(kid, posi, true);
                }
            }

            if (c.name == "siphonsoul")
            {
                destroy = true;
                attackOrHealHero(3, true);

            }


            //druid #######################################################################

            if (c.name == "moonfire" && c.CardID == "CS2_008")// nicht zu verwechseln mit cenarius choice nummer 1
            {
                damage = 1;
            }

            if (c.name == "markofthewild")
            {
                spott = true;
                attackbuff = 2;
                hpbuff = 2;
            }

            if (c.name == "healingtouch")
            {
                heal = 8;
            }

            if (c.name == "starfire")
            {
                damage = 5;
                //this.owncarddraw++;
                drawACard("", true);
            }

            if (c.name == "naturalize")
            {
                destroy = true;
                this.enemycarddraw += 2;
            }

            if (c.name == "savagery")
            {
                damage = this.ownheroAngr;
            }

            if (c.name == "swipe")
            {
                damage = 4;
                // all others get 1 spelldamage
                int damage1 = getSpellDamageDamage(1);
                if (target != 200)
                {
                    attackOrHealHero(damage1, false);
                }
                List<Minion> temp = new List<Minion>(this.enemyMinions);
                foreach (Minion mnn in temp)
                {
                    if (mnn.id + 10 != target)
                    {
                        minionGetDamagedOrHealed(mnn, damage1, 0, false);
                    }
                }
            }

            //druid choices##################################################################################
            if (c.name == "wrath")
            {
                if (choice == 1)
                {
                    damage = 3;
                }
                if (choice == 2)
                {
                    damage = 1;
                    //this.owncarddraw++;
                    drawACard("", true);
                }
            }

            if (c.name == "markofnature")
            {
                if (choice == 1)
                {
                    attackbuff = 4;
                }
                if (choice == 2)
                {
                    spott = true;
                    hpbuff = 4;
                }
            }

            if (c.name == "starfall")
            {
                if (choice == 1)
                {
                    damage = 5;
                }

            }


            //special cards#########################################################################################

            if (c.name == "nightmare")
            {
                //only to own mininos
                Enchantment e = CardDB.getEnchantmentFromCardID("EX1_316e");
                e.creator = hc.entity;
                e.controllerOfCreator = this.ownController;
                addEffectToMinionNoDoubles(m, e, true);
            }

            if (c.name == "dream")
            {
                backtohand = true;
                backtoHandManaChange = 0;
            }

            if (c.name == "bananas")
            {
                attackbuff = 1;
                hpbuff = 1;
            }

            if (c.name == "barreltoss")
            {
                damage = 2;
            }

            if (c.CardID == "PRO_001b")// i am murloc
            {
                damage = 4;
                //this.owncarddraw++;
                drawACard("", true);

            } if (c.name == "willofmukla")
            {
                heal = 6 ;
            }

            //make effect on target
            //ownminion

            if (damage >= 1) damage = getSpellDamageDamage(damage);
            if (adjacentDamage >= 1) adjacentDamage = getSpellDamageDamage(adjacentDamage);
            if (heal >= 1 && heal < 1000) heal = getSpellHeal(heal);

            if (target < 10)
            {
                if (silence) minionGetSilenced(m, true);
                minionGetBuffed(m, attackbuff, hpbuff, true);
                minionGetDamagedOrHealed(m, damage, heal, true);
                if (spott) m.taunt = true;
                if (charge) minionGetCharge(m);
                if (windfury) minionGetWindfurry(m);
                if (divineshild) m.divineshild = true;
                if (destroy) minionGetDestroyed(m, true);
                if (frozen) m.frozen = true;
                if (stealth) m.stealth = true;
                if (backtohand) minionReturnToHand(m, true,backtoHandManaChange );
                if (immune) m.immune = true;
                if (adjacentDamage >= 1)
                {
                    List<Minion> tempolist = new List<Minion>(this.ownMinions);
                    foreach (Minion mnn in tempolist)
                    {
                        if (mnn.id == target + 1 || mnn.id == target - 1)
                        {
                            minionGetDamagedOrHealed(m, adjacentDamage, 0, own);
                            if (frozen) mnn.frozen = true;
                        }
                    }
                }
                if (sheep) minionTransform(m, CardDB.Instance.getCardDataFromID("CS2_tk1"), own);
                if (frogg) minionTransform(m, CardDB.Instance.getCardDataFromID("hexfrog"), own);
                if (setHPtoONE)
                {
                    m.Hp = 1; m.maxHp = 1;
                }

                if (geistderahnen)
                {
                    Enchantment e = CardDB.getEnchantmentFromCardID("CS2_038e");
                    e.creator = hc.entity;
                    e.controllerOfCreator = this.ownController;
                    addEffectToMinionNoDoubles(m, e, true);
                }


            }
            //enemyminion
            if (target >= 10 && target < 20)
            {
                if (silence) minionGetSilenced(m, false);
                minionGetBuffed(m, attackbuff, hpbuff, false);
                minionGetDamagedOrHealed(m, damage, heal, false);
                if (spott) m.taunt = true;
                if (charge) minionGetCharge(m);
                if (windfury) minionGetWindfurry(m);
                if (divineshild) m.divineshild = true;
                if (destroy) minionGetDestroyed(m, false);
                if (frozen) m.frozen = true;
                if (stealth) m.stealth = true;
                if (backtohand) minionReturnToHand(m, false,backtoHandManaChange);
                if (immune) m.immune = true;
                if (adjacentDamage >= 1)
                {
                    List<Minion> tempolist = new List<Minion>(this.enemyMinions);
                    foreach (Minion mnn in tempolist)
                    {
                        if (mnn.id + 10 == target + 1 || mnn.id + 10 == target - 1)
                        {
                            minionGetDamagedOrHealed(m, adjacentDamage, 0, own);
                            if (frozen) mnn.frozen = true;
                        }
                    }
                }
                if (sheep) minionTransform(m, CardDB.Instance.getCardDataFromID("CS2_tk1"), own);
                if (frogg) minionTransform(m, CardDB.Instance.getCardDataFromID("hexfrog"), own);
                if (setHPtoONE)
                {
                    m.Hp = 1; m.maxHp = 1;
                }
                if (geistderahnen)
                {
                    Enchantment e = CardDB.getEnchantmentFromCardID("CS2_038e");
                    e.creator = hc.entity;
                    e.controllerOfCreator = this.ownController;
                    addEffectToMinionNoDoubles(m, e, false);
                }

            }
            if (target == 100)
            {
                if (frozen) this.ownHeroFrozen = true;
                if (damage >= 1) attackOrHealHero(damage, true);
                if (heal >= 1) attackOrHealHero(-heal, true);
            }
            if (target == 200)
            {
                if (frozen) this.enemyHeroFrozen = true;
                if (damage >= 1) attackOrHealHero(damage, false);
                if (heal >= 1) attackOrHealHero(-heal, false);
            }

        }

        private void playCardWithoutTarget(Handmanager.Handcard hc, int choice)
        {
            CardDB.Card c = hc.card;
            //todo faehrtenlesen!

            //play card without target
            if (c.name == "thecoin")
            {
                this.mana++;

            }
            //hunter#########################################################################
            if (c.name == "multi-shot" && this.enemyMinions.Count >= 2)
            {
                List<Minion> temp = new List<Minion>();
                int damage = getSpellDamageDamage(3);
                List<Minion> temp2 = new List<Minion>(this.enemyMinions);
                temp2.Sort((a, b) => -a.Hp.CompareTo(b.Hp));//damage the strongest
                temp.AddRange(Helpfunctions.TakeList(temp2, 2));
                foreach (Minion enemy in temp)
                {
                    minionGetDamagedOrHealed(enemy, damage, 0, false);
                }

            }
            if (c.name == "animalcompanion")
            {
                CardDB.Card c2 = CardDB.Instance.getCardData("misha");
                int placeoffather = this.ownMinions.Count - 1;
                callKid(c2, placeoffather, true);
            }

            if (c.name == "flare")
            {
                foreach (Minion m in this.ownMinions)
                {
                    m.stealth = false;
                }
                foreach (Minion m in this.enemyMinions)
                {
                    m.stealth = false;
                }
                //this.owncarddraw++;
                drawACard("", true);
                this.enemySecretCount = 0;
            }

            if (c.name == "unleashthehounds")
            {
                int anz = this.enemyMinions.Count;
                int posi = this.ownMinions.Count - 1;
                CardDB.Card kid = CardDB.Instance.getCardData("hound");
                for (int i = 0; i < anz; i++)
                {
                    callKid(kid, posi, true);
                }
            }

            if (c.name == "deadlyshot" && this.enemyMinions.Count >= 1)
            {
                List<Minion> temp = new List<Minion>();
                List<Minion> temp2 = new List<Minion>(this.enemyMinions);
                temp2.Sort((a, b) => a.Hp.CompareTo(b.Hp));
                temp.AddRange(Helpfunctions.TakeList(temp2, 1));
                foreach (Minion enemy in temp)
                {
                    minionGetDestroyed(enemy, false);
                }

            }

            //warrior#########################################################################
            if (c.name == "commandingshout")
            {
                List<Minion> temp = new List<Minion>(this.ownMinions);
                Enchantment e1 = CardDB.getEnchantmentFromCardID("NEW1_036e");
                e1.creator = hc.entity;
                e1.controllerOfCreator = this.ownController;
                Enchantment e2 = CardDB.getEnchantmentFromCardID("NEW1_036e2");
                e2.creator = hc.entity;
                e2.controllerOfCreator = this.ownController;
                foreach (Minion mnn in temp)
                {//cantLowerHPbelowONE
                    addEffectToMinionNoDoubles(mnn, e1, true);
                    addEffectToMinionNoDoubles(mnn, e2, true);
                    mnn.cantLowerHPbelowONE = true;
                }

            }

            if (c.name == "battlerage")
            {
                foreach (Minion mnn in this.ownMinions)
                {
                    if (mnn.wounded)
                    {
                        //this.owncarddraw++;
                        drawACard("", true);
                    }
                }

            }

            if (c.name == "brawl")
            {
                List<Minion> temp = new List<Minion>(this.ownMinions);
                foreach (Minion mnn in temp)
                {
                    minionGetDestroyed(mnn, true);
                }
                temp.Clear();
                temp.AddRange(this.enemyMinions);
                foreach (Minion mnn in temp)
                {
                    minionGetDestroyed(mnn,false);
                }

            }


            if (c.name == "cleave" && this.enemyMinions.Count >= 2)
            {
                List<Minion> temp = new List<Minion>();
                int damage = getSpellDamageDamage(2);
                List<Minion> temp2 = new List<Minion>(this.enemyMinions);
                temp2.Sort((a, b) => -a.Hp.CompareTo(b.Hp));
                temp.AddRange(Helpfunctions.TakeList(temp2, 2));
                foreach (Minion enemy in temp)
                {
                    minionGetDamagedOrHealed(enemy, damage, 0, false);
                }

            }

            if (c.name == "upgrade")
            {
                if (this.ownWeaponName != "")
                {
                    this.ownWeaponAttack++;
                    this.ownheroAngr++;
                    this.ownWeaponDurability++;
                }
                else
                {
                    CardDB.Card wcard = CardDB.Instance.getCardData("heavyaxe");
                    this.equipWeapon(wcard);
                }

            }



            if (c.name == "whirlwind")
            {
                List<Minion> temp = new List<Minion>(this.enemyMinions);
                int damage = getSpellDamageDamage(1);
                foreach (Minion enemy in temp)
                {
                    minionGetDamagedOrHealed(enemy, damage, 0, false);
                }
                temp.Clear();
                temp = new List<Minion>(this.ownMinions);
                foreach (Minion enemy in temp)
                {
                    minionGetDamagedOrHealed(enemy, damage, 0, true);
                }
            }

            if (c.name == "heroicstrike")
            {
                this.ownheroAngr = this.ownheroAngr + 4;
                if ((this.ownHeroNumAttackThisTurn == 0 || (this.ownHeroWindfury && this.ownHeroNumAttackThisTurn == 1)) && !this.ownHeroFrozen) 
                {
                    this.ownHeroReady = true;
                }
            }

            if (c.name == "shieldblock")
            {
                this.ownHeroDefence = this.ownHeroDefence + 5;
                //this.owncarddraw++;
                drawACard("", true);
            }



            //mage#########################################################################################

            if (c.name == "blizzard")
            {
                int damage = getSpellDamageDamage(2);
                List<Minion> temp = new List<Minion>(this.enemyMinions);
                int maxHp = 0;
                foreach (Minion enemy in temp)
                {
                    enemy.frozen = true;
                    if (maxHp < enemy.Hp) maxHp = enemy.Hp;

                    minionGetDamagedOrHealed(enemy, damage, 0, false, true);
                }

                this.lostDamage += Math.Max(0, damage - maxHp); 

            }

            if (c.name == "arcanemissiles")
            {
                /*List<Minion> temp = new List<Minion>(this.enemyMinions);
                temp.Sort((a, b) => -a.Hp.CompareTo(b.Hp));
                int damage = 1;
                int ammount = getSpellDamageDamage(3);
                int i = 0;
                int hp = 0;
                foreach (Minion enemy in temp)
                {
                    if (enemy.Hp >= 2)
                    {
                        minionGetDamagedOrHealed(enemy, damage, 0, false);
                        i++;
                        hp += enemy.Hp;
                        if (i == ammount) break;
                    }
                    
                }
                if (i < ammount) attackOrHealHero(ammount - i, false);*/

                int damage = 1;
                int i = 0;
                List<Minion> temp = new List<Minion>(this.enemyMinions);
                int times = this.getSpellDamageDamage(3);
                while (i < times)
                {
                    if (temp.Count >= 1)
                    {
                        temp.Sort((a, b) => -a.Hp.CompareTo(b.Hp));
                        if (temp[0].Hp == 1 && this.enemyHeroHp >= 2)
                        {
                            attackOrHealHero(damage, false);
                        }
                        else
                        {
                            minionGetDamagedOrHealed(temp[0], damage, 0, false);
                        }
                    }
                    else
                    {
                        attackOrHealHero(damage, false);
                    }
                    i++;
                }



            }
            if (c.name == "arcaneintellect")
            {
                //this.owncarddraw++;
                drawACard("", true);
                drawACard("", true);
            }

            if (c.name == "mirrorimage")
            {
                int posi = this.ownMinions.Count - 1;
                CardDB.Card kid = CardDB.Instance.getCardDataFromID("CS2_mirror");
                callKid(kid, posi, true);
                callKid(kid, posi, true);
            }

            if (c.name == "arcaneexplosion")
            {
                List<Minion> temp = new List<Minion>(this.enemyMinions);
                int damage = getSpellDamageDamage(1);
                foreach (Minion enemy in temp)
                {
                    minionGetDamagedOrHealed(enemy, damage, 0, false);
                }
            }
            if (c.name == "frostnova")
            {
                List<Minion> temp = new List<Minion>(this.enemyMinions);
                foreach (Minion enemy in temp)
                {
                    enemy.frozen = true;
                }

            }
            if (c.name == "flamestrike")
            {
                List<Minion> temp = new List<Minion>(this.enemyMinions);
                int damage = getSpellDamageDamage(4);
                int maxHp = 0;
                foreach (Minion enemy in temp)
                {
                    if (maxHp < enemy.Hp) maxHp = enemy.Hp;

                    minionGetDamagedOrHealed(enemy, damage, 0, false, true);
                }
                this.lostDamage += Math.Max(0, damage - maxHp); 

            }

            //pala#################################################################
            if (c.name == "consecration")
            {
                List<Minion> temp = new List<Minion>(this.enemyMinions);
                int damage = getSpellDamageDamage(2);
                foreach (Minion enemy in temp)
                {
                    minionGetDamagedOrHealed(enemy, damage, 0, false);
                }

                attackOrHealHero(damage, false);
            }

            if (c.name == "equality")
            {
                foreach (Minion m in this.ownMinions)
                {
                    m.Hp = 1;
                    m.maxHp = 1;
                }
                foreach (Minion m in this.enemyMinions)
                {
                    m.Hp = 1;
                    m.maxHp = 1;
                }

            }
            if (c.name == "divinefavor")
            {
                int enemcardsanz = this.enemyAnzCards + this.enemycarddraw;
                int diff = enemcardsanz - this.owncards.Count;
                if (diff >= 1)
                {
                    for (int i = 0; i < diff; i++)
                    {
                        //this.owncarddraw++;
                        drawACard("", true);
                    }
                }
            }

            if (c.name == "avengingwrath")
            {
                
                int damage = 1;
                int i = 0;
                List<Minion> temp = new List<Minion>(this.enemyMinions);
                int times = this.getSpellDamageDamage(8);
                while (i < times)
                {
                    if (temp.Count >= 1)
                    {
                        temp.Sort((a, b) => -a.Hp.CompareTo(b.Hp));
                        if (temp[0].Hp == 1 && this.enemyHeroHp >= 2)
                        {
                            attackOrHealHero(damage, false);
                        }
                        else
                        {
                            minionGetDamagedOrHealed(temp[0], damage, 0, false);
                        }
                    }
                    else
                    {
                        attackOrHealHero(damage, false);
                    }
                    i++;
                }

            }


            //priest ####################################################
            if (c.name == "circleofhealing")
            {
                List<Minion> temp = new List<Minion>(this.enemyMinions);
                int heal = getSpellHeal(4);
                foreach (Minion enemy in temp)
                {
                    minionGetDamagedOrHealed(enemy, 0, heal, false);
                }
                temp.Clear();
                temp.AddRange(this.ownMinions);
                foreach (Minion enemy in temp)
                {
                    minionGetDamagedOrHealed(enemy, 0, heal, true);
                }

            }
            if (c.name == "thoughtsteal")
            {
                //this.owncarddraw++;
                this.drawACard("enemycard",true);
                //this.owncarddraw++;
                this.drawACard("enemycard",true);
            }
            if (c.name == "mindvision")
            {
                if (this.enemyAnzCards+this.enemycarddraw >= 1)
                {
                    //this.owncarddraw++;
                    this.drawACard("enemycard",true);
                }
            }

            if (c.name == "shadowform")
            {
                if (this.ownHeroAblility.CardID == "CS1h_001") // lesser heal becomes mind spike
                {
                    this.ownHeroAblility = CardDB.Instance.getCardDataFromID("EX1_625t");
                    this.ownAbilityReady = true;
                }
                else
                {
                    this.ownHeroAblility = CardDB.Instance.getCardDataFromID("EX1_625t2");  // mindspike becomes mind shatter
                    this.ownAbilityReady = true;
                }
            }

            if (c.name == "mindgames")
            {
                CardDB.Card copymin = CardDB.Instance.getCardDataFromID("CS2_152"); //we draw a knappe :D (worst case)
                callKid(copymin, this.ownMinions.Count - 1, true);
            }

            if (c.name == "massdispel")
            {
                foreach (Minion m in this.enemyMinions)
                {
                    minionGetSilenced(m, false);
                }
            }
            if (c.name == "mindblast")
            {
                int damage = getSpellDamageDamage(5);
                attackOrHealHero(damage, false);
            }

            if (c.name == "holynova")
            {
                List<Minion> temp = new List<Minion>(this.ownMinions);
                int heal = getSpellHeal(2);
                int damage = getSpellDamageDamage(2);
                foreach (Minion enemy in temp)
                {
                    minionGetDamagedOrHealed(enemy, 0, heal,true,true);
                }
                attackOrHealHero(-heal, true);
                temp.Clear();
                temp.AddRange(this.enemyMinions);
                foreach (Minion enemy in temp)
                {
                    minionGetDamagedOrHealed(enemy, damage, 0, false,true);
                }
                attackOrHealHero(damage, false);

            }
            //rogue #################################################
            if (c.name == "preparation")
            {
                this.playedPreparation = true;
            }
            if (c.name == "bladeflurry")
            {
                List<Minion> temp = new List<Minion>(this.enemyMinions);
                int damage = this.getSpellDamageDamage(this.ownWeaponAttack);
                foreach (Minion enemy in temp)
                {
                    minionGetDamagedOrHealed(enemy, damage, 0, false);
                }
                attackOrHealHero(damage, false);

                //destroy own weapon
                this.lowerWeaponDurability(1000, true);
            }
            if (c.name == "headcrack")
            {
                int damage = getSpellDamageDamage(2);
                attackOrHealHero(damage, false);
                if (this.cardsPlayedThisTurn >= 1) this.owncarddraw++; // DONT DRAW A CARD WITH (drawAcard()) because we get this NEXT turn 
            }
            if (c.name == "sinisterstrike")
            {
                int damage = getSpellDamageDamage(3);
                attackOrHealHero(damage, false);
            }
            if (c.name == "deadlypoison")
            {
                if (this.ownWeaponName != "")
                {
                    this.ownWeaponAttack += 2;
                    this.ownheroAngr += 2;

                }
            }
            if (c.name == "fanofknives")
            {
                List<Minion> temp = new List<Minion>(this.enemyMinions);
                int damage = getSpellDamageDamage(1);
                foreach (Minion enemy in temp)
                {
                    minionGetDamagedOrHealed(enemy, damage, 0, false);
                }
                drawACard("", true);
            }

            if (c.name == "sprint")
            {
                for (int i = 0; i < 4; i++)
                {
                    //this.owncarddraw++;
                    drawACard("", true);
                }

            }

            if (c.name == "vanish")
            {
                List<Minion> temp = new List<Minion>(this.enemyMinions);
                int heal = getSpellHeal(4);
                foreach (Minion enemy in temp)
                {
                    minionReturnToHand(enemy, false, 0);
                }
                temp.Clear();
                temp.AddRange(this.ownMinions);
                foreach (Minion enemy in temp)
                {
                    minionReturnToHand(enemy, true, 0);
                }

            }

            //shaman #################################################
            if (c.name == "forkedlightning" && this.enemyMinions.Count >= 2)
            {
                List<Minion> temp = new List<Minion>();
                int damage = getSpellDamageDamage(2);
                List<Minion> temp2 = new List<Minion>(this.enemyMinions);
                temp2.Sort((a, b) => -a.Hp.CompareTo(b.Hp));
                temp.AddRange(Helpfunctions.TakeList(temp2, 2));
                foreach (Minion enemy in temp)
                {
                    minionGetDamagedOrHealed(enemy, damage, 0, false);
                }

            }

            if (c.name == "farsight")
            {
                //this.owncarddraw++;
                drawACard("", true);

            }

            if (c.name == "lightningstorm")
            {
                List<Minion> temp = new List<Minion>(this.enemyMinions);
                int damage = getSpellDamageDamage(2);

                int maxHp = 0;
                foreach (Minion enemy in temp)
                {
                    if (maxHp < enemy.Hp) maxHp = enemy.Hp;

                    minionGetDamagedOrHealed(enemy, damage, 0, false,true);
                }
                this.lostDamage += Math.Max(0, damage - maxHp); 

            }
            if (c.name == "feralspirit")
            {
                int posi = this.ownMinions.Count - 1;
                CardDB.Card kid = CardDB.Instance.getCardData("spiritwolf");
                callKid(kid, posi, true);
                callKid(kid, posi, true);
            }

            if (c.name == "totemicmight")
            {
                List<Minion> temp = new List<Minion>(this.ownMinions);
                foreach (Minion m in temp)
                {
                    if (m.handcard.card.race == 21) // if minion is a totem, buff it
                    {
                        minionGetBuffed(m, 0, 2, true);
                    }
                }

            }

            if (c.name == "bloodlust")
            {
                List<Minion> temp = new List<Minion>(this.ownMinions);
                foreach (Minion m in temp)
                {
                    Enchantment e = CardDB.getEnchantmentFromCardID("CS2_046e");
                    e.creator = this.ownController;
                    e.controllerOfCreator = this.ownController;
                    addEffectToMinionNoDoubles(m, e, true);
                }
            }


            //hexenmeister #################################################
            if (c.name == "sensedemons")
            {
                //this.owncarddraw += 2;
                this.drawACard("", true);
                this.drawACard("", true);


            }
            if (c.name == "twistingnether")
            {
                List<Minion> temp = new List<Minion>(this.enemyMinions);
                foreach (Minion enemy in temp)
                {
                    minionGetDestroyed(enemy, false);
                }
                temp.Clear();
                temp.AddRange(this.ownMinions);
                foreach (Minion enemy in temp)
                {
                    minionGetDestroyed(enemy, true);
                }

            }

            if (c.name == "hellfire")
            {
                List<Minion> temp = new List<Minion>(this.enemyMinions);
                int damage = getSpellDamageDamage(3);
                foreach (Minion enemy in temp)
                {
                    minionGetDamagedOrHealed(enemy, damage, 0, false);
                }
                temp.Clear();
                temp.AddRange(this.ownMinions);
                foreach (Minion enemy in temp)
                {
                    minionGetDamagedOrHealed(enemy, damage, 0, true);
                }
                attackOrHealHero(damage, true);
                attackOrHealHero(damage, false);

            }


            //druid #################################################
            if (c.name == "souloftheforest")
            {
                List<Minion> temp = new List<Minion>(this.ownMinions);
                Enchantment e = CardDB.getEnchantmentFromCardID("EX1_158e");
                e.creator = hc.entity;
                e.controllerOfCreator = this.ownController;
                foreach (Minion enemy in temp)
                {
                    addEffectToMinionNoDoubles(enemy, e, true);
                }
            }

            if (c.name == "innervate")
            {
                this.mana = Math.Min(this.mana + 2  ,10);

            }

            if (c.name == "bite")
            {
                this.ownheroAngr += 4;
                this.ownHeroDefence += 4;
                if ((this.ownHeroNumAttackThisTurn == 0 || (this.ownHeroWindfury && this.ownHeroNumAttackThisTurn == 1)) && !this.ownHeroFrozen)
                {
                    this.ownHeroReady = true;
                }

            }

            if (c.name == "claw")
            {
                this.ownheroAngr += 2;
                this.ownHeroDefence += 2;
                if ((this.ownHeroNumAttackThisTurn == 0 || (this.ownHeroWindfury && this.ownHeroNumAttackThisTurn == 1)) && !this.ownHeroFrozen)
                {
                    this.ownHeroReady = true;
                }

            }

            if (c.name == "forceofnature")
            {
                int posi = this.ownMinions.Count - 1;
                CardDB.Card kid = CardDB.Instance.getCardDataFromID("EX1_tk9");//Treant
                callKid(kid, posi, true);
                callKid(kid, posi, true);
                callKid(kid, posi, true);
            }

            if (c.name == "powerofthewild")// macht der wildnis with summoning
            {
                if (choice == 1)
                {
                    foreach (Minion m in this.ownMinions)
                    {
                        minionGetBuffed(m, 1, 1, true);
                    }
                }
                if (choice == 2)
                {
                    int posi = this.ownMinions.Count - 1;
                    CardDB.Card kid = CardDB.Instance.getCardDataFromID("EX1_160t");//panther
                    callKid(kid, posi, true);
                }
            }

            if (c.name == "starfall")
            {
                if (choice == 2)
                {
                    List<Minion> temp = new List<Minion>(this.enemyMinions);
                    int damage = getSpellDamageDamage(2);
                    foreach (Minion enemy in temp)
                    {
                        minionGetDamagedOrHealed(enemy, damage, 0, false);
                    }
                }

            }

            if (c.name == "nourish")
            {
                if (choice == 1)
                {
                    if (this.ownMaxMana == 10)
                    {
                        //this.owncarddraw++;
                        this.drawACard("excessmana",true);
                    }
                    else
                    {
                        this.ownMaxMana++;
                        this.mana++;
                    }
                    if (this.ownMaxMana == 10)
                    {
                        //this.owncarddraw++;
                        this.drawACard("excessmana",true);
                    }
                    else
                    {
                        this.ownMaxMana++;
                        this.mana++;
                    }
                }
                if (choice == 2)
                {
                    //this.owncarddraw+=3;
                    this.drawACard("", true);
                    this.drawACard("", true);
                    this.drawACard("", true);
                }
            }

            if (c.name == "savageroar")
            {
                List<Minion> temp = new List<Minion>(this.ownMinions);
                Enchantment e = CardDB.getEnchantmentFromCardID("CS2_011o");
                e.creator = hc.entity;
                e.controllerOfCreator = this.ownController;
                foreach (Minion m in temp)
                {
                    addEffectToMinionNoDoubles(m, e, true);
                }
                this.ownheroAngr += 2;
            }

            //special cards#######################

            if (c.CardID == "PRO_001a")// i am murloc
            {
                int posi = this.ownMinions.Count - 1;
                CardDB.Card kid = CardDB.Instance.getCardDataFromID("PRO_001at");//panther
                callKid(kid, posi, true);
                callKid(kid, posi, true);
                callKid(kid, posi, true);

            }

            if (c.CardID == "PRO_001c")// i am murloc
            {
                int posi = this.ownMinions.Count - 1;
                CardDB.Card kid = CardDB.Instance.getCardDataFromID("EX1_021");//scharfseher
                callKid(kid, posi, true);

            }

            if (c.name == "wildgrowth")
            {
                if (this.ownMaxMana == 10)
                {
                    //this.owncarddraw++;
                    this.drawACard("excessmana",true);
                }
                else
                {
                    this.ownMaxMana++;
                }

            }

            if (c.name == "excessmana")
            {
                //this.owncarddraw++;
                this.drawACard("", true);
            }

            if (c.name == "yseraawakens")
            {
                List<Minion> temp = new List<Minion>(this.enemyMinions);
                int damage = getSpellDamageDamage(5);
                foreach (Minion enemy in temp)
                {
                    if (enemy.name != "ysera")// dont attack ysera
                    {
                        minionGetDamagedOrHealed(enemy, damage, 0, false);
                    }
                }
                temp.Clear();
                temp.AddRange(this.ownMinions);
                foreach (Minion enemy in temp)
                {
                    if (enemy.name != "ysera")//dont attack ysera
                    {
                        minionGetDamagedOrHealed(enemy, damage, 0, false);
                    }
                }
                attackOrHealHero(damage, true);
                attackOrHealHero(damage, false);

            }

            if (c.name == "stomp")
            {
                List<Minion> temp = new List<Minion>(this.enemyMinions);
                int damage = getSpellDamageDamage(2);
                foreach (Minion enemy in temp)
                {
                    minionGetDamagedOrHealed(enemy, damage, 0, false);
                }

            }

        }

        private void drawACard(string ss, bool own)
        {
            string s = ss;
            if (s == "") s = "unknown";
            if (s == "enemycard") s = "unknown"; // NO PENALITY FOR DRAWING TO MUCH CARDS

            // cant hold more than 10 cards

            if (own)
            {
                if (s == "unknown") // draw a card from deck :D
                {
                    if (ownDeckSize == 0)
                    {
                        this.ownHeroFatigue++;
                        this.attackOrHealHero(this.ownHeroFatigue, true);
                    }
                    else
                    {
                        this.ownDeckSize--;
                        if (this.owncards.Count >= 10)
                        {
                            this.evaluatePenality += 5;
                            return;
                        }
                        this.owncarddraw++;
                    }

                }
                else 
                {
                    if (this.owncards.Count >= 10)
                    {
                        this.evaluatePenality += 5;
                        return;
                    }
                    this.owncarddraw++;

                }
                
                
            }
            else
            {
                if (s == "unknown") // draw a card from deck :D
                {
                    if (enemyDeckSize == 0)
                    {
                        this.enemyHeroFatigue++;
                        this.attackOrHealHero(this.enemyHeroFatigue, false);
                    }
                    else
                    {
                        this.enemyDeckSize--;
                        if (this.enemyAnzCards + this.enemycarddraw >= 10)
                        {
                            this.evaluatePenality += 5;
                            return;
                        }
                        this.enemycarddraw++;
                    }

                }
                else
                {
                    if (this.enemyAnzCards + this.enemycarddraw >= 10)
                    {
                        this.evaluatePenality += 5;
                        return;
                    }
                    this.enemycarddraw++;

                }
                return;
            }

            if (s == "unknown")
            {
                CardDB.Card plchldr = new CardDB.Card();
                plchldr.name = "unknown";
                Handmanager.Handcard hc = new Handmanager.Handcard();
                hc.card = plchldr;
                hc.position = this.owncards.Count + 1;
                hc.manacost = 1000;
                this.owncards.Add(hc);
            }
            else
            {
                CardDB.Card c = CardDB.Instance.getCardData(s);
                Handmanager.Handcard hc = new Handmanager.Handcard();
                hc.card = c;
                hc.position = this.owncards.Count + 1;
                hc.manacost = c.calculateManaCost(this);
                this.owncards.Add(hc);
            }

        }

        private void triggerPlayedAMinion(Handmanager.Handcard hc, bool own)
        {
            if (own) // effects only for OWN minons
            {
                List<Minion> tempo = new List<Minion>(this.ownMinions);
                foreach (Minion m in tempo)
                {
                    if (m.silenced) continue;

                    if (m.handcard.card.specialMin == CardDB.specialMinions.knifejuggler && m.entitiyID != hc.entity)
                    {
                        if (this.enemyMinions.Count >= 1)
                        {
                            List<Minion> temp = new List<Minion>();
                            int damage = 1;
                            List<Minion> temp2 = new List<Minion>(this.enemyMinions);
                            temp2.Sort((a, b) => -a.Hp.CompareTo(b.Hp));
                            temp.AddRange(Helpfunctions.TakeList(temp2, 1));
                            foreach (Minion enemy in temp)
                            {
                                minionGetDamagedOrHealed(enemy, damage, 0, false);
                            }

                        }
                        else
                        {
                            this.attackOrHealHero(1, false);
                        }
                    }

                    if (own && m.handcard.card.specialMin == CardDB.specialMinions.starvingbuzzard && (TAG_RACE)hc.card.race == TAG_RACE.PET && m.entitiyID != hc.entity)
                    {
                        //this.owncarddraw++;
                        this.drawACard("", true);
                    }

                }


            }


            //effects for ALL minons
            List<Minion> tempoo = new List<Minion>(this.ownMinions);
            foreach (Minion m in tempoo)
            {
                if (m.silenced) continue;
                if (m.handcard.card.specialMin==  CardDB.specialMinions.murloctidecaller && hc.card.race == 14 && m.entitiyID != hc.entity)
                {
                    minionGetBuffed(m, 1, 0, true);
                }
                if (m.handcard.card.specialMin == CardDB.specialMinions.oldmurkeye && hc.card.race == 14 && m.entitiyID != hc.entity)
                {
                    minionGetBuffed(m, 1, 0, true);
                }
            }
            tempoo.Clear();
            tempoo.AddRange(this.enemyMinions);
            foreach (Minion m in tempoo)
            {
                if (m.silenced) continue;
                //truebaugederalte
                if (m.handcard.card.specialMin == CardDB.specialMinions.murloctidecaller && hc.card.race == 14 && m.entitiyID != hc.entity)
                {
                    minionGetBuffed(m, 1, 0, false);
                }
                if (m.handcard.card.specialMin == CardDB.specialMinions.oldmurkeye && hc.card.race == 14 && m.entitiyID != hc.entity)
                {
                    minionGetBuffed(m, 1, 0, false);
                }
            }


        }
        private void triggerPlayedASpell(CardDB.Card c)
        {

            bool wilderpyro = false;
            List<Minion> temp = new List<Minion>(this.ownMinions);
            foreach (Minion m in temp)
            {
                if (m.silenced) continue;

                if (m.handcard.card.specialMin == CardDB.specialMinions.manawyrm)
                {
                    minionGetBuffed(m, 1, 0, true);
                }

                if (m.handcard.card.specialMin == CardDB.specialMinions.manaaddict)
                {
                    minionGetBuffed(m, 2, 0, true);
                }

                if (m.handcard.card.specialMin == CardDB.specialMinions.secretkeeper && c.Secret)
                {
                    minionGetBuffed(m, 1, 1, true);
                }

                if (m.handcard.card.specialMin == CardDB.specialMinions.archmageantonidas)
                {
                    drawACard("fireball",true);
                }

                if (m.handcard.card.specialMin == CardDB.specialMinions.violetteacher)
                {

                    CardDB.Card d = CardDB.Instance.getCardData("violetapprentice");
                    callKid(d, m.id, true);
                }

                if (m.handcard.card.specialMin == CardDB.specialMinions.gadgetzanauctioneer)
                {
                    //this.owncarddraw++;
                    drawACard("",true);
                }
                if (m.handcard.card.specialMin == CardDB.specialMinions.wildpyromancer)
                {
                    wilderpyro = true;
                }
            }

            foreach (Minion m in this.enemyMinions)
            {

                if (m.handcard.card.specialMin == CardDB.specialMinions.secretkeeper && c.Secret)
                {
                    minionGetBuffed(m, 1, 1, true);
                }
            }

            if (wilderpyro)
            {
                temp.Clear();
                temp.AddRange(this.ownMinions);
                foreach (Minion m in temp)
                {
                    if (m.silenced) continue;

                    if (m.handcard.card.specialMin == CardDB.specialMinions.wildpyromancer)
                    {
                        List<Minion> temp2 = new List<Minion>(this.ownMinions);
                        foreach (Minion mnn in temp2)
                        {
                            minionGetDamagedOrHealed(mnn, 1, 0, true);
                        }
                        temp2.Clear();
                        temp2.AddRange(this.enemyMinions);
                        foreach (Minion mnn in temp2)
                        {
                            minionGetDamagedOrHealed(mnn, 1, 0, false);
                        }
                    }
                }
            }

        }

        public void removeCard(Handmanager.Handcard hcc)
        {

            this.owncards.RemoveAll(x => x.entity == hcc.entity);
            int i = 1;
            foreach (Handmanager.Handcard hc in this.owncards)
            {
                hc.position = i;
                i++;
            }

        }

        public void playCard(Handmanager.Handcard hc, int cardpos, int cardEntity, int target, int targetEntity, int choice, int placepos, int penality)
        {
            CardDB.Card c = hc.card;
            this.evaluatePenality += penality;
            // lock at frostnova (click) / frostblitz (no click)
            this.mana = this.mana - hc.getManaCost(this);

            removeCard(hc);// remove card

            if (c.Secret)
            {
                this.ownSecretsIDList.Add(c.CardID);
                this.playedmagierinderkirintor = false;
            }
            if (c.type == CardDB.cardtype.SPELL) this.playedPreparation = false;

            //Helpfunctions.Instance.logg("play crd " + c.name + " entitiy# " + cardEntity + " mana " + hc.getManaCost(this) + " trgt " + target);
            if (logging) Helpfunctions.Instance.logg("play crd " + c.name + " entitiy# " + cardEntity + " mana " + hc.getManaCost(this) + " trgt " + target);

            if (c.type == CardDB.cardtype.MOB)
            {
                Action b = this.placeAmobSomewhere(hc, cardpos, target, choice,placepos);
                b.handcard = new Handmanager.Handcard(hc);
                b.druidchoice = choice;
                b.owntarget = placepos;
                b.enemyEntitiy = targetEntity;
                b.cardEntitiy = cardEntity;
                this.playactions.Add(b);
                this.mobsplayedThisTurn++;
                if (c.name == "kirintormage") this.playedmagierinderkirintor = true;

            }
            else
            {
                Action a = new Action();
                a.cardplay = true;
                a.handcard = new Handmanager.Handcard(hc);
                a.cardEntitiy = cardEntity;
                a.numEnemysBeforePlayed = this.enemyMinions.Count;
                a.comboBeforePlayed = (this.cardsPlayedThisTurn >= 1) ? true : false;
                a.owntarget = 0;
                if (target >= 0)
                {
                    a.owntarget = -1;
                }
                a.enemytarget = target;
                a.enemyEntitiy = targetEntity;
                a.druidchoice = choice;

                if (target == -1)
                {
                    //card with no target
                    if (c.type == CardDB.cardtype.WEAPON)
                    {
                        equipWeapon(c);
                    }
                    playCardWithoutTarget(hc, choice);
                }
                else //before : if(target >=0 && target < 20)
                {
                    if (c.type == CardDB.cardtype.WEAPON)
                    {
                        equipWeapon(c);
                    }
                    playCardWithTarget(hc, target, choice);
                }

                this.playactions.Add(a);

                if (c.type == CardDB.cardtype.SPELL)
                {
                    this.triggerPlayedASpell(c);
                }
            }

            triggerACardGetPlayed(c);

            this.ueberladung += c.recallValue;

            this.cardsPlayedThisTurn++;

        }

        private void triggerACardGetPlayed(CardDB.Card c)
        {
            List<Minion> temp = new List<Minion>(this.ownMinions);
            foreach (Minion mnn in temp)
            {
                if (mnn.silenced) continue;
                if (mnn.handcard.card.specialMin == CardDB.specialMinions.illidanstormrage)
                {
                    CardDB.Card d = CardDB.Instance.getCardData("flameofazzinoth");
                    callKid(d, mnn.id, true);
                }
                if (mnn.handcard.card.specialMin == CardDB.specialMinions.questingadventurer)
                {
                    minionGetBuffed(mnn, 1, 1, true);
                }
                if (mnn.handcard.card.specialMin == CardDB.specialMinions.unboundelemental && c.recallValue >= 1)
                {
                    minionGetBuffed(mnn, 1, 1, true);
                }
            }
        }

        public void attackWithWeapon(int target, int targetEntity, int penality)
        {
            //this.ownHeroAttackedInRound = true;
            this.ownHeroNumAttackThisTurn++;
            if ((this.ownHeroWindfury && this.ownHeroNumAttackThisTurn == 2) || (!this.ownHeroWindfury && this.ownHeroNumAttackThisTurn == 1))
            {
                this.ownHeroReady = false;
            }
            Action a = new Action();
            a.heroattack = true;
            a.enemytarget = target;
            a.enemyEntitiy = targetEntity;
            a.owntarget = 100;
            a.ownEntitiy = this.ownHeroEntity;
            a.numEnemysBeforePlayed = this.enemyMinions.Count;
            a.comboBeforePlayed = (this.cardsPlayedThisTurn >= 1) ? true : false;
            this.playactions.Add(a);

            if (this.ownWeaponName == "truesilverchampion")
            {
                this.attackOrHealHero(-2, true);
            }

            if (logging) Helpfunctions.Instance.logg("attck with weapon " + a.owntarget + " " + a.ownEntitiy + " trgt: " + a.enemytarget + " " + a.enemyEntitiy);

            if (target == 200)
            {
                attackOrHealHero(this.ownheroAngr, false);
            }
            else
            {

                Minion enemy = this.enemyMinions[target - 10];
                minionGetDamagedOrHealed(enemy, this.ownheroAngr, 0, false);

                if (!this.heroImmuneWhileAttacking)
                {
                    attackOrHealHero(enemy.Angr, true);
                    if (!enemy.silenced && enemy.handcard.card.specialMin ==  CardDB.specialMinions.waterelemental)
                    {
                        this.ownHeroFrozen = true;
                    }
                }
            }

            //todo
            if (ownWeaponName == "gorehowl" && target != 200)
            {
                this.ownWeaponAttack--;
                this.ownheroAngr--;
            }
            else
            {
                this.lowerWeaponDurability(1, true);
            }

        }

        public void ENEMYattackWithWeapon(int target, int targetEntity, int penality)
        {
            //this.ownHeroAttackedInRound = true;
            this.enemyHeroNumAttackThisTurn++;
            if ((this.enemyHeroWindfury && this.enemyHeroNumAttackThisTurn == 2) || (!this.enemyHeroWindfury && this.enemyHeroNumAttackThisTurn == 1))
            {
                this.enemyHeroReady = false;
            }

            if (this.enemyWeaponName == "truesilverchampion")
            {
                this.attackOrHealHero(-2,false);
            }

            if (logging) Helpfunctions.Instance.logg("enemy attck with weapon trgt: " + target + " " + targetEntity);

            if (target == 100)
            {
                attackOrHealHero(this.enemyheroAngr,true);
            }
            else
            {

                Minion enemy = this.ownMinions[target];
                minionGetDamagedOrHealed(enemy, this.enemyheroAngr, 0,true);

                if (!this.enemyheroImmuneWhileAttacking)
                {
                    attackOrHealHero(enemy.Angr, false);
                    if (!enemy.silenced && enemy.handcard.card.specialMin == CardDB.specialMinions.waterelemental)
                    {
                        this.enemyHeroFrozen = true;
                    }
                }
            }

            //todo
            if (enemyWeaponName == "gorehowl" && target != 100)
            {
                this.enemyWeaponAttack--;
                this.enemyheroAngr--;
            }
            else
            {
                this.lowerWeaponDurability(1, false);
            }

        }

        public void activateAbility(CardDB.Card c, int target, int targetEntity, int penality)
        {
            this.evaluatePenality += penality;
            HeroEnum heroname = this.ownHeroName;
            this.ownAbilityReady = false;
            this.mana -= 2;
            Action a = new Action();
            a.useability = true;
            a.handcard = new Handmanager.Handcard(c);
            a.enemytarget = target;
            a.enemyEntitiy = targetEntity;
            a.numEnemysBeforePlayed = this.enemyMinions.Count;
            a.comboBeforePlayed = (this.cardsPlayedThisTurn >= 1) ? true : false;
            this.playactions.Add(a);
            if (logging) Helpfunctions.Instance.logg("play ability on target " + target);

            if (heroname == HeroEnum.mage)
            {
                int damage = 1;
                if (target == 100)
                {
                    attackOrHealHero(damage, true);
                }
                else
                {
                    if (target == 200)
                    {
                        attackOrHealHero(damage, false);
                    }
                    else
                    {
                        if (target < 10)
                        {
                            Minion m = this.ownMinions[target];
                            this.minionGetDamagedOrHealed(m, damage, 0, true);
                        }

                        if (target >= 10 && target < 20)
                        {
                            Minion m = this.enemyMinions[target - 10];
                            this.minionGetDamagedOrHealed(m, damage, 0, false);
                        }
                    }
                }

            }

            if (heroname == HeroEnum.priest)
            {
                int heal = 2;
                if (this.auchenaiseelenpriesterin) heal = -2;

                if (c.name == "mindspike")
                {
                    heal = -1 * 2;
                }
                if (c.name == "mindshatter")
                {
                    heal = -1 * 3;
                }

                if (target == 100)
                {
                    attackOrHealHero(-1 * heal, true);
                }
                else
                {
                    if (target == 200)
                    {
                        attackOrHealHero(-1 * heal, false);
                    }
                    else
                    {
                        if (target < 10)
                        {
                            Minion m = this.ownMinions[target];
                            this.minionGetDamagedOrHealed(m, 0, heal, true);
                        }

                        if (target >= 10 && target < 20)
                        {
                            Minion m = this.enemyMinions[target - 10];
                            this.minionGetDamagedOrHealed(m, 0, heal, false);
                        }
                    }
                }

            }

            if (heroname == HeroEnum.warrior)
            {
                this.ownHeroDefence += 2;
            }

            if (heroname == HeroEnum.warlock)
            {
                //this.owncarddraw++;
                this.drawACard("", true);
                this.attackOrHealHero(2, true);
            }


            if (heroname == HeroEnum.thief)
            {

                CardDB.Card wcard = CardDB.Instance.getCardData("wickedknife");
                this.equipWeapon(wcard);
            }

            if (heroname == HeroEnum.druid)
            {
                this.ownheroAngr += 1;
                if ((this.ownHeroNumAttackThisTurn == 0 || (this.ownHeroWindfury && this.ownHeroNumAttackThisTurn == 1)) && !this.ownHeroFrozen) 
                {
                    this.ownHeroReady = true;
                }
                this.ownHeroDefence += 1;
            }


            if (heroname == HeroEnum.hunter)
            {
                this.attackOrHealHero(2, false);
            }

            if (heroname == HeroEnum.pala)
            {
                int posi = this.ownMinions.Count - 1;
                CardDB.Card kid = CardDB.Instance.getCardData("silverhandrecruit");
                callKid(kid, posi, true);
            }

            if (heroname == HeroEnum.shaman)
            {
                int posi = this.ownMinions.Count - 1;
                CardDB.Card kid = CardDB.Instance.getCardData("healingtotem");
                callKid(kid, posi, true);
            }

            if (heroname == HeroEnum.lordjaraxxus)
            {
                int posi = this.ownMinions.Count - 1;
                CardDB.Card kid = CardDB.Instance.getCardData("infernal");
                callKid(kid, posi, true);
            }


        }

        public void ENEMYactivateAbility(CardDB.Card c, int target, int targetEntity)
        {
            HeroEnum heroname = this.enemyHeroName;
            this.enemyAbilityReady = false;
            if (logging) Helpfunctions.Instance.logg("enemy play ability on target " + target);

            if (heroname == HeroEnum.mage)
            {
                int damage = 1;
                if (target == 100)
                {
                    attackOrHealHero(damage, true);
                }
                else
                {
                    if (target == 200)
                    {
                        attackOrHealHero(damage, false);
                    }
                    else
                    {
                        if (target < 10)
                        {
                            Minion m = this.ownMinions[target];
                            this.minionGetDamagedOrHealed(m, damage, 0, true);
                        }

                        if (target >= 10 && target < 20)
                        {
                            Minion m = this.enemyMinions[target - 10];
                            this.minionGetDamagedOrHealed(m, damage, 0, false);
                        }
                    }
                }

            }

            if (heroname == HeroEnum.priest)
            {
                int heal = 2;
                if (this.auchenaiseelenpriesterin) heal = -2;

                if (c.name == "mindspike")
                {
                    heal = -1 * 2;
                }
                if (c.name == "mindshatter")
                {
                    heal = -1 * 3;
                }
                
                if (target == 100)
                {
                    if (heal >= 1) return;
                    attackOrHealHero(-1 * heal, true);
                }
                else
                {
                    if (target == 200)
                    {
                        if (heal >= 1)
                        {
                            bool haslightwarden = false;
                            foreach (Minion mnn in this.enemyMinions)
                            {
                                if (mnn.handcard.card.specialMin == CardDB.specialMinions.lightwarden)
                                {
                                    haslightwarden = true;
                                    break;
                                }
                            }
                            if (!haslightwarden) return;
                        }
                        attackOrHealHero(-1 * heal, false);
                    }
                    else
                    {
                        if (target < 10)
                        {
                            Minion m = this.ownMinions[target];
                            this.minionGetDamagedOrHealed(m, 0, heal, true);
                        }

                        if (target >= 10 && target < 20)
                        {
                            Minion m = this.enemyMinions[target - 10];
                            this.minionGetDamagedOrHealed(m, 0, heal, false);
                        }
                    }
                }

            }

            if (heroname == HeroEnum.warrior)
            {
                this.enemyHeroDefence += 2;
            }

            if (heroname == HeroEnum.warlock)
            {
                //this.owncarddraw++;
                this.drawACard("", false);
                this.attackOrHealHero(2, false);
            }


            if (heroname == HeroEnum.thief)
            {

                CardDB.Card wcard = CardDB.Instance.getCardData("wickedknife");
                this.enemyheroAngr = wcard.Attack;
                this.enemyWeaponAttack = wcard.Attack;
                this.enemyWeaponDurability = wcard.Durability;
                this.enemyHeroWindfury = false;
                if ((this.enemyHeroNumAttackThisTurn == 0 || (this.enemyHeroWindfury && this.enemyHeroNumAttackThisTurn == 1)) && !this.enemyHeroFrozen)
                {
                    this.enemyHeroReady = true;
                }
            }

            if (heroname == HeroEnum.druid)
            {
                this.enemyheroAngr += 1;
                if ((this.enemyHeroNumAttackThisTurn == 0 || (this.enemyHeroWindfury && this.enemyHeroNumAttackThisTurn == 1)) && !this.enemyHeroFrozen)
                {
                    this.enemyHeroReady = true;
                }
                this.enemyHeroDefence += 1;
            }


            if (heroname == HeroEnum.hunter)
            {
                this.attackOrHealHero(2, true);
            }

            if (heroname == HeroEnum.pala)
            {
                int posi = this.enemyMinions.Count - 1;
                CardDB.Card kid = CardDB.Instance.getCardData("silverhandrecruit");
                callKid(kid, posi, false);
            }

            if (heroname == HeroEnum.shaman)
            {
                int posi = this.enemyMinions.Count - 1;
                CardDB.Card kid = CardDB.Instance.getCardData("healingtotem");
                callKid(kid, posi, false);
            }

            if (heroname == HeroEnum.lordjaraxxus)
            {
                int posi = this.enemyMinions.Count - 1;
                CardDB.Card kid = CardDB.Instance.getCardData("infernal");
                callKid(kid, posi, false);
            }


        }

        public void doAction()
        {
            /*if (this.playactions.Count >= 1)
            {
                Action a = this.playactions[0];

                if (a.cardplay)
                {
                    if (logging) help.logg("play " + a.handcard.card.name);
                    if (logging) help.logg("with position " + a.cardplace.X + "," + a.cardplace.Y);
                    help.clicklauf(a.cardplace.X, a.cardplace.Y);
                    if (a.owntarget >= 0)
                    {
                        if (logging) help.logg("on position " + a.ownplace.X + "," + a.ownplace.Y);
                        help.clicklauf(a.ownplace.X, a.ownplace.Y);
                    }
                    if (a.enemytarget >= 0)
                    {
                        if (logging) help.logg("and target to " + a.enemytarget + ": on " + a.targetplace.X + ", " + a.targetplace.Y);
                        help.clicklauf(a.targetplace.X, a.targetplace.Y);
                    }
                }
                if (a.minionplay)
                {
                    if (logging) help.logg("attacker: " + a.owntarget + " enemy: " + a.enemytarget);
                    help.clicklauf(a.ownplace.X, a.ownplace.Y);
                    System.Threading.Thread.Sleep(500);
                    if (logging) help.logg("targetplace " + a.targetplace.X + ", " + a.targetplace.Y);
                    help.clicklauf(a.targetplace.X, a.targetplace.Y);
                }
                if (a.heroattack)
                {
                    if (logging) help.logg("attack with hero, enemy: " + a.enemytarget);
                    help.clicklauf(a.ownplace.X, a.ownplace.Y);
                    if (logging) help.logg("targetplace " + a.targetplace.X + ", " + a.targetplace.Y);
                    help.clicklauf(a.targetplace.X, a.targetplace.Y);
                }
                if (a.useability)
                {
                    if (logging) help.logg("useability ");
                    help.clicklauf(a.ownplace.X, a.ownplace.Y);
                    if (a.enemytarget >= 0)
                    {
                        if (logging) help.logg("on enemy: " + a.enemytarget + "targetplace " + a.targetplace.X + ", " + a.targetplace.Y);
                        help.clicklauf(a.targetplace.X, a.targetplace.Y);
                    }
                }

            }
            else
            {
                // click endturnbutton
                help.clicklauf(939, 353);
            }
            help.laufmaus(915, 400, 6);
             */
        }


        private void debugMinions()
        {
            Helpfunctions.Instance.logg("OWN MINIONS################");

            foreach (Minion m in this.ownMinions)
            {
                Helpfunctions.Instance.logg("name,ang, hp, maxhp: " + m.name + ", " + m.Angr + ", " + m.Hp + ", " + m.maxHp);
                foreach (Enchantment e in m.enchantments)
                {
                    Helpfunctions.Instance.logg("enchment: " + e.CARDID + " " + e.creator + " " + e.controllerOfCreator);
                }
            }

            Helpfunctions.Instance.logg("ENEMY MINIONS############");
            foreach (Minion m in this.enemyMinions)
            {
                Helpfunctions.Instance.logg("name,ang, hp: " + m.name + ", " + m.Angr + ", " + m.Hp);
            }
        }

        public void printBoard()
        {
            Helpfunctions.Instance.logg("board: " + value);
            Helpfunctions.Instance.logg("cardsplayed: " + this.cardsPlayedThisTurn + " handsize: " + this.owncards.Count);
            Helpfunctions.Instance.logg("ownhero: ");
            Helpfunctions.Instance.logg("ownherohp: " + this.ownHeroHp + " + " + this.ownHeroDefence);
            Helpfunctions.Instance.logg("ownheroattac: " + this.ownheroAngr);
            Helpfunctions.Instance.logg("ownheroweapon: " + this.ownWeaponAttack + " " + this.ownWeaponDurability + " " + this.ownWeaponName);
            Helpfunctions.Instance.logg("ownherostatus: frozen" + this.ownHeroFrozen + " ");
            Helpfunctions.Instance.logg("enemyherohp: " + this.enemyHeroHp + " + " + this.enemyHeroDefence);
            Helpfunctions.Instance.logg("OWN MINIONS################");

            foreach (Minion m in this.ownMinions)
            {
                Helpfunctions.Instance.logg("name,ang, hp: " + m.name + ", " + m.Angr + ", " + m.Hp);
                foreach (Enchantment e in m.enchantments)
                {
                    Helpfunctions.Instance.logg("enchment " + e.CARDID + " " + e.creator + " " + e.controllerOfCreator);
                }
            }

            Helpfunctions.Instance.logg("ENEMY MINIONS############");
            foreach (Minion m in this.enemyMinions)
            {
                Helpfunctions.Instance.logg("name,ang, hp: " + m.name + ", " + m.Angr + ", " + m.Hp);
            }


            Helpfunctions.Instance.logg("");
        }

        public Action getNextAction()
        {
            if (this.playactions.Count >= 1) return this.playactions[0];
            return null;
        }

        public void printActions()
        {
            foreach (Action a in this.playactions)
            {
                if (a.cardplay)
                {
                    Helpfunctions.Instance.logg("play " + a.handcard.card.name);
                    if (a.druidchoice >= 1) Helpfunctions.Instance.logg("choose choise " + a.druidchoice);
                    Helpfunctions.Instance.logg("with entity " + a.cardEntitiy);
                    if (a.owntarget >= 0)
                    {
                        Helpfunctions.Instance.logg("on position " + a.owntarget);
                    }
                    if (a.enemytarget >= 0)
                    {
                        Helpfunctions.Instance.logg("and target to " + a.enemytarget + " " + a.enemyEntitiy);
                    }
                }
                if (a.minionplay)
                {
                    Helpfunctions.Instance.logg("attacker: " + a.owntarget + " enemy: " + a.enemytarget);
                    Helpfunctions.Instance.logg("targetplace " + a.enemyEntitiy);
                }
                if (a.heroattack)
                {
                    Helpfunctions.Instance.logg("attack with hero, enemy: " + a.enemytarget);
                    Helpfunctions.Instance.logg("targetplace " + a.enemyEntitiy);
                }
                if (a.useability)
                {
                    Helpfunctions.Instance.logg("useability ");
                    if (a.enemytarget >= 0)
                    {
                        Helpfunctions.Instance.logg("on enemy: " + a.enemytarget + "targetplace " + a.enemyEntitiy);
                    }
                }
                Helpfunctions.Instance.logg("");
            }
        }

    }

}
