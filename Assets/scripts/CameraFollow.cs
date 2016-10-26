using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

    public Transform target;
    public float m_speed = 0.1f;
    Camera mycam;
	// Use this for initialization

	void Start () {
        mycam = GetComponent<Camera>();

	}
	
	// Update is called once per frame
	void Update () {
        //mycam.orthographicSize = (Screen.height / 100f) / 0.0018f;
        if (target)
        {
			
            transform.position = Vector3.Lerp(transform.position, target.position, m_speed) + new Vector3(0,0,-10);
			transform.position = new Vector3(
				Mathf.Clamp(transform.position.x, -1350, 1350),
				Mathf.Clamp(transform.position.y, -5000, 10750),
				Mathf.Clamp(transform.position.z, -2000, 8000));

        }
	}


}
