using UnityEngine;
using System.Collections;

public class spikeBullet : MonoBehaviour {

	private GameObject FadeObj;
	public bool isSpike = false;
	public bool isFalling = false;
	public string playerName = "Player";
	
	private bool hasIncrementedStat = false;
	private GameObject player;

	// Use this for initialization
	void Start () {
		FadeObj = GameObject.Find("ShaddowSpikeCannon");

		if(FadeObj == null)
		{
			Debug.Log("cant find a shadowspikeCannon");
		}

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter2D (Collision2D coll)
	{
		if(coll.transform.name == playerName)
		{
			FadeObj.GetComponent<PlayerFail>().startDeath();
			disablePlayer();
			if(hasIncrementedStat == false)
			{
				hasIncrementedStat = true;
				incrementStats();
				Destroy(this.gameObject);
			}

			Debug.Log("Player Fell");
		}
		else
		{
			Destroy(this.gameObject);
		}
	}

	private void disablePlayer()
	{
		player = GameObject.Find("Player");
		player.GetComponent<FakeRobbeController>().canMove = false;
		player.GetComponent<Rigidbody2D>().isKinematic = true;
	}
	
	private void incrementStats()
	{
		if(isFalling == true)
		{
			SteamManager.StatsAndAchievements.incrementNumOfDeathsByFalling();
		}
		else if(isSpike == true)
		{
			SteamManager.StatsAndAchievements.incrementNumOfDeathsBySpikes();
		}
	}

}
