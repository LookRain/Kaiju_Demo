using UnityEngine;
using System.Collections;

public class player_movement : MonoBehaviour {

    Rigidbody2D rbody;
    Animator anim;
    public int currentGuilt, maxGuilt = 10;
    public int guiltTrigger1 = 4;
    public int guiltTrigger2 = 8;
    public int speed = 10;
    public GameObject ruin1, ruin2, ruin3, ruin4, ruin5, ruin6, ruin7, ruin8, ruin9, ruin10;
    private Vector2 vectorforobject;
    public ArrayList ruinList = new ArrayList();
    public string[] triggerList = new string[] { "building_trig_1", "building_trig_2", "building_trig_3",
    "building_trig_4","building_trig_5","building_trig_6","building_trig_7","building_trig_8","building_trig_9",
        "building_trig_10" };
    public int playerState;
    public int speedState;



    // Use this for initialization
    void Start () {
        rbody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        currentGuilt = 0;
        playerState = 0;
        speedState = 0;

        ruinList.Add(ruin1);
        ruinList.Add(ruin2);
        ruinList.Add(ruin3);
        ruinList.Add(ruin4);
        ruinList.Add(ruin5);
        ruinList.Add(ruin6);
        ruinList.Add(ruin7);
        ruinList.Add(ruin8);
        ruinList.Add(ruin9);
        ruinList.Add(ruin10);
        // ruinList.Add(ruin);
        


    }
    void CheckAndGrow()
    {
       if (playerState == 0)
        {
            if (currentGuilt >= guiltTrigger1)
            {
                
                transform.localScale = transform.localScale * 3 / 2;
                playerState = 1;
                
            }
        }
        if (playerState == 1)
            
        {
            if (speedState == 0)
            {
                speed = speed * 10 / 14;
                speedState = 1;
            }
            if (currentGuilt >= guiltTrigger2)
            {
                transform.localScale = transform.localScale * 3 / 2;
                playerState = 2;
            }
        }

        if (playerState == 2)

        {
            if (speedState == 1)
            {
                speed = speed * 10 / 14;
                speedState = 2;
            }
            if (currentGuilt >= maxGuilt)
            {
                //end game
            }
        }
    }
    void BuildingDestroy()
    {

    }
    void OnTriggerEnter2D(Collider2D col)
    {
        
        for (int i = 0; i < 10; i ++)
        {
            if (col.gameObject.tag == triggerList[i])
            {
                currentGuilt++;
                CheckAndGrow();
                vectorforobject = col.transform.position;
                GameObject ruinObject = (GameObject)ruinList[i];
                Instantiate(ruinObject, vectorforobject, Quaternion.identity);
                ruinObject.SetActive(true);
                Destroy(col.gameObject);
                Debug.Log(currentGuilt);
            }

            
        }
        

    }
	
	// Update is called once per frame
	void Update () {
        Vector2 movement_vector = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        if (movement_vector != Vector2.zero)
        {
            anim.SetBool("is_walking", true);
            anim.SetFloat("input_x", movement_vector.x);
            anim.SetFloat("input_y", movement_vector.y);
        } else
        {
            anim.SetBool("is_walking", false);
        }

        rbody.MovePosition(rbody.position + movement_vector * Time.deltaTime* speed * 800);
	}
}
