using UnityEngine;
using System.Collections;

public class RobbeController : MonoBehaviour {

	//Movement Configs
	public float gravity = -35.0f;
	public float runSpeed = 4.0f;
	public float groundDamping = 20f; // how fast do we change direction? higher means faster
	public float inAirDamping = 5f;
	public float targetJumpHeight = 3f;
	public bool doubleJump = false;
	public bool canMove;

	//Object movement configs
	private Vector2 moveColR = new Vector2(45.0f, 0.0f);
	private Vector2 moveColL = new Vector2(-45.0f, 0.0f);
	public bool _right;
	private float input1 = 0.0f;

	//Audio configs
	public AudioClip[] clips;
	private AudioSource _screams;

	//scripts to get
	private CharacterController2D _controller;
	private Animator _animator;

	//Inventory configs
	Inventory _arrowCount;
	Quiver _bowCount;

	//public vars for other scripts
	public Vector3 playervelocity;
	
	void Awake()
	{
		
		//grab script components
		_controller = GetComponent<CharacterController2D>();
		_animator = GetComponent<Animator>();
		_screams = GameObject.Find ("BossDeathScream").GetComponent<AudioSource>();

		//events :) may not need this line
		_controller.onTriggerEnterEvent += onTriggerEnterEvent;
	}

	void FixedUpdate()
	{
		//grab our current velocity as base for all calculations
		var fixedVelocity = _controller.velocity;


	}

	void Update()
	{


		//Jump animation state
		_animator.SetBool( "Grounded", _controller.isGrounded );

		//grab our current velocity as base for all calculations
		var velocity = _controller.velocity;
		playervelocity = velocity;

		//grab our current input and set input1
		input1 = Mathf.Abs(Input.GetAxis( "Horiz" ));

		//zero out vertical velocity if grounded
		if( _controller.isGrounded )
		{
			velocity.y = 0;
			//grab our current input and set v1
		}
		
		//HORIZONTAL INPUT//
		//move imediately to zero horizontal velocity if v1 is larger than current input.
		if( input1 > Mathf.Abs(Input.GetAxis( "Horiz" )))
		{
			velocity.x = 0.0f;
		}

		//move right
		else if( Input.GetAxis( "Horiz" ) > 0.15f)
		{
			velocity.x = runSpeed;
			_right = true;
			//grab our current input and set v1
		}
		
		//move left
		else if( Input.GetAxis( "Horiz" ) < -0.15f)
		{
			velocity.x = -runSpeed;
			_right = false;
			//grab our current input and set v1
		}
		//zero out horizontal velocity if not moving
		else
		{
			velocity.x = 0;
			//grab our current input and set v1
		}

		//VERTICAL INPUT//
		
		//jump
		if( Input.GetButtonDown( "Jumped" ))
		{
			if(_controller.isGrounded)
			{
				audio.PlayOneShot(clips[4], 0.55F);
				velocity.y = Mathf.Sqrt( 2f * targetJumpHeight * -gravity );
				doubleJump = true;
				SteamManager.StatsAndAchievements.incrementNumOfJumps();
			}
			else if(doubleJump == true)
			{
				audio.PlayOneShot(clips[4], 0.55F);
				velocity.y = Mathf.Sqrt( 2f * targetJumpHeight * -gravity );
				doubleJump = false;
				SteamManager.StatsAndAchievements.incrementNumOfJumps();
			}
		}



		//apply gravity before moving
		velocity.y += gravity * Time.deltaTime;
		
		//move based on velocity
		_controller.move( velocity * Time.deltaTime );

	}

	//Object movement via Physics
	void onTriggerEnterEvent( Collider2D col )
	{
		if(col.gameObject.layer == 10)
		{
			if(_right)
			{
				col.gameObject.rigidbody2D.AddForce(moveColR);
				//Unlock Achievement
				SteamManager.StatsAndAchievements.Unlock_Nice_Game_Developers_Achievement();
				//Play crate noise
				audio.PlayOneShot(clips[0], 0.45F);
			}
			else if(!_right)
			{
				col.gameObject.rigidbody2D.AddForce(moveColL);
				//Unlock Achievement
				SteamManager.StatsAndAchievements.Unlock_Nice_Game_Developers_Achievement();
				//Play crate noise
				audio.PlayOneShot(clips[0], 0.45F);
			}
		}
		else if(col.gameObject.tag == "Key")
		{
			audio.PlayOneShot(clips[1], 0.7F);
		}
		else if(col.gameObject.tag == "Bow")
		{
			audio.PlayOneShot(clips[7], 0.7F);
			if(col.gameObject.GetComponent<CollectBow>() != null)
			{
				//Inventory add
				//Debug.Log("You found a bow!");
				_arrowCount = GameObject.Find("Player").GetComponent<Inventory>();
				_arrowCount.Arrows += 1;
				Debug.Log ("Your Arrow as been inventoried!!!"+_arrowCount.Arrows);
				
				//Quiver add
				//Debug.Log("You grabbed a bow!");
				_bowCount = GameObject.Find("Player").GetComponent<Quiver>();
				_bowCount.bow += 1;
				Debug.Log ("This is the bow count" + _bowCount.bow);
				//Update PlayerPrefs
				PlayerPrefs.SetInt("bow", _bowCount.bow);
				
				_arrowCount.InventoryOnTimer();
			}
			else if (col.gameObject.GetComponent<CollectGoldenBow>() != null)
			{
				//Inventory add
				//Debug.Log("You found a bow!");
				_arrowCount = GameObject.Find("Player").GetComponent<Inventory>();
				_arrowCount.Arrows += 5;
				_arrowCount.startCollectTimer = true;
				Debug.Log ("Your Arrow as been inventoried!!!"+_arrowCount.Arrows);
				
				//Quiver add
				//Debug.Log("You grabbed a bow!");
				_bowCount = GameObject.Find("Player").GetComponent<Quiver>();
				_bowCount.bow += 5;
				Debug.Log ("This is the bow count" + _bowCount.bow);
				//Update PlayerPrefs
				PlayerPrefs.SetInt("bow", _bowCount.bow);
				
				_arrowCount.InventoryOnTimer();
			}
			//Destroy object
			Destroy(col.gameObject);
		}
		else if(col.gameObject.tag == "Door")
		{
			audio.PlayOneShot(clips[2], 0.7F);
		}
	}

	void OnParticleCollision(GameObject particle) 
	{
		Debug.Log ("This is the particle name " + particle.name);
	}

	public void BossDeathAudios ()
	{
		_screams.enabled = true;
	}

	public void EngagementAudio (int clipsNumber)
	{
		audio.PlayOneShot(clips[clipsNumber], 0.7f);
	}

	public void DelayAllowMovement()
	{
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
		Invoke ("AllowRobbesMovement", 1.5f);
	}

	private void AllowRobbesMovement() 
	{
		//Find Robbe and allow his movement again.  Turn kinematic to false.
		RobbeController _robbe = GameObject.Find("Player").GetComponent<RobbeController>();
		_robbe.enabled = true;
		
		//Find the LookDown camera and allow its movement.
		NoFaithController _lookdown = GameObject.Find("Camera").GetComponent<NoFaithController>();
		_lookdown.enabled = true;
	}
}
	