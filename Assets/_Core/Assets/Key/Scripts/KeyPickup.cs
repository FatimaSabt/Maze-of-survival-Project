using UnityEngine;

public class KeyPickup : MonoBehaviour
{
    AudioManager audioManager;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerInventory inventory = other.GetComponent<PlayerInventory>();

            if (inventory != null)
            {
                audioManager.PlaySFX(audioManager._keyCollect);
                inventory.CollectKey();
                Destroy(gameObject);
            }
        }
    }
}