using UnityEngine;
using System.Text.RegularExpressions;

public class KeyExitSystem : MonoBehaviour
{
    // --- Past Code ----
    // public string nextLevel;
    // public SceneController sceneController;
    // private void OnTriggerEnter(Collider other)
    // {
    //     if (other.CompareTag("Player"))
    //     {
    //         PlayerInventory inventory = other.GetComponent<PlayerInventory>();

    //         if (inventory != null && inventory.HasKey())
    //         {
    //             inventory.UseKey();
    //             Destroy(gameObject);

    //             Debug.Log("Door unlocked! You can exit now.");
    //             sceneController.LoadNextScene(nextLevel);
    //         }
    //         else
    //         {
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

            if (inventory != null && inventory.HasKey())
            {
                inventory.UseKey();
                
                // Hide the door and disable its collider instead of Destroying it immediately
                GetComponent<MeshRenderer>().enabled = false;
                GetComponent<Collider>().enabled = false;

                Debug.Log("Door unlocked! You Win!");
                
                // Trigger the Global Win UI
                UIManager.Instance.ShowWinScreen();
            }
            else
            {
                Debug.Log("Door is locked. You need a key.");
            }
        }
    }
}
