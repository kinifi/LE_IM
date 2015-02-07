using UnityEngine;
using System.Collections;

public class NextDungeon : MonoBehaviour {

	//Configs from Player Prefs
	private int _completed;
	private string _nextDungeon;

	//Get story title for boss
	public string currentStoryTitle;


	void Start()
	{
		_completed = PlayerPrefs.GetInt("completed");
		_nextDungeon = PlayerPrefs.GetString("door");
		//Debug.Log ("Number of dungeons completed this series: " + _completed);
		//Debug.Log("The next dungeon is: " + _nextDungeon);
	}

	void Update ()
	{
		if(Input.anyKeyDown)
		{
			GoNextDungeon();
		}
	}

	
	//uses nextDungeonName to set the next dungeon
	private void GoNextDungeon()
	{
		Debug.Log ("I made it!!!");
		if(_completed >= 4)
		{
			string nextBoss = _nextDungeon;
			Debug.Log (nextBoss);
			switch (nextBoss)
			{
			case "Robbe, the shy kid":
			case "Jack":
			case "All alone":
				Debug.Log ("ScaredBoss Set");
				Application.LoadLevel("ScaredBoss");
				break;
			case "Archery":
			case "The girl cousin":
				Debug.Log ("DepthsBoss Set");
				Application.LoadLevel("DepthsBoss");
				break;
			case "Music Class":
				Debug.Log ("GoblinBoss Set");
				Application.LoadLevel("GoblinBoss");
				break;
			case "The Walk Home":
				Debug.Log ("WolfBoss Set");
				Application.LoadLevel("WolfBoss");
				break;
			case "The Bully":
				Debug.Log ("Bully Set");
				Application.LoadLevel("BullyBoss");
				break;
			default:
				Debug.Log ("ScaredBoss Set due to default");
				Application.LoadLevel("ScaredBoss");
				break;
			}
		}
		else if(_completed < 4)
		{
			int nextTheme = Random.Range(1,7);
			switch (nextTheme)
			{
			case 1:
				Debug.Log ("Map Level Set");
				Application.LoadLevel("Map_Level_Gen");
				break;
			case 2:
				Debug.Log ("Dusk Level Set");
				Application.LoadLevel("Dusk_Level");
				break;
			case 3:
				Application.LoadLevel("Purple_Level");
				break;
			case 4:
				Debug.Log ("Nightmare Level Set");
				Application.LoadLevel("Nightmare_Level");
				break;
			case 5:
				Debug.Log ("Olive Level Set");
				Application.LoadLevel("Olive_Level");
				break;
			case 6:
				Debug.Log ("Rouche Level Set");
				Application.LoadLevel("Rouche_Level");
				break;
			default:
				Debug.Log ("Something has gone wrong judging on the next dungeon");
				Application.LoadLevel("Tutorial_Dungeon");
				break;
			}
		}
	}
}
