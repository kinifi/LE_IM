using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class backToEditMode : MonoBehaviour {

	public bool m_canTakeInput = false;
	public Button[] buttonsToActivate;
	public GameObject selfPanel, Player;

	// Use this for initialization
	void Start () {

	}

	public void readyEscapeButton()
	{
		m_canTakeInput = true;
	}

	private void Update()
	{
		if(Input.GetKeyDown(KeyCode.Escape))
		{
			if(m_canTakeInput)
			{
				inputDetection();
			}
		}
	}

	private void inputDetection()
	{
		m_canTakeInput = false;
		GameObject _BG = GameObject.Find("BG");
		GameObject _TileSelection = GameObject.Find("TileSelection");
		_BG.GetComponent<Animator>().SetTrigger("MoveIn");
		_TileSelection.GetComponent<Animator>().SetTrigger("MoveIn");
		selfPanel.SetActive(false);

		GameObject.Find("Main Camera").GetComponent<CameraController>().disableTarget();
		Player.SetActive(false);

		for (int i = 0; i < buttonsToActivate.Length; i++) 
		{
			buttonsToActivate[i].interactable = true;
		}

	}

}
