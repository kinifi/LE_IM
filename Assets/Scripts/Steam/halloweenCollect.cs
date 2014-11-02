using UnityEngine;
using System;
using System.Collections;

public class halloweenCollect : MonoBehaviour {

	private bool hasCollected = false;
	public bool Halloween = true;
	public bool doNotCollect = false;
	public GameObject candySound;

	// Use this for initialization
	void Start () {

		if(!Halloween)
		{
			Destroy(this.gameObject);
		}

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if(!doNotCollect)
		{
			if(other.name == "Player")
			{
				Debug.Log("Player Collected Me!");
				
				if(hasCollected == false)
				{
					//audio.Play();
					Instantiate(candySound, transform.position, Quaternion.identity);
					hasCollected = true;
					SteamManager.StatsAndAchievements.incrementNumOfCandiesCollected();
				}
				
				Destroy(this.gameObject);
			}
		}
	}
}
