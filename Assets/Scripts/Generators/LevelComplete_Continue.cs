using UnityEngine;
using System.Collections;

public class LevelComplete_Continue : MonoBehaviour {

	public GameObject completeMessage;
	public GameObject robbeContinues;
	
	
	void OnCollisionEnter2D (Collision2D Player) 
	{

		if(Player.gameObject.tag == "Player")
		{
			Transform currentTransform = GameObject.Find("FakeRobbe").GetComponent<Transform>();
			if(robbeContinues == null)
			{
				robbeContinues = Instantiate(completeMessage, currentTransform.position, Quaternion.identity) as GameObject;
				robbeContinues.transform.parent = currentTransform;
				Debug.Log ("You completed the level!!");
				Application.LoadLevel("Map_Level_Gen");
			}
		}
	}
}