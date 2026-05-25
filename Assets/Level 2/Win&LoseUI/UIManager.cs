using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    // Singleton instance so any script can call this easily
    public static UIManager Instance;

    [Header("UI Panels")]
    public GameObject winPanel;
    public GameObject losePanel;

    [Header("Win UI Stats")]
    public TMP_Text winCoinsText;
    public TMP_Text winTimeText;
    public TMP_Text winLevelText;

    [Header("Lose UI Stats")]
    public TMP_Text loseCoinsText;
    public TMP_Text loseTimeText;
    public TMP_Text loseLevelText;

    private void Awake()
    {
        // Set up the Singleton
        if (Instance == null) { Instance = this; }
        else { Destroy(gameObject); }
    }

    private void Start()
    {
        // Ensure panels are hidden and time is normal at the start of the level
        winPanel.SetActive(false);
        losePanel.SetActive(false);
        Time.timeScale = 1f; 
    }

    public void ShowWinScreen()
    {
        winPanel.SetActive(true);
        PauseGameAndUnlockCursor();
        
        // Update Text
        winCoinsText.text = "Coins: " + coins;
        winTimeText.text = "Time: " + timeTaken.ToString("F1") + "s";
        winLevelText.text = "Level " + SceneManager.GetActiveScene().name;
    }

    public void ShowLoseScreen()
    {
        losePanel.SetActive(true);
        PauseGameAndUnlockCursor();

        // Update Text
        loseCoinsText.text = "Coins: " + coins;
        loseTimeText.text = "Time: " + timeTaken.ToString("F1") + "s";
        loseLevelText.text = "Level " + SceneManager.GetActiveScene().name;
    }

    private void PauseGameAndUnlockCursor()
    {
        Time.timeScale = 0f; // Pauses the game world
        
        // Unlocks the mouse so the player can click "Retry" or "Next Level"
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }
}