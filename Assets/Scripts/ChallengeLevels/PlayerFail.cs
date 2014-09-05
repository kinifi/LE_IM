using UnityEngine;
using System.Collections;

public class PlayerFail : MonoBehaviour {

	public GameObject FadeObj;

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
			FadeObj.SetActive(true);
			Invoke("loadFailLevel", 1.0f);
			Debug.Log("Player Fell");
		}
	}

	private void loadFailLevel()
	{
		Application.LoadLevel("FailedLevel");
	}

}
