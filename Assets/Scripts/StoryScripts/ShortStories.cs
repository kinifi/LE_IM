using UnityEngine;
using System.Collections;

public class ShortStories : MonoBehaviour {

	//Configs - each story needs a string and a string[];
	public ArrayList shortStoriesArray = new ArrayList();
	public int storyCount = 7;

	//BE SURE TO SET IN INSPECTOR!!!!!
	public string[] storyTitlesArray = new string[7] {"0", "1", "2", "3", "4", "5", "6"};


	public string storyTitle1;
	private string story1;
	private string[] story1Array;

	public string storyTitle2;
	private string story2;
	private string[] story2Array;

	public string storyTitle3;
	private string story3;
	private string[] story3Array;

	public string storyTitle4;
	private string story4;
	private string[] story4Array;

	public string storyTitle5;
	private string story5;
	private string[] story5Array;

	public string storyTitle6;
	private string story6;
	private string[] story6Array;

	public string storyTitle7;
	private string story7;
	private string[] story7Array;


	// Use this for initialization
	void Start () 
	{
		ParagraphForm();
		LoadStoriesToArray();
		LoadTitlesToArray();
		//Debug.Log ("Short stories script complete");
	}

	private void ParagraphForm ()
	{
		//Set Story Title
		storyTitle1 = "Robbe, the shy kid";
		//Story as paragraph
		story1 = @"Sitting alone made it easy to have a conversation with himself. 'I guess that's ONE perk of being shy,' Robbe said aloud./'Mom said 3rd grade would be easier for me. I've got multiplication down, but I'm no braver than a second grader. Sheesh. Maybe I'll always be shy.'/The thought of being shy forever terrified Robbe. It's not that the other kids scared him. He just felt invisible around them. Especially if SHE was in the room./'She' being Robbe's cousin. About the same age, they were opposites in every way. 'That girl is so annoying!' Robbe said aloud to no one. 'She thinks she's so cool.'/'She' was the one who had said he was shy. Robbe remembered it clearly from 2nd grade. 'Why are you always so shy?' But he would show her! Third grade would be different.";
		//Convert to string array
		story1Array = story1.Split('/');
		//Debug.Log ("This is shortstoryarray1 element 0" + story1Array[0]);

		//Set Story Title
		storyTitle2 = "Jack";
		//Story as paragraph
		story2 = @"'Talking to yourself again?' A disheveled-haired boy came up to him, kickball in hand. 'You're weird that way, but I don't mind.' Jack continued talking as he sat down./Jack had decided he was Robbe's best friend. Robbe didn't remember having a say in the matter, but he did enjoy Jack's company - even if Jack was the one who was a bit weird./Jack continued rambling on and Robbe only half listened. Something about the kickball tournament. Neither boy was very athletic, but Jack loved kickball./'Are you even listening?!' Jack asked, pulling Robbe away from his thoughts. 'You derp. Sometimes it's like you live in your head' Robbe half smiled in reply 'Ya sorry'/At that moment the bell rang. Recess was over. 'Aw! Back to dumb class.' Jack hated school. Their next class was PE and today's lesson was archery. Robbe loved archery.";
		//Convert to string array
		story2Array = story2.Split('/');
		//Debug.Log ("This is shortstoryarray2 element 0" + story2Array[0]);

		//Set Story Title
		storyTitle3 = "Archery";
		//Story as paragraph
		story3 = @"Robbe had tried archery for the first time at summer camp, and had loved it! Of course those bows and arrows were plastic, but these were real./Robbe followed Jack to the fields and waited with excitement. The teacher was going over safety, but Robbe's eyes stayed on the bow. 'It's a good day to be a 3rd grader.'/'Something to share with the class, Robbe?' The whole class was looking at him. Jack nudged him with his elbow. 'erm, no' The teacher looked vexed but handed Robbe a bow./The bow was in his hands. The teacher was talking again and motioned to come over '...demonstrate for the class.' Robbe took an arrow and stepped to the shooting line./Robbe nocked the arrow, took his stance, and drew back.  He could feel the string on the side of his face. Aim. Everyone was watching. Release...Thump! He hit the target!";
		//Convert to string array
		story3Array = story3.Split('/');
		//Debug.Log ("This is shortstoryarray3 element 0" + story3Array[0]);

		//Set Story Title
		storyTitle4 = "The girl cousin";
		//Story as paragraph
		story4 = @"The class cheered. At least that's the way Robbe saw it. 'Nice work' commented the teacher. 'But he didn't even hit the center' Robbe moaned. It was her, his girl cousin./Why does she always have to ruin everything? Robbe thought. The teacher was talking again - 'Hitting the target was good.' It made it worse. Now he looked weak. Shy and weak./She'd always made him look bad. She was the first to walk, first to talk, the first to make friends. She'd probably be the first to hit a bull's eye./Robbe knew his attitude wasn't entirely fair.  She just always managed to get under his skin. Stupid girl cousin. Now he was in a foul mood and it was all her fault./Robbe returned to stand by Jack. 'Where did you learn to shoot a bow?!' Jack asked with excitement, but Robbe was watching the girl cousin take a turn...bull's eye.";
		//Convert to string array
		story4Array = story4.Split('/');
		//Debug.Log ("This is shortstoryarray4 element 0" + story4Array[0]);

		//Set Story Title
		storyTitle5 = "All alone";
		//Story as paragraph
		story5 = @"The day ended and Robbe rode the bus home. He pulled out his game finally finding a bit of peace. Robbe's mom had bought it for him. He remembered that day vividly./They had gone for school supplies. As they passed the electronics he heard , “Hey there, Rob!' his Uncle said. Robbe rolled his eyes 'It's Robbe.'/The adults chatted as he shifted away towards the game. He progressed through challenge levels, defeated monsters in dungeons. Robbe had never felt more confident./Time passed and Robbe began to wonder if his Mom would ever stop - she was GONE! He looked around, but she was no where. All of a sudden, Robbe felt very much alone./He had turned back to the game ashamed of the tears in his eyes. Minutes seemed like years before she reappeared. Tears in her own eyes, she had ran to him 'I'm sorry Robbe!'";
		//Convert to string array
		story5Array = story5.Split('/');
		//Debug.Log ("This is shortstoryarray5 element 0" + story5Array[0]);

		//Set Story Title
		storyTitle6 = "Music Class";
		//Story as paragraph
		story6 = @"Robbe found himself in Music Class with Mrs. Louis. 'Today we will be discussing a favorite of mine, truly a classic! In the Hall of the Mountain King'/Jack rolled his eyes, but Mrs Louis saw and threatened to sit on him. Rumor had it she once sat on a student and the kid was never the same. Jack looked a little scared./'In the Norwegian play Peer Gynt a troll king rules in a mountain.' Mrs. Louis explained.  'A troll?! Cool!' Jack shouted. 'Yes indeed,' replied Mrs. Louis 'and his troll daughter.'/The way she said it made Robbe wonder if she knew the trolls personally. 'Now close your eyes and listen' Mrs. Louis pressed play on the stereo.  The song started slow and low then grew./With his eyes shut, Robbe could almost see the green troll king with his imps and wisps dancing about.  Somewhere in the distance Mrs. Louis was whispering 'tee-tee tee-tee tah.'";
		//Convert to string array
		story6Array = story6.Split('/');
		//Debug.Log ("This is shortstoryarray6 element 0" + story6Array[0]);

		//Set Story Title
		storyTitle7 = "The Walk Home";
		//Story as paragraph
		story7 = @"There was a short walk from the bus stop back to Robbe's house. Passed the back of a shop and an alley way, left down Elm Street, his house was second on the right./One day, Robbe noticed a group of older kids in the alley. Normally, he would have hurried past, but something or maybe it was someone, called for him to stop./'Hey, What are *you* looking at?' said a big kid with a stick in his hand. 'Um, nothing' Robbe replied, 'just walking home.' The big kid now towered over over Robbe 'Then get home.'/Robbe turned and left. He didn't need trouble, but felt he should have stayed. At home, he told his mom about the kids. 'Let's check it out later so you feel better' Mom said./After supper, they walked back to the ally. There midst the boxes was a dog...or what used to be a dog. Robbe's mom pulled him away but the sight would stay with him for a very long time.";
		//Convert to string array
		story7Array = story7.Split('/');
		//Debug.Log ("This is shortstoryarray7 element 0" + story7Array[0]);

		/*//Set Story Title
		storyTitle# = "";
		//Story as paragraph
		story# = @"";
		//Convert to string array
		story#Array = story#.Split('/');
		//Debug.Log ("This is shortstoryarray# element 0" + story#Array[0]);*/
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
			//Debug.Log ("This is the value of line2: " + line2);

			shortStoriesArray.Add(line2);
			//Debug.Log ("This is the second shortstoriesarray: " + shortStoriesArray);
		}

