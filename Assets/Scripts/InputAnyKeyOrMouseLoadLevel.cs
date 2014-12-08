using UnityEngine;
using System.Collections;

public class InputAnyKeyOrMouseLoadLevel : MonoBehaviour {

    public string levelToLoad;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        if(Input.GetMouseButtonDown(0))
        {
            loadLevelNow();
        }
        else if(Input.GetMouseButtonDown(1))
        {
            loadLevelNow();
        }

        if(Input.anyKeyDown)
        {
            loadLevelNow();
        }

	
	}

    public void loadLevelNow()
    {
        Application.LoadLevel(levelToLoad);
    }
}
