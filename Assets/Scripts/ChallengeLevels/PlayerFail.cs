using UnityEngine;
using System.Collections;

public class PlayerFail : MonoBehaviour {

	public GameObject FadeObj;
	public bool isSpike = false;
	public bool isFalling = false;
	public string playerName = "Player";

	private bool hasIncrementedStat = false;
	private GameObject player;

	// Use this for initialization
	void Start () {

		this.collider2D.isTrigger = true;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D coll)
	{
		if(coll.transform.name == playerName)
		{
			FadeObj.SetActive(true);
			if(hasIncrementedStat == false)
			{
				hasIncrementedStat = true;
				incrementStats();
				Invoke("loadFailLevel", 1.0f);
			}
			Invoke("disablePlayer", 0.2f);
			Debug.Log("Player Fell");
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

	private void loadFailLevel()
	{
		Application.LoadLevel("FailedLevel");
	}

}
