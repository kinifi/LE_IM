using UnityEngine;
using System.Collections;

public class Inventory : MonoBehaviour {


	private float timer = 2.0f;
	private int x = 20, y = 20;
	public bool showInventory = false;
	public bool startCollectTimer = false;
	public GUISkin skin;

	//Configs to get 
	private int _arrows;
	private int _keys;
	private int _completed;

	[System.NonSerialized]
	public int Arrows, Keys, Completed;

	// Use this for initialization
	void Awake () {

		GetInventory();
		SetInventory();
	}

	void Update() {

		if(Input.GetButtonDown("Inventory"))
		{
			toggleInventory();
		}

		if(startCollectTimer)
		{
			timer -= Time.deltaTime;
			if(showInventory != true)
			{
				showInventory = true;
			}
			if(timer < 0)
			{
				startCollectTimer = false;
				timer = 2.0f;
				toggleInventory();
			}
		}
	}

	public void GetInventory()
	{
		//Get starting inventory
		_arrows = PlayerPrefs.GetInt("bow");
		_keys = PlayerPrefs.GetInt("keys");
		_completed = PlayerPrefs.GetInt("completed");
	}

	public void SetInventory()
	{
		//Set starting inventory
		Arrows = _arrows;
		Keys = _keys;
		Completed = _completed;
	}
	
	void OnGUI() {

		GUI.skin = skin;

		GUILayout.BeginArea(new Rect(x, y, 150, 100));
		if(showInventory)
		{
			GUILayout.BeginHorizontal();
			GUILayout.Label("Keys: " + Keys);
			GUILayout.Label("Arrows: " + Arrows);
			GUILayout.EndHorizontal();
		}
		GUILayout.EndArea();
	}

	private void toggleInventory()
	{
		showInventory = !showInventory;
	}

	public void InventoryOnTimer ()
	{
		startCollectTimer = true;
	}
}
