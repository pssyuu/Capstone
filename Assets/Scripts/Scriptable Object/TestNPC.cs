using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestNPC : MonoBehaviour
{
    public Scriptable_NPC npcData;

    private NPC character;

    void Start()
    {
        character = new NPC(
            npcData.npcName,
            npcData.level,
            npcData.health,
            npcData.damage,
            npcData.defense,
            (NPC.PersonalityType)npcData.personality,
            (NPC.OccupationType)npcData.occupation,
            (NPC.RaceType)npcData.race,
            (NPC.ReactionType)npcData.reaction,
            npcData.aggressiveProbability,
            npcData.friendlyProbability,
            npcData.neutralProbability
        );


        Debug.Log("Name: " + character.npcName);
        Debug.Log("Level: " + character.level);
        Debug.Log("Health: " + character.health);
        Debug.Log("Damage: " + character.damage);
        Debug.Log("Defense: " + character.defense);
        Debug.Log("Personality: " + character.personality);
        Debug.Log("Occupation: " + character.occupation);
        Debug.Log("Race: " + character.race);
        Debug.Log("Reaction: " + character.reaction);
        Debug.Log("Aggressive Probability: " + character.aggressiveProbability);
        Debug.Log("Friendly Probability: " + character.friendlyProbability);
        Debug.Log("Neutral Probability: " + character.neutralProbability);
    }
}
