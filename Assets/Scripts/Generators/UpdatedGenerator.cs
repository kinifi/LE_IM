using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;

public class UpdatedGenerator : MonoBehaviour {

	//Configs for map
	public string[] mapMatrix = new string[16];
	private int mapMatrixInt = 0;
	//List configs
	private List<string> forbiddenRoomList = new List<string> {"A,A", "A,B", "B,B", "B,A", "C,C", "C,D", "D,D", "D,C", "E,E", "E,F", "F,F", "F,E", "G,G", "G,H", "H,H", "H,G"};
	private List<int> inMatrix = new List<int> {0,1};

	//String configs
	private string roomString;
	private string lastRoom;
	private string roomPart1;
	private string roomPart2;

	//Configs bool
	private bool finalRoom = false;

	//Int configs
	private int positionModifier = 0;

	// Use this for initialization
	void Start () 
	{
		ZeroRoom();
	}
	
	public void NewDungeon()
	{
		//Sets the first room type to a standard.
		ZeroRoom();
	}

	private void ZeroRoom ()
	{    
		//set the first room to a standard
		mapMatrix[0] = "H,D";
		//Debug.Log ("The value of " + mapMatrixInt + " is: " + mapMatrix[0]);

		//update the last room value
		lastRoom = mapMatrix[0];
		//Debug.Log ("The last room is now: " + mapMatrix[0]);

		//increment mapMatrixInt
		mapMatrixInt += 1;
		//Debug.Log ("The next map matrix position is: " + mapMatrixInt);

		//find the next room
		NextRoom(lastRoom);
	}

	private void NextRoom (string lastRoomSaved)
	{
		//find room part 1
		FindRoomPart1(lastRoomSaved);
		//Debug.Log ("The first part of the room at " + mapMatrixInt + " is: " + roomPart1);

		//find room part 1
		Invoke ("FindRoomPart2", 0.25f);

		//Combine the room part strings
		Invoke("CombineRoomParts", 0.25f);

		//Combine room parts calls the SetMapMatrixValue method

	}

	private void FindRoomPart1 (string lastRoomFromNext)
	{
		//find the second part of the last room
		string lastPart2 = lastRoomFromNext[2].ToString();

		//determine the first part of the next room
		switch(lastPart2)
		{
		case "A":
			roomPart1 = "F";
			break;
		case "B":
			roomPart1 = "E";
			break;
		case "C":
			roomPart1 = "H";
			break;
		case "D":
			roomPart1 = "G";
			break;
		case "E":
			roomPart1 = "B";
			break;
		case "F":
			roomPart1 = "A";
			break;
		case "G":
			roomPart1 = "D";
			break;
		case "H":
			roomPart1 = "C";
			break;
		default:
			roomPart1 = lastPart2;
			Debug.Log("Something went wrong when selecting RoomPart1 for " + mapMatrix[mapMatrixInt]);
			break;
		}
	}

	private void FindRoomPart2 ()
	{
		//find room part 2
		if(mapMatrixInt < 5)
		{
			//Debug.Log ("Part2_A was called");
			FindRoomPart2_A();
			//Debug.Log ("The second part of the room at " + mapMatrixInt + " is: " + roomPart2);
		}
		else if (mapMatrixInt > 4 && mapMatrixInt < 8)
		{
			//Debug.Log ("Part2_B was called");
			FindRoomPart2_B();
			//Debug.Log ("The second part of the room at " + mapMatrixInt + " is: " + roomPart2);
		}
		else if (mapMatrixInt > 7 && mapMatrixInt < 12)
		{
			//Debug.Log ("Part2_C was called");
			FindRoomPart2_C();
			//Debug.Log ("The second part of the room at " + mapMatrixInt + " is: " + roomPart2);
		}
		else if (mapMatrixInt > 11 && mapMatrixInt < 16)
		{
			//Debug.Log ("Part2_D was called");
			FindRoomPart2_D();
			//Debug.Log ("The second part of the room at " + mapMatrixInt + " is: " + roomPart2);
		}
	}

