using UnityEngine;
using System.Text.RegularExpressions;

public class KeyExitSystem : MonoBehaviour
{
    public string nextLevel;
    public SceneController sceneController;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerInventory inventory = other.GetComponent<PlayerInventory>();

            if (inventory != null && inventory.HasKey())
            {
                inventory.UseKey();
                Destroy(gameObject);

                Debug.Log("Door unlocked! You can exit now.");
                sceneController.LoadNextScene(nextLevel);
            }
            else
            {
                Debug.Log("Door is locked. You need a key.");
            }
        }
    }
}
