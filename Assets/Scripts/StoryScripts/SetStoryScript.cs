using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SetStoryScript : MonoBehaviour {

	//Components to get
	private Text _textTitle;
	StoryTextBehaviour _storySceneText;
	StoryTextBehaviour _prepForPrinting;

	//Components to set
	private string[] textStory;
	private int storyMarker = 0;

	//Set from playerPrefs
	private int storyChapter = 0;


	// Use this for initialization
	void Awake () 
	{
		_textTitle = GameObject.Find ("StoryTitleText").GetComponent<Text>();
		_storySceneText = GameObject.Find ("StorySceneText").GetComponent<StoryTextBehaviour>();
		_prepForPrinting = GameObject.Find("StorySceneText").GetComponent<StoryTextBehaviour>();
	}

	void Start ()
	{
		GetStory();
		SetText();
		_prepForPrinting.PrepForPrinting();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	//Grabs the current story chapter then calls the method to get text
	private void GetStory ()
	{
		storyChapter = PlayerPrefs.GetInt("storyChapter");
		//Debug.Log ("This is the storyChapter: " + storyChapter);
		storyMarker = PlayerPrefs.GetInt("storyMarker");
	}

	//Finds the game object title and sets temporary variable to story title text
	private void SetText ()
	{

		Debug.Log ("the story chapter is: " +storyChapter);
		//Sets current story title text to temp variable
		if(storyChapter<5)
		{
			_textTitle.text = "Robbe, The Shy Kid";
			textStory = new string[5] {"Sitting alone made it easy to have a conversation with himself. \"I guess that's ONE perk of being shy,\" Robbe said aloud.", "\"Mom said 3rd grade would be easier for me. I've got multiplication down, but I'm no braver than a second grader. Sheesh. Maybe I'll always be shy.\"", "The thought of being shy forever terrified Robbe. It's not that the other kids scared him. He just felt invisible around them. Especially if SHE was in the room.", "'She’ being Robbe's cousin. About the same age, they were opposites in every way. \"That girl is so annoying!\" Robbe said aloud to no one. \"She thinks she's so cool.\"", "'She’ was the one who had said he was shy. Robbe remembered it clearly from 2nd grade. \"Why are you always so shy?\" she had said, but he would show her! Third grade would be different."};
			_storySceneText.storyString = textStory[storyMarker];

			storyMarker = (int)Mathf.Repeat(storyMarker + 1, 5);
		}
		else if(storyChapter > 4 && storyChapter < 10)
		{
			_textTitle.text = "Jack";
			textStory = new string[5] {"\"Talking to yourself again?\" A disheveled-haired boy came up to him, kickball in hand. \"You’re weird that way, but I don’t mind.\" Jack continued talking as he sat down.", "Jack had decided he was Robbe's best friend. Robbe didn't remember having a say in the matter, but he did enjoy Jack's company - even if Jack was the one who was a bit weird.", "Jack continued rambling on and Robbe only half listened. Something about the kickball tournament. Neither boy was very athletic, but Jack loved kickball.", "\"Are you even listening?!\" Jack asked, pulling Robbe away from his thoughts. \"You derp. Sometimes it's like you live in your head\" Robbe half smiled in reply, \"Ya sorry.\"", "At that moment the bell rang. Recess was over. \"Aw! Back to dumb class.\" Jack hated school. Their next class was PE and today's lesson was archery. Robbe loved archery."};
			_storySceneText.storyString = textStory[storyMarker];
			
			storyMarker = (int)Mathf.Repeat(storyMarker + 1, 5);
		}
		else if(storyChapter > 9 && storyChapter < 15)
		{
			_textTitle.text = "Archery";
			textStory = new string[5] {"Robbe had tried archery for the first time at summer camp, and had loved it! Of course those bows and arrows were plastic, but these were real.", "Robbe followed Jack to the fields and waited with excitement. The teacher was going over safety, but Robbe's eyes stayed on the bow. \"It's a good day to be a 3rd grader.\"", "\"Something to share with the class, Robbe?\" The whole class was looking at him. Jack nudged him with his elbow. \"Erm, no.\" The teacher looked vexed but handed Robbe a bow.", "The bow was in his hands. The teacher was talking again and motioned to come over \"...demonstrate for the class.\" Robbe took an arrow and stepped to the shooting line.", "Robbe nocked the arrow, took his stance, and drew back.  He could feel the string on the side of his face. Aim. Everyone was watching. Release...Thump! He hit the target!"};
			_storySceneText.storyString = textStory[storyMarker];
			
			storyMarker = (int)Mathf.Repeat(storyMarker + 1, 5);
		}
		else if(storyChapter > 14 && storyChapter < 20)
		{
			_textTitle.text = "The Girl Cousin";
			textStory = new string[5] {"The class cheered. At least that's the way Robbe saw it. \"Nice work.\" commented the teacher. \"But he didn't even hit the center.\" Robbe moaned. It was her - his girl cousin.", "\"Why does she always have to ruin everything?\" Robbe thought. The teacher was talking again. Hitting the target was good, but she had to make it worse. Now, he looked weak. Shy and weak.", "She’d always made him look bad. She was the first to walk, the first to talk, the first to make friends. She’d probably be the first to hit a bull's eye.", "Robbe knew his attitude wasn't entirely fair. She just always managed to get under his skin. Stupid girl cousin. Now he was in a foul mood and it was all her fault.", "Robbe returned to stand by Jack. \"Where did you learn to shoot a bow?!\"Jack asked with excitement, but Robbe was watching his girl cousin take a turn with the bow. Of course, she hit the bull's eye."};
			_storySceneText.storyString = textStory[storyMarker];
			
			storyMarker = (int)Mathf.Repeat(storyMarker + 1, 5);
		}
		else if(storyChapter > 19 && storyChapter < 25)
		{
			_textTitle.text = "All Alone";
			textStory = new string[5] {"The day ended and Robbe rode the bus home. He pulled out his game, finally finding a bit of peace. Robbe's mom had bought it for him. He remembered that day vividly.", "They had gone for school supplies. As they passed the electronics he heard , \"Hey there , Rob!\"  from his Uncle. Robbe rolled his eyes, \"It's Robbe.\"", "The adults chatted as he shifted away towards the game. He easily progressed through challenge levels and defeated monsters in the dungeons. Robbe had never felt more confident.", "Time passed and Robbe began to wonder if his Mom would ever stop - she was GONE! He looked around, but she was no where. All of a sudden, Robbe felt very much alone.", "He had turned back to the game ashamed of the tears in his eyes. Minutes seemed like years before she reappeared. She had ran to him with tears in her own eyes, \"I'm so sorry Robbe!\""};
			_storySceneText.storyString = textStory[storyMarker];
			
			storyMarker = (int)Mathf.Repeat(storyMarker + 1, 5);
		}
		else if(storyChapter > 24 && storyChapter < 30)
		{
			_textTitle.text = "Music Class";
			textStory = new string[5] {"Robbe found himself in Music Class with Mrs. Louis. \"Today we will be discussing a favorite of mine, truly a classic! In the Hall of the Mountain King\"", "Jack rolled his eyes, but Mrs Louis saw and threatened to sit on him. Rumor had it she once sat on a student and the kid was never the same. Jack looked a little scared.", "\"In the Norwegian play Peer Gynt a troll king rules in a mountain.\" Mrs. Louis explained.  \"A troll?! Cool!\" Jack shouted. \"Yes indeed,\" replied Mrs. Louis \"and his troll daughter.\"", "The way she said it made Robbe wonder if she knew the trolls personally. \"Now close your eyes and listen\" Mrs. Louis pressed play on the stereo.  The song started slow and low, then grew.", "With his eyes shut, Robbe could almost see the green troll king with his imps and wisps dancing about.  Somewhere in the distance Mrs. Louis was whispering \"tee-tee, tee-tee, tah.\""};
			_storySceneText.storyString = textStory[storyMarker];
			
			storyMarker = (int)Mathf.Repeat(storyMarker + 1, 5);
		}
		else if(storyChapter > 29 && storyChapter < 35)
		{
			_textTitle.text = "The Walk Home";
			textStory = new string[5] {"There was a short walk from the bus stop back to Robbe's house. He walked passed the back of a shop and an alley way, took a left down Elm Street, and his house was second on the right.", "One day, Robbe noticed a group of older kids in the alley. Normally, he would have hurried past, but something or maybe it was someone, called for him to stop.", "\"Hey, What are YOU looking at?\" said a big kid with a stick in his hand. \"Um, nothing\" Robbe replied, just walking home.\" The big kid now towered over Robbe \"Then get home.\"", "Robbe turned and left. He didn't need trouble, but felt he should have stayed. He told his mom about the kids when he got home. \"Let's check it out later so you feel better\" Mom said.", "After supper, they walked back to the ally. There, amidst the boxes, was a dog...or what used to be a dog. Robbe's mom pulled him away but the sight would stay with him for a very long time."};
			_storySceneText.storyString = textStory[storyMarker];
			
			storyMarker = (int)Mathf.Repeat(storyMarker + 1, 5);
		}
		else if(storyChapter > 34 && storyChapter < 40)
		{
			_textTitle.text = "The Bully";
			textStory = new string[5] {"At Robbe's school, third and fourth grade had lunch together.  He wasn't sure why but all the fourth graders in his school were big...REALLY big and one of them was a bully.", "The Bully liked to push smaller kids around, sometimes he’d throw a punch, and he always called names.  Robbe was smaller and shy - a perfect target. Robbe made sure to stay away from him.", "On his way to lunch, Robbe past a 4th grade classroom.  The Bully was at a table with a robot.  When he pushed a button the eyes glowed red.  The Bully laughed, but when he looked up he saw Robbe.", "Robbe ran down the hall to the cafeteria. His girl cousin saw the whole thing. \"You should just stand up to him, Robbe\" she said.  \"I'd prefer to stay alive, thank you.\" Robbe replied.", "\"A bully will only get worse the longer you wait to stand up for yourself\" she said. Robbe turned and ignored her, but she was right and Robbe knew it. He needed to be brave."};
			_storySceneText.storyString = textStory[storyMarker];
			
			storyMarker = (int)Mathf.Repeat(storyMarker + 1, 5);
		}
		else if(storyChapter > 39 && storyChapter < 45)
		{
			_textTitle.text = "The Forest";
			textStory = new string[5] {"One week later, Robbe's school was hosting an overnight outdoor camping event for 3rd and 4th graders.  Robbe was especially excited because Archery was one of the events.", "Robbe's group had their tent set up and went to the woodpile at the edge of the forest clearing for firewood. Dusk was settling and the forest was dark. It seemed to get darker the closer they got.", "The sound of twigs snapping in the forest startled the group. \"What was that?!\" Jack gasped. \"Probably just a squirrel,\" Robbe replied, a little more confident than he felt.", "The little hairs pricked on the back of Robbe's neck. \"Come on, let's go\" he said to Jack. Both boys hurried back to the camp site with firewood in their arms.", "As the chaperone started a fire, Robbe couldn't help but look back towards the dark forest. He couldn't draw his eyes away. The forest seemed just as enchanted as it did scary."};
			_storySceneText.storyString = textStory[storyMarker];
			
			storyMarker = (int)Mathf.Repeat(storyMarker + 1, 5);
		}
		else if(storyChapter > 44 && storyChapter < 50)
		{
			_textTitle.text = "Into the Dark";
			textStory = new string[5] {"\"Let's kick the ball around, Robbe\" Jack suggested. \"It's dark,\" Robbe replied. \"There's enough moonlight. Come on!\" The moon was bright. \"Alright,\" Robbe conceded.", "The boys headed away from the fire and began passing the ball. \"I’ve got to work on my power kick\" Jack said and swung his leg hard to connect with the ball.", "The ball shot up in the air, but Jack fell flat on his back. \"Are you okay?!\" Robbe rushed over. \"Ha ha! Ya, I'm fine\" Jack replied still lying on the ground.", "\"Where is the ball?\" Both boys looked around but didn't see it anywhere. \"I’ll grab the flashlight, wait here\" Jack said, as he ran back to the camp site.", "The hairs on the back of Robbe's neck pricked again as Jack left. Turning towards the forest, Robbe felt his feet moving. He didn't remember telling them too."};
			_storySceneText.storyString = textStory[storyMarker];
			
			storyMarker = (int)Mathf.Repeat(storyMarker + 1, 5);
		}
		else if(storyChapter > 49 && storyChapter < 55)
		{
			_textTitle.text = "Fireflies";
			textStory = new string[5] {"Robbe suddenly found himself in the dark forest, alone. The air smelled damp. He felt the chilly night on his skin, and he thought he saw something flash.", "Out of the corner of his eye, Robbe saw a flash of light. He spun around to see what it was, but the forest was dark. The light had vanished. Robbe blinked, and flash!", "Forgetting the dark, Robbe followed the light deeper into the forest. Soon he was standing under a willow tree and there were dozens of little flashes. Fireflies!", "As Robbe stood watching, one of the fireflies landed on his hand. Startled, Robbe jumped a little. Then, he  slowly brought his hand up to inspect the bug.", "\"You’re not shy, are you?\" Robbe said to the little bug. The firefly lit up even brighter, as if in reply, before flying away. Robbe smiled then turned to head back."};
			_storySceneText.storyString = textStory[storyMarker];
			
			storyMarker = (int)Mathf.Repeat(storyMarker + 1, 5);
		}
		else if(storyChapter > 54 && storyChapter < 60)
		{
			_textTitle.text = "Fighting the Dark";
			textStory = new string[5] {"Robbe turned to head back, but which way was the camp? The darkness seemed to grow bigger and collapse in on him all at the same time. Lost.", "Robbe felt his heart start to race. Which way? Which way? Then, flash! The fireflies were fighting back the night. Robbe focused on the fireflies and he felt less afraid.", "Robbe began to move his feet, following the little flashes. He was starting to feel something. Something he had never felt before. Yes! Robbe was beginning to feel brave.", "The darkness seemed to shrink back farther with each step Robbe took. The fireflies continued to light the way and the forest trees began to clear.", "Robbe could just see the campsite when he heard Jack yelling. \"Robbe! There you are!!\" Jack was standing in the clearing with the kickball and flashlight."};
			_storySceneText.storyString = textStory[storyMarker];
			
			storyMarker = (int)Mathf.Repeat(storyMarker + 1, 5);
		}
		else if(storyChapter > 59 && storyChapter < 65)
		{
			_textTitle.text = "Back to Camp";
			textStory = new string[5] {"Robbe's girl cousin rushed over. \"Robbe!\" she seemed a bit worried as she gave him a hug. \"I didn't know where you had gone! I felt scared.\" \"Oh sorry, I was right here,\" Robbe lied.", "Still feeling the affects of the forest, Robbe realized everything would be different. He was brave now. \"Do you still want to kick the ball around?\" Robbe asked. \"No way! It's dark now and it's creepy\" Jack replied.", "\"Alright, let's head back\" Robbe said, leading the way. \"Something is different about you, Robbe\" said his cousin. Robbe kept walking, but looked back towards the forest. He saw a flash, and smiled.", "\"Well if it isn't a bunch of 3rd graders.\" It was the 4th grade bully, the big one. \"Leave us alone\" Robbe was saying, but the bully hit the ball out of Jack's arm and it flew into the dark.", "\"You bully!\" Jack exclaimed. Robbe chased after the ball. It had rolled down a ditch and popped up onto the road leading into the camp. Robbe raced to grab it. There was a loud squeal, and the darkness took over."};
			_storySceneText.storyString = textStory[storyMarker];
			
			storyMarker = (int)Mathf.Repeat(storyMarker + 1, 5);
		}
		else if(storyChapter == 65)
		{
			_textTitle.text = "Brave At Last";
			_storySceneText.storyString = @"The darkness seemed to fade a little, but everything was strange. Robbe could see the edge of the forest through an unearthly fog. There were lights, but not fireflies. Instead the lights seemed to loom in the distance, disappearing and reappearing. 

'Where am  I?'

'What is this place?'

'I have to figure out how I got here.'

Robbe headed into the forest, determined and brave at last.";
		}
		else
		{
			_textTitle.text = "Another Memory to Remember";
			_storySceneText.storyString = "It would be super awesome if you could let the dev's know something went wrong with the story scene! :D ";
			Debug.Log ("Something has gone wrong with the SetText method in the SetStoryScript.");
		}

		StoryArchCompleteCheck ();
		SetNextChapter();
	}

	//Increments the next story arch and updates PlayerPref	
	private void StoryArchCompleteCheck ()
	{
		if(storyChapter%4 == 0)
		{
			//Unlock Achievement
			SteamManager.StatsAndAchievements.Unlock_Check_the_Memory_Book();
			Debug.Log("Memory Complete!!");
			//saves completed memory to playerPrefs
			PlayerPrefs.SetString(_textTitle.text, "completed");
			PlayerPrefs.SetInt("storyMarker", storyMarker);
			//Debug.Log ("This is the new storyMarker: " + storyMarker);
		}
	}
	
	//Increments the next chapter and updates PlayerPref
	private void SetNextChapter()
	{
		//Increments the next chapter 
		int nextChapter = (int)Mathf.Repeat(storyChapter + 1, 65);
		//Updates PlayerPref
		PlayerPrefs.SetInt("storyChapter", nextChapter);
		//Debug.Log ("This is the new storyChapter: " + storyChapter);
	}
}
