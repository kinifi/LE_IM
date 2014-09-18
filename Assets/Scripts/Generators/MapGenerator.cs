using UnityEngine;
using System.Collections;

public class MapGenerator : MonoBehaviour {
	
	public Matrix4x4 mapMatrix = new Matrix4x4();
	private int lastRow = 0;
	private int lastColumn = 0;
	private int pathNum = 1;
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
		else if(tutorialDone == true && Application.loadedLevelName == "Map_Level_Gen")
		{
			LoadCompleteMessage();
			NewDungeon();
			Debug.Log ("Continue Loaded");
		}
		else if(tutorialDone == true)
		{
			LoadControlsMessage();
			NewDungeon();
			Debug.Log ("No Tutorial Random Dungeon loaded!!");
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
		Debug.Log (mapMatrix);
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
		GenerateMatrix();
		StartRoomIsOne();
		ThePath(pathNum, lastRow, lastColumn);
		FillInTheMap();
	}

	private void LoadControlsMessage()
	{
		//Find Robbe's gameobject and set to Kinematic to zero out any velocity.
		GameObject startRobbe = GameObject.Find ("Player");
		startRobbe.rigidbody2D.isKinematic = true;
		
		//Find Robbe's controller and prevent his movement.
		RobbeController _robbe = GameObject.Find("Player").GetComponent<RobbeController>();
		_robbe.canMove = false;
		
		//Find the LookDown camera and prevent its movement.
		NoFaithController _lookdown = GameObject.Find("Camera").GetComponent<NoFaithController>();
		_lookdown.canMove = false;

		//Instantiate the controls splash and overlay Robbe.  Destroy it and call the movement function.
		GameObject controlsSplash = Instantiate(controlsMessage, startRobbe.transform.position, Quaternion.identity) as GameObject;
		controlsSplash.transform.OverlayPosition(startRobbe.transform);
		Destroy(controlsSplash, 2.5f);
		Invoke("AllowRobbesMovement", 2.5f);

	}

	private void LoadCompleteMessage()
	{
		//Find Robbe's gameobject and set to Kinematic to zero out any velocity.
		GameObject startRobbe = GameObject.Find ("Player");
		startRobbe.rigidbody2D.isKinematic = true;
		
		//Find Robbe's controller and prevent his movement.
		RobbeController _robbe = GameObject.Find("Player").GetComponent<RobbeController>();
		_robbe.canMove = false;
		
		//Find the LookDown camera and prevent its movement.
		NoFaithController _lookdown = GameObject.Find("Camera").GetComponent<NoFaithController>();
		_lookdown.canMove = false;

		//Instantiate the complete splash and overlay Robbe.  Destroy it and call the movement function.
		GameObject completeSplash = Instantiate(completeMessage, startRobbe.transform.position, Quaternion.identity) as GameObject;
		completeSplash.transform.OverlayPosition(startRobbe.transform);
		Destroy(completeSplash, 1.5f);
		Invoke("AllowRobbesMovement", 1.5f);
	}

	private void AllowRobbesMovement() 
	{
		//Find Robbe and allow his movement again.  Turn kinematic to false.
		RobbeController _robbe = GameObject.Find("Player").GetComponent<RobbeController>();
		_robbe.canMove = true;
		//_robbe.rigidbody2D.isKinematic = false;
		
		//Find the LookDown camera and allow its movement.
		NoFaithController _lookdown = GameObject.Find("Camera").GetComponent<NoFaithController>();
		_lookdown.canMove = true;
	}

	private void GenerateMatrix ()
	{
		//Generates a zero filled 4x4 matrix
		mapMatrix.SetColumn(0, Vector4.zero);
		mapMatrix.SetColumn(1, Vector4.zero);
		mapMatrix.SetColumn(2, Vector4.zero);
		mapMatrix.SetColumn(3, Vector4.zero);
	}

