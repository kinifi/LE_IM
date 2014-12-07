using UnityEngine;
using System.Collections;

public class NextDungeon : MonoBehaviour {

	//Configs from Player Prefs
	private int _completed;
	private string _nextDungeon;

	//Robbe animation configs
	private GameObject _robbeIdle;
	private GameObject _robbeRunRight;
	private GameObject _exitPoint;

	public Transform finalPosition;
	private Vector3 nextPosition;
	private float speed = 5.0f;
	private bool moveRobbe = false;


	void Start()
	{
		_completed = PlayerPrefs.GetInt("completed");
		_nextDungeon = PlayerPrefs.GetString("door");
		//Debug.Log ("Number of dungeons completed this series: " + _completed);
		//Debug.Log("The next dungeon is: " + _nextDungeon);

		//Upkeep
		moveRobbe = false;
		Invoke ("SetRobbe", 0.5f);
	}

	void Update ()
	{
		if(moveRobbe == true)
		{
			nextPosition = GameObject.Find ("Robbe_RunRight").transform.position;
			nextPosition.x = (nextPosition.x + speed * Time.deltaTime);
			GameObject.Find ("Robbe_RunRight").transform.position = nextPosition;
		}

		if(nextPosition.x >= finalPosition.position.x)
		{
			_robbeRunRight.GetComponent<SpriteRenderer>().enabled = false;
		}
	}
	
	//uses nextDungeonName to set the next dungeon
	private void GoNextDungeon()
	{
		Debug.Log ("I made it!!!");
		if(_completed >= 4)
		{
			string nextBoss = _nextDungeon;
			Debug.Log (nextBoss);
			switch (nextBoss)
			{
			case "1":
				Debug.Log ("ScaredBoss Set");
				Application.LoadLevel("ScaredBoss");
				break;
			case "2":
				Debug.Log ("DepthsBoss Set");
				Application.LoadLevel("DepthsBoss");
				break;
			case "3":
				Debug.Log ("GoblinBoss Set");
				Application.LoadLevel("GoblinBoss");
				break;
			default:
				Debug.Log ("GoblinBoss Set due to default");
				Application.LoadLevel("GoblinBoss");
				break;
			}
		}
		else if(_completed < 4)
		{
			string nextTheme = _nextDungeon;
			switch (nextTheme)
			{
			case "1":
				Debug.Log ("Map Level Set");
				Application.LoadLevel("Map_Level_Gen");
				break;
			case "2":
				Debug.Log ("Dusk Level Set");
				Application.LoadLevel("Dusk_Level");
				break;
			case "3":
				Application.LoadLevel("Purple_Level");
				break;
			case "4":
				Debug.Log ("Nightmare Level Set");
				Application.LoadLevel("Nightmare_Level");
				break;
			case "5":
				Debug.Log ("Olive Level Set");
				Application.LoadLevel("Olive_Level");
				break;
			default:
				Debug.Log ("Something has gone wrong judging on the next dungeon");
				Application.LoadLevel("Tutorial_Dungeon");
				break;
			}
		}
	}

	private void SetRobbe ()
	{
		_robbeIdle = GameObject.Find ("Robbe_Idle");
		_robbeRunRight = GameObject.Find ("Robbe_RunRight");
		Invoke("MoveRobbe", 2.0f);
	}

	private void MoveRobbe ()
	{
		_robbeIdle.SetActive(false);
		_robbeRunRight.GetComponent<SpriteRenderer>().enabled = true;
		moveRobbe = true;
	}
}
