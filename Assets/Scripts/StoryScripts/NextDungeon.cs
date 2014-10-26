using UnityEngine;
using System.Collections;

public class NextDungeon : MonoBehaviour {

	//Configs from Player Prefs
	private int _completed;
	private string _nextDungeon;

	void Start()
	{
		_completed = PlayerPrefs.GetInt("completed");
		_nextDungeon = PlayerPrefs.GetString("door");
	}
	
	//uses nextDungeonName to set the next dungeon
	private void GoNextDungeon(int completedDungeons)
	{
		if(completedDungeons == 4)
		{
			string nextBoss = _nextDungeon;
			switch (nextBoss)
			{
			case "1":
				Debug.Log ("ScaredBoss Set");
				Application.LoadLevel("ScaredBoss");
				break;
			case "2":
				Debug.Log ("DepthsBoss Set");
				Application.LoadLevel("DepthsBoss");
				break;
			case "3":
				Debug.Log ("GoblinBoss Set");
				Application.LoadLevel("GoblinBoss");
				break;
			default:
				Debug.Log ("GoblinBoss Set due to default");
				Application.LoadLevel("GoblinBoss");
				break;
			}
		}
		else if(completedDungeons < 4)
		{
			string nextTheme = _nextDungeon;
			switch (nextTheme)
			{
			case "1":
				Debug.Log ("Map Level Set");
				Application.LoadLevel("Map_Level_Gen");
				break;
			case "2":
				Debug.Log ("Dusk Level Set");
				Application.LoadLevel("Dusk_Level");
				break;
			case "3":
				Application.LoadLevel("Purple_Level");
				break;
			case "4":
				Debug.Log ("Nightmare Level Set");
				Application.LoadLevel("Nightmare_Level");
				break;
			default:
				Debug.Log ("Something has gone wrong judging on the next dungeon");
				Application.LoadLevel("Tutorial_Dungeon");
				break;
			}
		}
	}
}