	private void FindRoomPart2_A ()
	{
		//determine the limits for the next room's part 2 based on the room location
		switch(mapMatrixInt)
		{
		case 1:
			List<string> room1Parts = new List<string> {"C", "D", "E", "F"};
			//use Random.Range to select the next room's part 2
			int room1Part2Int = Random.Range (0,4);
			roomPart2 = room1Parts[room1Part2Int];
			//adjust the positionModifier value
			if(roomPart2 == "E" || roomPart2 == "F")
			{
				positionModifier = 5;
				//Debug.Log ("The position modifier is 5 for room 1.");
			}
			else
			{
				positionModifier = 1;
				//Debug.Log ("The position modifier is 1 for room 1.");
			}
			break;
		case 2:
			List<string> room2Parts = new List<string> {"C", "D", "E", "F"};
			//use Random.Range to select the next room's part 2
			int room2Part2Int = Random.Range (0,4);
			roomPart2 = room2Parts[room2Part2Int];
			//adjust the positionModifier value
			if(roomPart2 == "E" || roomPart2 == "F")
			{
				positionModifier = 3;
				//Debug.Log ("The position modifier is 3 for room 2.");
			}
			else
			{
				positionModifier = 1;
				//Debug.Log ("The position modifier is 1 for room 2.");
			}
			break;
		case 3:
			List<string> room3Parts = new List<string> {"E", "F"};
			//use Random.Range to select the next room's part 2
			int room3Part2Int = Random.Range (0,2);
			roomPart2 = room3Parts[room3Part2Int];
			//the path is going down, adjust the positionModifier value
				positionModifier = 1;
				//Debug.Log ("The position modifier is 1 for room 3.");
			break;
		case 4:
			List<string> room4Parts = new List<string> {"E", "F", "G", "H"};
			//use Random.Range to select the next room's part 2
			int room4Part2Int = Random.Range (0,4);
			roomPart2 = room4Parts[room4Part2Int];
			//adjust the positionModifier value
			if(roomPart2 == "E" || roomPart2 == "F")
			{
				positionModifier = 7;
				//Debug.Log ("The position modifier is 7 for room 4.");
			}
			else
			{
				positionModifier = 1;
				//Debug.Log ("The position modifier is 1 for room 4.");
			}
			break;
		default:
			Debug.Log ("Something went wrong in the FindPart2 switch for room: " + mapMatrixInt);
			List<string> room666Parts = new List<string> {"A", "B", "C", "D", "E", "F", "G", "H"};
			//use Random.Range to select the next room's part 2
			int roomPart2Int = Random.Range (0,8);
			roomPart2 = room666Parts[roomPart2Int];
			//adjust the modifier value
			positionModifier = 1;
			Debug.Log ("The position modifier is 1 for the Part2_A ERROR 666!!!!!");
			break;
		}
	}
	private void FindRoomPart2_B ()
	{
		//determine the limits for the next room's part 2 based on the room location
		switch(mapMatrixInt)
		{
	case 5:
			List<string> room5Parts = new List<string> {"E", "F", "G", "H"};
			//use Random.Range to select the next room's part 2
			int room5Part2Int = Random.Range (0,4);
			roomPart2 = room5Parts[room5Part2Int];
			//adjust the positionModifier value
			if(roomPart2 == "E" || roomPart2 == "F")
			{
				positionModifier = 5;
				//Debug.Log ("The position modifier is 5 for room 5.");
			}
			else
			{
				positionModifier = 1;
				//Debug.Log ("The position modifier is 1 for room 5.");
			}
			break;
		case 6:
			List<string> room6Parts = new List<string> {"E", "F", "G", "H"};
			//use Random.Range to select the next room's part 2
			int room6Part2Int = Random.Range (0,4);
			roomPart2 = room6Parts[room6Part2Int];
			//adjust the positionModifier value
			if(roomPart2 == "E" || roomPart2 == "F")
			{
				positionModifier = 3;
				//Debug.Log ("The position modifier is 3 for room 6.");
			}
			else
			{
				positionModifier = 1;
				//Debug.Log ("The position modifier is 1 for room 6.");
			}
			break;
		case 7:
			List<string> room7Parts = new List<string> {"E", "F"};
			//use Random.Range to select the next room's part 2
			int room7Part2Int = Random.Range (0,2);
			roomPart2 = room7Parts[room7Part2Int];
			//the path is going down, adjust the positionModifier value
			positionModifier = 1;
			//Debug.Log ("The position modifier is 1 for room 7.");
			break;
		default:
			Debug.Log ("Something went wrong in the FindPart2 switch for room: " + mapMatrixInt);
			List<string> room666Parts = new List<string> {"A", "B", "C", "D", "E", "F", "G", "H"};
			//use Random.Range to select the next room's part 2
			int roomPart2Int = Random.Range (0,8);
			roomPart2 = room666Parts[roomPart2Int];
			//adjust the modifier value
			positionModifier = 1;
			Debug.Log ("The position modifier is 1 for the Part2_B ERROR 666!!!!!");
			break;
		}
	}

