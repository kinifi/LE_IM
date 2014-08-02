using UnityEngine;
using System.Collections;

public class Inventory : MonoBehaviour {

	public int Arrows, Keys;
	private float timer = 2.0f;
	private int x = 20, y = 20;
	public bool showInventory = false;
	public bool startCollectTimer = false;
	public GUISkin skin;

	// Use this for initialization
	void Start () {
	
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
}
