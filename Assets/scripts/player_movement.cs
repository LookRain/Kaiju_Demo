using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class player_movement : MonoBehaviour {

    Rigidbody2D rbody;
    Animator anim;
    public Text guiltText;
    public Text winText;
    public Text loseText;
    public Text timeText;
    public CamearShake shaker;
    private bool isEnded;
    public AudioSource collision_sound;
    public float timeRemaining = 60;
    public int currentGuilt;
    public int maxGuilt = 10;
    public int guiltTrigger1 = 3;
    public int guiltTrigger2 = 5;
    public int speed = 10;
    public GameObject ruin1, ruin2, ruin3, ruin4, ruin5, ruin6, ruin7, ruin8, ruin9, ruin10,
        ruin11, ruin12, ruin13, ruin14, ruin15, ruin16, ruin17, ruin18, ruin19, ruin20;
    private Vector2 vectorforobject;
    private ArrayList ruinList = new ArrayList();
    private string[] triggerList = new string[] { "building_trig_1", "building_trig_2", "building_trig_3",
    "building_trig_4","building_trig_5","building_trig_6","building_trig_7","building_trig_8","building_trig_9",
        "building_trig_10", "building_trig_11", "building_trig_12", "building_trig_13",
    "building_trig_14","building_trig_15","building_trig_16","building_trig_17","building_trig_18","building_trig_19",
        "building_trig_20" };
    public int playerState;
    public int speedState;



    // Use this for initialization
    void Start () {
        currentGuilt = 0;
        playerState = 0;
        speedState = 0;
       
        rbody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        setGuiltText();
        Debug.Log(currentGuilt);
        isEnded = false;

       

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
        ruinList.Add(ruin11);
        ruinList.Add(ruin12);
        ruinList.Add(ruin13);
        ruinList.Add(ruin14);
        ruinList.Add(ruin15);
        ruinList.Add(ruin16);
        ruinList.Add(ruin17);
        ruinList.Add(ruin18);
        ruinList.Add(ruin19);
        ruinList.Add(ruin20);
        // ruinList.Add(ruin);
        winText.text = "";
        loseText.text = "";
        timeText.text = "Time Remaining: " + Mathf.Round(timeRemaining);


    }

    

    void setGuiltText()
    {
        guiltText.text = "Guilt Level: " + currentGuilt + "/" + maxGuilt;
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
                
            }
        }
        setGuiltText();
    }
   
   
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag.Contains("build"))
        {
            this.shaker.Shake(0.5f);
            collision_sound.Play();
            for (int i = 0; i < 20; i++)
            {
                if (col.gameObject.tag == triggerList[i])
                {
                    Debug.Log("building collided: " + i);
                    currentGuilt++;

                    vectorforobject = col.transform.position;
                    GameObject ruinObject = (GameObject)ruinList[i];
                    Instantiate(ruinObject, vectorforobject, Quaternion.identity);
                    ruinObject.SetActive(true);
                    ruinObject.transform.position = col.gameObject.transform.position;

                    timeRemaining -= 5;
                    Destroy(col.gameObject);
                    Debug.Log(currentGuilt);
                }
            }
        }
        if (col.gameObject.tag == "win_trig")
        {
            winText.text = "You Won!";
            isEnded = true;
        }

        if (col.gameObject.tag == "car_trig")
        {
            this.shaker.Shake(0.2f);
            collision_sound.Play();
            Debug.Log("car collided");
            Destroy(col.gameObject);
            currentGuilt++;
        }



    }
	
	// Update is called once per frame
	void Update () {
        CheckAndGrow();
        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        if (isEnded)
        {
            anim.SetBool("is_walking", false);
        }


        if (!isEnded)
        {

            timeRemaining -= Time.deltaTime;
            if (timeRemaining > 0)
            {
                timeText.text = "Time Remaining: " + Mathf.Round(timeRemaining);
            }
            else
            {
                timeText.text = "Time Remaining: " + 0;
            }

            if (currentGuilt >= maxGuilt || timeRemaining <= 0)
            {
                winText.text = "You Lost :(";
                isEnded = true;
            }

            Vector2 movement_vector = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
            if (movement_vector != Vector2.zero)
            {
                anim.SetBool("is_walking", true);
                anim.SetFloat("input_x", movement_vector.x);
                anim.SetFloat("input_y", movement_vector.y);
            }
            else
            {
                anim.SetBool("is_walking", false);
            }

            rbody.MovePosition(rbody.position + movement_vector * Time.deltaTime * speed * 800);
        }
	}
    void LateUpdate()
    {

        GetComponent<SpriteRenderer>().sortingOrder = -(int)(transform.position.y);
    }
}
