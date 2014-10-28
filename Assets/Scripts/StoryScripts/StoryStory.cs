using UnityEngine;
using System.Collections;
using System;

public class StoryStory : MonoBehaviour {

	//The string the current story chapter is set to
	private string textStory;

	//Total progress in shortStoryArray. Also gets assigned in PlayerPrefs as spoilersInt.
	private int storyChapter = 0;


	//Configs to get
	private string textForScreen;
	private ArrayList storyArray;

	// Use this for initialization
	void Start () 
	{
		GetStory();
		GetLabel();
		SetLabel();
		StoryArchCompleteCheck();
		SetNextChapter();
	}

	//Grabs the current story chapter then calls the method to get text
	private void GetStory ()
	{
		storyChapter = PlayerPrefs.GetInt("spoilersInt");
		//Debug.Log ("This is the storyChapter: " + storyChapter);
		Stories ();  
		//Debug.Log ("This is the textStory: " + textStory);
	}

	//Get full short story and set variable to current chapter text.
	private void Stories()
	{
		//Find and get the full stories array :D
		storyArray = GameObject.Find ("UI Root").GetComponent<ShortStories>().shortStoriesArray;
		Debug.Log ("This is the array count: " + storyArray.Count);
		//Set the textStory to the current story text
		textStory = (string) storyArray[storyChapter];
	}

	//Finds the game object label and sets temporary variable to chapter text
	private void GetLabel ()
	{
		//Finds the game object label
		textForScreen = GameObject.Find("StoryMessage").GetComponent<UILabel>().text;
		//Sets current story chapter text to temp variable
		textForScreen = textStory;
		//Debug.Log("This is label text: " + textForScreen);
	}

	//Set the game object label to the current chapter text
	private void SetLabel ()
	{
		//Sets the game object label to the current story text
		GameObject.Find("StoryMessage").GetComponent<UILabel>().text = textForScreen;
	}

	//Upkeep
	private void StoryArchCompleteCheck ()
	{
		if(storyChapter%4 == 0)
		{
			Debug.Log("Memory Complete!!");
		}
	}
	//Increments the next chapter and updates PlayerPref
	private void SetNextChapter()
	{
		//Increments the next chapter 
		int nextChapter = (int)Mathf.Repeat(storyChapter + 1, storyArray.Count);
		//Updates PlayerPref
		PlayerPrefs.SetInt("spoilersInt", nextChapter);
		//Debug.Log ("This is the new storyChapter: " + storyChapter);
	}

}
