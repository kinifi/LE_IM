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


					//kill.transform.parent = currentTransform;

					//Debug.Log ("You were killed by spikes!!");
					GameObject resetRobbe = GameObject.Find ("Player");
					Vector2 resetTransform = new Vector2(-3.95f, -1.0f);
					resetRobbe.transform.position = resetTransform;

					//resetRobbe.rigidbody2D.velocity = new Vector2( 0, 0);
					resetRobbe.rigidbody2D.isKinematic = true;
					
					FakeRobbeController _robbe = GameObject.Find("Player").GetComponent<FakeRobbeController>();
					_robbe.canMove = false;

					kill = Instantiate(deathMessage, correctDeathView, Quaternion.identity) as GameObject;
					kill.transform.OverlayPosition(resetRobbe.transform);
					Destroy(kill, 2.5f);
					Invoke("AllowRobbesMovement", 2.5f);
				}

			}
		}
	}

	private void AllowRobbesMovement() {
		FakeRobbeController _robbe = GameObject.Find("Player").GetComponent<FakeRobbeController>();
		_robbe.canMove = true;
		_robbe.rigidbody2D.isKinematic = false;
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
