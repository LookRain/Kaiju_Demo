using UnityEngine;
using System.Collections;

public class car_movement : MonoBehaviour {
    public float movementSpeed = 5;
	public int direction;
    private bool isAlive;
    Rigidbody2D rbody;
	bool isMoving;

    // Use this for initialization
    void Start () {
		isMoving = true;
        isAlive = true;
        rbody = GetComponent<Rigidbody2D>();
    }
	IEnumerator wait() {
		
		isMoving = false;
		yield return new WaitForSeconds(9/10);
		isMoving = true;
	}

	// Update is called once per frame
	void Update () {
		if (!isMoving) {
			return;
		}
		if (isMoving) {

			Vector2 movement_vector = new Vector2 (direction, 0);
			rbody.MovePosition (rbody.position + movement_vector * Time.deltaTime * movementSpeed * 2800);
		}
		if (direction == 1) {
			if (transform.position.x >= 9501) {
				Destroy (gameObject);
			}

		}
		if (direction == -1) {
			if (transform.position.x <= -8401) {
				Destroy (gameObject);
			}

		}
    }
	void OnTriggerEnter2D(Collider2D col){
		if (col.gameObject.tag.Contains ("car")) {
			if (this.transform.position.x > col.transform.position.x) {

				StartCoroutine(wait());

			}
		}
	}

    void LateUpdate()
    {

        GetComponent<SpriteRenderer>().sortingOrder = -(int)(transform.position.y);
    }
}
