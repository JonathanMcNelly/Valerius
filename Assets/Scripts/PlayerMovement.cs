using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour {

	public Animator anim;
	public Rigidbody2D rbody;
	[HideInInspector]
	public Vector3 position;
	public float speed; //determines speed of player character
	public bool isDead; //determines whether player is dead
	[HideInInspector]
	public float Horizontal, Vertical;
	public float combine;
	[HideInInspector]
	public static int currentScene;
	public bool issafe, iscleaning;
	public bool canMove = true;
	float countDown = 0.4f;
	public Transform orientation;
	[HideInInspector]
	public Vector2 movement_vector;
	//public bool cutscene;
	public float Initial_Y, Initial_X;
	[HideInInspector]
	public bool interactionDialogue;
	public bool isPaused;


	public string faceDirection = "";



	// Use this for initialization
	void Start () {

		/*if (StairManager.Stair == null)
		{
			position = GameController.lastPosition[SceneManager.GetActiveScene().buildIndex];

		}
		else if (StairManager.Stair.Equals("Left"))
		{
			position = GameObject.FindGameObjectWithTag("LeftSpawn").transform.position;
		}
		else if (StairManager.Stair.Equals("Right"))
		{
			position = GameObject.FindGameObjectWithTag("RightSpawn").transform.position;
		}*/


		Debug.Log(position);
		if (position != Vector3.zero)
		{
			gameObject.transform.position = position;
		}


		/*
        if ()
        {
            gameObject.transform.position = GameController.lastPosition[SceneManager.GetActiveScene().buildIndex];
        }
        */

		isDead = false;
		issafe = true;
		//GameController.goal = false;
		rbody = GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator> ();
		anim.SetFloat ("Input_y", Initial_Y);
		anim.SetFloat ("Input_x", Initial_X);





	}

	void Update()
	{

		orient ();
		/*if (GenericInteraction.interact) {
			if (canMove) {


				if (Input.GetKeyDown (KeyCode.E)) {
					
					PlayerInteraction ();
				}
			}


		}

		if (Inventory.currentItem == Inventory.Items.Lantern) {
			GetComponentInChildren<Light> ().enabled = true;

		}
		else 
		{
			GetComponentInChildren<Light> ().enabled = false;

		}*/




	}


	// Update is called once per frame
	void FixedUpdate () {


		combine = Horizontal + Vertical;



		PlayerControl();

		/*if (!issafe && LightFlicker.fade) {

			if (countDown <= 0)
			{
				KillPlayer();
			}
			countDown -= Time.deltaTime;
			Debug.Log(countDown);
		}
		else
		{
			isDead = false;
			countDown = 1.0f;
		}*/
	}


	public virtual void PlayerControl () {

		if (!canMove)
		{
			rbody.velocity = Vector2.zero;
			//if (!cutscene) {
				//anim.SetBool ("isWalking", false);
			//}
			return;
		}

		Horizontal = Input.GetAxisRaw ("Horizontal");
		Vertical = Input.GetAxisRaw ("Vertical");


		movement_vector = new Vector2 (Horizontal, Vertical);
		if (movement_vector.magnitude > 1.0f)
		{
			movement_vector = movement_vector.normalized;
		}
		//aniamte movements
		if (movement_vector != Vector2.zero) { //if there is an input command
			anim.SetBool ("isWalking", true); //declare player as moving
			anim.SetFloat ("Input_x", movement_vector.x); //tell animator the value of vector.x
			anim.SetFloat ("Input_y", movement_vector.y); //tell animator the value of vector.y
		} else { //if there is no movement input, tell animator that the player is not moving.
			anim.SetBool ("isWalking", false);
		}

		rbody.velocity = !iscleaning ? movement_vector * speed : Vector2.zero;
		//update rbody position

	}

	public void orient()
	{
		if(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
		{
			faceDirection = "Up";
			orientation.rotation = Quaternion.identity;
		}
		if(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
		{
			faceDirection = "Left";
			orientation.rotation = Quaternion.Euler (transform.forward * 90);
		}
		if (Input.GetKey (KeyCode.S) || Input.GetKey (KeyCode.DownArrow)) {

			faceDirection = "Down";
			orientation.rotation = Quaternion.Euler (transform.forward * 180);
		}
		if(Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
		{
			faceDirection = "Right";
			orientation.rotation = Quaternion.Euler (transform.forward * 270);
		}

	}


	void KillPlayer()
	{
		isDead = true;
		canMove = false;
		rbody.velocity = Vector2.zero;
		anim.SetTrigger("Die");
		Debug.Log("Dead");
	}

	public void PlayerInteraction ()
	{
		
		if (faceDirection == "Up") {

			anim.SetTrigger ("InteractUp");
		}
		else if (faceDirection == "Down") {

			anim.SetTrigger ("InteractDown");
		}

		else if (faceDirection == "Left") {

			anim.SetTrigger ("InteractLeft");
		}

		else if (faceDirection == "Right") {

			anim.SetTrigger ("InteractRight");
		}

	}





}