using UnityEngine;
using System.Collections;

public class MemoryPageLoad : MonoBehaviour {

	//Configs to see if the Memory is completed
	private MemoryEnableScript _memEnable;
	//Configs for the story Page
	private GameObject storyPage;
	private bool pageDisplayed = false;


	// Grabs the Memory Enable Script
	void Awake () 
	{
		_memEnable = GetComponent<MemoryEnableScript>();
	}
	
	// Turns off the story page when back is pressed
	void Update () 
	{
		if(pageDisplayed == true)
		{
			if(Input.GetButtonDown("Back") && pageDisplayed == true || Input.GetButtonDown("Confirm") && pageDisplayed == true)
			{
				storyPage.GetComponent<SpriteRenderer>().enabled = false;
				Invoke ("ResetPage", 0.5f);
			}
		}
	}

	//Gets called "On Click" Story selected is set in the inspector on the individual game objects
	public void AssignStoryPage (GameObject storySelected)
	{
		//sets name to string for switch input
		string pickStory = storySelected.name;
		//Debug.Log ("The pickStory value is: "+ pickStory);
		switch (pickStory)
		{
		case "Crash":
			//if the memory has been completed, calls the Crash Story Page
			if(_memEnable.Crash == true)
			{
				DisplayPage("CrashStoryPage");
				Debug.Log("Crash Story Should Display");
			}
			break;
		case "RobbetheShyKid":
			//if the memory has been completed, calls the Shy Kid Story Page
			if(_memEnable.RobbeTheShyKid == true)
			{
				DisplayPage("ShyKidStoryPage");
				Debug.Log("Shy Kid Story Should Display");
			}
			break;
		case "Jack":
			//if the memory has been completed, calls the Jack Story Page
			if(_memEnable.Jack == true)
			{
				DisplayPage("JackStoryPage");
				Debug.Log("Jack Story Should Display");
			}
			break;
		case "Archery":
			//if the memory has been completed, calls the Archery Story Page
			if(_memEnable.Archery == true)
			{
				DisplayPage("ArcheryStoryPage");
				Debug.Log("Archery Story Should Display");
			}
			break;
		case "TheGirlCousin":
			//if the memory has been completed, calls the Girl Cousin Story Page
			if(_memEnable.TheGirlCousin == true)
			{
				DisplayPage("TheGirlCousinStoryPage");
				Debug.Log("The Girl Cousin Story Should Display");
			}
			break;
		case "AllAlone":
			//if the memory has been completed, calls the All Alone Story Page
			if(_memEnable.AllAlone == true)
			{
				DisplayPage("AllAloneStoryPage");
				Debug.Log("All Alone Story Should Display");
			}
			break;
		case "MusicClass":
			//if the memory has been completed, calls the Music Class Story Page
			if(_memEnable.MusicClass == true)
			{
				DisplayPage("MusicClassStoryPage");
				Debug.Log("Music Class Story Should Display");
			}
			break;
		case "TheWalkHome":
			//if the memory has been completed, calls The Way Home Story Page
			if(_memEnable.TheWalkHome == true)
			{
				DisplayPage("TheWalkHomeStoryPage");
				Debug.Log("The Walk Home Story Should Display");
			}
			break;
		default:
			//Default message if something goes wrong
			Debug.Log ("Something went wrong assigning the story page");
			break;
		}

	}

	//called in switch
	private void DisplayPage (string storyToDisplay)
	{
		//takes the incoming and finds the corresponding game object
		storyPage = GameObject.Find(storyToDisplay);
		Debug.Log ("the page to display is: " + storyToDisplay);
		//displays the page
		if(pageDisplayed == false)
		{
			storyPage.GetComponent<SpriteRenderer>().enabled = true;
			Debug.Log ("This page should be displayed: " + storyPage.name);
			//sets pagedisplayed to true for the back button Update call
			pageDisplayed = true;
		}
	}

	//reset page
	private void ResetPage ()
	{
		pageDisplayed = false;
	}
}
