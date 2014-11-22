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
		if(Input.GetButtonDown("Back") && Panel.activeSelf == true)
		{
			Panel.SetActive(false);
			Debug.Log ("The Learn panel should go away.");
		}
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
			Panel.SetActive(true);
			
		}
		else
		{
			togglePlayerMovement();
			if(isChallengeLevels == false)
			{
				toggleCameraMovement();
				changeVectorOffSet(0);
			}
			
			Panel.SetActive(false);
		}
	}

	public void Resume()
	{
		togglePlayerMovement();
		if(isChallengeLevels == false)
		{
			toggleCameraMovement();
			changeVectorOffSet(0);
		}
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
			Panel.SetActive(true);
			Debug.Log ("The Learn panel should be visible.");
		}
		else if(Panel.activeSelf == true)
		{
			Panel.SetActive(false);
			Debug.Log ("The Learn panel should go away.");
		}
	}

}
