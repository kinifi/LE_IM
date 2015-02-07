using UnityEngine;
using System.Collections;

public class setCompanion : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}

	/// <summary>
	/// Sets the name of the companion.
	/// </summary>
	public void setCompanionData(string companionName)
	{
		if(PlayerPrefs.HasKey("companion"))
		{
			Debug.Log("Setting Companion");
			PlayerPrefs.SetString("companion", companionName);
		}
		else
		{
			Debug.Log("Companion Key doesnt Exist. Creating new Key");
			PlayerPrefs.SetString("companion", companionName);
		}


		Debug.Log("Companion Set!");
	}
}
