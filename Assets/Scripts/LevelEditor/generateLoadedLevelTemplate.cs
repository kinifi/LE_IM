using UnityEngine;
using System.Collections;

public class generateLoadedLevelTemplate : MonoBehaviour {

	public int levelX = 18, levelY = 12;
	public GameObject emptyTile;
	public bool generateOnStart = false;

	// Use this for initialization
	void Start () {
	
		if(generateOnStart)
		{
			Debug.Log("Starting Generation");
			generateLevel();
		}

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	private void generateLevel() {

		for (int x = 0; x < levelX; x++) {

			for (int y = 0; y < levelY; y++) {

				GameObject empty;
				empty = Instantiate(emptyTile, new Vector2(x, y), Quaternion.identity) as GameObject;
				empty.name = "" + x + y;
				empty.transform.parent = this.gameObject.transform;
			}

		}

	}
}
