using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class Level1_counter : MonoBehaviour {
	public static int gameCount = 0;
	void Awake() {
		//DontDestroyOnLoad (this);
	}
	// Use this for initialization
	void Start () {
		if (SceneManager.GetActiveScene ().name == "level1") {
			gameCount++;
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
