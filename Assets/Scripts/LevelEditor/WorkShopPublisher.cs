using UnityEngine;
using System.Collections;
using System.ComponentModel;
using Steamworks;

public class WorkShopPublisher : MonoBehaviour {

	public string saveFilePath, saveTagPrefix;
	private string fileName, screenshotLocation, fileDescription = "Type a description explaining your awesome creation!", saveFileEnding = ".txt", fileFullPath;
	private Texture2D levelImage;

	//Steam Callbacks
	private CallResult<RemoteStorageEnumerateUserPublishedFilesResult_t> RemoteStorageEnumerateUserPublishedFilesResult;


	// Use this for initialization
	void Start () {

		getFromStartingValues();
		createPaths();
		getLevelImage();
	}

	private void getFromStartingValues() {

		StartingValues _startingValues = GameObject.Find("StartingValues").GetComponent<StartingValues>();
		fileName = _startingValues.levelName;

	}

	private void createPaths () {

		saveFilePath = Application.dataPath + "/UserLevels/" + fileName + "/";
		saveTagPrefix = "?tag=";
		fileFullPath = saveFilePath + fileName + saveFileEnding;
	}

	private void getLevelImage() {
		levelImage = getLevelImage(fileName);
	}

	public Texture2D getLevelImage(string levelName) {
		
		Texture2D _lvlImage = ES2.LoadImage(Application.dataPath + "/UserLevels/" + levelName + "/" + levelName + ".png");
		return _lvlImage;
	}

	void writeToCloud() {

	}

	void publishToWorkShop() {
		string[] Tags = {};
		Steamworks.SteamRemoteStorage.PublishWorkshopFile(fileFullPath,
		                                                  screenshotLocation,
		                                                  SteamUtils.GetAppID(), 
		                                                  "Title!",
		                                                  "Description!",
		                                                  ERemoteStoragePublishedFileVisibility.k_ERemoteStoragePublishedFileVisibilityPublic, // Can be set to private, friends only, public
		                                                  Tags,
		                                                  EWorkshopFileType.k_EWorkshopFileTypeCommunity); //looks like it can be set to different types: Concept, Community, merch etc
	}




	void OnGUI()
	{
		///GUI
		GUILayout.BeginArea(new Rect(10, 10, Screen.width/3, Screen.height - 10));
		//Label that shows LevelName
		GUILayout.Label("Title: " + fileName);
		//Label that shows your Steam User Name as Author
		GUILayout.Label("Created By: " + SteamBasic.getPersonaName());
		GUILayout.Label("File Path: " + fileFullPath);
		//Text area for Description / 8000 characters max
		GUILayout.Label("Level Description");
		fileDescription = GUILayout.TextArea(fileDescription, 8000, GUILayout.Height(300));
		GUILayout.Label(fileDescription.Length + " - 8000 Character Count");
		//Publish Button
		GUILayout.Space (10);
		if(GUILayout.Button("Publish Level", GUILayout.Height(80)))
		{
			//enumerate over the users files
			//SteamAPICall_t handle = Steamworks.SteamRemoteStorage.EnumerateUserPublishedFiles(0);
			//RemoteStorageEnumerateUserPublishedFilesResult.Set(handle);
			//call file write
			//Steamworks.SteamRemoteStorage.FileWrite(fileFullPath, 
			//call file share
			//call publishToWorkShop();

		}

		GUILayout.EndArea();

		GUILayout.BeginArea(new Rect(Screen.width/3 + 50, Screen.height/4, Screen.width-Screen.width/3, Screen.height-10));
		GUILayout.Label(levelImage, GUILayout.Height(300), GUILayout.Width(Screen.width + 10 -Screen.width/3));
		GUILayout.EndArea();
	}

}
