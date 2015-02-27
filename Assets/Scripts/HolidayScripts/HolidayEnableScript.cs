using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HolidayEnableScript : MonoBehaviour {

	//Holiday temp variable configs
	private string holidayOne;
	private Color stampColorOne;

	// Use this for initialization
	void Awake () 
	{
		//Get holidayOne Status from player prefs and report it to the console
		holidayOne = PlayerPrefs.GetString("Vday2015");
		Debug.Log ("The status of Vday2015 is: " + holidayOne);
		//Get holidayOne base color
		stampColorOne = GameObject.Find ("Stamp_Vday2015").GetComponent<Image>().color;
		//Turn on stamp image if complete
		if(holidayOne == "completed")
		{
			stampColorOne.a = 255;
			GameObject.Find("Stamp_Vday2015").GetComponent<Image>().enabled = true;
		}
		else if(holidayOne != "completed")
		{
			Destroy(GameObject.Find("Stamp_Vday2015"));
		}
	}
}
