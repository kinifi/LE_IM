using UnityEngine;
using System.Collections;

public class numberOfGamesStat : MonoBehaviour {

	// Use this for initialization
	void Start () {
		SteamManager.StatsAndAchievements.incrementNumOfGames();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
