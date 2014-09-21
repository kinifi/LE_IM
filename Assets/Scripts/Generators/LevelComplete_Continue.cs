using UnityEngine;
using System.Collections;

public class LevelComplete_Continue : MonoBehaviour {

	public GameObject completeMessage;
	public GameObject robbeContinues;

	
	void OnTriggerEnter2D (Collider2D Player) 
	{

		if(Player.gameObject.tag == "Player")
		{
			if(robbeContinues == null)
			{
				
				//Instantiate the continue splash and overlay Robbe.
				GameObject resetRobbe = GameObject.Find ("Player");
				robbeContinues = Instantiate(completeMessage, resetRobbe.transform.position, Quaternion.identity) as GameObject;
				robbeContinues.transform.OverlayPosition(resetRobbe.transform);
				robbeContinues.transform.localScale = new Vector3(15.0f,15.0f,1.0f);

				//Find Robbe's gameobject and set his transform to the Spawn Location.
				GameObject respawn = GameObject.Find("Spawn_Location");
				resetRobbe.transform.position = respawn.transform.position;

				//Find Robbe's controller and prevent his movement.
				RobbeController _robbe = GameObject.Find("Player").GetComponent<RobbeController>();
				_robbe.enabled = false;
				
				//Find the LookDown camera and prevent its movement.
				NoFaithController _lookdown = GameObject.Find("Camera").GetComponent<NoFaithController>();
				_lookdown.enabled = false;
				


				Destroy(robbeContinues, 2.5f);

				//Let me know you comopleted the level!
				Debug.Log ("You completed the level!!");

				//Load the next level and Call the movement function.
				Application.LoadLevel("Map_Level_Gen");
				Invoke("AllowRobbesMovement", 1.5f);
			}
		}
	}

	private void AllowRobbesMovement() 
	{
		//Find Robbe and allow his movement again.  Turn kinematic to false.
		RobbeController _robbe = GameObject.Find("Player").GetComponent<RobbeController>();
		_robbe.enabled = true;

		//Find the LookDown camera and allow its movement.
		NoFaithController _lookdown = GameObject.Find("Camera").GetComponent<NoFaithController>();
		_lookdown.enabled = true;
	}
}