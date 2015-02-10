using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class StoryModeToggle : MonoBehaviour {

	//Toggle Text Configs
	Text _onOffText;

	// Use this for initialization
	void Start () 
	{
		_onOffText =  GameObject.Find("OnOffText").GetComponent<Text>();
		//Debug.Log ("The game object _onOffText is: " + _onOffText);
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	//Sets OnOffText on the toggle to off when unchecked
	public void SetToOffOrOn ()
	{
		if(_onOffText.text == "ON")
		{
			_onOffText.text = "OFF";
			PlayerPrefs.SetString("storyMode", "off");
			Debug.Log (PlayerPrefs.GetString("storyMode"));
		}
		else if (_onOffText.text == "OFF")
		{
			_onOffText.text = "ON";
			PlayerPrefs.SetString("storyMode", "on");
			Debug.Log (PlayerPrefs.GetString("storyMode"));
		}
	}

}
