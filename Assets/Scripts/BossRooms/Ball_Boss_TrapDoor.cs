using UnityEngine;
using System.Collections;

public class Ball_Boss_TrapDoor : MonoBehaviour {

	//This gameobject is set in the inspector
	public GameObject trapDoors;

	// Use this for initialization
	void Start () 
	{
		//confirm trapDoors are not active
		trapDoors.SetActive(false);
	}
	
	void OnTriggerExit2D (Collider2D other)
	{
		if(other.gameObject.tag == "Player")
		{
			trapDoors.SetActive(true);
			Debug.Log ("The trap doors have shut!");
		}
	}
}
