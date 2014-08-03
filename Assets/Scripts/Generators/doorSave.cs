using UnityEngine;
using System.Collections;

public class doorSave : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter2D(Collision2D coll)
	{

		if(coll.transform.name == "Player")
		{
			PlayerPrefs.SetString("tutorialDone", "true");
		}

	}
}
