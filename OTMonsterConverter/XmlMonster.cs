﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace OTMonsterConverter
{
    //https://github.com/otland/forgottenserver/blob/master/src/monsters.cpp

    public enum namedImmunity
    {
        physical,
        energy,
        fire,
        poison,
        earth = namedImmunity.poison,
        drown,
        ice,
        holy,
        death,
        lifedrain,
        manadrain,
        paralyze,
        outfit,
        drunk,
        invisible,
        invisibility = namedImmunity.invisible,
        bleed,
        NA
    }

    enum skullsXml
    {
        none = 0,
        yellow,
        green,
        white,
        red,
        black,
        orange
    }

    [Serializable, XmlRoot("monster")]
    public class Monster
    {
        [XmlAttribute]
        public string name;
        [XmlAttribute]
        public string nameDescription;
        [XmlAttribute]
        public string race; //todo: this could be number or string
        [XmlAttribute]
        public int experience;
        [XmlAttribute]
        public int speed;
        [XmlAttribute]
        public int manacost;
        [XmlAttribute]
        public string skull; //uses strings, "none", "yellow", "green", "white", "red", "black", "orange"
        //[XmlAttribute]
        //public int script; //todo: how to handle, yes its an attribute
        //public int script; //todo: how to handle, yes its also an element

        public Health health;
        public Flags flags;
        public Look look;
        public TargetChange targetchange;
        //public Attacks attacks;
        //public Defenses defenses;
        public Immunities immunities;
        public Voices voices;
        public Loot loot;
        public Elements elements;
        public Summons summons;
    }

    public class Health
    {
        [XmlAttribute]
        public int now;
        [XmlAttribute]
        public int max;
    }


    [XmlRoot(ElementName = "flags")]
    public class Flags
    {
        [XmlElementAttribute]
        public Flag[] flag;
    }

    public class Flag
    {
        [XmlAttribute]
        public int summonable = -99;
        [XmlAttribute]
        public int attackable = -99;
        [XmlAttribute]
        public int hostile = -99;
        [XmlAttribute]
        public int illusionable = -99;
        [XmlAttribute]
        public int convinceable = -99;
        [XmlAttribute]
        public int pushable = -99;
        [XmlAttribute]
        public int canpushitems = -99;
        [XmlAttribute]
        public int canpushcreatures = -99;
        [XmlAttribute]
        public int targetdistance = -99;
        [XmlAttribute]
        public int staticattack = -99;
        [XmlAttribute]
        public int lightlevel = -99;
        [XmlAttribute]
        public int lightcolor = -99;
        [XmlAttribute]
        public int runonhealth = -99;
        [XmlAttribute]
        public int hidehealth = -99;
    }

    public class TargetChange
    {
        [XmlAttribute]
        public int interval; //could be named "speed" or "interval"
        [XmlAttribute]
        public int chance;
    }

    public class Look
    {
        [XmlAttribute]
        public int type;
        [XmlAttribute]
        public int head; //only can exist if type exists
        [XmlAttribute]
        public int body; //only can exist if type exists
        [XmlAttribute]
        public int legs; //only can exist if type exists
        [XmlAttribute]
        public int feet; //only can exist if type exists
        [XmlAttribute]
        public int addons; //only can exist if type exists
        [XmlAttribute]
        public int typeex;
        [XmlAttribute]
        public int mount;
        [XmlAttribute]
        public int corpse;
    }

    public class Attacks
    {
        //public attack[] Attack
    }

    public class Defenses
    {
        [XmlAttribute]
        public int defense;
        [XmlAttribute]
        public int armor;

        //public defense[] defense
    }

    public class Immunities
    {
        [XmlElementAttribute]
        public Immunity[] immunity;
    }

    public class Immunity
    {
        [XmlAttribute]
        public namedImmunity name = namedImmunity.NA;
        [XmlAttribute]
        public int physical = -9999;
        [XmlAttribute]
        public int energy = -9999;
        [XmlAttribute]
        public int fire = -9999;
        [XmlAttribute]
        public int poison = -9999; //poison and earth are the same
        [XmlAttribute]
        public int earth = -9999; //poison and earth are the same
        [XmlAttribute]
        public int drown = -9999;
        [XmlAttribute]
        public int ice = -9999;
        [XmlAttribute]
        public int holy = -9999;
        [XmlAttribute]
        public int death = -9999;
        [XmlAttribute]
        public int lifedrain = -9999;
        [XmlAttribute]
        public int manadrain = -9999;
        [XmlAttribute]
        public int paralyze = -9999;
        [XmlAttribute]
        public int outfit = -9999;
        [XmlAttribute]
        public int bleed = -9999;
        [XmlAttribute]
        public int drunk = -9999;
        [XmlAttribute]
        public int invisible = -9999; //invisible and invisibility are the same
        [XmlAttribute]
        public int invisibility = -9999; //invisible and invisibility are the same
    }

    public class Voices
    {
        [XmlAttribute]
        public int interval; //interval and speed are the same
        [XmlAttribute]
        public int speed; //interval and speed are the same
        [XmlAttribute]
        public int chance;
        [XmlElementAttribute]
        public Voice[] voice;
    }

    public class Voice
    {
        [XmlAttribute]
        public string sentence;
        [XmlAttribute]
        public string yell; //can be 1 or true? //if it doesnt exist the value is false
    }

    public class Loot
    {
        public Item[] item;
    }

    public class Item
    {
        [XmlAttribute]
        public string id;
        [XmlAttribute]
        public int countmax = 1; //default value is 1
        [XmlAttribute]
        public int chance; //chance and chance1 are the same
        [XmlAttribute]
        public int chance1; //chance and chance1 are the same

        //optional
        [XmlAttribute]
        public int subtype; //used for charges?
        [XmlAttribute]
        public int actionId;
        [XmlAttribute]
        public string test; //used for? //Id guess to override the fault item name string?
    }

    public class Elements
    {
        [XmlElementAttribute]
        public Element[] element;
    }

    public class Element
    {
        [XmlAttribute]
        public int physicalPercent = -9999;
        [XmlAttribute]
        public int icePercent = -9999;
        [XmlAttribute]
        public int poisonPercent = -9999; //poisonPercent and earthPercent are the same
        [XmlAttribute]
        public int earthPercent = -9999; //poisonPercent and earthPercent are the same
        [XmlAttribute]
        public int firePercent = -9999;
        [XmlAttribute]
        public int energyPercent = -9999;
        [XmlAttribute]
        public int holyPercent = -9999;
        [XmlAttribute]
        public int deathPercent = -9999;
        [XmlAttribute]
        public int drownPercent = -9999;
        [XmlAttribute]
        public int lifedrainPercent = -9999;
        [XmlAttribute]
        public int manadrainPercent = -9999;
    }

    public class Summons
    {
        [XmlAttribute]
        public int maxSummons;
        public Summon[] summon;
    }

    public class Summon
    {
        [XmlAttribute]
        public string name;
        [XmlAttribute]
        public int interval = 1000; //interval and speed are the same //defaults to 1000 if missing
        [XmlAttribute]
        public int speed = 1000; //interval and speed are the same //defaults to 1000 if missing
        [XmlAttribute]
        public int chance; //defaults to 100 if missing
    }
}