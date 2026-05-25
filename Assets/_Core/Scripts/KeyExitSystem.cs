using UnityEngine;
using System.Text.RegularExpressions;

public class KeyExitSystem : MonoBehaviour
{
    public string nextLevel;
    public SceneController sceneController;

    AudioManager audioManager;

    void Awake()
    {
       audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerInventory inventory = other.GetComponent<PlayerInventory>();

            if (inventory != null && inventory.HasKey())
            {
                inventory.UseKey();
                Destroy(gameObject);
                audioManager.PlaySFX(audioManager._exit);
                Debug.Log("Door unlocked! You can exit now.");
                sceneController.LoadNextScene(nextLevel);
            }
            else
            {
                audioManager.PlaySFX(audioManager._doorClosed);
                Debug.Log("Door is locked. You need a key.");
            }
        }
    }
}
