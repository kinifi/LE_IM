using UnityEngine;
using System.Collections;

public class BadGuyFollowController : MonoBehaviour {

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
	public GameObject bowGolden;

	//Audio Configs
	public AudioClip[] wispSounds;

	//Animation Configs
	private Animator _anim;


	void Awake()
	{
		_anim = GetComponent<Animator>();
		GetComponentInChildren<ParticleSystem>().renderer.sortingLayerName  = "Danger Bad Guys";
	}

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

	//Method to draw rays and check bools
	private void RaycastMethod ()
	{
		//Sight Rays
		Debug.DrawLine(sightRayStart, sightRayEnd, Color.red);
		spotted = Physics2D.Linecast(sightRayStart, sightRayEnd, sightlayerMask);

		//Wall Rays
		Debug.DrawLine (wallRayStart, wallRayEnd, Color.yellow);
		walls = Physics2D.Linecast(wallRayStart, wallRayEnd, walllayerMask);
	}

	//Method to act on bools
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
			rigidbody2D.AddForce(Vector2.right * speed * Time.deltaTime);
		}
		else
		{
			ZeroOutFources();
			rigidbody2D.AddForce(-Vector2.right * speed * Time.deltaTime);
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
			sightRayUpdateStart.x -= 0.5f;
			sightRayUpdateStart.y +=0.2f;
			sightRayStart = sightRayUpdateStart;
			
			//update the sight end ray pos
			sightRayUpdateEnd = transform.position;
			sightRayUpdateEnd.x -= 4.0f;
			sightRayUpdateStart.y +=0.2f;
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
			sightRayUpdateEnd.x += 4.0f;
			sightRayUpdateStart.y +=0.2f;
			sightRayEnd = sightRayUpdateEnd;
		}
	}

	private void UpdateWallRayPosition ()
	{

		if(facingRight)
		{
			//update the wall start ray pos
			wallRayUpdateStart = transform.position;
			wallRayUpdateStart.x -= 0.5f;
			wallRayStart = wallRayUpdateStart;

			//update the wall end ray pos
			wallRayUpdateEnd = transform.position;
			wallRayUpdateEnd.x -= 1.0f;
			wallRayEnd = wallRayUpdateEnd;
		}
		else
		{
			//update the wall start ray pos
			wallRayUpdateStart = transform.position;
			wallRayUpdateStart.x += 0.5f;
			wallRayStart = wallRayUpdateStart;
			
			//update the wall end ray pos
			wallRayUpdateEnd = transform.position;
			wallRayUpdateEnd.x += 1.0f;
			wallRayEnd = wallRayUpdateEnd;
		}
	}

	private void UpdateSightedSpeed ()
	{
		if(facingRight)
		{
			sightedSpeed = -Vector2.right * 1000.0f;
			audio.pitch = 1.5f;
			//Return Pitch to normal
			Invoke ("ReturnPitch", 1.5f);
		}
		else
		{
			sightedSpeed = Vector2.right * 1000.0f;
			audio.pitch = 1.5f;
			//Return Pitch to normal
			Invoke ("ReturnPitch", 1.5f);
		}
	}

	private void OnTriggerEnter2D (Collider2D other)
	{
		if(other.gameObject.tag == "Arrow")
		{
			//Stop movement
			ZeroOutFources();
			//Stop anim body
			this.gameObject.GetComponentInChildren<ParticleSystem>().renderer.enabled = false;
			//Start anim
			_anim.SetBool("IsDead", true);
			//Play audio
			audio.PlayOneShot(wispSounds[0]);
			//Get position for bow drop
			Vector3 pos = transform.position;
			//Destroy Arrow
			Destroy(other.gameObject);
			//Decrement the wisp count if this is the goblin boss
			if(GameObject.Find ("GoblinBossBody") != null)
			{
				GameObject.Find ("WispCount").GetComponent<GoblinWispCount>().wispCount -=1;
				Debug.Log ("A wisp has been defeated!!!");
			}
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
		else if(other.gameObject.tag == "Player")
		{
			//Stop all movement of the bad guy!!
			this.gameObject.rigidbody2D.isKinematic = true;
			
			if(kill == null)
			{
				//Let me know you were killed by a Fire Wisp
				//Debug.Log ("You were killed by a bad guy!!" + this.gameObject.name);
				
				//Call player death script
				GameObject.Find("Player").GetComponent<RobbeController>().DelayAllowMovement();
			}
			//Allow movement of the bad guy!!
			this.gameObject.rigidbody2D.isKinematic = false;
		}
		

	}

	/*private void AllowRobbesMovement() 
	{
		//Allow movement of the bad guy again
		this.gameObject.rigidbody2D.isKinematic = false;
		
		//Find Robbe and allow his movement again.  Turn kinematic to false.
		RobbeController _robbe = GameObject.Find("Player").GetComponent<RobbeController>();
		_robbe.enabled = true;
		
		//Find the LookDown camera and allow its movement.
		NoFaithController _lookdown = GameObject.Find("Camera").GetComponent<NoFaithController>();
		_lookdown.enabled = true;
	}*/

	private void DestroyObject ()
	{
		Destroy (this.gameObject);
	}

	//Method to return pitch
	private void ReturnPitch ()
	{
		audio.pitch = 1.0f;
	}

}