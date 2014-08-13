using UnityEngine;
using System.Collections;

public class LevelComplete_Continue : MonoBehaviour {

	public GameObject completeMessage;
	public GameObject robbeContinues;
	private Vector3 correctContinueView;
	
	
	void OnCollisionEnter2D (Collision2D Player) 
	{

		if(Player.gameObject.tag == "Player")
		{
			if(robbeContinues == null)
			{
				
				//Find Robbe's gameobject and set his transform to the entrance.
				GameObject resetRobbe = GameObject.Find ("Player");
				Vector2 resetTransform = new Vector2(-3.5f, -0.9f);
				Vector3 resetScale = new Vector3(1.0f, 1.0f, 1.0f);
				resetRobbe.transform.position = resetTransform;

				//Set his scale to facing forward.
				resetRobbe.transform.localScale = resetScale;
				
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
				Destroy(robbeContinues, 2.0f);

				//Let me know you comopleted the level!
				Debug.Log ("You completed the level!!");

				//Load the next level and Call the movement function.
				Application.LoadLevel("Map_Level_Gen");
				Invoke("AllowRobbesMovement", 2.5f);
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