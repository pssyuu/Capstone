using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class TestNPC : NPC
{
    public Scriptable_NPC npcData;

    NPC testNPC;

    void Start()
    {
        InformationPrint();

    }

    private void OnEnable()
    {
        ResetCharactor();
    }

    public override void ResetCharactor()
    {
        npcName = npcData.npcName;
        maxHealth = npcData.maxHealth;
        currentHealth = npcData.curentHealth;
        temporaryHealth = npcData.temporaryHealth;
        experience = npcData.experience;
        level = npcData.level;
        race = npcData.race;
        defensive = npcData.defensive;
        speed = npcData.speed;
        skills = npcData.skills;
        spells = npcData.spells;
        equipment = npcData.equipment;
        consumables = npcData.consumables;
        strength = npcData.strength;
        agility = npcData.agility;
        healthStat = npcData.healthStat;
        intelligence = npcData.intelligence;
        wisdom = npcData.wisdom;
        charisma = npcData.charisma;
        strengthResist = npcData.strengthResist;
        agilityResist = npcData.agilityResist;
        healthStatResist = npcData.healthStatResist;
        intelligenceResist = npcData.intelligenceResist;
        wisdomResist = npcData.wisdomResist;
        charismaResist = npcData.charismaResist;
        skillProficiencies = npcData.skillProficiencies;
    }


    public void StartFilcker()
    {
        StartCoroutine(FilckerChractor());
    }

    public IEnumerator FilckerChractor()
    {
        Color originColor = GetComponent<SpriteRenderer>().color;

        GetComponent<SpriteRenderer>().color = Color.red;

        yield return new WaitForSeconds(0.1f);

        GetComponent<SpriteRenderer>().color = originColor;
    }
}
