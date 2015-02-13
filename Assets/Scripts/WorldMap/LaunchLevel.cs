﻿using UnityEngine;
using System.Collections;

public class LaunchLevel : MonoBehaviour {

	//---------------------------------------- DUNGEONS -----------------------------------------------------------//
	public void StartIntroScene ()
	{
		Debug.Log ("Preparing to launch Intro Scene");
		Application.LoadLevel("IntroScene");
	}

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
		Debug.Log ("Preparing to launch the Final Level");
		Application.LoadLevel("IntroScene");
	}

	//--------------------------------------- BOSSES ------------------------------------------------//
	public void StartNightmareBoss ()
	{
		Debug.Log ("Preparing to launch Nightmare Boss");
		Application.LoadLevel("ScaredBoss");
	}

	public void StartShootOutBoss ()
	{
		Debug.Log ("Preparing to launch Shoot Out Boss");
		Application.LoadLevel("ShootOutBoss");
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
		Debug.Log ("Preparing to launch Darkness Boss");
	}

	//----------------------------- HOLIDAY LEVELS -----------------------------------------------//
	public void StartVday2015 ()
	{
		Debug.Log ("Preparing to launch Vday2015");
		Application.LoadLevel("Vday2015");
	}
	
}
