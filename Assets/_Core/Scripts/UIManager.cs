using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    // Singleton instance so any script can call this easily
    public static UIManager Instance;

    [Header("UI Panels")]
    public GameObject lvlCompletePanel;
    public GameObject losePanel;

    [Header("Lvl Complete UI Stats")]
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
        lvlCompletePanel.SetActive(false);
        losePanel.SetActive(false);
        Time.timeScale = 1f; 
    }

    public void ShowLvlCompleteScreen(int collectedCoins, int lvlCoins, float timeTaken, string levelName)
    {
        lvlCompletePanel.SetActive(true);
        PauseGameAndUnlockCursor();
        
        // Update Text
        winCoinsText.text = $"{collectedCoins} / {lvlCoins}";
        winTimeText.text = $"Time: {timeTaken.ToString("F1")}s";
        winLevelText.text = levelName;
    }

    public void ShowLoseScreen(int collectedCoins, int lvlCoins, float timeTaken, string levelName)
    {
        losePanel.SetActive(true);
        PauseGameAndUnlockCursor();

        // Update Text
        loseCoinsText.text = $"{collectedCoins} / {lvlCoins}";
        loseTimeText.text = $"Time: {timeTaken.ToString("F1")}s";
        loseLevelText.text = levelName;
    }

    private void PauseGameAndUnlockCursor()
    {
        Time.timeScale = 0f; // Pauses the game world
        
        // Unlocks the mouse so the player can click "Retry" or "Next Level"
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }
}