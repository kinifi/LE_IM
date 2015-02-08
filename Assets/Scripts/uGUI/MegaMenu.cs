using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class MegaMenu : MonoBehaviour {

	//Panels to Toggle
	public GameObject GameplayPanel, SoundPanel, VideoPanel, LearnPanel;
	//The Regenerate Button reference in case this is a challenge level
	public GameObject RegenerateButton;
	//control panel are the top three buttons in the menu
	public GameObject ControlPanel;
	//Use this to toggle if this pause menu is in the challenge levels or not
	public bool isChallengeLevels = false;
	//is the pause Menu open?
	private bool isOpen = false;


	// Use this for initialization
	private void Start () {
	
	}

	void Update() {

		//check for input
		if(Input.GetButtonDown("Back"))
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
		Application.LoadLevel("MainMenu");
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

		ControlPanel.SetActive(false);
		GameplayPanel.SetActive(false);
		SoundPanel.SetActive(false);
		VideoPanel.SetActive(false);
	}

	/// <summary>
	/// Setups the menu makes the Pause menu show in a default state.
	/// Call this if wanting the Pause Menu to Display from anywhere
	/// </summary>
	public void setupMenu() {
		isOpen = true;
		ControlPanel.SetActive(true);
		toggleGameplay();
		//Disables the Regnerate button if on Challenge Levels
		DisableRegenerate ();
	}

	/// <summary>
	/// Toggles the gameplay and disables all the others
	/// </summary>
	public void toggleGameplay () {

		GameplayPanel.SetActive(true);
		SoundPanel.SetActive(false);
		VideoPanel.SetActive(false);
		setFirstSelected.setFirstSelectedItem(GameObject.Find("Gameplay_Button"));
	}

	public void toggleLearnPanel()
	{
		isOpen = true;
		ControlPanel.SetActive(false);
		GameplayPanel.SetActive(false);
		SoundPanel.SetActive(false);
		VideoPanel.SetActive(false);
		LearnPanel.SetActive(true);
	}

	/// <summary>
	/// Toggles the sound panel and disables all the others
	/// </summary>
	public void toggleSoundPanel () {

		GameplayPanel.SetActive(false);
		SoundPanel.SetActive(true);
		VideoPanel.SetActive(false);

	}

	/// <summary>
	/// Toggles the video panel and disables all the others
	/// </summary>
	public void toggleVideoPanel () {

		GameplayPanel.SetActive(false);
		SoundPanel.SetActive(false);
		VideoPanel.SetActive(true);
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

}
