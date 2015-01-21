using UnityEngine;
using System.Collections;

public class SpringJump : MonoBehaviour {

	//value for rigidbodies
	private Vector2 springing = new Vector2(0.0f, 75.0f);

	//value for kinematic 
	private float targetJumpHeight = 6.0f;
	private float gravity = -25.0f;

	//regulates stats reporting
	private bool hasCollided = false;

	//scripts to get
	private CharacterController2D _player;
	private RobbeController _audioPlayer;
	private RobbeController _isGrounded;

	void Awake()
	{
		//grab script components
		_player = GameObject.Find("Player").GetComponent<CharacterController2D>();
		_audioPlayer = GameObject.Find ("Player").GetComponent<RobbeController>();
	}

	void OnCollisionEnter2D (Collision2D col)
	{
		col.gameObject.rigidbody2D.AddForce(springing);
	}

	void OnTriggerEnter2D (Collider2D coll) 
	{
		if(coll.transform.name == "Player")
		{
			//play sound
			_audioPlayer.EngagementAudio(6);
			//grab our current velocity as base for all calculations
			var velocity = _player.velocity;
			velocity.y = Mathf.Sqrt( 2f * targetJumpHeight * -gravity );
			//apply gravity before moving
			velocity.y += gravity * Time.deltaTime;
			
			//move based on velocity
			_player.move( velocity * Time.deltaTime );
			//Debug.Log ("The player has landed!!! but should be springing!");

			if(!hasCollided)
			{
				hasCollided = true;
				_audioPlayer.canJump = true;

				IncrementStats();
				Invoke("InvokeReset", 0.2f);
			}
		}
	}

	/// <summary>
	/// Increments the stats 
	/// </summary>
	private void IncrementStats()
	{
		SteamManager.StatsAndAchievements.incrementNumOfTrampJumps();
	}

	/// <summary>
	/// Resets the hasCollided Value so we can invoke and set a stat again
	/// </summary>
	private void InvokeReset()
	{
		hasCollided = false;
		Invoke ("InvokeCantDouble", 1.5f);
	}

	private void InvokeCantDouble()
	{
		_audioPlayer.canJump = false;
	}
}
