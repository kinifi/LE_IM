using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class StoryTextBehaviour : MonoBehaviour {

	//Configs
	public float scale = 10.0f;
	public float speed = 1.0f;

	private TextMesh storyText;
	private string storyString = "This is the text in the story. It is pretty cool!";
	private char[] storyChar;
	private int storyCharLength;

	// Use this for initialization
	void Start () 
	{
		Debug.Log ("We've started");
		storyText = GetComponent<TextMesh>();
		storyChar = storyString.ToCharArray();
		storyCharLength = storyChar.Length;

		Debug.Log("The length of storyChar is: " + storyChar.Length);
		PrintStory();
	}
	
	// Update is called once per frame
	void PrintStory () 
	{
		for( int i = 0; i < storyCharLength; i++)
		{
			storyText.text += storyChar[i];
			Debug.Log ("This is i: " + storyChar[i]);
		}

	}
}
