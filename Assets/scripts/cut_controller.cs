using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class cut_controller : MonoBehaviour {
	public GameObject cut_img;
	// Use this for initialization
	void Start () {
		
	}

	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey(KeyCode.Space)) {
			if (Input.GetMouseButtonDown (0) || Input.GetMouseButtonDown (1)) { // add more mouse buttons if needed
				// Do nothing
			} else {
				if (SceneManager.GetActiveScene ().name.Contains ("1")) {
					SceneManager.LoadScene ("level1_overview");
				}
				if (SceneManager.GetActiveScene ().name.Contains ("2")) {
					SceneManager.LoadScene ("level2_overview");
				}
				if (SceneManager.GetActiveScene ().name.Contains ("3")) {
					SceneManager.LoadScene ("level3_overview");
				}

			}
		}
	}
}
