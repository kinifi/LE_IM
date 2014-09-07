using UnityEngine;
using System.Collections;

public class Options : MonoBehaviour {
	
	public bool isJustLoader;
	private bool ToggleValue = true;
	public UIToggle myToggle;
	private string tempVal;

	// Use this for initialization
	void Start () {

		if(PlayerPrefs.HasKey("Audio"))
	   	{
			tempVal = PlayerPrefs.GetString("Audio");
		}
		else
		{
			PlayerPrefs.SetString("Audio", "True");
		}

		changeVolume();
	}

	private void changeVolume()
	{

		if(tempVal == "True")
		{
			AudioListener.volume = 1.0f;
			changeUIToggle();
		}
		else
		{
			AudioListener.volume = 0.0f;
			changeUIToggle();
		}

	}

	public void changeValue()
	{
		ToggleValue = !ToggleValue;
		changeVolume();
	}

	private void changeUIToggle()
	{
		if(ToggleValue)
		{
			PlayerPrefs.SetString("Audio", "True");
			if(!isJustLoader)
			{
				myToggle.value = true;
			}
			Debug.Log("Audio: " + "True");
		}
		else
		{
			PlayerPrefs.SetString("Audio", "False");
			if(!isJustLoader == false)
			{
				myToggle.value = false;
			}
			Debug.Log("Audio: " + "False");
		}
	}


}
