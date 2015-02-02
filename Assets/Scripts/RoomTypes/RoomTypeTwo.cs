using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RoomTypeTwo : MonoBehaviour {
	
	//set up room 
	public GameObject[] tileOfRoom;
	public Vector3 startingPosition2;
	private Vector3 roomTilePosition;
	private List<int> lineBreaks = new List<int>(new int[] {10,20,30,40,50,60,70});
	
	public int[] typeTwoArray;
	
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
	public void BeginRoom2 () 
	{
		Debug.Log ("This is the starting position for RoomType2 "+startingPosition2);
		ChooseRoomTypeTwoTemplate();
		CheckForObstacleBlocks();
		ResetTheRoom();
	}
	
	private void ResetTheRoom()
	{
		telaportNumeric +=1;
		groundBlock1 = Vector3.zero;
		groundBlock2 = Vector3.zero;
		airBlock1 = Vector3.zero;
		airBlock2 = Vector3.zero;
		startObstacleXposition = 0.0f;
		startObstacleYposition = 0.0f;
	}
	
	private void LoopThroughTypeTwoArray ()
	{
		for (int i = 0; i < typeTwoArray.Length; i++)
		{
			CheckYPosition(i);
		}
	}
	
	private void ChooseRoomTypeTwoTemplate ()
	{
		RoomTypeTwoPositionInitalize();
		//picks a random number correlated to a Type 1 template
		int temp = Random.Range(0, 13);
		
		switch (temp)
		{
		case 0:
			typeTwoArray = new int[] 
			{
				0,2,1,11,1,1,1,1,2,2,
				0,0,8,11,142,1,1,1,0,2,
				10,0,0,8,1,1,1,8,0,2,
				0,0,0,0,8,1,8,0,0,2,
				0,0,0,0,0,0,0,0,0,1,
				0,0,0,0,0,0,0,0,0,9,
				3,4,20,0,0,0,0,111,0,11,
				1,1,11,2,0,0,2,11,142,1
			};
			Debug.Log("Room Type Two Zero was chosen.");
			break;
		case 1:
			typeTwoArray = new int[]
			{
				0,0,0,0,0,0,0,0,0,0,
				0,6,0,0,0,0,0,0,0,0,
				0,0,0,0,0,0,0,1,2,0,
				0,0,0,0,0,0,0,0,0,0,
				0,20,0,0,0,0,0,0,0,0,
				1,1,2,0,0,5,0,0,0,0,
				0,0,0,0,0,0,0,0,0,0,
				0,0,0,0,0,0,0,0,0,0
			};
			Debug.Log("Room Type Two One was chosen.");
			break;
		case 2:
			typeTwoArray = new int[]
			{
				0,0,0,0,0,6,0,0,0,0,
				0,0,0,0,0,0,0,0,0,0,
				5,0,0,0,0,0,0,0,0,0,
				0,0,0,0,0,0,0,0,0,0,
				0,0,0,0,0,0,0,0,20,0,
				20,0,0,0,0,0,0,0,0,7,
				1,2,0,20,0,0,0,0,3,1,
				141,11,2,2,0,0,2,11,1,1
			};
			Debug.Log("Room Type Two Two was chosen.");
			break;
		case 3:
			typeTwoArray = new int[]
			{
				0,0,0,0,0,6,0,0,0,0,
				0,0,0,0,0,0,0,0,0,0,
				0,0,0,0,0,0,0,0,0,0,
				0,10,0,7,0,0,0,0,0,0,
				1,1,1,1,1,0,0,0,0,0,
				1,0,111,0,0,1,0,0,0,14,
				1,20,20,0,9,0,0,0,3,1,
				1,141,0,21,11,11,0,0,1,1
			};
			Debug.Log("Room Type Two Three was chosen.");
			break;
		case 4:
			typeTwoArray = new int[]
			{
				0,0,0,0,0,0,0,0,0,0,
				0,0,0,5,0,0,0,0,0,0,
				0,0,0,0,0,0,0,0,0,0,
				0,0,0,0,0,0,0,0,0,0,
				0,0,0,0,1,2,0,0,0,0,
				0,0,7,0,0,0,0,0,2,0,
				7,0,1,0,0,0,0,0,1,111,
				1,11,142,1,0,0,0,1,1,1
			};
			Debug.Log("Room Type Two Four was chosen.");
			break;
		case 5:
			typeTwoArray = new int[]
			{
				0,0,0,0,0,2,1,142,11,0,
				0,0,0,0,0,0,0,0,0,0,
				0,0,1,0,0,0,21,0,0,0,
				0,0,2,0,0,0,0,0,0,0,
				0,3,11,141,2,1,0,0,0,0,
				11,11,20,0,0,0,0,0,0,0,
				1,1,1,2,0,0,0,0,7,0,
				0,0,0,0,0,0,0,11,1,1
			};
			Debug.Log("Room Type Two Five was chosen.");
			break;
		case 6:
			typeTwoArray = new int[]
			{
				0,0,0,7,0,0,0,0,0,0,
				0,0,0,1,0,0,0,0,21,
				0,10,0,0,0,0,0,0,0,0,
				0,0,0,0,0,0,7,0,0,0,
				0,0,0,2,0,0,1,0,0,0,
				0,0,0,1,0,0,0,1,0,0,
				0,320,1,0,0,0,21,1,11,
				2,1,0,0,0,0,0,11,2,2
			};
			Debug.Log("Room Type Two Six was chosen.");
			break;
		case 7:
			typeTwoArray = new int[]
			{
				0,11,2,2,2,2,2,1,1,16,
				0,0,1,0,20,0,11,0,0,0,
				1,0,0,1,0,11,0,0,0,661,
				0,0,0,0,1,1,0,0,0,0,
				0,0,0,0,0,0,0,3,0,0,
				0,0,0,0,0,0,0,1,0,0,
				6,0,0,0,0,0,0,0,0,20,
				0,0,0,0,0,0,0,0,1,1
			};
			Debug.Log("Room Type Two Seven was chosen.");
			break;
		case 8:
			typeTwoArray = new int[]
			{
				0,1,1,11,141,11,142,11,1,1,
				0,0,0,0,0,0,0,0,0,0,
				0,0,0,0,0,0,0,0,0,0,
				0,0,667,0,21,668,0,0,0,0,
				0,0,0,1,0,0,0,0,0,0,
				0,0,0,665,0,0,0,0,0,0,
				1,0,0,0,0,0,2,1,0,20,
				1,1,0,0,0,1,0,21,1,11
			};
			Debug.Log("Room Type Two Eight was chosen.");
			break;
		case 9:
			typeTwoArray = new int[]
			{
				0,11,11,1,1,1,1,11,1,11,
				0,0,0,0,13,0,0,20,0,0,
				0,0,0,0,0,0,0,0,21,0,
				0,0,0,0,0,0,0,0,0,0,
				0,0,0,1,0,2,0,0,0,0,
				0,0,1,1,0,0,1,0,0,0,
				0,1,0,21,0,0,0,21,0,0,
				1,0,21,1,0,0,1,1,142,11
			};
			Debug.Log("Room Type Two Nine was chosen.");
			break;
		case 10:
			typeTwoArray = new int[]
			{
				0,11,11,1,1,0,21,1,1,11,
				0,0,0,21,0,21,1,13,0,0,
				1,0,141,1,0,21,1,13,0,0,
				141,0,11,1,1,1,0,0,0,0,
				11,0,0,0,0,0,0,0,0,0,
				9,0,0,0,0,0,0,0,0,0,
				142,20,0,0,11,1,664,1,0,0,
				141,0,0,11,1,1,1,1,11,7
			};
			Debug.Log("Room Type Two Ten was chosen.");
			break;
		case 11:
			typeTwoArray = new int[]
			{
				0,11,11,1,1,6,0,0,0,0,
				0,0,0,0,0,0,0,0,0,0,
				0,0,0,0,0,0,0,0,0,0,
				1,0,0,111,2,0,0,4,0,0,
				0,0,0,3,1,1,0,0,0,0,
				0,0,2,2,1,2,2,0,0,0,
				0,0,0,1,1,20,0,0,0,0,
				2,0,0,0,2,0,0,0,0,2
			};
			Debug.Log("Room Type Two Eleven was chosen.");
			break;
		case 12:
			typeTwoArray = new int[]
			{
				0,11,1,11,11,1,1,1,11,11,
				0,0,0,0,0,0,0,66,0,0,
				1,1,1,0,0,0,1,1,0,0,
				1,0,0,1,1,1,0,66,0,0,
				1,0,0,0,0,0,0,0,0,0,
				0,20,0,661,0,0,0,1,1,1,
				0,0,0,0,0,111,3,0,0,1,
				1,11,11,0,0,1,1,0,0,11
			};
			Debug.Log("Room Type Two Twelve was chosen.");
			break;
		}
		//calls the function to loop through the created array
		LoopThroughTypeTwoArray ();
	}
	
	private void RoomTypeTwoPositionInitalize()
	{
		//sets the starting x position of the room
		roomTilePosition.x = startingPosition2.x;
		//sets the starting y position of the room
		roomTilePosition.y = startingPosition2.y;
		//sets the starting z position of the room
		roomTilePosition.z = 0;
		transform.position = roomTilePosition;  
		//Debug.Log("Room Type Two initalized");
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
			roomTilePosition.x = startingPosition2.x;
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
		if(typeTwoArray[arrayNum] == 0)
		{
			Instantiate(tileOfRoom[12], roomTilePosition, Quaternion.identity);
			roomTilePosition.x += 1.0f;
			transform.position = roomTilePosition;
		}
		else if(typeTwoArray[arrayNum] == 1)
		{
			//istantiates block then moves the x position ahead by one
			int randomSolid = Random.Range (0,6);
			Instantiate(tileOfRoom[randomSolid], roomTilePosition, Quaternion.identity);
			roomTilePosition.x += 1.0f;
			transform.position = roomTilePosition;
		}
		else if(typeTwoArray[arrayNum] == 2)
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
		else if(typeTwoArray[arrayNum] == 3)
		{
			//istantiates block then moves the x position ahead by one
			Instantiate(tileOfRoom[6], roomTilePosition, Quaternion.identity);
			roomTilePosition.x += 1.0f;
			transform.position = roomTilePosition;
		}
		else if(typeTwoArray[arrayNum] == 4)
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
		else if(typeTwoArray[arrayNum] == 5)
		{
			if(groundBlock1 == Vector3.zero)
			{
				groundBlock1 = roomTilePosition;
				Debug.Log("Room Type Two Ground Block 1 initialized at: "+groundBlock1);
			}
			else
			{
				groundBlock2 = roomTilePosition;
				Debug.Log("Room Type Two Ground Block 2 initialized at: "+groundBlock2);
			}
			
			Instantiate(tileOfRoom[12], roomTilePosition, Quaternion.identity);
			roomTilePosition.x += 1.0f;
			transform.position = roomTilePosition;
		}
		else if(typeTwoArray[arrayNum] == 6)
		{
			
			if(airBlock1 == Vector3.zero)
			{
				airBlock1 = roomTilePosition;
				Debug.Log("Room Type Two Air Block 1 initialized at: "+airBlock1);
			}
			else
			{
				airBlock2 = roomTilePosition;
				Debug.Log("Room Type Two Air Block 2 initialized at: "+airBlock2);
			}
			
			Instantiate(tileOfRoom[12], roomTilePosition, Quaternion.identity);
			roomTilePosition.x += 1.0f;
			transform.position = roomTilePosition;
		}
		else if(typeTwoArray[arrayNum] == 7)
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
		else if(typeTwoArray[arrayNum] == 8)
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
		else if(typeTwoArray[arrayNum] == 9)
		{
			Instantiate(tileOfRoom[10], roomTilePosition, Quaternion.identity);
			roomTilePosition.x += 1.0f;
			transform.position = roomTilePosition;
		}
		else if(typeTwoArray[arrayNum] == 10)
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
		else if(typeTwoArray[arrayNum] == 11)
		{
			//istantiates block then moves the x position ahead by one
			Instantiate(tileOfRoom[14], roomTilePosition, Quaternion.identity);
			roomTilePosition.x += 1.0f;
			transform.position = roomTilePosition;
		}
		else if(typeTwoArray[arrayNum] == 12)
		{
			//istantiates block then moves the x position ahead by one
			Instantiate(tileOfRoom[8], roomTilePosition, Quaternion.identity);
			roomTilePosition.x += 1.0f;
			transform.position = roomTilePosition;
		}
		else if(typeTwoArray[arrayNum] == 13)
		{
			//istantiates block then moves the x position ahead by one
			Instantiate(tileOfRoom[9], roomTilePosition, Quaternion.identity);
			roomTilePosition.x += 1.0f;
			transform.position = roomTilePosition;
		}
		else if(typeTwoArray[arrayNum] == 14)
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
		else if(typeTwoArray[arrayNum] == 15)
		{
			//istantiates block then moves the x position ahead by one
			Instantiate(tileOfRoom[24], roomTilePosition, Quaternion.identity);
			roomTilePosition.x += 1.0f;
			transform.position = roomTilePosition;
		}
		else if(typeTwoArray[arrayNum] == 16)
		{
			//istantiates block then moves the x position ahead by one
			Instantiate(tileOfRoom[25], roomTilePosition, Quaternion.identity);
			roomTilePosition.x += 1.0f;
			transform.position = roomTilePosition;
		}
		else if(typeTwoArray[arrayNum] == 17)
		{
			//istantiates block then moves the x position ahead by one
			GameObject telaIn = Instantiate(tileOfRoom[26], roomTilePosition, Quaternion.identity) as GameObject;
			telaInStringName = telaportNumeric.ToString();
			telaIn.gameObject.name = telaInStringName;
			roomTilePosition.x += 1.0f;
			transform.position = roomTilePosition;
		}
		else if(typeTwoArray[arrayNum] == 18)
		{
			//istantiates block then moves the x position ahead by one
			GameObject telaOut = Instantiate(tileOfRoom[27], roomTilePosition, Quaternion.identity) as GameObject;
			telaOutStringName = ("telaOut"+telaportNumeric);
			telaOut.gameObject.name = telaOutStringName;
			//Debug.Log (telaOut.gameObject.name);
			roomTilePosition.x += 1.0f;
			transform.position = roomTilePosition;
		}
		else if(typeTwoArray[arrayNum] == 20)
		{
			//istantiates block then moves the x position ahead by one
			Instantiate(tileOfRoom[21], roomTilePosition, Quaternion.identity);
			roomTilePosition.x += 1.0f;
			transform.position = roomTilePosition;
		}
		else if(typeTwoArray[arrayNum] == 21)
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
		else if(typeTwoArray[arrayNum] == 33)
		{
			//istantiates block then moves the x position ahead by one
			Instantiate(tileOfRoom[15], roomTilePosition, Quaternion.identity);
			roomTilePosition.x += 1.0f;
			transform.position = roomTilePosition;
		}
		else if (typeTwoArray[arrayNum] == 41)
		{
			Instantiate(tileOfRoom[7], roomTilePosition, Quaternion.identity);
			roomTilePosition.x += 1.0f;
			transform.position = roomTilePosition;
		}
		else if(typeTwoArray[arrayNum] == 50)
		{
			//istantiates block
			int randomSolid = Random.Range (0,6);
			GameObject hiddenRoom = Instantiate(tileOfRoom[randomSolid], roomTilePosition, Quaternion.identity) as GameObject;
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
		}
		else if(typeTwoArray[arrayNum] == 66)
		{
			//istantiates block then moves the x position ahead by one
			GameObject BG = Instantiate(tileOfRoom[22], roomTilePosition, Quaternion.identity) as GameObject;
			BG.gameObject.tag = "BadGuy";
			Vector3 fluffybg = BG.transform.position;
			fluffybg.z = 1.0f;
			BG.transform.position = fluffybg;
			roomTilePosition.x += 1.0f;
			transform.position = roomTilePosition;
		}
		else if(typeTwoArray[arrayNum] == 76)
		{
			Instantiate(tileOfRoom[28], roomTilePosition, Quaternion.identity);
			roomTilePosition.x += 1.0f;
			transform.position = roomTilePosition;
		}
		else if(typeTwoArray[arrayNum] == 86)
		{
			Instantiate(tileOfRoom[29], roomTilePosition, Quaternion.identity);
			roomTilePosition.x += 1.0f;
			transform.position = roomTilePosition;
		}
		else if(typeTwoArray[arrayNum] == 96)
		{
			GameObject SB = Instantiate(tileOfRoom[30], roomTilePosition, Quaternion.identity) as GameObject;
			SB.gameObject.name = "ShaddowBounce";
			roomTilePosition.x += 1.0f;
			transform.position = roomTilePosition;
		}
		else if(typeTwoArray[arrayNum] == 97)
		{
			GameObject SB = Instantiate(tileOfRoom[30], roomTilePosition, Quaternion.identity) as GameObject;
			SB.gameObject.name = "ShaddowForward";
			roomTilePosition.x += 1.0f;
			transform.position = roomTilePosition;
		}
		else if(typeTwoArray[arrayNum] == 99)
		{
			Instantiate(tileOfRoom[23], roomTilePosition, Quaternion.identity);
			roomTilePosition.x += 1.0f;
			transform.position = roomTilePosition;
		}
		else if(typeTwoArray[arrayNum] == 100)
		{
			Instantiate(tileOfRoom[11], roomTilePosition, Quaternion.identity);
			roomTilePosition.x += 1.0f;
			transform.position = roomTilePosition;
		}
		else if(typeTwoArray[arrayNum] == 111)
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
		else if(typeTwoArray[arrayNum] == 141)
		{
			//istantiates block then moves the x position ahead by one
			Instantiate(tileOfRoom[19], roomTilePosition, Quaternion.identity);
			roomTilePosition.x += 1.0f;
			transform.position = roomTilePosition;
		}
		else if(typeTwoArray[arrayNum] == 142)
		{
			//istantiates block then moves the x position ahead by one
			Instantiate(tileOfRoom[20], roomTilePosition, Quaternion.identity);
			roomTilePosition.x += 1.0f;
			transform.position = roomTilePosition;
		}
		else if(typeTwoArray[arrayNum] == 320)
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
		else if(typeTwoArray[arrayNum] == 360)
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
		else if(typeTwoArray[arrayNum] == 661)
		{
			//istantiates block then moves the x position ahead by one
			GameObject BGV = Instantiate(tileOfRoom[33], roomTilePosition, Quaternion.identity) as GameObject;
			BGV.gameObject.tag = "BadGuyVert";
			Vector3 fluffybgv = BGV.transform.position;
			fluffybgv.z = 0.0f;
			BGV.transform.position = fluffybgv;
			roomTilePosition.x += 1.0f;
			transform.position = roomTilePosition;
		}
		else if(typeTwoArray[arrayNum] == 664)
		{
			GameObject spks = Instantiate(tileOfRoom[28], roomTilePosition, Quaternion.identity) as GameObject;
			spks.gameObject.tag = "spike";
			roomTilePosition.x += 1.0f;
			transform.position = roomTilePosition;
		}
		else if(typeTwoArray[arrayNum] == 665)
		{
			GameObject spks = Instantiate(tileOfRoom[29], roomTilePosition, Quaternion.identity) as GameObject;
			spks.gameObject.tag = "topspike";
			roomTilePosition.x += 1.0f;
			transform.position = roomTilePosition;
		}
		else if(typeTwoArray[arrayNum] == 666)
		{
			//istantiates block then moves the x position ahead by one
			Instantiate(tileOfRoom[22], roomTilePosition, Quaternion.identity);
			roomTilePosition.x += 1.0f;
			transform.position = roomTilePosition;
		}
		else if(typeTwoArray[arrayNum] == 667)
		{
			GameObject spks = Instantiate(tileOfRoom[31], roomTilePosition, Quaternion.identity) as GameObject;
			spks.gameObject.tag = "leftspike";
			roomTilePosition.x += 1.0f;
			transform.position = roomTilePosition;
		}
		else if(typeTwoArray[arrayNum] == 668)
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
			GroundBlockPositionInitalize2(groundBlock2);
			ChooseGroundTemplate ();
		}
		if(airBlock1 != Vector3.zero)
		{
			AirBlockPositionInitalize(airBlock1);
			ChooseLeftAirTemplate();
		}
		if(airBlock2 != Vector3.zero)
		{
			AirBlockPositionInitalize2(airBlock2);
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
		int temp = Random.Range(0, 6);
		
		switch (temp)
		{
		case 0:
			tileBlockArray = new int[] 
			{
				0,0,0,0,7,
				0,0,1,1,1,
			};
			//Debug.Log("Room Type Two Ground Zero was chosen.");
			break;
		case 1:
			tileBlockArray = new int[]
			{
				2,0,0,4,0,
				1,1,1,1,1,
			};
			//Debug.Log("Room Type Two Ground One was chosen.");
			break;
		case 2:
			tileBlockArray = new int[]
			{
				0,4,1,7,0,
				0,1,1,1,0,
			};
			//Debug.Log("Room Type Two Ground Two was chosen.");
			break;
		case 3:
			tileBlockArray = new int[]
			{
				0,1,111,1,11,
				0,7,2,7,0,
			};
			//Debug.Log("Room Type Two Ground Three was chosen.");
			break;
		case 4:
			tileBlockArray = new int[]
			{
				4,2,1,0,0,
				1,1,0,1,1,
			};
			//Debug.Log("Room Type Two Ground Four was chosen.");
			break;
		case 5:
			tileBlockArray = new int[]
			{
				0,665,11,1,2,
				0,1,0,0,0,
			};
			//Debug.Log("Room Type Two Ground Five was chosen.");
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
		//Debug.Log("Room Type Two Ground tileBlock initalized");
	}
	private void GroundBlockPositionInitalize2(Vector3 groundblockstart)
	{
		tilePosition = groundblockstart;
		transform.position = tilePosition;
		//sets the starting x position of the obstacle block
		startObstacleXposition = groundblockstart.x;
		//sets the starting y position of the obstacle block
		startObstacleYposition = groundblockstart.y;
		//Debug.Log("Room Type Two Ground tileBlock initalized");
	}
	
	//picks a left air template at random
	public void ChooseLeftAirTemplate ()
	{
		int temp = Random.Range(0, 5);
		
		switch (temp)
		{
		case 0:
			tileBlockArray = new int[] 
			{
				1,2,1,1,1,
				1,115,2,2,11,
			};
			//Debug.Log("Room Type Two Left Air Zero was chosen.");
			break;
		case 1:
			tileBlockArray = new int[]
			{
				0,4,0,0,2,
				0,1,1,1,1,
			};
			//Debug.Log("Room Type Two Left Air One was chosen.");
			break;
		case 2:
			tileBlockArray = new int[]
			{
				0,1,96,0,0,
				1,2,1,1,2,
			};
			//Debug.Log("Room Type Two Left Air Two was chosen.");
			break;
		case 3:
			tileBlockArray = new int[]
			{
				0,1,2,1,2,
				0,8,0,8,0,
			};
			//Debug.Log("Room Type Two Left Air Three was chosen.");
			break;
		case 4:
			tileBlockArray = new int[]
			{
				0,1,1,4,0,
				2,8,8,1,2,
			};
			//Debug.Log("Room Type Two Left Air Four was chosen.");
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
		//Debug.Log("Room Type Two Air tileBlock initalized at: " +airblockstart);
	}
	private void AirBlockPositionInitalize2(Vector3 airblockstart)
	{
		tilePosition = airblockstart;
		transform.position = tilePosition;
		//sets the starting x position of the obstacle block
		startObstacleXposition = airblockstart.x;
		//sets the starting y position of the obstacle block
		startObstacleYposition = airblockstart.y;
		//Debug.Log("Room Type Two Air tileBlock initalized at: " +airblockstart);
	}
	
	//picks a right air template at random
	public void ChooseRightAirTemplate ()
	{
		//picks a random number correlated to a tileBlockArray
		int temp = Random.Range(0, 10);
		
		switch (temp)
		{
		case 0:
			tileBlockArray = new int[] 
			{
				2,7,141,2,0,
				0,1,1,1,1
			};
			//Debug.Log("Room Type Two Right Air Zero was chosen.");
			break;
		case 1:
			tileBlockArray = new int[]
			{
				111,4,0,2,7,
				0,1,115,1,1
			};
			//Debug.Log("Room Type Two Right Air One was chosen.");
			break;
		case 2:
			tileBlockArray = new int[]
			{
				1,0,0,0,1,
				665,2,1,1,668,
			};
			//Debug.Log("Room Type Two Right Air Two was chosen.");
			break;
		case 3:
			tileBlockArray = new int[]
			{
				0,2,2,2,2,
				0,0,0,0,0
			};
			//Debug.Log("Room Type Two Right Air Three was chosen.");
			break;
		case 4:
			tileBlockArray = new int[]
			{
				0,1,1,2,2,
				0,115,8,0,0,
			};
			//Debug.Log("Room Type Two Right Air Four was chosen.");
			break;
		case 5:
			tileBlockArray = new int[]
			{
				7,0,1,2,0,
				1,2,8,0,0,
			};
			//Debug.Log("Room Type Two Right Air Five was chosen.");
			break;
		case 6:
			tileBlockArray = new int[]
			{
				0,0,0,0,0,
				15,1,1,1,16,
			};
			//Debug.Log("Room Type Two Right Air Six was chosen.");
			break;
		case 7:
			tileBlockArray = new int[]
			{
				15,1,2,1,16,
				0,0,0,0,0,
			};
			//Debug.Log("Room Type Two Right Air Seven was chosen.");
			break;
		case 8:
			tileBlockArray = new int[]
			{
				0,1,1,1,0,
				0,0,1,0,0,
			};
			//Debug.Log("Room Type Two Right Air Eight was chosen.");
			break;
		case 9:
			tileBlockArray = new int[]
			{
				1,0,0,0,41,
				1,1,1,0,0,
			};
			//Debug.Log("Room Type Two Right Air Nine was chosen.");
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
			//Debug.Log (telaOut.gameObject.name);
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
			//istantiates block
			int randomSolid = Random.Range (0,6);
			GameObject hiddenRoom = Instantiate(tileOfRoom[randomSolid], roomTilePosition, Quaternion.identity) as GameObject;
			//set tile to empty layer
			hiddenRoom.layer = 15;
			//set new alpha value for tile
			Color hidden = hiddenRoom.GetComponent<SpriteRenderer>().color;
			float alphaH = 0.45f;
			hidden.a = alphaH;
			hiddenRoom.GetComponent<SpriteRenderer>().color = hidden;
			//move the x position ahead by one
			tilePosition.x += 1.0f;
			transform.position = tilePosition;
		}
		else if(tileBlockArray[iLoop] == 66)
		{
			//istantiates block then moves the x position ahead by one
			GameObject BG = Instantiate(tileOfRoom[22], tilePosition, Quaternion.identity) as GameObject;
			BG.gameObject.tag = "BadGuy";
			Vector3 fluffybg = BG.transform.position;
			fluffybg.z = 1.0f;
			BG.transform.position = fluffybg;
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
			GameObject BGV = Instantiate(tileOfRoom[33], tilePosition, Quaternion.identity) as GameObject;
			BGV.gameObject.tag = "BadGuyVert";
			Vector3 fluffybgv = BGV.transform.position;
			fluffybgv.z = 0.0f;
			BGV.transform.position = fluffybgv;
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
