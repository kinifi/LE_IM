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
				//Find Robbe's gameobject and set his transform to the Spawn Location.
				GameObject resetRobbe = GameObject.Find ("Player");
				GameObject respawn = GameObject.Find("Spawn_Location");
				resetRobbe.transform.position = respawn.transform.position;

				//Find Robbe's controller and prevent his movement.
				RobbeController _robbe = GameObject.Find("Player").GetComponent<RobbeController>();
				_robbe.enabled = false;
				
				//Find the LookDown camera and prevent its movement.
				NoFaithController _lookdown = GameObject.Find("Camera").GetComponent<NoFaithController>();
				_lookdown.enabled = false;
				
				//Instantiate the continue splash and overlay Robbe.
				robbeContinues = Instantiate(completeMessage, resetRobbe.transform.position, Quaternion.identity) as GameObject;
				robbeContinues.transform.OverlayPosition(resetRobbe.transform);
				robbeContinues.transform.localScale = new Vector3(15.0f,15.0f,1.0f);

				if(Input.GetButtonDown("Fire1"))
				{
					Destroy(robbeContinues);
				}
				else
				{
					Destroy(robbeContinues, 2.5f);
				}

				//Let me know you comopleted the level!
				Debug.Log ("You completed the level!!");

				//Call the next level based on Exit Door Name
				GetThemeName();
			}
		}
	}

	private void GetThemeName()
	{
		string nextTheme = this.gameObject.name;

		switch (nextTheme)
		{
		case "1":
			Application.LoadLevel("Map_Level_Gen");
			Debug.Log ("Map Level Loading");
			Invoke("AllowRobbesMovement", 1.5f);
			break;
		case "2":
			Application.LoadLevel("Dusk_Level");
			Debug.Log ("Dusk Level Loading");
			Invoke("AllowRobbesMovement", 1.5f);
			break;
		case "3":
			Application.LoadLevel("Purple_Level");
			Debug.Log("Purple Level Loading");
			Invoke("AllowRobbesMovement", 1.5f);
			break;
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