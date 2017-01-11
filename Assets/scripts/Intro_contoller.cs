using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class Intro_contoller : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (SceneManager.GetActiveScene ().name == "intro") {
			if (Input.GetKey (KeyCode.Escape)) {
				Application.Quit ();
			}
		}
		if (!Input.GetKey (KeyCode.Escape) && Input.anyKeyDown) {
			if (Input.GetMouseButtonDown (0) || Input.GetMouseButtonDown (1)) { // add more mouse buttons if needed
				// Do nothing
			} else {
				//SceneManager.SetActiveScene (SceneManager.GetSceneByName("Level1"));
				SceneManager.LoadScene ("starting_story");
			}
		}
	}
}
