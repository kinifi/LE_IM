using UnityEngine;
using System.Collections;

public class ExitDoorName : MonoBehaviour {

	//Bool to see if the player has collided
	private bool hasCollided = false;

	// Use this for initialization
	void Start () 
	{
		//confirm the bool is set to false
		hasCollided = false;
	
	}

	public void OnCollisionEnter2D (Collision2D other)
	{
		Debug.Log ("The exitdoorname script was called");
		if(other.gameObject.tag == "Player")
		{
			if(hasCollided == false)
			{
				//set the bool to true to prevent more than one call
				hasCollided = true;
				//Increment Stats
				Debug.Log("The steam manager is next!!");
				SteamManager.StatsAndAchievements.incrementNumBossesDefeated();
			}
			//set the playerPrefs to completed for the current boss
			string levelName = Application.loadedLevelName;
			switch(levelName)
			{
			case "ScaredBoss":
				//Set player prefs to completed
				PlayerPrefs.SetString(levelName, "completed");
				break;
			case "ShootOutBoss":
				//Set player prefs to completed
				PlayerPrefs.SetString(levelName, "completed");
				break;
			case "DepthsBoss":
				//Set player prefs to completed
				PlayerPrefs.SetString(levelName, "completed");
				break;
			case "GoblinBoss":
				//Set player prefs to completed
				PlayerPrefs.SetString(levelName, "completed");
				break;
			case "WolfBoss":
				//Set player prefs to completed
				PlayerPrefs.SetString(levelName, "completed");
				break;
			case "BullyBoss":
				//Set player prefs to completed
				PlayerPrefs.SetString(levelName, "completed");
				break;
			case "DarknessBoss":
				//Set player prefs to completed
				PlayerPrefs.SetString(levelName, "completed");
				break;
			default:
				Debug.Log ("Something has gone wrong when setting the Current Boss " + levelName + " to completed.");
				break;
			}
			Debug.Log ("The OnCollision Ran!");
		}

	}
}