	private void FindRoomPart2_C ()
	{
		//determine the limits for the next room's part 2 based on the room location
		switch(mapMatrixInt)
		{
		case 8:
			List<string> room8Parts = new List<string> {"C", "D", "E", "F"};
			//use Random.Range to select the next room's part 2
			int room8Part2Int = Random.Range (0,4);
			roomPart2 = room8Parts[room8Part2Int];
			//adjust the positionModifier value
			if(roomPart2 == "E" || roomPart2 == "F")
			{
				positionModifier = 7;
				//Debug.Log ("The position modifier is 7 for room 8.");
			}
			else
			{
				positionModifier = 1;
				//Debug.Log ("The position modifier is 1 for room 8.");
			}
			break;
		case 9:
			List<string> room9Parts = new List<string> {"C", "D", "E", "F"};
			//use Random.Range to select the next room's part 2
			int room9Part2Int = Random.Range (0,4);
			roomPart2 = room9Parts[room9Part2Int];
			//adjust the positionModifier value
			if(roomPart2 == "E" || roomPart2 == "F")
			{
				positionModifier = 5;
				//Debug.Log ("The position modifier is 5 for room 9.");
			}
			else
			{
				positionModifier = 1;
				//Debug.Log ("The position modifier is 1 for room 9.");
			}
			break;
		case 10:
			List<string> room10Parts = new List<string> {"C", "D", "E", "F"};
			//use Random.Range to select the next room's part 2
			int room10Part2Int = Random.Range (0,4);
			roomPart2 = room10Parts[room10Part2Int];
			//adjust the positionModifier value
			if(roomPart2 == "E" || roomPart2 == "F")
			{
				positionModifier = 3;
				//Debug.Log ("The position modifier is 3 for room 10.");
			}
			else
			{
				positionModifier = 1;
				//Debug.Log ("The position modifier is 1 for room 10.");
			}
			break;
		case 11:
			List<string> room11Parts = new List<string> {"E", "F"};
			//use Random.Range to select the next room's part 2
			int room11Part2Int = Random.Range (0,2);
			roomPart2 = room11Parts[room11Part2Int];
			//the path is going down, adjust the positionModifier value
			positionModifier = 1;
			//Debug.Log ("The position modifier is 1 for room 11.");
			break;
		default:
			Debug.Log ("Something went wrong in the FindPart2 switch for room: " + mapMatrixInt);
			List<string> room666Parts = new List<string> {"A", "B", "C", "D", "E", "F", "G", "H"};
			//use Random.Range to select the next room's part 2
			int roomPart2Int = Random.Range (0,8);
			roomPart2 = room666Parts[roomPart2Int];
			//adjust the modifier value
			positionModifier = 1;
			Debug.Log ("The position modifier is 1 for the Part2_C ERROR 666!!!!!");
			break;
		}
	}
	private void FindRoomPart2_D ()
	{
		//determine the limits for the next room's part 2 based on the room location
		switch(mapMatrixInt)
		{
	case 12:
			List<string> room12Parts = new List<string> {"G", "H", "Z"};
			//use Random.Range to select the next room's part 2
			int room12Part2Int = Random.Range(0,3);
			roomPart2 = room12Parts[room12Part2Int];
			//adjust the modifier value
			if(roomPart2 != "Z")
			{
				positionModifier = 1;
				//Debug.Log ("The position modifier is 1 for room 12.");
			}
			else
			{
				finalRoom = true;
				//Debug.Log("Final Room!!!!");
			}
			break;
		case 13:
			List<string> room13Parts = new List<string> {"G", "H", "Z"};
			//use Random.Range to select the next room's part 2
			int room13Part2Int = Random.Range(0,3);
			roomPart2 = room13Parts[room13Part2Int];
			//adjust the modifier value
			if(roomPart2 != "Z")
			{
				positionModifier = 1;
				//Debug.Log ("The position modifier is 1 for room 13.");
			}
			else
			{
				finalRoom = true;
				//Debug.Log("Final Room!!!!");
			}
			break;
		case 14:
			List<string> room14Parts = new List<string> {"G", "H", "Z"};
			//use Random.Range to select the next room's part 2
			int room14Part2Int = Random.Range(0,3);
			roomPart2 = room14Parts[room14Part2Int];
			//adjust the modifier value
			if(roomPart2 != "Z")
			{
				positionModifier = 1;
				//Debug.Log ("The position modifier is 1 for room 14.");
			}
			else
			{
				finalRoom = true;
				//Debug.Log("Final Room!!!!");
			}
			break;
		case 15:
			roomPart2 = "Z";
			finalRoom = true;
			//Debug.Log ("The path made it all the way to room 15 :D");
			break;
		default:
			Debug.Log ("Something went wrong in the FindPart2 switch for room: " + mapMatrixInt);
			List<string> room666Parts = new List<string> {"A", "B", "C", "D", "E", "F", "G", "H"};
			//use Random.Range to select the next room's part 2
			int roomPart2Int = Random.Range (0,8);
			roomPart2 = room666Parts[roomPart2Int];
			//adjust the modifier value
			positionModifier = 1;
			Debug.Log ("The position modifier is 1 for the Part2_D ERROR 666!!!!!");
			break;
		}
	}

