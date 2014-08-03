using UnityEngine;
using System.Collections;
using Steamworks;

public class steamTest : MonoBehaviour {

	private int testStat = 0;

	// Use this for initialization
	void Start () {
		Console.AddCommand(new ConsoleCommand("getValues", "gets a stat from the server", CmdParameterType.None, this.gameObject, "getValues"));
		Console.AddCommand(new ConsoleCommand("createTest", "Adds to the game var", CmdParameterType.None, this.gameObject, "createTest"));
	}
	
	public void createTest()
	{
		SteamManager.StatsAndAchievements.incrementNumOfGames();
	}

	public void getValues()
	{
		SteamManager.StatsAndAchievements.getStats();
	}
}
