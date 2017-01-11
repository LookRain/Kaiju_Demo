using UnityEngine;
using System.Collections;

public class people_walk_right : MonoBehaviour {
	public float movementSpeed = 5;
	private bool isAlive;
	Rigidbody2D rbody;
	bool isMoving;
	// Use this for initialization
	void Start () {
		isMoving = true;
		isAlive = true;
		rbody = GetComponent<Rigidbody2D>();
	}


	// Update is called once per frame
	void Update () {
		if (!isMoving) {
			return;
		}
		if (isMoving) {
			Vector2 movement_vector = new Vector2 (1, 0);
			rbody.MovePosition (rbody.position + movement_vector * Time.deltaTime * movementSpeed * 2800);
		}
	}

	void LateUpdate()
	{

		GetComponent<SpriteRenderer>().sortingOrder = -(int)(transform.position.y);
	}
}
