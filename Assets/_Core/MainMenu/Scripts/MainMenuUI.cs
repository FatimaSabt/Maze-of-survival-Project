using UnityEngine;
using UnityEngine.UI;

public class MainMenuUI : MonoBehaviour
{
    public GameObject mainMenuPanel;
    public GameObject settingsPanel;
    public GameObject howToPlayPanel;
    public GameObject creditsPanel;


    void Start()
    {
        // Show main menu first
        mainMenuPanel.SetActive(true);

        // Hide other panels at the start
        settingsPanel.SetActive(false);
        howToPlayPanel.SetActive(false);
        creditsPanel.SetActive(false);


    }

    public void OpenSettings()
    {
        // Show settings screen only
        mainMenuPanel.SetActive(false);
        settingsPanel.SetActive(true);
        howToPlayPanel.SetActive(false);
        creditsPanel.SetActive(false);
    }

    public void OpenHowToPlay()
    {
        // Show how to play screen only
        mainMenuPanel.SetActive(false);
        settingsPanel.SetActive(false);
        howToPlayPanel.SetActive(true);
        creditsPanel.SetActive(false);
    }
    public void OpenCredits()
    {
        // Show how to play screen only
        mainMenuPanel.SetActive(false);
        settingsPanel.SetActive(false);
        howToPlayPanel.SetActive(false);
        creditsPanel.SetActive(true);
    }

    public void BackToMainMenu()
    {
        // Return to main menu
        mainMenuPanel.SetActive(true);
        settingsPanel.SetActive(false);
        howToPlayPanel.SetActive(false);
        creditsPanel.SetActive(false);
    }
}