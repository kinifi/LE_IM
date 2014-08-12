using UnityEngine;
using System.Collections;

public class MouseController : MonoBehaviour {
	
	public GameObject[] Tiles;
	public int levelX = 2, levelY = 2;
	private string blockName;
	private GameObject Loadlevel;

	// Use this for initialization
	void Start () {
		Loadlevel = GameObject.Find("Loadlevel");
	}
	
	// Update is called once per frame
	void Update () {

		if(Input.GetMouseButton(0))
		{
			RaycastHit2D hit = Physics2D.Raycast(new Vector2(camera.ScreenToWorldPoint(Input.mousePosition).x,camera.ScreenToWorldPoint(Input.mousePosition).y), Vector2.zero, 0f);
			if (hit.collider != null) 
			{
				getSelectedBlockValue();
				if(blockName == "" || blockName == null)
				{
					Debug.Log("Select A Tile");
				}
				else
				{
					spawnTile(hit.transform);
					Destroy(hit.transform.gameObject);
				}
			}
		}
		
		
	}

	private void spawnTile(Transform hitBlock) {


		//Debug.Log(blockName + "|" + hitblockname);

		for (int i = 0; i < Tiles.Length; i++) {
			if(Tiles[i].name == blockName)
			{
				GameObject b;
				b = Instantiate(Tiles[i], hitBlock.position, Quaternion.identity) as GameObject;
				b.name = hitBlock.name;
				b.transform.parent = Loadlevel.transform;
			}
			else
			{
				Debug.Log(blockName);
			}
		}

		/*
		if(blockName == "tile1_1")
		{
			GameObject b;
			b = Instantiate(Tiles[17], hitBlock.position, Quaternion.identity) as GameObject;
			b.name = hitBlock.name;
			b.transform.parent = Loadlevel.transform;
		}
		else if(blockName == "tile1_2")
		{
			GameObject b;
			b = Instantiate(Tiles[18], hitBlock.position, Quaternion.identity) as GameObject;
			b.name = hitBlock.name;
			b.transform.parent = Loadlevel.transform;
		}
		else if(blockName == "tile1_3")
		{
			GameObject b;
			b = Instantiate(Tiles[19], hitBlock.position, Quaternion.identity) as GameObject;
			b.name = hitBlock.name;
			b.transform.parent = Loadlevel.transform;
		}
		else if(blockName == "tile1_4")
		{
			
		}
		else if(blockName == "tile1_5")
		{
			
		}
		else if(blockName == "tile1_6")
		{
			
		}
		else if(blockName == "tile1_7")
		{
			
		}
		else if(blockName == "tile1_8")
		{
			
		}
		else if(blockName == "tile1_9")
		{
			
		}
		else if(blockName == "tile1_10")
		{
			
		}
		else if(blockName == "tile1_11")
		{
			
		}
		else if(blockName == "BGtile1")
		{
			
		}
		else if(blockName == "BGtile4")
		{
			
		}
		else if(blockName == "BGtile1_1")
		{
			
		}
		else
		{
			Debug.Log("No Block for: " + blockName);
		}
		*/
	}

	private void getSelectedBlockValue () {

		LE_GUI _gui = GameObject.Find("_GUI").GetComponent<LE_GUI>();
		blockName = _gui.selectedBlock.ToString();

	}

}
