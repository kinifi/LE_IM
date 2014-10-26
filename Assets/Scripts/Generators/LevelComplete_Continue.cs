using UnityEngine;
using System.Collections;

public class LevelComplete_Continue : MonoBehaviour {

	public GameObject completeMessage;
	public GameObject robbeContinues;

	//Grab inventory configs
	private int _bows; 
	private int _keys;
	private int _completed;

	//Configs
	string thisDoorName;

	void OnTriggerEnter2D (Collider2D Player) 
	{
		Debug.Log ("The exit door has been colided by!!! "+Player);
		if(Player.gameObject.tag == "Player")
		{
			if(robbeContinues == null)
			{
				//Find Robbe's controller and prevent his movement.
				RobbeController _robbe = GameObject.Find("Player").GetComponent<RobbeController>();
				_robbe.enabled = false;
				
				//Find the LookDown camera and prevent its movement.
				NoFaithController _lookdown = GameObject.Find("Camera").GetComponent<NoFaithController>();
				_lookdown.enabled = false;
				
				//Instantiate the controls splash and overlay Robbe.  Destroy it and call the movement function.
				GameObject completeSplash = Instantiate(completeMessage, _robbe.transform.position, Quaternion.identity) as GameObject;
				completeSplash.transform.OverlayPosition(_robbe.transform);

				//Find Robbe's gameobject and set his transform to the Spawn Location.
				GameObject respawn = GameObject.Find("Spawn_Location");
				_robbe.transform.position = respawn.transform.position;

				if(Input.GetButtonDown("Fire1"))
				{
					Destroy(robbeContinues);
				}
				else
				{
					Destroy(robbeContinues, 2.5f);
				}

				//Let me know you comopleted the level!
				thisDoorName = this.gameObject.name;
				SetDoorNameToPlayerPref(thisDoorName);
				Debug.Log ("You completed the level!!");

				//Get current inventory and call the set method
				_bows = GameObject.Find("Player").GetComponent<Inventory>().Arrows;
				_keys = GameObject.Find("Player").GetComponent<Inventory>().Keys;
				_completed = GameObject.Find("Player").GetComponent<Inventory>().Completed + 1;
				SetInventoryToPlayerPref (_bows, _keys, _completed);
				LoadStoryScreen();
			}
		}
	}

	private void LoadStoryScreen()
	{
		Application.LoadLevel("StoryScreen");
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

	//Set current inventory to player prefs
	private void SetInventoryToPlayerPref (int bows, int keys, int completed)
	{
		PlayerPrefs.SetInt("bow", bows);
		PlayerPrefs.SetInt("keys", keys);
		PlayerPrefs.SetInt("completed", completed);
	}

	private void SetDoorNameToPlayerPref (string doorName)
	{
		PlayerPrefs.SetString("door", doorName);
	}
}