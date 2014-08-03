using UnityEngine;
using System.Collections;

public class PauseScreen : MonoBehaviour {

	public GameObject Panel;
	public GameObject cam;
	public GameObject Player;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

		if(Input.GetButtonDown("Fire2"))
		{
			togglePanel();
		}
	
	}

	public void goToMain()
	{
		Application.LoadLevel("Main_Menu");
	}

	public void Resume()
	{
		togglePlayerMovement();
		toggleCameraMovement();
		changeVectorOffSet(0);
		Panel.SetActive(false);
	}

	private void togglePlayerMovement()
	{
		FakeRobbeController _robbe = Player.GetComponent<FakeRobbeController>();
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
			toggleCameraMovement();
			Panel.SetActive(true);
			changeVectorOffSet(-50);
		}
		else
		{
			togglePlayerMovement();
			toggleCameraMovement();
			changeVectorOffSet(0);
			Panel.SetActive(false);
		}
	}
}
