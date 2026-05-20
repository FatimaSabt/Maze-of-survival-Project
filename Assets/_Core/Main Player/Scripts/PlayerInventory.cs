using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    // This class manages the player's inventory
    // It will be for key and coins
    public bool hasKey = false;
    public int coinCount = 0;


    public void CollectKey()
    {
        hasKey = true;
        Debug.Log("Key collected!");
    }

    public bool HasKey()
    {
        return hasKey;
    }

    public void UseKey()
    {
        if (hasKey)
        {
            hasKey = false;
            Debug.Log("Key used!");
        }
        else
        {
            Debug.Log("You don't have a key.");
        }
    }

    public void CollectCoin(int value)
    {
        coinCount += value;
        Debug.Log("Collected a coin! Total coins: " + coinCount);
    }
}