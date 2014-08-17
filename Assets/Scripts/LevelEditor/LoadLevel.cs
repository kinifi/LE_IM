using UnityEngine;
using System.Collections;

public class LoadLevel : MonoBehaviour {

	public int levelX = 18, levelY = 12;
	public string levelName;
	public string authorName;
    public GameObject[] Blocks;


	private bool hideGUI = false;
	private Vector2 scrollPosition;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI () {

		if(!hideGUI)
		{
			GUILayout.BeginArea(new Rect(0, 0, Screen.width/4 , Screen.height));
			getUserGeneratedLevels();
			GUILayout.EndArea();
		}

	}

	public void LoadLevelNow() {

		if(ES2.Exists(Application.dataPath + "/UserLevels/" + levelName + "/" + levelName + ".txt?tag=" + "AuthorName"))
		{
			authorName = ES2.Load<string>(Application.dataPath + "/UserLevels/" + levelName + "/" + levelName + ".txt?tag=" + "AuthorName");
			Debug.Log("Author: " + authorName);
		}

		for (int x = 0; x < levelX; x++) {
			
			for (int y = 0; y < levelY; y++) {

				if(ES2.Exists(Application.dataPath + "/UserLevels/" + levelName + "/" + levelName + ".txt?tag=" + "" + x + y))
				{
					//Debug.Log("I Exist!");
                    //load the value
                    string s_Name = ES2.Load<string>(Application.dataPath + "/UserLevels/" + levelName + "/" + levelName + ".txt?tag=" + "" + x + y);

                    //pass the values and pass it to the block creator
                    instantiateBlock(s_Name, x, y);

				}
				else
				{
					///Debug.Log("I Dont Exist: " + "" + x + y);
				}
			}
			
		}

	}

    private void instantiateBlock(string spriteName, int x, int y)
    {

        //if they match instantiate that block
        for (int s = 0; s < Blocks.Length; s++)
        {
            if(Blocks[s].GetComponent<SpriteRenderer>().sprite.name == spriteName)
            {
                GameObject newBlock;
                newBlock = Instantiate(Blocks[s], new Vector2(x, y), Quaternion.identity) as GameObject;
                newBlock.name = "" + x + y;
            }
        }

    }

	private void getUserGeneratedLevels () {

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
					hideGUI = true;
					LoadLevelNow();
				}
				
			}
		}
		GUILayout.EndScrollView();

	}

	public string[] getFoldersInUserLevels () {
		
		string[] folders = ES2.GetFolders(Application.dataPath + "/UserLevels/");
		return folders;
		
	}
}
