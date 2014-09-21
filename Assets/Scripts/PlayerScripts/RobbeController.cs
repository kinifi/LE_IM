using UnityEngine;
using System.Collections;

public class RobbeController : MonoBehaviour {

	//Movement Configs
	public float gravity = -25.0f;
	public float runSpeed = 5.0f;
	public float groundDamping = 20f; // how fast do we change direction? higher means faster
	public float inAirDamping = 5f;
	public float targetJumpHeight = 3f;
	public bool doubleJump = false;
	public bool canMove;

	//Object movement configs
	private Vector2 moveColR = new Vector2(45.0f, 0.0f);
	private Vector2 moveColL = new Vector2(-45.0f, 0.0f);
	private bool _right;

	//Animator States
	/*private int idleState = Animator.StringToHash( "Idle" );
	private int runState = Animator.StringToHash( "RunRight" );
	private int jumpState = Animator.StringToHash( "JumpRight" );*/

	//scripts to get
	private CharacterController2D _controller;
//	private Animator _animator;
	
	void Awake()
	{
		
		//grab script components
		_controller = GetComponent<CharacterController2D>();
//		_animator = GetComponent<Animator>();

		//events :) may not need this line
		_controller.onTriggerEnterEvent += onTriggerEnterEvent;
	}
	
	void Update()
	{
		//grab our current velocity as base for all calculations
		var velocity = _controller.velocity;
		
		//zero out vertical velocity if grounded
		if( _controller.isGrounded )
		{
			velocity.y = 0;
		}
		
		//HORIZONTAL INPUT//
		
		//move right
		if( Input.GetAxis( "Horizontal" ) > 0.15f)
		{
			velocity.x = runSpeed;
			goRight();
			_right = true;
			
			/*//running animation state
			if( _controller.isGrounded)
			{
				_animator.SetTrigger( runState );
			}*/
		}
		
		//move left
		else if( Input.GetAxis( "Horizontal" ) < -0.15f)
		{
			velocity.x = -runSpeed;
			goLeft();
			_right = false;
			
			/*//running animation state
			if( _controller.isGrounded)
			{
				_animator.SetTrigger( runState );
			}*/
		}
		
		//zero out horizontal velocity if not moving
		else
		{
			velocity.x = 0;
			
			/*//idle animation state
			if( _controller.isGrounded)
			{
				_animator.SetTrigger( idleState );
			}*/
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
				
				/*//jump animation state
				_animator.SetTrigger( jumpState );*/
			}
			else if(doubleJump == true)
			{
				velocity.y = Mathf.Sqrt( 2f * targetJumpHeight * -gravity );
				doubleJump = false;
				SteamManager.StatsAndAchievements.incrementNumOfJumps();
				audio.Play();
				
				/*//jump animation state
				_animator.SetTrigger( jumpState );*/
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
		if(col.transform.name == "PushBlock50(Clone)")
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

	private void goLeft()
	{
		if( transform.localScale.x > 0f)
		{
			transform.localScale = new Vector3( -transform.localScale.x, transform.localScale.y, transform.localScale.z );
		}
	}

	private void goRight()
	{
		if( transform.localScale.x < 0f)
		{
			transform.localScale = new Vector3( -transform.localScale.x, transform.localScale.y, transform.localScale.z );
		}
	}
}
	