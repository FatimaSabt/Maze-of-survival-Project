using UnityEngine;
using System.Text.RegularExpressions;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public  GameObject spawnPoint; // Reference to the spawn point in the scene
    private void Start()
    {
        // Spawn player at the SpawnPoint in the current scene
        SpawnPlayerAtSpawnPoint();
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
