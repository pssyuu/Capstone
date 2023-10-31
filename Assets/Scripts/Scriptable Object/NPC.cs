using UnityEngine;

public class NPC : MonoBehaviour
{
    public enum PersonalityType
    {
        Aggressive,
        Friendly,
        Neutral
    }

    public enum OccupationType
    {
        Warrior,
        Paladin,
        Barbarian_Warrior,
        Thief,
        Hunter,
        Bard,
        Wizard,
        Witch,
        Priest
    }

    public enum RaceType
    {
        Human,
        Elf,
        Dwarf,
        Orc,
        Goblin
    }

    public enum ReactionType
    {
        Idle,
        Smile,
        Sad
    }

    public string npcName;
    public int level;

    public int health;
    public int damage;
    public int defense;

    public PersonalityType personality;
    public OccupationType occupation;
    public RaceType race;
    public ReactionType reaction;

    public float aggressiveProbability;
    public float friendlyProbability;
    public float neutralProbability;

    public NPC(string name, int lvl, int hp, int dmg, int def, PersonalityType per, OccupationType occ, RaceType rac, ReactionType react, float aggrProb, float friendProb, float neutralProb)
    {
        npcName = name;
        level = lvl;
        health = hp;
        damage = dmg;
        defense = def;
        personality = per;
        occupation = occ;
        race = rac;
        reaction = react;
        aggressiveProbability = aggrProb;
        friendlyProbability = friendProb;
        neutralProbability = neutralProb;
    }
}
