﻿using UnityEngine;
using System.Collections;
using System;

public class StoryStory : MonoBehaviour {

	//The string the current story chapter is set to
	private string textStory;
	private string textTitle;

	//Total progress in shortStoryArray. Also gets assigned in PlayerPrefs as spoilersInt.
	private int storyChapter = 0;
	private int storyArch = 0;


	//Configs to get
	private string textForScreen;
	private string textForTitle;
	private ArrayList storyArray;
	private string[] storyTitleArray;

	// Use this for initialization
	void Start () 
	{
		GetStory();
		GetLabel();
		GetTitle();
		SetLabel();
		SetTitle();
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
		storyArch = PlayerPrefs.GetInt("spoilersArchInt");
		//Debug.Log ("This is the storyChapter: " + storyChapter);
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

	//Finds the game object title and sets temporary variable to story title text
	private void GetTitle ()
	{
		//Find and get the full stories Title array :D
		storyTitleArray = GameObject.Find ("UI Root").GetComponent<ShortStories>().storyTitlesArray;
		//Finds the game object title
		textForTitle = GameObject.Find("StoryTitle").GetComponent<UILabel>().text;
		//Sets current story title text to temp variable
		textTitle = storyTitleArray[storyArch];
		//Debug.Log("This is label text: " + textForScreen);
		textForTitle = textTitle;
		//Debug.Log("This is title text: " + textForTitle);
	}

	//Set the game object label to the current chapter text
	private void SetLabel ()
	{
		//Sets the game object label to the current story text
		GameObject.Find("StoryMessage").GetComponent<UILabel>().text = textForScreen;
	}

	//Set the game object label to the current chapter text
	private void SetTitle ()
	{
		//Sets the game object label to the current story text
		GameObject.Find("StoryTitle").GetComponent<UILabel>().text = textForTitle;
	}

	//Increments the next story arch and updates PlayerPref	
	private void StoryArchCompleteCheck ()
	{
		if(storyChapter%4 == 0)
		{
			Debug.Log("Memory Complete!!");
			//saves completed memory to playerPrefs
			PlayerPrefs.SetString(textForTitle, "completed");
			//Increments the next story arch 
			int nextChapter = (int)Mathf.Repeat(storyArch + 1, storyTitleArray.Length);
			//Updates PlayerPref
			PlayerPrefs.SetInt("spoilersArchInt", nextChapter);
			//Debug.Log ("This is the new storyArch: " + storyArch);
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
