using UnityEngine;
using System.Text.RegularExpressions;
using UnityEngine.SceneManagement;

public class KeyExitSystem : MonoBehaviour
{
    // no need more
    // public string nextLevel;
    // public SceneController sceneController;

    AudioManager audioManager;

    void Awake()
    {
       audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    // private void OnTriggerEnter(Collider other)
    // {
    //     if (other.CompareTag("Player"))
    //     {
    //         PlayerInventory inventory = other.GetComponent<PlayerInventory>();

    //         if (inventory != null && inventory.HasKey())
    //         {
    //             inventory.UseKey();
    //             Destroy(gameObject);
    //             audioManager.PlaySFX(audioManager._exit);
    //             Debug.Log("Door unlocked! You can exit now.");
    //             sceneController.LoadNextScene(nextLevel);
    //         }
    //         else
    //         {
    //             audioManager.PlaySFX(audioManager._doorClosed);
    //             Debug.Log("Door is locked. You need a key.");
    //         }
    //     }
    // }

    // ---- New Code ---
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerInventory inventory = other.GetComponent<PlayerInventory>();

            // try this if the coins count displayed the total not the current level
            //PlayerInventory inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInventory>();

            if (inventory != null && inventory.HasKey())
            {
                inventory.UseKey();
                Destroy(gameObject);
                
                // // Hide the door and disable its collider instead of Destroying it immediately
                // GetComponent<MeshRenderer>().enabled = false;
                // GetComponent<Collider>().enabled = false;

                audioManager.PlaySFX(audioManager._exit);
                Debug.Log("Door unlocked! You can exit now.");
                
                //sceneController.LoadNextScene(nextLevel);

                int currentCoins = inventory.coinCount;
                int maxCoins = SceneController.Instance.LvlCoins;
                float timeTaken = Time.timeSinceLevelLoad;
                string levelName = SceneManager.GetActiveScene().name;

                
                // Trigger the Global Level Complete UI
                UIManager.Instance.ShowLvlCompleteScreen(currentCoins, maxCoins, timeTaken, levelName);
            }
            else
            {
                audioManager.PlaySFX(audioManager._doorClosed);
                Debug.Log("Door is locked. You need a key.");
            }
        }
    }
}
