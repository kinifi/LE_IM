using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BadGuyController : MonoBehaviour {
	

	private float moveSpeed = 3.0f;
	private bool faceRight = false;
	private bool faceUp = true;

	private bool isShot = false;

	public GameObject kill;
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
			
			if(kill == null)
			{
				//Let me know you were killed by a fire wisp
				//Debug.Log ("You were killed by a fire wisp!!" + this.gameObject.name);
				
				//Call Death Script on Player
				GameObject.Find("Player").GetComponent<RobbeController>().DelayAllowMovement();
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
			Destroy(gameObject, 0.5f);
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
