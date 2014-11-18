using UnityEngine;
using System.Collections;

public class Teleport : MonoBehaviour {

	public GameObject telaOut;
	void Start ()
	{
		string telaIn = this.gameObject.name;
		string telaOutName = "telaOut" + telaIn;

		Debug.Log ("This is the telaOutName: " + telaOutName);

		telaOut = GameObject.Find(telaOutName);
	}

	void OnTriggerEnter2D (Collider2D other)
	{
		if(other.gameObject.tag == "Player")
		{
			other.transform.position = telaOut.transform.position;
			audio.Play();
		}
	}
}
