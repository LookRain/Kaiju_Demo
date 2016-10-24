using UnityEngine;
using System.Collections;

public class building_sort_layer : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void LateUpdate()
    {

        GetComponent<SpriteRenderer>().sortingOrder = -(int)(transform.position.y);
    }
}
