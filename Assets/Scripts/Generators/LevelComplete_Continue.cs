using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LevelComplete_Continue : MonoBehaviour {

	//Fade configs
	private Image _fadeCanvas;
	private bool fade = false;
	private float timer = 0;

	//Grab inventory configs
	private int _bows; 
	private int _keys;
	private int _completed;

	//basic config
	private bool hasCollided = false;

	void Update ()
	{
		//fades the black canvas in
		if(fade == true)
		{
			timer += Time.deltaTime;
			//set current color to a temp variable
			Color colorForCanvas = _fadeCanvas.color;
			//Lerp the alpha
			colorForCanvas.a = Mathf.Lerp(0,128,timer);
			//set canvas color to the temp value
			_fadeCanvas.color = colorForCanvas;
		}
	}

	void OnTriggerEnter2D (Collider2D Player) 
	{
		Debug.Log ("The exit door has been colided by!!! "+Player);
		if(Player.gameObject.tag == "Player")
		{
			if(hasCollided == false)
			{
				hasCollided = true;
				FadeToBlack();
				//Get current inventory and call the set method
				_bows = GameObject.Find("Player").GetComponent<Inventory>().Arrows;
				_keys = GameObject.Find("Player").GetComponent<Inventory>().Keys;
				SetInventoryToPlayerPref (_bows, _keys, _completed);

				//Start Story Scene
				LoadStoryScreen();
			}
		}
	}

	private void FadeToBlack ()
	{
		//set the canvas to enabled and fade the canvas in
		_fadeCanvas = GameObject.Find ("FadeToBlack_Canvas").GetComponent<Image>();
		_fadeCanvas.enabled = true;
		fade = true;
	}

	private void LoadStoryScreen()
	{
		Application.LoadLevel("StoryScene");
	}

	//Set current inventory to player prefs
	private void SetInventoryToPlayerPref (int bows, int keys, int completed)
	{
		PlayerPrefs.SetInt("bow", bows);
		PlayerPrefs.SetInt("keys", keys);
		PlayerPrefs.SetInt("completed", completed);
	}

}