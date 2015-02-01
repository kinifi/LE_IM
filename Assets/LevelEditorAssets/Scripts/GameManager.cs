﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Xml;
using System.Text;
using System.IO;
using Steamworks;

public class GameManager : MonoBehaviour {

	//testcomment
    private List<GameObject> gameObjs = new List<GameObject>();
	private string path;
	public string mapFolderPath;
	public string mapName;
    public string author_Name, author_Note, background_Color;
    public GameObject[] Tiles;
    public GameObject EditorTile;
    public Camera cam;

    private bool canDraw = true;
    private bool attemptingToUploadToSteamWorkshop = false;
    private bool privateLevel = false;

	//Steam workshop stuff
	private PublishedFileId_t m_PublishedFileId;
	private UGCUpdateHandle_t m_UGCUpdateHandle;
	private CallResult<CreateItemResult_t> OnCreateItemResultCallResult;
	private CallResult<SubmitItemUpdateResult_t> OnSubmitItemUpdateResultCallResult;
	private ulong BytesProcessed;
	private ulong BytesTotal;
	private string imagePath;

	public GUISkin skin;
	public Text inputMapName;
	public Text inputDescription;
	public Text UploadPanelText;
	public GameObject GoToMainMenuButton, LoadingPanel;
	public bool hasUploaded = false;
	public string _progress;

	public int currentSelectedTile;

	void Start () {

		OnCreateItemResultCallResult = CallResult<CreateItemResult_t>.Create(OnCreateItemResult);
		OnSubmitItemUpdateResultCallResult = CallResult<SubmitItemUpdateResult_t>.Create(OnSubmitItemUpdateResult);

		//Set the author name to the Steam Persona Name. Example: authorName = Kinifi
        author_Name = SteamBasic.getPersonaName();
		Debug.Log("Starting Game Manager");
	}

	public void setCurrentSelectedTile (int _tileNumber) {

		currentSelectedTile = _tileNumber;
	}

	public void setMapName () {

		mapName = inputMapName.text;
		if(inputDescription.text != "" || inputDescription.text != null)
		{
			author_Note = inputDescription.text;
		}
		else
		{
			//TODO: PAX EAST level comments taken out!
			author_Note = "Pax East Level";
			author_Note = inputDescription.text + "| Made by: " + author_Name;
		}
	}

	public void setBackGroundColor (string _color) {

		background_Color = _color;
	}
	

	public void goToMainLevelEditorScene()
	{
		Application.LoadLevel("LevelCreatorScene");
	}

    void Update ()
    {

		if(hasUploaded)
		{
			_progress = SteamManager.WorkshopUpload.State.ToString();
			if(_progress == "Complete")
			{
				UploadPanelText.text = "Upload Complete! Bringing you back to the Main Menu";
				Invoke("goToMainLevelEditorScene", 3.0f);
			}
		}

		//If the Left Mouse button is down, change the sprite to the sprite selected
        if (Input.GetMouseButtonDown(1))
        {
            var worldTouch = cam.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit;
            hit = Physics2D.Raycast(new Vector2(worldTouch.x, worldTouch.y), Vector2.zero, Mathf.Infinity);
            if (hit != null && hit.collider != null)
            {
                if (canDraw)
                {
                    //TODO: This will get an Error if the Hit.GameObject doesn't have a Collider2D
                    hit.transform.gameObject.GetComponent<SpriteRenderer>().sprite = Tiles[currentSelectedTile].gameObject.GetComponent<SpriteRenderer>().sprite;
                    hit.transform.name = Tiles[currentSelectedTile].gameObject.GetComponent<SpriteRenderer>().sprite.name;
                    hit.transform.tag = "Untagged";
                    //Debug.Log(hit.transform.name);
                }
                else
                {
                    hit.transform.gameObject.GetComponent<SpriteRenderer>().sprite = EditorTile.gameObject.GetComponent<SpriteRenderer>().sprite;
                    hit.transform.name = EditorTile.gameObject.GetComponent<SpriteRenderer>().sprite.name;
                    hit.transform.tag = "Untagged";
                }
            }
        }
    }
	

	public void UploadToSteamWorkShopPlease ()
	{

		Debug.Log("Starting Workshop upload");

		//Upload to Steam workshop. 
		//TODO: Add a description field
		SteamManager.WorkshopUpload.CreateWorkshopItem(mapFolderPath,
		                                               imagePath,
		                                               mapName,
		                                               author_Note,
		                                               Steamworks.ERemoteStoragePublishedFileVisibility.k_ERemoteStoragePublishedFileVisibilityPublic);
		hasUploaded = true;


	}


	#region OnButton Actions for uGUI 

	public void onSaveLevel() {

		SaveLevel();
	}

	public void onCreateBlankLevel () {

		createBlankLevel();
	}

	public void onClearLevel () {

		ClearLevel();
	}

	public void onDraw () {

		canDraw = true;
	}

	public void onErase () {

		canDraw = false;
	}

	public void onZoomOut() {

		cam.orthographicSize++;
	}

