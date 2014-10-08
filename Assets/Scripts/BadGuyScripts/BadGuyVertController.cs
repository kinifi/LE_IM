using UnityEngine;
using System.Collections;

public class BadGuyVertController : MonoBehaviour {
	
	//Bool Configs
	public bool spotted = false;
	public bool walls = false;
	public bool facingRight = false;
	
	//Transform configs
	public Transform sightStart, sightEnd, wallStart, wallEnd;
	
	//Configs for speed
	public float speed = 5000.0f;
	private Vector2 sightedSpeed;
	
	//Configs for sight rays
	private Vector2 sightRayStart;
	private Vector2 sightRayEnd;
	private Vector2 sightRayUpdateStart;
	private Vector2 sightRayUpdateEnd;
	//Config for sight layermask
	public LayerMask sightlayerMask; //make sure we aren't in this layer 
	
	
	//Configs for wall rays
	private Vector2 wallRayStart;
	private Vector2 wallRayEnd;
	private Vector2 wallRayUpdateStart;
	private Vector2 wallRayUpdateEnd;
	//Config for sight layermask	
	public LayerMask walllayerMask; //make sure we aren't in this layer 
	
	//Death Configs
	public GameObject kill;
	public GameObject deathSplash;
	public GameObject bowGolden;

	//Audio Configs
	public AudioClip[] vertWispSounds;

	//Components to get
	private int _goblinsDeadNum;
	
	void Start ()
	{
		//Initialize sight ray
		sightRayStart = sightStart.position;
		sightRayEnd = sightEnd.position;
		
		
		//Initialize wall ray
		wallRayStart = wallStart.position;
		wallRayEnd = wallEnd.position;
		
		//Begin patrol
		InvokeRepeating("Patrol", 0.0f, Random.Range (8,13));
	}
	
	void Update ()
	{
		RaycastMethod();
		Behaviours();
		UpdateWallRayPosition();
		UpdateSightRayPosition();
		UpdateSightedSpeed();
	}
	
	private void RaycastMethod ()
	{
		//Sight Rays
		Debug.DrawLine(sightRayStart, sightRayEnd, Color.red);
		spotted = Physics2D.Linecast(sightRayStart, sightRayEnd, sightlayerMask);
		
		//Wall Rays
		Debug.DrawLine (wallRayStart, wallRayEnd, Color.yellow);
		walls = Physics2D.Linecast(wallRayStart, wallRayEnd, walllayerMask);
	}
	
	private void Behaviours ()
	{
		if(spotted == true)
		{
			//Debug.Log ("Spotted!!!!");
			rigidbody2D.AddForce(sightedSpeed * Time.deltaTime);
		}
		if(walls == true)
		{
			//Debug.Log ("Walls is: "+walls);
			Patrol();
		}
	}
	
	private void Patrol ()
	{
		Flip();
		if(facingRight == false)
		{
			ZeroOutFources();
			rigidbody2D.AddForce(Vector2.up * speed * Time.deltaTime);
		}
		else
		{
			ZeroOutFources();
			rigidbody2D.AddForce(-Vector2.up * speed * Time.deltaTime);
		}
	}
	
	private void ZeroOutFources ()
	{
		rigidbody2D.isKinematic = true;
		rigidbody2D.isKinematic = false;
	}
	
	private void Flip()
	{
		facingRight = !facingRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
		//Debug.Log ("Flip ran and moveForward is now: " + moveForward);
	}
	
	private void UpdateSightRayPosition ()
	{
		if(facingRight)
		{
			//update the sight start ray pos
			sightRayUpdateStart = transform.position;
			sightRayUpdateStart.y -= 0.5f;
			sightRayUpdateStart.x +=0.2f;
			sightRayStart = sightRayUpdateStart;
			
			//update the sight end ray pos
			sightRayUpdateEnd = transform.position;
			sightRayUpdateEnd.y -= 4.0f;
			sightRayUpdateStart.x +=0.2f;
			sightRayEnd = sightRayUpdateEnd;
		}
		else
		{
			//update the sight start ray pos
			sightRayUpdateStart = transform.position;
			sightRayUpdateStart.x += 0.5f;
			sightRayUpdateStart.y +=0.2f;
			sightRayStart = sightRayUpdateStart;
			
			//update the sight end ray pos
			sightRayUpdateEnd = transform.position;
			sightRayUpdateEnd.y += 4.0f;
			sightRayUpdateStart.x +=0.2f;
			sightRayEnd = sightRayUpdateEnd;
		}
	}
	
	private void UpdateWallRayPosition ()
	{
		
		if(facingRight)
		{
			//update the wall start ray pos
			wallRayUpdateStart = transform.position;
			wallRayUpdateStart.y -= 0.5f;
			wallRayStart = wallRayUpdateStart;
			
			//update the wall end ray pos
			wallRayUpdateEnd = transform.position;
			wallRayUpdateEnd.y -= 1.0f;
			wallRayEnd = wallRayUpdateEnd;
		}
		else
		{
			//update the wall start ray pos
			wallRayUpdateStart = transform.position;
			wallRayUpdateStart.y += 0.5f;
			wallRayStart = wallRayUpdateStart;
			
			//update the wall end ray pos
			wallRayUpdateEnd = transform.position;
			wallRayUpdateEnd.y += 1.0f;
			wallRayEnd = wallRayUpdateEnd;
		}
	}
	
	private void UpdateSightedSpeed ()
	{
		if(facingRight)
		{
			sightedSpeed = -Vector2.up * 1000.0f;
			audio.pitch = 1.5f;
			//Return Pitch to normal
			Invoke ("ReturnPitch", 1.5f);
		}
		else
		{
			sightedSpeed = Vector2.up * 1000.0f;
			audio.pitch = 1.5f;
			//Return Pitch to normal
			Invoke ("ReturnPitch", 1.5f);			
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
			//Play audio
			audio.PlayOneShot(vertWispSounds[0]);
			//Get position for bow drop
			Vector3 pos = transform.position;
			//Destroy Arrow
			Destroy(other.gameObject);
			//Increment Death
			_goblinsDeadNum = GameObject.Find ("GoblinBossBody").GetComponent<GoblinBody>().gouhls;
			_goblinsDeadNum -= 1;
			GameObject.Find ("GoblinBossBody").GetComponent<GoblinBody>().gouhls = _goblinsDeadNum;
			//chance of drop
			int drop = Random.Range(1,6);
			//drop
			if(drop == 5)
			{
				Instantiate(bowGolden, pos, Quaternion.identity);
			}
			//Destroy object
			Invoke ("DestroyObject", 0.45f);
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

	private void DestroyObject()
	{
		Destroy(this.gameObject);
	}

	//Method to return pitch
	private void ReturnPitch ()
	{
		audio.pitch = 1.0f;
	}
	
}