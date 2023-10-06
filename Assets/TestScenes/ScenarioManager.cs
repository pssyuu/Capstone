using UnityEngine;
using UnityEngine.UI;
using Newtonsoft.Json;
using System.Collections.Generic;

public class ScenarioManager : MonoBehaviour
{
    // �б���
    public TextAsset jsonFile; // �ν����� â���� JSON ������ �巡�� �� ����� ����
    public Text dialogueTextUI;
    public Button[] choiceButtons;

    private ScenarioData scenarioData;
    private int currentScenarioIndex = 0;

    private void Start()
    {
        // jsonFile ������ �Ҵ�� JSON ������ ������
        string jsonText = jsonFile.text;

        // JSON �ؽ�Ʈ�� �ó����� �����ͷ� �Ľ�
        scenarioData = JsonConvert.DeserializeObject<ScenarioData>(jsonText);

        // ���� ���� �� �ʱ� �ó����� ǥ��
        DisplayScenario(currentScenarioIndex);
    }

    private void DisplayScenario(int scenarioIndex)
    {
        // ���� �ó����� �ε����κ��� ���� ������ ���� ��������
        ScenarioItem currentScenario = scenarioData.scenario[scenarioIndex];
        string dialogueText = currentScenario.text;
        List<ScenarioChoice> choices = currentScenario.choices;

        // ��縦 UI�� ǥ��
        dialogueTextUI.text = dialogueText;

        // ������ ��ư�� Ȱ��ȭ�ϰ� �ؽ�Ʈ ���� �� ������ ����
        for (int i = 0; i < choiceButtons.Length; i++)
        {
            if (i < choices.Count)
            {
                choiceButtons[i].gameObject.SetActive(true);
                Text buttonText = choiceButtons[i].GetComponentInChildren<Text>();
                buttonText.text = choices[i].text; // ������ �ؽ�Ʈ ����

                // �������� ����� �̺�Ʈ �ڵ鷯 ���
                int choiceIndex = i;
                choiceButtons[i].onClick.RemoveAllListeners();
                choiceButtons[i].onClick.AddListener(() => OnChoiceClicked(choiceIndex));
            }
            else
            {
                // �������� ���� ��ư�� ��Ȱ��ȭ
                choiceButtons[i].gameObject.SetActive(false);
            }
        }
    }

    private void OnChoiceClicked(int choiceIndex)
    {
        // ���� �ó��������� ������ �������� nextScenarioID�� ������
        int nextScenarioID = scenarioData.scenario[currentScenarioIndex].choices[choiceIndex].nextScenarioID;

        // ������ ���� �ó������� �ε����� ã��
        currentScenarioIndex = GetScenarioIndexByID(nextScenarioID);

        // ��縦 ������ �������� �ؽ�Ʈ�� ������Ʈ
        string dialogueText = scenarioData.scenario[currentScenarioIndex].text;
        dialogueTextUI.text = dialogueText;

        // ���ο� �ó������� ǥ��
        DisplayScenario(currentScenarioIndex);
    }

    private int GetScenarioIndexByID(int scenarioID)
    {
        // �־��� scenarioID�� �ش��ϴ� �ó������� �ε��� �˻�
        for (int i = 0; i < scenarioData.scenario.Count; i++)
        {
            if (scenarioData.scenario[i].id == scenarioID)
            {
                return i;
            }
        }
        return -1; // �ش� ID�� ���� �ó������� ã�� ���� ���
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
