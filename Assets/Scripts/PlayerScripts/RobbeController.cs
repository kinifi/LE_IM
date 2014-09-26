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
	private bool _right;
	private float input1 = 0.0f;

	//scripts to get
	private CharacterController2D _controller;
	private Animator _animator;
	
	void Awake()
	{
		
		//grab script components
		_controller = GetComponent<CharacterController2D>();
		_animator = GetComponent<Animator>();

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

		//grab our current input and set input1
		input1 = Mathf.Abs(Input.GetAxis( "Horizontal" ));

		//zero out vertical velocity if grounded
		if( _controller.isGrounded )
		{
			velocity.y = 0;
			//grab our current input and set v1
		}
		
		//HORIZONTAL INPUT//
		//move imediately to zero horizontal velocity if v1 is larger than current input.
		if( input1 > Mathf.Abs(Input.GetAxis( "Horizontal" )))
		{
			velocity.x = 0.0f;
		}

		//move right
		else if( Input.GetAxis( "Horizontal" ) > 0.15f)
		{
			velocity.x = runSpeed;
			_right = true;
			//grab our current input and set v1
		}
		
		//move left
		else if( Input.GetAxis( "Horizontal" ) < -0.15f)
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
		if( Input.GetButtonDown( "Jump" ))
		{
			if(_controller.isGrounded)
			{
				velocity.y = Mathf.Sqrt( 2f * targetJumpHeight * -gravity );
				doubleJump = true;
				SteamManager.StatsAndAchievements.incrementNumOfJumps();
				audio.Play();
				
			}
			else if(doubleJump == true)
			{
				velocity.y = Mathf.Sqrt( 2f * targetJumpHeight * -gravity );
				doubleJump = false;
				SteamManager.StatsAndAchievements.incrementNumOfJumps();
				audio.Play();
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
			}
			else if(!_right)
			{
				col.gameObject.rigidbody2D.AddForce(moveColL);
			}
		}
	}
}
	