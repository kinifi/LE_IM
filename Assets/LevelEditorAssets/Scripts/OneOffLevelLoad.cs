using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Xml;
using System.Text;
using System.IO;

public class OneOffLevelLoad : MonoBehaviour {

    private string mapName, mapPath, mapDescription;
    private Camera _cam;
    public GameObject[] Tiles;


	// Use this for initialization
	void Start () {

        _cam = GameObject.Find("Camera").camera;

        mapName = PlayerPrefs.GetString("Title");
        mapDescription = PlayerPrefs.GetString("Description");
        mapPath = PlayerPrefs.GetString("Path");


        //load the level
        LoadXML();
	}



    /// <summary>
    /// Call this to load the level from a xml file name
    /// </summary>
    void LoadXML()
    {
        //clear the existing level on the screen
        //ClearLevel();

		mapPath = Application.dataPath + "/UserLevels/" + "/" +  mapName + "/" + mapName + ".xml";


        XmlReader reader = XmlReader.Create(mapPath);
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
        for (int i = 0; i < Data.Count; i++)
        {
            // getting data
            XmlNode DataChilds = Data.Item(i);

            // getting all gameObjects stored inside data
            XmlNodeList allGameObjects = DataChilds.ChildNodes;

            //Create a Gameobject with the tiles name
            //TODO Parse this string to instantiate the correct block Tile

            for (int t = 0; t < Tiles.Length; t++)
            {
                if (allGameObjects.Item(0).InnerText == Tiles[t].name)
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
    /// Change the background Color of the camera
    /// </summary>
    /// <param name="color">The new color of the background camera</param>
    private void parseBackgroundColor(string color)
    {

        if (color == "black")
        {
            _cam.backgroundColor = Color.black;
        }
        else if (color == "blue")
        {
            _cam.backgroundColor = Color.blue;
        }
        else if (color == "green")
        {
            _cam.backgroundColor = Color.green;
        }
        else if (color == "yellow")
        {
            _cam.backgroundColor = Color.yellow;
        }
        else if (color == "cyan")
        {
            _cam.backgroundColor = Color.cyan;
        }
        else if (color == "white")
        {
            _cam.backgroundColor = Color.white;
        }
        else if (color == "red")
        {
            _cam.backgroundColor = Color.red;
        }

    }


}
