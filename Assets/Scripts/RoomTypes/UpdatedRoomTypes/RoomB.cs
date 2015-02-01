using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RoomB : MonoBehaviour {
	
	//Configs set from Room Call
	private GameObject[] tileOfRoom;
	public Vector3 startingPositionB;
	private Vector3 roomTilePosition;
	private List<int> lineBreaks = new List<int>(new int[] {10,20,30,40,50,60,70});
	
	//room array configs
	private int[] roomArray;
	private int randomPick;
	
	//teleport configs
	private int telaportNumeric = 0;
	private string telaInStringName;
	private string telaOutStringName;
	
	//configs for room type
	public string roomValue;
	
	// Use this for initialization
	void Start () 
	{
		//grab the string value of the current room type
		tileOfRoom = GameObject.Find("Matrix00").GetComponent<RoomTypeZero>().tileOfRoom;
	}
	
	public void BeginRoom ()
	{
		Debug.Log ("The room has started.");
		AssignRoomArray();
		RoomPositionInitalize();
		LoopThroughArray();
		ResetTheRoom();
	}
	
	private void AssignRoomArray ()
	{
		//find the first part of the room type
		string roomPart1 = roomValue[0].ToString();
		//find the second part of the room type
		string roomPart2 = roomValue[2].ToString();
		
		//determine the first part of the next room
		switch(roomPart2)
		{
		case "C":
			//randomly pick which array to use
			randomPick = Random.Range (0,3);
			if(randomPick == 0)
			{
				roomArray = new int[] 
				{
					1,1,1,1,1,0,0,0,0,0,
					1,0,0,0,0,0,0,0,0,0,
					1,0,5,0,0,667,0,21,0,7,
					8,0,0,1,0,0,0,0,0,1,
					0,0,0,0,0,0,0,0,0,1,
					7,0,0,0,0,0,0,0,0,1,
					11,664,0,0,660,0,0,0,3,1,
					1,0,21,141,1,1,0,21,1,1
				};
			}
			else if (randomPick == 1)
			{
				roomArray = new int[] 
				{
					0,1,1,1,0,0,0,0,0,1,
					0,1,13,10,0,0,0,21,0,1,
					0,12,0,0,0,0,0,1,0,1,
					0,1,1,141,0,0,0,1,0,9,
					0,9,11,0,0,0,0,1,0,1,
					1,1,1,1,1,668,0,11,0,1,
					1,50,111,50,50,11,0,11,3,1,
					1,1,1,0,21,1,1,141,11,1
				};
			}
			else
			{
				roomArray = new int[] 
				{
					0,0,0,0,0,0,1,0,0,0,
					0,5,0,0,0,0,1,0,0,0,
					0,0,0,1,1,0,11,0,0,0,
					3,0,0,0,0,0,1,0,7,0,
					1,7,7,7,0,0,8,0,1,0,
					1,1,1,1,0,0,0,0,11,0,
					1,111,50,9,11,3,0,41,1,0,
					11,1,1,1,1,11,1,1,1,1
				};
			}
			Debug.Log("The room type is: " + roomPart1 + ",C");
			break;
		case "D":
			
			//randomly pick which array to use
			randomPick = Random.Range (0,3);
			if(randomPick == 0)
			{
				roomArray = new int[] 
				{
					1,0,21,1,1,0,0,0,0,0,
					1,1,0,21,0,0,0,0,0,1,
					1,1,668,0,0,0,0,15,1,16,
					11,0,0,0,0,0,0,0,0,0,
					142,0,0,0,0,0,0,0,0,0,
					9,1,1,668,0,0,0,0,0,0,
					50,5,1,1,1,0,0,0,0,0,
					11,1,1,1,1,0,21,1,2,1
				};
			}
			else if (randomPick == 1)
			{
				roomArray = new int[] 
				{
					0,0,0,0,0,0,15,0,21,1,
					0,0,0,0,0,0,0,0,0,1,
					0,11,0,0,0,0,0,0,0,8,
					0,11,0,11,0,0,0,0,0,0,
					0,11,0,1,0,1,0,0,0,0,
					0,99,0,1,0,1,0,1,0,0,
					664,1,664,1,664,1,12,1,7,0,
					1,1,1,1,1,1,1,1,1,1
				};
			}
			else
			{
				roomArray = new int[] 
				{
					1,0,21,0,21,0,0,0,0,1,
					1,0,0,0,0,0,0,0,15,141,
					8,0,100,0,0,0,0,0,667,11,
					0,0,0,0,0,21,0,0,15,142,
					0,0,0,0,0,0,0,0,0,11,
					0,0,12,0,0,0,0,0,0,1,
					0,3,1,3,0,0,0,0,0,9,
					664,1,0,1,12,12,12,0,21,1
				};
			}
			Debug.Log("The room type is: " + roomPart1 + ",D");
			break;
		case "E":
			//randomly pick which array to use
			randomPick = Random.Range (0,3);
			if(randomPick == 0)
			{
				roomArray = new int[] 
				{
					0,0,0,21,1,11,16,0,0,0,
					7,7,665,665,1,111,16,0,0,0,
					0,21,0,0,665,0,21,0,0,0,
					0,0,0,0,0,0,0,0,0,1,
					0,100,0,0,0,0,0,0,0,15,
					0,0,0,0,0,11,11,1,0,1,
					0,0,0,0,0,142,11,16,0,1,
					7,7,1,11,141,1,16,9,1,1
				};
			}
			else if (randomPick == 1)
			{
				roomArray = new int[] 
				{
					1,1,1,1,0,0,0,0,0,0,
					1,0,0,0,0,0,0,0,0,1,
					1,0,0,0,0,0,0,0,0,11,
					13,0,0,0,3,0,0,0,0,660,
					0,0,0,1,1,0,0,0,0,1,
					0,111,0,141,1,0,16,0,0,141,
					12,0,12,11,1,0,0,0,0,13,
					1,1,1,142,1,0,0,0,0,0
				};
			}
			else
			{
				roomArray = new int[] 
				{
					0,21,0,0,0,21,0,0,0,0,
					8,0,0,0,0,661,0,0,0,1,
					0,0,0,0,0,0,0,0,0,1,
					0,7,0,7,0,0,0,0,0,1,
					0,11,141,1,0,0,0,21,1,0,
					142,0,0,0,0,0,13,8,13,0,
					1,0,0,0,0,0,0,0,10,0,
					0,21,11,1,1,0,0,0,0,0
				};
			}
			Debug.Log("The room type is: " + roomPart1 + ",E");
			break;
		case "F":
			//randomly pick which array to use
			randomPick = Random.Range (0,3);
			if(randomPick == 0)
			{
				roomArray = new int[] 
				{
					1,668,0,0,0,0,0,0,0,1,
					1,0,0,0,660,0,0,0,0,1,
					1,0,1,11,141,0,0,0,0,0,
					0,0,1,5,1,0,667,1,0,0,
					0,0,665,0,0,0,0,0,0,0,
					0,0,0,0,0,0,0,0,0,0,
					0,0,0,0,0,0,96,0,0,0,
					0,0,0,0,667,0,21,1,0,0
				};
			}
			else if (randomPick == 1)
			{
				roomArray = new int[] 
				{
					1,1,665,1,1,0,21,0,0,0,
					1,50,50,50,50,13,1,0,0,0,
					1,99,50,50,50,50,1,0,0,667,
					1,141,0,21,11,0,21,0,0,0,
					1,0,0,0,0,0,0,660,0,0,
					141,0,0,0,3,0,0,0,0,7,
					11,0,0,0,21,0,0,0,21,1,
					142,0,0,0,0,0,21,0,0,1
				};
			}
			else
			{
				roomArray = new int[] 
				{
					0,21,0,0,0,0,0,0,0,0,
					656,0,0,0,0,0,0,0,0,0,
					0,0,96,0,0,0,0,96,0,0,
					1,1,1,16,0,0,1,1,1,1,
					1,10,0,0,0,0,0,660,0,0,
					1,0,0,0,0,0,0,0,0,0,
					141,660,0,0,0,0,0,0,0,0,
					11,141,9,142,1,1,1,1,1,11
				};
			}
			Debug.Log("The room type is: " + roomPart1 + ",F");
			break;
		case "G":
			//randomly pick which array to use
			randomPick = Random.Range (0,3);
			if(randomPick == 0)
			{
				roomArray = new int[] 
				{
					1,1,0,0,0,0,0,0,0,1,
					141,0,0,0,664,664,0,0,0,11,
					0,0,0,0,1,1,0,0,0,142,
					0,0,667,1,1,1,1,667,0,2,
					0,0,667,1,1,1,1,0,0,1,
					0,0,0,0,0,111,0,0,0,1,
					0,0,0,0,0,0,0,0,0,11,
					1,11,0,0,21,1,1,7,142,11
				};
			}
			else if (randomPick == 1)
			{
				roomArray = new int[] 
				{
					1,0,21,1,0,0,0,0,0,1,
					1,0,0,0,0,0,0,0,0,1,
					8,0,0,0,664,1,16,0,0,1,
					0,661,0,667,1,1,0,0,0,21,
					0,0,0,0,8,0,0,0,11,141,
					0,0,100,0,0,0,1,1,9,1,
					0,0,0,0,1,1,99,50,50,1,
					1,1,11,1,1,0,21,141,0,21
				};
			}
			else
			{
				roomArray = new int[] 
				{
					0,21,0,0,0,0,0,0,0,0,
					1,0,0,0,660,0,0,0,0,0,
					8,0,0,0,0,0,0,0,0,0,
					0,0,0,0,1,1,0,0,0,0,
					11,0,0,667,0,21,668,0,0,0,
					11,0,0,0,1,0,0,0,0,0,
					0,0,0,0,0,0,0,0,3,1,
					1,0,21,0,0,660,0,0,0,21
				};
			}
			Debug.Log("The room type is: " + roomPart1 + ",G");
			break;
		case "H":
			//randomly pick which array to use
			randomPick = Random.Range (0,3);
			if(randomPick == 0)
			{
				roomArray = new int[] 
				{
					0,0,0,0,0,0,0,0,0,0,
					0,0,21,0,0,0,0,11,11,0,
					0,0,0,0,0,0,0,667,141,0,
					0,0,0,0,1,1,0,0,11,668,
					0,0,0,0,12,8,0,0,142,0,
					0,1,1,0,0,0,0,0,21,0,
					0,8,12,0,0,0,0,12,8,0,
					0,10,0,1,142,11,1,111,0,0
				};
			}
			else if (randomPick == 1)
			{
				roomArray = new int[] 
				{
					0,0,0,0,0,0,0,0,0,11,
					0,0,0,0,0,0,0,0,0,11,
					0,0,0,0,0,0,0,0,0,142,
					11,0,3,0,11,11,0,0,0,1,
					11,0,1,0,0141,142,0,3,0,1,
					1,0,1,0,111,11,0,1,0,1,
					1,12,1,12,0,21,12,1,7,141,
					1,1,1,1,1,1,1,1,1,11
				};
			}
			else
			{
				roomArray = new int[] 
				{
					11,11,11,1,1,0,0,0,0,0,
					0,0,0,0,0,0,0,0,0,0,
					0,0,660,0,0,0,0,0,0,0,
					0,0,0,0,0,0,0,0,0,0,
					0,0,0,0,11,11,0,0,0,0,
					0,0,0,1,50,50,1,0,0,0,
					3,3,0,21,5,50,11,141,3,3,
					0,21,1,1,12,1,1,1,0,21
				};
			}
			Debug.Log("The room type is: " + roomPart1 + ",H");
			break;
		case "Z":
			//randomly pick which array to use
			randomPick = Random.Range (0,3);
			if(randomPick == 0)
			{
				roomArray = new int[] 
				{
					1,0,21,1,1,6,0,0,0,1,
					0,0,0,0,0,0,0,0,0,1,
					0,0,0,0,0,0,0,0,0,665,
					661,0,0,33,0,0,0,0,0,0,
					0,0,15,0,21,16,0,0,667,1,
					0,0,0,0,0,0,0,0,0,11,
					0,0,0,0,0,0,3,0,0,1,
					1,0,21,1,1,1,0,21,1,1
				};
			}
			else if (randomPick == 1)
			{
				roomArray = new int[] 
				{
					0,0,0,0,0,0,0,0,0,0,
					1,668,0,0,0,0,0,0,0,0,
					1,0,0,0,0,0,0,0,0,0,
					1,0,0,0,0,0,0,0,0,0,
					1,668,100,0,0,0,0,0,0,1,
					1,0,21,1,1,1,0,0,0,141,
					1,0,33,0,0,9,0,0,0,11,
					1,1,1,0,21,1,0,2,1,1
				};
			}
			else
			{
				roomArray = new int[] 
				{
					1,0,21,0,21,1,0,0,0,0,
					1,1,11,1,1,0,0,0,0,0,
					1,0,21,1,13,0,0,0,0,0,
					1,141,1,0,0,0,0,667,1,0,
					0,21,13,0,0,0,0,0,0,0,
					1,0,0,0,0,0,0,0,0,0,
					0,0,0,0,0,0,0,33,0,0,
					12,12,12,12,12,12,141,11,1,664
				};
			}
			Debug.Log("The room type is: " + roomPart1 + ",Z");
			break;
		default:
			Debug.Log("The room type is: " + roomPart1 + roomPart2);
			Debug.Log("Something went wrong when selecting RoomPart2 for in RoomB");
			break;
		}
		/*
			roomArray = new int[] 
			{
				0,0,0,0,0,0,0,0,0,0,
				0,0,0,0,0,0,0,0,0,0,
				0,0,0,0,0,0,0,0,0,0,
				0,0,0,0,0,0,0,0,0,0,
				0,0,0,0,0,0,0,0,0,0,
				0,0,0,0,0,0,0,0,0,0,
				0,0,0,0,0,0,0,0,0,0,
				0,0,0,0,0,0,0,0,0,0
			};*/
	}
	
	private void RoomPositionInitalize()
	{
		//sets the starting x position of the room
		roomTilePosition.x = startingPositionB.x;
		//sets the starting y position of the room
		roomTilePosition.y = startingPositionB.y;
		//sets the starting z position of the room
		roomTilePosition.z = 0;
		transform.position = roomTilePosition;
		//Debug.Log("Room Type B initalized");
	}
	
	private void LoopThroughArray ()
	{
		for (int i = 0; i < roomArray.Length; i++)
		{
			CheckYPosition(i);
		}
	}
	
	//determines which row the tile is in and sets its position accordingly
	private void CheckYPosition (int y)
	{
		if(lineBreaks.Contains(y))
		{
			roomTilePosition.y -= 1.0f;
			CheckXPosition(y);
		}
		else
		{
			CheckXPosition(y);
		}
	}
	
	//determines which column the tile is in and sets its postion accordingly
	private void CheckXPosition (int x)
	{
		if(lineBreaks.Contains(x))
		{
			//resets the x position to the starting x position of room
			roomTilePosition.x = startingPositionB.x;
			transform.position = roomTilePosition;
			RoomTileInstantiate(x);
		}
		else
		{
			RoomTileInstantiate(x);
		}
	}
	
	private void RoomTileInstantiate(int arrayNum)
	{
		int currentTile = roomArray[arrayNum];
		//istantiates tile at appropriate position and moves the postion ahead
		switch(currentTile)
		{
		case 0:
			//Empty Tile
			Instantiate(tileOfRoom[12], roomTilePosition, Quaternion.identity);
			roomTilePosition.x += 1.0f;
			transform.position = roomTilePosition;
			break;
		case 1:
			//Random Solid Block
			int randomSolid = Random.Range (0,6);
			//istantiates block then moves the x position ahead by one
			Instantiate(tileOfRoom[randomSolid], roomTilePosition, Quaternion.identity);
			roomTilePosition.x += 1.0f;
			transform.position = roomTilePosition;
			break;
		case 2:
			//50% Chance of Random Solid Block
			int rand50 = Random.Range(1,3);
			if(rand50 == 1)
			{
				//picks a random solid block texture
				int randomSolid50 = Random.Range (0,6);
				//istantiates block then moves the x position ahead by one
				Instantiate(tileOfRoom[randomSolid50], roomTilePosition, Quaternion.identity);
				roomTilePosition.x += 1.0f;
				transform.position = roomTilePosition;
				
			}
			else
			{
				//Empty Tile
				Instantiate(tileOfRoom[12], roomTilePosition, Quaternion.identity);
				roomTilePosition.x += 1.0f;
				transform.position = roomTilePosition;
			}
			break;
		case 3:
			//Spring
			Instantiate(tileOfRoom[6], roomTilePosition, Quaternion.identity);
			roomTilePosition.x += 1.0f;
			transform.position = roomTilePosition;
			break;
		case 4:
			//50% of a Push Block
			int random50 = Random.Range (0,2);
			//istantiates block then moves the x position ahead by one
			if(random50 == 1)
			{
				Instantiate(tileOfRoom[7], roomTilePosition, Quaternion.identity);
				roomTilePosition.x += 1.0f;
				transform.position = roomTilePosition;
			}
			else
			{
				//Empty Tile
				Instantiate(tileOfRoom[12], roomTilePosition, Quaternion.identity);
				roomTilePosition.x += 1.0f;
				transform.position = roomTilePosition;
			}
			break;
		case 5:
			//25% of a key, bow, golden bow, empty
			int reward25 = Random.Range (0,2);
			//istantiates block then moves the x position ahead by one
			if(reward25 == 1)
			{
				//Bow
				Instantiate(tileOfRoom[21], roomTilePosition, Quaternion.identity);
				roomTilePosition.x += 1.0f;
				transform.position = roomTilePosition;
			}
			else if(reward25 == 2)
			{
				//Key
				Instantiate(tileOfRoom[11], roomTilePosition, Quaternion.identity);
				roomTilePosition.x += 1.0f;
				transform.position = roomTilePosition;
			}
			else if(reward25 == 3)
			{
				//Golden bow
				Instantiate(tileOfRoom[23], roomTilePosition, Quaternion.identity);
				roomTilePosition.x += 1.0f;
				transform.position = roomTilePosition;
			}
			else
			{
				//Empty Tile
				Instantiate(tileOfRoom[12], roomTilePosition, Quaternion.identity);
				roomTilePosition.x += 1.0f;
				transform.position = roomTilePosition;
			}
			break;
		case 7:
			//33% Chance of Ground Spike
			int rand33 = Random.Range(1,4);
			//istantiates block then moves the x position ahead by one
			if(rand33 == 1)
			{
				Instantiate(tileOfRoom[8], roomTilePosition, Quaternion.identity);
				roomTilePosition.x += 1.0f;
				transform.position = roomTilePosition;
			}
			else
			{
				//Empty Tile
				Instantiate(tileOfRoom[12], roomTilePosition, Quaternion.identity);
				roomTilePosition.x += 1.0f;
				transform.position = roomTilePosition;
			}
			break;
		case 8:
			//33% Chance of Top Spike
			int random33 = Random.Range(1,4);
			//istantiates block then moves the x position ahead by one
			if(random33 == 1)
			{
				Instantiate(tileOfRoom[9], roomTilePosition, Quaternion.identity);
				roomTilePosition.x += 1.0f;
				transform.position = roomTilePosition;
				
			}
			else
			{
				//Empty Tile
				Instantiate(tileOfRoom[12], roomTilePosition, Quaternion.identity);
				roomTilePosition.x += 1.0f;
				transform.position = roomTilePosition;
			}
			break;
		case 9:
			//Locked Door
			Instantiate(tileOfRoom[10], roomTilePosition, Quaternion.identity);
			roomTilePosition.x += 1.0f;
			transform.position = roomTilePosition;
			break;
		case 10:
			//50% Chance of a Key
			int randomKey50 = Random.Range(0,4);
			//istantiates block then moves the x position ahead by one
			if(randomKey50 != 1)
			{
				Instantiate(tileOfRoom[11], roomTilePosition, Quaternion.identity);
				roomTilePosition.x += 1.0f;
				transform.position = roomTilePosition;
			}
			else
			{
				//Empty tile
				Instantiate(tileOfRoom[12], roomTilePosition, Quaternion.identity);
				roomTilePosition.x += 1.0f;
				transform.position = roomTilePosition;
			}
			break;
		case 11:
			//Breakable Block Single
			Instantiate(tileOfRoom[14], roomTilePosition, Quaternion.identity);
			roomTilePosition.x += 1.0f;
			transform.position = roomTilePosition;
			break;
		case 12:
			//Ground spike
			Instantiate(tileOfRoom[8], roomTilePosition, Quaternion.identity);
			roomTilePosition.x += 1.0f;
			transform.position = roomTilePosition;
			break;
		case 13:
			//Top spike
			Instantiate(tileOfRoom[9], roomTilePosition, Quaternion.identity);
			roomTilePosition.x += 1.0f;
			transform.position = roomTilePosition;
			break;
		case 14:
			//25% chance of a Push Block
			int rand25 = Random.Range(0,4);
			//istantiates block then moves the x position ahead by one
			if(rand25 == 1)
			{
				Instantiate(tileOfRoom[13], roomTilePosition, Quaternion.identity);
				roomTilePosition.x += 1.0f;
				transform.position = roomTilePosition;
			}
			else
			{
				//Empyt tile
				Instantiate(tileOfRoom[12], roomTilePosition, Quaternion.identity);
				roomTilePosition.x += 1.0f;
				transform.position = roomTilePosition;
			}
			break;
		case 15:
			//Left spike
			Instantiate(tileOfRoom[24], roomTilePosition, Quaternion.identity);
			roomTilePosition.x += 1.0f;
			transform.position = roomTilePosition;
			break;
		case 16:
			//Right spike
			Instantiate(tileOfRoom[25], roomTilePosition, Quaternion.identity);
			roomTilePosition.x += 1.0f;
			transform.position = roomTilePosition;
			break;
		case 17:
			//Teleport In
			GameObject telaIn = Instantiate(tileOfRoom[26], roomTilePosition, Quaternion.identity) as GameObject;
			telaInStringName = telaportNumeric.ToString();
			telaIn.gameObject.name = telaInStringName;
			roomTilePosition.x += 1.0f;
			transform.position = roomTilePosition;
			break;
		case 18:
			//Teleport Out
			GameObject telaOut = Instantiate(tileOfRoom[27], roomTilePosition, Quaternion.identity) as GameObject;
			telaOutStringName = ("telaOut"+telaportNumeric);
			telaOut.gameObject.name = telaOutStringName;
			//Debug.Log (telaOut.gameObject.name);
			roomTilePosition.x += 1.0f;
			transform.position = roomTilePosition;
			break;
		case 20:
			//Bow
			Instantiate(tileOfRoom[21], roomTilePosition, Quaternion.identity);
			roomTilePosition.x += 1.0f;
			transform.position = roomTilePosition;
			break;
		case 21:
			//Random solid 2x1 block
			Vector3 correctedPosition = roomTilePosition + new Vector3(0.5f, 0.0f, 0.0f);
			int rand13 = Random.Range(1,4);
			if(rand13 == 1)
			{
				//istantiates block then moves the x position ahead by one
				Instantiate(tileOfRoom[16], correctedPosition, Quaternion.identity);
				roomTilePosition.x += 1.0f;
				transform.position = roomTilePosition;
			}
			else if(rand13 == 2)
			{
				//istantiates block then moves the x position ahead by one
				Instantiate(tileOfRoom[17], correctedPosition, Quaternion.identity);
				roomTilePosition.x += 1.0f;
				transform.position = roomTilePosition;
			}
			else if(rand13 == 3)
			{
				//istantiates block then moves the x position ahead by one
				Instantiate(tileOfRoom[18], correctedPosition, Quaternion.identity);
				roomTilePosition.x += 1.0f;
				transform.position = roomTilePosition;
			}
			break;
		case 33:
			//Exit door
			Instantiate(tileOfRoom[15], roomTilePosition, Quaternion.identity);
			roomTilePosition.x += 1.0f;
			transform.position = roomTilePosition;
			break;
		case 41:
			//push block
			Instantiate(tileOfRoom[7], roomTilePosition, Quaternion.identity);
			roomTilePosition.x += 1.0f;
			transform.position = roomTilePosition;
			break;
		case 50:
			//Hidden block
			int randomHiddenSolid = Random.Range (0,6);
			//instantiate block
			GameObject hiddenRoom = Instantiate(tileOfRoom[randomHiddenSolid], roomTilePosition, Quaternion.identity) as GameObject;
			//set tile to empty layer
			hiddenRoom.layer = 15;
			//set new alpha value for tile
			Color hidden = hiddenRoom.GetComponent<SpriteRenderer>().color;
			float alphaH = 0.45f;
			hidden.a = alphaH;
			hiddenRoom.GetComponent<SpriteRenderer>().color = hidden;
			//move the x position ahead by one
			roomTilePosition.x += 1.0f;
			transform.position = roomTilePosition;
			break;
		case 96:
			//Bounce shaddow
			GameObject SB = Instantiate(tileOfRoom[30], roomTilePosition, Quaternion.identity) as GameObject;
			SB.gameObject.name = "ShaddowBounce";
			roomTilePosition.x += 1.0f;
			transform.position = roomTilePosition;
			break;
		case 97:
			//forward shaddow
			GameObject SBF = Instantiate(tileOfRoom[30], roomTilePosition, Quaternion.identity) as GameObject;
			SBF.gameObject.name = "ShaddowForward";
			roomTilePosition.x += 1.0f;
			transform.position = roomTilePosition;
			break;
		case 99:
			//Golden Bow
			Instantiate(tileOfRoom[23], roomTilePosition, Quaternion.identity);
			roomTilePosition.x += 1.0f;
			transform.position = roomTilePosition;
			break;
		case 100:
			//100% Key
			Instantiate(tileOfRoom[11], roomTilePosition, Quaternion.identity);
			roomTilePosition.x += 1.0f;
			transform.position = roomTilePosition;
			break;
		case 111: 
			//33% bow
			int randBow33 = Random.Range(1,4);
			//istantiates block then moves the x position ahead by one
			if(randBow33 == 1)
			{
				//istantiates block then moves the x position ahead by one
				Instantiate(tileOfRoom[21], roomTilePosition, Quaternion.identity);
				roomTilePosition.x += 1.0f;
				transform.position = roomTilePosition;
				
			}
			else
			{
				//moves the x position ahead by one
				Instantiate(tileOfRoom[12], roomTilePosition, Quaternion.identity);
				roomTilePosition.x += 1.0f;
				transform.position = roomTilePosition;
			}
			break;
		case 141:
			//Breakable bottom Left
			Instantiate(tileOfRoom[19], roomTilePosition, Quaternion.identity);
			roomTilePosition.x += 1.0f;
			transform.position = roomTilePosition;
			break;
		case 142:
			//Breakable top Right
			Instantiate(tileOfRoom[20], roomTilePosition, Quaternion.identity);
			roomTilePosition.x += 1.0f;
			transform.position = roomTilePosition;
			break;
		case 660:
			//Fire wisp <-->
			GameObject BG = Instantiate(tileOfRoom[22], roomTilePosition, Quaternion.identity) as GameObject;
			BG.gameObject.tag = "BadGuy";
			Vector3 fluffybg = BG.transform.position;
			fluffybg.z = -5.0f;
			BG.transform.position = fluffybg;
			roomTilePosition.x += 1.0f;
			transform.position = roomTilePosition;
			break;
		case 661:
			//Fire wisp vert
			GameObject BGV = Instantiate(tileOfRoom[33], roomTilePosition, Quaternion.identity) as GameObject;
			BGV.gameObject.tag = "BadGuyVert";
			Vector3 fluffybgv = BGV.transform.position;
			fluffybgv.z = -5.0f;
			BGV.transform.position = fluffybgv;
			roomTilePosition.x += 1.0f;
			transform.position = roomTilePosition;
			break;
		case 664:
			//Ground Shaddow spike cannon
			GameObject spks = Instantiate(tileOfRoom[28], roomTilePosition, Quaternion.identity) as GameObject;
			spks.gameObject.tag = "spike";
			roomTilePosition.x += 1.0f;
			transform.position = roomTilePosition;
			break;
		case 665:
			//Top Shaddow spike cannon
			GameObject Tspks = Instantiate(tileOfRoom[29], roomTilePosition, Quaternion.identity) as GameObject;
			Tspks.gameObject.tag = "topspike";
			roomTilePosition.x += 1.0f;
			transform.position = roomTilePosition;
			break;
		case 667:
			//Left shaddow spike cannon
			GameObject Lspks = Instantiate(tileOfRoom[31], roomTilePosition, Quaternion.identity) as GameObject;
			Lspks.gameObject.tag = "leftspike";
			roomTilePosition.x += 1.0f;
			transform.position = roomTilePosition;
			break;
		case 668:
			//Right shaddow spike cannon
			GameObject Rspks = Instantiate(tileOfRoom[32], roomTilePosition, Quaternion.identity) as GameObject;
			Rspks.gameObject.tag = "rightspike";
			roomTilePosition.x += 1.0f;
			transform.position = roomTilePosition;
			break;
		default:
			Debug.Log ("Something went wrong with instantiating the room tile at position: " + roomTilePosition);
			//Empty Tile
			Instantiate(tileOfRoom[12], roomTilePosition, Quaternion.identity);
			roomTilePosition.x += 1.0f;
			transform.position = roomTilePosition;
			break;
		}
	}
	
	private void ResetTheRoom()
	{
		telaportNumeric +=1;
		OnComplete();
	}
	
	private void OnComplete ()
	{
		Debug.Log ("This Room " + roomValue + " is complete.");
	}
	
}
