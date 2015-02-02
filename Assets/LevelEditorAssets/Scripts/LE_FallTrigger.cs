using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LE_FallTrigger : MonoBehaviour {

	public GameObject deathScreen;

	// Use this for initialization
	void Start () {
	
		if(Application.loadedLevelName == "OneOffLevel")
		{
			deathScreen = GameObject.Find("Canvas");

			foreach (Transform item in deathScreen.transform) {

				if(item.name == "DeathPanel")
				{
					deathScreen = item.gameObject;
				}

			}

		}
		else
		{
			Debug.Log("Not in the level");
		}

	}
	
	void OnTriggerEnter2D(Collider2D other) {
		
		if(other.name == "Player")
		{
			deathScreen.SetActive(true);
		}
		else
		{
			Destroy(other.gameObject);
		}
		
	}
}
