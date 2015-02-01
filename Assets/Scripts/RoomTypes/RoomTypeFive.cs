using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RoomTypeFive : MonoBehaviour {
	
	//set up room 
	public GameObject[] tileOfRoom;
	public Vector3 startingPosition5;
	private Vector3 roomTilePosition;
	private List<int> lineBreaks = new List<int>(new int[] {10,20,30,40,50,60,70});
	
	public int[] typeFiveArray;
	
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
	public void BeginRoom5() 
	{
		Debug.Log ("This is the starting position for RoomType5 "+startingPosition5);
		ChooseRoomTypeFiveTemplate();
		CheckForObstacleBlocks();
		telaportNumeric +=1;
	}
	
	private void LoopThroughTypeFiveArray ()
	{
		for (int i = 0; i < typeFiveArray.Length; i++)
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
		startObstacleXposition = 0.0f;
		startObstacleYposition = 0.0f;
	}
	
	private void ChooseRoomTypeFiveTemplate ()
	{
		RoomTypeFivePositionInitalize();
		//picks a random number correlated to a Type 5 template
		int temp = Random.Range(0,15);
		
		switch (temp)
		{
		case 0:
			typeFiveArray = new int[] 
			{
				0,0,1,1,0,0,1,1,1,1,
				0,2,1,2,0,0,1,668,0,1,
				0,1,1,1,0,0,665,0,0,1,
				0,0,1,1,0,0,0,0,0,8,
				0,0,0,0,0,0,0,0,0,0,
				0,2,0,0,0,0,0,0,0,0,
				3,1,1,0,3,7,0,0,0,0,
				1,7,7,1,1,1,7,1,1,1
			};
			Debug.Log("Room Type Five Zero was chosen.");
			break;
		case 1:
			typeFiveArray = new int[]
			{
				0,1,1,1,0,0,0,0,0,1,
				0,1,13,10,0,0,1,1,0,1,
				0,12,0,0,0,0,0,1,0,1,
				0,1,1,141,0,0,0,1,0,9,
				0,9,11,0,0,0,0,1,0,1,
				1,1,1,1,1,668,0,1,0,1,
				1,50,111,50,50,11,0,3,0,1,
				1,1,1,1,1,1,1,141,11,1
			};
			Debug.Log("Room Type Five One was chosen.");
			break;
		case 2:
			typeFiveArray = new int[]
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
			Debug.Log("Room Type Five Two was chosen.");
			break;
		case 3:
			typeFiveArray = new int[]
			{
				0,0,0,0,0,0,0,0,1,1,
				0,10,0,0,0,0,0,0,11,0,
				0,2,1,4,0,0,0,0,1,1,
				0,1,1,1,0,0,0,0,0,11,
				0,0,0,0,0,3,0,0,0,0,
				0,1,0,2,0,1,7,1,0,0,
				7,1,1,7,7,1,1,1,7,1,
				1,1,1,1,1,1,11,1,1,1
			};
			Debug.Log("Room Type Five Three was chosen.");
			break;
		case 4:
			typeFiveArray = new int[] 
			{
				0,0,0,0,0,0,0,0,0,0,
				0,0,0,0,0,0,0,0,0,0,
				0,0,1,1,1,1,1,1,1,0,
				0,0,0,0,9,0,8,0,1,0,
				0,0,0,1,1,0,0,0,9,0,
				0,0,1,10,0,0,0,1,1,0,
				10,1,1,0,0,0,1,11,1,3,
				1,1,1,1,1,1,1,1,1,1
			};
			Debug.Log("Room Type Five Four was chosen.");
			break;
		case 5:
			typeFiveArray = new int[] 
			{
				0,0,0,0,0,0,0,0,0,0,
				0,1,2,1,0,0,2,1,11,1,
				0,8,0,8,0,0,0,665,8,8,
				0,0,0,0,0,0,0,0,0,0,
				0,0,0,0,0,0,0,0,0,0,
				0,0,0,1,0,0,0,0,0,0,
				1,0,0,1,1,0,96,0,0,1,
				1,1,1,1,1,0,21,1,11,11
				
			};
			Debug.Log("Room Type Five Five was chosen.");
			break;
		case 6:
			typeFiveArray = new int[] 
			{
				0,0,0,0,0,0,0,0,0,0,
				0,0,0,0,0,0,0,0,0,0,
				0,0,0,0,0,0,0,96,0,0,
				1,1,1,0,0,0,1,1,1,1,
				0,0,0,0,0,0,0,0,0,0,
				0,0,0,0,0,0,0,0,0,0,
				0,66,0,0,3,0,0,0,0,0,
				11,1,1,1,1,1,1,1,1,11
				
			};
			Debug.Log("Room Type Five Six was chosen.");
			break;
		case 7:
			typeFiveArray = new int[] 
			{
				0,0,0,0,0,0,1,0,0,0,
				0,0,10,0,0,0,1,0,0,0,
				0,0,0,0,0,0,1,0,10,0,
				0,0,0,0,0,0,1,0,21,0,
				1,0,0,0,0,0,0,0,0,0,
				1,0,0,0,0,0,0,0,0,0,
				1,0,0,664,0,0,0,0,0,0,
				1,1,1,1,1,1,1,1,1,1
				
			};
			Debug.Log("Room Type Five Seven was chosen.");
			break;
		case 8:
			typeFiveArray = new int[] 
			{
				0,0,0,0,0,0,0,0,0,0,
				0,0,0,1,1,1,1,1,0,0,
				0,0,0,0,0,0,0,1,0,0,
				0,0,0,0,1,0,111,1,0,0,
				0,0,0,1,1,1,1,1,0,0,
				0,0,0,0,0,1,1,1,0,0,
				7,0,0,1,0,11,11,0,3,1,
				1,1,1,1,1,1,1,1,1,1
				
			};
			Debug.Log("Room Type Five Eight was chosen.");
			break;
		case 9:
			typeFiveArray = new int[] 
			{
				0,0,0,0,0,0,0,1,1,1,
				0,0,0,0,0,0,0,0,1,1,
				1,1,1,0,0,1,1,1,0,1,
				0,0,1,1,1,1,0,0,0,0,
				0,0,0,0,0,0,0,0,0,0,
				11,1,1,111,12,0,1,1,1,1,
				0,0,1,1,1,1,1,0,0,0,
				0,0,1,1,1,1,1,0,0,0
				
			};
			Debug.Log("Room Type Five Nine was chosen.");
			break;
		case 10:
			typeFiveArray = new int[] 
			{
				0,0,0,0,0,100,0,0,0,0,
				0,0,1,1,9,1,1,1,0,0,
				0,1,100,0,0,0,0,100,1,0,
				0,9,0,0,0,0,0,0,1,0,
				0,1,0,0,0,0,661,0,1,0,
				0,1,0,0,0,0,0,0,1,0,
				0,9,0,3,0,0,0,0,9,0,
				0,21,1,1,1,1,1,1,1,1
				
			};
			//Debug.Log("Room Type Five Ten was chosen.");
			break;
		case 11:
			typeFiveArray = new int[] 
			{
				0,6,0,0,0,0,0,0,0,0,
				0,0,0,0,0,0,0,0,0,0,
				0,0,0,0,0,0,0,0,0,0,
				0,0,0,0,0,0,0,0,0,0,
				0,0,0,0,0,0,0,0,0,0,
				0,0,0,0,0,0,0,0,0,0,
				1,97,0,97,0,97,0,97,0,1,
				1,1,1,1,1,11,1,1,1,1
				
			};
			Debug.Log("Room Type Five Eleven was chosen.");
			break;
		case 12:
			typeFiveArray = new int[] 
			{
				0,0,0,0,0,0,0,0,0,0,
				0,1,0,0,99,0,0,0,0,0,
				0,1,0,0,0,0,0,0,0,0,
				0,1,3,0,0,0,0,0,0,0,
				3,1,1,0,0,0,0,0,661,0,
				1,0,66,0,0,0,0,0,0,0,
				1,1,1,1,1,1,1,1,0,1,
				0,0,0,0,0,0,0,0,1,0
				
			};
			Debug.Log("Room Type Five Twelve was chosen.");
			break;
		case 13:
			typeFiveArray = new int[] 
			{
				0,0,0,0,0,0,0,0,1,1,
				0,0,0,0,0,41,0,0,0,1,
				1,1,1,1,1,11,1,1,0,1,
				1,0,0,0,0,0,0,4,0,1,
				1,1,1,1,1,0,1,1,1,1,
				0,0,0,0,17,0,0,0,0,0,
				12,12,12,12,1,1,12,12,18,0,
				1,1,1,1,1,1,1,1,1,11
				
			};
			//Debug.Log("Room Type Five Thirteen was chosen.");
			break;
		case 14:
			typeFiveArray = new int[] 
			{
				0,0,0,0,0,0,0,0,0,0,
				0,0,0,0,0,0,0,0,0,0,
				1,0,0,0,2,0,0,0,1,0,
				0,1,0,0,0,0,0,1,0,0,
				0,0,0,0,0,0,0,0,0,0,
				0,0,0,0,0,0,0,0,0,0,
				0,0,0,0,0,0,0,0,0,0,
				0,0,0,0,0,0,0,0,0,0
				
			};
			Debug.Log("Room Type Five Fourteen was chosen.");
			break;
		}
		//calls the function to loop through the created array
		LoopThroughTypeFiveArray ();
	}
	
	private void RoomTypeFivePositionInitalize()
	{
		//sets the starting x position of the room
		roomTilePosition.x = startingPosition5.x;
		//sets the starting y position of the room
		roomTilePosition.y = startingPosition5.y;
		//sets the starting z position of the room
		roomTilePosition.z = 0;
		transform.position = roomTilePosition;
		//Debug.Log("Room Type Zero initalized");
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
			roomTilePosition.x = startingPosition5.x;
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
		if(typeFiveArray[arrayNum] == 0)
		{
			Instantiate(tileOfRoom[12], roomTilePosition, Quaternion.identity);
			roomTilePosition.x += 1.0f;
			transform.position = roomTilePosition;
		}
		else if(typeFiveArray[arrayNum] == 1)
		{
			//istantiates block then moves the x position ahead by one
			int randomSolid = Random.Range (0,6);
			Instantiate(tileOfRoom[randomSolid], roomTilePosition, Quaternion.identity);
			roomTilePosition.x += 1.0f;
			transform.position = roomTilePosition;
		}
		else if(typeFiveArray[arrayNum] == 2)
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
		else if(typeFiveArray[arrayNum] == 3)
		{
			//istantiates block then moves the x position ahead by one
			Instantiate(tileOfRoom[6], roomTilePosition, Quaternion.identity);
			roomTilePosition.x += 1.0f;
			transform.position = roomTilePosition;
		}
		else if(typeFiveArray[arrayNum] == 4)
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
		else if(typeFiveArray[arrayNum] == 5)
		{
			if(groundBlock1 == Vector3.zero)
			{
				groundBlock1 = roomTilePosition;
				Debug.Log("Room Type Five Ground Block 1 initialized at: "+groundBlock1);
			}
			else
			{
				groundBlock2 = roomTilePosition;
				Debug.Log("Room Type Five Ground Block 2 initialized at: "+groundBlock2);
			}
			
			Instantiate(tileOfRoom[12], roomTilePosition, Quaternion.identity);
			roomTilePosition.x += 1.0f;
			transform.position = roomTilePosition;
		}
		else if(typeFiveArray[arrayNum] == 6)
		{
			if(airBlock1 == Vector3.zero)
			{
				airBlock1 = roomTilePosition;
				Debug.Log("Room Type Five Air Block 1 initialized at: "+airBlock1);
			}
			else
			{
				airBlock2 = roomTilePosition;
				Debug.Log("Room Type Two Five Block 2 initialized at: "+airBlock2);
			}
			
			Instantiate(tileOfRoom[12], roomTilePosition, Quaternion.identity);
			roomTilePosition.x += 1.0f;
			transform.position = roomTilePosition;
		}
		else if(typeFiveArray[arrayNum] == 7)
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
		else if(typeFiveArray[arrayNum] == 8)
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
		else if(typeFiveArray[arrayNum] == 9)
		{
			Instantiate(tileOfRoom[10], roomTilePosition, Quaternion.identity);
			roomTilePosition.x += 1.0f;
			transform.position = roomTilePosition;
		}
		else if(typeFiveArray[arrayNum] == 10)
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
		else if(typeFiveArray[arrayNum] == 11)
		{
			//istantiates block then moves the x position ahead by one
			Instantiate(tileOfRoom[14], roomTilePosition, Quaternion.identity);
			roomTilePosition.x += 1.0f;
			transform.position = roomTilePosition;
		}
		else if(typeFiveArray[arrayNum] == 12)
		{
			//istantiates block then moves the x position ahead by one
			Instantiate(tileOfRoom[8], roomTilePosition, Quaternion.identity);
			roomTilePosition.x += 1.0f;
			transform.position = roomTilePosition;
		}
		else if(typeFiveArray[arrayNum] == 13)
		{
			//istantiates block then moves the x position ahead by one
			Instantiate(tileOfRoom[9], roomTilePosition, Quaternion.identity);
			roomTilePosition.x += 1.0f;
			transform.position = roomTilePosition;
		}
		else if(typeFiveArray[arrayNum] == 14)
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
		else if(typeFiveArray[arrayNum] == 15)
		{
			//istantiates block then moves the x position ahead by one
			Instantiate(tileOfRoom[24], roomTilePosition, Quaternion.identity);
			roomTilePosition.x += 1.0f;
			transform.position = roomTilePosition;
		}
		else if(typeFiveArray[arrayNum] == 16)
		{
			//istantiates block then moves the x position ahead by one
			Instantiate(tileOfRoom[25], roomTilePosition, Quaternion.identity);
			roomTilePosition.x += 1.0f;
			transform.position = roomTilePosition;
		}
		else if(typeFiveArray[arrayNum] == 17)
		{
			//istantiates block then moves the x position ahead by one
			GameObject telaIn = Instantiate(tileOfRoom[26], roomTilePosition, Quaternion.identity) as GameObject;
			telaInStringName = telaportNumeric.ToString();
			telaIn.gameObject.name = telaInStringName;
			roomTilePosition.x += 1.0f;
			transform.position = roomTilePosition;
		}
		else if(typeFiveArray[arrayNum] == 18)
		{
			//istantiates block then moves the x position ahead by one
			GameObject telaOut = Instantiate(tileOfRoom[27], roomTilePosition, Quaternion.identity) as GameObject;
			telaOutStringName = ("telaOut"+telaportNumeric);
			telaOut.gameObject.name = telaOutStringName;
			//Debug.Log (telaOut.gameObject.name);
			roomTilePosition.x += 1.0f;
			transform.position = roomTilePosition;
		}
		else if(typeFiveArray[arrayNum] == 20)
		{
			//istantiates block then moves the x position ahead by one
			Instantiate(tileOfRoom[21], roomTilePosition, Quaternion.identity);
			roomTilePosition.x += 1.0f;
			transform.position = roomTilePosition;
		}
		else if(typeFiveArray[arrayNum] == 21)
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
		else if(typeFiveArray[arrayNum] == 33)
		{
			//istantiates block then moves the x position ahead by one
			Instantiate(tileOfRoom[15], roomTilePosition, Quaternion.identity);
			roomTilePosition.x += 1.0f;
			transform.position = roomTilePosition;
		}
		else if (typeFiveArray[arrayNum] == 41)
		{
			Instantiate(tileOfRoom[7], roomTilePosition, Quaternion.identity);
			roomTilePosition.x += 1.0f;
			transform.position = roomTilePosition;
		}
		else if(typeFiveArray[arrayNum] == 50)
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
		else if(typeFiveArray[arrayNum] == 66)
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
		else if(typeFiveArray[arrayNum] == 76)
		{
			Instantiate(tileOfRoom[28], roomTilePosition, Quaternion.identity);
			roomTilePosition.x += 1.0f;
			transform.position = roomTilePosition;
		}
		else if(typeFiveArray[arrayNum] == 86)
		{
			Instantiate(tileOfRoom[29], roomTilePosition, Quaternion.identity);
			roomTilePosition.x += 1.0f;
			transform.position = roomTilePosition;
		}
		else if(typeFiveArray[arrayNum] == 96)
		{
			GameObject SB = Instantiate(tileOfRoom[30], roomTilePosition, Quaternion.identity) as GameObject;
			SB.gameObject.name = "ShaddowBounce";
			roomTilePosition.x += 1.0f;
			transform.position = roomTilePosition;
		}
		else if(typeFiveArray[arrayNum] == 97)
		{
			GameObject SB = Instantiate(tileOfRoom[30], roomTilePosition, Quaternion.identity) as GameObject;
			SB.gameObject.name = "ShaddowForward";
			roomTilePosition.x += 1.0f;
			transform.position = roomTilePosition;
		}
		else if(typeFiveArray[arrayNum] == 99)
		{
			Instantiate(tileOfRoom[23], roomTilePosition, Quaternion.identity);
			roomTilePosition.x += 1.0f;
			transform.position = roomTilePosition;
		}
		else if(typeFiveArray[arrayNum] == 100)
		{
			Instantiate(tileOfRoom[11], roomTilePosition, Quaternion.identity);
			roomTilePosition.x += 1.0f;
			transform.position = roomTilePosition;
		}
		else if(typeFiveArray[arrayNum] == 111)
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
		else if(typeFiveArray[arrayNum] == 141)
		{
			//istantiates block then moves the x position ahead by one
			Instantiate(tileOfRoom[19], roomTilePosition, Quaternion.identity);
			roomTilePosition.x += 1.0f;
			transform.position = roomTilePosition;
		}
		else if(typeFiveArray[arrayNum] == 142)
		{
			//istantiates block then moves the x position ahead by one
			Instantiate(tileOfRoom[20], roomTilePosition, Quaternion.identity);
			roomTilePosition.x += 1.0f;
			transform.position = roomTilePosition;
		}
		else if(typeFiveArray[arrayNum] == 320)
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
		else if(typeFiveArray[arrayNum] == 360)
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
		else if(typeFiveArray[arrayNum] == 661)
		{
			//istantiates block then moves the x position ahead by one
			GameObject BGV = Instantiate(tileOfRoom[33], roomTilePosition, Quaternion.identity) as GameObject;
			BGV.gameObject.tag = "BadGuyVert";
			Vector3 fluffybgv = BGV.transform.position;
			fluffybgv.z = -5.0f;
			BGV.transform.position = fluffybgv;
			roomTilePosition.x += 1.0f;
			transform.position = roomTilePosition;
		}
		else if(typeFiveArray[arrayNum] == 664)
		{
			GameObject spks = Instantiate(tileOfRoom[28], roomTilePosition, Quaternion.identity) as GameObject;
			spks.gameObject.tag = "spike";
			roomTilePosition.x += 1.0f;
			transform.position = roomTilePosition;
		}
		else if(typeFiveArray[arrayNum] == 665)
		{
			GameObject spks = Instantiate(tileOfRoom[29], roomTilePosition, Quaternion.identity) as GameObject;
			spks.gameObject.tag = "topspike";
			roomTilePosition.x += 1.0f;
			transform.position = roomTilePosition;
		}
		else if(typeFiveArray[arrayNum] == 666)
		{
			//istantiates block then moves the x position ahead by one
			Instantiate(tileOfRoom[22], roomTilePosition, Quaternion.identity);
			roomTilePosition.x += 1.0f;
			transform.position = roomTilePosition;
		}
		else if(typeFiveArray[arrayNum] == 667)
		{
			GameObject spks = Instantiate(tileOfRoom[31], roomTilePosition, Quaternion.identity) as GameObject;
			spks.gameObject.tag = "leftspike";
			roomTilePosition.x += 1.0f;
			transform.position = roomTilePosition;
		}
		else if(typeFiveArray[arrayNum] == 668)
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
			ChooseAirTemplate();
		}
		if(airBlock2 != Vector3.zero)
		{
			AirBlockPositionInitalize2(airBlock2);
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
				0,1,1,1,2
			};
			//Debug.Log("Room Type Five Ground Zero was chosen.");
			break;
		case 1:
			tileBlockArray = new int[]
			{
				0,0,0,0,0,
				4,0,2,7,0,
				1,1,2,1,0
			};
			//Debug.Log("Room Type Five Ground One was chosen.");
			break;
		case 2:
			tileBlockArray = new int[]
			{
				0,0,0,0,0,
				0,2,2,4,2,
				0,21,2,1,11
			};
			//Debug.Log("Room Type Five Ground Two was chosen.");
			break;
		case 3:
			tileBlockArray = new int[]
			{
				1,1,1,0,1,
				0,15,1,7,0,
				1,1,1,1,1
			};
			//Debug.Log("Room Type Five Ground Three was chosen.");
			break;
		case 4:
			tileBlockArray = new int[]
			{
				11,0,0,11,0,
				0,1,1,0,21,
				0,1,1,1,1
			};
			//Debug.Log("Room Type Five Ground Four was chosen.");
			break;
		case 5:
			tileBlockArray = new int[]
			{
				0,4,4,4,2,
				4,1,0,21,0,
				1,2,4,1,1
			};
			//Debug.Log("Room Type Five Ground Five was chosen.");
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
		//Debug.Log("Room Type Five Ground tileBlock initalized");
	}
	private void GroundBlockPositionInitalize2(Vector3 groundblockstart)
	{
		tilePosition = groundblockstart;
		transform.position = tilePosition;
		//sets the starting x position of the obstacle block
		startObstacleXposition = groundblockstart.x;
		//sets the starting y position of the obstacle block
		startObstacleYposition = groundblockstart.y;
		//Debug.Log("Room Type Five Ground tileBlock initalized");
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
		//Debug.Log("Room Type Five Air tileBlock initalized");
	}
	private void AirBlockPositionInitalize2(Vector3 airblockstart)
	{
		tilePosition = airblockstart;
		transform.position = tilePosition;
		//sets the starting x position of the obstacle block
		startObstacleXposition = airblockstart.x;
		//sets the starting y position of the obstacle block
		startObstacleYposition = airblockstart.y;
		//Debug.Log("Room Type Five Air tileBlock initalized");
	}
	//picks an air template at random
	public void ChooseAirTemplate ()
	{
		//picks a random number correlated to a tileBlockArray
		int temp = Random.Range(0, 11);
		
		switch (temp)
		{
		case 0:
			tileBlockArray = new int[] 
			{
				142,1,7,1,0,
				0,0,1,1,0
			};
			//Debug.Log("Room Type Five Air Zero was chosen.");
			break;
		case 1:
			tileBlockArray = new int[]
			{
				0,1,4,2,0,
				0,0,0,21,2
			};
			//Debug.Log("Room Type Five Air One was chosen.");
			break;
		case 2:
			tileBlockArray = new int[]
			{
				0,0,0,7,7,
				0,1,1,0,21
			};
			//Debug.Log("Room Type Five Air Two was chosen.");
			break;
		case 3:
			tileBlockArray = new int[]
			{
				0,3,0,11,4,
				1,1,0,0,0
			};
			//Debug.Log("Room Type Five Air Three was chosen.");
			break;
		case 4:
			tileBlockArray = new int[]
			{
				0,0,0,0,99,
				1,0,21,141,0
			};
			//Debug.Log("Room Type Five Air Four was chosen.");
			break;
		case 5:
			tileBlockArray = new int[]
			{
				1,2,11,0,0,
				2,142,11,141,11
			};
			//Debug.Log("Room Type Five Air Five was chosen.");
			break;
		case 6:
			tileBlockArray = new int[]
			{
				0,0,0,1,0,
				1,1,0,1,1,
			};
			//Debug.Log("Room Type Five Air Six was chosen.");
			break;
		case 7:
			tileBlockArray = new int[]
			{
				0,664,0,0,1,
				0,1,0,0,665,
			};
			//Debug.Log("Room Type Five Air Seven was chosen.");
			break;
		case 8:
			tileBlockArray = new int[]
			{
				1,1,1,16,0,
				0,0,0,0,4,
			};
			//Debug.Log("Room Type Five Air Eight was chosen.");
			break;
		case 9:
			tileBlockArray = new int[]
			{
				0,4,41,0,0,
				1,1,1,0,0,
			};
			//Debug.Log("Room Type Five Air Nine was chosen.");
			break;
		case 10:
			tileBlockArray = new int[]
			{
				2,2,20,2,2,
				2,2,1,2,2,
			};
			//Debug.Log("Room Type Five Air Ten was chosen.");
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
			GameObject BGV = Instantiate(tileOfRoom[33], tilePosition, Quaternion.identity) as GameObject;
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