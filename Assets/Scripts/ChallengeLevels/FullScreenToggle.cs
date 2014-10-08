using UnityEngine;
using System.Collections;

public class FullScreenToggle : MonoBehaviour {

	public UIToggle fullScreenToggle;

	// Use this for initialization
	void Start () {

		//fullScreenToggle.value = Screen.fullScreen;
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void changeToggleValue()
	{
		Screen.fullScreen = !Screen.fullScreen;
		Debug.Log("Toggle FullScreen: " + Screen.fullScreen);
	}
}
