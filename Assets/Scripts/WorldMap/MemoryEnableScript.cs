using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MemoryEnableScript : MonoBehaviour {

	//StatusStrings configs
	private string oneZeroStatus;
	private string oneOneStatus;
	private string oneTwoStatus;
	private string oneThreeStatus;
	private string oneFourStatus;
	private string oneFiveStatus;
	private string oneSixStatus;
	private string oneSevenStatus;
	private string oneEightStatus;
	private string oneNineStatus;
	private string oneTenStatus;
	private string oneElevenStatus;
	private string oneTwelveStatus;
	private string oneThirteenStatus;
	private string oneFourteenStatus;
	private string oneFifteenStatus;

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
	public bool TheForest;
	public bool IntoTheDark;
	public bool Fireflies;

	// Use this for initialization
	void Awake () 
	{
		//Set Story Zero Status 
		oneZeroStatus = "completed";
		GameObject.Find ("00_Crash").GetComponent<Image>().enabled = true;
		GameObject.Find("00_Crash").GetComponent<Button>().interactable = true;

		//Get PlayerPrefs for First Story
		oneOneStatus = PlayerPrefs.GetString("Robbe, The Shy Kid");
		//Turn on polaroid image and Set Story One bool to true if complete
		if(oneOneStatus == "completed")
		{
			GameObject.Find ("01_RobbeTheShyKid").GetComponent<Image>().enabled = true;
			GameObject.Find("01_RobbeTheShyKid").GetComponent<Button>().interactable = true;
			GameObject.Find("01").GetComponent<Image>().enabled = false;
		}

		//Get PlayerPrefs for Second Story
		oneTwoStatus = PlayerPrefs.GetString("Jack");
		//Turn on polaroid image and Set Story Two bool to true if complete
		if(oneTwoStatus == "completed")
		{
			GameObject.Find ("02_Jack").GetComponent<Image>().enabled = true;
			GameObject.Find("02_Jack").GetComponent<Button>().interactable = true;
			GameObject.Find ("02").GetComponent<Image>().enabled = false;
		}

		//Get PlayerPrefs for Third Story
		oneThreeStatus = PlayerPrefs.GetString("Archery");
		//Turn on polaroid image and Set Story Three bool to true if complete
		if(oneThreeStatus == "completed")
		{
			GameObject.Find ("03_Archery").GetComponent<Image>().enabled = true;
			GameObject.Find("03_Archery").GetComponent<Button>().interactable = true;
			GameObject.Find ("03").GetComponent<Image>().enabled = false;
		}
		//Get PlayerPrefs for Fourth Story
		oneFourStatus = PlayerPrefs.GetString("The Girl Cousin");
		//Turn on polaroid image and Set Story Four bool to true if complete
		if(oneFourStatus == "completed")
		{
			GameObject.Find ("04_TheGirlCousin").GetComponent<Image>().enabled = true;
			GameObject.Find("04_TheGirlCousin").GetComponent<Button>().interactable = true;
			GameObject.Find ("04").GetComponent<Image>().enabled = false;
		}
		//Get PlayerPrefs for Fifth Story
		oneFiveStatus = PlayerPrefs.GetString("All Alone");
		//Turn on polaroid image and Set Story Five bool to true if complete
		if(oneFiveStatus == "completed")
		{
			GameObject.Find ("05_AllAlone").GetComponent<Image>().enabled = true;
			GameObject.Find("05_AllAlone").GetComponent<Button>().interactable = true;
			GameObject.Find ("05").GetComponent<Image>().enabled = false;
		}
		//GetPlayerPrefs for Sixth Story
		oneSixStatus = PlayerPrefs.GetString("Music Class");
		//Turn on polaroid image and Set Story Six bool to true if complete
		if(oneSixStatus == "completed")
		{
			GameObject.Find ("06_MusicClass").GetComponent<Image>().enabled = true;
			GameObject.Find("06_MusicClass").GetComponent<Button>().interactable = true;
			GameObject.Find ("06").GetComponent<Image>().enabled = false;
		}
		//GetPlayerPrefs for Seventh Story
		oneSevenStatus = PlayerPrefs.GetString("The Walk Home");
		//Turn on polaroid image and Set Story Seven bool to true if complete
		if(oneSevenStatus == "completed")
		{
			GameObject.Find ("07_TheWalkHome").GetComponent<Image>().enabled = true;
			GameObject.Find("07_TheWalkHome").GetComponent<Button>().interactable = true;
			GameObject.Find ("07").GetComponent<Image>().enabled = false;
		}
		//GetPlayerPrefs for Eighth Story
		oneEightStatus = PlayerPrefs.GetString("The Bully");
		//Turn on polaroid image and Set Story Eight bool to true if complete
		if(oneEightStatus == "completed")
		{
			GameObject.Find ("08_TheBully").GetComponent<Image>().enabled = true;
			GameObject.Find("08_TheBully").GetComponent<Button>().interactable = true;
			GameObject.Find ("08").GetComponent<Image>().enabled = false;
		}
		//GetPlayerPrefs for Nineth Story
		oneNineStatus = PlayerPrefs.GetString("The Forest");
		//Turn on polaroid image and Set Story Nine bool to true if complete
		if(oneNineStatus == "completed")
		{
			GameObject.Find ("09_TheForest").GetComponent<Image>().enabled = true;
			GameObject.Find("09_TheForest").GetComponent<Button>().interactable = true;
			GameObject.Find ("09").GetComponent<Image>().enabled = false;
		}
		//GetPlayerPrefs for Tenth Story
		oneTenStatus = PlayerPrefs.GetString("Into the Dark");
		//Turn on polaroid image and Set Story Ten bool to true if complete
		if(oneTenStatus == "completed")
		{
			GameObject.Find ("10_IntoTheDark").GetComponent<Image>().enabled = true;
			GameObject.Find("10_IntoTheDark").GetComponent<Button>().interactable = true;
			GameObject.Find ("10").GetComponent<Image>().enabled = false;
		}
		//GetPlayerPrefs for Eleventh Story
		oneElevenStatus = PlayerPrefs.GetString("Fireflies");
		//Turn on polaroid image and Set Story Eleven bool to true if complete
		if(oneElevenStatus == "completed")
		{
			GameObject.Find ("11_Fireflies").GetComponent<Image>().enabled = true;
			GameObject.Find("11_Fireflies").GetComponent<Button>().interactable = true;
			GameObject.Find ("11").GetComponent<Image>().enabled = false;
		}
		//GetPlayerPrefs for Twelveth Story
		oneTwelveStatus = PlayerPrefs.GetString("Fighting the Dark");
		//Turn on polaroid image and Set Story Twelve bool to true if complete
		if(oneTwelveStatus == "completed")
		{
			GameObject.Find ("12_FightingTheDark").GetComponent<Image>().enabled = true;
			GameObject.Find("12_FightingTheDark").GetComponent<Button>().interactable = true;
			GameObject.Find ("12").GetComponent<Image>().enabled = false;
		}
		//GetPlayerPrefs for Thirteenth Story
		oneThirteenStatus = PlayerPrefs.GetString("Back to Camp");
		//Turn on polaroid image and Set Story Thirteen bool to true if complete
		if(oneThirteenStatus == "completed")
		{
			GameObject.Find ("13_BackToCamp").GetComponent<Image>().enabled = true;
			GameObject.Find("13_BackToCamp").GetComponent<Button>().interactable = true;
			GameObject.Find ("13").GetComponent<Image>().enabled = false;
		}
		//GetPlayerPrefs for Fourteenth Story
		oneFourteenStatus = PlayerPrefs.GetString("Brave At Last");
		//Turn on polaroid image and Set Story Fourteen bool to true if complete
		if(oneFourteenStatus == "completed")
		{
			GameObject.Find ("14_BraveAtLast").GetComponent<Image>().enabled = true;
			GameObject.Find("14_BraveAtLast").GetComponent<Button>().interactable = true;
			GameObject.Find ("14").GetComponent<Image>().enabled = false;
		}
	}
}
