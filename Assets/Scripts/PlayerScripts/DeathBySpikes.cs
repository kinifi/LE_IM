using UnityEngine;
using System.Collections;

public class DeathBySpikes : MonoBehaviour {

	private bool hasCollided = false;


	void OnCollisionEnter2D (Collision2D Player)
	{
		if(Player.gameObject.tag == "Player")
		{
			Debug.Log ("The player has collided");
		}
	}

	void OnTriggerEnter2D (Collider2D Player) 
	{
		if(Player.gameObject.tag == "Player")
		{
			if(!hasCollided)
			{
				//Set hasCollided to true to prevent multiple kills
				hasCollided = true;
				//Increment the player states
				IncrementStats();
				//Invoke the reset for hasCollided
				Invoke("InvokeReset", 0.2f);
				//Let me know you were killed by spikes
				Debug.Log ("You were killed by spikes!!");
				//Call Death Script on Player
				GameObject.Find("Player").GetComponent<RobbeController>().DelayAllowMovement();
			}
		}
	}

	/// <summary>
	/// Increments the stats 
	/// </summary>
	private void IncrementStats()
	{
		SteamManager.StatsAndAchievements.incrementNumOfDeathsBySpikes();
		Debug.Log("Incremented the spike stat");
	}

	// Resets the hasCollided Value so we can invoke and set a stat again
	private void InvokeReset()
	{
		hasCollided = false;
	}
}
