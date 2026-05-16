using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class Arrow : MonoBehaviour
{
    public float life = 3;
 
    void Awake()
    {
        Destroy(gameObject, life);
    }
 
    void OnCollisionEnter(Collision collision)
    {
          if (collision.gameObject.CompareTag("Player"))
        {
             PlayerHealth player = collision.gameObject.GetComponent<PlayerHealth>();

            if (player != null)
            {
                player.TakeDamage(1);
            }
        }

        Destroy(gameObject); // arrow disappears after impact
    }
    }
