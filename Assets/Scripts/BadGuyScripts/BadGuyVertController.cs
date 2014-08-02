using UnityEngine;
using System.Collections;

public class BadGuyVertController : MonoBehaviour {

	private Vector3 moveUp = new Vector3(0.0f, -1.0f, 0f);
	public float vertMoveSpeed = 5.0f;
	public float vertMaxSpeed = 5.0f;
	bool faceUp = true;
	public GameObject vertKilledMe;
	public GameObject deathSplash;
	public GameObject bowGolden;
	
	void Start ()
	{
		float speedGenerator = Random.Range(3.0f,5.0f);
		vertMoveSpeed = speedGenerator;
	}
	
	void Update()
	{
		if(Mathf.Abs(rigidbody2D.velocity.x) < Mathf.Abs(vertMaxSpeed))
		{
			rigidbody2D.AddForce(moveUp * vertMoveSpeed);
		}
	}
	
	void OnCollisionEnter2D (Collision2D player) 
	{
		if(player.gameObject.tag == "Player")
		{
			Transform currentTransform = GameObject.Find("FakeRobbe").GetComponent<Transform>();
			if(vertKilledMe == null)
			{
				vertKilledMe = Instantiate(deathSplash, currentTransform.position, Quaternion.identity) as GameObject;
				vertKilledMe.transform.parent = currentTransform;
				//Debug.Log ("You were killed by a bad guy!!");
				GameObject resetRobbe = GameObject.Find ("FakeRobbe");
				Vector2 resetTransform = new Vector2(-3.95f, -1.0f);
				resetRobbe.transform.position = resetTransform;
				Destroy(vertKilledMe, 2.0f);
			}
		}
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
			FlipUp();
			//Debug.Log ("FlipUp was called");
		}
	}

	void FlipUp()
	{
		faceUp = !faceUp;
		Vector3 theScale = transform.localScale;
		theScale.y *= -1;
		moveUp *= -1;
		transform.localScale = theScale;
		//Debug.Log ("Flip ran and moveUp is now: " + moveUp);
	}
}
