using UnityEngine;
using System.Collections;

public class people_right_spawner : MonoBehaviour {
	public Vector2 pos;
	public GameObject peopleRightPrefab1;
	public GameObject peopleRightPrefab2;
	public float interval_floor, interval_ceiling;
	private bool isEnded;
	// Use this for initialization
	void Start () {
		Vector2 pos = new Vector2(6505, 7138);
		StartCoroutine ("MyCoroutine");
		isEnded = player_movement.isEnded;
	}

	IEnumerator MyCoroutine() {
		while (!isEnded) {
			isEnded = player_movement.isEnded;
			Debug.Log (isEnded);
			int rand = (int)Mathf.Round(Random.Range (1,3));

			if (rand == 1) {
				SpawnPeople (peopleRightPrefab1, pos);
			} else if (rand == 2) {
				SpawnPeople (peopleRightPrefab2, pos);
			}
			float interval = Random.Range (interval_floor, interval_ceiling);


			yield return new WaitForSeconds (interval);
		}

	}	
	void SpawnPeople(GameObject go, Vector2 position) {
		Instantiate (go, position, Quaternion.identity);
	}
	// Update is called once per frame
	void Update () {

	}
}
