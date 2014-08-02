using UnityEngine;
using System.Collections;

public class MenuButtons : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}

	public void openAchievements() {
		SteamBasic.openSteamOverlayToAchievement();
	}

	public void openCommunity()
	{
		SteamBasic.openSteamOverlayToCommunity();
	}

	public void goToChallengeLevels() {
		Debug.Log("Loading Challenge Levels");
	}

	public void goToCampaignLevels() {

		Application.LoadLevel("Tutorial_Dungeon");
		Debug.Log("Loading Campaign");
	}

	public void goToLevelEditor() {
		Application.LoadLevel("Start_Screen");
		Debug.Log("Loading Level Editor");
	}

	public void quitGame() {
		Application.Quit();
	}
}
