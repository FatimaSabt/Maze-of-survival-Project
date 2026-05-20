using Unity.VisualScripting;
using UnityEngine;

public class KeyExitSystem : MonoBehaviour
{
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
            // Go to the next level 
        }
        else
        {
            Debug.Log("Door is locked. You need a key.");
        }
    }
}
    
}
