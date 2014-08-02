using UnityEngine;
using System.Collections;

public class RoomCall03 : MonoBehaviour {

	public int matrixValue03;
	private float roomTypeValue03;

	// Use this for initialization
	public void GetMatrix03Value()
	{
		MapGenerator matrixValue03 = GameObject.Find ("Dungeon Generator").GetComponent<MapGenerator>();
		roomTypeValue03 = (matrixValue03.mapMatrix[0,3]);
		AssignRoomType(roomTypeValue03);
		
	}

	void AssignRoomType (float matrix03RoomType) {
		
		if (matrix03RoomType == 0.0f)
		{
			RoomTypeZero room0Get = GameObject.Find("Matrix00").GetComponent<RoomTypeZero>();
			room0Get.startingPosition0 = new Vector3(30.0f, 0.0f, 0.0f);
			room0Get.BeginRoom0();
			//Debug.Log ("This needs to be a zero room in 03.");
		}
		else if(matrix03RoomType == 1.0f)
		{
			RoomTypeOne room1Get = GameObject.Find("Matrix00").GetComponent<RoomTypeOne>();
			room1Get.startingPosition1 = new Vector3(30.0f, 0.0f, 0.0f);
			room1Get.BeginRoom1();
			//Debug.Log("Case 03 1 was called.");
		}
		else if(matrix03RoomType == 2.0f)
		{
			RoomTypeTwo room2Get = GameObject.Find("Matrix00").GetComponent<RoomTypeTwo>();
			room2Get.startingPosition2 = new Vector3(30.0f, 0.0f, 0.0f);
			room2Get.BeginRoom2();
			//Debug.Log("Case 03 2 was called.");
		}
		else if(matrix03RoomType == 3.0f)
		{
			RoomTypeThree room3Get = GameObject.Find("Matrix00").GetComponent<RoomTypeThree>();
			room3Get.startingPosition3 = new Vector3(30.0f, 0.0f, 0.0f);
			room3Get.BeginRoom3();
			//Debug.Log("Case 03 3 was called.");
		}
		else if(matrix03RoomType == 4.0f)
		{
			RoomTypeFour room4Get = GameObject.Find("Matrix00").GetComponent<RoomTypeFour>();
			room4Get.startingPosition4 = new Vector3(30.0f, 0.0f, 0.0f);
			room4Get.BeginRoom4();
			//Debug.Log ("Case 00 4 was called.");
		}
		else if(matrix03RoomType == 5.0f)
		{
			RoomTypeFive room5Get = GameObject.Find("Matrix00").GetComponent<RoomTypeFive>();
			room5Get.startingPosition5 = new Vector3(30.0f, 0.0f, 0.0f);
			room5Get.BeginRoom5();
			//Debug.Log("Case 03 5 was called.");
		}
		else if(matrix03RoomType == 0.333f)
		{
			RoomTypeExit roomEGet = GameObject.Find("Matrix00").GetComponent<RoomTypeExit>();
			roomEGet.startingPositionE = new Vector3(30.0f, 0.0f, 0.0f);
			roomEGet.BeginRoomE();
			//Debug.Log ("The 03 exit was called.");
		}
		else if (matrix03RoomType == 6.0f)
		{
			RoomTypeTutorial roomTGet = GameObject.Find("Matrix00").GetComponent<RoomTypeTutorial>();
			roomTGet.startingPositionT = new Vector3(30.0f, 0.0f, 0.0f);
			roomTGet.BeginRoomTutorial();
			//Debug.Log ("The 03 tutorial was called");
		}
		else
		{
			Debug.Log ("Something went wrong in 03.");
		}
		
	}
}
