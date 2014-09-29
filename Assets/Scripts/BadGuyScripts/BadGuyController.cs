using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BadGuyController : MonoBehaviour {
	

	private float moveSpeed = 3.0f;
	private bool faceRight = false;
	private bool faceUp = true;

	public GameObject kill;
	public GameObject deathSplash;
	public GameObject bowGolden;

	//Components to get
	private BoxCollider2D _col;

	void Start()
	{
		if(this.gameObject.tag == "BadGuy")
		{
			BoxCollider2D[] _col = GetComponents<BoxCollider2D>();
			for(int i = 0; i < _col.Length; i++)
			{
				if(_col[i].center.y == 0.35f)
				{
					//Debug.Log ("Destroying "+_col[i].center.y);
					Destroy(_col[i]);
				}
				if(_col[i].center.y == -0.35f)
				{
					//Debug.Log ("Destroying "+_col[i].center.y);
					Destroy(_col[i]);
				}
			}

		}
		else if(this.gameObject.tag == "BadGuyVert")
		{
			BoxCollider2D[] _col = GetComponents<BoxCollider2D>();
			for(int i = 0; i < _col.Length; i++)
			{
				if(_col[i].center.x == 0.3f)
				{
					//Debug.Log ("Destroying "+_col[i].center.x);
					Destroy(_col[i]);
				}
				if(_col[i].center.x == -0.32f)
				{
					//Debug.Log ("Destroying "+_col[i].center.x);
					Destroy(_col[i]);
				}
			}
		}
	}

	void Update()
	{
		if(this.gameObject.tag == "BadGuy")
		{
			if(faceRight)
			{
				transform.Translate(Vector3.right * Time.deltaTime * moveSpeed);
			}
			else
			{
				transform.Translate(-Vector3.right * Time.deltaTime * moveSpeed);
			}

		}
		else if(this.gameObject.tag == "BadGuyVert")
		{
			if(faceUp)
			{
				transform.Translate(Vector3.up * Time.deltaTime * moveSpeed);
			}
			else
			{
				transform.Translate(-Vector3.up * Time.deltaTime * moveSpeed);
			}
		}
	}

	private void OnTriggerEnter2D (Collider2D other)
	{
		if(other.gameObject.tag == "Player")
		{
			//Stop all movement of the bad guy!!
			this.gameObject.rigidbody2D.isKinematic = true;
			
//			Transform currentTransform = GameObject.Find("Player").GetComponent<Transform>();
			if(kill == null)
			{
				//Debug.Log ("You were killed by a bad guy!!");
				
				//Find Robbe's gameobject and set his transform to the Spawn Location.
				GameObject resetRobbe = GameObject.Find ("Player");
				GameObject respawn = GameObject.Find("Spawn_Location");
				resetRobbe.transform.position = respawn.transform.position;
				
				//Find Robbe's controller and prevent his movement.
				RobbeController _robbe = GameObject.Find("Player").GetComponent<RobbeController>();
				_robbe.enabled = false;
				
				//Find the LookDown camera and prevent its movement.
				NoFaithController _lookdown = GameObject.Find("Camera").GetComponent<NoFaithController>();
				_lookdown.enabled = false;
				
				//Instantiate the death splash and overlay Robbe.  Destroy it and call the movement function.
				kill = Instantiate(deathSplash, resetRobbe.transform.position, Quaternion.identity) as GameObject;
				kill.transform.OverlayPosition(resetRobbe.transform);
				kill.transform.localScale = new Vector3(50.0f,50.0f,1.0f);
				
				Destroy(kill, 2.5f);
				Invoke("AllowRobbesMovement", 2.5f);
			}
		}

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

		if(other.gameObject.layer != 12 && other.gameObject.layer != 15 && other.gameObject.layer != 18)
		{
			if(this.gameObject.tag == "BadGuy")
			{
				Flip();
				//Debug.Log ("Flip was called");
			}
			else if(this.gameObject.tag == "BadGuyVert")
			{
				FlipUp();
				//Debug.Log ("FlipUp was called");
			}
		}
	}

	private void AllowRobbesMovement() 
	{
		//Allow movement of the bad guy again
		this.gameObject.rigidbody2D.isKinematic = false;
		
		//Find Robbe and allow his movement again.  Turn kinematic to false.
		RobbeController _robbe = GameObject.Find("Player").GetComponent<RobbeController>();
		_robbe.enabled = true;

		//Find the LookDown camera and allow its movement.
		NoFaithController _lookdown = GameObject.Find("Camera").GetComponent<NoFaithController>();
		_lookdown.enabled = true;
	}

	private void Flip()
	{
		faceRight = !faceRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
		//Debug.Log ("Flip ran and moveForward is now: " + moveForward);
	}

	private void FlipUp()
	{
		faceUp = !faceUp;
		//Debug.Log ("FlipUp ran and moveUp is now: " + moveUp);
	}
}
