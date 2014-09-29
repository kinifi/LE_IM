using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RoomTypeZero : MonoBehaviour {
	
	//Set up room 
	public GameObject[] tileOfRoom;
	public Vector3 startingPosition0;
	private Vector3 roomTilePosition;
	private List<int> lineBreaks = new List<int>(new int[] {10,20,30,40,50,60,70});

	public int[] typeZeroArray;

	//Set up telaport naming increments
	private int telaportNumeric = 0;
	private string telaInStringName;
	private string telaOutStringName;
	
	//Set up obstacle blocks
	private Vector3 tilePosition;
	private float startObstacleXposition;
	private float startObstacleYposition;
	private int[] tileBlockArray;
	private Vector3 groundBlock1 = Vector3.zero;
	private Vector3 groundBlock2 = Vector3.zero;
	private Vector3 airBlock1 = Vector3.zero;
	private Vector3 airBlock2 = Vector3.zero;
	
	// Functions needed to create the Room.
	public void BeginRoom0() 
	{
		Debug.Log ("This is the starting position for RoomType0 "+startingPosition0);
		ChooseRoomTypeZeroTemplate();
		CheckForObstacleBlocks();
		ResetTheRoom();
	}
	//Loops through the randomly choosen Array
	private void LoopThroughTypeZeroArray ()
	{
		for (int i = 0; i < typeZeroArray.Length; i++)
		{
			CheckYPosition(i);
		}
	}
	//Increments the telaport and resets block values
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

	//Gets the starting position and ranomly selects a room array
	private void ChooseRoomTypeZeroTemplate ()
	{
		RoomTypeZeroPositionInitalize();
		//Picks a random number correlated to a Type 0 template
		int temp = Random.Range(0,11);
		
		switch (temp)
		{
		case 0:
			typeZeroArray = new int[] 
			{
				0,0,0,21,0,1,1,13,0,0,
				0,5,0,0,0,0,13,0,2,0,
				0,0,0,0,0,0,0,0,0,0,
				0,0,0,0,0,0,0,0,0,2,
				0,0,20,0,0,0,0,0,0,0,
				0,0,0,0,0,3,0,0,0,0,
				0,1,1,11,1,1,2,0,0,0,
				0,0,0,0,0,0,0,11,11,0
			};
			//Debug.Log("Room Type Zero Zero was chosen.");
			break;
		case 1:
			typeZeroArray = new int[]
			{
				0,0,0,0,0,0,0,0,0,0,
				0,0,2,0,0,0,0,7,2,0,
				96,0,21,0,0,0,1,1,1,1,
				2,2,0,0,0,2,0,0,0,0,
				0,0,5,0,0,0,0,0,0,0,
				0,0,0,0,0,0,0,0,661,0,
				111,0,0,0,0,0,111,0,0,0,
				1,1,11,142,11,11,141,1,1,1
			};
			//Debug.Log("Room Type Zero One was chosen.");
			break;
		case 2:
			typeZeroArray = new int[]
			{
				0,2,1,1,1,1,1,1,0,0,
				0,0,8,8,8,8,8,8,0,0,
				0,0,0,0,0,0,0,0,0,0,
				0,0,0,21,0,0,0,0,0,0,
				1,0,0,0,0,0,0,21,0,0,
				1,0,0,0,0,0,0,0,0,0,
				1,3,360,0,0,0,320,0,111,0,
				1,1,11,0,0,0,1,1,142,11
			};
			//Debug.Log("Room Type Zero Two was chosen.");
			break;
		case 3:
			typeZeroArray = new int[]
			{
				0,0,0,0,0,0,0,0,0,0,
				0,0,1,1,1,1,2,1,1,1,
				0,111,0,0,0,0,0,0,0,0,
				1,1,1,1,0,0,2,1,4,1,
				1,0,0,0,0,0,0,8,0,0,
				1,2,1,320,0,0,0,661,0,0,
				1,1,1,4,1,0,0,0,0,0,
				1,1,2,1,141,11,11,0,0,0
			};
			//Debug.Log("Room Type Zero Three was chosen.");
			break;
		case 4:
			typeZeroArray = new int[] 
			{
				142,11,141,2,1,1,11,1,1,2,
				1,0,2,1,1,1,1,11,1,1,
				1,11,1,2,2,8,2,2,11,8,
				8,1,8,1,2,0,0,0,8,0,
				0,8,0,0,0,0,0,0,0,0,
				661,0,0,0,2,0,0,0,0,0,
				111,0,320,2,1,2,20,0,4,0,
				1,1,1,1,1,1,11,11,142,1
			};
			//Debug.Log("Room Type Zero Four was chosen.");
			break;
		case 5:
			typeZeroArray = new int[] 
			{
				1,0,21,1,11,2,2,0,21,0,
				0,6,0,0,0,0,0,0,0,0,
				0,0,0,0,0,0,0,0,0,0,
				0,0,0,2,2,0,0,41,7,0,
				11,0,0,0,0,1,1,1,1,1,
				2,0,0,0,0,0,0,0,0,0,
				11,111,0,0,0,0,0,0,0,0,
				11,1,11,11,0,0,0,0,2,0
			};
			//Debug.Log("Room Type Zero Five was chosen.");
			break;
		case 6:
			int randomHidden = Random.Range (0,10);
			if(randomHidden == 0)
			{
				typeZeroArray = new int[] 
				{
					0,0,0,0,0,0,0,0,0,0,
					0,0,50,50,0,21,0,0,0,
					50,50,50,50,50,50,50,0,0,0,
					50,50,50,50,10,50,50,0,0,0,
					50,50,50,50,10,50,50,0,0,0,
					50,50,50,50,3,10,50,50,0,0,
					0,0,50,1,1,1,1,1,50,0,
					0,0,0,0,0,0,0,0,0,0
				};
				//Debug.Log("Room Type Zero Six-Key was chosen.");
			}
			else if(randomHidden == 1)
			{
				typeZeroArray = new int[] 
				{
					0,0,0,0,0,0,0,0,0,0,
					0,2,50,0,21,11,0,0,0,
					0,50,50,50,1,50,0,21,0,
					0,50,50,50,661,50,50,50,0,0,
					0,50,50,50,0,50,50,50,0,0,
					0,50,50,50,3,0,50,50,0,0,
					2,1,50,1,1,1,1,1,50,0,
					0,2,0,0,0,2,0,0,0,0
				};
				//Debug.Log("Room Type Zero Six-BadGuy was chosen.");
			}
			else if(randomHidden == 2)
			{
				typeZeroArray = new int[] 
				{
					0,0,0,0,0,0,0,0,0,0,
					0,2,50,0,21,11,0,0,0,
					0,50,50,50,50,50,0,21,0,
					0,50,50,50,111,50,50,50,0,0,
					0,50,50,50,111,50,50,50,0,0,
					0,50,50,50,3,111,50,50,0,0,
					2,1,50,1,1,1,1,1,50,0,
					0,2,0,0,0,2,0,0,0,0
				};
				//Debug.Log("Room Type Zero Six-Bow was chosen.");
			}
			else if(randomHidden == 3 || randomHidden == 4)
			{
				typeZeroArray = new int[] 
				{
					6,0,0,0,0,0,0,0,0,0,
					0,0,0,0,0,0,0,0,0,0,
					0,0,0,0,0,6,0,0,0,0,
					6,0,0,0,0,0,0,0,0,0,
					0,0,0,0,0,0,0,0,0,0,
					0,0,5,0,0,0,0,0,0,0,
					0,0,0,0,0,0,0,0,0,0,
					20,0,0,0,0,0,0,0,0,0
				};
				//Debug.Log("Room Type Zero Six-34 was chosen.");
			}
			else if(randomHidden == 5 || randomHidden == 6 || randomHidden == 7)
			{
				typeZeroArray = new int[] 
				{
					0,0,0,0,0,13,1,16,0,0,
					0,2,2,2,0,0,0,320,0,0,
					0,2,8,2,0,0,21,0,0,0,
					0,0,0,0,0,0,0,0,0,0,
					0,21,0,0,0,21,0,0,0,0,
					0,0,0,0,0,0,7,111,0,0,
					0,0,0,1,11,141,1,0,0,0,
					9,0,1,1,0,21,0,1,10,1
				};
				//Debug.Log("Room Type Zero Six-567 was chosen.");
			}
			else if(randomHidden == 8 || randomHidden == 9)
			{
				typeZeroArray = new int[] 
				{
					6,0,0,0,0,0,0,0,0,0,
					0,0,0,0,0,2,0,0,0,1,
					6,0,0,0,0,0,0,0,0,0,
					0,0,0,0,0,0,0,0,2,1,
					6,0,0,0,0,0,10,0,0,0,
					0,0,0,0,0,0,0,0,0,0,
					6,0,0,0,0,0,360,0,0,0,
					0,0,0,0,0,0,1,0,111,0
				};
				//Debug.Log("Room Type Zero Six-89 was chosen.");
			}
			//Debug.Log("Room Type Zero Six was chosen.");
			break;
		case 7:
			typeZeroArray = new int[] 
			{
				0,0,0,0,0,0,0,0,0,0,
				0,1,1,97,0,0,0,0,0,0,
				0,0,1,1,1,1,0,0,1,1,
				0,0,0,0,0,0,0,0,0,0,
				1,668,0,0,0,0,0,0,0,2,
				0,0,0,0,0,7,0,0,21,0,
				111,0,7,0,1,0,0,0,0,0,
				1,1,1,1,1,1,1,1,1,1
			};
			//Debug.Log("Room Type Zero Seven was chosen.");
			break;
		case 8:
			typeZeroArray = new int[] 
			{
				6,0,0,0,0,0,0,0,0,0,
				0,0,0,0,0,0,0,0,0,0,
				0,0,0,0,0,0,0,0,1,1,
				0,0,0,0,0,0,0,0,0,0,
				1,66,0,0,0,0,0,0,0,1,
				0,0,0,0,0,6,0,0,0,0,
				0,0,0,0,0,0,0,0,0,0,
				1,0,0,0,1,1,0,1,0,1
			};
			//Debug.Log("Room Type Zero Eight was chosen.");
			break;
		case 9:
			typeZeroArray = new int[] 
			{
				0,0,0,0,0,0,0,0,0,0,
				0,0,0,0,0,0,0,0,0,0,
				0,96,0,0,0,0,0,0,1,1,
				1,1,1,0,0,0,0,0,0,0,
				0,0,0,5,0,0,0,0,0,1,
				0,0,0,0,0,0,0,0,0,0,
				1,668,0,0,0,0,0,0,0,0,
				1,0,0,0,0,0,0,1,0,1
			};
			//Debug.Log("Room Type Zero Nine was chosen.");
			break;
		case 10:
			typeZeroArray = new int[] 
			{
				6,0,0,0,0,6,0,0,0,0,
				0,0,0,0,0,0,0,0,0,0,
				1,16,0,0,0,661,0,0,0,0,
				0,0,0,0,0,0,0,0,0,0,
				5,0,0,0,0,5,0,0,0,0,
				0,0,0,0,0,0,0,0,0,0,
				0,0,0,0,0,0,0,0,0,0,
				1,1,1,1,1,1,1,1,1,1
			};
			//Debug.Log("Room Type Zero Ten was chosen.");
			break;
		}
		//Calls the function to loop through the created array
		LoopThroughTypeZeroArray ();
	}
	
	private void RoomTypeZeroPositionInitalize()
	{
		//Sets the starting x position of the room
		roomTilePosition.x = startingPosition0.x;
		//Sets the starting y position of the room
		roomTilePosition.y = startingPosition0.y;
		//Sets the starting z position of the room
		roomTilePosition.z = 0;
		transform.position = roomTilePosition;
		//Debug.Log("Room Type Zero initalized");
	}
	
	
	//Determines which row the tile is in and sets its position accordingly
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
	
	//Determines which column the tile is in and sets its postion accordingly
	private void CheckXPosition (int x)
	{
		if(lineBreaks.Contains(x))
		{
			//Resets the x position to the starting x position of room
			roomTilePosition.x = startingPosition0.x;
			transform.position = roomTilePosition;
			RoomTileInstantiate(x);
		}
		else
		{
			RoomTileInstantiate(x);
		}
	}
	
	//Instantiates tile at appropriate position and moves the postion ahead
	private void RoomTileInstantiate(int arrayNum)
	{
		if(typeZeroArray[arrayNum] == 0)
		{
			//Instantiates empty block then moves the x position ahead by one
			Instantiate(tileOfRoom[12], roomTilePosition, Quaternion.identity);
			roomTilePosition.x += 1.0f;
			transform.position = roomTilePosition;
		}
		else if(typeZeroArray[arrayNum] == 1)
		{
			//Picks a random solid block texture
			int randomSolid = Random.Range (0,6);
			//Instantiates solid block then moves the x position ahead by one
			Instantiate(tileOfRoom[randomSolid], roomTilePosition, Quaternion.identity);
			roomTilePosition.x += 1.0f;
			transform.position = roomTilePosition;
		}
		else if(typeZeroArray[arrayNum] == 2)
		{
			//50% chance the solid block will be instantiated
			int rand50 = Random.Range(1,3);
			if(rand50 == 1)
			{
				//Picks a random solid block texture
				int randomSolid50 = Random.Range (0,6);
				//Instantiates solid block then moves the x position ahead by one
				Instantiate(tileOfRoom[randomSolid50], roomTilePosition, Quaternion.identity);
				roomTilePosition.x += 1.0f;
				transform.position = roomTilePosition;
				
			}
			else
			{
				//Instantiates empty block then moves the x position ahead by one
				Instantiate(tileOfRoom[12], roomTilePosition, Quaternion.identity);
				roomTilePosition.x += 1.0f;
				transform.position = roomTilePosition;
			}
		}
		else if(typeZeroArray[arrayNum] == 3)
		{
			//Instantiates spring block then moves the x position ahead by one
			Instantiate(tileOfRoom[6], roomTilePosition, Quaternion.identity);
			roomTilePosition.x += 1.0f;
			transform.position = roomTilePosition;
		}
		else if(typeZeroArray[arrayNum] == 4)
		{
			//50% chance the push block will be instantiated
			int rand50 = Random.Range (0,2);
			if(rand50 == 1)
			{
				//Instantiates push block then moves the x position ahead by one
				Instantiate(tileOfRoom[7], roomTilePosition, Quaternion.identity);
				roomTilePosition.x += 1.0f;
				transform.position = roomTilePosition;
			}
			else
			{
				//Instantiates empty block then moves the x position ahead by one
				Instantiate(tileOfRoom[12], roomTilePosition, Quaternion.identity);
				roomTilePosition.x += 1.0f;
				transform.position = roomTilePosition;
			}
		}
		else if(typeZeroArray[arrayNum] == 5)
		{
			//Saves the position for the ground block(s)
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

			//Instantiates empty block then moves the x position ahead by one
			Instantiate(tileOfRoom[12], roomTilePosition, Quaternion.identity);
			roomTilePosition.x += 1.0f;
			transform.position = roomTilePosition;
		}
		else if(typeZeroArray[arrayNum] == 6)
		{
			//Saves the position for the air block(s)
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

			//Instantiates empty block then moves the x position ahead by one
			Instantiate(tileOfRoom[12], roomTilePosition, Quaternion.identity);
			roomTilePosition.x += 1.0f;
			transform.position = roomTilePosition;
		}
		else if(typeZeroArray[arrayNum] == 7)
		{
			//33% chance a spike will be instantiated
			int rand33 = Random.Range(1,4);
			//Instantiates spike block then moves the x position ahead by one
			if(rand33 == 1)
			{
				Instantiate(tileOfRoom[8], roomTilePosition, Quaternion.identity);
				roomTilePosition.x += 1.0f;
				transform.position = roomTilePosition;
			}
			//Instantiates empty block then moves the x position ahead by one
			else
			{
				Instantiate(tileOfRoom[12], roomTilePosition, Quaternion.identity);
				roomTilePosition.x += 1.0f;
				transform.position = roomTilePosition;
			}
		}
		else if(typeZeroArray[arrayNum] == 8)
		{
			//33% chance a top spike will be instantiated
			int rand33 = Random.Range(1,4);
			//Instantiates top spike block then moves the x position ahead by one
			if(rand33 == 1)
			{
				Instantiate(tileOfRoom[9], roomTilePosition, Quaternion.identity);
				roomTilePosition.x += 1.0f;
				transform.position = roomTilePosition;
				
			}
			//Instantiates empty block then moves the x position ahead by one
			else
			{
				Instantiate(tileOfRoom[12], roomTilePosition, Quaternion.identity);
				roomTilePosition.x += 1.0f;
				transform.position = roomTilePosition;
			}
		}
		else if(typeZeroArray[arrayNum] == 9)
		{
			//Instantiates door block then moves the x position ahead by one
			Instantiate(tileOfRoom[10], roomTilePosition, Quaternion.identity);
			roomTilePosition.x += 1.0f;
			transform.position = roomTilePosition;
		}
		else if(typeZeroArray[arrayNum] == 10)
		{
			//50% chance a key will be instantiated
			int rand50 = Random.Range(0,4);
			//Instantiates key block (+1 key) then moves the x position ahead by one
			if(rand50 != 1)
			{
				Instantiate(tileOfRoom[11], roomTilePosition, Quaternion.identity);
				roomTilePosition.x += 1.0f;
				transform.position = roomTilePosition;
			}
			//Instantiates empty block then moves the x position ahead by one
			else
			{
				Instantiate(tileOfRoom[12], roomTilePosition, Quaternion.identity);
				roomTilePosition.x += 1.0f;
				transform.position = roomTilePosition;
			}
		}
		else if(typeZeroArray[arrayNum] == 11)
		{
			//Instantiates breakable block then moves the x position ahead by one
			Instantiate(tileOfRoom[14], roomTilePosition, Quaternion.identity);
			roomTilePosition.x += 1.0f;
			transform.position = roomTilePosition;
		}
		else if(typeZeroArray[arrayNum] == 12)
		{
			//Instantiates spike block then moves the x position ahead by one
			Instantiate(tileOfRoom[8], roomTilePosition, Quaternion.identity);
			roomTilePosition.x += 1.0f;
			transform.position = roomTilePosition;
		}
		else if(typeZeroArray[arrayNum] == 13)
		{
			//Instantiates top spike block then moves the x position ahead by one
			Instantiate(tileOfRoom[9], roomTilePosition, Quaternion.identity);
			roomTilePosition.x += 1.0f;
			transform.position = roomTilePosition;
		}
		else if(typeZeroArray[arrayNum] == 14)
		{
			//25% chance a pushblock will be instantiated
			int rand25 = Random.Range(0,4);
			//Instantiates push block then moves the x position ahead by one
			if(rand25 == 1)
			{
				Instantiate(tileOfRoom[13], roomTilePosition, Quaternion.identity);
				roomTilePosition.x += 1.0f;
				transform.position = roomTilePosition;
			}
			//Instantiates empty block then moves the x position ahead by one
			else
			{
				Instantiate(tileOfRoom[12], roomTilePosition, Quaternion.identity);
				roomTilePosition.x += 1.0f;
				transform.position = roomTilePosition;
			}
		}
		else if(typeZeroArray[arrayNum] == 15)
		{
			//Instantiates spikeleft block then moves the x position ahead by one
			Instantiate(tileOfRoom[24], roomTilePosition, Quaternion.identity);
			roomTilePosition.x += 1.0f;
			transform.position = roomTilePosition;
		}
		else if(typeZeroArray[arrayNum] == 16)
		{
			//Instantiates spikeright block then moves the x position ahead by one
			Instantiate(tileOfRoom[25], roomTilePosition, Quaternion.identity);
			roomTilePosition.x += 1.0f;
			transform.position = roomTilePosition;
		}
		else if(typeZeroArray[arrayNum] == 17)
		{
			//Instantiates teleport-in block, sets name, then moves the x position ahead by one
			GameObject telaIn = Instantiate(tileOfRoom[26], roomTilePosition, Quaternion.identity) as GameObject;
			telaInStringName = telaportNumeric.ToString();
			telaIn.gameObject.name = telaInStringName;
			roomTilePosition.x += 1.0f;
			transform.position = roomTilePosition;
		}
		else if(typeZeroArray[arrayNum] == 18)
		{
			//Instantiates teleport-out block, sets name, then moves the x position ahead by one
			GameObject telaOut = Instantiate(tileOfRoom[27], roomTilePosition, Quaternion.identity) as GameObject;
			telaOutStringName = ("telaOut"+telaportNumeric);
			telaOut.gameObject.name = telaOutStringName;
			//Debug.Log (telaOut.gameObject.name);
			roomTilePosition.x += 1.0f;
			transform.position = roomTilePosition;
		}
		else if(typeZeroArray[arrayNum] == 20)
		{
			//Instantiates bow block (+1 arrow) then moves the x position ahead by one
			Instantiate(tileOfRoom[21], roomTilePosition, Quaternion.identity);
			roomTilePosition.x += 1.0f;
			transform.position = roomTilePosition;
		}
		else if(typeZeroArray[arrayNum] == 21)
		{
			//Corrects the position to account for 2x1 block.
			Vector3 correctedPosition = roomTilePosition + new Vector3(0.5f, 0.0f, 0.0f);
			//Randomly selects one of three 2x1 block textures
			int rand13 = Random.Range(1,4);
			//Instantiates 2x1 block then moves the x position ahead by one
			if(rand13 == 1)
			{
				Instantiate(tileOfRoom[16], correctedPosition, Quaternion.identity);
				roomTilePosition.x += 1.0f;
				transform.position = roomTilePosition;
			}
			else if(rand13 == 2)
			{
				Instantiate(tileOfRoom[17], correctedPosition, Quaternion.identity);
				roomTilePosition.x += 1.0f;
				transform.position = roomTilePosition;
			}
			else if(rand13 == 3)
			{
				Instantiate(tileOfRoom[18], correctedPosition, Quaternion.identity);
				roomTilePosition.x += 1.0f;
				transform.position = roomTilePosition;
			}
		}
		else if(typeZeroArray[arrayNum] == 33)
		{
			//Instantiates EXIT block then moves the x position ahead by one
			Instantiate(tileOfRoom[15], roomTilePosition, Quaternion.identity);
			roomTilePosition.x += 1.0f;
			transform.position = roomTilePosition;
		}
		else if (typeZeroArray[arrayNum] == 41)
		{
			//Instantiates push block then moves the x position ahead by one
			Instantiate(tileOfRoom[7], roomTilePosition, Quaternion.identity);
			roomTilePosition.x += 1.0f;
			transform.position = roomTilePosition;
		}
		else if(typeZeroArray[arrayNum] == 50)
		{
			//Selects one of six solid block textures
			int randomSolid = Random.Range (0,6);
			//Instantiates hidden block, moves to HiddenBlock Layer, then moves the x position ahead by one
			GameObject hiddenRoom = Instantiate(tileOfRoom[randomSolid], roomTilePosition, Quaternion.identity) as GameObject;
			hiddenRoom.layer = 15;
			roomTilePosition.x += 1.0f;
			transform.position = roomTilePosition;
		}
		else if(typeZeroArray[arrayNum] == 66)
		{
			//Instantiates Bad Guy block (moves horizontal), sets tag, then moves the x position ahead by one
			GameObject BG = Instantiate(tileOfRoom[22], roomTilePosition, Quaternion.identity) as GameObject;
			BG.gameObject.tag = "BadGuy";
			roomTilePosition.x += 1.0f;
			transform.position = roomTilePosition;
		}
		else if(typeZeroArray[arrayNum] == 96)
		{
			//Instantiates shaddow block (bounces), sets name, then moves the x position ahead by one
			GameObject SB = Instantiate(tileOfRoom[30], roomTilePosition, Quaternion.identity) as GameObject;
			SB.gameObject.name = "ShaddowBounce";
			roomTilePosition.x += 1.0f;
			transform.position = roomTilePosition;
		}
		else if(typeZeroArray[arrayNum] == 97)
		{
			//Instantiates shaddow block (moves forward), sets name, then moves the x position ahead by one
			GameObject SB = Instantiate(tileOfRoom[30], roomTilePosition, Quaternion.identity) as GameObject;
			SB.gameObject.name = "ShaddowForward";
			roomTilePosition.x += 1.0f;
			transform.position = roomTilePosition;
		}
		else if(typeZeroArray[arrayNum] == 99)
		{
			//Instantiates golden bow block (+5 arrows) then moves the x position ahead by one
			Instantiate(tileOfRoom[23], roomTilePosition, Quaternion.identity);
			roomTilePosition.x += 1.0f;
			transform.position = roomTilePosition;
		}
		else if(typeZeroArray[arrayNum] == 100)
		{
			//Instantiates key block (+1 key) then moves the x position ahead by one
			Instantiate(tileOfRoom[11], roomTilePosition, Quaternion.identity);
			roomTilePosition.x += 1.0f;
			transform.position = roomTilePosition;
		}
		else if(typeZeroArray[arrayNum] == 111)
		{
			//33% chance the bow block will be instantiated
			int rand33 = Random.Range(1,4);
			//Instantiates bow block (+1 arrow) then moves the x position ahead by one
			if(rand33 == 1)
			{
				Instantiate(tileOfRoom[21], roomTilePosition, Quaternion.identity);
				roomTilePosition.x += 1.0f;
				transform.position = roomTilePosition;
				
			}
			//Instantiates empty block then moves the x position ahead by one
			else
			{
				Instantiate(tileOfRoom[12], roomTilePosition, Quaternion.identity);
				roomTilePosition.x += 1.0f;
				transform.position = roomTilePosition;
			}
		}
		else if(typeZeroArray[arrayNum] == 141)
		{
			//Instantiates breakableTR block then moves the x position ahead by one
			Instantiate(tileOfRoom[19], roomTilePosition, Quaternion.identity);
			roomTilePosition.x += 1.0f;
			transform.position = roomTilePosition;
		}
		else if(typeZeroArray[arrayNum] == 142)
		{
			//Instantiates breakableBL block then moves the x position ahead by one
			Instantiate(tileOfRoom[20], roomTilePosition, Quaternion.identity);
			roomTilePosition.x += 1.0f;
			transform.position = roomTilePosition;
		}
		else if(typeZeroArray[arrayNum] == 320)
		{
			//20% chance the spring block will be instantiated
			int rand20 = Random.Range(0,5);
			if(rand20 == 0)
			{
				//Instantiates spring block then moves the x position ahead by one
				Instantiate(tileOfRoom[6], roomTilePosition, Quaternion.identity);
				roomTilePosition.x += 1.0f;
				transform.position = roomTilePosition;
			}
			else
			{
				//Instantiates empty block then moves the x position ahead by one
				Instantiate(tileOfRoom[12], roomTilePosition, Quaternion.identity);
				roomTilePosition.x += 1.0f;
				transform.position = roomTilePosition;
			}
		}
		else if(typeZeroArray[arrayNum] == 360)
		{
			//Aprox. 60% chance the spring block will be instantiated
			int rand60 = Random.Range(0,3);
			if(rand60 != 0)
			{
				//Instantiates spring block then moves the x position ahead by one
				Instantiate(tileOfRoom[6], roomTilePosition, Quaternion.identity);
				roomTilePosition.x += 1.0f;
				transform.position = roomTilePosition;
			}
			else
			{
				//Instantiates empty block then moves the x position ahead by one
				Instantiate(tileOfRoom[12], roomTilePosition, Quaternion.identity);
				roomTilePosition.x += 1.0f;
				transform.position = roomTilePosition;
			}
		}
		else if(typeZeroArray[arrayNum] == 661)
		{
			//Instantiates BadGuy block (moves vertical), sets tag, then moves the x position ahead by one
			GameObject BGV = Instantiate(tileOfRoom[22], roomTilePosition, Quaternion.identity) as GameObject;
			BGV.gameObject.tag = "BadGuyVert";
			roomTilePosition.x += 1.0f;
			transform.position = roomTilePosition;
		}
		else if(typeZeroArray[arrayNum] == 664)
		{
			//Instantiates Shaddow Spike Cannon block, sets tag, then moves the x position ahead by one
			GameObject spks = Instantiate(tileOfRoom[28], roomTilePosition, Quaternion.identity) as GameObject;
			spks.gameObject.tag = "spike";
			roomTilePosition.x += 1.0f;
			transform.position = roomTilePosition;
		}
		else if(typeZeroArray[arrayNum] == 665)
		{
			//Instantiates Shaddow Spiketop Cannon block, sets tag, then moves the x position ahead by one
			GameObject spks = Instantiate(tileOfRoom[29], roomTilePosition, Quaternion.identity) as GameObject;
			spks.gameObject.tag = "topspike";
			roomTilePosition.x += 1.0f;
			transform.position = roomTilePosition;
		}
		else if(typeZeroArray[arrayNum] == 666)
		{
			//Instantiates BadGuy block then moves the x position ahead by one
			Instantiate(tileOfRoom[22], roomTilePosition, Quaternion.identity);
			roomTilePosition.x += 1.0f;
			transform.position = roomTilePosition;
		}
		else if(typeZeroArray[arrayNum] == 667)
		{
			//Instantiates Shaddow Spikeleft block, sets tag, then moves the x position ahead by one
			GameObject spks = Instantiate(tileOfRoom[31], roomTilePosition, Quaternion.identity) as GameObject;
			spks.gameObject.tag = "leftspike";
			roomTilePosition.x += 1.0f;
			transform.position = roomTilePosition;
		}
		else if(typeZeroArray[arrayNum] == 668)
		{
			//Instantiates Shaddow Spikeright block, sets tag, then moves the x position ahead by one
			GameObject spks = Instantiate(tileOfRoom[32], roomTilePosition, Quaternion.identity) as GameObject;
			spks.gameObject.tag = "rightspike";
			roomTilePosition.x += 1.0f;
			transform.position = roomTilePosition;
		}
	}
	
	//Checks if there were obstacle block positions from the array.
	private void CheckForObstacleBlocks()
	{
		//If there was a ground block. Initialize the position and pick a template.
		if(groundBlock1 != Vector3.zero)
		{
			GroundBlockPositionInitalize(groundBlock1);
			ChooseGroundTemplate ();
		}
		//IUf there was an air block. Initialize the position and pick a template.
		if(airBlock1 != Vector3.zero)
		{
			AirBlockPositionInitalize(airBlock1);
			ChooseAirTemplate();
		}
	}
	
	//Loops through the selected obstacle bock array.
	private void LoopThroughArray ()
	{
		for (int i = 0; i < tileBlockArray.Length; i++)
		{
			CheckObstacleYPosition(i);
		}
	}
	
	//Randomly chooses a ground template.
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
			//Debug.Log("Room Type Zero Ground Zero was chosen.");
			break;
		case 1:
			tileBlockArray = new int[]
			{
				0,0,14,0,0,
				0,4,2,7,0,
				0,1,2,1,0
			};
			//Debug.Log("Room Type Zero Ground One was chosen.");
			break;
		case 2:
			tileBlockArray = new int[]
			{
				0,0,0,0,0,
				0,2,2,4,2,
				8,8,2,2,11
			};
			//Debug.Log("Room Type Zero Ground Two was chosen.");
			break;
		case 3:
			tileBlockArray = new int[]
			{
				1,1,1,11,1,
				0,8,8,7,0,
				0,0,0,1,0
			};
			//Debug.Log("Room Type Zero Ground Three was chosen.");
			break;
		case 4:
			tileBlockArray = new int[]
			{
				11,0,0,11,0,
				0,1,1,2,0,
				0,8,8,1,4
			};
			//Debug.Log("Room Type Zero Ground Four was chosen.");
			break;
		case 5:
			tileBlockArray = new int[]
			{
				0,14,14,14,2,
				4,2,2,2,0,
				1,2,4,1,14
			};
			//Debug.Log("Room Type Zero Ground Five was chosen.");
			break;
		}
		
		//Calls the function to loop through the array
		LoopThroughArray ();
	}
	
	//Sets the position of the ground obstacle block using the saved position from the Room Array.
	private void GroundBlockPositionInitalize(Vector3 groundblockstart)
	{
		tilePosition = groundblockstart;
		transform.position = tilePosition;
		//sets the starting x position of the obstacle block
		startObstacleXposition = groundblockstart.x;
		//sets the starting y position of the obstacle block
		startObstacleYposition = groundblockstart.y;
		//Debug.Log("Room Type Zero Ground tileBlock initalized");
	}
	
	//Sets the postion of the air obstacle block using hte saved position from the Room Array.
	private void AirBlockPositionInitalize(Vector3 airblockstart)
	{
		tilePosition = airblockstart;
		transform.position = tilePosition;
		//sets the starting x position of the obstacle block
		startObstacleXposition = airblockstart.x;
		//sets the starting y position of the obstacle block
		startObstacleYposition = airblockstart.y;
		//Debug.Log("Room Type Zero Air tileBlock initalized");
	}
	
	//Randomly chooses an air template.
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
			//Debug.Log("Room Type Zero Air Zero was chosen.");
			break;
		case 1:
			tileBlockArray = new int[]
			{
				2,1,4,2,0,
				0,2,1,14,2
			};
			//Debug.Log("Room Type Zero Air One was chosen.");
			break;
		case 2:
			tileBlockArray = new int[]
			{
				0,0,0,7,7,
				0,1,1,1,1
			};
			//Debug.Log("Room Type Zero Air Two was chosen.");
			break;
		case 3:
			tileBlockArray = new int[]
			{
				0,3,0,11,4,
				1,1,11,11,2
			};
			//Debug.Log("Room Type Zero Air Three was chosen.");
			break;
		case 4:
			tileBlockArray = new int[]
			{
				0,2,0,0,142,
				0,141,0,0,2
			};
			//Debug.Log("Room Type Zero Air Three was chosen.");
			break;
		case 5:
			tileBlockArray = new int[]
			{
				0,21,0,320,0,
				0,21,1,0,0
			};
			//Debug.Log("Room Type Zero Air Three was chosen.");
			break;
		}
		//Calls the function to loop through the created array
		LoopThroughArray ();
	}
	
	//Determines which row the tile is in and sets its position accordingly.
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
	
	//Determines which column the tile is in and sets its postion accordingly
	private void CheckObstacleXPosition (int x)
	{
		if(x < 5 || (x > 5 & x < 10) || x > 10 )
		{
			ObstacleTileInstantiate(x);
		}
		else if(x == 5 || x == 10)
		{
			//Resets the x position to the starting x position for that obstacle block
			tilePosition.x = startObstacleXposition;
			transform.position = tilePosition;
			ObstacleTileInstantiate(x);
		}
	}
	
	//Instantiates tile at appropriate position and moves the postion ahead.
	private void ObstacleTileInstantiate(int iLoop)
	{
		if(tileBlockArray[iLoop] == 0)
		{
			//Instantiates empty block then moves the x position ahead by one
			Instantiate(tileOfRoom[12], tilePosition, Quaternion.identity);
			tilePosition.x += 1.0f;
			transform.position = tilePosition;
		}
		else if(tileBlockArray[iLoop] == 1)
		{
			//Picks a random solid block texture
			int randomSolid = Random.Range (0,6);
			//Instantiates solid block then moves the x position ahead by one
			Instantiate(tileOfRoom[randomSolid], tilePosition, Quaternion.identity);
			tilePosition.x += 1.0f;
			transform.position = tilePosition;
		}
		else if(tileBlockArray[iLoop] == 2)
		{
			//50% chance the solid block will be instantiated
			int rand50 = Random.Range(1,3);
			if(rand50 == 1)
			{
				//Picks a random solid block texture
				int randomSolid50 = Random.Range (0,6);
				//Instantiates solid block then moves the x position ahead by one
				Instantiate(tileOfRoom[randomSolid50], tilePosition, Quaternion.identity);
				tilePosition.x += 1.0f;
				transform.position = tilePosition;
				
			}
			else
			{
				//Instantiates empty block then moves the x position ahead by one
				Instantiate(tileOfRoom[12], tilePosition, Quaternion.identity);
				tilePosition.x += 1.0f;
				transform.position = tilePosition;
			}
		}
		else if(tileBlockArray[iLoop] == 3)
		{
			//Instantiates spring block then moves the x position ahead by one
			Instantiate(tileOfRoom[6], tilePosition, Quaternion.identity);
			tilePosition.x += 1.0f;
			transform.position = tilePosition;
		}
		else if(tileBlockArray[iLoop] == 4)
		{
			//50% chance the push block will be instantiated
			int rand50 = Random.Range (0,2);
			if(rand50 == 1)
			{
				//Instantiates push block then moves the x position ahead by one
				Instantiate(tileOfRoom[7], tilePosition, Quaternion.identity);
				tilePosition.x += 1.0f;
				transform.position = tilePosition;
			}
			else
			{
				//Instantiates empty block then moves the x position ahead by one
				Instantiate(tileOfRoom[12], tilePosition, Quaternion.identity);
				tilePosition.x += 1.0f;
				transform.position = tilePosition;
			}
		}
		else if(tileBlockArray[iLoop] == 5)
		{
			//Saves the position for the ground block(s)
			if(groundBlock1 == Vector3.zero)
			{
				groundBlock1 = tilePosition;
				//Debug.Log("Room Type Two Ground Block 1 initialized at: "+groundBlock1);
			}
			else
			{
				groundBlock2 = tilePosition;
				//Debug.Log("Room Type Two Ground Block 2 initialized at: "+groundBlock2);
			}
			
			//Instantiates empty block then moves the x position ahead by one
			Instantiate(tileOfRoom[12], tilePosition, Quaternion.identity);
			tilePosition.x += 1.0f;
			transform.position = tilePosition;
		}
		else if(tileBlockArray[iLoop] == 6)
		{
			//Saves the position for the air block(s)
			if(airBlock1 == Vector3.zero)
			{
				airBlock1 = tilePosition;
				//Debug.Log("Room Type Two Air Block 1 initialized at: "+airBlock1);
			}
			else
			{
				airBlock2 = tilePosition;
				//Debug.Log("Room Type Two Air Block 2 initialized at: "+airBlock2);
			}
			
			//Instantiates empty block then moves the x position ahead by one
			Instantiate(tileOfRoom[12], tilePosition, Quaternion.identity);
			tilePosition.x += 1.0f;
			transform.position = tilePosition;
		}
		else if(tileBlockArray[iLoop] == 7)
		{
			//33% chance a spike will be instantiated
			int rand33 = Random.Range(1,4);
			//Instantiates spike block then moves the x position ahead by one
			if(rand33 == 1)
			{
				Instantiate(tileOfRoom[8], tilePosition, Quaternion.identity);
				tilePosition.x += 1.0f;
				transform.position = tilePosition;
			}
			//Instantiates empty block then moves the x position ahead by one
			else
			{
				Instantiate(tileOfRoom[12], tilePosition, Quaternion.identity);
				tilePosition.x += 1.0f;
				transform.position = tilePosition;
			}
		}
		else if(tileBlockArray[iLoop] == 8)
		{
			//33% chance a top spike will be instantiated
			int rand33 = Random.Range(1,4);
			//Instantiates top spike block then moves the x position ahead by one
			if(rand33 == 1)
			{
				Instantiate(tileOfRoom[9], tilePosition, Quaternion.identity);
				tilePosition.x += 1.0f;
				transform.position = tilePosition;
				
			}
			//Instantiates empty block then moves the x position ahead by one
			else
			{
				Instantiate(tileOfRoom[12], tilePosition, Quaternion.identity);
				tilePosition.x += 1.0f;
				transform.position = tilePosition;
			}
		}
		else if(tileBlockArray[iLoop] == 9)
		{
			//Instantiates door block then moves the x position ahead by one
			Instantiate(tileOfRoom[10], tilePosition, Quaternion.identity);
			tilePosition.x += 1.0f;
			transform.position = tilePosition;
		}
		else if(tileBlockArray[iLoop] == 10)
		{
			//50% chance a key will be instantiated
			int rand50 = Random.Range(0,4);
			//Instantiates key block (+1 key) then moves the x position ahead by one
			if(rand50 != 1)
			{
				Instantiate(tileOfRoom[11], tilePosition, Quaternion.identity);
				tilePosition.x += 1.0f;
				transform.position = tilePosition;
			}
			//Instantiates empty block then moves the x position ahead by one
			else
			{
				Instantiate(tileOfRoom[12], tilePosition, Quaternion.identity);
				tilePosition.x += 1.0f;
				transform.position = tilePosition;
			}
		}
		else if(tileBlockArray[iLoop] == 11)
		{
			//Instantiates breakable block then moves the x position ahead by one
			Instantiate(tileOfRoom[14], tilePosition, Quaternion.identity);
			tilePosition.x += 1.0f;
			transform.position = tilePosition;
		}
		else if(tileBlockArray[iLoop] == 12)
		{
			//Instantiates spike block then moves the x position ahead by one
			Instantiate(tileOfRoom[8], tilePosition, Quaternion.identity);
			tilePosition.x += 1.0f;
			transform.position = tilePosition;
		}
		else if(tileBlockArray[iLoop] == 13)
		{
			//Instantiates top spike block then moves the x position ahead by one
			Instantiate(tileOfRoom[9], tilePosition, Quaternion.identity);
			tilePosition.x += 1.0f;
			transform.position = tilePosition;
		}
		else if(tileBlockArray[iLoop] == 14)
		{
			//25% chance a pushblock will be instantiated
			int rand25 = Random.Range(0,4);
			//Instantiates push block then moves the x position ahead by one
			if(rand25 == 1)
			{
				Instantiate(tileOfRoom[13], tilePosition, Quaternion.identity);
				tilePosition.x += 1.0f;
				transform.position = tilePosition;
			}
			//Instantiates empty block then moves the x position ahead by one
			else
			{
				Instantiate(tileOfRoom[12], tilePosition, Quaternion.identity);
				tilePosition.x += 1.0f;
				transform.position = tilePosition;
			}
		}
		else if(tileBlockArray[iLoop] == 15)
		{
			//Instantiates spikeleft block then moves the x position ahead by one
			Instantiate(tileOfRoom[24], tilePosition, Quaternion.identity);
			tilePosition.x += 1.0f;
			transform.position = tilePosition;
		}
		else if(tileBlockArray[iLoop] == 16)
		{
			//Instantiates spikeright block then moves the x position ahead by one
			Instantiate(tileOfRoom[25], tilePosition, Quaternion.identity);
			tilePosition.x += 1.0f;
			transform.position = tilePosition;
		}
		else if(tileBlockArray[iLoop] == 17)
		{
			//Instantiates teleport-in block, sets name, then moves the x position ahead by one
			GameObject telaIn = Instantiate(tileOfRoom[26], tilePosition, Quaternion.identity) as GameObject;
			telaInStringName = telaportNumeric.ToString();
			telaIn.gameObject.name = telaInStringName;
			tilePosition.x += 1.0f;
			transform.position = tilePosition;
		}
		else if(tileBlockArray[iLoop] == 18)
		{
			//Instantiates teleport-out block, sets name, then moves the x position ahead by one
			GameObject telaOut = Instantiate(tileOfRoom[27], tilePosition, Quaternion.identity) as GameObject;
			telaOutStringName = ("telaOut"+telaportNumeric);
			telaOut.gameObject.name = telaOutStringName;
			//Debug.Log (telaOut.gameObject.name);
			tilePosition.x += 1.0f;
			transform.position = tilePosition;
		}
		else if(tileBlockArray[iLoop] == 20)
		{
			//Instantiates bow block (+1 arrow) then moves the x position ahead by one
			Instantiate(tileOfRoom[21], tilePosition, Quaternion.identity);
			tilePosition.x += 1.0f;
			transform.position = tilePosition;
		}
		else if(tileBlockArray[iLoop] == 21)
		{
			//Corrects the position to account for 2x1 block.
			Vector3 correctedPosition = tilePosition + new Vector3(0.5f, 0.0f, 0.0f);
			//Randomly selects one of three 2x1 block textures
			int rand13 = Random.Range(1,4);
			//Instantiates 2x1 block then moves the x position ahead by one
			if(rand13 == 1)
			{
				Instantiate(tileOfRoom[16], correctedPosition, Quaternion.identity);
				tilePosition.x += 1.0f;
				transform.position = tilePosition;
			}
			else if(rand13 == 2)
			{
				Instantiate(tileOfRoom[17], correctedPosition, Quaternion.identity);
				tilePosition.x += 1.0f;
				transform.position = tilePosition;
			}
			else if(rand13 == 3)
			{
				Instantiate(tileOfRoom[18], correctedPosition, Quaternion.identity);
				tilePosition.x += 1.0f;
				transform.position = tilePosition;
			}
		}
		else if(tileBlockArray[iLoop] == 33)
		{
			//Instantiates EXIT block then moves the x position ahead by one
			Instantiate(tileOfRoom[15], tilePosition, Quaternion.identity);
			tilePosition.x += 1.0f;
			transform.position = tilePosition;
		}
		else if (tileBlockArray[iLoop] == 41)
		{
			//Instantiates push block then moves the x position ahead by one
			Instantiate(tileOfRoom[7], tilePosition, Quaternion.identity);
			tilePosition.x += 1.0f;
			transform.position = tilePosition;
		}
		else if(tileBlockArray[iLoop] == 50)
		{
			//Selects one of six solid block textures
			int randomSolid = Random.Range (0,6);
			//Instantiates hidden block, moves to HiddenBlock Layer, then moves the x position ahead by one
			GameObject hiddenRoom = Instantiate(tileOfRoom[randomSolid], tilePosition, Quaternion.identity) as GameObject;
			hiddenRoom.layer = 15;
			tilePosition.x += 1.0f;
			transform.position = tilePosition;
		}
		else if(tileBlockArray[iLoop] == 66)
		{
			//Instantiates Bad Guy block (moves horizontal), sets tag, then moves the x position ahead by one
			GameObject BG = Instantiate(tileOfRoom[22], tilePosition, Quaternion.identity) as GameObject;
			BG.gameObject.tag = "BadGuy";
			tilePosition.x += 1.0f;
			transform.position = tilePosition;
		}
		else if(tileBlockArray[iLoop] == 96)
		{
			//Instantiates shaddow block (bounces), sets name, then moves the x position ahead by one
			GameObject SB = Instantiate(tileOfRoom[30], tilePosition, Quaternion.identity) as GameObject;
			SB.gameObject.name = "ShaddowBounce";
			tilePosition.x += 1.0f;
			transform.position = tilePosition;
		}
		else if(tileBlockArray[iLoop] == 97)
		{
			//Instantiates shaddow block (moves forward), sets name, then moves the x position ahead by one
			GameObject SB = Instantiate(tileOfRoom[30], tilePosition, Quaternion.identity) as GameObject;
			SB.gameObject.name = "ShaddowForward";
			tilePosition.x += 1.0f;
			transform.position = tilePosition;
		}
		else if(tileBlockArray[iLoop] == 99)
		{
			//Instantiates golden bow block (+5 arrows) then moves the x position ahead by one
			Instantiate(tileOfRoom[23], tilePosition, Quaternion.identity);
			tilePosition.x += 1.0f;
			transform.position = tilePosition;
		}
		else if(tileBlockArray[iLoop] == 100)
		{
			//Instantiates key block (+1 key) then moves the x position ahead by one
			Instantiate(tileOfRoom[11], tilePosition, Quaternion.identity);
			tilePosition.x += 1.0f;
			transform.position = tilePosition;
		}
		else if(tileBlockArray[iLoop] == 111)
		{
			//33% chance the bow block will be instantiated
			int rand33 = Random.Range(1,4);
			//Instantiates bow block (+1 arrow) then moves the x position ahead by one
			if(rand33 == 1)
			{
				Instantiate(tileOfRoom[21], tilePosition, Quaternion.identity);
				tilePosition.x += 1.0f;
				transform.position = tilePosition;
				
			}
			//Instantiates empty block then moves the x position ahead by one
			else
			{
				Instantiate(tileOfRoom[12], tilePosition, Quaternion.identity);
				tilePosition.x += 1.0f;
				transform.position = tilePosition;
			}
		}
		else if(tileBlockArray[iLoop] == 141)
		{
			//Instantiates breakableTR block then moves the x position ahead by one
			Instantiate(tileOfRoom[19], tilePosition, Quaternion.identity);
			tilePosition.x += 1.0f;
			transform.position = tilePosition;
		}
		else if(tileBlockArray[iLoop] == 142)
		{
			//Instantiates breakableBL block then moves the x position ahead by one
			Instantiate(tileOfRoom[20], tilePosition, Quaternion.identity);
			tilePosition.x += 1.0f;
			transform.position = tilePosition;
		}
		else if(tileBlockArray[iLoop] == 320)
		{
			//20% chance the spring block will be instantiated
			int rand20 = Random.Range(0,5);
			if(rand20 == 0)
			{
				//Instantiates spring block then moves the x position ahead by one
				Instantiate(tileOfRoom[6], tilePosition, Quaternion.identity);
				tilePosition.x += 1.0f;
				transform.position = tilePosition;
			}
			else
			{
				//Instantiates empty block then moves the x position ahead by one
				Instantiate(tileOfRoom[12], tilePosition, Quaternion.identity);
				tilePosition.x += 1.0f;
				transform.position = tilePosition;
			}
		}
		else if(tileBlockArray[iLoop] == 360)
		{
			//Aprox. 60% chance the spring block will be instantiated
			int rand60 = Random.Range(0,3);
			if(rand60 != 0)
			{
				//Instantiates spring block then moves the x position ahead by one
				Instantiate(tileOfRoom[6], tilePosition, Quaternion.identity);
				tilePosition.x += 1.0f;
				transform.position = tilePosition;
			}
			else
			{
				//Instantiates empty block then moves the x position ahead by one
				Instantiate(tileOfRoom[12], tilePosition, Quaternion.identity);
				tilePosition.x += 1.0f;
				transform.position = tilePosition;
			}
		}
		else if(tileBlockArray[iLoop] == 661)
		{
			//Instantiates BadGuy block (moves vertical), sets tag, then moves the x position ahead by one
			GameObject BGV = Instantiate(tileOfRoom[22], tilePosition, Quaternion.identity) as GameObject;
			BGV.gameObject.tag = "BadGuyVert";
			tilePosition.x += 1.0f;
			transform.position = tilePosition;
		}
		else if(tileBlockArray[iLoop] == 664)
		{
			//Instantiates Shaddow Spike Cannon block, sets tag, then moves the x position ahead by one
			GameObject spks = Instantiate(tileOfRoom[28], tilePosition, Quaternion.identity) as GameObject;
			spks.gameObject.tag = "spike";
			tilePosition.x += 1.0f;
			transform.position = tilePosition;
		}
		else if(tileBlockArray[iLoop] == 665)
		{
			//Instantiates Shaddow Spiketop Cannon block, sets tag, then moves the x position ahead by one
			GameObject spks = Instantiate(tileOfRoom[29], tilePosition, Quaternion.identity) as GameObject;
			spks.gameObject.tag = "topspike";
			tilePosition.x += 1.0f;
			transform.position = tilePosition;
		}
		else if(tileBlockArray[iLoop] == 666)
		{
			//Instantiates BadGuy block then moves the x position ahead by one
			Instantiate(tileOfRoom[22], tilePosition, Quaternion.identity);
			tilePosition.x += 1.0f;
			transform.position = tilePosition;
		}
		else if(tileBlockArray[iLoop] == 667)
		{
			//Instantiates Shaddow Spikeleft block, sets tag, then moves the x position ahead by one
			GameObject spks = Instantiate(tileOfRoom[31], tilePosition, Quaternion.identity) as GameObject;
			spks.gameObject.tag = "leftspike";
			tilePosition.x += 1.0f;
			transform.position = tilePosition;
		}
		else if(tileBlockArray[iLoop] == 668)
		{
			//Instantiates Shaddow Spikeright block, sets tag, then moves the x position ahead by one
			GameObject spks = Instantiate(tileOfRoom[32], tilePosition, Quaternion.identity) as GameObject;
			spks.gameObject.tag = "rightspike";
			tilePosition.x += 1.0f;
			transform.position = tilePosition;
		}
	}
}