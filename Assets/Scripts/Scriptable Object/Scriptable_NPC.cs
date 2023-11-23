using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New NPC", menuName = "Scriptable Object/NPC")]
public class Scriptable_NPC : ScriptableObject
{
    [Header("캐릭터 정보")]
    public string npcName;
    public int maxHealth;
    public int curentHealth;
    public int temporaryHealth;
    public int experience;
    public int level;
    public enum RaceType
    {
        Human,
        Elf,
        Dwarf,
        Orc,
        Goblin
    }
    public enum Personalitytype
    {
        ACTOR,
        EXPLORER,
        AGITATOR,
        POWERGAMER, 
        TAcTICIAN,
        STORYTELLER
    }
    public int defensive;
    public int speed;

    [Header("리스트")]
    public List<string> skills;
    public List<string> spells;
    public List<string> equipment;
    public List<string> consumables;

    [Header("캐릭터 스탯")]
    public int strength;
    public int agility;
    public int healthStat;
    public int intelligence;
    public int wisdom;
    public int charisma;
    public int strengthResist;
    public int agilityResist;
    public int healthStatResist;
    public int intelligenceResist;
    public int wisdomResist;
    public int charismaResist;
    public List<string> skillProficiencies;

    public RaceType race;
}
