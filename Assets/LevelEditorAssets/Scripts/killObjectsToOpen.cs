using UnityEngine;
using System.Collections;

public class killObjectsToOpen : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	void OnTriggerStay2D(Collider2D other) {

		Debug.Log("Here");

		if(other.name != "Player")
		{
			Debug.Log("Killing: " + other.gameObject);
			Destroy(other.gameObject);
		}
		else
		{
			Debug.Log("Not Killing: " + other.gameObject);
		}
	}
}
