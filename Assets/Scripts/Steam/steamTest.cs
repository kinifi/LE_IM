using UnityEngine;
using System.Collections;
using Steamworks;

public class steamTest : MonoBehaviour {

	private int testStat = 0;

	// Use this for initialization
	void Start () {

	}
	
	public void createTest()
	{
		SteamManager.StatsAndAchievements.incrementNumOfGames();
	}

	public void getValues()
	{
		SteamManager.StatsAndAchievements.getStats();
	}
}
