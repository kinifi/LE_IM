﻿using UnityEngine;
using System.Collections;

public class PauseScreen : MonoBehaviour {

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
		Panel.SetActive(false);
	}

	public void RespawnRobbe ()
	{
		GameObject respawnPosition = GameObject.Find ("Spawn_Location");
		Player.transform.position = respawnPosition.transform.position;
		Resume ();
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

	private void toggleCanFire ()
	{
		_canFire = !_canFire;
		GameObject.Find ("Player").GetComponent<Quiver>().canFire = _canFire;
	}
}
