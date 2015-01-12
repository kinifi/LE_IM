using UnityEngine;
using System.Collections;

public class ShaddowBox : MonoBehaviour {

	private Vector3 moveForward = new Vector3(-10.0f, 10.0f, 0.0f);
	private Vector3 shaddowJump = new Vector3(0.0f, 15.0f, 0f);

	//Forward Configs
	public float moveSpeed = 3.0f;
	public float maxSpeed = 3.0f;
	private float nextForwardJump;
	private bool facingRight = true;
	private bool canFlip = true;

	//Bounce configs
	public float jumpRate = 2.0f;
	private float nextJump;

	//Death configs
	public GameObject kill;
	public GameObject deathSplash;
	public GameObject bowGolden;

	//Audio Configs
	public AudioClip[] voices;

	//Anaimation Configs
	public GameObject splash;



	void Update()
	{
		if(Mathf.Abs(rigidbody2D.velocity.x) < Mathf.Abs(maxSpeed))
		{
			if(this.gameObject.name == "ShaddowForward" && Time.time > nextForwardJump)
			{
				nextForwardJump = Time.time + jumpRate;
				rigidbody2D.AddForce(moveForward * moveSpeed);
				Invoke("PlaySquish", 0.01f);
			}
			else if(this.gameObject.name == "ShaddowBounce" && Time.time > nextJump)
			{
				nextJump = Time.time + jumpRate;
				Bounce();
				Invoke("PlaySquish", 1.0f);
				//Debug.Log ("Bounce was called");
			}
		}
	}
	
	/*private void AllowRobbesMovement() 
	{
		//Find Robbe and allow his movement again.  Turn kinematic to false.
		RobbeController _robbe = GameObject.Find("Player").GetComponent<RobbeController>();
		_robbe.enabled = true;

		//Find the LookDown camera and allow its movement.
		NoFaithController _lookdown = GameObject.Find("Camera").GetComponent<NoFaithController>();
		_lookdown.enabled = true;
	}*/

	void OnTriggerEnter2D (Collider2D other)
	{
		if(other.gameObject.tag == "Arrow")
		{
			//start animation
			Instantiate(splash, this.gameObject.transform.position, Quaternion.identity);
			//play audio
			audio.PlayOneShot(voices[1], 1.0f);
			//grab position for bow drop
			Vector3 pos = transform.position;
			//destroy arrow
			Destroy(other.gameObject);
			//chance of drop
			int drop = Random.Range(1,6);
			//drop
			if(drop == 5)
			{
				Instantiate(bowGolden, pos, Quaternion.identity);
			}
			//destroy object
			Invoke ("DestroyObj", 0.05f);
		}

		if(other.gameObject.tag == "Player")
		{
//			Transform currentTransform = GameObject.Find("Player").GetComponent<Transform>();
			if(kill == null)
			{
				//Debug.Log ("You were killed by a bad guy!!");

				//Failsafe enable movement
				GameObject.Find("Player").GetComponent<RobbeController>().DelayAllowMovement();
				
				/*	//Find Robbe's gameobject and set his transform to the Spawn Location.
				GameObject resetRobbe = GameObject.Find ("Player");
				GameObject respawn = GameObject.Find("Spawn_Location");
				resetRobbe.transform.position = respawn.transform.position;
				
				//Find Robbe's controller and prevent his movement.
				RobbeController _robbe = GameObject.Find("Player").GetComponent<RobbeController>();
				_robbe.enabled = false;
				
				//Find the LookDown camera and prevent its movement.
				NoFaithController _lookdown = GameObject.Find("Camera").GetComponent<NoFaithController>();
				_lookdown.enabled = false;*/
				
				//Instantiate the death splash and overlay Robbe.  Destroy it and call the movement function.
				GameObject resetRobbe = GameObject.Find ("Player");
				kill = Instantiate(deathSplash, resetRobbe.transform.position, Quaternion.identity) as GameObject;
				kill.transform.OverlayPosition(resetRobbe.transform);
				kill.transform.localScale = new Vector3(50.0f,50.0f,1.0f);
				
				Destroy(kill, 1.0f);
			}
		}
		
		if(other.gameObject.layer != 12 && other.gameObject.layer != 15)
		{
			if(this.gameObject.name == "ShaddowForward" && canFlip == true)
			{
				AboutFace();
				//Debug.Log ("AboutFace was called");
			}
		}
	}
	
	void AboutFace()
	{
		if(facingRight)
		{
			canFlip = false;
			moveForward = new Vector3(3.0f, 10.0f, 0.0f);
			facingRight = !facingRight;
			Invoke ("CanFlipTrue", 0.5f);
		}
		else if(!facingRight)
		{
			canFlip = false;
			moveForward = new Vector3(-3.0f, 10.0f, 0.0f);
			facingRight = true;
			Invoke ("CanFlipTrue", 0.5f);
		}
		//Debug.Log("AboutFace Ran!!!!!!!!!");
	}
	
	void Bounce()
	{
		rigidbody2D.AddForce(shaddowJump * moveSpeed *2);
		Invoke("PlaySquish", 0.75f);
		//Debug.Log("Bounce Ran!!!!!!!!!");
	}

	void PlaySquish ()
	{
		audio.PlayOneShot(voices[0]);
	}

	void DestroyObj ()
	{
		//Destroy obj
		Destroy(this.gameObject);
	}

	void CanFlipTrue()
	{
		canFlip = true;
	}
}
