using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI_Trigger : MonoBehaviour
{
    public Enemy_AI enemyAI; // Drag the AI enemy here

    void OnTriggerEnter(Collider other)
    {
        // When the player enters the trigger area, activate the AI
        if (other.CompareTag("Remy"))
        {
            enemyAI.ActivateChase();
        }
    }

    void OnTriggerStay(Collider other)
    {
        // This helps if the player starts inside the trigger area
        if (other.CompareTag("Remy"))
        {
            enemyAI.ActivateChase();
        }
    }
}