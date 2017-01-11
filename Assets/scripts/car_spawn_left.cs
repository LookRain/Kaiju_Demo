using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class car_spawn_left : MonoBehaviour {
	public Vector2 pos, pos2;
	public GameObject carPrefab,carPrefab2;
	public float interval_floor, interval_ceiling;
	private bool isEnded;
	public Text txt;
	private int cnt;
	// Use this for initialization
	void Start () {
		if (SceneManager.GetActiveScene ().name != "level1") {
			cnt = 0;
			//Vector2 pos = new Vector2(6505, 7138);
			StartCoroutine ("MyCoroutine");

			txt.text = name + " has started";
		}


	}

	IEnumerator MyCoroutine() {
		
		while (true) {				
//				Debug.Log (isEnded);
				
			SpawnCar (carPrefab,pos);
			SpawnCar (carPrefab2, pos2);
			float interval = Random.Range (interval_floor, interval_ceiling);
			cnt++;
			txt.text = name + " just spawned a car " + cnt;
				yield return new WaitForSeconds (interval);

			}
	

	}	

	void SpawnCar(GameObject go, Vector2 position) {
		Instantiate (go, position, Quaternion.identity);
	}
	// Update is called once per frame
	void Update () {
	
	}
}
