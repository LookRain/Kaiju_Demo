using UnityEngine;
using System.Collections;

public class car_fast : MonoBehaviour {
	public float movementSpeed = 50;
	private bool isAlive;
	Rigidbody2D rbody;
	// Use this for initialization
	void Start () {
		isAlive = true;
		rbody = GetComponent<Rigidbody2D>();
	}

	// Update is called once per frame
	void Update () {
		Vector2 movement_vector = new Vector2(1,0);
		rbody.MovePosition(rbody.position + movement_vector * Time.deltaTime * movementSpeed * 800);

	}

	void LateUpdate()
	{

		GetComponent<SpriteRenderer>().sortingOrder = -(int)(transform.position.y);
	}
}
