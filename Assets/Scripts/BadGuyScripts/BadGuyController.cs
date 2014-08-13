using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BadGuyController : MonoBehaviour {
	
	private Vector3 moveForward = new Vector3(-1.0f, 0.0f, 0.0f);
	private Vector3 moveUp = new Vector3(0.0f, -1.0f, 0f);

	public float moveSpeed = 5.0f;
	public float maxSpeed = 5.0f;

	private bool faceRight = true;
	private bool ignoreCollisionFlip = false;
	private bool faceUp = true;
	private bool ignoreCollisionFlipUp = false;


	public GameObject kill;
	public GameObject deathSplash;
	public GameObject bowGolden;

	void Update()
	{
		if(Mathf.Abs(rigidbody2D.velocity.x) < Mathf.Abs(maxSpeed))
		{
			if(this.gameObject.tag == "BadGuy")
			{
				rigidbody2D.AddForce(moveForward * moveSpeed);
			}
			else if(this.gameObject.tag == "BadGuyVert")
			{
				rigidbody2D.AddForce(moveUp * moveSpeed);
			}
		}
	}
	
	void OnCollisionEnter2D (Collision2D player) 
	{
		if(player.gameObject.tag == "Player")
		{

			Transform currentTransform = GameObject.Find("Player").GetComponent<Transform>();
			if(kill == null)
			{
				//Debug.Log ("You were killed by a bad guy!!");

				//Find Robbe's gameobject and set his transform to the entrance.
				GameObject resetRobbe = GameObject.Find ("Player");
				Vector2 resetTransform = new Vector2(-3.5f, -0.9f);
				Vector3 resetScale = new Vector3(1.0f, 1.0f, 1.0f);
				resetRobbe.transform.position = resetTransform;

				//Set his scale to facing forward.
				resetRobbe.transform.localScale = resetScale;
				
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
				Destroy(kill, 2.5f);
				Invoke("AllowRobbesMovement", 2.5f);
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
			Destroy(this.gameObject);
			
			int drop = Random.Range(1,6);
			if(drop == 5)
			{
				Instantiate(bowGolden, pos, Quaternion.identity);
			}
		}

		if(other.gameObject.layer != 12 && other.gameObject.layer != 15)
		{
			if(this.gameObject.tag == "BadGuy")
			{
				ignoreCollisionFlip = true;
				Flip();
				//Debug.Log ("Flip was called");
			}
			else if(this.gameObject.tag == "BadGuyVert")
			{
				ignoreCollisionFlipUp = true;
				FlipUp();
				//Debug.Log ("FlipUp was called");
			}
		}
	}
	
	void Flip()
	{
		faceRight = !faceRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		moveForward *= -1;
		transform.localScale = theScale;
		ignoreCollisionFlip = false;
		//Debug.Log ("Flip ran and moveForward is now: " + moveForward);
	}

	void FlipUp()
	{
		faceUp = !faceUp;
		moveUp *= -1;
		ignoreCollisionFlipUp = false;
		//Debug.Log ("FlipUp ran and moveUp is now: " + moveUp);
	}
}
