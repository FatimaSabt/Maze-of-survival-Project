using UnityEngine;
using System.Text.RegularExpressions;
using UnityEngine.SceneManagement;
using TMPro;

public class SceneController : MonoBehaviour
{
    private float levelTimer = 0f;
    private GameObject[] coins; // Array to hold all coin objects in the scene
    public  GameObject spawnPoint; // Reference to the spawn point in the scene
    public TextMeshProUGUI Score; // Reference to the TextMeshPro for displaying coin count
    public TextMeshProUGUI KeyText; // Reference to the TextMeshPro for displaying key collected
    public TextMeshProUGUI timer; // Reference to the TextMeshPro for displaying timer

    internal static readonly int Coins;

    // make SceneController as Singleton
    public static SceneController Instance;

    private void Awake()
    {
        Instance = this;

        coins = GameObject.FindGameObjectsWithTag("Coin");
    } 

    

    private void Start()
    {
        if (spawnPoint != null )
        {
            //Get total coin object placed in the current level
            coins = GameObject.FindGameObjectsWithTag("Coin");
            if (coins == null || coins.Length == 0)
            {
                Debug.LogWarning("No coins found in the scene!");
            }else
            {
                Debug.Log("Coins found in the scene: " + coins.Length);
                //Initialize the coin count display for the current level
                LevelLayout();
            }
            Debug.Log("Total coins in the scene: " + coins.Length);

            // Spawn player at the SpawnPoint in the current scene
            SpawnPlayerAtSpawnPoint();
        }
    
    }

    private void Update()
    {
        UpdateTimer();
    }

    private void UpdateTimer()
    {
        levelTimer += Time.deltaTime;

        if (timer != null)
        {
            System.TimeSpan timeSpan = System.TimeSpan.FromSeconds(levelTimer);
            timer.text = timeSpan.ToString(@"mm\:ss");
        }
    }
    
    public void SpawnPlayerAtSpawnPoint()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            if (spawnPoint != null)
            {
                player.transform.position = spawnPoint.transform.position;
                player.transform.rotation = spawnPoint.transform.rotation;
            }
            else
            {
                Debug.LogError("No SpawnPoint found in the scene!");
            }
        }
        else
        {
            Debug.LogError("No Player object found in the scene!");
        }
    }

    public void LevelLayout()
    {

        //Get total coins in player inventory for current level
        PlayerInventory playerInventory = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInventory>();
        Debug.Log("Player's current coin count: " + playerInventory.coinCount);
 
        //"cointCount / coins.Length"
        if (Score != null)
        {
            Score.text =  playerInventory.coinCount + " / " + coins.Length;
        }

        // ----- New Code ----------
        // Key UI
        if (KeyText != null)
        {
            KeyText.text = playerInventory.hasKey ? "1 / 1" : "0 / 1";
        }
        // -------------------------

        //Show timer
        if (timer != null)
        {
            timer.text = " 00:00";
        }
    }

    // ----- New Code ----------

    // a getter to get total number of coins in the level
    public int LvlCoins 
    { 
        get { return coins != null ? coins.Length : 0; } 
    }

    // method to restart the current level
    public void RetryLevel()
    {
        // Unpause the game before reloading
        Time.timeScale = 1f; 
        
        // Load the currently active scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); 
    }

    // -------------------------

    public void LoadNextScene( string sceneName)
    {
        //Validate the scene level name using regex to prevent loading unintended scenes
        Match match = Regex.Match(sceneName, @"\d+");
        int sceneLevel = match.Success ? int.Parse(match.Value) : -1;
        if (sceneLevel < 0)
        {
            // If the scene name doesn't contain a valid level number, go to main menu instead
            SceneManager.LoadScene("MainMenu");
            return;
        }else if (sceneLevel > 5)
        {
            Debug.LogError("Game completed! No more scenes to load.");
            return;
        }

        // ----- New Code ----------
        // Unpause the game before loading the next scene!
        Time.timeScale = 1f;
        // -------------------------

        //go to scene by scene name
        SceneManager.LoadScene(sceneName);
    }
}
