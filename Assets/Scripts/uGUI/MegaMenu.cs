using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MegaMenu : MonoBehaviour {

	public GameObject GameplayPanel, SoundPanel, VideoPanel;
	public GameObject ControlPanel;
	private bool isOpen = false;

	// Use this for initialization
	private void Start () {
	
	}

	private void Update() {

		if(Input.GetKeyDown(KeyCode.Escape))
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

	private void closeMenu() {

		ControlPanel.SetActive(false);
		GameplayPanel.SetActive(false);
		SoundPanel.SetActive(false);
		VideoPanel.SetActive(false);
	}

	private void setupMenu() {
		ControlPanel.SetActive(true);
		toggleGameplay();
	}

	public void toggleGameplay () {

		GameplayPanel.SetActive(true);
		SoundPanel.SetActive(false);
		VideoPanel.SetActive(false);
	}

	public void toggleSoundPanel () {

		GameplayPanel.SetActive(false);
		SoundPanel.SetActive(true);
		VideoPanel.SetActive(false);

	}

	public void toggleVideoPanel () {

		GameplayPanel.SetActive(false);
		SoundPanel.SetActive(false);
		VideoPanel.SetActive(true);
	}

}
