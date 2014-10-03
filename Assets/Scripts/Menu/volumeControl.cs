using UnityEngine;
using System.Collections;

public class volumeControl : MonoBehaviour {

	public UISlider volValue;

	// Use this for initialization
	void Start () {
		if(PlayerPrefs.HasKey("volume"))
		{
			volValue.value = PlayerPrefs.GetFloat("volume");
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void changeVolume()
	{
		AudioListener.volume = volValue.value;
		PlayerPrefs.SetFloat("volume", volValue.value);
	}
}
