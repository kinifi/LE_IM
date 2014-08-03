using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RoomTypeOne : MonoBehaviour {
	
	//set up room 
	public GameObject[] tileOfRoom;
	public Vector3 startingPosition1;
	private Vector3 roomTilePosition;
	private List<int> lineBreaks = new List<int>(new int[] {10,20,30,40,50,60,70});
	
	
	public int[] typeOneArray;
	
	private int telaportNumeric = 0;
	private string telaInStringName;
	private string telaOutStringName;
	
	//set up obstacle blocks
	private Vector3 tilePosition;
	private float startObstacleXposition;
	private float startObstacleYposition;
	private int[] tileBlockArray;
	private Vector3 groundBlock1 = Vector3.zero;
	private Vector3 groundBlock2 = Vector3.zero;
	private Vector3 airBlock1 = Vector3.zero;
	private Vector3 airBlock2 = Vector3.zero;
	
	
	// Use this for initialization
	public void BeginRoom1() 
	{
		Debug.Log ("This is the starting position for RoomType1 "+startingPosition1);
		ChooseRoomTypeOneTemplate();
		CheckForObstacleBlocks();
		ResetTheRoom();
	}
	
	private void LoopThroughTypeOneArray ()
	{
		for (int i = 0; i < typeOneArray.Length; i++)
		{
			CheckYPosition(i);
		}
	}
	
	private void ResetTheRoom()
	{
		telaportNumeric +=1;
		groundBlock1 = Vector3.zero;
		groundBlock2 = Vector3.zero;
		airBlock1 = Vector3.zero;
		airBlock2 = Vector3.zero;
	}
	
	private void ChooseRoomTypeOneTemplate ()
	{
		RoomTypeOnePositionInitalize();
		//picks a random number correlated to a Type 1 template
		int temp = Random.Range(0, 11);
		
		switch (temp)
		{
		case 0:
			typeOneArray = new int[] 
			{
				0,0,0,0,0,6,0,0,0,0,
				0,1,1,1,0,0,0,0,0,0,
				0,0,1,0,0,0,0,0,0,0,
				0,0,0,0,0,0,0,0,0,0,
				0,0,5,0,0,0,0,0,0,2,
				0,0,0,0,0,0,0,0,21,0,
				111,0,0,0,0,0,0,21,0,0,
				1,1,1,1,1,1,1,1,1,1
			};
			//Debug.Log("Room Type One Zero was chosen.");
			break;
		case 1:
			typeOneArray = new int[]
			{
				0,0,1,1,1,0,1,1,1,0,
				0,0,0,0,0,0,8,8,8,0,
				0,0,0,0,0,0,0,0,0,0,
				0,0,0,0,2,0,0,0,0,0,
				5,0,0,0,0,0,0,0,0,111,
				0,0,0,0,0,0,0,0,0,141,
				0,0,0,0,0,3,0,142,11,0,
				1,1,1,11,1,1,1,1,21,0
			};
			//Debug.Log("Room Type One One was chosen.");
			break;
		case 2:
			typeOneArray = new int[]
			{
				0,0,1,1,1,0,1,1,1,0,
				0,0,8,8,10,0,0,0,0,0,
				5,0,0,0,0,0,0,0,0,0,
				0,0,0,0,0,0,0,21,0,0,
				0,111,0,0,0,0,0,0,0,0,
				1,1,1,1,0,0,0,0,0,0,
				11,99,9,0,4,0,0,0,3,0,
				1,1,21,0,1,1,1,1,1,1
			};
			//Debug.Log("Room Type One Two was chosen.");
			break;
		case 3:
			typeOneArray = new int[]
			{
				0,0,0,0,0,0,0,0,0,0,
				0,6,0,0,0,0,0,0,0,0,
				0,0,0,0,0,0,0,0,0,0,
				0,0,0,0,0,0,0,0,0,0,
				0,0,0,0,0,7,0,0,0,0,
				0,0,0,21,1,1,11,0,0,0,
				0,0,21,10,111,111,10,11,0,0,
				11,1,1,11,1,1,1,1,141,1
			};
			//Debug.Log("Room Type One Three was chosen.");
			break;
		case 4:
			typeOneArray = new int[]
			{
				0,0,1,1,1,0,0,1,0,21,
				0,7,0,0,0,6,0,0,0,0,
				0,1,2,0,0,0,0,0,0,0,
				0,0,0,0,0,0,0,0,0,0,
				5,0,0,0,0,0,0,0,0,0,
				0,0,0,0,0,0,0,0,0,0,
				0,0,0,0,0,0,3,141,0,0,
				1,1,1,1,11,11,11,1,1,1
			};
			//Debug.Log("Room Type One Four was chosen.");
			break;
		case 5:
			typeOneArray = new int[]
			{
				0,1,1,1,1,1,1,1,1,1,
				0,1,1,8,0,0,0,0,1,0,
				0,0,1,0,0,0,0,0,13,0,
				0,0,0,0,0,0,0,0,0,0,
				0,0,0,0,0,0,0,0,0,0,
				0,0,5,0,0,0,0,0,0,0,
				1,1,0,0,0,0,0,1,0,21,
				0,21,0,0,0,0,0,1,1,1
			};
			//Debug.Log("Room Type One Five was chosen.");
			break;
		case 6:
			typeOneArray = new int[]
			{
				0,1,1,0,0,1,0,0,1,1,
				0,0,0,0,0,11,0,0,0,0,
				1,0,0,6,0,0,0,0,0,1,
				0,0,0,0,0,0,0,0,661,0,
				1,0,0,0,0,0,0,0,0,1,
				1,66,0,0,0,0,0,0,0,1,
				0,0,0,0,0,0,0,0,0,0,
				1,1,12,0,1,1,111,0,1,1
			};
			//Debug.Log("Room Type One Six was chosen.");
			break;
		case 7:
			typeOneArray = new int[]
			{
				0,1,1,1,6,0,0,0,0,1,
				0,0,0,0,0,0,0,0,0,11,
				0,0,0,0,0,0,1,1,0,8,
				0,111,0,0,12,0,11,11,0,0,
				0,0,0,0,1,1,0,0,0,0,
				0,0,7,0,0,21,0,0,0,0,
				0,3,1,1,0,0,0,0,0,0,
				1,1,1,1,0,21,1,1,1,1
			};
			//Debug.Log("Room Type One Seven was chosen.");
			break;
		case 8:
			typeOneArray = new int[]
			{
				0,1,0,0,21,0,1,0,0,15,
				0,1,0,0,0,0,0,0,0,0,
				0,1,0,1,0,21,1,2,0,0,
				0,76,0,0,0,0,0,0,0,0,
				0,0,0,12,0,0,21,141,11,142,
				0,0,3,1,0,0,0,0,0,0,
				1,1,1,6,0,0,0,0,0,0,
				1,0,21,0,0,0,0,0,0,1
			};
			//Debug.Log("Room Type One Eight was chosen.");
			break;
		case 9:
			typeOneArray = new int[]
			{
				0,1,1,1,2,2,1,1,1,1,
				0,8,0,13,0,0,0,0,0,0,
				0,0,0,0,0,0,0,0,0,0,
				0,0,0,0,0,6,0,0,0,0,
				0,0,0,0,0,0,0,0,0,0,
				5,0,0,0,0,0,0,0,0,0,
				0,0,0,0,0,0,0,0,0,0,
				0,0,0,0,0,1,1,1,0,21
			};
			//Debug.Log("Room Type One Nine was chosen.");
			break;
		case 10:
			typeOneArray = new int[]
			{
				0,0,0,0,0,0,0,0,0,0,
				0,0,0,0,0,0,0,0,0,21,
				0,0,0,0,0,0,21,0,0,0,
				0,0,0,0,0,0,0,0,0,0,
				0,6,0,0,0,0,0,0,0,0,
				0,0,0,0,0,0,0,0,0,0,
				0,0,0,0,0,0,0,3,0,76,
				1,1,1,1,1,1,1,1,1,1
			};
			//Debug.Log("Room Type One Ten was chosen.");
			break;
		}
		//calls the function to loop through the created array
		LoopThroughTypeOneArray ();
	}
	
	private void RoomTypeOnePositionInitalize()
	{
		//sets the starting x position of the room
		roomTilePosition.x = startingPosition1.x;
		//sets the starting y position of the room
		roomTilePosition.y = startingPosition1.y;
		//sets the starting z position of the room
		roomTilePosition.z = 0;
		transform.position = roomTilePosition;
		//Debug.Log("Room Type One initalized");
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
			roomTilePosition.x = startingPosition1.x;
			transform.position = roomTilePosition;
			RoomTileInstantiate(x);
		}
		else
		{
			RoomTileInstantiate(x);
		}
	}
	
	//istantiates tile at appropriate position and moves the postion ahead
	private void RoomTileInstantiate(int arrayNum)
	{
		if(typeOneArray[arrayNum] == 0)
		{
			Instantiate(tileOfRoom[12], roomTilePosition, Quaternion.identity);
			roomTilePosition.x += 1.0f;
			transform.position = roomTilePosition;
		}
		else if(typeOneArray[arrayNum] == 1)
		{
			//istantiates block then moves the x position ahead by one
			int randomSolid = Random.Range (0,6);
			Instantiate(tileOfRoom[randomSolid], roomTilePosition, Quaternion.identity);
			roomTilePosition.x += 1.0f;
			transform.position = roomTilePosition;
		}
		else if(typeOneArray[arrayNum] == 2)
		{
			//50% chance the block will be instantiated
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
				//moves the x position ahead by one
				Instantiate(tileOfRoom[12], roomTilePosition, Quaternion.identity);
				roomTilePosition.x += 1.0f;
				transform.position = roomTilePosition;
			}
		}
		else if(typeOneArray[arrayNum] == 3)
		{
			//istantiates block then moves the x position ahead by one
			Instantiate(tileOfRoom[6], roomTilePosition, Quaternion.identity);
			roomTilePosition.x += 1.0f;
			transform.position = roomTilePosition;
		}
		else if(typeOneArray[arrayNum] == 4)
		{
			int rand50 = Random.Range (0,2);
			if(rand50 == 1)
			{
				//istantiates block then moves the x position ahead by one
				Instantiate(tileOfRoom[7], roomTilePosition, Quaternion.identity);
				roomTilePosition.x += 1.0f;
				transform.position = roomTilePosition;
			}
			else
			{
				Instantiate(tileOfRoom[12], roomTilePosition, Quaternion.identity);
				roomTilePosition.x += 1.0f;
				transform.position = roomTilePosition;
			}
		}
		else if(typeOneArray[arrayNum] == 5)
		{
			if(groundBlock1 == Vector3.zero)
			{
				groundBlock1 = roomTilePosition;
				//Debug.Log("Room Type Two Ground Block 1 initialized at: "+groundBlock1);
			}
			else
			{
				groundBlock2 = roomTilePosition;
				//Debug.Log("Room Type Two Ground Block 2 initialized at: "+groundBlock2);
			}
			
			Instantiate(tileOfRoom[12], roomTilePosition, Quaternion.identity);
			roomTilePosition.x += 1.0f;
			transform.position = roomTilePosition;
		}
		else if(typeOneArray[arrayNum] == 6)
		{
			
			if(airBlock1 == Vector3.zero)
			{
				airBlock1 = roomTilePosition;
				//Debug.Log("Room Type Two Air Block 1 initialized at: "+airBlock1);
			}
			else
			{
				airBlock2 = roomTilePosition;
				//Debug.Log("Room Type Two Air Block 2 initialized at: "+airBlock2);
			}
			
			Instantiate(tileOfRoom[12], roomTilePosition, Quaternion.identity);
			roomTilePosition.x += 1.0f;
			transform.position = roomTilePosition;
		}
		else if(typeOneArray[arrayNum] == 7)
		{
			int rand33 = Random.Range(1,4);
			if(rand33 == 1)
			{
				Instantiate(tileOfRoom[8], roomTilePosition, Quaternion.identity);
				roomTilePosition.x += 1.0f;
				transform.position = roomTilePosition;
			}
			else
			{
				Instantiate(tileOfRoom[12], roomTilePosition, Quaternion.identity);
				roomTilePosition.x += 1.0f;
				transform.position = roomTilePosition;
			}
		}
		else if(typeOneArray[arrayNum] == 8)
		{
			int rand33 = Random.Range(1,4);
			if(rand33 == 1)
			{
				Instantiate(tileOfRoom[9], roomTilePosition, Quaternion.identity);
				roomTilePosition.x += 1.0f;
				transform.position = roomTilePosition;
				
			}
			else
			{
				Instantiate(tileOfRoom[12], roomTilePosition, Quaternion.identity);
				roomTilePosition.x += 1.0f;
				transform.position = roomTilePosition;
			}
		}
		else if(typeOneArray[arrayNum] == 9)
		{
			Instantiate(tileOfRoom[10], roomTilePosition, Quaternion.identity);
			roomTilePosition.x += 1.0f;
			transform.position = roomTilePosition;
		}
		else if(typeOneArray[arrayNum] == 10)
		{
			int rand50 = Random.Range(0,4);
			if(rand50 != 1)
			{
				Instantiate(tileOfRoom[11], roomTilePosition, Quaternion.identity);
				roomTilePosition.x += 1.0f;
				transform.position = roomTilePosition;
			}
			else
			{
				Instantiate(tileOfRoom[12], roomTilePosition, Quaternion.identity);
				roomTilePosition.x += 1.0f;
				transform.position = roomTilePosition;
			}
		}
		else if(typeOneArray[arrayNum] == 11)
		{
			//istantiates block then moves the x position ahead by one
			Instantiate(tileOfRoom[14], roomTilePosition, Quaternion.identity);
			roomTilePosition.x += 1.0f;
			transform.position = roomTilePosition;
		}
		else if(typeOneArray[arrayNum] == 12)
		{
			//istantiates block then moves the x position ahead by one
			Instantiate(tileOfRoom[8], roomTilePosition, Quaternion.identity);
			roomTilePosition.x += 1.0f;
			transform.position = roomTilePosition;
		}
		else if(typeOneArray[arrayNum] == 13)
		{
			//istantiates block then moves the x position ahead by one
			Instantiate(tileOfRoom[9], roomTilePosition, Quaternion.identity);
			roomTilePosition.x += 1.0f;
			transform.position = roomTilePosition;
		}
		else if(typeOneArray[arrayNum] == 14)
		{
			int rand25 = Random.Range(0,4);
			if(rand25 == 1)
			{
				Instantiate(tileOfRoom[13], roomTilePosition, Quaternion.identity);
				roomTilePosition.x += 1.0f;
				transform.position = roomTilePosition;
			}
			else
			{
				Instantiate(tileOfRoom[12], roomTilePosition, Quaternion.identity);
				roomTilePosition.x += 1.0f;
				transform.position = roomTilePosition;
			}
		}
		else if(typeOneArray[arrayNum] == 15)
		{
			//istantiates block then moves the x position ahead by one
			Instantiate(tileOfRoom[24], roomTilePosition, Quaternion.identity);
			roomTilePosition.x += 1.0f;
			transform.position = roomTilePosition;
		}
		else if(typeOneArray[arrayNum] == 16)
		{
			//istantiates block then moves the x position ahead by one
			Instantiate(tileOfRoom[25], roomTilePosition, Quaternion.identity);
			roomTilePosition.x += 1.0f;
			transform.position = roomTilePosition;
		}
		else if(typeOneArray[arrayNum] == 17)
		{
			//istantiates block then moves the x position ahead by one
			GameObject telaIn = Instantiate(tileOfRoom[26], roomTilePosition, Quaternion.identity) as GameObject;
			telaInStringName = telaportNumeric.ToString();
			telaIn.gameObject.name = telaInStringName;
			roomTilePosition.x += 1.0f;
			transform.position = roomTilePosition;
		}
		else if(typeOneArray[arrayNum] == 18)
		{
			//istantiates block then moves the x position ahead by one
			GameObject telaOut = Instantiate(tileOfRoom[27], roomTilePosition, Quaternion.identity) as GameObject;
			telaOutStringName = ("telaOut"+telaportNumeric);
			telaOut.gameObject.name = telaOutStringName;
			//Debug.Log (telaOut.gameObject.name);
			roomTilePosition.x += 1.0f;
			transform.position = roomTilePosition;
		}
		else if(typeOneArray[arrayNum] == 20)
		{
			//istantiates block then moves the x position ahead by one
			Instantiate(tileOfRoom[21], roomTilePosition, Quaternion.identity);
			roomTilePosition.x += 1.0f;
			transform.position = roomTilePosition;
		}
		else if(typeOneArray[arrayNum] == 21)
		{
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
		}
		else if(typeOneArray[arrayNum] == 33)
		{
			//istantiates block then moves the x position ahead by one
			Instantiate(tileOfRoom[15], roomTilePosition, Quaternion.identity);
			roomTilePosition.x += 1.0f;
			transform.position = roomTilePosition;
		}
		else if (typeOneArray[arrayNum] == 41)
		{
			Instantiate(tileOfRoom[7], roomTilePosition, Quaternion.identity);
			roomTilePosition.x += 1.0f;
			transform.position = roomTilePosition;
		}
		else if(typeOneArray[arrayNum] == 50)
		{
			//istantiates block then moves the x position ahead by one
			int randomSolid = Random.Range (0,6);
			GameObject hiddenRoom = Instantiate(tileOfRoom[randomSolid], roomTilePosition, Quaternion.identity) as GameObject;
			hiddenRoom.layer = 15;
			roomTilePosition.x += 1.0f;
			transform.position = roomTilePosition;
		}
		else if(typeOneArray[arrayNum] == 66)
		{
			//istantiates block then moves the x position ahead by one
			GameObject BG = Instantiate(tileOfRoom[22], roomTilePosition, Quaternion.identity) as GameObject;
			BG.gameObject.tag = "BadGuy";
			roomTilePosition.x += 1.0f;
			transform.position = roomTilePosition;
		}
		else if(typeOneArray[arrayNum] == 76)
		{
			Instantiate(tileOfRoom[28], roomTilePosition, Quaternion.identity);
			roomTilePosition.x += 1.0f;
			transform.position = roomTilePosition;
		}
		else if(typeOneArray[arrayNum] == 86)
		{
			Instantiate(tileOfRoom[29], roomTilePosition, Quaternion.identity);
			roomTilePosition.x += 1.0f;
			transform.position = roomTilePosition;
		}
		else if(typeOneArray[arrayNum] == 96)
		{
			GameObject SB = Instantiate(tileOfRoom[30], roomTilePosition, Quaternion.identity) as GameObject;
			SB.gameObject.name = "ShaddowBounce";
			roomTilePosition.x += 1.0f;
			transform.position = roomTilePosition;
		}
		else if(typeOneArray[arrayNum] == 97)
		{
			GameObject SB = Instantiate(tileOfRoom[30], roomTilePosition, Quaternion.identity) as GameObject;
			SB.gameObject.name = "ShaddowForward";
			roomTilePosition.x += 1.0f;
			transform.position = roomTilePosition;
		}
		else if(typeOneArray[arrayNum] == 99)
		{
			Instantiate(tileOfRoom[23], roomTilePosition, Quaternion.identity);
			roomTilePosition.x += 1.0f;
			transform.position = roomTilePosition;
		}
		else if(typeOneArray[arrayNum] == 100)
		{
			Instantiate(tileOfRoom[11], roomTilePosition, Quaternion.identity);
			roomTilePosition.x += 1.0f;
			transform.position = roomTilePosition;
		}
		else if(typeOneArray[arrayNum] == 111)
		{
			//33% chance the block will be instantiated
			int rand33 = Random.Range(1,4);
			if(rand33 == 1)
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
		}
		else if(typeOneArray[arrayNum] == 141)
		{
			//istantiates block then moves the x position ahead by one
			Instantiate(tileOfRoom[19], roomTilePosition, Quaternion.identity);
			roomTilePosition.x += 1.0f;
			transform.position = roomTilePosition;
		}
		else if(typeOneArray[arrayNum] == 142)
		{
			//istantiates block then moves the x position ahead by one
			Instantiate(tileOfRoom[20], roomTilePosition, Quaternion.identity);
			roomTilePosition.x += 1.0f;
			transform.position = roomTilePosition;
		}
		else if(typeOneArray[arrayNum] == 320)
		{
			//aprox. 20% chance the block will be instantiated
			int rand20 = Random.Range(0,5);
			if(rand20 == 0)
			{
				//istantiates block then moves the x position ahead by one
				Instantiate(tileOfRoom[6], roomTilePosition, Quaternion.identity);
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
		}
		else if(typeOneArray[arrayNum] == 360)
		{
			//aprox. 60% chance the block will be instantiated
			int rand60 = Random.Range(0,3);
			if(rand60 != 0)
			{
				//istantiates block then moves the x position ahead by one
				Instantiate(tileOfRoom[6], roomTilePosition, Quaternion.identity);
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
		}
		else if(typeOneArray[arrayNum] == 661)
		{
			//istantiates block then moves the x position ahead by one
			GameObject BGV = Instantiate(tileOfRoom[22], roomTilePosition, Quaternion.identity) as GameObject;
			BGV.gameObject.tag = "BadGuyVert";
			roomTilePosition.x += 1.0f;
			transform.position = roomTilePosition;
		}
		else if(typeOneArray[arrayNum] == 664)
		{
			GameObject spks = Instantiate(tileOfRoom[28], roomTilePosition, Quaternion.identity) as GameObject;
			spks.gameObject.tag = "spike";
			roomTilePosition.x += 1.0f;
			transform.position = roomTilePosition;
		}
		else if(typeOneArray[arrayNum] == 665)
		{
			GameObject spks = Instantiate(tileOfRoom[29], roomTilePosition, Quaternion.identity) as GameObject;
			spks.gameObject.tag = "topspike";
			roomTilePosition.x += 1.0f;
			transform.position = roomTilePosition;
		}
		else if(typeOneArray[arrayNum] == 666)
		{
			//istantiates block then moves the x position ahead by one
			Instantiate(tileOfRoom[22], roomTilePosition, Quaternion.identity);
			roomTilePosition.x += 1.0f;
			transform.position = roomTilePosition;
		}
		else if(typeOneArray[arrayNum] == 667)
		{
			GameObject spks = Instantiate(tileOfRoom[31], roomTilePosition, Quaternion.identity) as GameObject;
			spks.gameObject.tag = "leftspike";
			roomTilePosition.x += 1.0f;
			transform.position = roomTilePosition;
		}
		else if(typeOneArray[arrayNum] == 668)
		{
			GameObject spks = Instantiate(tileOfRoom[32], roomTilePosition, Quaternion.identity) as GameObject;
			spks.gameObject.tag = "rightspike";
			roomTilePosition.x += 1.0f;
			transform.position = roomTilePosition;
		}
	}
	
	private void CheckForObstacleBlocks()
	{
		if(groundBlock1 != Vector3.zero)
		{
			GroundBlockPositionInitalize(groundBlock1);
			ChooseGroundTemplate ();
		}
		if(groundBlock2 != Vector3.zero)
		{
			GroundBlockPositionInitalize(groundBlock2);
			ChooseGroundTemplate ();
		}
		if(airBlock1 != Vector3.zero)
		{
			AirBlockPositionInitalize(airBlock1);
			ChooseLeftAirTemplate();
		}
		if(airBlock2 != Vector3.zero)
		{
			AirBlockPositionInitalize(airBlock2);
			ChooseRightAirTemplate();
		}
	}
	
	private void LoopThroughArray ()
	{
		for (int i = 0; i < tileBlockArray.Length; i++)
		{
			CheckObstacleYPosition(i);
		}
	}
	
	private void ChooseGroundTemplate ()
	{
		
		//picks a random number correlated to a tileBlockArray
		int temp = Random.Range(0, 21);
		
		switch (temp)
		{
		case 0:
			tileBlockArray = new int[] 
			{
				0,0,0,0,0,
				0,0,41,0,2,
				15,1,0,21,0
			};
			//Debug.Log("Room Type One Ground Zero was chosen.");
			break;
		case 1:
			tileBlockArray = new int[]
			{
				0,0,0,0,0,
				3,2,0,2,0,
				1,1,1,1,0
			};
			//Debug.Log("Room Type One Ground One was chosen.");
			break;
		case 2:
			tileBlockArray = new int[]
			{
				0,0,111,0,0,
				0,7,0,7,2,
				1,1,0,21,8
			};
			//Debug.Log("Room Type One Ground Two was chosen.");
			break;
		case 3:
			tileBlockArray = new int[]
			{
				0,0,0,0,1,
				0,7,0,1,2,
				0,21,1,1,0
			};
			//Debug.Log("Room Type One Ground Three was chosen.");
			break;
		case 4:
			tileBlockArray = new int[]
			{
				0,0,0,0,0,
				0,4,7,0,0,
				2,1,1,1,2
			};
			//Debug.Log("Room Type One Ground Four was chosen.");
			break;
		case 5:
			tileBlockArray = new int[]
			{
				0,1,1,1,2,
				3,1,10,0,4,
				1,1,11,1,1
			};
			//Debug.Log("Room Type One Ground Five was chosen.");
			break;
		case 6:
			tileBlockArray = new int[]
			{
				0,0,4,0,0,
				0,141,0,2,2,
				11,0,21,0,1
			};
			//Debug.Log("Room Type One Ground Six was chosen.");
			break;
		case 7:
			tileBlockArray = new int[] 
			{
				7,0,0,0,7,
				1,0,4,0,1,
				0,1,1,1,0
			};
			//Debug.Log("Room Type One Ground Seven was chosen.");
			break;
		case 8:
			tileBlockArray = new int[]
			{
				0,0,0,0,0,
				0,4,0,2,7,
				1,0,21,1,1
			};
			//Debug.Log("Room Type One Ground Eight was chosen.");
			break;
		case 9:
			tileBlockArray = new int[]
			{
				0,1,0,0,1,
				15,1,1,664,1,
				0,1,0,1,0
			};
			//Debug.Log("Room Type One Ground Nine was chosen.");
			break;
		case 10:
			tileBlockArray = new int[]
			{
				2,1,1,1,1,
				0,0,11,0,2,
				1,1,1,1,1
			};
			//Debug.Log("Room Type One Ground Ten was chosen.");
			break;
		case 11:
			tileBlockArray = new int[]
			{
				0,0,1,1,1,
				1,0,0,0,0,
				0,21,1,1,1
			};
			//Debug.Log("Room Type One Ground Eleven was chosen.");
			break;
		case 12:
			tileBlockArray = new int[]
			{
				1,1,11,0,0,
				111,0,0,0,0,
				2,142,11,141,11
			};
			//Debug.Log("Room Type One Ground Twelve was chosen.");
			break;
		case 13:
			tileBlockArray = new int[]
			{
				0,0,0,1,1,
				4,3,0,0,0,
				1,1,0,1,1
			};
			//Debug.Log("Room Type One Ground Thirteen was chosen.");
			break;
		case 14:
			tileBlockArray = new int[]
			{
				10,0,1,9,1,
				0,0,1,111,1,
				1,1,1,0,21
			};
			//Debug.Log("Room Type One Ground Fourteen was chosen.");
			break;
		case 15:
			tileBlockArray = new int[]
			{
				1,0,1,1,1,
				0,0,4,0,0,
				141,11,142,0,11
			};
			//Debug.Log("Room Type One Ground Fifteen was chosen.");
			break;
		case 16:
			tileBlockArray = new int[]
			{
				1,0,1,16,0,
				0,0,41,0,0,
				1,141,11,1,1
			};
			//Debug.Log("Room Type One Ground Sixteen was chosen.");
			break;
		case 17:
			tileBlockArray = new int[]
			{
				1,1,20,1,0,
				1,667,0,0,0,
				0,21,1,1,1
			};
			//Debug.Log("Room Type One Ground Seventeen was chosen.");
			break;
		case 18:
			tileBlockArray = new int[]
			{
				1,0,1,0,11,
				1,0,11,0,0,
				1,3,1,0,1
			};
			//Debug.Log("Room Type One Ground Eighteen was chosen.");
			break;
		case 19:
			tileBlockArray = new int[]
			{
				1,1,0,0,0,
				9,0,0,3,10,
				1,1,1,1,1
			};
			//Debug.Log("Room Type One Ground Nineteen was chosen.");
			break;
		case 20:
			tileBlockArray = new int[]
			{
				0,1,1,0,0,
				3,1,1,0,0,
				1,0,0,1,1
			};
			//Debug.Log("Room Type One Ground Twenty was chosen.");
			break;
		}
		
		//calls the function to loop through the array
		LoopThroughArray ();
	}
	
	//sets the position of the ground obstacle block
	private void GroundBlockPositionInitalize(Vector3 groundblockstart)
	{
		tilePosition = groundblockstart;
		transform.position = tilePosition;
		//sets the starting x position of the obstacle block
		startObstacleXposition = groundblockstart.x;
		//sets the starting y position of the obstacle block
		startObstacleYposition = groundblockstart.y;
		//Debug.Log("Room Type One Ground tileBlock initalized");
	}
	
	//picks a left air template at random
	public void ChooseLeftAirTemplate ()
	{
		int temp = Random.Range(0, 11);
		
		switch (temp)
		{
		case 0:
			tileBlockArray = new int[] 
			{
				0,21,2,1,16,
				1,1,0,0,0,
			};
			//Debug.Log("Room Type One Left Air Zero was chosen.");
			break;
		case 1:
			tileBlockArray = new int[]
			{
				0,2,0,2,0,
				0,1,142,11,1
			};
			//Debug.Log("Room Type One Left Air One was chosen.");
			break;
		case 2:
			tileBlockArray = new int[]
			{
				2,1,0,0,4,
				667,1,1,1,2,
			};
			//Debug.Log("Room Type One Left Air Two was chosen.");
			break;
		case 3:
			tileBlockArray = new int[]
			{
				2,1,1,0,21,
				0,8,8,8,0,
			};
			//Debug.Log("Room Type One Left Air Three was chosen.");
			break;
		case 4:
			tileBlockArray = new int[]
			{
				0,21,1,111,0,
				1,8,8,0,21,
			};
			//Debug.Log("Room Type One Left Air Four was chosen.");
			break;
			
		case 5:
			tileBlockArray = new int[]
			{
				0,0,10,1,0,
				0,21,1,0,2,
			};
			//Debug.Log("Room Type One Left Air Five was chosen.");
			break;
		case 6:
			tileBlockArray = new int[]
			{
				1,0,12,0,1,
				12,0,1,0,12,
			};
			//Debug.Log("Room Type One Left Air Six was chosen.");
			break;
		case 7:
			tileBlockArray = new int[]
			{
				66,0,0,0,10,
				1,0,21,1,1,
			};
			//Debug.Log("Room Type One Left Air Seven was chosen.");
			break;
		case 8:
			tileBlockArray = new int[]
			{
				1,0,0,41,0,
				1,1,0,1,0,
			};
			//Debug.Log("Room Type One Left Air Eight was chosen.");
			break;
		case 9:
			tileBlockArray = new int[]
			{
				664,0,0,0,1,
				1,0,0,0,665,
			};
			//Debug.Log("Room Type One Left Air Nine was chosen.");
			break;
		case 10:
			tileBlockArray = new int[]
			{
				3,0,3,0,3,
				1,1,1,1,1,
			};
			//Debug.Log("Room Type One Left Air Ten was chosen.");
			break;
		}
		
		//calls the function to loop through the created array
		LoopThroughArray ();
	}
	
	//sets the postion of the left air obstacle block
	private void AirBlockPositionInitalize(Vector3 airblockstart)
	{
		tilePosition = airblockstart;
		transform.position = tilePosition;
		//sets the starting x position of the obstacle block
		startObstacleXposition = airblockstart.x;
		//sets the starting y position of the obstacle block
		startObstacleYposition = airblockstart.y;
		//Debug.Log("Room Type One Air tileBlock initalized");
	}
	
	//picks a right air template at random
	public void ChooseRightAirTemplate ()
	{
		//picks a random number correlated to a tileBlockArray
		int temp = Random.Range(0, 11);
		
		switch (temp)
		{
		case 0:
			tileBlockArray = new int[] 
			{
				0,0,41,0,0,
				0,0,1,1,1
			};
			//Debug.Log("Room Type One Right Air Zero was chosen.");
			break;
		case 1:
			tileBlockArray = new int[]
			{
				0,4,0,2,7,
				0,0,21,1,1
			};
			//Debug.Log("Room Type One Right Air One was chosen.");
			break;
		case 2:
			tileBlockArray = new int[]
			{
				1,0,0,0,1,
				8,2,1,1,2,
			};
			//Debug.Log("Room Type One Right Air Two was chosen.");
			break;
		case 3:
			tileBlockArray = new int[]
			{
				2,1,1,1,1,
				0,8,8,8,2,
			};
			//Debug.Log("Room Type One Right Air Three was chosen.");
			break;
		case 4:
			tileBlockArray = new int[]
			{
				1,1,1,2,1,
				0,665,665,0,0,
			};
			//Debug.Log("Room Type One Right Air Four was chosen.");
			break;
		case 5:
			tileBlockArray = new int[]
			{
				1,2,11,0,0,
				2,142,11,141,11
			};
			//Debug.Log("Room Type One Right Air Five was chosen.");
			break;
		case 6:
			tileBlockArray = new int[]
			{
				0,0,0,0,0,
				1,1,0,1,1,
			};
			//Debug.Log("Room Type One Right Air Six was chosen.");
			break;
		case 7:
			tileBlockArray = new int[]
			{
				664,0,0,0,1,
				1,0,0,0,665,
			};
			//Debug.Log("Room Type One Right Air Seven was chosen.");
			break;
		case 8:
			tileBlockArray = new int[]
			{
				1,1,1,16,0,
				0,0,0,0,4,
			};
			//Debug.Log("Room Type One Right Air Eight was chosen.");
			break;
		case 9:
			tileBlockArray = new int[]
			{
				0,4,41,0,0,
				1,1,1,0,0,
			};
			//Debug.Log("Room Type One Right Air Nine was chosen.");
			break;
		case 10:
			tileBlockArray = new int[]
			{
				2,2,2,2,2,
				2,2,2,2,2,
			};
			//Debug.Log("Room Type One Right Air Ten was chosen.");
			break;
		}
		//calls the function to loop through the created array
		LoopThroughArray ();
	}
	
	//determines which row the tile is in and sets its position accordingly
	private void CheckObstacleYPosition (int y)
	{
		if(y == 5 || y == 10)
		{
			tilePosition.y -= 1.0f;
			transform.position = tilePosition;
			CheckObstacleXPosition(y);
		}
		else
		{
			CheckObstacleXPosition(y);
		}
	}
	
	//determines which column the tile is in and sets its postion accordingly
	private void CheckObstacleXPosition (int x)
	{
		if(x < 5 || (x > 5 & x < 10) || x > 10 )
		{
			ObstacleTileInstantiate(x);
		}
		else if(x == 5 || x == 10)
		{
			//resets the x position to the starting x position for that obstacle block
			tilePosition.x = startObstacleXposition;
			transform.position = tilePosition;
			ObstacleTileInstantiate(x);
		}
	}
	
	//istantiates tile at appropriate position and moves the postion ahead
	private void ObstacleTileInstantiate(int iLoop)
	{
		if(tileBlockArray[iLoop] == 0)
		{
			Instantiate(tileOfRoom[12], tilePosition, Quaternion.identity);
			tilePosition.x += 1.0f;
			transform.position = tilePosition;
		}
		else if(tileBlockArray[iLoop] == 1)
		{
			//istantiates block then moves the x position ahead by one
			int randomSolid = Random.Range (0,6);
			Instantiate(tileOfRoom[randomSolid], tilePosition, Quaternion.identity);
			tilePosition.x += 1.0f;
			transform.position = tilePosition;
		}
		else if(tileBlockArray[iLoop] == 2)
		{
			//50% chance the block will be instantiated
			int rand50 = Random.Range(1,3);
			if(rand50 == 1)
			{
				//picks a random solid block texture
				int randomSolid50 = Random.Range (0,6);
				//istantiates block then moves the x position ahead by one
				Instantiate(tileOfRoom[randomSolid50], tilePosition, Quaternion.identity);
				tilePosition.x += 1.0f;
				transform.position = tilePosition;
				
			}
			else
			{
				//moves the x position ahead by one
				Instantiate(tileOfRoom[12], tilePosition, Quaternion.identity);
				tilePosition.x += 1.0f;
				transform.position = tilePosition;
			}
		}
		else if(tileBlockArray[iLoop] == 3)
		{
			//istantiates block then moves the x position ahead by one
			Instantiate(tileOfRoom[6], tilePosition, Quaternion.identity);
			tilePosition.x += 1.0f;
			transform.position = tilePosition;
		}
		else if(tileBlockArray[iLoop] == 4)
		{
			int rand50 = Random.Range (0,2);
			if(rand50 == 1)
			{
				//istantiates block then moves the x position ahead by one
				Instantiate(tileOfRoom[7], tilePosition, Quaternion.identity);
				tilePosition.x += 1.0f;
				transform.position = tilePosition;
			}
			else
			{
				Instantiate(tileOfRoom[12], tilePosition, Quaternion.identity);
				tilePosition.x += 1.0f;
				transform.position = tilePosition;
			}
		}
		else if(tileBlockArray[iLoop] == 5)
		{
			groundBlock1 = tilePosition;
			//Debug.Log("Room Type Tutorial Ground Block 1 initialized at: "+groundBlock1);
			
			Instantiate(tileOfRoom[12], tilePosition, Quaternion.identity);
			tilePosition.x += 1.0f;
			transform.position = tilePosition;
		}
		else if(tileBlockArray[iLoop] == 6)
		{
			
			airBlock1 = tilePosition;
			//Debug.Log("Room Type Tutorial Air Block 1 initialized at: "+airBlock1);
			
			Instantiate(tileOfRoom[12], tilePosition, Quaternion.identity);
			tilePosition.x += 1.0f;
			transform.position = tilePosition;
		}
		else if(tileBlockArray[iLoop] == 7)
		{
			int rand33 = Random.Range(1,4);
			if(rand33 == 1)
			{
				Instantiate(tileOfRoom[8], tilePosition, Quaternion.identity);
				tilePosition.x += 1.0f;
				transform.position = tilePosition;
			}
			else
			{
				Instantiate(tileOfRoom[12], tilePosition, Quaternion.identity);
				tilePosition.x += 1.0f;
				transform.position = tilePosition;
			}
		}
		else if(tileBlockArray[iLoop] == 8)
		{
			int rand33 = Random.Range(1,4);
			if(rand33 == 1)
			{
				Instantiate(tileOfRoom[9], tilePosition, Quaternion.identity);
				tilePosition.x += 1.0f;
				transform.position = tilePosition;
				
			}
			else
			{
				Instantiate(tileOfRoom[12], tilePosition, Quaternion.identity);
				tilePosition.x += 1.0f;
				transform.position = tilePosition;
			}
		}
		else if(tileBlockArray[iLoop] == 9)
		{
			Instantiate(tileOfRoom[10], tilePosition, Quaternion.identity);
			tilePosition.x += 1.0f;
			transform.position = tilePosition;
		}
		else if(tileBlockArray[iLoop] == 10)
		{
			int rand50 = Random.Range(0,4);
			if(rand50 != 1)
			{
				Instantiate(tileOfRoom[11], tilePosition, Quaternion.identity);
				tilePosition.x += 1.0f;
				transform.position = tilePosition;
			}
			else
			{
				Instantiate(tileOfRoom[12], tilePosition, Quaternion.identity);
				tilePosition.x += 1.0f;
				transform.position = tilePosition;
			}
		}
		else if(tileBlockArray[iLoop] == 11)
		{
			//istantiates block then moves the x position ahead by one
			Instantiate(tileOfRoom[14], tilePosition, Quaternion.identity);
			tilePosition.x += 1.0f;
			transform.position = tilePosition;
		}
		else if(tileBlockArray[iLoop] == 12)
		{
			//istantiates block then moves the x position ahead by one
			Instantiate(tileOfRoom[8], tilePosition, Quaternion.identity);
			tilePosition.x += 1.0f;
			transform.position = tilePosition;
		}
		else if(tileBlockArray[iLoop] == 13)
		{
			//istantiates block then moves the x position ahead by one
			Instantiate(tileOfRoom[9], tilePosition, Quaternion.identity);
			tilePosition.x += 1.0f;
			transform.position = tilePosition;
		}
		else if(tileBlockArray[iLoop] == 14)
		{
			int rand25 = Random.Range(0,4);
			if(rand25 == 1)
			{
				Instantiate(tileOfRoom[13], tilePosition, Quaternion.identity);
				tilePosition.x += 1.0f;
				transform.position = tilePosition;
			}
			else
			{
				Instantiate(tileOfRoom[12], tilePosition, Quaternion.identity);
				tilePosition.x += 1.0f;
				transform.position = tilePosition;
			}
		}
		else if(tileBlockArray[iLoop] == 15)
		{
			//istantiates block then moves the x position ahead by one
			Instantiate(tileOfRoom[24], tilePosition, Quaternion.identity);
			tilePosition.x += 1.0f;
			transform.position = tilePosition;
		}
		else if(tileBlockArray[iLoop] == 16)
		{
			//istantiates block then moves the x position ahead by one
			Instantiate(tileOfRoom[25], tilePosition, Quaternion.identity);
			tilePosition.x += 1.0f;
			transform.position = tilePosition;
		}
		else if(tileBlockArray[iLoop] == 17)
		{
			//istantiates block then moves the x position ahead by one
			GameObject telaIn = Instantiate(tileOfRoom[26], roomTilePosition, Quaternion.identity) as GameObject;
			telaInStringName = telaportNumeric.ToString();
			telaIn.gameObject.name = telaInStringName;
			roomTilePosition.x += 1.0f;
			transform.position = roomTilePosition;
		}
		else if(tileBlockArray[iLoop] == 18)
		{
			//istantiates block then moves the x position ahead by one
			GameObject telaOut = Instantiate(tileOfRoom[27], roomTilePosition, Quaternion.identity) as GameObject;
			telaOutStringName = ("telaOut"+telaportNumeric);
			telaOut.gameObject.name = telaOutStringName;
			Debug.Log (telaOut.gameObject.name);
			roomTilePosition.x += 1.0f;
			transform.position = roomTilePosition;
		}
		else if(tileBlockArray[iLoop] == 20)
		{
			//istantiates block then moves the x position ahead by one
			Instantiate(tileOfRoom[21], tilePosition, Quaternion.identity);
			tilePosition.x += 1.0f;
			transform.position = tilePosition;
		}
		else if(tileBlockArray[iLoop] == 21)
		{
			Vector3 correctedPosition = tilePosition + new Vector3(0.5f, 0.0f, 0.0f);
			int rand13 = Random.Range(1,4);
			if(rand13 == 1)
			{
				//istantiates block then moves the x position ahead by one
				Instantiate(tileOfRoom[16], correctedPosition, Quaternion.identity);
				tilePosition.x += 1.0f;
				transform.position = tilePosition;
			}
			else if(rand13 == 2)
			{
				//istantiates block then moves the x position ahead by one
				Instantiate(tileOfRoom[17], correctedPosition, Quaternion.identity);
				tilePosition.x += 1.0f;
				transform.position = tilePosition;
			}
			else if(rand13 == 3)
			{
				//istantiates block then moves the x position ahead by one
				Instantiate(tileOfRoom[18], correctedPosition, Quaternion.identity);
				tilePosition.x += 1.0f;
				transform.position = tilePosition;
			}
		}
		else if(tileBlockArray[iLoop] == 33)
		{
			//istantiates block then moves the x position ahead by one
			Instantiate(tileOfRoom[15], tilePosition, Quaternion.identity);
			tilePosition.x += 1.0f;
			transform.position = tilePosition;
		}
		else if (tileBlockArray[iLoop] == 41)
		{
			Instantiate(tileOfRoom[7], tilePosition, Quaternion.identity);
			tilePosition.x += 1.0f;
			transform.position = tilePosition;
		}
		else if(tileBlockArray[iLoop] == 50)
		{
			//istantiates block then moves the x position ahead by one
			int randomSolid = Random.Range (0,6);
			GameObject hiddenRoom = Instantiate(tileOfRoom[randomSolid], tilePosition, Quaternion.identity) as GameObject;
			hiddenRoom.layer = 15;
			tilePosition.x += 1.0f;
			transform.position = tilePosition;
		}
		else if(tileBlockArray[iLoop] == 66)
		{
			//istantiates block then moves the x position ahead by one
			GameObject BG = Instantiate(tileOfRoom[22], tilePosition, Quaternion.identity) as GameObject;
			BG.gameObject.tag = "BadGuy";
			tilePosition.x += 1.0f;
			transform.position = tilePosition;
		}
		else if(tileBlockArray[iLoop] == 76)
		{
			Instantiate(tileOfRoom[28], tilePosition, Quaternion.identity);
			tilePosition.x += 1.0f;
			transform.position = tilePosition;
		}
		else if(tileBlockArray[iLoop] == 86)
		{
			Instantiate(tileOfRoom[29], tilePosition, Quaternion.identity);
			tilePosition.x += 1.0f;
			transform.position = tilePosition;
		}
		else if(tileBlockArray[iLoop] == 96)
		{
			GameObject SB = Instantiate(tileOfRoom[30], tilePosition, Quaternion.identity) as GameObject;
			SB.gameObject.name = "ShaddowBounce";
			tilePosition.x += 1.0f;
			transform.position = tilePosition;
		}
		else if(tileBlockArray[iLoop] == 97)
		{
			GameObject SB = Instantiate(tileOfRoom[30], tilePosition, Quaternion.identity) as GameObject;
			SB.gameObject.name = "ShaddowForward";
			tilePosition.x += 1.0f;
			transform.position = tilePosition;
		}
		else if(tileBlockArray[iLoop] == 99)
		{
			Instantiate(tileOfRoom[23], tilePosition, Quaternion.identity);
			tilePosition.x += 1.0f;
			transform.position = tilePosition;
		}
		else if(tileBlockArray[iLoop] == 100)
		{
			Instantiate(tileOfRoom[11], tilePosition, Quaternion.identity);
			tilePosition.x += 1.0f;
			transform.position = tilePosition;
		}
		else if(tileBlockArray[iLoop] == 111)
		{
			//33% chance the block will be instantiated
			int rand33 = Random.Range(1,4);
			if(rand33 == 1)
			{
				//istantiates block then moves the x position ahead by one
				Instantiate(tileOfRoom[21], tilePosition, Quaternion.identity);
				tilePosition.x += 1.0f;
				transform.position = tilePosition;
				
			}
			else
			{
				//moves the x position ahead by one
				Instantiate(tileOfRoom[12], tilePosition, Quaternion.identity);
				tilePosition.x += 1.0f;
				transform.position = tilePosition;
			}
		}
		else if(tileBlockArray[iLoop] == 141)
		{
			//istantiates block then moves the x position ahead by one
			Instantiate(tileOfRoom[19], tilePosition, Quaternion.identity);
			tilePosition.x += 1.0f;
			transform.position = tilePosition;
		}
		else if(tileBlockArray[iLoop] == 142)
		{
			//istantiates block then moves the x position ahead by one
			Instantiate(tileOfRoom[20], tilePosition, Quaternion.identity);
			tilePosition.x += 1.0f;
			transform.position = tilePosition;
		}
		else if(tileBlockArray[iLoop] == 320)
		{
			//aprox. 20% chance the block will be instantiated
			int rand20 = Random.Range(0,5);
			if(rand20 == 0)
			{
				//istantiates block then moves the x position ahead by one
				Instantiate(tileOfRoom[6], tilePosition, Quaternion.identity);
				tilePosition.x += 1.0f;
				transform.position = tilePosition;
			}
			else
			{
				//moves the x position ahead by one
				Instantiate(tileOfRoom[12], tilePosition, Quaternion.identity);
				tilePosition.x += 1.0f;
				transform.position = tilePosition;
			}
		}
		else if(tileBlockArray[iLoop] == 360)
		{
			//aprox. 60% chance the block will be instantiated
			int rand60 = Random.Range(0,3);
			if(rand60 != 0)
			{
				//istantiates block then moves the x position ahead by one
				Instantiate(tileOfRoom[6], tilePosition, Quaternion.identity);
				tilePosition.x += 1.0f;
				transform.position = tilePosition;
			}
			else
			{
				//moves the x position ahead by one
				Instantiate(tileOfRoom[12], tilePosition, Quaternion.identity);
				tilePosition.x += 1.0f;
				transform.position = tilePosition;
			}
		}
		else if(tileBlockArray[iLoop] == 661)
		{
			//istantiates block then moves the x position ahead by one
			GameObject BGV = Instantiate(tileOfRoom[22], tilePosition, Quaternion.identity) as GameObject;
			BGV.gameObject.tag = "BadGuyVert";
			tilePosition.x += 1.0f;
			transform.position = tilePosition;
		}
		else if(tileBlockArray[iLoop] == 664)
		{
			GameObject spks = Instantiate(tileOfRoom[28], tilePosition, Quaternion.identity) as GameObject;
			spks.gameObject.tag = "spike";
			tilePosition.x += 1.0f;
			transform.position = tilePosition;
		}
		else if(tileBlockArray[iLoop] == 665)
		{
			GameObject spks = Instantiate(tileOfRoom[29], tilePosition, Quaternion.identity) as GameObject;
			spks.gameObject.tag = "topspike";
			tilePosition.x += 1.0f;
			transform.position = tilePosition;
		}
		else if(tileBlockArray[iLoop] == 666)
		{
			//istantiates block then moves the x position ahead by one
			Instantiate(tileOfRoom[22], tilePosition, Quaternion.identity);
			tilePosition.x += 1.0f;
			transform.position = tilePosition;
		}
		else if(tileBlockArray[iLoop] == 667)
		{
			GameObject spks = Instantiate(tileOfRoom[31], tilePosition, Quaternion.identity) as GameObject;
			spks.gameObject.tag = "leftspike";
			tilePosition.x += 1.0f;
			transform.position = tilePosition;
		}
		else if(tileBlockArray[iLoop] == 668)
		{
			GameObject spks = Instantiate(tileOfRoom[32], tilePosition, Quaternion.identity) as GameObject;
			spks.gameObject.tag = "rightspike";
			tilePosition.x += 1.0f;
			transform.position = tilePosition;
		}
	}
}
