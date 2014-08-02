using UnityEngine;
using System.Collections;

public class blockLoader : MonoBehaviour {

	private string saveFilePath, saveTagPrefix;
	private string saveFileExtension = ".txt";
	private string levelName;
	public string objectInfo;
	private bool isLoading;

	// Use this for initialization
	void Start () {
		
		getLevelName ();
		createSaveFilePath ();

		if (isLoading) {
            checkIfTagDataExists();
		}
	}
	
	//check for the data and see if anything exists
	private void checkIfTagDataExists()
	{
		if (ES2.Exists (saveFilePath + levelName + saveFileExtension + saveTagPrefix + this.gameObject.name)) {
			objectInfo = ES2.Load<string> (saveFilePath + levelName + saveFileExtension + saveTagPrefix + this.gameObject.name);
            createNewBlock(objectInfo);
		}
	}

	//instantiate a new child depending on the string value passed
	private void createNewBlock(string blockValue)
	{
		
	}
	
	//delete the old gameObject
	


	//Get LevelName from the Starting Values Object
	private void getLevelName()
	{
			StartingValues _startingValues = GameObject.Find("StartingValues").GetComponent<StartingValues>();
			levelName = _startingValues.levelName;
			isLoading = _startingValues.isLoading;
	}
	
	//Create the file paths need to get the save data
	private void createSaveFilePath() {
		saveFilePath = Application.dataPath + "/UserLevels/" + levelName + "/";
		saveTagPrefix = "?tag=";
	}
}
