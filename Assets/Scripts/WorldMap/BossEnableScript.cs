using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BossEnableScript : MonoBehaviour {

	//Boss temp variable configs
	private string bossOne;
	private string bossTwo;
	private string bossThree;
	private string bossFour;
	private string bossFive;
	private string bossSix;
	private string bossSeven;

	// Use this for initialization
	void Awake () 
	{
		//Get bossOne Status from player prefs
		bossOne = PlayerPrefs.GetString("ScaredBoss");
		//Turn on stamp image if complete
		if(bossOne == "completed")
		{
			GameObject.Find ("Stamp_Nightmare").GetComponent<Image>().enabled = true;
			GameObject.Find("Stamp_Nightmare").GetComponent<Button>().interactable = true;
		}

		//Get bossTwo Status from player prefs
		bossTwo = PlayerPrefs.GetString("ShootOutBoss");
		//Turn on stamp image if complete
		if(bossTwo == "completed")
		{
			GameObject.Find ("Stamp_ShootOut").GetComponent<Image>().enabled = true;
			GameObject.Find("Stamp_ShootOut").GetComponent<Button>().interactable = true;
		}

		//Get bossThree Status from player prefs
		bossThree = PlayerPrefs.GetString("DepthsBoss");
		//Turn on stamp image if complete
		if(bossThree == "completed")
		{
			GameObject.Find ("Stamp_Depths").GetComponent<Image>().enabled = true;
			GameObject.Find("Stamp_Depths").GetComponent<Button>().interactable = true;
		}

		//Get bossFour Status from player prefs
		bossFour = PlayerPrefs.GetString("GoblinBoss");
		//Turn on stamp image if complete
		if(bossFour == "completed")
		{
			GameObject.Find ("Stamp_Goblin").GetComponent<Image>().enabled = true;
			GameObject.Find("Stamp_Goblin").GetComponent<Button>().interactable = true;
		}

		//Get bossFive Status from player prefs
		bossFive = PlayerPrefs.GetString("WolfBoss");
		//Turn on stamp image if complete
		if(bossFive == "completed")
		{
			GameObject.Find ("Stamp_Wolf").GetComponent<Image>().enabled = true;
			GameObject.Find("Stamp_Wolf").GetComponent<Button>().interactable = true;
		}

		//Get bossSix Status from player prefs
		bossSix = PlayerPrefs.GetString("BullyBoss");
		//Turn on stamp image if complete
		if(bossSix == "completed")
		{
			GameObject.Find ("Stamp_Robot").GetComponent<Image>().enabled = true;
			GameObject.Find("Stamp_Robot").GetComponent<Button>().interactable = true;
		}

		//Get bossSeven Status from player prefs
		bossSeven = PlayerPrefs.GetString("DarknessBoss");
		//Turn on stamp image if complete
		if(bossSeven == "completed")
		{
			GameObject.Find ("Stamp_Darkness").GetComponent<Image>().enabled = true;
			GameObject.Find("Stamp_Darkness").GetComponent<Button>().interactable = true;
		}
	}
}
