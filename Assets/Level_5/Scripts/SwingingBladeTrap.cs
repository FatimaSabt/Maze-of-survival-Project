using UnityEngine;

public class SwingingBladeTrap : MonoBehaviour
{
    public float swingAngle = 60f;
    public float swingSpeed = 2f;
    private Quaternion startRotation;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        startRotation = transform.localRotation;
    }

    // Update is called once per frame
    void Update()
    {
        float angle = Mathf.Sin(Time.time * swingSpeed) * swingAngle;
        transform.localRotation = startRotation * Quaternion.Euler(0, 0, angle);
    }
}