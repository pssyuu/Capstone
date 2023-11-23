using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

#region Enum List
//����, �÷��̾���, NPC��, �¸�, �й�
public enum BattleState { START, PLAYERTURN, NPCTURN, WON, LOST }
//����, Ž��, �浿, â��
public enum BehaviorType { IMMERSIVE, EXPLORATORY, IMPULSIVE, CREATIVE }
//����, �ֹ�, ����, ��, ����, ���� 
public enum MainAction { ATTCK, SPELL, SPRINT, STEALTH, HELP }
//��������, ��ġ��
public enum BonusAction { SECONDARYATTCK, KNOCKBACK }
//����, ��ȸ ����
public enum ReactionActionP { LEAP, CHANCEATTCK }
#endregion

public class BattleSystem : MonoBehaviour
{
    public GameObject playerPrefab;
    public GameObject npcPrefab;

    NPC npc;

    public Transform playerBattleTransform;
    public Transform npcBattleTransform;

    public Text currentState;

    public float rateTurn;

    public BattleState state;
    [HideInInspector]
    public BehaviorType behaviorType;
    [HideInInspector]
    public MainAction mainAction;

    int bonusSpeed = 5;

    bool SurpiseAttacked = false;
    bool turnEnd = false;

    private GameObject playerObject;

    void Start()
    {
        state = BattleState.START;
        StartCoroutine(BattleLoop());
    }

    void Update()
    {
        currentState.text = state.ToString();
    }

    private void OnEnable()
    {
        SetupBattle();
    }

    void SetupBattle()
    {
        PlayerCleanup();
        NPCCleanup();

        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
        if (playerObject == null)
        {
            playerObject = Instantiate(playerPrefab);
            playerObject.transform.position = playerBattleTransform.position;
            playerObject.tag = "Player";
        }
        else
        {
            playerObject.SetActive(false); // �÷��̾� ��Ȱ��ȭ
            playerObject.transform.position = playerBattleTransform.position; // ��ġ �缳��
            playerObject.SetActive(true); // �÷��̾� Ȱ��ȭ
        }

        Instantiate(npcPrefab);
    }

    IEnumerator BattleLoop()
    {
        while (state != BattleState.WON && state != BattleState.LOST)
        {
            yield return StartCoroutine(ProcessTurn());
        }
    }

    IEnumerator ProcessTurn()
    {
        switch (state)
        {
            case BattleState.START:
                SetupBattle();
                yield return new WaitForSeconds(rateTurn);
                state = BattleState.PLAYERTURN;
                break;

            case BattleState.PLAYERTURN:
                Debug.Log("Player's Turn");
                yield return StartCoroutine(PlayerTurn());
                state = BattleState.NPCTURN;
                break;

            case BattleState.NPCTURN:
                Debug.Log("NPC's Turn");
                yield return StartCoroutine(NPCTurn());
                state = BattleState.PLAYERTURN;
                break;
        }
    }

    IEnumerator PlayerTurn()
    {
        yield return new WaitForSeconds(rateTurn);
    }


    IEnumerator NPCTurn()
    {
        yield return new WaitForSeconds(rateTurn);
    }
    void CombatPriority() //�ӵ� ��� �� �켱��
    {
        if (SurpiseAttacked != false)
        {

        }
    }

    void ChoiseNPCBehaviorAttck()
    {

    }

    void MainActionType()
    {
        switch (mainAction)
        {
            case MainAction.ATTCK:
                break;
            case MainAction.SPELL:
                break;
            case MainAction.SPRINT:
                break;
            case MainAction.STEALTH:
                break;
        }
    }

    void PlayerCleanup()
    {
        if (playerObject != null)
        {
            Destroy(playerObject);
        }
    }

    void NPCCleanup()
    {
        GameObject npcObject = GameObject.FindGameObjectWithTag("NPC");
        if (npcObject != null)
        {
            Destroy(npcObject);
        }
    }
}
