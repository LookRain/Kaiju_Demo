using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class guilt_bar_controller : MonoBehaviour {
	public Sprite[] guiltSprites;

	public Image guiltBar;
	private int guilt;
	// Use this for initialization
	void Start () {
		guilt = player_movement.currentGuilt;
	}
	
	// Update is called once per frame
	void Update () {
		guilt = player_movement.currentGuilt;
		if (player_movement.currentGuilt >= guiltSprites.Length) {
			guilt = guiltSprites.Length - 1;
		}
		guiltBar.sprite = guiltSprites [guilt];

	}
}
