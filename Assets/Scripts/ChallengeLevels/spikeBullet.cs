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

	void OnTriggerEnter2D (Collider2D coll)
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
			//I'm suppose to die here
			if(coll.name == "solid0")
			{
				//Destroy(this.gameObject);
				Debug.Log(coll.name);
			}
		}
	}

	private void disablePlayer()
	{
		player = GameObject.Find("Player");
		player.GetComponent<RobbeController>().canMove = false;
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
