using UnityEngine;
using System.Collections;

public class RoomCall00 : MonoBehaviour {

  	private string roomTypeValue00;

	// Use this for initialization
	public void GetMatrix00Value()
	{
		UpdatedGenerator matrixValue00 = GameObject.Find ("Dungeon Generator").GetComponent<UpdatedGenerator>();
		roomTypeValue00 = (matrixValue00.mapMatrix[0]);
		AssignRoomType(roomTypeValue00);

	}
	
	void AssignRoomType (string roomType) {
	
		//find the first part of the assigned room
		string firstPart = roomType[0].ToString();

		//Determine which roomtype script to use based on the first part of the room type value
		if (firstPart == "H")
		{
			//Find the RoomH script
			RoomH roomHGet = GameObject.Find("Matrix00").GetComponent<RoomH>();
			roomHGet.startingPosition0 = Vector3.zero;
			roomHGet.BeginRoom();
			//Debug.Log ("This needs to be an H room in 00.");
		}
		else
		{
			Debug.Log ("Something went wrong in 0.");
		}

	}

}
