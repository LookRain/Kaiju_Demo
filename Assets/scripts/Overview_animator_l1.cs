using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Overview_animator_l1 : MonoBehaviour {

	Camera mycam;


	private Animator ani;



	// Use this for initialization

	void Start () {
		ani = GetComponent<Animator> ();
		StartCoroutine ("MyCoroutine");
		//SceneManager.LoadScene ("level1");
	}


	IEnumerator MyCoroutine() {


		//ani.Stop();
		yield return new WaitForSeconds (10);
		//ani.SetActive (false);
		ani.Stop();
		if (SceneManager.GetActiveScene ().name.Contains ("1")) {
			SceneManager.LoadScene ("level1");
		}
		if (SceneManager.GetActiveScene ().name.Contains ("2")) {
			SceneManager.LoadScene ("level2");
		}
		if (SceneManager.GetActiveScene ().name.Contains ("3")) {
			SceneManager.LoadScene ("level3");
		}


	}





	// Update is called once per frame
	void Update () {
	}


}