	private void CombineRoomParts ()
	{
		//combine the room parts
		string nextRoom = roomPart1 + "," + roomPart2;
		//Debug.Log ("The next room is: " + nextRoom);
		
		//check against the forbiden list
		if(forbiddenRoomList.Contains(nextRoom))
		{
			//Debug.Log ("The next room is a forbidden room. START OVER!!!");
			NextRoom(lastRoom);
		}
		else
		{
			//Debug.Log ("The next room is good to go!!");
			SetMapMatrixValue(nextRoom);
		}
	}

	private void SetMapMatrixValue(string currentRoom)
	{
		//set current room
		//Debug.Log ("The next room is now the current room: " + currentRoom);
		mapMatrix[mapMatrixInt] = currentRoom;
		
		//update the last room value
		lastRoom = mapMatrix[mapMatrixInt];
		//Debug.Log ("The last room is now: " + mapMatrix[mapMatrixInt]);
		
		//increment mapMatrixInt
		mapMatrixInt = (mapMatrixInt + positionModifier);
		//Debug.Log ("The next map matrix position is: " + mapMatrixInt);
		//Add new mapMatrixInt to inMatrix list
		inMatrix.Add(mapMatrixInt);
		//set the row Modifier back to zero;
		positionModifier = 0;
		
		//keep going or be done?
		if(mapMatrixInt < 16 && finalRoom == false)
		{
			//find the next room
			NextRoom(lastRoom);
		}
		else
		{
			Invoke ("SaturateOhs", 0.25f);
		}
	}

