using UnityEngine;
using System.Collections;

public class MenuButtons : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}

	public void goToOptions() {
		Application.LoadLevel("Options");
	}

	public void openAchievements() {
		SteamBasic.openSteamOverlayToAchievement();
	}

	public void openCommunity()
	{
		SteamBasic.openSteamOverlayToURL("steamcommunity.com/app/265670/");
	}

	public void goToChallengeLevels() {
		Application.LoadLevel("Challenge");
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

	public void goToStats()
	{
		Application.LoadLevel("Stats");
	}

	public void quitGame() {
		Application.Quit();
	}
}
