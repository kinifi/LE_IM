using UnityEngine;
using System.Collections;

public class AsyncLoadingScene : MonoBehaviour {

	private string levelToLoad;

	// Use this for initialization
	void Start () {
	
		asyncLevelToLoad("Tutorial_Dungeon");

		if(PlayerPrefs.HasKey("asynclevel"))
	    {
			levelToLoad = PlayerPrefs.GetString("asynclevel");
			StartCoroutine("StartLoadingLevel");
		}
		else
		{
			Debug.LogError("Level not set using: asyncLevelToLoad(LEVELNAME)");
		}


	}
	
	IEnumerator StartLoadingLevel() {
		AsyncOperation async = Application.LoadLevelAsync(levelToLoad);
		yield return async;
		Debug.Log("Loading complete");
		if(async.isDone)
		{
			completedLevelLoad();
		}
	}


	public static void asyncLevelToLoad(string _level)
	{
		PlayerPrefs.SetString("asynclevel", _level);
	}

	private void completedLevelLoad()
	{

		Debug.Log("Done");
	}
}
