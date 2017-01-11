using UnityEngine;
using System.Collections;

public class Level3_counter : MonoBehaviour {
	public static int gameCount;
	void Awake() {
		DontDestroyOnLoad (this);
	}
	// Use this for initialization
	void Start () {
		gameCount++;
	}

	// Update is called once per frame
	void Update () {

	}
}
