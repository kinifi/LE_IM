using UnityEngine;
using System.Collections;

public class SpringJump : MonoBehaviour {

	public Vector2 springing = new Vector2(0.0f, 275.0f);
	private bool hasCollided = false;

	void OnCollisionEnter2D (Collision2D coll) {

		coll.gameObject.rigidbody2D.AddForce(springing);

		if(coll.transform.name == "Player")
		{


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
