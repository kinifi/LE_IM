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


	public GameObject killMe;
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
	
	void OnCollisionEnter2D (Collision2D player) 
	{
		if(player.gameObject.tag == "Player")
		{
			Transform currentTransform = GameObject.Find("Player").GetComponent<Transform>();
			if(killMe == null)
			{
				killMe = Instantiate(deathSplash, currentTransform.position, Quaternion.identity) as GameObject;
				//killMe.transform.parent = currentTransform;
				//Debug.Log ("You were killed by a bad guy!!");
				GameObject resetRobbe = GameObject.Find ("Player");

				Vector2 resetTransform = new Vector2(-3.95f, -1.0f);
				resetRobbe.transform.position = resetTransform;

				FakeRobbeController _robbe = GameObject.Find("Player").GetComponent<FakeRobbeController>();
				_robbe.canMove = false;

				killMe.transform.OverlayPosition(resetRobbe.transform);

				Destroy(killMe, 2.5f);
				Invoke("AllowRobbesMovement", 2.5f);
			}
		}
	}

	private void AllowRobbesMovement() {
		FakeRobbeController _robbe = GameObject.Find("Player").GetComponent<FakeRobbeController>();
		_robbe.canMove = true;
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
