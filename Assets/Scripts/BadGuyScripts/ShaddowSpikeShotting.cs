using UnityEngine;
using System.Collections;

public class ShaddowSpikeShotting : MonoBehaviour {
	
	public float shotSpeed;
	public GameObject deathMessage;
	public GameObject kill;
	private bool hasCollided = false;
	
	void Start ()
	{
		if(this.gameObject.tag == "spike")
		{
			rigidbody2D.AddForce(Vector2.up * shotSpeed);
		}
		else if(this.gameObject.tag == "topspike")
		{
			rigidbody2D.AddForce(-Vector2.up * shotSpeed);
		}
		else if(this.gameObject.tag == "rightspike")
		{
			rigidbody2D.AddForce(Vector2.right * shotSpeed);
		}
		else if(this.gameObject.tag == "leftspike")
		{
			rigidbody2D.AddForce(-Vector2.right * shotSpeed);
		}
		else if (this.gameObject.tag == "bossspike")
		{
			rigidbody2D.AddRelativeForce(-Vector2.right * shotSpeed);
		}
		
	}
	
	void OnTriggerEnter2D (Collider2D other)
	{
		if(other.gameObject.tag == "Player")
		{
			DeathbySpikes();
		}
		else if(other.gameObject.tag != "Player")
		{
			Destroy(this.gameObject);
		}
	}

	void OnCollisionEnter2D (Collision2D other)
	{
		if(other.gameObject.tag != "Player")
		{
			Destroy(this.gameObject);

		}
		else if(other.gameObject.tag == "Player")
		{
			Destroy(this.gameObject, 0.15f);
		}
	}
	
	private void DeathbySpikes()
	{
		//Stop all movement of Spike Cannon.
		this.rigidbody2D.isKinematic = true; 

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
	
	private void AllowRobbesMovement() 
	{
		//Find Robbe and allow his movement again.  Turn kinematic to false.
		RobbeController _robbe = GameObject.Find("Player").GetComponent<RobbeController>();
		_robbe.enabled = true;

		//Find the LookDown camera and allow its movement.
		NoFaithController _lookdown = GameObject.Find("Camera").GetComponent<NoFaithController>();
		_lookdown.enabled = true;

		//Destory the spike :)
		Destroy(this.gameObject);
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
