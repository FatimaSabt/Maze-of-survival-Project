using UnityEngine;
using System.Collections;

public class FloorSpikeTrap : MonoBehaviour
{
    public Transform spikes;

    public Vector3 hiddenPos;
    public Vector3 raisedPos;

    public float waitTime = 5f;
    public float riseSpeed = 10f;
    public float lowerSpeed = 4f;
    public float activeTime = 2f;

    void Start()
    {
        // Start the spikes in the hidden local position
        spikes.localPosition = hiddenPos;

        // Start the trap loop
        StartCoroutine(TrapLoop());
    }

    IEnumerator TrapLoop()
    {
        while (true)
        {
            // Wait before activating
            yield return new WaitForSeconds(waitTime);

            // Move spikes out
            yield return MoveSpike(raisedPos, riseSpeed);

            // Keep spikes active for a short time
            yield return new WaitForSeconds(activeTime);

            // Move spikes back in
            yield return MoveSpike(hiddenPos, lowerSpeed);
        }
    }

    IEnumerator MoveSpike(Vector3 target, float speed)
    {
        // Use localPosition here, not position
        while (Vector3.Distance(spikes.localPosition, target) > 0.01f)
        {
            spikes.localPosition = Vector3.MoveTowards(
                spikes.localPosition,
                target,
                speed * Time.deltaTime
            );

            yield return null;
        }

        // Snap exactly to target local position
        spikes.localPosition = target;
    }
}