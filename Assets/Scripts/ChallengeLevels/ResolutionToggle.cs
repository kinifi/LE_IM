using UnityEngine;
using System.Collections;

public class ResolutionToggle : MonoBehaviour {
	
	public UILabel resolutionLabel;
	private Resolution[] resolutions;
	private int ResValue = 0;
	private bool isDirty = false;
	
	
	// Use this for initialization
	void Start () {
		
		resolutionLabel.text = Screen.width + "," + Screen.height;
		getScreenResolutions();
		Debug.Log(resolutions.Length);
		Debug.Log(">>>>>>Current resolution");
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
		isDirty = true;
		
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
		if(isDirty)
		{
			if(Screen.fullScreen)
			{
				Screen.SetResolution(resolutions[ResValue].width, resolutions[ResValue].height, Screen.fullScreen);
			}
			else
			{
				Screen.SetResolution(resolutions[ResValue].width, resolutions[ResValue].height, !Screen.fullScreen);
			}
		}
		else
		{
			if(Screen.fullScreen)
			{
				Screen.SetResolution(Screen.currentResolution.width, Screen.currentResolution.height, Screen.fullScreen);
			}
			else
			{
				Screen.SetResolution(Screen.currentResolution.width, Screen.currentResolution.height, !Screen.fullScreen);
			}
		}
	}
	
}
