using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Level_counter : MonoBehaviour {
	public static int Level1_Count;
	public static int Level2_Count;
	public static int Level3_Count;
	void Awake() {
		
	}
	// Use this for initialization
	void Start () {
		if (SceneManager.GetActiveScene ().name.Contains ("1")) {
			Level1_Count++;
		}
		if (SceneManager.GetActiveScene ().name.Contains ("2")) {
			Level2_Count++;
		}
		if (SceneManager.GetActiveScene ().name.Contains ("3")) {
			Level3_Count++;
		}
	}

	// Update is called once per frame
	void Update () {

	}
}
