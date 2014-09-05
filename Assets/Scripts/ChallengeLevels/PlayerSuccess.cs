using UnityEngine;
using System.Collections;

public class PlayerSuccess : MonoBehaviour {

	// Use this for initialization
	void Start () {
		this.collider2D.isTrigger = true;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D coll)
	{
		if(coll.transform.name == "Challenge_Player")
		{
			Debug.Log("Player Success");
		}
	}

}
