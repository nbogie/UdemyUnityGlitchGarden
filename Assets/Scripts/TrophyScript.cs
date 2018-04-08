using UnityEngine;

public class TrophyScript : MonoBehaviour {
    [Range(0.1f, 10f)]
    public float swaySpeed = 1f;
	
	void Update () {

        Quaternion rot = Quaternion.identity;
        float angle = 0.5f * Mathf.Rad2Deg * Mathf.Sin(Time.timeSinceLevelLoad * swaySpeed);
        rot.eulerAngles = new Vector3(0, 0, angle);
        transform.rotation = rot;

	}

}
