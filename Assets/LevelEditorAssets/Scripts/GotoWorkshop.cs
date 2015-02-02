using UnityEngine;
using System.Collections;

public class GotoWorkshop : MonoBehaviour {

	public string WorkShopItemURL = "steamcommunity.com/workshop/browse/?appid=265670&browsesort=trend&section=readytouseitems";

	// Use this for initialization
	void Start () {
	
	}

	public void GoToWorkShopItemPage()
	{
		SteamBasic.openSteamOverlayToURL(WorkShopItemURL);
		Debug.Log("Opening Overlay to WorkShop Trending Items");
	}

	
}
