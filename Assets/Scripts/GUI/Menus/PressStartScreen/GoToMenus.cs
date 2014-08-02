using UnityEngine;
using System.Collections;

public class GoToMenus : MonoBehaviour {

    public string level;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void GoToMainMenu()
    {

        Application.LoadLevel(level);
    }
}
