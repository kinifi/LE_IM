using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class StoryTextBehaviour : MonoBehaviour {

	//Configs
	public float speed = 0.15f;

	//story GameObject configs
	private Text storyText;
	private int nextChar = 0;

	//story chapter configs
	private string storyString = "This is the text in the story. It is pretty cool!";
	private char[] storyChar;
	private int storyCharLength;

	// Use this for initialization
	void Start () 
	{
		Debug.Log ("We've started");
		storyText = GetComponent<Text>();

		storyChar = storyString.ToCharArray();
		storyCharLength = storyChar.Length;

		Debug.Log("The length of storyChar is: " + storyChar.Length);
		InvokeRepeating("PrintStory", 1.0f, speed);
	}
	
	// Update is called once per frame
	void PrintStory () 
	{
		if(nextChar < storyCharLength)
		{
			storyText.text += storyChar[nextChar];
			//Debug.Log ("This is i: " + storyChar[nextChar]);

			nextChar += 1;
		}
		else
		{
			OnComplete();
		}

	}

	void OnComplete()
	{
		CancelInvoke();
		Debug.Log ("We're finished!!!");
	}
}
