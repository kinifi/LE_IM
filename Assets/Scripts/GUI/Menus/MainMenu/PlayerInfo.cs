using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerInfo : MonoBehaviour {

	public Text playerName;

	// Use this for initialization
	void Start () {
	
		playerName.text = "" + SteamBasic.getPersonaName();

	}
}
