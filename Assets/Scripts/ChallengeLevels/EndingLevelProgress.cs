using UnityEngine;
using System.Collections;

public class EndingLevelProgress : MonoBehaviour {

	private string levelProgress;
	private string newLevel;
	private float Timer = 2.0f;
	private bool startTimer = false;

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
			newLevel = "2-1";
			Debug.Log("Loading New Level: " + newLevel);
			startTimer = true;
		}
		else if(levelProgress == "2-12")
		{
			newLevel = "3-1";
			Debug.Log("Loading New Level: " + newLevel);
			startTimer = true;
		}
		else
		{
			if(levelProgress == "1-1")
			{
				newLevel = "1-2";
			}
			else if(levelProgress == "1-2")
			{
				newLevel = "1-3";
			}
			else if(levelProgress == "1-3")
			{
				newLevel = "1-4";
			}
			else if(levelProgress == "1-4")
			{
				newLevel = "1-5";
			}
			else if(levelProgress == "1-5")
			{
				newLevel = "1-6";
			}
			else if(levelProgress == "1-6")
			{
				newLevel = "1-7";
			}
			else if(levelProgress == "1-7")
			{
				newLevel = "1-8";
			}
			else if(levelProgress == "1-8")
			{
				newLevel = "1-9";
			}
			else if(levelProgress == "1-9")
			{
				newLevel = "1-10";
			}
			else if(levelProgress == "1-10")
			{
				newLevel = "1-11";
			}
			else if(levelProgress == "1-11")
			{
				newLevel = "1-12";
			}
			else if(levelProgress == "2-1")
			{
				newLevel = "2-2";
			}
			else if(levelProgress == "2-2")
			{
				newLevel = "2-3";
			}
			else if(levelProgress == "2-3")
			{
				newLevel = "2-4";
			}
			else if(levelProgress == "2-4")
			{
				newLevel = "2-5";
			}
			else if(levelProgress == "2-5")
			{
				newLevel = "2-6";
			}
			else if(levelProgress == "2-6")
			{
				newLevel = "2-7";
			}
			else if(levelProgress == "2-7")
			{
				newLevel = "2-8";
			}
			else if(levelProgress == "2-8")
			{
				newLevel = "2-9";
			}
			else if(levelProgress == "2-9")
			{
				newLevel = "2-10";
			}
			else if(levelProgress == "2-10")
			{
				newLevel = "2-11";
			}
			else if(levelProgress == "2-11")
			{
				newLevel = "2-12";
			}

			Debug.Log("Loading New Level: " + newLevel);
			startTimer = true;
		}
	}



}
