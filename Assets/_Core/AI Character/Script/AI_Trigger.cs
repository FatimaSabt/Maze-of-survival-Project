using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI_Trigger : MonoBehaviour
{
    [Header("Player Settings")]
    public GameObject player; // Drag Remy/player object here

    [Header("AI Settings")]
    public Enemy_AI enemyAI; // Drag the AI enemy here

    void OnTriggerEnter(Collider other)
    {
        // 1. Check if the object OR its parent is the assigned player
        if (other.transform.root.gameObject == player)
        {
            // 2. Activate the AI chase
            enemyAI.ActivateChase();
        }
    }
    /*
    void OnTriggerStay(Collider other)
    {
        // 3. Keep activating chase while the player stays inside
        if (other.transform.root.gameObject == player)
        {
            enemyAI.ActivateChase();
        }
    }*/
}