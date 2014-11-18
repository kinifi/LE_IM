using UnityEngine;
using System.Collections;

public class LoadPreviousSavedLevel : MonoBehaviour {

	private float restartTimer = 2.0f;

	// Use this for initialization
	void Start () {
	
	}
	
	void Update()
	{
		restartTimer -= Time.deltaTime;
		if(restartTimer < 0)
		{
			goToPreviousSavedLevel();
		}
	}

    public void goToPreviousSavedLevel()
    {
        if(PlayerPrefs.HasKey("PreviousLevel"))
        {
            string templevelName = PlayerPrefs.GetString("PreviousLevel");
            Application.LoadLevel(templevelName);
        }
        else
        {
            Application.LoadLevel("Main_Menu");
        }
        
    }

}
