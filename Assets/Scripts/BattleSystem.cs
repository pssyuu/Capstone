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

        // �÷��̾� �Է� ó��
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SwitchTurn();
        }
    }

    void SwitchTurn()
    {
        // ���� �Ͽ� ���� ��ȯ
        if (state == BattleState.PLAYERTURN)
        {
            playerTurnUI.SetActive(false); // �÷��̾� ���� ������ UI�� ���ϴ�.
            state = BattleState.NPCTURN;
        }
        else if (state == BattleState.NPCTURN)
        {
            playerTurnUI.SetActive(true); // NPC ���� �����ϸ� UI�� �մϴ�.
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

        // ������ �� �÷��̾� ������ ����
        state = BattleState.PLAYERTURN;
        playerTurnUI.SetActive(true); // ���� ���� �� �÷��̾� ���̹Ƿ� UI�� �մϴ�.
    }
}
