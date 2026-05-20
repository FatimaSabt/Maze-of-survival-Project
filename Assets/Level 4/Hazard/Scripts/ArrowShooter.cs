using UnityEngine;
using System.Collections;

public class ArrowShooter : MonoBehaviour
{
    public Transform arrowSpawnPoint;
    public GameObject arrowPrefab;
    public float arrowSpeed = 10f;
    public float shootInterval = 5f;

    void Start()
    {
        shootInterval = 5f;
        InvokeRepeating("ShootArrow", shootInterval, shootInterval);
    }

    void ShootArrow()
    {
        Arrow arrow = Instantiate(arrowPrefab, arrowSpawnPoint.position, arrowSpawnPoint.rotation).GetComponent<Arrow>();
        arrow.GetComponent<Rigidbody>().linearVelocity =
            arrowSpawnPoint.forward * arrowSpeed;
    }
}