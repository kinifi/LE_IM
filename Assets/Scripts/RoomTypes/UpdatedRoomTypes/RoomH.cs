using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RoomH : MonoBehaviour {

	//Set up room 
	public GameObject[] tileOfRoom;
	public Vector3 startingPosition0;
	private Vector3 roomTilePosition;
	private List<int> lineBreaks = new List<int>(new int[] {10,20,30,40,50,60,70});

	//configs for room type
	string roomValue;

	// Use this for initialization
	void Start () 
	{
		//grab the string value of the current room type
		roomValue = GameObject.Find ("Dungeon Generator").GetComponent<UpdatedGenerator>().mapMatrix[0];
	}

	public void BeginRoom ()
	{
		Debug.Log ("The room has started.");
		AssignRoomArray();
	}

	public void AssignRoomArray ()
	{
		//find the first part of the room type
		string roomPart1 = roomValue[0].ToString();
		//find the second part of the room type
		string roomPart2 = roomValue[2].ToString();

		//determine the first part of the next room
		switch(roomPart2)
		{
		case "A":
			Debug.Log("The room type is: " + roomPart1 + ",A");
			break;
		case "B":
			Debug.Log("The room type is: " + roomPart1 + ",B");
			break;
		case "C":
			Debug.Log("The room type is: " + roomPart1 + ",C");
			break;
		case "D":
			Debug.Log("The room type is: " + roomPart1 + ",D");
			break;
		case "E":
			Debug.Log("The room type is: " + roomPart1 + ",E");
			break;
		case "F":
			Debug.Log("The room type is: " + roomPart1 + ",F");
			break;
		default:
			Debug.Log("The room type is: " + roomPart1 + roomPart2);
			Debug.Log("Something went wrong when selecting RoomPart2 for in RoomH");
			break;
		}
	}
}
