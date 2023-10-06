using UnityEngine;
using UnityEngine.UI;
using Newtonsoft.Json;
using System.Collections.Generic;

public class ScenarioManager : MonoBehaviour
{
    // 분기점
    public TextAsset jsonFile; // 인스펙터 창에서 JSON 파일을 드래그 앤 드롭할 변수
    public Text dialogueTextUI;
    public Button[] choiceButtons;

    private ScenarioData scenarioData;
    private int currentScenarioIndex = 0;

    private void Start()
    {
        // jsonFile 변수에 할당된 JSON 파일을 가져옴
        string jsonText = jsonFile.text;

        // JSON 텍스트를 시나리오 데이터로 파싱
        scenarioData = JsonConvert.DeserializeObject<ScenarioData>(jsonText);

        // 게임 시작 시 초기 시나리오 표시
        DisplayScenario(currentScenarioIndex);
    }

    private void DisplayScenario(int scenarioIndex)
    {
        // 현재 시나리오 인덱스로부터 대사와 선택지 정보 가져오기
        ScenarioItem currentScenario = scenarioData.scenario[scenarioIndex];
        string dialogueText = currentScenario.text;
        List<ScenarioChoice> choices = currentScenario.choices;

        // 대사를 UI에 표시
        dialogueTextUI.text = dialogueText;

        // 선택지 버튼을 활성화하고 텍스트 설정 및 선택지 연결
        for (int i = 0; i < choiceButtons.Length; i++)
        {
            if (i < choices.Count)
            {
                choiceButtons[i].gameObject.SetActive(true);
                Text buttonText = choiceButtons[i].GetComponentInChildren<Text>();
                buttonText.text = choices[i].text; // 선택지 텍스트 설정

                // 선택지와 연결된 이벤트 핸들러 등록
                int choiceIndex = i;
                choiceButtons[i].onClick.RemoveAllListeners();
                choiceButtons[i].onClick.AddListener(() => OnChoiceClicked(choiceIndex));
            }
            else
            {
                // 선택지가 없는 버튼은 비활성화
                choiceButtons[i].gameObject.SetActive(false);
            }
        }
    }

    private void OnChoiceClicked(int choiceIndex)
    {
        // 현재 시나리오에서 선택한 선택지의 nextScenarioID를 가져옴
        int nextScenarioID = scenarioData.scenario[currentScenarioIndex].choices[choiceIndex].nextScenarioID;

        // 선택한 다음 시나리오의 인덱스를 찾음
        currentScenarioIndex = GetScenarioIndexByID(nextScenarioID);

        // 대사를 선택한 선택지의 텍스트로 업데이트
        string dialogueText = scenarioData.scenario[currentScenarioIndex].text;
        dialogueTextUI.text = dialogueText;

        // 새로운 시나리오를 표시
        DisplayScenario(currentScenarioIndex);
    }

    private int GetScenarioIndexByID(int scenarioID)
    {
        // 주어진 scenarioID에 해당하는 시나리오의 인덱스 검색
        for (int i = 0; i < scenarioData.scenario.Count; i++)
        {
            if (scenarioData.scenario[i].id == scenarioID)
            {
                return i;
            }
        }
        return -1; // 해당 ID를 가진 시나리오를 찾지 못한 경우
    }
}

[System.Serializable]
public class ScenarioChoice
{
    public string text;
    public int nextScenarioID;
}

[System.Serializable]
public class ScenarioItem
{
    public int id;
    public string text;
    public List<ScenarioChoice> choices;
}

[System.Serializable]
public class ScenarioData
{
    public List<ScenarioItem> scenario;
}
