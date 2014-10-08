using UnityEngine;
using System.Collections;

public class ResolutionToggle : MonoBehaviour {

	public UILabel resolutionLabel;
	private Resolution[] resolutions;
	private int ResValue = 0;

	// Use this for initialization
	void Start () {
	
		resolutionLabel.text = Screen.width + "," + Screen.height;
		getScreenResolutions();
		Debug.Log(resolutions.Length);
	}

	private void getScreenResolutions()
	{
		resolutions = Screen.resolutions;
		Debug.Log("Get Screen Resolutions");
	}

	private void updateLabel()
	{
		resolutionLabel.text = resolutions[ResValue].width + "," + resolutions[ResValue].height;
		//Debug.Log("Update Label value");
	}

	public void updateButtonLabel()
	{
		//Debug.Log("Before:" + ResValue);
		if(ResValue == resolutions.Length - 1)
		{
			ResValue = 0;
			updateLabel();
			//Debug.Log("After" + ResValue);
		}
		else
		{
			ResValue++;
			updateLabel();
			//Debug.Log("After" + ResValue);
		}

	}


	public void setResolution()
	{
		Screen.SetResolution(resolutions[ResValue].width, resolutions[ResValue].height, Screen.fullScreen);
	}
	
}
