using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class player_movement2 : MonoBehaviour {

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
	public AudioSource collision_sound, squish_sound;
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



	// Use this for initialization


	void Start () {
		forePlay = true;
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
			this.shaker.Shake(0.2f);
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



		}
		if (col.gameObject.tag == "people_trig")
		{

			squish_sound.Play ();
			timeRemaining -= 3;
			Debug.Log("people collided");
			squish_sound.Play ();
			Destroy(col.gameObject);
			currentGuilt++;
		}
		if (col.gameObject.tag == "win_trig")
		{
			if (flowerNo >= numFlowerToPass) {
				winText.text = "You Won!";
				isEnded = true;
			}
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
		}
		if (col.gameObject.tag == "sweet_trig") 
		{
			if (currentGuilt <= 3) {
				currentGuilt = 0;
			} else {
				currentGuilt -= 3;
			}
			Destroy (col.gameObject);
		}
		if (col.gameObject.tag == "flower_trig") 
		{
			flowerNo++;
			Destroy (col.gameObject);
		}


	}

	// Update is called once per frame
	void Update () {
		Debug.Log ("isGoing: " + isGoing);
		deternmineState();
		determineSizeAndSpeed ();
		if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.R))
		{
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
		}
		if (Input.GetKeyDown(KeyCode.P) || Input.GetKeyDown(KeyCode.Space))
		{
			if (isGoing) {
				Time.timeScale = 0;
				isGoing = false;
			} else {
				Time.timeScale = 1;
				isGoing = true;
			}
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
