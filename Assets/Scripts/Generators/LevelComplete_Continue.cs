using UnityEngine;
using System.Collections;

public class LevelComplete_Continue : MonoBehaviour {

	public GameObject completeMessage;
	public GameObject robbeContinues;

	
	void OnCollisionEnter2D (Collision2D Player) 
	{

		if(Player.gameObject.tag == "Player")
		{
			if(robbeContinues == null)
			{
				
				//Find Robbe's gameobject and set his transform to the Spawn Location.
				GameObject resetRobbe = GameObject.Find ("Player");
				GameObject respawn = GameObject.Find("Spawn_Location");
				resetRobbe.transform.position = respawn.transform.position;

				//Set Robbe to Kinematic to zero out any velocity
				resetRobbe.rigidbody2D.isKinematic = true;
				
				//Find Robbe's controller and prevent his movement.
				FakeRobbeController _robbe = GameObject.Find("Player").GetComponent<FakeRobbeController>();
				_robbe.canMove = false;
				
				//Find the LookDown camera and prevent its movement.
				NoFaithController _lookdown = GameObject.Find("Camera").GetComponent<NoFaithController>();
				_lookdown.canMove = false;
				
				//Instantiate the continue splash and overlay Robbe.
				robbeContinues = Instantiate(completeMessage, resetRobbe.transform.position, Quaternion.identity) as GameObject;
				robbeContinues.transform.OverlayPosition(resetRobbe.transform);
				robbeContinues.transform.localScale = new Vector3(15.0f,15.0f,1.0f);

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
		FakeRobbeController _robbe = GameObject.Find("Player").GetComponent<FakeRobbeController>();
		_robbe.canMove = true;
		_robbe.rigidbody2D.isKinematic = false;
		
		//Find the LookDown camera and allow its movement.
		NoFaithController _lookdown = GameObject.Find("Camera").GetComponent<NoFaithController>();
		_lookdown.canMove = true;
	}
}