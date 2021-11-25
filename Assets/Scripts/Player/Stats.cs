using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : Attributes
{
    //Str - damage
    //Dex - agility
    //Con - health, resistance
    //Int - book smart
    //Wis - street smart (Common sense)
    //Char - literally just charisma

    [System.Serializable]
    public struct StatSheet
    {
        public string name;
        public int baseValue;
        //used for buffs/debuffs
        public int tempValue;
        //temp value for levelups
        public int lvlTempValue;
        public int raceBonus;
    }

    public StatSheet[] charStats = new StatSheet[6];
    public CharacterClass characterClass = CharacterClass.Barbarian;
    public CharacterRace characterRace = CharacterRace.Dragonborn;
}

public enum CharacterClass
{
    Barbarian,
    Bard,
    Rogue,
    Warrior,
    Paladin,
    Cleric,
    Wizard,
    Sorcerer,
    Warlock,
    Druid,
    Monk,
    Fighter,
    None
}

public enum CharacterRace
{ 
    Human,
    Dwarf,
    Elf,
    Dragonborn,
    Gnome,
    HalfElf,
    Halfling,
    Tiefling,
    HalfOrc,
    None
}
