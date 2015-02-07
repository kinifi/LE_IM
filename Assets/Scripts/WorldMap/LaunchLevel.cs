using UnityEngine;
using System.Collections;

public class LaunchLevel : MonoBehaviour {

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	//---------------------------------------- DUNGEONS -----------------------------------------------------------//
	public void StartBasicTheme ()
	{
		Debug.Log ("Preparing to launch Tutorial Dungeon");
		Application.LoadLevel("Tutorial_Dungeon");
	}

	public void StartNightmareTheme ()
	{
		Debug.Log ("Preparing to launch Nightmare Dungeon");
		Application.LoadLevel("Nightmare_Level");
	}

	public void StartDepthsTheme ()
	{
		Debug.Log ("Preparing to launch Depths Dungeon");
		Application.LoadLevel("Purple_Level");
	}

	public void StartForestTheme ()
	{
		Debug.Log ("Preparing to launch Forest Dungeon");
		Application.LoadLevel("Map_Level_Gen");
	}

	public void StartOliveTheme ()
	{
		Debug.Log ("Preparing to launch Olive Dungeon");
		Application.LoadLevel("Olive_Level");
	}

	public void StartRobotTheme ()
	{
		Debug.Log ("Preparing to launch Robot Dungeon");
		Application.LoadLevel("Rouche_Level");
	}

	public void StartDuskTheme ()
	{
		Debug.Log ("Preparing to launch Dusk Dungeon");
		Application.LoadLevel("Dusk_Level");
	}

	public void StartFinalLevel ()
	{
	}

	//--------------------------------------- BOSSES ------------------------------------------------//
	public void StartNightmareBoss ()
	{
		Debug.Log ("Preparing to launch Nightmare Boss");
		Application.LoadLevel("ScaredBoss");
	}

	public void StartShootOutBoss ()
	{
	}

	public void StartDepthsBoss ()
	{
		Debug.Log ("Preparing to launch Depths Boss");
		Application.LoadLevel("DepthsBoss");
	}

	public void StartGoblinBoss ()
	{
		Debug.Log ("Preparing to launch Goblin Boss");
		Application.LoadLevel("GoblinBoss");
	}

	public void StartWolfBoss ()
	{
		Debug.Log ("Preparing to launch Wolf Boss");
		Application.LoadLevel("WolfBoss");
	}

	public void StartRobotBoss ()
	{
		Debug.Log ("Preparing to launch Robot Boss");
		Application.LoadLevel("BullyBoss");
	}

	public void StartDarknessBoss ()
	{
	}
	
}
