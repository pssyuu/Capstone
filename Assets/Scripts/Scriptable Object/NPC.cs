using System.Collections.Generic;
using UnityEngine;
using static Scriptable_NPC;

public abstract class NPC : MonoBehaviour
{
    public string npcName { get; set; }
    public int maxHealth { get; set; }
    public int currentHealth { get; set; }
    public int temporaryHealth { get; set; }
    public int experience { get; set; }
    public int level { get; set; }
    public RaceType race { get; set; }
    public Personalitytype personalitytype { get; set; }
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

    public abstract void ResetCharactor();

    public void InformationPrint()
    {
        Debug.Log("Character Info:");
        Debug.Log("Name: " + this.npcName);
        Debug.Log("Max Health: " + this.maxHealth);
        Debug.Log("Current Health: " + this.currentHealth);
        Debug.Log("Temporary Health: " + this.temporaryHealth);
        Debug.Log("Experience: " + this.experience);
        Debug.Log("Level: " + this.level);
        Debug.Log("Race: " + this.race);
        Debug.Log("Defensive: " + this.defensive);
        Debug.Log("Speed: " + this.speed);

        Debug.Log("Skills:");
        foreach (var skill in this.skills)
        {
            Debug.Log(skill);
        }

        Debug.Log("Spells:");
        foreach (var spell in this.spells)
        {
            Debug.Log(spell);
        }

        Debug.Log("Equipment:");
        foreach (var equip in this.equipment)
        {
            Debug.Log(equip);
        }

        Debug.Log("Consumables:");
        foreach (var consumable in this.consumables)
        {
            Debug.Log(consumable);
        }

        Debug.Log("Stats:");
        Debug.Log("Strength: " + this.strength);
        Debug.Log("Agility: " + this.agility);
        Debug.Log("Health Stat: " + this.healthStat);
        Debug.Log("Intelligence: " + this.intelligence);
        Debug.Log("Wisdom: " + this.wisdom);
        Debug.Log("Charisma: " + this.charisma);

        Debug.Log("Resistances:");
        Debug.Log("Strength Resist: " + this.strengthResist);
        Debug.Log("Agility Resist: " + this.agilityResist);
        Debug.Log("Health Stat Resist: " + this.healthStatResist);
        Debug.Log("Intelligence Resist: " + this.intelligenceResist);
        Debug.Log("Wisdom Resist: " + this.wisdomResist);
        Debug.Log("Charisma Resist: " + this.charismaResist);

        Debug.Log("Skill Proficiencies:");
        foreach (var proficiency in this.skillProficiencies)
        {
            Debug.Log(proficiency);
        }
    }
}