	private void PathNumGenerator()
	{
		//generates a number between 1 and upto but not including 6 for room path.
		pathNum = Random.Range(1, 6);
	}
	
	private void StartRoomIsOne()
	{
		pathNum = 1;
		ThePath(pathNum, lastRow, lastColumn);
	}
	
	private void ThePath(int num, int row, int column)
	{
		switch (num)
		{
		case 5:
			if(lastRow+1<4)
			{
				mapMatrix[lastRow, lastColumn] = num;
				if(lastRow-1>=0)
				{				
					mapMatrix[lastRow-1, lastColumn] = 2;
					lastRow+=1;
					PathNumGenerator();
					ThePath(pathNum, lastRow, lastColumn);
				}
				else if(lastColumn+1<4)
				{
					lastRow+=1;
					int right = Random.Range(3,5);
					GoRight(right);
				}
				else if(lastColumn-1>=0)
				{
					lastRow+=1;
					int left = Random.Range (1,3);
					GoLeft (left);
				}
			}
			else
			{
				mapMatrix[lastRow, lastColumn] = 0.333f;
				OnComplete();
			}
			break;
		case 4:
			if(lastColumn+1<4)
			{
				GoRight(num);
			}
			else
			{
				SpecialCaseGoesLeft();
			}
			break;
		case 3:
			if(lastColumn+1<4)
			{
				GoRight(num);
			}
			else
			{
				SpecialCaseGoesLeft();
			}
			break;
		case 2:
			if(lastColumn -1 >= 0)
			{
				mapMatrix[lastRow, lastColumn] = num;
				if(lastRow+1<4)
				{
					mapMatrix[lastRow+1, lastColumn] = 3;
				}
				lastColumn = lastColumn-1;
				//Debug.Log ("The lastColumn is now: " + lastColumn);
				PathNumGenerator();
				ThePath(pathNum, lastRow, lastColumn);
			}
			else
			{
				SpecialCaseGoesRight();
			}
			break;
		case 1:
			if(lastColumn-1>= 0)
			{
				GoLeft(num);
			}
			else
			{
				SpecialCaseGoesRight();
			}
			break;
		default:
			Debug.Log("Something went wrong in this matrix: "+mapMatrix);
			break;
		}
	}
	
	private void GoLeft(int ruleNum)
	{
		mapMatrix[lastRow, lastColumn] = ruleNum;
		lastColumn = lastColumn-1;
		//Debug.Log ("The lastColumn is now: " + lastColumn);
		PathNumGenerator();
		ThePath(pathNum, lastRow, lastColumn);
	}
	
	private void GoRight(int ruleNum)
	{
		mapMatrix[lastRow, lastColumn] = ruleNum;
		lastColumn = lastColumn+1;
		//Debug.Log ("The lastColumn is now: " + lastColumn);
		PathNumGenerator();
		ThePath(pathNum, lastRow, lastColumn);
	}
	
	private void SpecialCaseGoesLeft()
	{
		if(lastRow+1<4)
		{
			mapMatrix[lastRow, lastColumn] = 2;
			mapMatrix[lastRow+1, lastColumn] = 5;
			if(lastColumn-1>=0)
			{
				lastColumn = lastColumn-1;
			}
			PathNumGenerator();
			ThePath(pathNum, lastRow, lastColumn);
		}
		else
		{
			mapMatrix[lastRow, lastColumn] = 0.333f;
			OnComplete();
		}
	}
	
	private void SpecialCaseGoesRight()
	{
		if(lastRow+1<4)
		{
			mapMatrix[lastRow, lastColumn] = 2;
			mapMatrix[lastRow+1, lastColumn] = 5;
			if(lastColumn+1<4)
			{
				lastColumn = lastColumn+1;
			}
			PathNumGenerator();
			ThePath(pathNum, lastRow, lastColumn);
		}
		else
		{
			mapMatrix[lastRow, lastColumn] = 0.333f;
			OnComplete();
		}
	}
}
