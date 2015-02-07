using UnityEngine;
using System.Collections;

public class ShaddowSpikeShotting : MonoBehaviour {
	
	public float shotSpeed;
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
			DeathbySpikeShot();
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
			DeathbySpikeShot();
		}
	}
	
	private void DeathbySpikeShot()
	{
		if(kill == null)
		{
			//Let me know you were killed by a Shaddow spike
			//Debug.Log ("You were killed by a Shaddow Spike!" + this.gameObject.name);
			
			//Call player death script
			GameObject.Find("Player").GetComponent<RobbeController>().DelayAllowMovement();
		}
		//Destroy this object
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
