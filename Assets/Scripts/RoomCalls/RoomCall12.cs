using UnityEngine;
using System.Collections;

public class RoomCall12 : MonoBehaviour {

	private string roomTypeValue12;
	
	// Use this for initialization
	public void GetMatrix12Value()
	{
		UpdatedGenerator matrixValue12 = GameObject.Find ("Dungeon Generator").GetComponent<UpdatedGenerator>();
		roomTypeValue12 = (matrixValue12.mapMatrix[6]);
		AssignRoomType(roomTypeValue12);
		
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
			roomAGet.startingPositionA = new Vector3(20.0f, -8.0f, 0.0f);
			roomAGet.roomValue = roomType;
			roomAGet.BeginRoom();
			//Debug.Log ("This needs to be an A room in 12.");
			break;
		case "B":
			//Find the RoomB script
			RoomB roomBGet = GameObject.Find("Matrix00").GetComponent<RoomB>();
			roomBGet.startingPositionB = new Vector3(20.0f, -8.0f, 0.0f);
			roomBGet.roomValue = roomType;
			roomBGet.BeginRoom();
			//Debug.Log ("This needs to be an B room in 12.");
			break;
		case "C":
			//Find the RoomC script
			RoomC roomCGet = GameObject.Find("Matrix00").GetComponent<RoomC>();
			roomCGet.startingPositionC = new Vector3(20.0f, -8.0f, 0.0f);
			roomCGet.roomValue = roomType;
			roomCGet.BeginRoom();
			//Debug.Log ("This needs to be an C room in 12.");
			break;
		case "D":
			//Find the RoomD script
			RoomD roomDGet = GameObject.Find("Matrix00").GetComponent<RoomD>();
			roomDGet.startingPositionD = new Vector3(20.0f, -8.0f, 0.0f);
			roomDGet.roomValue = roomType;
			roomDGet.BeginRoom();
			//Debug.Log ("This needs to be an D room in 12.");
			break;
		case "E":
			//Find the RoomE script
			RoomE roomEGet = GameObject.Find("Matrix00").GetComponent<RoomE>();
			roomEGet.startingPositionE = new Vector3(20.0f, -8.0f, 0.0f);
			roomEGet.roomValue = roomType;
			roomEGet.BeginRoom();
			//Debug.Log ("This needs to be an E room in 12.");			
			break;
		case "F":
			//Find the RoomF script
			RoomF roomFGet = GameObject.Find("Matrix00").GetComponent<RoomF>();
			roomFGet.startingPositionF = new Vector3(20.0f, -8.0f, 0.0f);
			roomFGet.roomValue = roomType;
			roomFGet.BeginRoom();
			//Debug.Log ("This needs to be an F room in 12.");
			break;
		case "G":
			//Find the RoomG script
			RoomG roomGGet = GameObject.Find("Matrix00").GetComponent<RoomG>();
			roomGGet.startingPositionG = new Vector3(20.0f, -8.0f, 0.0f);
			roomGGet.roomValue = roomType;
			roomGGet.BeginRoom();
			//Debug.Log ("This needs to be an G room in 12.");
			break;
		case "H":
			//Find the RoomH script
			RoomH roomHGet = GameObject.Find("Matrix00").GetComponent<RoomH>();
			roomHGet.startingPositionH = new Vector3(20.0f, -8.0f, 0.0f);
			roomHGet.roomValue = roomType;
			roomHGet.BeginRoom();
			//Debug.Log ("This needs to be an H room in 12.");
			break;
		case "O":
			//Find the RoomO script
			RoomO roomOGet = GameObject.Find("Matrix00").GetComponent<RoomO>();
			roomOGet.startingPositionO = new Vector3(20.0f, -8.0f, 0.0f);
			roomOGet.roomValue = roomType;
			roomOGet.BeginRoom();
			//Debug.Log ("This needs to be an O room in 12.");
			break;
		default:
			Debug.Log ("Something went wrong in 12.");
			break;
		}
	}
}
