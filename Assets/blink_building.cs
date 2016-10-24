using UnityEngine;
using System.Collections;

public class blink_building : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        StartCoroutine(DoBlinks(3f, 0.3f));

    }
    void LateUpdate()
    {

        GetComponent<SpriteRenderer>().sortingOrder = -(int)(transform.position.y);
    }

    IEnumerator DoBlinks(float duration, float blinkTime)
    {
        while (duration > 0f)
        {
            duration -= Time.deltaTime;

            //toggle renderer
            gameObject.GetComponent<Renderer>().material.color = Color.yellow;
            yield return new WaitForSeconds(blinkTime);
            gameObject.GetComponent<Renderer>().material.color = Color.white;
            yield return new WaitForSeconds(blinkTime);

            //wait for a bit

        }

        //make sure renderer is enabled when we exit
        gameObject.GetComponent<Renderer>().material.color = Color.white;
    }
}
