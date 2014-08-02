using UnityEngine;
using System.Collections;

public class RoomCall20 : MonoBehaviour {

	public int matrixValue20;
	private float roomTypeValue20;
	
	// Use this for initialization
	public void GetMatrix20Value()
	{
		MapGenerator matrixValue20 = GameObject.Find("Dungeon Generator").GetComponent<MapGenerator>();
		roomTypeValue20 = (matrixValue20.mapMatrix[2,0]);
		AssignRoomType(roomTypeValue20);
		
	}
	
	void AssignRoomType (float matrix20RoomType) {
		
		if (matrix20RoomType == 0.0f)
		{
			RoomTypeZero room0Get = GameObject.Find("Matrix00").GetComponent<RoomTypeZero>();
			room0Get.startingPosition0 = new Vector3(0.0f, -16.0f, 0.0f);
			room0Get.BeginRoom0();
			//Debug.Log ("This needs to be a zero room in 20.");
		}
		else if(matrix20RoomType == 1.0f)
		{
			RoomTypeOne room1Get = GameObject.Find("Matrix00").GetComponent<RoomTypeOne>();
			room1Get.startingPosition1 = new Vector3(0.0f, -16.0f, 0.0f);
			room1Get.BeginRoom1();
			//Debug.Log("Case 20 1 was called.");
		}
		else if(matrix20RoomType == 2.0f)
		{
			RoomTypeTwo room2Get = GameObject.Find("Matrix00").GetComponent<RoomTypeTwo>();
			room2Get.startingPosition2 = new Vector3(0.0f, -16.0f, 0.0f);
			room2Get.BeginRoom2();
			//Debug.Log ("Case 20 2 was called.");
		}
		else if(matrix20RoomType == 3.0f)
		{
			RoomTypeThree room3Get = GameObject.Find("Matrix00").GetComponent<RoomTypeThree>();
			room3Get.startingPosition3 = new Vector3(0.0f, -16.0f, 0.0f);
			room3Get.BeginRoom3();
			//Debug.Log("Case 20 3 was called.");
		}
		else if(matrix20RoomType == 4.0f)
		{
			RoomTypeFour room4Get = GameObject.Find("Matrix00").GetComponent<RoomTypeFour>();
			room4Get.startingPosition4 = new Vector3(0.0f, -16.0f, 0.0f);
			room4Get.BeginRoom4();
			//Debug.Log ("Case 00 4 was called.");
		}
		else if(matrix20RoomType == 5.0f)
		{
			RoomTypeFive room5Get = GameObject.Find("Matrix00").GetComponent<RoomTypeFive>();
			room5Get.startingPosition5 = new Vector3(0.0f, -16.0f, 0.0f);
			room5Get.BeginRoom5();
			//Debug.Log("Case 20 5 was called.");
		}
		else if(matrix20RoomType == 0.333f)
		{
			RoomTypeExit roomEGet = GameObject.Find("Matrix00").GetComponent<RoomTypeExit>();
			roomEGet.startingPositionE = new Vector3(0.0f, -16.0f, 0.0f);
			roomEGet.BeginRoomE();
			//Debug.Log ("The 20 exit was called.");
		}
		else if (matrix20RoomType == 6.0f)
		{
			RoomTypeTutorial roomTGet = GameObject.Find("Matrix00").GetComponent<RoomTypeTutorial>();
			roomTGet.startingPositionT = new Vector3(0.0f, -16.0f, 0.0f);
			roomTGet.BeginRoomTutorial();
			//Debug.Log ("The 20 tutorial was called");
		}
		else
		{
			Debug.Log ("Something went wrong in 20.");
		}
		
	}
}
