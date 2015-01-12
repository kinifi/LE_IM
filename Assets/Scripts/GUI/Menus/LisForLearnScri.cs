using UnityEngine;
using System.Collections;

public class LisForLearnScri : MonoBehaviour {

	//Set Public Configs
	public GameObject Panel;
	public GameObject cam;
	public GameObject Player;
	public bool isChallengeLevels = false;


	// Use this for initialization
	void Awake () 
	{
	}

	// Update is called once per frame
	void Update () {

		if(Input.GetButtonDown("LearnButton") && Application.loadedLevelName == "Options")
		{
			Debug.Log ("LearnButton was pressed.");
			OptionsToggle ();
		}
		else if(Input.GetButtonDown("LearnButton") && Application.loadedLevelName != "Options")
		{
			if(GameObject.Find("Pause") == null)
			{
				togglePanel();
			}
		}
	}

	public void togglePanel()
	{
		if(Panel.activeSelf == false)
		{
			/*togglePlayerMovement();
			if(isChallengeLevels == false)
			{
				toggleCameraMovement();
				changeVectorOffSet(-50);
			}*/
			//Displays the learn panel
			Panel.SetActive(true);
			//Pauses the game time scale
			Invoke("GameTimePause", 0.55f);
		}
		else
		{
			/*togglePlayerMovement();
			if(isChallengeLevels == false)
			{
				toggleCameraMovement();
				changeVectorOffSet(0);
			}*/
			Resume ();
		}
	}

	public void Resume()
	{
		//Starts the game time scale
		GameTimePlay ();
		//Turns off the panel
		Panel.SetActive(false);
	}

	private void togglePlayerMovement()
	{
		RobbeController _robbe = Player.GetComponent<RobbeController>();
		_robbe.canMove = !_robbe.canMove;
	}

	private void toggleCameraMovement()
	{
		NoFaithController _nofaith = cam.GetComponent<NoFaithController>();
		_nofaith.canMove = !_nofaith.canMove;
	}

	private void changeVectorOffSet(int changeValue)
	{
		Smooth_Follow _smoothFollow = cam.GetComponent<Smooth_Follow>();
		_smoothFollow.cameraOffset = new Vector3(0, 0, changeValue);
	}

	public void OptionsToggle ()
	{
		if(Panel.activeSelf == false)
		{
			//Displays the Learn panel
			Panel.SetActive(true);
			Debug.Log ("The Learn panel should be visible.");
			//Pauses the game time scale
			Invoke("GameTimePause", 0.25f);
		}
		else if(Panel.activeSelf == true)
		{
			//Starts the game time scale
			GameTimePlay ();
			//Turns off the panel
			Panel.SetActive(false);
			Debug.Log ("The Learn panel should go away.");
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
