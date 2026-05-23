using UnityEngine;
using System.Text.RegularExpressions;
using UnityEngine.SceneManagement;
using TMPro;

public class SceneController : MonoBehaviour
{
    private GameObject[] coins; // Array to hold all coin objects in the scene
    public  GameObject spawnPoint; // Reference to the spawn point in the scene
    public TextMeshProUGUI Score; // Reference to the TextMeshPro for displaying coin count
    private void Start()
    {
         //Get total coin object placed in the current level
        coins = GameObject.FindGameObjectsWithTag("Coin");
        Debug.Log("Total coins in the scene: " + coins.Length);
        // Spawn player at the SpawnPoint in the current scene
        SpawnPlayerAtSpawnPoint();
        //Initialize the coin count display for the current level
        LevelLayout();
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
            Debug.LogError("No Player found in the scene!");
        }
    }

    public void LevelLayout()
    {

        //Get total coins in player inventory for current level
        PlayerInventory playerInventory = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInventory>();
        Debug.Log("Player's current coin count: " + playerInventory.coinCount);

        //Formatic way to display the coin count in the UI can be implemented here, 
        //"cointCount / coins.Length"
        if (Score != null)
        {
            Score.text =  playerInventory.coinCount + " / " + coins.Length;
        }
        else
        {
            Debug.LogError("Score TextMesh reference is not set!");
        }


    }

    public void LoadNextScene( string sceneName)
    {
        //Validate the scene level name using regex to prevent loading unintended scenes
        Match match = Regex.Match(sceneName, @"\d+");
        int sceneLevel = match.Success ? int.Parse(match.Value) : -1;
        if (sceneLevel < 0)
        {
            Debug.LogError("Invalid scene name: " + sceneName);
            return;
        }else if (sceneLevel > 5)
        {
            Debug.LogError("Game completed! No more scenes to load.");
            return;
        }

        //go to scene by scene name
        SceneManager.LoadScene(sceneName);
    }
}
