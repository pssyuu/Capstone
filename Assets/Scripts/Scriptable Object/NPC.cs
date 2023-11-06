using System.Collections.Generic;
using static Scriptable_NPC;

public class NPC
{
    public string npcName { get; set; }
    public int maxHealth { get; set; }
    public int currentHealth { get; set; }
    public int temporaryHealth { get; set; }
    public int experience { get; set; }
    public int level { get; set; }
    public RaceType race { get; set; }
    public int defensive { get; set; }
    public int speed { get; set; }

    public List<string> skills { get; set; }
    public List<string> spells { get; set; }
    public List<string> equipment { get; set; }
    public List<string> consumables { get; set; }

    public int strength { get; set; }
    public int agility { get; set; }
    public int healthStat { get; set; }
    public int intelligence { get; set; }
    public int wisdom { get; set; }
    public int charisma { get; set; }
    public int strengthResist { get; set; }
    public int agilityResist { get; set; }
    public int healthStatResist { get; set; }
    public int intelligenceResist { get; set; }
    public int wisdomResist { get; set; }
    public int charismaResist { get; set; }
    public List<string> skillProficiencies { get; set; }

    public NPC(string name)
    {
        npcName = name;
    }
}
