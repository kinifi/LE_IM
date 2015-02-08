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

	//public GameObject campButton, resumeButton;

	private EventSystem eventSystem = null;

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
		GameTimePlay();
	}

	/// <summary>
	/// Quits to main menu.
	/// </summary>
	public void quitToMainMenu()
	{
		Application.LoadLevel("Main_Menu");
		GameTimePlay();
	}

	/// <summary>
	/// Resets the level.
	/// </summary>
	public void resetLevel()
	{
		Application.LoadLevel(Application.loadedLevelName);
		GameTimePlay();
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
		//setFirstSelected.setFirstSelectedItem(campButton);
		//SetSelectedGameObject(campButton);
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

		//Debug.Log (GameObject.Find("1_Resume") + " here it is");
		//Debug.Log (GameObject.Find("1_Resume").GetComponent<Button>() + " this is the button");

		SetSelectedGameObject(GameObject.Find("1_Resume"));

		GameTimePause();
	}

	public void SetSelectedGameObject(GameObject selected)
	{
		 //GameObject.Find("EventSystem").GetComponent<EventSystem>().SetSelectedGameObject(resumeButton, );

		Debug.Log(">>>>>>>>>>>>>>> is .alreadySelecting? " + GameObject.Find("EventSystem").GetComponent<EventSystem>().alreadySelecting);
		//EventSystem.current.SetSelectedGameObject(selected, new BaseEventData(GameObject.Find("EventSystem").GetComponent<EventSystem>()));
		GameObject.Find("EventSystem").GetComponent<EventSystem>().SetSelectedGameObject(selected);
		Debug.Log("EVENTSYSTEM: setting " + selected.name + " as the .SetSelectedGameObject");
		//Debug.Log("EVENTSYSTEM: current selected gameobject: " + GameObject.Find("EventSystem").GetComponent<EventSystem>().currentSelectedGameObject.ToString());
		//Debug.Log("EVENTSYSTEM: first selected Gameobject: " + GameObject.Find("EventSystem").GetComponent<EventSystem>().firstSelectedGameObject.name);
		//Debug.Log("EVENTSYSTEM: last selected Gameobject: " + GameObject.Find("EventSystem").GetComponent<EventSystem>().lastSelectedGameObject.name);
		Debug.Log(">>>>>>>>>>>>>>> is .alreadySelecting? " + GameObject.Find("EventSystem").GetComponent<EventSystem>().alreadySelecting);
	}

	/*
	static GameObject FindFirstEnabledSelectable (GameObject gameObject)
	{
		GameObject go = null;
		var selectables = gameObject.GetComponentsInChildren<Selectable> (true);
		foreach (var selectable in selectables) {
			if (selectable.IsActive () && selectable.IsInteractable ()) {
				go = selectable.gameObject;
				Debug.Log("" + go.name);
				break;
			}
		}
		return go;
	}
	*/

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
		GameObject.Find("EventSystem").GetComponent<EventSystem>().SetSelectedGameObject(GameObject.Find("Close"));
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
