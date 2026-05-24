using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    // This runs when the Play button is clicked
    public void PlayGame()
    {
        SceneManager.LoadScene("Level_3");
    }
}