using UnityEngine;
using System.Collections;

public class SpringJump : MonoBehaviour {

	//value for rigidbodies
	private Vector2 springing = new Vector2(0.0f, 275.0f);

	//value for kinematic 
	private float targetJumpHeight = 5.0f;
	private float gravity = -25.0f;

	//regulates stats reporting
	private bool hasCollided = false;

	//scripts to get
	private CharacterController2D _player;

	void Awake()
	{
		//grab script components
		_player = GameObject.Find("Player").GetComponent<CharacterController2D>();
	}

	void OnCollisionEnter2D (Collision2D col)
	{
		col.gameObject.rigidbody2D.AddForce(springing);
	}

	void OnTriggerEnter2D (Collider2D coll) 
	{
		if(coll.transform.name == "Player")
		{
			//grab our current velocity as base for all calculations
			var velocity = _player.velocity;
			velocity.y = Mathf.Sqrt( 2f * targetJumpHeight * -gravity );
			//apply gravity before moving
			velocity.y += gravity * Time.deltaTime;
			
			//move based on velocity
			_player.move( velocity * Time.deltaTime );
			Debug.Log ("The player has landed!!! but should be springing!");

			if(!hasCollided)
			{
				hasCollided = true;

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
	}
}
