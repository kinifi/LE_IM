using UnityEngine;
using System.Collections;

public class LevelSwitch : MonoBehaviour {

	public string levelNameToLoad;

	// Use this for initialization
	void Start () {
	
	}
	
	public void ChangeScene() {
		Application.LoadLevel(levelNameToLoad);
	}
}
