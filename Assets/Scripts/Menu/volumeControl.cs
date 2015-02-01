using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class volumeControl : MonoBehaviour {

	public UISlider volValue;
	public Slider _slider;

	// Use this for initialization
	void Start () {
		if(PlayerPrefs.HasKey("volume"))
		{
			if(_slider != null)
			{
				_slider.value = PlayerPrefs.GetFloat("volume");
			}
			else
			{
				volValue.value = PlayerPrefs.GetFloat("volume");
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void changeVolume()
	{
		if(_slider != null)
		{
			AudioListener.volume = _slider.value;
			PlayerPrefs.SetFloat("volume", _slider.value);
		}
		else
		{
			AudioListener.volume = volValue.value;
			PlayerPrefs.SetFloat("volume", volValue.value);
		}
	}
}
