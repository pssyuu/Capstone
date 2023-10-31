using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New NPC", menuName = "NPC/New NPC")]
public class Scriptable_NPC : ScriptableObject
{
    public enum PersonalityType
    {
        Aggressive,
        Friendly,
        Neutral
    }

    //직업
    public enum OccupationType
    {
        //전사, 야만전사, 성기사, 도적, 사냥꾼, 음유시인, 마법사 흑마법사, 사제
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

    // 종족
    public enum RaceType
    {
        Human,
        Elf,
        Dwarf,
        Orc,
        Goblin
    }

    // 반응
    public enum ReactionType
    {
        Idle,
        Smile,
        Sad
    }

    [Header("기본 정보")]
    public string npcName;
    public int level;

    [Header("스탯")]
    public int health;
    public int damage;
    public int defense;

    [Header("성격, 종족, 직업")]
    public PersonalityType personality;
    public OccupationType occupation;
    public RaceType race;

    [Header("행동확률")]
    [Range(0f, 1f)]
    public float aggressiveProbability;
    [Range(0f, 1f)]
    public float friendlyProbability;
    [Range(0f, 1f)]
    public float neutralProbability;

    [Header("반응")]
    public ReactionType reaction;
}
