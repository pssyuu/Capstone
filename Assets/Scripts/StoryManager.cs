using UnityEngine;
using UnityEngine.UI;
using Newtonsoft.Json;
using System.Collections.Generic;

public class StoryManager : NextScene
{
    // �б���
    public TextAsset jsonFile; // �ν����� â���� JSON ������ �巡�� �� ����� ����
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
        // ó�� ���۽� ����â ��Ȱ��ȭ
        selectButton.SetActive(false);
    }

    private void Start()
    {
        // jsonFile ������ �Ҵ�� JSON ������ ������
        string jsonText = jsonFile.text;

        // JSON �ؽ�Ʈ�� �ó����� �����ͷ� �Ľ�
        storyData = JsonConvert.DeserializeObject<StoryData>(jsonText);

        // ���� ���� �� �ʱ� �ó����� ǥ��
        DisplayScenario(currentScenarioIndex);
    }

    private void DisplayScenario(int scenarioIndex)
    {
        // ���� �ó����� �ε����κ��� ���� ������ ���� ��������
        StoryItem currentScenario = storyData.scenario[scenarioIndex];
        string dialogueText = currentScenario.text;

        // ��縦 UI�� ǥ��
        dialogueTextUI.text = dialogueText;
    } 

    public void OnChoiceClicked()
    {
        // ���� �ؽ�Ʈ�� ���� �ؽ�Ʈ�� �Ѿ
        next = storyData.scenario[currentScenarioIndex].nextScenarioID;
        currentScenarioIndex = next;
        dialogueText = storyData.scenario[next].text;
        dialogueTextUI.text = dialogueText;

        // �ؽ�Ʈ�� ������ ��ư ��Ȱ��ȭ, �ؽ�Ʈ�� ������ ��ư Ȱ��ȭ 
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