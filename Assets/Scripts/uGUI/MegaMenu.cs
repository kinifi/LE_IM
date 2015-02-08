using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class MegaMenu : MonoBehaviour {

	//Panels to Toggle
	public GameObject GameplayPanel, LearnPanel;
	//The Regenerate Button reference in case this is a challenge level
	public GameObject RegenerateButton;
	//The Reset Button 
	public GameObject RespawnButton;
	//Use this to toggle if this pause menu is in the challenge levels or not
	public bool isChallengeLevels = false;
	//is the pause Menu open?
	private bool isOpen = false;

	// Use this for initialization
	private void Start () {
	
	}

	void Update() {

		//check for input
		if(Input.GetButtonDown("Back") && isOpen == false)
		{

			if(!isOpen)
			{
				isOpen = true;
				setupMenu();
			}
			else
			{
				isOpen = false;
				closeMenu();
			}
		}
		else if(Input.GetButtonDown("LearnButton") && isOpen == false)
		{
			toggleLearnPanel();
			isOpen = true;
		}

	}

	/// <summary>
	/// Quits the game.
	/// </summary>
	public void QuitGame()
	{
		Application.Quit();
	}

	/// <summary>
	/// Quits to main menu.
	/// </summary>
	public void quitToMainMenu()
	{
		Application.LoadLevel("Main_Menu");
	}

	/// <summary>
	/// Resets the level.
	/// </summary>
	public void resetLevel()
	{
		Application.LoadLevel(Application.loadedLevelName);
	}

	/// <summary>
	/// Closes the menu.
	/// </summary>
	public void closeMenu() {

		isOpen = false;
		GameplayPanel.SetActive(false);
		LearnPanel.SetActive(false);
		GameTimePlay();
		enablePlayerFiring();
	}

	/// <summary>
	/// Setups the menu makes the Pause menu show in a default state.
	/// Call this if wanting the Pause Menu to Display from anywhere
	/// </summary>
	public void setupMenu() {
		isOpen = true;
		toggleGameplay();
		disablePlayerFiring();
		//Disables the Regnerate button if on Challenge Levels
		DisableRegenerate ();
		DisableRespawn();
		GameTimePause();
		//GameObject.Find("EventSystem").GetComponent<EventSystem>().SetSelectedGameObject(GameObject.Find("Gameplay_Button"));
	}

	/// <summary>
	/// Toggles the gameplay and disables all the others
	/// </summary>
	public void toggleGameplay () {

		GameplayPanel.SetActive(true);
	}

	/// <summary>
	/// Toggles the learn panel.
	/// </summary>
	public void toggleLearnPanel()
	{
		isOpen = true;
		GameplayPanel.SetActive(false);

		LearnPanel.SetActive(true);
		//GameObject.Find("EventSystem").GetComponent<EventSystem>().SetSelectedGameObject(GameObject.Find("Close"));
	}

	/// <summary>
	/// Toggles the sound panel and disables all the others
	/// </summary>
	public void toggleSoundPanel () {

		GameplayPanel.SetActive(false);

	}

	/// <summary>
	/// Toggles the video panel and disables all the others
	/// </summary>
	public void toggleVideoPanel () {

		GameplayPanel.SetActive(false);
		//GameObject.Find("EventSystem").GetComponent<EventSystem>().SetSelectedGameObject(GameObject.Find("1_Resolutions"));
	}

	/// <summary>
	/// Disables the player firing.
	/// </summary>
	private void disablePlayerFiring ()
	{
		if(isChallengeLevels == false)
		{
			GameObject.Find ("Player").GetComponent<Quiver>().canFire = false;
		}

	}

	private void enablePlayerFiring()
	{
		if(isChallengeLevels == false)
		{
			GameObject.Find ("Player").GetComponent<Quiver>().canFire = true;
		}
	}

	/// <summary>
	/// Disables the Regnerate button if on Challenge Levels
	/// </summary>
	private void DisableRegenerate ()
	{
		if(isChallengeLevels == true)
		{
			RegenerateButton.SetActive(false);
			Debug.Log ("Regenerate has been deactivated");
		}
		else
		{
			RegenerateButton.SetActive(true);
			Debug.Log ("No need to deactivate regenerate");
		}
	}

	private void DisableRespawn ()
	{
		if(isChallengeLevels == true)
		{
			if(Application.loadedLevelName == "Main_Menu")
			{
				RespawnButton.SetActive(false);
			}
			Debug.Log ("Reset has been deactivated");
		}
		else
		{
			RespawnButton.SetActive(true);
			Debug.Log ("No need to deactivate reset");
		}
	}


	/// <summary>
	/// Respawns the robbe.
	/// </summary>
	public void RespawnRobbe ()
	{
		//Finds the spawn location and moves robbe there
		GameObject respawnPosition = GameObject.Find ("Spawn_Location");
		GameObject.Find("Player").transform.position = respawnPosition.transform.position;
		//Resumes the game
		closeMenu();
	}

	/// <summary>
	/// Regenerate this Scene/Level
	/// </summary>
	public void Regenerate ()
	{
		string currentLevel = Application.loadedLevelName;
		//Starts the game time scale
		GameTimePlay ();
		//Regenerates a new level of the same type
		Application.LoadLevel(currentLevel);
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

}
