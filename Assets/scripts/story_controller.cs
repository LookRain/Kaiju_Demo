using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class story_controller: MonoBehaviour {
	private Image img;
	public GameObject board1, board2, board3, board4, board5, board6, board7, board8;
	private int counter;
	// Use this for initialization
	void Start() {

		counter = 0;
	}

	// Update is called once per frame
	void Update() {
		if (Input.anyKeyDown) {
			if (Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1)) { // add more mouse buttons if needed
				// Do nothing
			} else {
				counter++;
			}
		}
		//SceneManager.SetActiveScene (SceneManager.GetSceneByName("Level1"));
		if (counter == 1) {
			board1.SetActive(false);
		}
		if (counter == 2) {
			board2.SetActive(false);
		}
		if (counter == 3) {
			board3.SetActive(false);
		}
		if (counter == 4) {
			board4.SetActive(false);
		}
		if (counter == 5) {
			board5.SetActive(false);
		}
		if (counter == 6) {
			if (SceneManager.GetActiveScene().name == "starting_story") {
				board6.SetActive(false);

			} else if (SceneManager.GetActiveScene().name == "ending_story") {
				board7.SetActive(true);
				board8.SetActive (true);
			}
		}
		if (counter == 7) {
			if (SceneManager.GetActiveScene ().name == "starting_story") {
				board7.SetActive (false);
			}else if (SceneManager.GetActiveScene().name == "ending_story") {
				SceneManager.LoadScene("intro");
			}
		}
		if (counter == 8) {
			if (SceneManager.GetActiveScene().name == "starting_story") {
				SceneManager.LoadScene("level1_cut_scene");

			}

		}

	}

}