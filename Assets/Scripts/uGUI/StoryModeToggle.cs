using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class StoryModeToggle : MonoBehaviour {

	//Toggle Text Configs
	Text _onOffText;
	string startText;

	// Use this for initialization
	void Start () 
	{
		_onOffText =  GameObject.Find("OnOffText").GetComponent<Text>();
		//Debug.Log ("The game object _onOffText is: " + _onOffText);
		startText = PlayerPrefs.GetString("storyMode");
		Debug.Log ("This is the startText: " + startText);
		if(startText == "on")
		{
			GameObject.Find ("Toggle").GetComponent<Toggle>().isOn = true;
			_onOffText.text = "ON";
		}
		else if(startText == "off")
		{
			GameObject.Find ("Toggle").GetComponent<Toggle>().isOn = false;
			_onOffText.text = "OFF";
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	//Sets OnOffText on the toggle to off when unchecked
	public void SetToOffOrOn ()
	{
		if(_onOffText.text == "ON")
		{
			PlayerPrefs.SetString("storyMode", "off");
			_onOffText.text = "OFF";
			Debug.Log (PlayerPrefs.GetString("storyMode"));
		}
		else if (_onOffText.text == "OFF")
		{
			PlayerPrefs.SetString("storyMode", "on");
			_onOffText.text = "ON";
			Debug.Log (PlayerPrefs.GetString("storyMode"));
		}
	}

}
