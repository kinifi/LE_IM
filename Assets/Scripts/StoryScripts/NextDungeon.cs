using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class NextDungeon : MonoBehaviour {

	//Set from playerPrefs
	private int storyChapter = 0;
	private List<int> bossChapters = new List<int> {5,15,25,30,35,40,60};


	void Start()
	{
		storyChapter = PlayerPrefs.GetInt("storyChapter");
	}

	void Update ()
	{
		if(Input.anyKeyDown)
		{
			CheckIfNextLevelIsABoss();
		}
	}

	public void CheckIfNextLevelIsABoss ()
	{
		//Checks if the next level should be a boss
		if(bossChapters.Contains(storyChapter))
		{
			Debug.Log ("This level should be a boss");
			switch(storyChapter)
			{
			case 5:
				Debug.Log ("Preparing to launch Nightmare Boss");
				Application.LoadLevel("ScaredBoss");
				break;
			case 15:
				Debug.Log ("Preparing to launch Shoot Out Boss");
				break;
			case 25:
				Debug.Log ("Preparing to launch Depths Boss");
				Application.LoadLevel("DepthsBoss");
				break;
			case 30:
				Debug.Log ("Preparing to launch Goblin Boss");
				Application.LoadLevel("GoblinBoss");
				break;
			case 35:
				Debug.Log ("Preparing to launch Wolf Boss");
				Application.LoadLevel("WolfBoss");
				break;
			case 40:
				Debug.Log ("Preparing to launch Robot Boss");
				Application.LoadLevel("BullyBoss");
				break;
			case 60:
				Debug.Log ("Preparing to launch Darkness Boss");
				break;
			default:
				Debug.Log ("Something went wrong when setting a boss level.");
				Debug.Log ("Please let the devs know! :D");
				Application.LoadLevel("WolfBoss");
				break;
			}
		}
		else
		{
			Debug.Log ("The next level is not a boss level");
			StartNextLevel();
		}
	}

	//Finds the game object title and sets temporary variable to story title text
	private void StartNextLevel ()
	{
		//Sets current story title text to temp variable
		if(storyChapter<5)
		{
			Debug.Log ("Preparing to launch Tutorial Dungeon");
			Application.LoadLevel("Tutorial_Dungeon");
			
		}
		//Shy Kid finished - Go to Nightmare Boss
		else if(storyChapter > 4 && storyChapter < 10)
		{
			Debug.Log ("Preparing to launch Nightmare Dungeon");
			Application.LoadLevel("Nightmare_Level");
			
		}
		//Jack Finished
		else if(storyChapter > 9 && storyChapter < 15)
		{
			//----------------SWITCH TO ARCHERY THEME!!!! --------------------------//
			Debug.Log ("Preparing to launch Nightmare Dungeon");
			Application.LoadLevel("Nightmare_Level");
			
		}
		//Archery Finished - Go to Shoot Out Boss
		else if(storyChapter > 14 && storyChapter < 20)
		{
			//----------------SWITCH TO ARCHERY THEME!!!! --------------------------//
			Debug.Log ("Preparing to launch Nightmare Dungeon");
			Application.LoadLevel("Nightmare_Level");
			
		}
		//Girl Cousin Finished
		else if(storyChapter > 19 && storyChapter < 25)
		{
			Debug.Log ("Preparing to launch Depths Dungeon");
			Application.LoadLevel("Purple_Level");
			
		}
		//All Alone Finished - Go to Depths Boss
		else if(storyChapter > 24 && storyChapter < 30)
		{
			Debug.Log ("Preparing to launch Depths Dungeon");
			Application.LoadLevel("Purple_Level");
			
		}
		//Music Class Finished - Go to Goblin Boss
		else if(storyChapter > 29 && storyChapter < 35)
		{
			Debug.Log ("Preparing to launch Tutorial Dungeon");
			Application.LoadLevel("Tutorial_Dungeon");
			
		}
		//The Walk Home Finished - Go to Wolf Boss
		else if(storyChapter > 34 && storyChapter < 40)
		{
			Debug.Log ("Preparing to launch Olive Dungeon");
			Application.LoadLevel("Olive_Level");
			
		}
		//The Bully Finished - Go to Robot Boss
		else if(storyChapter > 39 && storyChapter < 45)
		{
			Debug.Log ("Preparing to launch Robot Dungeon");
			Application.LoadLevel("Rouche_Level");
			
		}
		//The Forest Finished
		else if(storyChapter > 44 && storyChapter < 50)
		{
			Debug.Log ("Preparing to launch Dusk Dungeon");
			Application.LoadLevel("Dusk_Level");
			
		}
		//Into the Dark Finished
		else if(storyChapter > 49 && storyChapter < 55)
		{
			Debug.Log ("Preparing to launch Dusk Dungeon");
			Application.LoadLevel("Dusk_Level");
			
		}
		//Fireflies Finished
		else if(storyChapter > 54 && storyChapter < 60)
		{
			Debug.Log ("Preparing to launch Forest Dungeon");
			Application.LoadLevel("Map_Level_Gen");
			
		}
		//Fighting the Dark Finished - Go to Darkness Boss
		else if(storyChapter > 59 && storyChapter < 65)
		{
			Debug.Log ("Preparing to launch Forest Dungeon");
			Application.LoadLevel("Map_Level_Gen");
			
		}
		//Back to Camp Finished
		else if(storyChapter == 65)
		{
			Debug.Log ("Launching the final level");
		}
		//Brave At Last Finished - Go to Last Level
		else
		{
			Debug.Log ("Something has gone wrong with the StartNextLevel method in the NextDungeon Script.");
			Debug.Log ("Please let the developers know :D ");
			Application.LoadLevel("Tutorial_Dungeon");
		}
	}
	
}
