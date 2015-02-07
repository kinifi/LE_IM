using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class StoryTextBehaviour : MonoBehaviour {

	//Configs
	public float scale = 10.0f;
	public float speed = 1.0f;

	private Text storyText;
	private string storyString = "This is the text in the story. It is pretty cool!";
	private char[] storyChar;

	// Use this for initialization
	void Start () 
	{
		Debug.Log ("We've started");
		storyText = GetComponent<Text>();
		Debug.Log ("The value of storyText is: " + storyText.text);
		storyChar = storyString.ToCharArray();
	}
	
	// Update is called once per frame
	void Update () 
	{
		for( int i = 0; i < storyChar.Length; i++)
		{
			//storyText.GetComponent<TextGenerator>() .Populate(storyChar[i]);
			Debug.Log ("This is i: " + storyChar[i]);
		}
	}
}
