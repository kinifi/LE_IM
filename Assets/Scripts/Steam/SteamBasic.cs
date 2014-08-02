using UnityEngine;
using System.Collections;
using Steamworks;

public class SteamBasic : MonoBehaviour {

	//TODO: Research This
	public static void setStat() {
		//SteamUserStats.GetStat();

	}

	/// <summary>
	/// Stores the stats to steam.
	/// </summary>
	/// <returns><c>true</c>, if stats to steam was stored, <c>false</c> otherwise.</returns>
	public static bool storeStatsToSteam () {
		bool stats = SteamUserStats.StoreStats();
		return stats;
	}


	/// <summary>
	/// Sets the rich presence.
	/// </summary>
	/// <param name="message">STRING : Message to set status for</param>
	public static void setRichPresence(string message, string key = "status") {

		SteamFriends.SetRichPresence(key, message);
	}

	/// <summary>
	/// Clears the rich presence.
	/// </summary>
	public static void clearRichPresence() {

		SteamFriends.ClearRichPresence();
	}

	/// <summary>
	/// Gets the name of the persona.
	/// </summary>
	/// <returns>The persona name.</returns>
	public static string getPersonaName () {

		string name = SteamFriends.GetPersonaName();
		return name;
	}

	/// <summary>
	/// Opens the steam overlay to URL.
	/// </summary>
	/// <param name="URL">URL - Does not require HTTP://</param>
	public static void openSteamOverlayToURL(string URL) {

		string _finalURL = "http://" + URL;
		SteamFriends.ActivateGameOverlayToWebPage(_finalURL);
	}

	/// <summary>
	/// Opens the steam overlay to achievement.
	/// </summary>
	public static void openSteamOverlayToAchievement() {
		SteamFriends.ActivateGameOverlay("Achievements");
	}

	/// <summary>
	/// Opens the steam overlay to community.
	/// </summary>
	public static void openSteamOverlayToCommunity() {

		SteamFriends.ActivateGameOverlay("Community");
	}

}
