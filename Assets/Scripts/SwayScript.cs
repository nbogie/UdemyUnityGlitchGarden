using UnityEngine;

public class SwayScript : MonoBehaviour {
    
    [Range(-10f, 10f)]
    public float swaySpeed = 1f;

    [Range(0f, 2f)]
    public float phase = 0f;

    [Range(0.1f, 1f)]
    public float range = 0.5f;

    void Update()
    {
        float ph = phase * 90 * Mathf.Deg2Rad;
        Quaternion rot = Quaternion.identity;
        float angle = range * Mathf.Rad2Deg * Mathf.Sin(ph + Time.timeSinceLevelLoad * swaySpeed);
        rot.eulerAngles = new Vector3(0, 0, angle);
        transform.localRotation = rot;

    }

}
