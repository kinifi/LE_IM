using UnityEngine;
using System.Collections;

public class PlayerInfo : MonoBehaviour {

	public UILabel playerName;

	// Use this for initialization
	void Start () {
	
		playerName.text = "Welcome: " + SteamBasic.getPersonaName();

	}
}
