using UnityEngine;
using UnityEngine.UI;

public class MainMenuUI : MonoBehaviour
{
    public GameObject mainMenuPanel;
    public GameObject settingsPanel;
    public GameObject howToPlayPanel;


    void Start()
    {
        // Show main menu first
        mainMenuPanel.SetActive(true);

        // Hide other panels at the start
        settingsPanel.SetActive(false);
        howToPlayPanel.SetActive(false);

  
    }

    public void OpenSettings()
    {
        // Show settings screen only
        mainMenuPanel.SetActive(false);
        settingsPanel.SetActive(true);
        howToPlayPanel.SetActive(false);
    }

    public void OpenHowToPlay()
    {
        // Show how to play screen only
        mainMenuPanel.SetActive(false);
        settingsPanel.SetActive(false);
        howToPlayPanel.SetActive(true);
    }

    public void BackToMainMenu()
    {
        // Return to main menu
        mainMenuPanel.SetActive(true);
        settingsPanel.SetActive(false);
        howToPlayPanel.SetActive(false);
    }
}