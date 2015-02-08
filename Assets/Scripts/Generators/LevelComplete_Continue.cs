using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LevelComplete_Continue : MonoBehaviour {

	//Grab inventory configs
	private int _bows; 
	private int _keys;
	private int _completed;

	//basic config
	private bool hasCollided = false;

	void OnTriggerEnter2D (Collider2D Player) 
	{
		Debug.Log ("The exit door has been colided by!!! "+Player);
		if(Player.gameObject.tag == "Player")
		{
			if(hasCollided == false)
			{
				hasCollided = true;
				CheckBossRooms();
				//Get current inventory and call the set method
				_bows = GameObject.Find("Player").GetComponent<Inventory>().Arrows;
				_keys = GameObject.Find("Player").GetComponent<Inventory>().Keys;
				SetInventoryToPlayerPref (_bows, _keys, _completed);

				//Start Story Scene
				LoadStoryScreen();
			}
		}
	}

	private void CheckBossRooms()
	{
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
			Debug.Log ("This is not a boss level");
			break;
		}
	}

	private void LoadStoryScreen()
	{
		Application.LoadLevel("StoryScene");
	}

	//Set current inventory to player prefs
	private void SetInventoryToPlayerPref (int bows, int keys, int completed)
	{
		PlayerPrefs.SetInt("bow", bows);
		PlayerPrefs.SetInt("keys", keys);
		PlayerPrefs.SetInt("completed", completed);
	}

}