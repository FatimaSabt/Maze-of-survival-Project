using UnityEngine;

public class FloorSpikeTrap : MonoBehaviour
{
    public Transform spikes;

    public Vector3 hiddenPos;
    public Vector3 raisedPos;

    public float waitTime;

    public float riseSpeed;
    public float lowerSpeed ;

    public float activeTime;

    void Start()
    {
        spikes.position = hiddenPos;
        StartCoroutine(TrapLoop());
    }

    System.Collections.IEnumerator TrapLoop()
    {
        while (true)
        {
            yield return new WaitForSeconds(waitTime);

            // Fast stab upward
            yield return MoveSpike(raisedPos, riseSpeed);

            yield return new WaitForSeconds(activeTime);

            // Slower retract
            yield return MoveSpike(hiddenPos, lowerSpeed);
        }
    }

    System.Collections.IEnumerator MoveSpike(Vector3 target, float speed)
    {
        while (Vector3.Distance(spikes.position, target) > .01f)
        {
            spikes.position = Vector3.MoveTowards(
                spikes.position,
                target,
                speed * Time.deltaTime
            );

            yield return null;
        }
    }
}