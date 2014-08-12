using UnityEngine;
using System.Collections;

public class blockLoader : MonoBehaviour {

	private string saveFilePath, saveTagPrefix;
	private string saveFileExtension = ".txt";
	private string levelName;
	public string objectInfo;
	private bool isLoading = true;
		
	public GameObject[] Tiles;

	// Use this for initialization
	void Start () {
		
		getLevelName ();


		if (isLoading) {
            //checkIfTagDataExists();
		}
	}
	
	//check for the data and see if anything exists
	private void checkIfTagDataExists()
	{
		Debug.Log(saveFilePath);
		Debug.Log(levelName);
		Debug.Log(saveFileExtension);

		if (ES2.Exists (saveFilePath + levelName + saveFileExtension + "?tag=" + "" + this.gameObject.name)) {
			//objectInfo = ES2.Load<string> (saveFilePath + levelName + saveFileExtension + "?tag=" + "" + this.gameObject.name);
			//createNewBlock(objectInfo);
		}
		else
		{
			Debug.Log("no tag: " + this.name);
		}
	}

	//instantiate a new child depending on the string value passed
	private void createNewBlock(string blockValue)
	{
		/////////////////////
		/// 0: Standard One Block
		/// 1: Block With Moss On Top
		///	99: Editor Tile
		/// 0000000000: LevelName
		/////////////////////

		GameObject block;

		if(blockValue == "0")
		{
			block = Instantiate(Tiles[0], this.gameObject.transform.position, Quaternion.identity) as GameObject;
			block.name = this.gameObject.name;
			Destroy(this.gameObject);
		}
		else if(blockValue == "1")
		{
			block = Instantiate(Tiles[1], this.gameObject.transform.position, Quaternion.identity) as GameObject;
			block.name = this.gameObject.name;
			Destroy(this.gameObject);
		}
		else if(blockValue == "99")
		{
			//Debug.Log("Ed tile: " + this.gameObject.name);
			Destroy(this.gameObject);
		}
		else
		{
			Debug.Log(this.gameObject.name + " : " + blockValue);
			//block.transform.name = this.gameObject.name;
			Destroy(this.gameObject);
		}

	}
	
	//delete the old gameObject


	//Get LevelName from the Starting Values Object
	private void getLevelName()
	{
			//StartingValues _startingValues = GameObject.Find("StartingValues").GetComponent<StartingValues>();
			//levelName = _startingValues.levelName;
			//isLoading = _startingValues.isLoading;

		Debug_StartingValues _debugStartingValues = GameObject.Find("StartingValues").GetComponent<Debug_StartingValues>();
		levelName = _debugStartingValues.levelName;
		//checkIfTagDataExists();
		//Debug.Log(saveFilePath + levelName + saveFileExtension + saveTagPrefix + "" + this.gameObject.name);
		//Debug.Log(saveTagPrefix);
		createSaveFilePath ();
	}
	
	//Create the file paths need to get the save data
	private void createSaveFilePath() {
		saveFilePath = Application.dataPath + "/UserLevels/" + levelName + "/";
		saveTagPrefix = "?tag=";
		checkIfTagDataExists();
	}
}
