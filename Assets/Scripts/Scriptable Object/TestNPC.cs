using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;
using static Scriptable_NPC;

public class TestNPC : MonoBehaviour
{
    public Scriptable_NPC npcData;

    NPC testNPC;

    void Start()
    {
        testNPC = new NPC("Test")
        {
            npcName = npcData.npcName,
            maxHealth = npcData.maxHealth,
            currentHealth = npcData.curentHealth,
            temporaryHealth = npcData.temporaryHealth,
            experience = npcData.experience,
            level = npcData.level,
            race = npcData.race,
            defensive = npcData.defensive,
            speed = npcData.speed,
            skills = npcData.skills,
            spells = npcData.spells,
            equipment = npcData.equipment,
            consumables = npcData.consumables,
            strength = npcData.strength,
            agility = npcData.agility,
            healthStat = npcData.healthStat,
            intelligence = npcData.intelligence,
            wisdom = npcData.wisdom,
            charisma = npcData.charisma,
            strengthResist = npcData.strengthResist,
            agilityResist = npcData.agilityResist,
            healthStatResist = npcData.healthStatResist,
            intelligenceResist = npcData.intelligenceResist,
            wisdomResist = npcData.wisdomResist,
            charismaResist = npcData.charismaResist,
            skillProficiencies = npcData.skillProficiencies
        };

        InformationPrint();

    }

    void InformationPrint()
    {
        Debug.Log("Character Info:");
        Debug.Log("Name: " + testNPC.npcName);
        Debug.Log("Max Health: " + testNPC.maxHealth);
        Debug.Log("Current Health: " + testNPC.currentHealth);
        Debug.Log("Temporary Health: " + testNPC.temporaryHealth);
        Debug.Log("Experience: " + testNPC.experience);
        Debug.Log("Level: " + testNPC.level);
        Debug.Log("Race: " + testNPC.race);
        Debug.Log("Defensive: " + testNPC.defensive);
        Debug.Log("Speed: " + testNPC.speed);

        Debug.Log("Skills:");
        foreach (var skill in testNPC.skills)
        {
            Debug.Log(skill);
        }

        Debug.Log("Spells:");
        foreach (var spell in testNPC.spells)
        {
            Debug.Log(spell);
        }

        Debug.Log("Equipment:");
        foreach (var equip in testNPC.equipment)
        {
            Debug.Log(equip);
        }

        Debug.Log("Consumables:");
        foreach (var consumable in testNPC.consumables)
        {
            Debug.Log(consumable);
        }

        Debug.Log("Stats:");
        Debug.Log("Strength: " + testNPC.strength);
        Debug.Log("Agility: " + testNPC.agility);
        Debug.Log("Health Stat: " + testNPC.healthStat);
        Debug.Log("Intelligence: " + testNPC.intelligence);
        Debug.Log("Wisdom: " + testNPC.wisdom);
        Debug.Log("Charisma: " + testNPC.charisma);

        Debug.Log("Resistances:");
        Debug.Log("Strength Resist: " + testNPC.strengthResist);
        Debug.Log("Agility Resist: " + testNPC.agilityResist);
        Debug.Log("Health Stat Resist: " + testNPC.healthStatResist);
        Debug.Log("Intelligence Resist: " + testNPC.intelligenceResist);
        Debug.Log("Wisdom Resist: " + testNPC.wisdomResist);
        Debug.Log("Charisma Resist: " + testNPC.charismaResist);

        Debug.Log("Skill Proficiencies:");
        foreach (var proficiency in testNPC.skillProficiencies)
        {
            Debug.Log(proficiency);
        }
    }
}
