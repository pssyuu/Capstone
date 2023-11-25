using System.Collections;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;

public enum BattleState { START, PLAYERTURN, NPCTURN, WON, LOST };

public class BattleSystem : MonoBehaviour
{
    private static BattleSystem instance;

    public static BattleSystem Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<BattleSystem>();
                if (instance == null)
                {
                    GameObject obj = new GameObject(typeof(BattleSystem).Name);
                    instance = obj.AddComponent<BattleSystem>();
                }
            }
            return instance;
        }
    }

    public GameObject playerTurnUI;

    public Transform playerBattleTransform;
    public Transform npcBattleTransform;

    public Text currentState;

    public BattleState state;

    private GameObject playerObject;
    private GameObject NPCObject;

    void Start()
    {
        state = BattleState.START;
        SetupBattle();
    }

    void Update()
    {
        currentState.text = state.ToString();

        // 플레이어 입력 처리
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SwitchTurn();
        }
    }

    void SwitchTurn()
    {
        // 현재 턴에 따라 전환
        if (state == BattleState.PLAYERTURN)
        {
            playerTurnUI.SetActive(false); // 플레이어 턴이 끝나면 UI를 끕니다.
            state = BattleState.NPCTURN;
        }
        else if (state == BattleState.NPCTURN)
        {
            playerTurnUI.SetActive(true); // NPC 턴이 시작하면 UI를 켭니다.
            state = BattleState.PLAYERTURN;
        }
    }

    void SetupBattle()
    {

        playerObject = GameObject.FindGameObjectWithTag("Player");
        if (playerObject != null)
        {
            playerObject.transform.position = playerBattleTransform.position;
        }

        NPCObject = GameObject.FindGameObjectWithTag("NPC");
        if (NPCObject != null)
        {
            NPCObject.transform.position = npcBattleTransform.position;
        }

        // 시작할 때 플레이어 턴으로 설정
        state = BattleState.PLAYERTURN;
        playerTurnUI.SetActive(true); // 게임 시작 시 플레이어 턴이므로 UI를 켭니다.
    }
}
