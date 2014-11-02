 using UnityEngine;
using System.Collections;

public class MapGenerator : MonoBehaviour {
	
	//Configs
	public Matrix4x4 mapMatrix;
	private Vector2 thisPos = new Vector2(0.0f, 0.0f);
	private Vector2 nextPos;
	private int posNum;
	private string posNumString;
	private int basicRoomNum;
	private int downRoomNum;

	public GameObject controlsMessage;
	public GameObject completeMessage;
	private bool tutorialDone = false;
	
	private void Start() 
	{
		//check to see if the tutorial has been complete
		isTutorialComplete();

		if(tutorialDone == false)
		{
			LoadControlsMessage();
			GenerateTutorialMatrix();
			FillInTheMap();
			Debug.Log ("Tutorial Dungeon Loaded!");
		}
		else if(tutorialDone == true && Application.loadedLevel < 12)
		{
			LoadCompleteMessage();
			NewDungeon();
			Debug.Log ("Continue Loaded");
		}
		else if(tutorialDone == true && Application.loadedLevel > 11)
		{
			LoadCompleteMessage();
			Debug.Log("Boss Level");
		}
		else
		{
			Debug.Log ("Something went wrong on Start!!!");
		}
	}

	private void isTutorialComplete () 
	{
		//increment the stats for steam
		incrementGamesPlayed();

		string _tutorialDone = PlayerPrefs.GetString("tutorialDone");
		if(_tutorialDone == "true")
		{
			tutorialDone = true;
		}
		else
		{
			tutorialDone = false;
		}
	}

	private void incrementGamesPlayed()
	{
		SteamManager.StatsAndAchievements.incrementNumOfGames();
	}

	private void GenerateTutorialMatrix ()
	{
		Vector4 tutorialRoom = new Vector4(6.0f, 6.0f, 6.0f, 6.0f);
		//Generates a zero filled 4x4 matrix
		mapMatrix.SetRow(0, tutorialRoom);
		mapMatrix.SetRow(1, tutorialRoom);
		mapMatrix.SetRow(2, tutorialRoom);
		mapMatrix.SetRow(3, tutorialRoom);
	}	
	
	private void FillInTheMap()
	{
		//Debug.Log (mapMatrix);
		RoomCall00 sendValue00 = GameObject.Find ("Matrix00").GetComponent<RoomCall00>();
		sendValue00.GetMatrix00Value();
		
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
		sendValue33.GetMatrix33Value();
	}

	private void OnComplete()
	{
		Debug.Log ("Dungeon should be generated.");
	}

	public void NewDungeon()
	{
		//Genertes a blank (0.0f) matrix
		GenerateMatrix();
		//Sets the first room type to 1.
		FirstRoomOne();
		Debug.Log(mapMatrix);
		FillInTheMap();
	}

	private void LoadControlsMessage()
	{
		//Find Robbe's gameobject and set to Kinematic to zero out any velocity.
		GameObject startRobbe = GameObject.Find ("Player");
		startRobbe.rigidbody2D.isKinematic = true;
		
		//Find Robbe's controller and prevent his movement.
		RobbeController _robbe = GameObject.Find("Player").GetComponent<RobbeController>();
		_robbe.enabled = false;

		//Find the LookDown camera and prevent its movement.
		NoFaithController _lookdown = GameObject.Find("Camera").GetComponent<NoFaithController>();
		_lookdown.enabled = false;

		//Instantiate the controls splash and overlay Robbe.  Destroy it and call the movement function.
		GameObject controlsSplash = Instantiate(controlsMessage, startRobbe.transform.position, Quaternion.identity) as GameObject;
		controlsSplash.transform.OverlayPosition(startRobbe.transform);

		//Destroy Splash
		if(Input.GetButtonDown("Confirm"))
		{
			Destroy(controlsSplash);
		}
		else
		{
			Destroy(controlsSplash, 2.5f);
		}
		
		//Allow Robbe's movement again
		Invoke("AllowRobbesMovement", 2.5f);
	}

	private void LoadCompleteMessage()
	{
		//Find Robbe's controller and prevent his movement.
		RobbeController _robbe = GameObject.Find("Player").GetComponent<RobbeController>();
		_robbe.enabled = false;
		
		//Find the LookDown camera and prevent its movement.
		NoFaithController _lookdown = GameObject.Find("Camera").GetComponent<NoFaithController>();
		_lookdown.enabled = false;

		//Instantiate the complete splash and overlay Robbe.  Destroy it and call the movement function.
		GameObject completeSplash = Instantiate(completeMessage, _robbe.transform.position, Quaternion.identity) as GameObject;
		completeSplash.transform.OverlayPosition(_robbe.transform);

		//Destroy Splash
		if(Input.GetButtonDown("Confirm"))
		{
			Destroy(completeSplash);
		}
		else
		{
			Destroy(completeSplash, 2.5f);
		}

		//Allow Robbe's movement again
		Invoke("AllowRobbesMovement", 2.5f);
	}