	public void onZoomIn() {

		cam.orthographicSize--;
	}

	#endregion

    /// <summary>
    /// Call this to create a 20x20 blank level
    /// </summary>
    private void createBlankLevel()
    {

        ///Clear the level of existing blocks
        ClearLevel();

        int levelX = 20;
        int levelY = 20;

        GameObject _newLevel = new GameObject();
        _newLevel.name = "_Level";

        for (int x = 0; x < levelX; x++)
        {
            for (int y = 0; y < levelY; y++)
            {
                    GameObject _newBlock;
                    _newBlock = Instantiate(EditorTile, new Vector2(x, y), Quaternion.identity) as GameObject;
                    _newBlock.name = x + y + "";
                    _newBlock.transform.parent = _newLevel.transform;
            }
        }
    }

    /// <summary>
    /// Delete every GameObject with the "Block" Tag
    /// Can pass any tag name to it. Defaults to Block
    /// </summary>
    private void ClearLevel(string tagName = "ChallengeGround")
    {
		/*
        gameObjs = GameObject.FindGameObjectsWithTag(tagName);

		if(gameObjs != null)
		{
	        for (int i = 0; i < gameObjs.Length; i++)
	        {
	            Destroy(gameObjs[i].gameObject);
	        }
		}
		*/

        GameObject _lvl;
        _lvl = GameObject.Find("_Level");
        if (_lvl != null)
        {
            Destroy(_lvl);
        }

        //cam.backgroundColor = new Color(0.192f, 0.30f, 0.474f, 0.019f);
		if(background_Color != null || background_Color != "")
		{
			parseBackgroundColor(background_Color);
		}
		else
		{
			parseBackgroundColor("blue");
		}
    }

    /// <summary>
    /// Change the background Color of the camera
    /// </summary>
    /// <param name="color">The new color of the background camera</param>
    private void parseBackgroundColor(string color)
    {

        if(color == "black")
        {
            cam.backgroundColor = Color.black;
        }
        else if(color == "blue")
        {
            cam.backgroundColor = Color.blue;
        }
        else if(color == "green")
        {
            cam.backgroundColor = Color.green;
        }
        else if(color == "yellow")
        {
            cam.backgroundColor = Color.yellow;
        }
        else if(color == "cyan")
        {
            cam.backgroundColor = Color.cyan;
        }
        else if(color == "white")
        {
            cam.backgroundColor = Color.white;
        }
        else if(color == "red")
        {
            cam.backgroundColor = Color.red;
        }

    }

    /// <summary>
    /// Call this to load the level from a xml file name
    /// </summary>
	void LoadXML(string mapName)
	{
        //clear the existing level on the screen
        //ClearLevel();

		path = Application.dataPath + "/UserLevels/" + "/" +  mapName + "/" + mapName + ".xml";
		
		XmlReader reader = XmlReader.Create(path);
		XmlDocument xmlDoc = new XmlDocument();
	    xmlDoc.Load(reader);
	   	XmlNodeList Data = xmlDoc.GetElementsByTagName("Block");
        XmlNodeList Settings = xmlDoc.GetElementsByTagName("Settings");

        //How many Tiles are in the XML File
        Debug.Log("Number of Tiles in Level: " + Data.Count);
        //Get the background Color
        Debug.Log(Settings.Item(0).ChildNodes.Item(0).InnerText);
        parseBackgroundColor(Settings.Item(0).ChildNodes.Item(0).InnerText.ToLower());
        //Get the Author name
        Debug.Log(Settings.Item(0).ChildNodes.Item(1).InnerText);
        //get the author Note
        Debug.Log(Settings.Item(0).ChildNodes.Item(2).InnerText);

        GameObject _newLevel = new GameObject();
        _newLevel.name = "_Level";

        //How many XML Tags are inside of the number of Tiles(Data.Count)
        for(int i = 0; i < Data.Count;i++)
	    {
			// getting data
	    	XmlNode DataChilds = Data.Item(i);

			// getting all gameObjects stored inside data
	    	XmlNodeList allGameObjects = DataChilds.ChildNodes;

            //Create a Gameobject with the tiles name
            //TODO Parse this string to instantiate the correct block Tile

            for (int t = 0; t < Tiles.Length; t++)
            {
                if(allGameObjects.Item(0).InnerText == Tiles[t].name)
                {
                    GameObject _newBlock;
                    _newBlock = Instantiate(Tiles[t], new Vector2(float.Parse(allGameObjects.Item(1).InnerText), float.Parse(allGameObjects.Item(2).InnerText)), Quaternion.identity) as GameObject;
					_newBlock.tag = "ChallengeGround";
					_newBlock.name = allGameObjects.Item(0).InnerText;
                    _newBlock.transform.parent = _newLevel.transform;
                }
            }

            //GameObject _test = new GameObject(allGameObjects.Item(0).InnerText);
            //set the position according to the X and Y xml
            //_test.transform.position = new Vector2(int.Parse(allGameObjects.Item(1).InnerText), int.Parse(allGameObjects.Item(2).InnerText));
        
	    }
		reader.Close();
	}

