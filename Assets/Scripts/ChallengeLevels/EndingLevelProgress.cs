using UnityEngine;
using System.Collections;

public class EndingLevelProgress : MonoBehaviour {

	private string levelProgress;
	private string newLevel;
	private float Timer = 2.0f;
	private bool startTimer = false;

	//SUPER NOTE!!! PlayerPref TF3 = Levels Completed!! <------- !!!!!!! READ !!!!!!!

	// Use this for initialization
	void Start () {
		getPlayerPrefData();
	}
	
	// Update is called once per frame
	void Update () {

		if(startTimer)
		{
			Timer -= Time.deltaTime;
			if(Timer < 0)
			{
				Application.LoadLevel(newLevel);
			}
		}
	
	}

	public void getPlayerPrefData()
	{
		if(PlayerPrefs.HasKey("PreviousLevel"))
		{
			levelProgress = PlayerPrefs.GetString("PreviousLevel");
			Debug.Log(levelProgress);
			parseNewLevel();
		}
		else
		{
			Debug.Log("No Data");
		}
	}

	public void parseNewLevel()
	{
		if(levelProgress == "1-12")
		{
			//Log level completion to playerprefs

			PlayerPrefs.SetInt( "TF3", 12);
			Debug.Log ("TF3 logged");
			//Assign next level
			newLevel = "2-1";
			//Debug and start timer
			Debug.Log("Loading New Level: " + newLevel);
			startTimer = true;
		}
		else if(levelProgress == "2-12")
		{
			//Log level completion to playerprefs
			PlayerPrefs.SetInt( "TF3", 24);
			Debug.Log ("TF3 logged");
			//Assign next level
			newLevel = "3-1";
			//Debug and start timer
			Debug.Log("Loading New Level: " + newLevel);
			startTimer = true;
		}
		else if(levelProgress == "3-12")
		{
			//Log level completion to playerprefs
			PlayerPrefs.SetInt( "TF3", 36);
			Debug.Log ("TF3 logged");
			//UNLOCK 100% STAT!!!! <--------------------- THIS IS THE 100% POINT!!!!!
			SteamManager.StatsAndAchievements.Unlock_Full_Tank_Achievement(); 
			//Return to Main Menu
			Application.LoadLevel("Main_Menu");
			startTimer = true;
		}
		else
		{
			if(levelProgress == "1-1")
			{
				//Log level completion to playerprefs
				PlayerPrefs.SetInt( "TF3", 1);
				Debug.Log ("TF3 logged");
				//Assign next level
				newLevel = "1-2";
			}
			else if(levelProgress == "1-2")
			{
				//Log level completion to playerprefs
				PlayerPrefs.SetInt( "TF3", 2);
				Debug.Log ("TF3 logged");
				//Assign next level
				newLevel = "1-3";
			}
			else if(levelProgress == "1-3")
			{
				//Log level completion to playerprefs
				PlayerPrefs.SetInt( "TF3", 3);
				Debug.Log ("TF3 logged");
				//Assign next level
				newLevel = "1-4";
			}
			else if(levelProgress == "1-4")
			{
				//Log level completion to playerprefs
				PlayerPrefs.SetInt( "TF3", 4);
				Debug.Log ("TF3 logged");
				//Assign next level
				newLevel = "1-5";
			}
			else if(levelProgress == "1-5")
			{
				//Log level completion to playerprefs
				PlayerPrefs.SetInt( "TF3", 5);
				Debug.Log ("TF3 logged");
				//Assign next level
				newLevel = "1-6";
			}
			else if(levelProgress == "1-6")
			{
				//Log level completion to playerprefs
				PlayerPrefs.SetInt( "TF3", 6);
				Debug.Log ("TF3 logged");
				//Assign next level
				newLevel = "1-7";
			}
			else if(levelProgress == "1-7")
			{
				//Log level completion to playerprefs
				PlayerPrefs.SetInt( "TF3", 7);
				Debug.Log ("TF3 logged");
				//Assign next level
				newLevel = "1-8";
			}
			else if(levelProgress == "1-8")
			{
				//Log level completion to playerprefs
				PlayerPrefs.SetInt( "TF3", 8);
				Debug.Log ("TF3 logged");
				//Assign next level
				newLevel = "1-9";
			}
			else if(levelProgress == "1-9")
			{
				//Log level completion to playerprefs
				PlayerPrefs.SetInt( "TF3", 9);
				Debug.Log ("TF3 logged");
				//Assign next level
				newLevel = "1-10";
			}
			else if(levelProgress == "1-10")
			{
				//Log level completion to playerprefs
				PlayerPrefs.SetInt( "TF3", 10);
				Debug.Log ("TF3 logged");
				//Assign next level
				newLevel = "1-11";
			}
			else if(levelProgress == "1-11")
			{
				//Log level completion to playerprefs
				PlayerPrefs.SetInt( "TF3", 11);
				Debug.Log ("TF3 logged");
				//Assign next level
				newLevel = "1-12";
			}
			else if(levelProgress == "2-1")
			{
				//Log level completion to playerprefs
				PlayerPrefs.SetInt( "TF3", 13);
				Debug.Log ("TF3 logged");
				//Assign next level
				newLevel = "2-2";
			}
			else if(levelProgress == "2-2")
			{
				//Log level completion to playerprefs
				PlayerPrefs.SetInt( "TF3", 14);
				Debug.Log ("TF3 logged");
				//Assign next level
				newLevel = "2-3";
			}
			else if(levelProgress == "2-3")
			{
				//Log level completion to playerprefs
				PlayerPrefs.SetInt( "TF3", 15);
				Debug.Log ("TF3 logged");
				//Assign next level
				newLevel = "2-4";
			}
			else if(levelProgress == "2-4")
			{
				//Log level completion to playerprefs
				PlayerPrefs.SetInt( "TF3", 16);
				Debug.Log ("TF3 logged");
				//Assign next level
				newLevel = "2-5";
			}
			else if(levelProgress == "2-5")
			{
				//Log level completion to playerprefs
				PlayerPrefs.SetInt( "TF3", 17);
				Debug.Log ("TF3 logged");
				//Assign next level
				newLevel = "2-6";
			}
			else if(levelProgress == "2-6")
			{
				//Log level completion to playerprefs
				PlayerPrefs.SetInt( "TF3", 18);
				Debug.Log ("TF3 logged");
				//UNLOCK HALFWAY STAT!!!  <--------------------- HERE IS THE HALFWAY POINT!!!
				SteamManager.StatsAndAchievements.Unlock_Halfway_There_Achievement();
				//Assign next level
				newLevel = "2-7";
			}
			else if(levelProgress == "2-7")
			{
				//Log level completion to playerprefs
				PlayerPrefs.SetInt( "TF3", 19);
				Debug.Log ("TF3 logged");
				//Assign next level
				newLevel = "2-8";
			}
			else if(levelProgress == "2-8")
			{
				//Log level completion to playerprefs
				PlayerPrefs.SetInt( "TF3", 20);
				Debug.Log ("TF3 logged");
				//Assign next level
				newLevel = "2-9";
			}
			else if(levelProgress == "2-9")
			{
				//Log level completion to playerprefs
				PlayerPrefs.SetInt( "TF3", 21);
				Debug.Log ("TF3 logged");
				//Assign next level
				newLevel = "2-10";
			}
			else if(levelProgress == "2-10")
			{
				//Log level completion to playerprefs
				PlayerPrefs.SetInt( "TF3", 22);
				Debug.Log ("TF3 logged");
				//Assign next level
				newLevel = "2-11";
			}
			else if(levelProgress == "2-11")
			{
				//Log level completion to playerprefs
				PlayerPrefs.SetInt( "TF3", 23);
				Debug.Log ("TF3 logged");
				//Assign next level
				newLevel = "2-12";
			}
			else if(levelProgress == "3-1")
			{
				//Log level completion to playerprefs
				PlayerPrefs.SetInt( "TF3", 25);
				Debug.Log ("TF3 logged");
				//Assign next level
				newLevel = "3-2";
			}
			else if(levelProgress == "3-2")
			{
				//Log level completion to playerprefs
				PlayerPrefs.SetInt( "TF3", 26);
				Debug.Log ("TF3 logged");
				//Assign next level
				newLevel = "3-3";
			}
			else if(levelProgress == "3-3")
			{
				//Log level completion to playerprefs
				PlayerPrefs.SetInt( "TF3", 27);
				Debug.Log ("TF3 logged");
				//Assign next level
				newLevel = "3-4";
			}
			else if(levelProgress == "3-4")
			{
				//Log level completion to playerprefs
				PlayerPrefs.SetInt( "TF3", 28);
				Debug.Log ("TF3 logged");
				//Assign next level
				newLevel = "3-5";
			}
			else if(levelProgress == "3-5")
			{
				//Log level completion to playerprefs
				PlayerPrefs.SetInt( "TF3", 29);
				Debug.Log ("TF3 logged");
				//Assign next level
				newLevel = "3-6";
			}
			else if(levelProgress == "3-6")
			{
				//Log level completion to playerprefs
				PlayerPrefs.SetInt( "TF3", 30);
				Debug.Log ("TF3 logged");
				//Assign next level
				newLevel = "3-7";
			}
			else if(levelProgress == "3-7")
			{
				//Log level completion to playerprefs
				PlayerPrefs.SetInt( "TF3", 31);
				Debug.Log ("TF3 logged");
				//Assign next level
				newLevel = "3-8";
			}
			else if(levelProgress == "3-8")
			{
				//Log level completion to playerprefs
				PlayerPrefs.SetInt( "TF3", 32);
				Debug.Log ("TF3 logged");
				//Assign next level
				newLevel = "3-9";
			}
			else if(levelProgress == "3-9")
			{
				//Log level completion to playerprefs
				PlayerPrefs.SetInt( "TF3", 33);
				Debug.Log ("TF3 logged");
				//Assign next level
				newLevel = "3-10";
			}
			else if(levelProgress == "3-10")
			{
				//Log level completion to playerprefs
				PlayerPrefs.SetInt( "TF3", 34);
				Debug.Log ("TF3 logged");
				//Assign next level
				newLevel = "3-11";
			}
			else if(levelProgress == "3-11")
			{
				//Log level completion to playerprefs
				PlayerPrefs.SetInt( "TF3", 35);
				Debug.Log ("TF3 logged");
				//Assign next level
				newLevel = "3-12";
			}
			Debug.Log("Loading New Level: " + newLevel);
			startTimer = true;
		}
	}



}