	private void AllowRobbesMovement() 
	{
		//Find Robbe and allow his movement again.  Turn kinematic to false.
		RobbeController _robbe = GameObject.Find("Player").GetComponent<RobbeController>();
		_robbe.enabled = true;

		//Find the LookDown camera and allow its movement.
		NoFaithController _lookdown = GameObject.Find("Camera").GetComponent<NoFaithController>();
		_lookdown.enabled = true;
	}

	private void GenerateMatrix ()
	{
		//Generates a zero filled 4x4 matrix
		mapMatrix.SetColumn(0, Vector4.zero);
		mapMatrix.SetColumn(1, Vector4.zero);
		mapMatrix.SetColumn(2, Vector4.zero);
		mapMatrix.SetColumn(3, Vector4.zero);
	}

	//Assigns the first room to value 1;
	private void FirstRoomOne ()
	{
		AssignValue(Vector2.zero, "roomOne");
	}

	//Calls the position generator method and the moves the cursor. Then calls the method to assign the room type value.
	void MoveCursor()
	{
		//Generate the position number
		PosNumGenerator();
		
		//Move the cursor right, left, or down (x = row, y = column)
		switch(posNumString)
		{
		case "1":
			//Go right if you can if not go down.
			if(thisPos.y + 1.0f < 4.0f)
			{
				nextPos = new Vector2 ((thisPos.y+1.0f), thisPos.x);
				thisPos = nextPos;
				//Calls the method to assign the room type value
				AssignValue(thisPos, "fromLeft");
			}
			//Go down if you can or call the exit.
			else
			{
				if(thisPos.x +1.0f < 4.0f)
				{
					//Go down
					nextPos = new Vector2 (thisPos.y,(thisPos.x+1.0f));
					thisPos = nextPos;
					//Calls the method to assign the room type value
					AssignValue(thisPos, "fromTop");
				}
				else
				{
					//Calls the method to assign the room type value
					AssignValue(thisPos, "Exit");
				}
			}
			break;
		case "2":
			//Go left if you can if not go down.
			if(thisPos.y - 1.0f >= 0.0f)
			{
				nextPos = new Vector2 ((thisPos.y-1.0f), thisPos.x);
				thisPos = nextPos;
				//Calls the method to assign the room type value
				AssignValue(thisPos, "fromRight");
			}
			else
			{
				if(thisPos.x +1.0f < 4.0f)
				{
					//Go down if you can or call the exit.
					nextPos = new Vector2 (thisPos.y,(thisPos.x+1.0f));
					thisPos = nextPos;
					//Calls the method to assign the room type value
					AssignValue(thisPos, "fromTop");
				}
				else
				{
					//Calls the method to assign the room type value
					AssignValue(thisPos, "Exit");
				}
			}
			break;
		default:
			Debug.Log("Something has gone terribly wrong when moving the cursor.");
			Debug.Log(mapMatrix);
			break;
		}
		
		
	}
	
	//Picks which direction the cursor should move
	void PosNumGenerator()
	{
		posNum = Random.Range (1,3);
		//Debug.Log (posNum);
		posNumString = posNum.ToString();
		//Debug.Log (posNumString);
	}
	
	//This method assigns the room type value to the matrix location.
	void AssignValue(Vector2 position, string fromDirection)
	{
		switch(fromDirection)
		{
		case "roomOne":
			//Assigns the very first room to room type one
			mapMatrix[0,0] = 1;
			Debug.Log("The roomtype for start is: "+mapMatrix[0,0]);
			MoveCursor();
			break;
		case "fromLeft":
			//Picks a room type with openings to the left and right
			basicRoomNum = Random.Range(1,4);
			mapMatrix[Mathf.RoundToInt(position.x), Mathf.RoundToInt(position.y)] = basicRoomNum;
			MoveCursor();
			break;
		case "fromRight":
			//Picks a room type with openings to the left and right
			basicRoomNum = Random.Range(1,4);
			mapMatrix[Mathf.RoundToInt(position.x), Mathf.RoundToInt(position.y)] = basicRoomNum;
			MoveCursor();
			break;
		case "fromTop":
			//Picks a room type with openings to the top
			downRoomNum = Random.Range(4,6);
			mapMatrix[Mathf.RoundToInt(position.x), Mathf.RoundToInt(position.y)] = downRoomNum;
			MoveCursor();
			break;
		case "Exit":
			//Sets the exit room
			mapMatrix[Mathf.RoundToInt(position.x), Mathf.RoundToInt(position.y)] = 0.333f;
			break;
		default:
			Debug.Log("Something went wrong Assigning a value.");
			Debug.Log(mapMatrix);
			break;
		}
	}
}
