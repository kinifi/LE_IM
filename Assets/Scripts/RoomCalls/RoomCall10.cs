using UnityEngine;
using System.Collections;

public class RoomCall10 : MonoBehaviour {

	public int matrixValue10;
	private float roomTypeValue10;
	
	// Use this for initialization
	public void GetMatrix10Value()
	{
		MapGenerator matrixValue10 = GameObject.Find("Dungeon Generator").GetComponent<MapGenerator>();
		roomTypeValue10 = (matrixValue10.mapMatrix[1,0]);
		AssignRoomType(roomTypeValue10);
		
	}
	
	void AssignRoomType (float matrix10RoomType) {
		
		if (matrix10RoomType == 0.0f)
		{
			RoomTypeZero room0Get = GameObject.Find("Matrix00").GetComponent<RoomTypeZero>();
			room0Get.startingPosition0 = new Vector3(0.0f, -8.0f, 0.0f);
			room0Get.BeginRoom0();
			//Debug.Log ("This needs to be a zero room in 10.");
		}
		else if(matrix10RoomType == 1.0f)
		{
			RoomTypeOne room1Get = GameObject.Find("Matrix00").GetComponent<RoomTypeOne>();
			room1Get.startingPosition1 = new Vector3(0.0f, -8.0f, 0.0f);
			room1Get.BeginRoom1();
			//Debug.Log("Case 10 1 was called.");
		}
		else if(matrix10RoomType == 2.0f)
		{
			RoomTypeTwo room2Get = GameObject.Find("Matrix00").GetComponent<RoomTypeTwo>();
			room2Get.startingPosition2 = new Vector3(0.0f, -8.0f, 0.0f);
			room2Get.BeginRoom2();
			//Debug.Log ("Case 10 2 was called.");
		}
		else if(matrix10RoomType == 3.0f)
		{
			RoomTypeThree room3Get = GameObject.Find("Matrix00").GetComponent<RoomTypeThree>();
			room3Get.startingPosition3 = new Vector3(0.0f, -8.0f, 0.0f);
			room3Get.BeginRoom3();
			//Debug.Log("Case 10 3 was called.");
		}
		else if(matrix10RoomType == 4.0f)
		{
			RoomTypeFour room4Get = GameObject.Find("Matrix00").GetComponent<RoomTypeFour>();
			room4Get.startingPosition4 = new Vector3(0.0f, -8.0f, 0.0f);
			room4Get.BeginRoom4();
			//Debug.Log ("Case 00 4 was called.");
		}
		else if(matrix10RoomType == 5.0f)
		{
			RoomTypeFive room5Get = GameObject.Find("Matrix00").GetComponent<RoomTypeFive>();
			room5Get.startingPosition5 = new Vector3(0.0f, -8.0f, 0.0f);
			room5Get.BeginRoom5();
			//Debug.Log("Case 10 5 was called.");
		}
		else if(matrix10RoomType == 0.333f)
		{
			RoomTypeExit roomEGet = GameObject.Find("Matrix00").GetComponent<RoomTypeExit>();
			roomEGet.startingPositionE = new Vector3(0.0f, -8.0f, 0.0f);
			roomEGet.BeginRoomE();
			//Debug.Log ("The 10 exit was called.");
		}
		else if (matrix10RoomType == 6.0f)
		{
			RoomTypeTutorial roomTGet = GameObject.Find("Matrix00").GetComponent<RoomTypeTutorial>();
			roomTGet.startingPositionT = new Vector3(0.0f, -8.0f, 0.0f);
			roomTGet.BeginRoomTutorial();
			//Debug.Log ("The 10 tutorial was called");
		}
		else
		{
			Debug.Log ("Something went wrong in 10.");
		}
		
	}
}
