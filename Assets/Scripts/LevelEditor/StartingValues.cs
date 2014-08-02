using UnityEngine;
using System.Collections;
using Steamworks;

public class StartingValues : MonoBehaviour {

	public GUISkin skin;
	public string levelName;
	public GUIText messageText;
	public bool hasEnteredInformation = false;
	public bool isLoading = false;

	private Vector2 scrollPosition;

	//preview vars
	private Texture2D previewTexture;
	private bool levelToPreviewIsSelected = false;

	// Use this for initialization
	void Start () {

		DontDestroyOnLoad(this.gameObject);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI() {

		GUI.skin = skin;

		GUILayout.BeginArea(new Rect(0, 0, Screen.width/4, Screen.height));

		createNewLevelGUI();

		showUserLevelNames();

		GUILayout.EndArea();


		GUILayout.BeginArea(new Rect(Screen.width/4, 0, Screen.width - Screen.width/4 ,Screen.height));

		showSelectedLevel();

		GUILayout.EndArea();
	}

	private void showSelectedLevel () {
		if(levelToPreviewIsSelected)
		{
			//show the selected Level picture here
			GUILayout.Label(previewTexture, GUILayout.Height(Screen.height-100), GUILayout.Width(Screen.width - Screen.width/4));

			if(GUILayout.Button("Play " + levelName, GUILayout.Height(30)))
			{
				Debug.Log("Play this new level" + levelName);
			}

			if(GUILayout.Button("Edit Selected Level : " + levelName, GUILayout.Height(30)))
			{
				Debug.Log("Load this new level" + levelName);
				isLoading = true;
			}
			
		}
	}


	private void showUserLevelNames() {

		if(!hasEnteredInformation)
		{
			GUILayout.Space(10);
			GUILayout.Label("Select A Level To Load");
			scrollPosition = GUILayout.BeginScrollView(scrollPosition, GUILayout.Width(Screen.width/4), GUILayout.Height(400));
			
			if(getFoldersInUserLevels().Length == 0)
			{
				GUILayout.Label("No Levels Here :'(");
			}
			else
			{
				string[] localLevelNames = getFoldersInUserLevels();
				for (int i = 0; i < localLevelNames.Length; i++) {
					
					if(GUILayout.Button(localLevelNames[i]))
					{
						Debug.Log("Now Loading " + localLevelNames[i]);
						levelName = localLevelNames[i];
						levelToPreviewIsSelected = true;
						previewTexture = getLevelImage(levelName);
					}
					
				}
			}
			GUILayout.EndScrollView();
		}

	}

	private void createNewLevelGUI () {

		if(!hasEnteredInformation)
		{
			GUILayout.Space(10);
			GUILayout.Label("Imagine Me Level Creator");
			GUILayout.Space(10);
			
			GUILayout.BeginHorizontal();
			GUILayout.Label("Type A Level Name: ");
			levelName = GUILayout.TextField(levelName, 20);
			GUILayout.EndHorizontal();
			
			if(GUILayout.Button("Start Creating Level", GUILayout.Height(30)))
			{
				if(levelName == "")
				{
					messageSystem("Error: Enter A Level Name");
				}
				else
				{
					if(ES2.Exists(Application.dataPath + "/UserLevels/" + levelName + "/" + levelName + ".txt"))
					{
						messageSystem("Error: Level Exists Already");
					}
					else
					{
						hasEnteredInformation = true;
						isLoading = true;
						Application.LoadLevel("LevelCreatorScene");
					}
				}
				
			}
			
		}
	}

	public Texture2D getLevelImage(string levelName) {

		Texture2D _lvlImage = ES2.LoadImage(Application.dataPath + "/UserLevels/" + levelName + "/" + levelName + ".png");
		return _lvlImage;
	}

	//gets all the folder names in the User Levels Folder
	//Returns a string array of all the names
	public string[] getFoldersInUserLevels () {

		string[] folders = ES2.GetFolders(Application.dataPath + "/UserLevels/");
		return folders;

	}

	public void messageSystem(string message) {
		
		messageText.text = "\n " + message + " \n";
		Invoke("messageSystemClear", 1.0f);
	}
	
	private void messageSystemClear() {
		messageText.text = " ";
	}

}
