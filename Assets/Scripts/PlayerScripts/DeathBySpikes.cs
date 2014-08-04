using UnityEngine;
using System.Collections;

public class DeathBySpikes : MonoBehaviour {

	public GameObject deathMessage;
	public GameObject kill;
	private Vector3 correctDeathView;
	private bool hasCollided = false;


	void OnCollisionEnter2D (Collision2D Player) 
	{
		if(Player.gameObject.tag == "Player")
		{


			Transform currentTransform = GameObject.Find("Player").GetComponent<Transform>();
			if(currentTransform.position.x == -1)
			{
				correctDeathView = currentTransform.position * -1;
			}
			else
			{
				correctDeathView = currentTransform.position;
			}

			if(kill == null)
			{

				if(!hasCollided)
				{
					hasCollided = true;
					
					IncrementStats();
					Invoke("InvokeReset", 0.2f);

					kill = Instantiate(deathMessage, correctDeathView, Quaternion.identity) as GameObject;
					kill.transform.parent = currentTransform;
					//Debug.Log ("You were killed by spikes!!");
					GameObject resetRobbe = GameObject.Find ("Player");
					Vector2 resetTransform = new Vector2(-3.95f, -1.0f);
					resetRobbe.transform.position = resetTransform;
					Destroy(kill, 2.5f);


				}

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
	
	/// <summary>
	/// Resets the hasCollided Value so we can invoke and set a stat again
	/// </summary>
	private void InvokeReset()
	{
		hasCollided = false;
	}
}
