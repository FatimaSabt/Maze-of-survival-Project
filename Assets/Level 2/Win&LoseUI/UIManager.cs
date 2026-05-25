using UnityEngine;

public class UIManager : MonoBehaviour
{
    [Header("UI Panels")]
    public GameObject winPanel;
    public GameObject losePanel;

    private void Start()
    {
        // Ensure panels are hidden when the level starts
        winPanel.SetActive(false);
        losePanel.SetActive(false);
        
        // Ensure time is running normally
        Time.timeScale = 1f; 
    }

    public void ShowWinScreen()
    {
        winPanel.SetActive(true);
        Time.timeScale = 0f; // Pauses the game
    }

    public void ShowLoseScreen()
    {
        losePanel.SetActive(true);
        Time.timeScale = 0f; // Pauses the game
    }
}