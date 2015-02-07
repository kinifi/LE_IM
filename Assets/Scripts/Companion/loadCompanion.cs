using UnityEngine;
using System.Collections;

public class loadCompanion : MonoBehaviour {

	public GameObject[] companions;

	// Use this for initialization
	void Start () {
	
		loadCompanionData();

	}

	/// <summary>
	/// Loads the companion data.
	/// </summary>
	private void loadCompanionData()
	{
		if(PlayerPrefs.HasKey("companion"))
		{
			string companionValue = PlayerPrefs.GetString("companion");
			if(companionValue == "" || companionValue == "None")
			{
				Debug.Log("No Companion Set");
			}
			else
			{
				//cycle through all the companions and see which one to spawn
				for (int i = 0; i < companions.Length; i++) 
				{
					if(companions[i].name.ToLower() == companionValue.ToLower())
					{
						Debug.Log("Found Companion");
						GameObject _companion;
						_companion = Instantiate(companions[i].gameObject, this.transform.position, Quaternion.identity) as GameObject;
						_companion.name = "Companion";
						Debug.Log("Created Companion");
					}
				}


			}
		}
		else
		{
			Debug.Log("No Companion Set");
		}
	}
}
