using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{


    public Button playButton; 

    SceneController sceneController;

    void Start()
    {
        sceneController = FindFirstObjectByType<SceneController>();
        if(playButton != null)
        {
            playButton.onClick.AddListener(() => PlayGame("Level_3"));
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
}