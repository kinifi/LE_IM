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
					kill = Instantiate(deathMessage, resetRobbe.transform.position, Quaternion.identity) as GameObject;
					kill.transform.OverlayPosition(resetRobbe.transform);
					kill.transform.localScale = new Vector3(50.0f,50.0f,1.0f);

					Destroy(kill, 2.5f);
					Invoke("AllowRobbesMovement", 2.5f);
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
