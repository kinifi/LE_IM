using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ExitDoor : MonoBehaviour {

	public GameObject endScreen;

	// Use this for initialization
	void Start () {
	
	}
	
	void OnTriggerEnter2D(Collider2D other) {
		
		if(other.name == "Player")
		{
			endScreen.SetActive(true);
		}

	}
}
