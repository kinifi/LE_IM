using UnityEngine;
using System.Collections;
using Steamworks;

public class IM_Editor : MonoBehaviour {

	public GUISkin skin;
	public GUIText messageText;
	public GameObject mainCamera, screenshotCamera;
	public GameObject[] Tiles;
	public GameObject EditorTile;
	private string levelName = "testLevel";
	public string[] levelRows;
	private string levelValue;
	private int levelX = 18, levelY = 12;
	private GameObject parentCreator;
	private bool hasLevelName, hasAuthorName, showChecklist;
	private Vector2 scrollPosition;
	private int selectedButtonTile = 0;
	private bool isTakingScreenShot = false;

	#region Easy Save Vars

	private string saveFilePath;
	private string saveTagPrefix;

	#endregion

	// Use this for initialization
	void Start () {

		getLevelName();

		//Create the New Level File
		saveTileData(levelName, 0000000000);
		
		GenerateLevel();
		//add the save paths to the easy save vars for later use
		createSaveFilePath();
		messageSystem("Starting Editor");

		for (int i = 0; i < levelRows.Length; i++) {
			levelRows[i] = "0";
		}

	}

	private void getLevelName()
	{
		StartingValues _startingValues = GameObject.Find("StartingValues").GetComponent<StartingValues>();
		levelName = _startingValues.levelName;

	}

	void Update() {

		if(Input.GetMouseButtonDown(0))
		{
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;
			if(Physics.Raycast(ray, out hit, 100))
			{
				//Debug.DrawLine(ray.origin, hit.point);
				//Debug.Log(hit.transform.name);
				Destroy(hit.transform.gameObject);
				//spawn a new block depending on selectedButtonTile

				if(selectedButtonTile == 0)
				{
					GameObject tile;
					tile = Instantiate(Tiles[0], hit.transform.position, Quaternion.identity) as GameObject;
					tile.name = hit.transform.name;
					tile.transform.parent = parentCreator.transform;
					saveTileData(tile.name, selectedButtonTile);
				}
				else if(selectedButtonTile == 1)
				{
					GameObject tile;
					tile = Instantiate(Tiles[1], hit.transform.position, Quaternion.identity) as GameObject;
					tile.name = hit.transform.name;
					tile.transform.parent = parentCreator.transform;
					saveTileData(tile.name, selectedButtonTile);
				}

				//delete last or you won't have a reference to the transform anymore


				//TODO:save the tile name as a tag and its selectedButtontile value as an int connected to that tile tag

			}
		}


		if(Input.GetMouseButtonDown(1))
		{
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;
			if(Physics.Raycast(ray, out hit, 100))
			{

				Destroy(hit.transform.gameObject);

				GameObject tile;
				tile = Instantiate(EditorTile, hit.transform.position, Quaternion.identity) as GameObject;
				tile.name = hit.transform.name;
				tile.transform.parent = parentCreator.transform;
				deleteTileData(tile.name);
			}

		}



	}


	private void saveTileData(string tileName, int tileValue) {

		ES2.Save(tileValue, saveFilePath + levelName + ".txt" + saveTagPrefix + tileName);
	}

	private void deleteTileData(string tileName)
	{
		ES2.Delete(saveFilePath + levelName + ".txt" + saveTagPrefix + tileName);
	}

	//Create the file paths need to get the save data
	private void createSaveFilePath() {
		saveFilePath = Application.dataPath + "/UserLevels/" + levelName + "/";
		saveTagPrefix = "?tag=";
	}

	private void createParentCreatorObject() {

		parentCreator = new GameObject("CreatorParent");
	}

	void OnGUI () {

		GUI.skin = skin;

		GUILayout.BeginArea(new Rect(0,0, Screen.width/4, Screen.height));

		if(!isTakingScreenShot)
		{
			isPreviewingLevel();
		}
		GUILayout.EndArea();



	}

	private void LevelCreator() {

		for (int X = 0; X < levelX; X++) {
			
			for (int Y = 0; Y < levelY; Y++) {

				GameObject tile;
				tile = Instantiate(EditorTile, new Vector2(X, Y), Quaternion.identity) as GameObject;
				tile.name = "" + X + Y;
				tile.transform.parent = parentCreator.transform;
				tile.AddComponent<blockLoader> ();
				saveTileData(tile.name, 99);
			}
			
		}

	}

	private void isPreviewingLevel() {

		GUILayout.Label("Create A Level");
		GUILayout.Space(10);
		GUILayout.BeginHorizontal();
		GUILayout.Label("Level Name: ");
		GUILayout.Label(levelName);
		GUILayout.EndHorizontal();
		
		GUILayout.BeginHorizontal();
		GUILayout.Label("Creator's Name: " + SteamBasic.getPersonaName());
		GUILayout.EndHorizontal();
		
		GUILayout.Space(10);

		//create scrollable buttons here
		scrollPosition = GUILayout.BeginScrollView(scrollPosition, GUILayout.Width(Screen.width/4), GUILayout.Height(300));

		for (int i = 0; i < Tiles.Length; i++) {
			if(GUILayout.Button(Tiles[i].name))
			{
				selectedButtonTile = i;
				Debug.Log(i);
			}
		}

		GUILayout.EndScrollView();



		GUILayout.Space(10);


		if(GUILayout.Button("Save Locally", GUILayout.Height(30)))
		{
			if(levelName == "")
			{
				messageSystem("Error: Enter A Level Name");
			}
			else
			{
				saveScreenShot();
				Debug.Log("Saved: " + levelName + "to" + saveFilePath);
			}
			
		}

		if(GUILayout.Button("Submit To WorkShop", GUILayout.Height(30)))
		{
			if(levelName == "")
			{
				messageSystem("Error: Enter A Level Name");
			}
			else
			{
				saveScreenShot();
				Debug.Log("Submit to Steam Workshop");
				Invoke("MoveToPublisher", 2.0f);
			}

		}


	}

	private void MoveToPublisher() {

		Application.LoadLevel("Level_Editor_Publisher");

	}

	private void GenerateLevel() {
		Destroy(parentCreator);
		createParentCreatorObject();
		messageSystem("Building Level");
		LevelCreator();
	}

	public void saveScreenShot() {

		isTakingScreenShot = true;
		//disable the main camera
		mainCamera.SetActive(false);
		//enable the screenshot camera
		screenshotCamera.SetActive(true);
		//take a screenshot
		Application.CaptureScreenshot(saveFilePath + levelName + ".png");
		//invoke the activation of the main camera again
		Invoke("toggleCameras", 0.5f); 
	}

	private void toggleCameras () {

		screenshotCamera.SetActive(false);
		mainCamera.SetActive(true);
		isTakingScreenShot = false;
	}

	public void messageSystem(string message) {

		messageText.text = "\n " + message + " \n";
		Invoke("messageSystemClear", 1.0f);

	}


	private void messageSystemClear() {
		messageText.text = " ";
	}

}
