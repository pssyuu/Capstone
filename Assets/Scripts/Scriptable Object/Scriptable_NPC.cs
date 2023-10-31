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

    //����
    public enum OccupationType
    {
        //����, �߸�����, �����, ����, ��ɲ�, ��������, ������ �渶����, ����
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

    // ����
    public enum RaceType
    {
        Human,
        Elf,
        Dwarf,
        Orc,
        Goblin
    }

    // ����
    public enum ReactionType
    {
        Idle,
        Smile,
        Sad
    }

    [Header("�⺻ ����")]
    public string npcName;
    public int level;

    [Header("����")]
    public int health;
    public int damage;
    public int defense;

    [Header("����, ����, ����")]
    public PersonalityType personality;
    public OccupationType occupation;
    public RaceType race;

    [Header("�ൿȮ��")]
    [Range(0f, 1f)]
    public float aggressiveProbability;
    [Range(0f, 1f)]
    public float friendlyProbability;
    [Range(0f, 1f)]
    public float neutralProbability;

    [Header("����")]
    public ReactionType reaction;
}