    /// <summary>
    /// Call this to save a level
    /// </summary>
    private void SaveLevel()
    {
        Debug.Log("Started Save" + Time.realtimeSinceStartup);
        //gameObjs = GameObject.FindGameObjectsWithTag("Block");

		GameObject _gameObjs;
		_gameObjs = GameObject.Find("_Level");

		foreach (Transform child in _gameObjs.transform)
		{
			if(child.tag != "EditorOnly")
			{
				gameObjs.Add(child.gameObject);
			}
		}




        mapName = Regex.Replace(mapName, @"\s", "");
        author_Name = Regex.Replace(author_Name, @"\s", "");
        background_Color = Regex.Replace(background_Color, @"\s", "");
        saveXML();
    }

	private void screenshotTaker () {

		GameObject _canvas = GameObject.Find("Canvas");
		_canvas.SetActive(false);

		Application.CaptureScreenshot(Application.dataPath + "/UserLevels/" + "/" +  mapName + "/" + mapName + ".png");
		imagePath = Application.dataPath + "/UserLevels/" + "/" +  mapName + "/" + mapName + ".png";

		_canvas.SetActive(true);
		Debug.Log("Screenshot captured: " + Application.dataPath + "/UserLevels/" + "/" +  mapName + "/" + mapName + ".png");

		//change the text so the users can go back to the main menu
		UploadPanelText.text = "Uploading to Steam!";
		LoadingPanel.SetActive(true);
		GoToMainMenuButton.SetActive(true);

	}


    /// <summary>
    /// DO NOT CALL. save the XML by finding all the gameobjects in the level with the "Block" Tag
    /// </summary>
	private void saveXML()
	{
		//set the paths so we can use them later
		path = Application.dataPath + "/UserLevels/" + "/" +  mapName + "/" + mapName + ".xml";
		mapFolderPath = Application.dataPath + "/UserLevels/" + "/" +  mapName + "/";
		//create the folder for the level
		System.IO.Directory.CreateDirectory(Application.dataPath + "/UserLevels/" + "/" +  mapName);
		//take a screenshot of everything
		screenshotTaker();


		XmlDocument xmlDoc = new XmlDocument();
	    XmlElement elmRoot = xmlDoc.CreateElement("Level");
    	xmlDoc.AppendChild(elmRoot);



        foreach (GameObject go in gameObjs)
        {
            //Creating an xml element with level name
            XmlElement Block = xmlDoc.CreateElement("Block");
				
			//Creating an xml element for all block data
            XmlElement Block_Prefab = xmlDoc.CreateElement("Prefab");
			XmlElement Block_Position_X = xmlDoc.CreateElement("X");
			XmlElement Block_Position_Y = xmlDoc.CreateElement("Y");
			

			//setting all the data to the appropriate xml node
            Block_Prefab.InnerText = go.gameObject.name;
            Block_Position_X.InnerText = go.transform.position.x + "";
			Block_Position_Y.InnerText = go.transform.position.y + "";
			

		    //make the Block data a Child of the Root XML Object
			elmRoot.AppendChild(Block);

			//Make all the block data a child of the block Object
            Block.AppendChild(Block_Prefab);
			Block.AppendChild(Block_Position_X);
			Block.AppendChild(Block_Position_Y);
		    
    	}

    	XmlElement settings = xmlDoc.CreateElement("Settings");
    	XmlElement backgroundColor = xmlDoc.CreateElement("backgroundColor");
    	XmlElement authorName = xmlDoc.CreateElement("authorName");
    	XmlElement authorNote = xmlDoc.CreateElement("authorNote");
    	backgroundColor.InnerText = background_Color;
    	authorName.InnerText = author_Name;
    	authorNote.InnerText = author_Note;
    	elmRoot.AppendChild(settings);
    	settings.AppendChild(backgroundColor);
    	settings.AppendChild(authorName);
    	settings.AppendChild(authorNote);


		StreamWriter outStream = System.IO.File.CreateText(path);
	    xmlDoc.Save(outStream);
	    outStream.Close();
        Debug.Log("Finished Save" + Time.realtimeSinceStartup);
	}

	void OnCreateItemResult(CreateItemResult_t pCallback, bool bIOFailure) {


		Debug.Log("[" + CreateItemResult_t.k_iCallback + " - CreateItemResult_t] - " + pCallback.m_eResult + " -- " + pCallback.m_nPublishedFileId + " -- " + pCallback.m_bUserNeedsToAcceptWorkshopLegalAgreement);
		m_PublishedFileId = pCallback.m_nPublishedFileId;
	}

	void OnSubmitItemUpdateResult(SubmitItemUpdateResult_t pCallback, bool bIOFailure) {
		Debug.Log("[" + SubmitItemUpdateResult_t.k_iCallback + " - SubmitItemUpdateResult_t] - " + pCallback.m_eResult + " -- " + pCallback.m_bUserNeedsToAcceptWorkshopLegalAgreement);
	}

}
