using UnityEngine;
using UnityEngine.SceneManagement;

public class NextScene: MonoBehaviour
{

    public void LoadScene(string SceneName)
    {
        SceneManager.LoadScene(SceneName);
    }

    public void LoadScene2(string SceneName)
    {
        SceneManager.LoadScene(SceneName,LoadSceneMode.Additive);
    }

    public void EixtScene()
    {
        Application.Quit();
    }


}
