using UnityEngine;
using System.Collections;

public class PauseScreen : MonoBehaviour {

	/// VERY IMPORTANT !!!!!! If you touch this script be sure to call GameTimePlay() to start the Time Scale again!!!!!! READ THIS!!!! //
	public GameObject Panel;
	public GameObject cam;
	public GameObject Player;
	public bool isChallengeLevels = false;

	//Set Private Configs
	private GameObject learnScreen;
	private bool _canFire;

	// Use this for initialization
	void Awake () 
	{
		//prevents the player from shooting during the pause menu
		_canFire = GameObject.Find ("Player").GetComponent<Quiver>().canFire;
	}

	// Update is called once per frame
	void Update () {

		if(Input.GetButtonDown("Back"))
		{
			togglePanel();
			toggleCanFire();
			if(GameObject.Find ("Learn") != null)
			{
				GameObject learnScreen = GameObject.Find ("Learn");
				learnScreen.SetActive(false);
			}
		}
	
	}

	public void goToMain()
	{
		//Starts the game time scale
		GameTimePlay ();
		//Loads the main menu
		Application.LoadLevel("Main_Menu");
	}

	public void Resume()
	{
		togglePlayerMovement();
		toggleCanFire();
		if(isChallengeLevels == false)
		{
			toggleCameraMovement();
			changeVectorOffSet(0);
		}
		//Starts the game time scale
		GameTimePlay ();
		//Turns off the panel
		Panel.SetActive(false);
	}

	public void RespawnRobbe ()
	{
		//Finds the spawn location and moves robbe there
		GameObject respawnPosition = GameObject.Find ("Spawn_Location");
		Player.transform.position = respawnPosition.transform.position;
		//Resumes the game
		Resume ();
	}

	public void Regenerate ()
	{
		string currentLevel = Application.loadedLevelName;
		//Starts the game time scale
		GameTimePlay ();
		//Regenerates a new level of the same type
		Application.LoadLevel(currentLevel);
	}

	private void togglePlayerMovement()
	{
		RobbeController _robbe = Player.GetComponent<RobbeController>();
		_robbe.canMove = !_robbe.canMove;
	}

	private void changeVectorOffSet(int changeValue)
	{
		Smooth_Follow _smoothFollow = cam.GetComponent<Smooth_Follow>();
		_smoothFollow.cameraOffset = new Vector3(0, 0, changeValue);
	}

	private void toggleCameraMovement()
	{
		NoFaithController _nofaith = cam.GetComponent<NoFaithController>();
		_nofaith.canMove = !_nofaith.canMove;
	}

	private void togglePanel()
	{
		if(Panel.activeSelf == false)
		{
			togglePlayerMovement();
			if(isChallengeLevels == false)
			{
				toggleCameraMovement();
				changeVectorOffSet(-50);
			}
			//Displays the Panel
			Panel.SetActive(true);
			//Disables the Regnerate button if on Challenge Levels
			DisableRegenerate ();
			//Pauses the game time scale
			Invoke("GameTimePause", 0.25f);

		}
		else
		{
			togglePlayerMovement();
			if(isChallengeLevels == false)
			{
				toggleCameraMovement();
				changeVectorOffSet(0);
			}
			//Starts the game time scale
			GameTimePlay ();
			//Turns off the Panel
			Panel.SetActive(false);
		}
	}

	private void toggleCanFire ()
	{
		_canFire = !_canFire;
		GameObject.Find ("Player").GetComponent<Quiver>().canFire = _canFire;
	}

	//Disables the Regnerate button if on Challenge Levels
	private void DisableRegenerate ()
	{
		if(isChallengeLevels == true)
		{
			GameObject.Find ("ReGenerate").SetActive(false);
		}
		else
		{
			GameObject.Find ("ReGenerate").SetActive(true);
		}
	}

	//Pauses the game time scale
	private void GameTimePause ()
	{
		Time.timeScale = 0.0f;
	}

	//Starts the game time scale
	private void GameTimePlay ()
	{
		Time.timeScale = 1.0f;
	}

}
