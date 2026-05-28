using UnityEngine;

public class SwingingBladeTrap : MonoBehaviour
{
    public float swingAngle = 60f;
    public float swingSpeed = 2f;
    private Quaternion startRotation;


    [Header("Swing Audio Settings")]
    public float swingInterval = 3f;
    private float swingstepTimer;

    public AudioSource swing;

    AudioManager audioManager;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
        startRotation = transform.localRotation;
    }

    // Update is called once per frame
    void Update()
    {
        float angle = Mathf.Sin(Time.time * swingSpeed) * swingAngle;
        transform.localRotation = startRotation * Quaternion.Euler(0, 0, angle);

        HandleSwingAudio();
    }

    private void HandleSwingAudio()
    {
        if (audioManager != null && audioManager.isSoundOn)
        {
            swingstepTimer -= Time.deltaTime;

            if (swingstepTimer <= 0f)
            {
                if (!swing.isPlaying)
                {
                    swing.Play();
                }

                swingstepTimer = swingInterval;
            }
        }
        else
        {
            swing.Stop();
            swingstepTimer = 0f;
        }
    }


}