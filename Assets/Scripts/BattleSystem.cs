using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

#region Enum List
//시작, 플레이어턴, NPC턴, 승리, 패배
public enum BattleState { START, PLAYERTURN, NPCTURN, WON, LOST }
//몰입, 탐색, 충동, 창의
public enum BehaviorType { IMMERSIVE, EXPLORATORY, IMPULSIVE, CREATIVE }
//공격, 주문, 질주, 퇴각, 은신, 돕기 
public enum MainAction { ATTCK, SPELL, SPRINT, STEALTH, HELP }
//보조공격, 밀치기
public enum BonusAction { SECONDARYATTCK, KNOCKBACK }
//도약, 기회 공격
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
            playerObject.SetActive(false); // 플레이어 비활성화
            playerObject.transform.position = playerBattleTransform.position; // 위치 재설정
            playerObject.SetActive(true); // 플레이어 활성화
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
    void CombatPriority() //속도 계산 및 우선권
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
