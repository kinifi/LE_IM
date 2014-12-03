using UnityEngine;
using System.Collections;

public class SteamStats : MonoBehaviour {

	public UILabel NumGames, NumDeathsByFalling, NumDeathsBySpikes, NumJumps, NumTrampJumps, HalloweenCandies, NumBossDeaths;

	// Use this for initialization
	void Start () {
	
		//pull from the steam server
		SteamManager.StatsAndAchievements.getStats();

		//set the new updated stats to the UILabels
		setLabelsToStats();
	}

	private void setLabelsToStats()
	{
		NumGames.text = "Total Games Played: " + SteamManager.StatsAndAchievements.m_nTotalGamesPlayed; 
		NumJumps.text = "Number of Jumps: " + SteamManager.StatsAndAchievements.m_nTotalNumJumps;
		NumTrampJumps.text = "Number of Trampoline Jumps: " + SteamManager.StatsAndAchievements.m_nTotalNumTrampJumps;
		NumDeathsByFalling.text = "Number of Deaths By Falling: " + SteamManager.StatsAndAchievements.m_nTotalNumDeathByFalling;
		NumDeathsBySpikes.text = "Number of Deaths By Spikes: " + SteamManager.StatsAndAchievements.m_nTotalNumDeathBySpikes;
		//HalloweenCandies.text = "Number of Halloween Candies: " + SteamManager.StatsAndAchievements.m_nTotalNumHalloweenCandies;
        NumBossDeaths.text = "Number of Bosses Killed: " + SteamManager.StatsAndAchievements.m_nTotalNumBossesDefeated;
	}

	public void backToMain() {

		Application.LoadLevel("Main_Menu");
		Debug.Log("Go back");

	}

	// Update is called once per frame
	void Update () {


	}
}
