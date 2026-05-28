using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    // Singleton instance so any script can call this easily
    public static UIManager Instance;

    [Header("Canvas")]
    public Canvas scoreCanvas;

    [Header("UI Panels")]
    public GameObject lvlCompletePanel;
    public GameObject losePanel;
    public GameObject winPanel;

    [Header("Backgrounds Panels")]
    public GameObject mazeBackground;
    public GameObject background;
    public GameObject outlineBackground;
    

    [Header("Lvl Complete UI Stats")]
    public TMP_Text winLevelText;
    public TMP_Text winCoinsText;
    public TMP_Text winTimeText;
    

    [Header("Lose UI Stats")]
    public TMP_Text loseLevelText;
    public TMP_Text loseCoinsText;
    public TMP_Text loseTimeText;

    [Header("Win UI Stats")]
    public TMP_Text CoinsText;
    public TMP_Text TimeText;
    

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
        winPanel.SetActive(false);
        mazeBackground.SetActive(false);
        background.SetActive(false); 
        outlineBackground.SetActive(false);

        Time.timeScale = 1f; 
    }

    public void ShowLvlCompleteScreen(int collectedCoins, int lvlCoins, float timeTaken, string levelName)
    {
        scoreCanvas.enabled = false;
        mazeBackground.SetActive(true);
        background.SetActive(true);
        outlineBackground.SetActive(true);
        
        PauseGameAndUnlockCursor();
        
        // Extract the level number from the scene name (e.g., "Level_5" -> 5)
        System.Text.RegularExpressions.Match match = System.Text.RegularExpressions.Regex.Match(levelName, @"\d+");
        int sceneLevel = match.Success ? int.Parse(match.Value) : -1;// Route to the correct panel based on the level number
        
        if (sceneLevel == 5)
        {
            winPanel.SetActive(true);
            
            CoinsText.text = $"{collectedCoins} / {lvlCoins}";
            
            // Convert the float to a TimeSpan
            System.TimeSpan timeSpan = System.TimeSpan.FromSeconds(timeTaken);
            TimeText.text = $"Time: {timeSpan.ToString(@"mm\:ss")}";
        }
        else
        {
            // Show Level Complete panel
            lvlCompletePanel.SetActive(true);
            
            // Update Text
            winLevelText.text = $"Level {sceneLevel}";
            winCoinsText.text = $"{collectedCoins} / {lvlCoins}";
            
            // Convert the float to a TimeSpan
            System.TimeSpan timeSpan = System.TimeSpan.FromSeconds(timeTaken);
            winTimeText.text = $"Time: {timeSpan.ToString(@"mm\:ss")}";
        }

        // // Update Text
        // winLevelText.text = levelName;
        // winCoinsText.text = $"{collectedCoins} / {lvlCoins}";
        
        // // Convert the float to a TimeSpan
        // System.TimeSpan timeSpan = System.TimeSpan.FromSeconds(timeTaken);
        // // formating the time presentation as 14:54
        // winTimeText.text = $"Time: {timeSpan.ToString(@"mm\:ss")}";
        
    }

    public void ShowLoseScreen(int collectedCoins, int lvlCoins, float timeTaken, string levelName)
    {
        scoreCanvas.enabled = false;
        losePanel.SetActive(true);
        outlineBackground.SetActive(true);

        PauseGameAndUnlockCursor();

        // Update Texts
        loseLevelText.text = levelName;
        loseCoinsText.text = $"{collectedCoins} / {lvlCoins}";
        
        // Convert the float to a TimeSpan
        System.TimeSpan timeSpan = System.TimeSpan.FromSeconds(timeTaken);
        // formating the time presentation as 14:54
        loseTimeText.text = $"Time: {timeSpan.ToString(@"mm\:ss")}";
        
    }

    private void PauseGameAndUnlockCursor()
    {
        Time.timeScale = 0f; // Pauses the game world
        
        // Unlocks the mouse so the player can click "Retry" or "Next Level"
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }
}