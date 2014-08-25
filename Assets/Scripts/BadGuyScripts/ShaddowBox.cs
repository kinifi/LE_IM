using UnityEngine;
using System.Collections;

public class ShaddowBox : MonoBehaviour {

	private Vector3 moveForward = new Vector3(-5.0f, 10.0f, 0.0f);
	private Vector3 shaddowJump = new Vector3(0.0f, 15.0f, 0f);
	
	public float moveSpeed = 3.0f;
	public float maxSpeed = 3.0f;
	private float nextForwardJump;
	private bool facingRight = true;

	public float jumpRate = 2.0f;
	private float nextJump;


	public GameObject kill;
	public GameObject deathSplash;
	public GameObject bowGolden;

	void Update()
	{
		if(Mathf.Abs(rigidbody2D.velocity.x) < Mathf.Abs(maxSpeed))
		{
			if(this.gameObject.name == "ShaddowForward" && Time.time > nextForwardJump)
			{
				nextForwardJump = Time.time + jumpRate;
				rigidbody2D.AddForce(moveForward * moveSpeed);
			}
			else if(this.gameObject.name == "ShaddowBounce" && Time.time > nextJump)
			{
				nextJump = Time.time + jumpRate;
				Bounce();
				//Debug.Log ("Bounce was called");
			}
		}
	}
	
	private void AllowRobbesMovement() 
	{
		//Find Robbe and allow his movement again.  Turn kinematic to false.
		FakeRobbeController _robbe = GameObject.Find("Player").GetComponent<FakeRobbeController>();
		_robbe.canMove = true;
		_robbe.rigidbody2D.isKinematic = false;
		
		//Find the LookDown camera and allow its movement.
		NoFaithController _lookdown = GameObject.Find("Camera").GetComponent<NoFaithController>();
		_lookdown.canMove = true;
	}

	void OnTriggerEnter2D (Collider2D other)
	{
		if(other.gameObject.tag == "Arrow")
		{
			Vector3 pos = transform.position;
			Destroy(other.gameObject);

			int drop = Random.Range(1,6);
			if(drop == 5)
			{
				Instantiate(bowGolden, pos, Quaternion.identity);
			}
			Destroy(gameObject);
		}

		if(other.gameObject.tag == "Player")
		{
			Transform currentTransform = GameObject.Find("Player").GetComponent<Transform>();
			if(kill == null)
			{
				//Debug.Log ("You were killed by a bad guy!!");
				
				//Find Robbe's gameobject and set his transform to the Spawn Location.
				GameObject resetRobbe = GameObject.Find ("Player");
				GameObject respawn = GameObject.Find("Spawn_Location");
				resetRobbe.transform.position = respawn.transform.position;
				
				//Set Robbe to Kinematic to zero out any velocity
				resetRobbe.rigidbody2D.isKinematic = true;
				
				//Find Robbe's controller and prevent his movement.
				FakeRobbeController _robbe = GameObject.Find("Player").GetComponent<FakeRobbeController>();
				_robbe.canMove = false;
				
				//Find the LookDown camera and prevent its movement.
				NoFaithController _lookdown = GameObject.Find("Camera").GetComponent<NoFaithController>();
				_lookdown.canMove = false;
				
				//Instantiate the death splash and overlay Robbe.  Destroy it and call the movement function.
				kill = Instantiate(deathSplash, resetRobbe.transform.position, Quaternion.identity) as GameObject;
				kill.transform.OverlayPosition(resetRobbe.transform);
				kill.transform.localScale = new Vector3(50.0f,50.0f,1.0f);
				
				Destroy(kill, 2.5f);
				Invoke("AllowRobbesMovement", 2.5f);
			}
		}
		
		if(other.gameObject.layer != 12 && other.gameObject.layer != 15)
		{
			if(this.gameObject.name == "ShaddowForward")
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
			moveForward = new Vector3(3.0f, 10.0f, 0.0f);
			facingRight = !facingRight;
		}
		else if(!facingRight)
		{
			moveForward = new Vector3(-3.0f, 10.0f, 0.0f);
			facingRight = true;
		}
		//Debug.Log("AboutFace Ran!!!!!!!!!");
	}
	
	void Bounce()
	{
		rigidbody2D.AddForce(shaddowJump * moveSpeed *2);
		//Debug.Log("Bounce Ran!!!!!!!!!");
	}
}
