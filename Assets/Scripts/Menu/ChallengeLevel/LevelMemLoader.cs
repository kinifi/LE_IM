using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LevelMemLoader : MonoBehaviour {

	//The level 1 is always unlocked
	private int levelUnlocked = 1;
	public GameObject[] Levels;

	// Use this for initialization
	void Start () {

		loadLevelUnlockedValue();

	}

	/// <summary>
	/// Loads the level unlocked value.
	/// If the value doesn't exist it will set it to 1.
	/// </summary>
	private void loadLevelUnlockedValue()
	{
		if(PlayerPrefs.HasKey("levelUnlock"))
		{
			levelUnlocked = PlayerPrefs.GetInt("levelUnlock");
            //Debug.Log(">>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>" + levelUnlocked);

			if(levelUnlocked >= Levels.Length)
			{
				levelUnlocked = Levels.Length;

			}
            // Call levels to be unlocked 
			unlockLevels();
			
            Debug.Log("Exists:" + levelUnlocked);

		}
		else
		{
			PlayerPrefs.SetInt( "levelUnlock", 1);
			Debug.Log("Created");
		}
	}

	private void unlockLevels()
	{
		for (int i = 0; i < Levels.Length; i++) {
			if(i >= levelUnlocked)
			{
                if (Levels[i] != null)
                {
                    //Levels[i].SetActive(false);
					Levels[i].GetComponent<Button>().interactable = false;
                }
			}
			else
			{
                if (Levels[i] != null)
                {
                    
                    //Levels[i].SetActive(true);
					Levels[i].GetComponent<Button>().interactable = true;
                }
			}

		}
	}


}
