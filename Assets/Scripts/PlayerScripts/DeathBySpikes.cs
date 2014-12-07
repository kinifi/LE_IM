using UnityEngine;
using System.Collections;

public class DeathBySpikes : MonoBehaviour {

	public GameObject deathMessage;
	public GameObject kill;
	private bool hasCollided = false;


	void OnTriggerEnter2D (Collider2D Player) 
	{
		if(Player.gameObject.tag == "Player")
		{
			if(kill == null)
			{
				if(!hasCollided)
				{
					hasCollided = true;
					
					IncrementStats();
					Invoke("InvokeReset", 0.2f);

					//Debug.Log ("You were killed by spikes!!");

					
					//Failsafe enable movement
					GameObject.Find("Player").GetComponent<RobbeController>().DelayAllowMovement();
					
					//Instantiate the death splash and overlay Robbe.  Destroy it and call the movement function.
					GameObject resetRobbe = GameObject.Find ("Player");
					kill = Instantiate(deathMessage, resetRobbe.transform.position, Quaternion.identity) as GameObject;
					kill.transform.OverlayPosition(resetRobbe.transform);
					kill.transform.localScale = new Vector3(50.0f,50.0f,1.0f);
					
					Destroy(kill, 1.0f);
				}
			}
		}
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

	/// <summary>
	/// Increments the stats 
	/// </summary>
	private void IncrementStats()
	{
		SteamManager.StatsAndAchievements.incrementNumOfDeathsBySpikes();
		Debug.Log("Incremented the spike stat");
	}
	
	/// <summary>
	/// Resets the hasCollided Value so we can invoke and set a stat again
	/// </summary>
	private void InvokeReset()
	{
		hasCollided = false;
	}
}
