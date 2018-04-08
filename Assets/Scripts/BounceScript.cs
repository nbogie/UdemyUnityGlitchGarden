using UnityEngine;

public class BounceScript : MonoBehaviour
{
    Vector3 originalPosition;

    private void Start()
    {
        originalPosition = transform.position;
    }

    [Range(0.1f, 10f)]
    public float speed = 1f;

    [Range(0f, 2f)]
    public float phase = 0f;

    [Range(0.1f, 50f)]
    public float range = 0.1f;

    void Update()
    {
        float ph = phase * 90 * Mathf.Deg2Rad;

        float amt = range * Mathf.Sin(ph + Time.timeSinceLevelLoad * speed);
        //relative to the parent
        transform.localPosition = transform.up * amt;
    }

}
