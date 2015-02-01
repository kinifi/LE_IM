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
	
	void AssignRoomType (string roomType) 
	{
		//find the first part of the assigned room
		string firstPart = roomType[0].ToString();

		//determine the first part of the next room
		switch(firstPart)
		{
		case "A":
			//Find the RoomA script
			RoomA roomAGet = GameObject.Find("Matrix00").GetComponent<RoomA>();
			roomAGet.startingPositionA = Vector3.zero;
			roomAGet.roomValue = roomType;
			roomAGet.BeginRoom();
			//Debug.Log ("This needs to be an A room in 00.");
			break;
		case "B":
			//Find the RoomB script
			RoomB roomBGet = GameObject.Find("Matrix00").GetComponent<RoomB>();
			roomBGet.startingPositionB = Vector3.zero;
			roomBGet.roomValue = roomType;
			roomBGet.BeginRoom();
			//Debug.Log ("This needs to be an B room in 00.");
			break;
		case "C":
			//Find the RoomC script
			RoomC roomCGet = GameObject.Find("Matrix00").GetComponent<RoomC>();
			roomCGet.startingPositionC = Vector3.zero;
			roomCGet.roomValue = roomType;
			roomCGet.BeginRoom();
			//Debug.Log ("This needs to be an C room in 00.");
			break;
		case "D":
			//Find the RoomD script
			RoomD roomDGet = GameObject.Find("Matrix00").GetComponent<RoomD>();
			roomDGet.startingPositionD = Vector3.zero;
			roomDGet.roomValue = roomType;
			roomDGet.BeginRoom();
			//Debug.Log ("This needs to be an D room in 00.");
			break;
		case "E":
			//Find the RoomE script
			RoomE roomEGet = GameObject.Find("Matrix00").GetComponent<RoomE>();
			roomEGet.startingPositionE = Vector3.zero;
			roomEGet.roomValue = roomType;
			roomEGet.BeginRoom();
			//Debug.Log ("This needs to be an E room in 00.");			
			break;
		case "F":
			//Find the RoomF script
			RoomF roomFGet = GameObject.Find("Matrix00").GetComponent<RoomF>();
			roomFGet.startingPositionF = Vector3.zero;
			roomFGet.roomValue = roomType;
			roomFGet.BeginRoom();
			//Debug.Log ("This needs to be an F room in 00.");
			break;
		case "G":
			//Find the RoomG script
			RoomG roomGGet = GameObject.Find("Matrix00").GetComponent<RoomG>();
			roomGGet.startingPositionG = Vector3.zero;
			roomGGet.roomValue = roomType;
			roomGGet.BeginRoom();
			//Debug.Log ("This needs to be an G room in 00.");
			break;
		case "H":
			//Find the RoomH script
			RoomH roomHGet = GameObject.Find("Matrix00").GetComponent<RoomH>();
			roomHGet.startingPositionH = Vector3.zero;
			roomHGet.roomValue = roomType;
			roomHGet.BeginRoom();
			//Debug.Log ("This needs to be an H room in 00.");
			break;
		case "O":
			//Find the RoomO script
			RoomO roomOGet = GameObject.Find("Matrix00").GetComponent<RoomO>();
			roomOGet.startingPositionO = Vector3.zero;
			roomOGet.roomValue = roomType;
			roomOGet.BeginRoom();
			//Debug.Log ("This needs to be an O room in 00.");
			break;
		default:
			Debug.Log ("Something went wrong in 00.");
			break;
		}
	}

}
