using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class introController : MonoBehaviour {
	public Image start1, start2;
	private Color c;
	// Use this for initialization
	void Start () {
		c = start1.color;
		StartCoroutine ("MyCoroutine");
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	IEnumerator MyCoroutine() {
		while (true) {
			c.a = 100;
			start1.color = c;
			yield return new WaitForSeconds (1);
			c.a = 0;
			start1.color = c;
		}

	}	
}
