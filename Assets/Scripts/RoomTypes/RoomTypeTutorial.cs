using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RoomTypeTutorial : MonoBehaviour {
	
	//set up room 
	public GameObject[] tileOfRoom;
	public Vector3 startingPositionT;
	private int roomStep = 0;

	private Vector3 roomTilePosition;
	private List<int> lineBreaks = new List<int>(new int[] {10,20,30,40,50,60,70});

	public int[] typeTutorialArray;
	
	private int telaportNumeric = 0;
	private string telaInStringName;
	private string telaOutStringName;

	//set up obstacle blocks
	private Vector3 tilePosition;
	private float startObstacleXposition;
	private float startObstacleYposition;
	private int[] tileBlockArray;
	private Vector3 groundBlock1;
	private Vector3 groundBlock2;
	private Vector3 airBlock1;
	private Vector3 airBlock2;
	
	// Use this for initialization
	public void BeginRoomTutorial() 
	{
		Debug.Log ("This is the starting position for RoomTypeTutorial "+startingPositionT);
		ChooseRoomTypeTutorialTemplate();
		CheckForObstacleBlocks();
		RoomStepUp();
		telaportNumeric +=1;
	}
	
	private void LoopThroughTypeTutorialArray ()
	{
		for (int i = 0; i < typeTutorialArray.Length; i++)
		{
			CheckYPosition(i);
		}
	}

	private void RoomStepUp ()
	{
		if(roomStep<16)
		{
			roomStep+=1;
			//Debug.Log ("roomStep is now set to: " + roomStep);
		}
	}
	
	private void ChooseRoomTypeTutorialTemplate ()
	{
		RoomTypeTutorialPositionInitalize();

		switch (roomStep)
		{
		case 0:
			typeTutorialArray = new int[] 
			{
				0,0,12,0,0,0,0,0,0,0,
				0,0,1,16,0,0,0,0,0,0,
				1,0,1,0,0,0,1,1,3,1,
				1,0,0,21,1,0,1,1,1,13,
				1,0,0,0,0,0,0,0,0,0,
				1,0,0,0,0,0,0,0,0,0,
				0,0,41,0,0,3,0,0,0,3,
				1,1,1,12,12,1,1,1,1,1
			};
			//Debug.Log("Room Type Tutorial Zero was chosen.");
			break;
		case 1:
			typeTutorialArray = new int[] 
			{
				0,0,0,0,0,0,0,0,0,0,
				0,0,0,0,0,0,0,0,100,0,
				1,0,0,0,0,0,0,0,0,0,
				1,0,0,0,0,0,0,0,0,0,
				1,0,0,0,0,0,0,0,0,0,
				1,0,0,0,0,0,0,0,0,1,
				1,0,0,1,0,3,0,0,0,0,
				1,1,0,21,1,1,12,1,12,1
			};
			//Debug.Log("Room Type Tutorial One was chosen.");
			break;
		case 2:
			typeTutorialArray = new int[] 
			{
				13,0,0,0,0,0,1,0,0,15,
				12,0,0,0,0,0,13,0,0,15,
				1,0,0,0,0,0,0,0,0,0,
				1,0,0,0,0,0,0,0,0,0,
				9,0,1,0,0,0,1,0,0,0,
				1,1,1,12,3,0,1,0,0,0,
				1,1,1,1,1,1,1,1,1,0,
				1,0,21,0,0,0,0,1,0,0
			};
			//Debug.Log("Room Type Tutorial Two was chosen.");
			break;
		case 3:
			typeTutorialArray = new int[] 
			{
				1,0,0,0,0,0,0,0,0,0,
				1,99,0,0,0,12,12,0,0,0,
				1,1,1,0,0,1,1,3,0,0,
				1,13,0,0,0,1,1,1,9,1,
				1,41,0,0,0,0,0,0,0,0,
				1,0,0,0,0,0,0,0,0,0,
				1,3,0,0,0,0,12,12,3,0,
				1,1,1,1,1,1,1,1,1,9
			};
			//Debug.Log("Room Type Tutorial Three was chosen.");
			break;
		case 4:
			typeTutorialArray = new int[] 
			{
				0,1,0,665,0,0,0,0,0,0,
				0,0,0,0,0,0,0,0,0,0,
				0,0,0,0,0,0,0,0,0,0,
				0,0,0,0,0,0,0,0,0,0,
				0,0,0,0,0,0,0,0,0,0,
				0,0,0,0,0,0,0,0,0,0,
				0,0,0,0,0,0,0,664,0,0,
				0,0,1,1,1,1,1,1,1,1
			};
			//Debug.Log("Room Type Tutorial Four was chosen.");
			break;
		case 5:
			typeTutorialArray = new int[] 
			{
				1,0,0,1,13,0,0,0,1,1,
				1,0,0,1,0,0,0,0,11,0,
				0,0,18,1,17,0,0,0,11,0,
				0,0,1,1,1,0,0,1,1,3,
				1,0,0,0,0,0,0,0,1,1,
				1,0,0,0,0,1,1,0,15,1,
				1,3,0,0,0,0,0,0,0,1,
				1,1,1,12,12,12,12,0,0,1
			};
			//Debug.Log("Room Type Tutorial Five was chosen.");
			break;
		case 6:
			typeTutorialArray = new int[] 
			{
				0,0,41,0,0,0,0,0,0,0,
				20,1,1,0,0,0,0,20,20,0,
				0,1,0,1,12,12,1,1,0,0,
				0,0,0,0,1,1,0,0,0,0,
				0,12,0,0,0,0,0,0,0,0,
				141,1,12,0,0,0,0,1,0,0,
				1,0,21,12,0,12,1,1,3,0,
				1,1,1,1,3,1,1,1,1,1
			};
			//Debug.Log("Room Type Tutorial Six was chosen.");
			break;
		case 7:
			typeTutorialArray = new int[] 
			{
				11,0,0,0,0,0,0,0,0,0,
				11,0,0,0,0,0,0,0,0,3,
				1,1,0,0,0,100,0,0,15,1,
				1,0,0,0,0,0,12,0,0,0,
				1,0,0,0,12,0,1,0,0,0,
				1,12,0,0,1,0,1,0,0,0,
				1,1,12,3,1,3,1,3,0,0,
				1,1,1,1,1,1,1,1,1,1
			};
			//Debug.Log("Room Type Tutorial Seven was chosen.");
			break;
		case 8:
			typeTutorialArray = new int[] 
			{
				0,0,0,0,13,1,0,0,0,0,
				0,41,0,0,0,1,0,0,0,0,
				142,1,0,0,0,0,0,0,0,0,
				0,0,0,0,0,0,0,0,0,0,
				0,0,0,0,0,0,1,0,0,1,
				0,0,0,0,0,0,1,0,0,0,
				12,12,12,0,3,0,0,0,1,0,
				1,1,1,1,1,0,0,0,0,0
			};
			//Debug.Log("Room Type Tutorial Eight was chosen.");
			break;
		case 9:
			typeTutorialArray = new int[] 
			{
				1,0,0,0,0,0,0,1,1,1,
				1,15,1,0,0,0,0,0,0,0,
				1,0,0,0,0,1,0,0,0,0,
				0,0,0,0,0,0,0,0,0,1,
				1,1,16,0,0,1,1,0,0,1,
				15,0,0,0,0,0,0,0,0,0,
				15,0,0,0,0,0,0,0,66,0,
				15,1,1,1,0,21,1,1,1,1
			};
			//Debug.Log("Room Type Tutorial Nine was chosen.");
			break;
		case 10:
			typeTutorialArray = new int[] 
			{
				0,0,0,0,0,0,0,0,0,0,
				0,0,0,0,0,0,0,0,0,0,
				0,0,661,0,0,0,0,0,0,0,
				0,0,0,0,0,661,0,0,0,0,
				0,0,0,0,0,0,0,0,0,0,
				1,0,0,0,12,0,1,661,1,0,
				0,1,0,0,1,0,1,0,1,0,
				1,1,1,1,1,1,1,1,0,21
			};
			//Debug.Log("Room Type Tutorial Ten was chosen.");
			break;
		case 11:
			typeTutorialArray = new int[] 
			{
				1,0,0,0,0,0,0,0,0,0,
				1,0,100,0,0,0,0,66,0,1,
				1,0,0,1,1,1,1,1,0,0,
				1,0,0,0,0,0,0,0,0,0,
				1,0,0,0,1,1,1,0,0,1,
				0,0,1,1,0,0,0,1,1,1,
				0,0,0,0,0,12,0,0,0,0,
				1,1,1,1,1,1,1,1,9,1
			};
			//Debug.Log("Room Type Tutorial Eleven was chosen.");
			break;
		case 12:
			typeTutorialArray = new int[] 
			{
				0,0,0,0,0,0,0,0,0,0,
				0,0,41,41,41,0,0,12,0,0,
				0,1,1,1,1,0,0,1,0,0,
				0,0,0,0,0,1,0,1,1,9,
				0,0,0,0,0,0,0,1,0,0,
				0,0,0,0,0,0,0,1,100,0,
				0,0,0,0,0,0,0,1,0,0,
				12,12,1,0,41,1,41,1,1,0
			};
			//Debug.Log("Room Type Tutorial Twelve was chosen.");
			break;
		case 13:
			typeTutorialArray = new int[] 
			{
				0,1,0,0,0,0,0,0,0,0,
				0,1,0,0,0,0,0,0,0,0,
				100,1,0,0,0,21,0,0,0,0,
				1,1,0,0,13,0,0,0,0,0,
				0,1,0,0,0,0,0,0,0,0,
				41,9,0,0,0,33,0,0,0,0,
				0,1,0,0,0,0,21,16,0,0,
				1,1,1,1,1,1,1,1,1,1
			};
			//Debug.Log("Room Type Tutorial Thirteen was chosen.");
			break;
		case 14:
			typeTutorialArray = new int[] 
			{
				1,0,0,0,0,0,0,0,0,1,
				1,0,0,0,41,41,0,0,20,1,
				1,0,0,0,0,21,0,0,0,1,
				1,0,0,0,0,0,0,0,0,13,
				1,0,0,0,0,0,0,0,0,0,
				11,0,0,0,0,0,0,0,0,0,
				11,0,0,41,41,0,0,0,3,0,
				1,12,12,1,1,1,12,12,1,1
			};
			//Debug.Log("Room Type Tutorial Fourteen was chosen.");
			break;
		case 15:
			typeTutorialArray = new int[] 
			{
				0,0,0,0,0,0,0,0,0,0,
				0,0,0,0,0,0,0,0,21,0,
				0,0,0,21,0,0,0,0,0,0,
				0,0,0,0,1,3,0,0,0,0,
				0,0,0,0,1,0,21,0,0,0,
				0,1,0,0,0,0,0,0,0,0,
				0,0,0,0,0,0,0,0,0,0,
				1,12,12,12,12,12,12,12,1,1  
			};
			//Debug.Log("Room Type Tutorial Fifteen was chosen.");
			break;
		}
		//calls the function to loop through the created array
		LoopThroughTypeTutorialArray ();
	}
	
	private void RoomTypeTutorialPositionInitalize()
	{
		//sets the starting x position of the room
		roomTilePosition.x = startingPositionT.x;
		//sets the starting y position of the room
		roomTilePosition.y = startingPositionT.y;
		//sets the starting z position of the room
		roomTilePosition.z = 0;
		transform.position = roomTilePosition;
		//Debug.Log("Room Type Tutorial initalized");
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
			roomTilePosition.x = startingPositionT.x;
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
		if(typeTutorialArray[arrayNum] == 0)
		{
			Instantiate(tileOfRoom[12], roomTilePosition, Quaternion.identity);
			roomTilePosition.x += 1.0f;
			transform.position = roomTilePosition;
		}
		else if(typeTutorialArray[arrayNum] == 1)
		{
			//istantiates block then moves the x position ahead by one
			int randomSolid = Random.Range (0,6);
			Instantiate(tileOfRoom[randomSolid], roomTilePosition, Quaternion.identity);
			roomTilePosition.x += 1.0f;
			transform.position = roomTilePosition;
		}
		else if(typeTutorialArray[arrayNum] == 2)
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
		else if(typeTutorialArray[arrayNum] == 3)
		{
			//istantiates block then moves the x position ahead by one
			Instantiate(tileOfRoom[6], roomTilePosition, Quaternion.identity);
			roomTilePosition.x += 1.0f;
			transform.position = roomTilePosition;
		}
		else if(typeTutorialArray[arrayNum] == 4)
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
		else if(typeTutorialArray[arrayNum] == 5)
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
		else if(typeTutorialArray[arrayNum] == 6)
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
		else if(typeTutorialArray[arrayNum] == 7)
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
		else if(typeTutorialArray[arrayNum] == 8)
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
		else if(typeTutorialArray[arrayNum] == 9)
		{
			Instantiate(tileOfRoom[10], roomTilePosition, Quaternion.identity);
			roomTilePosition.x += 1.0f;
			transform.position = roomTilePosition;
		}
		else if(typeTutorialArray[arrayNum] == 10)
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
		else if(typeTutorialArray[arrayNum] == 11)
		{
			//istantiates block then moves the x position ahead by one
			Instantiate(tileOfRoom[14], roomTilePosition, Quaternion.identity);
			roomTilePosition.x += 1.0f;
			transform.position = roomTilePosition;
		}
		else if(typeTutorialArray[arrayNum] == 12)
		{
			//istantiates block then moves the x position ahead by one
			Instantiate(tileOfRoom[8], roomTilePosition, Quaternion.identity);
			roomTilePosition.x += 1.0f;
			transform.position = roomTilePosition;
		}
		else if(typeTutorialArray[arrayNum] == 13)
		{
			//istantiates block then moves the x position ahead by one
			Instantiate(tileOfRoom[9], roomTilePosition, Quaternion.identity);
			roomTilePosition.x += 1.0f;
			transform.position = roomTilePosition;
		}
		else if(typeTutorialArray[arrayNum] == 14)
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
		else if(typeTutorialArray[arrayNum] == 15)
		{
			//istantiates block then moves the x position ahead by one
			Instantiate(tileOfRoom[24], roomTilePosition, Quaternion.identity);
			roomTilePosition.x += 1.0f;
			transform.position = roomTilePosition;
		}
		else if(typeTutorialArray[arrayNum] == 16)
		{
			//istantiates block then moves the x position ahead by one
			Instantiate(tileOfRoom[25], roomTilePosition, Quaternion.identity);
			roomTilePosition.x += 1.0f;
			transform.position = roomTilePosition;
		}
		else if(typeTutorialArray[arrayNum] == 17)
		{
			//istantiates block then moves the x position ahead by one
			GameObject telaIn = Instantiate(tileOfRoom[26], roomTilePosition, Quaternion.identity) as GameObject;
			telaInStringName = telaportNumeric.ToString();
			telaIn.gameObject.name = telaInStringName;
			roomTilePosition.x += 1.0f;
			transform.position = roomTilePosition;
		}
		else if(typeTutorialArray[arrayNum] == 18)
		{
			//istantiates block then moves the x position ahead by one
			GameObject telaOut = Instantiate(tileOfRoom[27], roomTilePosition, Quaternion.identity) as GameObject;
			telaOutStringName = ("telaOut"+telaportNumeric);
			telaOut.gameObject.name = telaOutStringName;
			//Debug.Log (telaOut.gameObject.name);
			roomTilePosition.x += 1.0f;
			transform.position = roomTilePosition;
		}
		else if(typeTutorialArray[arrayNum] == 20)
		{
			//istantiates block then moves the x position ahead by one
			Instantiate(tileOfRoom[21], roomTilePosition, Quaternion.identity);
			roomTilePosition.x += 1.0f;
			transform.position = roomTilePosition;
		}
		else if(typeTutorialArray[arrayNum] == 21)
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
		else if(typeTutorialArray[arrayNum] == 33)
		{
			//istantiates block then moves the x position ahead by one
			Instantiate(tileOfRoom[15], roomTilePosition, Quaternion.identity);
			roomTilePosition.x += 1.0f;
			transform.position = roomTilePosition;
		}
		else if (typeTutorialArray[arrayNum] == 41)
		{
			Instantiate(tileOfRoom[7], roomTilePosition, Quaternion.identity);
			roomTilePosition.x += 1.0f;
			transform.position = roomTilePosition;
		}
		else if(typeTutorialArray[arrayNum] == 50)
		{
			//istantiates block then moves the x position ahead by one
			int randomSolid = Random.Range (0,6);
			GameObject hiddenRoom = Instantiate(tileOfRoom[randomSolid], roomTilePosition, Quaternion.identity) as GameObject;
			hiddenRoom.layer = 15;
			roomTilePosition.x += 1.0f;
			transform.position = roomTilePosition;
		}
		else if(typeTutorialArray[arrayNum] == 66)
		{
			//istantiates block then moves the x position ahead by one
			GameObject BG = Instantiate(tileOfRoom[22], roomTilePosition, Quaternion.identity) as GameObject;
			BG.gameObject.tag = "BadGuy";
			Vector3 fluffybg = BG.transform.position;
			fluffybg.z = -5.0f;
			BG.transform.position = fluffybg;
			roomTilePosition.x += 1.0f;
			transform.position = roomTilePosition;
		}
		else if(typeTutorialArray[arrayNum] == 76)
		{
			Instantiate(tileOfRoom[28], roomTilePosition, Quaternion.identity);
			roomTilePosition.x += 1.0f;
			transform.position = roomTilePosition;
		}
		else if(typeTutorialArray[arrayNum] == 86)
		{
			Instantiate(tileOfRoom[29], roomTilePosition, Quaternion.identity);
			roomTilePosition.x += 1.0f;
			transform.position = roomTilePosition;
		}
		else if(typeTutorialArray[arrayNum] == 96)
		{
			GameObject SB = Instantiate(tileOfRoom[30], roomTilePosition, Quaternion.identity) as GameObject;
			SB.gameObject.name = "ShaddowBounce";
			roomTilePosition.x += 1.0f;
			transform.position = roomTilePosition;
		}
		else if(typeTutorialArray[arrayNum] == 97)
		{
			GameObject SB = Instantiate(tileOfRoom[30], roomTilePosition, Quaternion.identity) as GameObject;
			SB.gameObject.name = "ShaddowForward";
			roomTilePosition.x += 1.0f;
			transform.position = roomTilePosition;
		}
		else if(typeTutorialArray[arrayNum] == 99)
		{
			Instantiate(tileOfRoom[23], roomTilePosition, Quaternion.identity);
			roomTilePosition.x += 1.0f;
			transform.position = roomTilePosition;
		}
		else if(typeTutorialArray[arrayNum] == 100)
		{
			Instantiate(tileOfRoom[11], roomTilePosition, Quaternion.identity);
			roomTilePosition.x += 1.0f;
			transform.position = roomTilePosition;
		}
		else if(typeTutorialArray[arrayNum] == 111)
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
		else if(typeTutorialArray[arrayNum] == 141)
		{
			//istantiates block then moves the x position ahead by one
			Instantiate(tileOfRoom[19], roomTilePosition, Quaternion.identity);
			roomTilePosition.x += 1.0f;
			transform.position = roomTilePosition;
		}
		else if(typeTutorialArray[arrayNum] == 142)
		{
			//istantiates block then moves the x position ahead by one
			Instantiate(tileOfRoom[20], roomTilePosition, Quaternion.identity);
			roomTilePosition.x += 1.0f;
			transform.position = roomTilePosition;
		}
		else if(typeTutorialArray[arrayNum] == 320)
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
		else if(typeTutorialArray[arrayNum] == 360)
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
		else if(typeTutorialArray[arrayNum] == 661)
		{
			//istantiates block then moves the x position ahead by one
			GameObject BGV = Instantiate(tileOfRoom[22], roomTilePosition, Quaternion.identity) as GameObject;
			BGV.gameObject.tag = "BadGuyVert";
			Vector3 fluffybgv = BGV.transform.position;
			fluffybgv.z = -5.0f;
			BGV.transform.position = fluffybgv;
			roomTilePosition.x += 1.0f;
			transform.position = roomTilePosition;
		}
		else if(typeTutorialArray[arrayNum] == 664)
		{
			GameObject spks = Instantiate(tileOfRoom[28], roomTilePosition, Quaternion.identity) as GameObject;
			spks.gameObject.tag = "spike";
			roomTilePosition.x += 1.0f;
			transform.position = roomTilePosition;
		}
		else if(typeTutorialArray[arrayNum] == 665)
		{
			GameObject spks = Instantiate(tileOfRoom[29], roomTilePosition, Quaternion.identity) as GameObject;
			spks.gameObject.tag = "topspike";
			roomTilePosition.x += 1.0f;
			transform.position = roomTilePosition;
		}
		else if(typeTutorialArray[arrayNum] == 666)
		{
			//istantiates block then moves the x position ahead by one
			Instantiate(tileOfRoom[22], roomTilePosition, Quaternion.identity);
			roomTilePosition.x += 1.0f;
			transform.position = roomTilePosition;
		}
		else if(typeTutorialArray[arrayNum] == 667)
		{
			GameObject spks = Instantiate(tileOfRoom[31], roomTilePosition, Quaternion.identity) as GameObject;
			spks.gameObject.tag = "leftspike";
			roomTilePosition.x += 1.0f;
			transform.position = roomTilePosition;
		}
		else if(typeTutorialArray[arrayNum] == 668)
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
		if(airBlock1 != Vector3.zero)
		{
			AirBlockPositionInitalize(airBlock1);
			ChooseAirTemplate();
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
				2,2,2,2,7,
				0,0,0,0,1,
				0,7,1,1,2
			};
			//Debug.Log("Room Type Tutorial Ground Zero was chosen.");
			break;
		case 1:
			tileBlockArray = new int[]
			{
				0,0,14,0,0,
				0,4,2,7,0,
				0,1,2,1,0
			};
			//Debug.Log("Room Type Tutorial Ground One was chosen.");
			break;
		case 2:
			tileBlockArray = new int[]
			{
				0,0,0,0,0,
				0,2,2,4,2,
				8,8,2,2,11
			};
			//Debug.Log("Room Type Tutorial Ground Two was chosen.");
			break;
		case 3:
			tileBlockArray = new int[]
			{
				1,1,1,11,1,
				0,8,8,7,0,
				0,0,0,1,0
			};
			//Debug.Log("Room Type Tutorial Ground Three was chosen.");
			break;
		case 4:
			tileBlockArray = new int[]
			{
				11,0,0,11,0,
				0,1,1,2,0,
				0,8,8,1,4
			};
			//Debug.Log("Room Type Tutorial Ground Four was chosen.");
			break;
		case 5:
			tileBlockArray = new int[]
			{
				0,14,14,14,2,
				4,2,2,2,0,
				1,2,4,1,14
			};
			//Debug.Log("Room Type Tutorial Ground Five was chosen.");
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
		//Debug.Log("Room Type Tutorial Ground tileBlock initalized");
	}
	
	//sets the postion of the air obstacle block
	private void AirBlockPositionInitalize(Vector3 airblockstart)
	{
		tilePosition = airblockstart;
		transform.position = tilePosition;
		//sets the starting x position of the obstacle block
		startObstacleXposition = airblockstart.x;
		//sets the starting y position of the obstacle block
		startObstacleYposition = airblockstart.y;
		//Debug.Log("Room Type Tutorial Air tileBlock initalized");
	}
	
	//picks an air template at random
	public void ChooseAirTemplate ()
	{
		//picks a random number correlated to a tileBlockArray
		int temp = Random.Range(0, 6);
		
		switch (temp)
		{
		case 0:
			tileBlockArray = new int[] 
			{
				2,2,2,2,2,
				0,2,8,2,0
			};
			//Debug.Log("Room Type Tutorial Air Zero was chosen.");
			break;
		case 1:
			tileBlockArray = new int[]
			{
				2,1,4,2,0,
				0,2,1,14,2
			};
			//Debug.Log("Room Type Tutorial Air One was chosen.");
			break;
		case 2:
			tileBlockArray = new int[]
			{
				0,0,0,7,7,
				0,1,1,1,1
			};
			//Debug.Log("Room Type Tutorial Air Two was chosen.");
			break;
		case 3:
			tileBlockArray = new int[]
			{
				0,3,0,11,4,
				1,1,11,11,2
			};
			//Debug.Log("Room Type Tutorial Air Three was chosen.");
			break;
		case 4:
			tileBlockArray = new int[]
			{
				0,2,0,0,142,
				0,141,0,0,2
			};
			//Debug.Log("Room Type Tutorial Air Three was chosen.");
			break;
		case 5:
			tileBlockArray = new int[]
			{
				0,0,21,320,
				21,0,21
			};
			//Debug.Log("Room Type Tutorial Air Three was chosen.");
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
			Vector3 fluffybg = BG.transform.position;
			fluffybg.z = -5.0f;
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
			GameObject BGV = Instantiate(tileOfRoom[22], tilePosition, Quaternion.identity) as GameObject;
			BGV.gameObject.tag = "BadGuyVert";
			Vector3 fluffybgv = BGV.transform.position;
			fluffybgv.z = -5.0f;
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