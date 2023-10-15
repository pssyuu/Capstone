using UnityEngine;
using UnityEngine.UI;
using Newtonsoft.Json;
using System.Collections.Generic;

public class StoryManager : NextScene
{
    // 분기점
    public TextAsset jsonFile; // 인스펙터 창에서 JSON 파일을 드래그 앤 드롭할 변수
    public Text dialogueTextUI;
    public GameObject selectButton;
    public GameObject storyButton;

    private StoryData storyData;
    private int next = 0;
    private int currentScenarioIndex = 0;
    //private int ranScenarioIndex = Random.Range(0,2);

    string dialogueText;

    private void Awake()
    {
        // 처음 시작시 선택창 비활성화
        selectButton.SetActive(false);
    }

    private void Start()
    {
        // jsonFile 변수에 할당된 JSON 파일을 가져옴
        string jsonText = jsonFile.text;

        // JSON 텍스트를 시나리오 데이터로 파싱
        storyData = JsonConvert.DeserializeObject<StoryData>(jsonText);

        // 게임 시작 시 초기 시나리오 표시
        DisplayScenario(currentScenarioIndex);
    }

    private void DisplayScenario(int scenarioIndex)
    {
        // 현재 시나리오 인덱스로부터 대사와 선택지 정보 가져오기
        StoryItem currentScenario = storyData.scenario[scenarioIndex];
        string dialogueText = currentScenario.text;

        // 대사를 UI에 표시
        dialogueTextUI.text = dialogueText;
    } 

    public void OnChoiceClicked()
    {
        // 현재 텍스트를 다음 텍스트로 넘어감
        next = storyData.scenario[currentScenarioIndex].nextScenarioID;
        currentScenarioIndex = next;
        dialogueText = storyData.scenario[next].text;
        dialogueTextUI.text = dialogueText;

        // 텍스트가 있으면 버튼 비활성화, 텍스트가 없으면 버튼 활성화 
        if (dialogueText == "")
        {
            selectButton.SetActive(true);
            storyButton.gameObject.SetActive(false);
        }
        else
        {
            selectButton.SetActive(false);
            storyButton.gameObject.SetActive(true);
        }
    }

    private void Option1()
    {
        next = storyData.scenario[currentScenarioIndex].nextScenarioID;
        currentScenarioIndex = next;
        dialogueText = storyData.scenario[next].text;
        dialogueTextUI.text = dialogueText;

    }

    private void FixedUpdate()
    {
        if (next == 999)
        {
            LoadScene("Gameover");
        }
    }
}

[System.Serializable]
public class StoryItem
{
    public int id;
    public string text;
    public int nextScenarioID;
}

[System.Serializable]
public class StoryData
{
    public List<StoryItem> scenario;
}