using UnityEngine;
using System.Collections;

public class LE_GUI : MonoBehaviour {

	private string levelName = "EnterLevelName";
	private int selGridInt = 0;
	private string[] selStrings = new string[] {"Blocks", "Player", "Enemies", "Spikes", "Hide"};
	private Vector2 scrollPosition;
	public Texture2D[] blocks, player, Enemies, Spikes, Interactions;
	public GameObject cam;
	public string selectedBlock;
	public bool hasSaved = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI() {

		GUILayout.BeginArea(new Rect( 20, 20, Screen.width-20, Screen.height-20));

		GUILayout.BeginHorizontal();
		levelName = GUILayout.TextField(levelName, 30, GUILayout.Width(150));
		GUILayout.Space(10);
		selGridInt = GUILayout.SelectionGrid(selGridInt, selStrings, 10);
		GUILayout.EndHorizontal();
		if(GUILayout.Button("Save", GUILayout.Width(150)))
		{
			ES2.Save(SteamBasic.getPersonaName(), Application.dataPath + "/UserLevels/" + levelName + "/" + levelName + ".txt?tag=" + "AuthorName");
			//After Saving you can call Workshop's button
			GameObject _parent = GameObject.Find("Loadlevel");
			foreach (Transform child in _parent.transform)
			{
				//Debug.Log(child.GetComponent<SpriteRenderer>().sprite.name);
				ES2.Save(child.GetComponent<SpriteRenderer>().sprite.name, Application.dataPath + "/UserLevels/" + levelName + "/" + levelName + ".txt?tag=" + child.name);
			}

			Debug.Log("Save");
		}

		if(hasSaved)
		{
			if(GUILayout.Button("Submit To WorkShop", GUILayout.Width(150)))
			{
				//After Saving you can call Workshop's button
				Debug.Log("Start WorkShop Service");
			}
		}

		GUILayout.Space(10);

		#region Button Scroll View / Vertical View

		GUILayout.BeginVertical();
		scrollPosition = GUILayout.BeginScrollView(scrollPosition, GUILayout.Width(80), GUILayout.Height(500));
		if(selGridInt == 0)
		{
			//Show the blocks array
			for (int i = 0; i < blocks.Length; i++) {
				if(GUILayout.Button(blocks[i], GUILayout.Width(50), GUILayout.Height(50)))
				{
					selectedBlock = blocks[i].name;
					Debug.Log(blocks[i].name);
				}
			}
		}
		else if(selGridInt == 1)
		{
			//Show the Player array
			for (int i = 0; i < player.Length; i++) {
				if(GUILayout.Button(player[i], GUILayout.Width(50), GUILayout.Height(50)))
				{
					selectedBlock = player[i].name;
					Debug.Log(player[i].name);
				}
			}
		}
		else if(selGridInt == 2)
		{
			//Show the Enemies array
			for (int i = 0; i < Enemies.Length; i++) {
				if(GUILayout.Button(Enemies[i], GUILayout.Width(50), GUILayout.Height(50)))
				{
					selectedBlock = Enemies[i].name;
					Debug.Log(Enemies[i].name);
				}
			}
		}
		else if(selGridInt == 3)
		{
			//Show the spikes array
			for (int i = 0; i < Spikes.Length; i++) {
				if(GUILayout.Button(Spikes[i], GUILayout.Width(50), GUILayout.Height(50)))
				{
					selectedBlock = blocks[i].name;
					Debug.Log(Spikes[i].name);
				}
			}
		}
		else
		{
			//Debug.Log("Hide Texture Panel");
		}

		GUILayout.EndScrollView();
		GUILayout.EndVertical();

		#endregion

		GUILayout.EndArea();


		//call the zoom object
		Zoom();
	}

	/// <summary>
	/// Zoom this instance.
	/// </summary>
	private void Zoom() {
		
		GUILayout.BeginArea(new Rect(20 , Screen.height-20, 200, 100));
		GUILayout.BeginHorizontal();
		if(GUILayout.Button("--"))
		{
			//After Saving you can call Workshop's button
			cam.camera.orthographicSize = cam.camera.orthographicSize += 0.5f;
			Debug.Log("Zoom Out");
		}
		GUILayout.Label("Zoom", GUILayout.Width(40));
		if(GUILayout.Button("++"))
		{
			//After Saving you can call Workshop's button
			cam.camera.orthographicSize = cam.camera.orthographicSize -= 0.5f;
			Debug.Log("Zoom In");
		}
		GUILayout.EndHorizontal();
		GUILayout.EndArea();
	}
}