	private void SaturateOhs ()
	{
		//Declare and instantiate RegEx
		Regex defaultRegex = new Regex(@"[A-Z]");

		//loop through the matrix array and fill in the empties with Ohs.
		for(int i = 0; i < 16; i++)
		{
			if(defaultRegex.IsMatch(mapMatrix[i]) == false)
			{
				mapMatrix[i] = "O,O";
				//Debug.Log("There was no match");
			}
		}
		//invoke OnComplete
		Invoke ("OnComplete", 0.5f);
	}
	
	private void OnComplete()
	{
		Debug.Log ("Dungeon should be generated.");
		for(int i = 0; i < 16; i++)
		{
			Debug.Log (mapMatrix[i]);
		}
		Invoke ("FillInTheMap", 0.15f);
	}

	private void FillInTheMap()
	{
		//Debug.Log (mapMatrix);
		RoomCall00 sendValue00 = GameObject.Find ("Matrix00").GetComponent<RoomCall00>();
		sendValue00.GetMatrix00Value();
		/*
		RoomCall01 sendValue01 = GameObject.Find ("Matrix01").GetComponent<RoomCall01>();
		sendValue01.GetMatrix01Value();
		
		RoomCall02 sendValue02 = GameObject.Find ("Matrix02").GetComponent<RoomCall02>();
		sendValue02.GetMatrix02Value();
		
		RoomCall03 sendValue03 = GameObject.Find ("Matrix03").GetComponent<RoomCall03>();
		sendValue03.GetMatrix03Value();
		
		RoomCall10 sendValue10 = GameObject.Find ("Matrix10").GetComponent<RoomCall10>();
		sendValue10.GetMatrix10Value();
		
		RoomCall11 sendValue11 = GameObject.Find ("Matrix11").GetComponent<RoomCall11>();
		sendValue11.GetMatrix11Value();
		
		RoomCall12 sendValue12 = GameObject.Find ("Matrix12").GetComponent<RoomCall12>();
		sendValue12.GetMatrix12Value();
		
		RoomCall13 sendValue13 = GameObject.Find ("Matrix13").GetComponent<RoomCall13>();
		sendValue13.GetMatrix13Value();
		
		RoomCall20 sendValue20 = GameObject.Find ("Matrix20").GetComponent<RoomCall20>();
		sendValue20.GetMatrix20Value();
		
		RoomCall21 sendValue21 = GameObject.Find ("Matrix21").GetComponent<RoomCall21>();
		sendValue21.GetMatrix21Value();
		
		RoomCall22 sendValue22 = GameObject.Find ("Matrix22").GetComponent<RoomCall22>();
		sendValue22.GetMatrix22Value();
		
		RoomCall23 sendValue23 = GameObject.Find ("Matrix23").GetComponent<RoomCall23>();
		sendValue23.GetMatrix23Value();
		
		RoomCall30 sendValue30 = GameObject.Find ("Matrix30").GetComponent<RoomCall30>();
		sendValue30.GetMatrix30Value();
		
		RoomCall31 sendValue31 = GameObject.Find ("Matrix31").GetComponent<RoomCall31>();
		sendValue31.GetMatrix31Value();
		
		RoomCall32 sendValue32 = GameObject.Find ("Matrix32").GetComponent<RoomCall32>();
		sendValue32.GetMatrix32Value();
		
		RoomCall33 sendValue33 = GameObject.Find ("Matrix33").GetComponent<RoomCall33>();
		sendValue33.GetMatrix33Value();*/
	}
}
