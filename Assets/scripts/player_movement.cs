using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class player_movement : MonoBehaviour {

    Rigidbody2D rbody;
    Animator anim;


	public int numFlowerToPass;
	public static int flowerNo;
    public Text guiltText;
    public Text winText;
    public Text loseText;
    public Text timeText;
	public Text flowerText;
    public CamearShake shaker;
    public static bool isEnded;
	public AudioSource collision_sound, squish_sound, flower_sound, sweet_sound;
    public float timeRemaining = 60;
    public static int currentGuilt;
    public int maxGuilt = 10;
    public int guiltTrigger1 = 3;
    public int guiltTrigger2 = 5;
    public int initSpeed = 10;
	private float speed;
    public GameObject ruin1, ruin2, ruin3, ruin4, ruin5, ruin6, ruin7;
    private Vector2 vectorforobject;
    private ArrayList ruinList = new ArrayList();
    private string[] triggerList = new string[] { "building_trig_1", "building_trig_2", "building_trig_3",
    "building_trig_4","building_trig_5","building_trig_6","building_trig_7"};
    public int playerState;
    public int speedState;
	public GameObject explosionGO;
	public static bool isGoing;
	public GameObject gateClosed, gateOpen;
	public static bool forePlay;
	public static bool playingOverview;
	//public GameObject overview_amt;
	public GameObject pauseScreen, helpScreen, lostScreen;
	private bool isHelping;
	public GameObject dialogSys;
	public Text speech;
	private bool playingDialog;
    // Use this for initialization
	private int peopleCount, carCount, buildingCount, sweetCount, flowerCount;
	//public Text monitor;
	private int c;

    void Start () {
		forePlay = true;
		isHelping = false;
		playingDialog = false;
		peopleCount = 0;
		carCount = 0;
		buildingCount = 0;
		sweetCount = 0;
		flowerCount = 0;
		c = 1;
//		monitor.text = "game count is: " + Level1_counter.gameCount;



		flowerNo = 0;
        currentGuilt = 0;
        playerState = 0;
        speedState = 0;
		speed = (float)initSpeed;
       
        rbody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        setGuiltText();
       // Debug.Log(currentGuilt);
        isEnded = false;
		isGoing = true;
		//Vector2 currentPos = rbody.position;
		//rbody.position = currentPos + new Vector2 (0, 1);
		anim.SetBool("is_walking", true);
	
		anim.SetFloat("input_y", -1);
	
		anim.SetBool("is_walking", false);

        ruinList.Add(ruin1);
        ruinList.Add(ruin2);
        ruinList.Add(ruin3);
        ruinList.Add(ruin4);
        ruinList.Add(ruin5);
        ruinList.Add(ruin6);
        ruinList.Add(ruin7);
       
        // ruinList.Add(ruin);
        winText.text = "";
        loseText.text = "";
        timeText.text = ""+Mathf.Round(timeRemaining);
		flowerText.text = 0 + " / " + numFlowerToPass;


    }

    

    void setGuiltText()
    {
        guiltText.text = "Guilt Level: " + currentGuilt + "/" + maxGuilt;
    }

	void deternmineState() {
		if (currentGuilt < guiltTrigger1) {
			playerState = 0;
		}
		if (currentGuilt >= guiltTrigger1 && currentGuilt < guiltTrigger2) {
			playerState = 1;
		}
		if (currentGuilt >= guiltTrigger2) {
			playerState = 2;
		}
	}
	void determineSizeAndSpeed() {
		if (playerState == 0) {
			transform.localScale = new Vector3(0.35f,0.35f,0.5f);
			speed = (float)initSpeed;
		 
		}
		if (playerState == 1) {
			transform.localScale = new Vector3(0.49f,0.49f,0.7f);
			speed = (float)initSpeed / 2f;
		}
		if (playerState == 2) {
			transform.localScale = new Vector3(0.686f,0.686f,0.98f);;
			speed = (float)initSpeed / 3.5f;
		}
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
            this.shaker.Shake(0.12f);
            collision_sound.Play();
			if (col.gameObject.tag == "building_trig_1") {
				vectorforobject = col.transform.position;
				Instantiate(ruin1, vectorforobject, Quaternion.identity);
			}
			if (col.gameObject.tag == "building_trig_2") {
				vectorforobject = col.transform.position;
				Instantiate(ruin2, vectorforobject, Quaternion.identity);
			}
			if (col.gameObject.tag == "building_trig_3") {
				vectorforobject = col.transform.position;
				Instantiate(ruin3, vectorforobject, Quaternion.identity);
			}
			if (col.gameObject.tag == "building_trig_4") {
				vectorforobject = col.transform.position;
				Instantiate(ruin4, vectorforobject, Quaternion.identity);
			}
			if (col.gameObject.tag == "building_trig_5") {
				vectorforobject = col.transform.position;
				Instantiate(ruin5, vectorforobject, Quaternion.identity);
			}
			if (col.gameObject.tag == "building_trig_6") {
				vectorforobject = col.transform.position;
				Instantiate(ruin6, vectorforobject, Quaternion.identity);
			}
			if (col.gameObject.tag == "building_trig_7") {
				vectorforobject = col.transform.position;
				Instantiate(ruin7, vectorforobject, Quaternion.identity);
			}


              
                    currentGuilt++;

                    vectorforobject = col.transform.position;
                   
					Instantiate(explosionGO, vectorforobject, Quaternion.identity);


					explosionGO.transform.position = col.gameObject.transform.position;

                    timeRemaining -= 5;
                    Destroy(col.gameObject);
			buildingCount++;

			if (SceneManager.GetActiveScene ().name == "level1") {
				if (Level1_counter.gameCount == 1 && buildingCount == 1) {
					playingDialog = true;
					dialogSys.SetActive (true);
					speech.text = "Oh my stepping on these buildings is making me puff up with guilt! I better avoid them!";
					Time.timeScale = 0;
				}
			}
    
              

        }
		if (col.gameObject.tag == "people_trig")
		{

			squish_sound.Play ();
			timeRemaining -= 3;
			Debug.Log("people collided");
			squish_sound.Play ();
			Destroy(col.gameObject);
			currentGuilt++;
			peopleCount++;
			//DIALOGUE ONLY IN LEVEL 1 AND FIRST GAME COUNT

			if (SceneManager.GetActiveScene ().name == "level1") {
				if (Level1_counter.gameCount == 1 && peopleCount == 1) {
					playingDialog = true;
					dialogSys.SetActive (true);
					speech.text = "Oh my stepping on these people is making me puff up with guilt! I better avoid them!";
					Time.timeScale = 0;
				}
			}

		}
        if (col.gameObject.tag == "win_trig")
        {
			if (flowerNo >= numFlowerToPass) {
				//winText.text = "You Won!";
				if (SceneManager.GetActiveScene ().name.Contains ("1")) {
					SceneManager.LoadScene ("level2_cut_scene");
				}
				if (SceneManager.GetActiveScene ().name.Contains ("2")) {
					SceneManager.LoadScene ("level3_cut_scene");
				}
				if (SceneManager.GetActiveScene ().name.Contains ("3")) {
					SceneManager.LoadScene ("ending_story");
				}

				isEnded = true;
			}
        }
		if (col.gameObject.tag == "gate" && flowerNo < numFlowerToPass)
		{
				playingDialog = true;
				dialogSys.SetActive (true);
				speech.text = "I haven't collected enough flowers for my mum!";
				Time.timeScale = 0;

		}

        if (col.gameObject.tag == "car_trig")
        {
			vectorforobject = col.transform.position;
            this.shaker.Shake(0.1f);
            collision_sound.Play();
			Instantiate(explosionGO, vectorforobject, Quaternion.identity);
            Debug.Log("car collided");
            Destroy(col.gameObject);
            currentGuilt++;
			carCount++;

			if (SceneManager.GetActiveScene ().name == "level1") {
				if (Level1_counter.gameCount == 1 && carCount == 1) {
					playingDialog = true;
					dialogSys.SetActive (true);
					speech.text = "I just killed a car!!";
					Time.timeScale = 0;
				}
			}

        }
		if (col.gameObject.tag == "sweet_trig") 
		{
			if (currentGuilt <= 3) {
				currentGuilt = 0;
			} else {
				currentGuilt -= 3;
			}
			Destroy (col.gameObject);
			sweetCount++;
			sweet_sound.Play ();
			if (SceneManager.GetActiveScene ().name == "level1") {
				if (Level1_counter.gameCount == 1 && sweetCount == 1) {
					playingDialog = true;
					dialogSys.SetActive (true);
					speech.text = "Ahhh... these sweets make me feel so good! I feel less guilty now.";
					Time.timeScale = 0;
				}
			}

		}
		if (col.gameObject.tag == "flower_trig") 
		{
			flowerNo++;
			Destroy (col.gameObject);
			flowerCount++;
			flower_sound.Play ();
			if (SceneManager.GetActiveScene ().name == "level1") {
				if (Level1_counter.gameCount == 1 && flowerCount == 1) {
					playingDialog = true;
					dialogSys.SetActive (true);
					speech.text = "Such a pretty flower! mum will love it! I need to collected enough of them for my mum!";
					Time.timeScale = 0;
				}
			}

		}


    }
	
	// Update is called once per frame
	void Update () {
//		monitor.text = "game count is: " + Level1_counter.gameCount;
//		Debug.Log ("game count is: " + Level1_counter.gameCount);
		//Debug.Log ("isGoing: " + isGoing);
		if (playingDialog) {
			if (Input.GetKeyDown (KeyCode.Space)) {  
				Time.timeScale = 1;
				dialogSys.SetActive (false);
				playingDialog = false;
			}

		}
	
		if (!isGoing) {	//if game is paused
			
			isHelping = false;	//makes sure that helping screen should no appear

			if (Input.GetKeyDown (KeyCode.H)) {  //consumes H key input
			}
			if (Input.GetKeyDown (KeyCode.P)) {  //is P is pressed, unpause the game, set isGOing to true, removes pause screen
				Time.timeScale = 1;
				isGoing = true;
				pauseScreen.SetActive (false);
			}
			if (Input.GetKeyDown (KeyCode.Escape)) {  //is P is pressed, unpause the game, set isGOing to true, removes pause screen
				SceneManager.LoadScene("intro");
			}
		} else {	// if game is on going
			if (!isHelping) {
				if (Input.GetKeyDown (KeyCode.P)) {  // if P is pressed, pause the game, set isGOing to false, call up pause screen
					Time.timeScale = 0;
					isGoing = false;
					pauseScreen.SetActive (true);
				}

				if (Input.GetKeyDown (KeyCode.H)) {
					Time.timeScale = 0;
					isHelping = true;
					helpScreen.SetActive (true);
				}
			

			} else {
				if (Input.GetKeyDown (KeyCode.H)) {
					Time.timeScale = 1;
					isHelping = false;
					helpScreen.SetActive (false);
				}
			}
		}






		//Debug.Log ("Level1 count: " + Level_counter.Level1_Count + "playingOverview: " + playingOverview);
		deternmineState();
		determineSizeAndSpeed ();
		if (Input.GetKeyDown(KeyCode.R) && !playingDialog && !isHelping && isGoing)	//reload current level
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }


        if (isEnded)
        {
            anim.SetBool("is_walking", false);
			Vector2 currentPos = rbody.position;

        }


		if (!isEnded && isGoing)
        {

            timeRemaining -= Time.deltaTime;
            if (timeRemaining > 0)
            {
                timeText.text = ""+Mathf.Round(timeRemaining);
            }
            else
            {
                timeText.text = ""+0;
            }

			flowerText.text = flowerNo + " / " + numFlowerToPass;
			if (flowerNo >= numFlowerToPass) {
				gateClosed.SetActive (false);
				gateOpen.SetActive (true);
			}

            if (currentGuilt >= maxGuilt || timeRemaining <= 0)
            {
                //winText.text = "You Lost :(";
				lostScreen.SetActive (true);
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
