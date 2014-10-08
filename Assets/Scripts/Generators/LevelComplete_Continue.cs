using UnityEngine;
using System.Collections;

public class LevelComplete_Continue : MonoBehaviour {

	public GameObject completeMessage;
	public GameObject robbeContinues;

	//Grab inventory configs
	private int _bows; 
	private int _keys;
	private int _completed;

	void OnTriggerEnter2D (Collider2D Player) 
	{
		Debug.Log ("THIS HAS COLLIDED!!! "+Player);
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
				Debug.Log ("You completed the level!!");

				//Get current inventory and call the set method
				_bows = GameObject.Find("Player").GetComponent<Inventory>().Arrows;
				_keys = GameObject.Find("Player").GetComponent<Inventory>().Keys;
				_completed = GameObject.Find("Player").GetComponent<Inventory>().Completed + 1;
				SetInventoryToPlayerPref (_bows, _keys, _completed);
				//Call the next level based on Exit Door Name
				GetThemeName(_completed);
			}
		}
	}

	private void GetThemeName(int completedDungeons)
	{
		if(completedDungeons == 3)
		{
			PlayerPrefs.SetInt("completed", 0);
			string nextBoss = this.gameObject.name;
			switch (nextBoss)
			{
			case "1":
				Application.LoadLevel("ScaredBoss");
				Debug.Log ("ScaredBoss Loading");
				Invoke("AllowRobbesMovement", 1.5f);
				break;
			case "2":
				Application.LoadLevel("DepthsBoss");
				Debug.Log ("DepthsBoss Loading");
				Invoke("AllowRobbesMovement", 1.5f);
				break;
			case "3":
				Application.LoadLevel("GoblinBoss");
				Debug.Log ("GoblinBoss Loading");
				Invoke("AllowRobbesMovement", 1.5f);
				break;
			default:
				Application.LoadLevel("ScaredBoss");
				Debug.Log ("ScaredBoss Loading due to default");
				Invoke("AllowRobbesMovement", 1.5f);
				break;
			}
		}
		else if(completedDungeons < 3)
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
			case "4":
				Application.LoadLevel("Nightmare_Level");
				Debug.Log ("Nightmare Level Loading");
				Invoke("AllowRobbesMovement", 1.5f);
				break;
			default:
				Debug.Log ("Something has gone wrong");
				break;
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

	//Set current inventory to player prefs
	private void SetInventoryToPlayerPref (int bows, int keys, int completed)
	{
		PlayerPrefs.SetInt("bow", bows);
		PlayerPrefs.SetInt("keys", keys);
		PlayerPrefs.SetInt("completed", completed);
	}
}