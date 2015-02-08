using UnityEngine;
using System.Collections;

public class ExitDoorName : MonoBehaviour {



	// Use this for initialization
	void Start () 
	{

		string _names = this.gameObject.name;
		//Debug.Log("MY NAME IS: "+_names);
		switch (_names)
		{
		case "NExit":
			this.gameObject.name = "4";
			Debug.Log("MY NAME IS: "+this.gameObject.name);
			break;
		case "DepthsExit":
			this.gameObject.name = "3";
			Debug.Log("MY NAME IS: "+this.gameObject.name);
			break;
		case "GoblinExit":
			this.gameObject.name = "1";
			Debug.Log("MY NAME IS: "+this.gameObject.name);
			break;
		case "WolfExit":
			this.gameObject.name = "2";
			Debug.Log ("My name is: "+this.gameObject.name);
			break;
		case "BullyExit":
			this.gameObject.name = "5";
			Debug.Log ("My name is: "+this.gameObject.name);
			break;
		default:
			Debug.Log ("Something went wrong with the exit door!");
			break;
		}
	}

	public void OnCollisionEnter2D (Collision2D other)
	{
		if(other.gameObject.tag == "Player")
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
				Debug.Log ("Something has gone wrong when setting the Current Boss " + levelName + " to completed.");
				break;
			}
			Debug.Log ("The OnCollision Ran!");
		}

	}
}
