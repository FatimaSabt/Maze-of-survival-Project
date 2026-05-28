using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public bool hasKey = false;

    // For per level counting
    public int coinCount = 0;

    // Static variable to keep track of the total number of coins collected across all instances of PlayerInventory
    public static int totalCoinCount = 0;
    
    // Static variable to track total time across all levels
    public static float totalTimeTaken = 0f;


    //Hold player settings
    public static bool isMusicOn = true;
    public static bool isSoundOn = true;
    public static bool isFullScreen = true;
    public static float sensitivity = 15.0f;


    //Camera refrence for sensitivity adjustment
    public FirstPersonCamera playerCamera;

    void Start()
    {
        ChangeSensitivity(sensitivity);
    }
    public void CollectKey()
    {
        hasKey = true;
        Debug.Log("Key collected!");

        // ----- New Code ----------
        SceneController.Instance.LevelLayout();
        // -------------------------
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

            // ----- New Code ----------
            SceneController.Instance.LevelLayout();
            // -------------------------
        }
        else
        {
            Debug.Log("You don't have a key.");
        }
    }

    public void CollectCoin(int value)
    {
        coinCount += value;
        totalCoinCount += value;
        Debug.Log("Collected a coin! Total coins: " + coinCount);
    }

    public void ChangeSensitivity(float newSensitivity)
    {
        FirstPersonCamera.mouseSensitivity = newSensitivity;
    }
}