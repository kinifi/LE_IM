using UnityEngine;
using System.Collections;

public class ShortStories : MonoBehaviour {

	//NOTE!!!!!!!! Be sure to change the if statement for the title in StoryStory.cs <-----------!!!
	//Configs - each story needs a string and a string[];
	public ArrayList shortStoriesArray = new ArrayList();
	public int storyCount = 11;

	//BE SURE TO SET IN INSPECTOR!!!!! <-----------!!!
	public string[] storyTitlesArray = new string[11] {"0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "10"};


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

	public string storyTitle8;
	private string story8;
	private string[] story8Array;

	public string storyTitle9;
	private string story9;
	private string[] story9Array;

	public string storyTitle10;
	private string story10;
	private string[] story10Array;

	public string storyTitle11;
	private string story11;
	private string[] story11Array;


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

		//Set Story Title
		storyTitle8 = "The Bully";
		//Story as paragraph
		story8 = @"At Robbe's school, third and fourth grade had lunch together.  He wasn't sure why but all the fourth graders in his school were big...REALLY big and one of them was a bully./The Bully liked to push smaller kids around, sometimes he'd throw a punch, and he always called names.  Robbe was smaller and shy - a perfect target. Robbe made sure to stay away from him./On his way to lunch, Robbe past a 4th grade classroom.  The Bully was at a table with a robot.  When he pushed a button the eyes glowed red.  The Bully laughed, but when he looked up he saw Robbe./Robbe ran down the hall to the cafeteria.  His girl cousin saw the whole thing and said 'You should just stand up to him, Robbe'  'I'd prefer to stay alive, thank you.' Robbe replied./'A bully is only going to get worse the longer you wait to stand up for yourself' she said.  Robbe turned and ignored her, but she was right and Robbe knew it. He needed to be brave.";
		//Convert to string array
		story8Array = story8.Split ('/');
		//Debug.Log("This is shortstoryarray8 element 0" + story8Array[0]);

		//Set Story Title
		storyTitle9 = "The Forest";
		//Story as paragraph
		story9 = @"One week later, Robbe's school was hosting an overnight outdoor camping event for 3rd and 4th graders.  Robbe was especially excited because Archery was one of the events./Robbe's group had their tent set up and went to the woodpile at the edge of the forest clearing for fire wood. Dusk was settling and the forest was dark as they reached the woodpile./They heard the sound of twigs snapping in the forest. 'What was that?!' Jack gasped, startled. 'Probably just a squirrel,' Robbe replied, a little more confident than he felt./The little hairs pricked on the back of Robbe's neck. 'Come on, lets go' he said to Jack. Both boys hurried back to the camp site with the firewood in their arms./The chaperone started a fire. Robbe couldnt help but look back towards the dark forest. He couldnt draw his eyes away. The forest seemed just as enchanted as it did scary.";
		//Convert to string array
		story9Array = story9.Split('/');
		//Debug.Log ("This is shortstoryarray9 element 0" + story9Array[0]);

		//Set Story Title
		storyTitle10 = "Into The Dark";
		//Story as paragraph
		story10 = @"'Let's kick the ball around, Robbe' Jack suggested. 'It's dark,' Robbe replied. 'There's enough moonlight. Come on!' The moon was bright. 'Alright,' Robbe conceded./The boys headed away from the fire and began passing the ball.  'I've got to work on my power kick' Jack said and swung his leg hard to connect with the ball./The ball shot up in the air, but jack fell flat on his back. 'Are you okay?!' Robbe rushed over. 'Ha ha! Ya, I'm fine' Jack replied still lying on the ground./'Where is the ball?' Both boys looked around but didn't see it anywhere.  'I'll grab the flashlight, wait here' Jack said as he turned back to the camp site./The hairs on the back of Robbe's neck pricked again as Jack left. Turning towards the forest, Robbe felt his feet moving. He didn't remember telling them too.";
		//Convert to string array
		story10Array = story10.Split('/');
		//Debug.Log ("This is shortstoryarray10 element 0" + story10Array[0]);

		//Set Story Title
		storyTitle11 = "Fireflies";
		//Story as paragraph
		story11 = @"Robbe suddenly found himself in the dark forest, alone. The air smelled damp. He felt the chilly night on his skin, and he thought he saw something flash./Out of the corner of his eye, Robbe saw a flash of light. He spun around to see what it was but the forest was dark. The light had vanished. Robbe blinked, and flash!/Forgetting the dark, Robbe followed the light deeper into the forest. Soon he was standing under a willow tree and there were dozens of little flashes. Fireflies!/As Robbe stood watching, one of the fireflies landed on his hand. Startled, Robbe jumped a little. Then, he  slowly brought his hand up to inspect the bug./'You're not shy, are you?' Robbe said to the little bug. As if in reply, the firefly lit up even brighter before flying away. Robbe smiled then turned to head back.";
		//Convert to string array
		story11Array = story11.Split('/');
		//Debug.Log ("This is shortstoryarray11 element 0" + story11Array[0]);

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
		for (int i = 0; i < story8Array.Length; i++)
		{
			string line8 = story8Array[i].ToString();
			//Debug.Log ("This is the value of line8: " + line8);
			
			shortStoriesArray.Add(line8);
			//Debug.Log ("This is the eighth shortstoriesarray: " + shortStoriesArray);
		}
		for (int i = 0; i < story9Array.Length; i++)
		{
			string line9 = story9Array[i].ToString();
			//Debug.Log ("This is the value of line9: " + line9);
			
			shortStoriesArray.Add(line9);
			//Debug.Log ("This is the nineth shortstoriesarray: " + shortStoriesArray);
		}
		for (int i = 0; i < story10Array.Length; i++)
		{
			string line10 = story10Array[i].ToString();
			//Debug.Log ("This is the value of line10: " + line10);
			
			shortStoriesArray.Add(line10);
			//Debug.Log ("This is the tenth shortstoriesarray: " + shortStoriesArray);
		}
		for (int i = 0; i < story11Array.Length; i++)
		{
			string line11 = story11Array[i].ToString();
			//Debug.Log ("This is the value of line11: " + line11);
			
			shortStoriesArray.Add(line11);
			//Debug.Log ("This is the eleventh shortstoriesarray: " + shortStoriesArray);
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
		storyTitlesArray[7] = storyTitle8;
		storyTitlesArray[8] = storyTitle9;
		storyTitlesArray[9] = storyTitle10;
		storyTitlesArray[10] = storyTitle11;

		//storyTitleArray[#] = storyTitle#;
	}

}
