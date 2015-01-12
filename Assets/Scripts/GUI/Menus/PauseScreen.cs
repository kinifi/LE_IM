using UnityEngine;
using System.Collections;

public class PauseScreen : MonoBehaviour {

	/// VERY IMPORTANT !!!!!! If you touch this script be sure to call GameTimePlay() to start the Time Scale again!!!!!! READ THIS!!!! //

	//panel configs
	public GameObject PausePanel;
	public GameObject LearnPanel;
	private GameObject Panel;

	//other configs
	public GameObject Player;
	public bool isChallengeLevels = false;
	private bool canToggle = true;


	void Update () {

		if(Input.GetButtonDown("Back") && canToggle == true)
		{
			canToggle = false;
			Debug.Log ("canToggle is now false: "+canToggle);
			if(GameObject.Find ("Learn") != null)
			{
				Panel = LearnPanel;
				togglePanel ();
			}
			else if(GameObject.Find ("Pause") != null)
			{
				Panel = PausePanel;
				togglePanel();
			}
			else
			{
				Panel = PausePanel;
				togglePanel();
			}
		}
		if(Input.GetButtonDown("LearnButton") && Application.loadedLevelName == "Options" && canToggle == true)
		{
			canToggle = false;
			Debug.Log ("canToggle is now false: "+canToggle);
			Debug.Log ("LearnButton was pressed.");
			Panel = LearnPanel;
			togglePanel ();
		}
		if(Input.GetButtonDown("LearnButton") && Application.loadedLevelName != "Options" && canToggle == true)
		{
			canToggle = false;
			Debug.Log ("canToggle is now false: "+canToggle);
			Debug.Log ("LearnButton was pressed.");
			if(GameObject.Find("Pause") == null)
			{
				Panel = LearnPanel;
				togglePanel();
			}
			else
			{
				Invoke ("ToggleTrue", 0.05f);
			}
		}
		if(Panel != null)
		{
			if(GameObject.Find ("Learn") != null || GameObject.Find ("Pause") != null)
			{
				GameObject.Find ("Camera").GetComponent<Camera>().cullingMask = 1 << (LayerMask.NameToLayer("UI"));
				GameObject.Find ("Player").GetComponent<Quiver>().canFire = false;
			}
			else
			{
				GameObject.Find ("Camera").GetComponent<Camera>().cullingMask = LayerMask.NameToLayer("Everything");
				GameObject.Find ("Player").GetComponent<Quiver>().canFire = true;
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
		//Set canToggle to true
		ToggleTrue();
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

	private void togglePanel()
	{
		Invoke ("ToggleTrue", 0.05f);

		if(Panel.activeSelf == false)
		{
			//Displays the Panel
			Panel.SetActive(true);
			Debug.Log ("Panel should be set to on!");
			//Disables the Regnerate button if on Challenge Levels
			DisableRegenerate ();
			//Pauses the game time scale
			Invoke("GameTimePause", 0.15f);
		}
		else
		{
			//Resumes the game
			Resume();
		}
	}

	//Disables the Regnerate button if on Challenge Levels
	private void DisableRegenerate ()
	{
		if(Panel == PausePanel)
		{
			if(isChallengeLevels == true)
			{
				GameObject.Find ("ReGenerate").SetActive(false);
				Debug.Log ("Regenerate has been deactivated");
			}
			else
			{
				GameObject.Find ("ReGenerate").SetActive(true);
				Debug.Log ("No need to deactivate regenerate");
			}
		}
	}

	//Pauses the game time scale
	private void GameTimePause ()
	{
		Debug.Log ("Pausing Game Time");
		Time.timeScale = 0.0f;
	}

	//Starts the game time scale
	private void GameTimePlay ()
	{
		Debug.Log ("Resume game time");
		Time.timeScale = 1.0f;
	}

	//setToggle to true
	private void ToggleTrue ()
	{
		canToggle = true;
		Debug.Log ("canToggle is now true: "+canToggle);
	}
}
