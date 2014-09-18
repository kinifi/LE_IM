using UnityEngine;
using System.Collections;

public class RobbeController : MonoBehaviour {

	//Movement Configs
	public float gravity = -25.0f;
	public float runSpeed = 5.0f;
	//public float groundDamping = 20f; // how fast do we change direction? higher means faster
	//public float inAirDamping = 5f;
	public float targetJumpHeight = 3f;
	public bool doubleJump = false;
	public bool canMove;

	//Animator States
	private int idleState = Animator.StringToHash( "Idle" );
	private int runState = Animator.StringToHash( "RunRight" );
	private int jumpState = Animator.StringToHash( "JumpRight" );
	
	//scripts to get
	private CharacterController2D _controller;
	private Animator _animator;
	
	void Awake()
	{
		
		//grab script components
		_controller = GetComponent<CharacterController2D>();
		_animator = GetComponent<Animator>();
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
	