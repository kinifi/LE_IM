using UnityEngine;
using System.Collections;

public class ShortStories : MonoBehaviour {

	//Configs - each story needs a string and a string[];
	public ArrayList shortStoriesArray = new ArrayList();
	public int storyCount = 2;

	private string story1;
	private string[] story1Array;

	private string story2;
	private string[] story2Array;


	// Use this for initialization
	void Start () 
	{
		ParagraphForm();
		LoadStoriesToArray();
		//Debug.Log ("Short stories script complete");
	}

	private void ParagraphForm ()
	{
		//Story as paragraph
		story1 = @"They'd met in the kitchen. Married in the parlor. She'd miss the house, but lit the match anyway./
It felt uncomfortable, like putting on a shirt a size too small. He looked across at his old human body, now no more than a husk./
'What is this?' asked the little girl, flipping over the dusty pile.'It's a book,' said her mother, 'Sit here, I'll show you.'/
She held him. The small part that was well battled the giant illness inside her for enough time to just be his mom for awhile./
It cried for help. I held it in my hands. I ran for help. It was dying. Saw a drug store nearby. Luckily they had a phone charger.";
		//Convert to string array
		story1Array = story1.Split('/');
		//Debug.Log ("This is shortstoryarray1 element 0" + story1Array[0]);

		//Story as paragraph
		story2 = @"The house was dark. It felt it. He said, It's dim, and he laughed, but none of us did, because he was right, and we knew he would die first./
Toronto's been through the Fords anf this endless election and now Jiangate. At least the Leafs still suck./
We kissed under an azure sky. She texted a friend to tell her she was in love. Her friend was my ex. That was mean, I said. We kissed again./
They nuzzled by the fireplace. He said, Remember the night we met in Paris? But she had never been to Paris. Suddenly the fire felt too hot./
We went swimming. I fell in love. It was simple. But she wasn't in love. Not with me or with anyone else. I learned later she hated swimming.";
		//Convert to string array
		story2Array = story2.Split('/');
		//Debug.Log ("This is shortstoryarray2 element 0" + story2Array[0]);
	}

	private void LoadStoriesToArray ()
	{
		//Debug.Log ("LoadStories has started");
		for (int i = 0; i < story1Array.Length; i++)
		{
			string line = story1Array[i].ToString();
			//Debug.Log ("This is the value of line1: " + line);

			shortStoriesArray.Add(line);
			//Debug.Log ("This is shortstoriesarray: " + shortStoriesArray);
		}

		for (int i = 0; i < story2Array.Length; i++)
		{
			string line2 = story2Array[i].ToString();
			//Debug.Log ("This is the value of line1: " + line2);

			shortStoriesArray.Add(line2);
			//Debug.Log ("This is the second shortstoriesarray: " + shortStoriesArray);
		}
		Debug.Log ("This is the shortStoriesArray count: " + shortStoriesArray.Count);
	}
}
