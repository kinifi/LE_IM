using UnityEngine;
using System.Collections;

public class unlockGen_DungeonAchievementOnStart : MonoBehaviour {

	// Use this for initialization
	void Start () {

		SteamManager.StatsAndAchievements.Unlock_Gen_Dungeon_Achievement();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
