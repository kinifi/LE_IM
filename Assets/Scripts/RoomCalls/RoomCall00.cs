using UnityEngine;
using System.Collections;

public class RoomCall00 : MonoBehaviour {

	public int matrixValue00;
	private float roomTypeValue00;

	// Use this for initialization
	public void GetMatrix00Value()
	{
		MapGenerator matrixValue00 = GameObject.Find ("Dungeon Generator").GetComponent<MapGenerator>();
		roomTypeValue00 = (matrixValue00.mapMatrix[0,0]);
		AssignRoomType(roomTypeValue00);

	}
	
	void AssignRoomType (float matrix00RoomType) {
	
		if (matrix00RoomType == 0.0f)
		{
			RoomTypeZero room0Get = GameObject.Find("Matrix00").GetComponent<RoomTypeZero>();
			room0Get.startingPosition0 = Vector3.zero;
			room0Get.BeginRoom0();
			//Debug.Log ("This needs to be a zero room in 00.");
		}
		else if(matrix00RoomType == 1.0f)
		{
			RoomTypeOne room1Get = GameObject.Find("Matrix00").GetComponent<RoomTypeOne>();
			room1Get.startingPosition1 = Vector3.zero;
			room1Get.BeginRoom1();
			//Debug.Log("Case 00 1 was called.");
		}
		else if(matrix00RoomType == 2.0f)
		{
			RoomTypeTwo room2Get = GameObject.Find("Matrix00").GetComponent<RoomTypeTwo>();
			room2Get.startingPosition2 = Vector3.zero;
			room2Get.BeginRoom2();
			//Debug.Log ("Case 00 2 was called.");
		}
		else if(matrix00RoomType == 3.0f)
		{
			RoomTypeThree room3Get = GameObject.Find("Matrix00").GetComponent<RoomTypeThree>();
			room3Get.startingPosition3 = Vector3.zero;
			room3Get.BeginRoom3();
			//Debug.Log ("Case 00 3 was called.");
		}
		else if(matrix00RoomType == 4.0f)
		{
			RoomTypeFour room4Get = GameObject.Find("Matrix00").GetComponent<RoomTypeFour>();
			room4Get.startingPosition4 = Vector3.zero;
			room4Get.BeginRoom4();
			//Debug.Log ("Case 00 4 was called.");
		}
		else if(matrix00RoomType == 5.0f)
		{
			RoomTypeFive room5Get = GameObject.Find("Matrix00").GetComponent<RoomTypeFive>();
			room5Get.startingPosition5 = Vector3.zero;
			room5Get.BeginRoom5();
			//Debug.Log("Case 00 5 was called.");
		}
		else if(matrix00RoomType == 0.333f)
		{
			RoomTypeExit roomEGet = GameObject.Find("Matrix00").GetComponent<RoomTypeExit>();
			roomEGet.startingPositionE = Vector3.zero;
			roomEGet.BeginRoomE();
			//Debug.Log ("The 00 exit was called.");
		}
		else if (matrix00RoomType == 6.0f)
		{
			RoomTypeTutorial roomTGet = GameObject.Find("Matrix00").GetComponent<RoomTypeTutorial>();
			roomTGet.startingPositionT = Vector3.zero;
			roomTGet.BeginRoomTutorial();
			//Debug.Log ("This needs to be a Tutorial room in 00.");
		}
		else
		{
			Debug.Log ("Something went wrong in 00.");
		}

	}

}
