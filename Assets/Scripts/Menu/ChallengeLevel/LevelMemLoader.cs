using UnityEngine;
using System.Collections;

public class LevelMemLoader : MonoBehaviour {

	//The level 1 is always unlocked
	private int levelUnlocked = 1;

	public UIButton[] Levels;

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
            Debug.Log(">>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>" + levelUnlocked);
            //check if the achievements need to be unlocked
            if(levelUnlocked >= 15)
            {
                SteamManager.StatsAndAchievements.Unlock_Halfway_There_Achievement();
                Debug.Log("15 or more levels unlocked");
                
                if (levelUnlocked >= 30)
                {
                    SteamManager.StatsAndAchievements.Unlock_Full_Tank_Achievement();
                    Debug.Log("30 or more");
                }

            }
            else
            {
                Debug.Log("less than 15 levels unlocked");
            }


			if(levelUnlocked >= Levels.Length)
			{
				levelUnlocked = Levels.Length;

			}
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
				Levels[i].isEnabled = false;
			}
			else
			{
				Levels[i].isEnabled = true;
			}

		}
	}

	// Update is called once per frame
	void Update () {
	
	}
}
