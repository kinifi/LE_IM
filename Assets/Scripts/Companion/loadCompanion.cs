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

						if(companions[i].name == "BluePixelCompanion" || companions[i].name == "DeveloperCompanion")
						{
							GameObject _companion;
							_companion = Instantiate(companions[i].gameObject, this.transform.position, Quaternion.identity) as GameObject;
							_companion.name = "Companion";
							Debug.Log("Created Companion");
						}
						else
						{
							//Spawn multiple fireflies
							GameObject _companion;
							_companion = Instantiate(companions[i].gameObject, this.transform.position, Quaternion.identity) as GameObject;
							_companion.name = "Companion1";
							_companion.GetComponent<companionBehavior>().m_followSpeed = Random.Range(2,8);
							_companion.GetComponent<companionBehavior>().m_maxDistanceFromPlayer = Random.Range(1,3);
							Debug.Log("Created Companion 1");

							GameObject _companion2;
							_companion2 = Instantiate(companions[i].gameObject, this.transform.position, Quaternion.identity) as GameObject;
							_companion2.name = "Companion2";
							_companion2.GetComponent<companionBehavior>().m_followSpeed = Random.Range(2,8);
							_companion2.GetComponent<companionBehavior>().m_maxDistanceFromPlayer = Random.Range(1,3);
							Debug.Log("Created Companion 2");

							GameObject _companion3;
							_companion3 = Instantiate(companions[i].gameObject, this.transform.position, Quaternion.identity) as GameObject;
							_companion3.name = "Companion3";
							_companion3.GetComponent<companionBehavior>().m_followSpeed = Random.Range(2,8);
							_companion3.GetComponent<companionBehavior>().m_maxDistanceFromPlayer = Random.Range(1,3);
							Debug.Log("Created Companion 3");

						}
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
