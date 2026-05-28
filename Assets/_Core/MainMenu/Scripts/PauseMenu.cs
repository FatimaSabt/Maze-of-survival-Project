using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [Header("Pause Menu Screens")]
    public GameObject pauseMenuPanel;
    public GameObject pauseSettingsPanel;

    [Header("Gameplay UI")]
    public GameObject gameplayUI; // Drag your coins/key/timer canvas here

    [Header("Main Menu Scene")]
    public string mainMenuSceneName = "MainMenu";

    [Header("Background Outline")]
    public GameObject backgroundOutline;


    private bool isPaused = false;

    void Start()
    {
        // 1. Hide pause menu screens at the start
        pauseMenuPanel.SetActive(false);
        backgroundOutline.SetActive(false);
        pauseSettingsPanel.SetActive(false);

        // 2. Show gameplay UI at the start
        if (gameplayUI != null)
        {
            gameplayUI.SetActive(true);
        }

        // 3. Make sure the game is running normally
        Time.timeScale = 1f;

        // 4. Lock cursor for first-person gameplay
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        // 5. Open/close pause menu with Esc or P
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P))
        {
            if (isPaused)
            {
                ContinueGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    public void PauseGame()
    {
        // 6. Show pause menu
        pauseMenuPanel.SetActive(true);
        backgroundOutline.SetActive(true);
        pauseSettingsPanel.SetActive(false);

        // 7. Hide gameplay UI
        if (gameplayUI != null)
        {
            gameplayUI.SetActive(false);
        }

        // 8. Pause the game
        Time.timeScale = 0f;

        // 9. Unlock cursor so buttons can be clicked
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        isPaused = true;
    }

    public void ContinueGame()
    {
        // 10. Hide pause menu screens
        pauseMenuPanel.SetActive(false);
        backgroundOutline.SetActive(false);
        pauseSettingsPanel.SetActive(false);

        // 11. Show gameplay UI again
        if (gameplayUI != null)
        {
            gameplayUI.SetActive(true);
        }

        // 12. Resume the game
        Time.timeScale = 1f;

        // 13. Lock cursor again for gameplay
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        isPaused = false;
    }

    public void OpenSettings()
    {
        // 14. Hide pause menu
        pauseMenuPanel.SetActive(false);
        backgroundOutline.SetActive(false);

        // 15. Show settings panel
        pauseSettingsPanel.SetActive(true);

        // 16. Keep gameplay UI hidden while in settings
        if (gameplayUI != null)
        {
            gameplayUI.SetActive(false);
        }
    }

    public void BackToPauseMenu()
    {
        // 17. Hide settings panel
        pauseSettingsPanel.SetActive(false);
        backgroundOutline.SetActive(true);

        // 18. Show pause menu again
        pauseMenuPanel.SetActive(true);
    }

    public void GoToMainMenu()
    {
        // 19. Resume time before changing scenes
        Time.timeScale = 1f;

        // 20. Unlock cursor for main menu
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        // 21. Load main menu scene
        SceneManager.LoadScene(mainMenuSceneName);
    }
}