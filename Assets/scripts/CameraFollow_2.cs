using UnityEngine;
using System.Collections;

public class CameraFollow_2 : MonoBehaviour {

	public Transform target;
	public float m_speed = 0.1f;
	Camera mycam;
	public int leftLimit,rightLimit, topLimit, botLimit;
	private Animator ani;



	// Use this for initialization

	void Start () {
		ani = GetComponent<Animator> ();

		player_movement2.forePlay = true;
		if (Level2_counter.gameCount > 1) {
			player_movement2.forePlay = false;
			ani.Stop ();
		} else {
			//player_movement2.isGoing = false;
		}
		Debug.Log (Level2_counter.gameCount);

		//transform.position = new Vector3 (500,13000,-13000);
		//transform.position = Vector3.Lerp (transform.position, target.position, m_speed) + new Vector3 (0, 0, -10);
		if (player_movement2.forePlay) {

			StartCoroutine ("MyCoroutine");


		}


		player_movement2.forePlay = false;


		mycam = GetComponent<Camera>();

		mycam.pixelRect = new Rect (0, 0, 1280, 720);

	}


	IEnumerator MyCoroutine() {
		player_movement2.isGoing = false;

		yield return new WaitForSeconds (6);
		ani.Stop();
		player_movement2.isGoing = true;
	}


	// Update is called once per frame
	void Update () {
		//mycam.orthographicSize = (Screen.height / 100f) / 0.003f;
		//mycam.orthographicSize = (Screen.width / 100f) / 0.008f;
		if (player_movement2.isGoing || !player_movement2.forePlay) {
			//transform.position = new Vector3 (500,13000,-13000);
			if (target) {
				//transform.position = new Vector3 (580.9758f,15690f,-100f);
				transform.position = Vector3.Lerp (transform.position, target.position, m_speed) + new Vector3 (0, 0, -1);
				//Debug.Log(transform.position.x + ", " + transform.position.y+", " + transform.position.z);
				//transform.position = new Vector3(
				//Mathf.Clamp(transform.position.x, leftLimit, rightLimit),
				//Mathf.Clamp(transform.position.y, botLimit, topLimit),
				//Mathf.Clamp(transform.position.z, -2000, 8000));

			}
		} else {
		}


	}


}