		for (int i = 0; i < story3Array.Length; i++)
		{
			string line3 = story3Array[i].ToString();
			//Debug.Log ("This is the value of line3: " + line3);
			
			shortStoriesArray.Add(line3);
			//Debug.Log ("This is the third shortstoriesarray: " + shortStoriesArray);
		}

		for (int i = 0; i < story4Array.Length; i++)
		{
			string line4 = story4Array[i].ToString();
			//Debug.Log ("This is the value of line4: " + line4);
			
			shortStoriesArray.Add(line4);
			//Debug.Log ("This is the fourth shortstoriesarray: " + shortStoriesArray);
		}

		for (int i = 0; i < story5Array.Length; i++)
		{
			string line5 = story5Array[i].ToString();
			//Debug.Log ("This is the value of line5: " + line5);
			
			shortStoriesArray.Add(line5);
			//Debug.Log ("This is the fifth shortstoriesarray: " + shortStoriesArray);
		}

		for (int i = 0; i < story6Array.Length; i++)
		{
			string line6 = story6Array[i].ToString();
			//Debug.Log ("This is the value of line7: " + line7);
			
			shortStoriesArray.Add(line6);
			//Debug.Log ("This is the sixth shortstoriesarray: " + shortStoriesArray);
		}

		for (int i = 0; i < story7Array.Length; i++)
		{
			string line7 = story7Array[i].ToString();
			//Debug.Log ("This is the value of line7: " + line7);
			
			shortStoriesArray.Add(line7);
			//Debug.Log ("This is the seventh shortstoriesarray: " + shortStoriesArray);
		}

		/*for (int i = 0; i < story#Array.Length; i++)
		{
			string line# = story#Array[i].ToString();
			//Debug.Log ("This is the value of line#: " + line#);
			
			shortStoriesArray.Add(line#);
			//Debug.Log ("This is the #### shortstoriesarray: " + shortStoriesArray);
		}*/
		Debug.Log ("This is the shortStoriesArray count: " + shortStoriesArray.Count);
	}

	private void LoadTitlesToArray()
	{
		storyTitlesArray[0] = storyTitle1;
		storyTitlesArray[1] = storyTitle2;
		storyTitlesArray[2] = storyTitle3;
		storyTitlesArray[3] = storyTitle4;
		storyTitlesArray[4] = storyTitle5;
		storyTitlesArray[5] = storyTitle6;
		storyTitlesArray[6] = storyTitle7;
		//storyTitleArray[#] = storyTitle#;
	}

}
