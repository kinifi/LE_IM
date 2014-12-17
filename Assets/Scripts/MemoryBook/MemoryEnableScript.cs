using UnityEngine;
using System.Collections;

public class MemoryEnableScript : MonoBehaviour {

	//StatusStrings configs
	private string oneOneStatus;
	private string oneTwoStatus;
	private string oneThreeStatus;
	private string oneFourStatus;
	private string oneFiveStatus;
	private string oneSixStatus;
	private string oneSevenStatus;
	private string oneEightStatus;
	private string oneNineStatus;

	//MemoryPageBool configs
	public bool Crash;
	public bool RobbeTheShyKid;
	public bool Jack;
	public bool Archery;
	public bool TheGirlCousin;
	public bool AllAlone;
	public bool MusicClass;
	public bool TheWalkHome;
	public bool TheBully;

	// Use this for initialization
	void Awake () 
	{
		//Set Story One Status 
		oneOneStatus = "completed";
		//Set Story One bool to true if complete
		if(oneOneStatus == "completed")
		{
			GameObject.Find ("CrashMemoryImage").GetComponent<SpriteRenderer>().enabled = true;
			GameObject.Find ("CrashLabel").GetComponent<UILabel>().enabled = false;
			Crash = true;
		}

		//Get PlayerPrefs for Second Story
		oneTwoStatus = PlayerPrefs.GetString("Robbe, the shy kid");
		//Turn on polaroid image and Set Story Two bool to true if complete
		if(oneTwoStatus == "completed")
		{
			GameObject.Find ("ShyKidMemoryImage").GetComponent<SpriteRenderer>().enabled = true;
			GameObject.Find ("ShyKidLabel").GetComponent<UILabel>().enabled = false;
			RobbeTheShyKid = true;
		}

		//Get PlayerPrefs for Third Story
		oneThreeStatus = PlayerPrefs.GetString("Jack");
		//Turn on polaroid image and Set Story Three bool to true if complete
		if(oneThreeStatus == "completed")
		{
			GameObject.Find ("JackMemoryImage").GetComponent<SpriteRenderer>().enabled = true;
			GameObject.Find ("JackLabel").GetComponent<UILabel>().enabled = false;
			Jack = true;
		}
		//Get PlayerPrefs for Fourth Story
		oneFourStatus = PlayerPrefs.GetString("Archery");
		//Turn on polaroid image and Set Story Four bool to true if complete
		if(oneFourStatus == "completed")
		{
			GameObject.Find ("ArcheryMemoryImage").GetComponent<SpriteRenderer>().enabled = true;
			GameObject.Find ("ArcheryLabel").GetComponent<UILabel>().enabled = false;
			Archery = true;
		}
		//Get PlayerPrefs for Fifth Story
		oneFiveStatus = PlayerPrefs.GetString("The girl cousin");
		//Turn on polaroid image and Set Story Five bool to true if complete
		if(oneFiveStatus == "completed")
		{
			GameObject.Find ("TheGirlCousinMemoryImage").GetComponent<SpriteRenderer>().enabled = true;
			GameObject.Find ("TheGirlCousinLabel").GetComponent<UILabel>().enabled = false;
			TheGirlCousin = true;
		}
		//GetPlayerPrefs for Sixth Story
		oneSixStatus = PlayerPrefs.GetString("All alone");
		//Turn on polaroid image and Set Story Six bool to true if complete
		if(oneSixStatus == "completed")
		{
			GameObject.Find ("AllAloneMemoryImage").GetComponent<SpriteRenderer>().enabled = true;
			GameObject.Find ("AllAloneLabel").GetComponent<UILabel>().enabled = false;
			AllAlone = true;
		}
		//GetPlayerPrefs for Seventh Story
		oneSevenStatus = PlayerPrefs.GetString("Music Class");
		//Turn on polaroid image and Set Story Seven bool to true if complete
		if(oneSevenStatus == "completed")
		{
			Debug.Log("Memory 7");
			GameObject.Find ("MusicClassMemoryImage").GetComponent<SpriteRenderer>().enabled = true;
			GameObject.Find ("MusicClassLabel").GetComponent<UILabel>().enabled = false;
			MusicClass = true;
		}
		//GetPlayerPrefs for Eighth Story
		oneEightStatus = PlayerPrefs.GetString("The Walk Home");
		//Turn on polaroid image and Set Story Eight bool to true if complete
		if(oneEightStatus == "completed")
		{
			Debug.Log("Memory 8");
			GameObject.Find ("TheWalkHomeMemoryImage").GetComponent<SpriteRenderer>().enabled = true;
			GameObject.Find ("TheWalkHomeLabel").GetComponent<UILabel>().enabled = false;
			TheWalkHome = true;
		}
		//GetPlayerPrefs for Nineth Story
		oneNineStatus = PlayerPrefs.GetString("The Bully");
		//Turn on polaroid image and Set Story Nine bool to true if complete
		if(oneNineStatus == "completed")
		{
			Debug.Log("Memory 9");
			GameObject.Find ("TheBullyMemoryImage").GetComponent<SpriteRenderer>().enabled = true;
			GameObject.Find ("TheBullyLabel").GetComponent<UILabel>().enabled = false;
			TheBully = true;
		}
	}
}
