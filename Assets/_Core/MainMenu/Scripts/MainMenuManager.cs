using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{
    public Button playButton; 
    public Button playAIModeButton;

    SceneController sceneController;

    void Start()
    {
        sceneController = FindFirstObjectByType<SceneController>();
        if(playButton != null)
        {
            playButton.onClick.AddListener(() => PlayGame("Level 1"));
        }
        if (playAIModeButton != null)
        {
            playAIModeButton.onClick.AddListener(() => PlayAIMode("Level_1_AI"));
        }
    }

    // This runs when the Play button is clicked
    public void PlayGame(string sceneName)
    {
        if (sceneController == null)
        {
            sceneController = FindFirstObjectByType<SceneController>();
        }else
        {
            sceneController.LoadNextScene(sceneName);
        }
    }

    public void PlayAIMode(string sceneName)
    {
        if (sceneController == null)
        {
            sceneController = FindFirstObjectByType<SceneController>();
        }
        else
        {
            sceneController.LoadNextScene(sceneName);
        }
    }

    public void QuitGame()
    {
        Application.Quit();
    }


}