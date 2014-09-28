using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Alienware;
using AlienFXManagedWrapper;

public class AlienwareFX : MonoBehaviour {

	private FXLight keyboardLight;
	private FXZone zoneAll;

	// Use this for initialization
	void Start () {

		DontDestroyOnLoad(this.gameObject);
		loadAlienFX();
	}
	
	///<Summary>
	///Is the Alienware LightFX Loaded?
	///</Summary>
	public bool isAlienFXLoaded ()
	{
		if (AlienFX.isLoaded || AlienFX.isInit)
		{
			return true;
		}
		else
		{
			return false;
		}
	}

	///<Summary>
	/// Is the Alienware LightFX Loaded?
	/// Can only be loaded when AlienFX has been init or Loaded
	///</Summary>
	public void loadAlienFX()
	{
		if(!isAlienFXLoaded())
		{
			AlienFX.Load();
				
			keyboardLight = AlienFX.GetLightByName("Keyboard");
			
			if(keyboardLight == null)
			{
				Debug.LogError("Keyboard is null");
			}
			else 
			{
				zoneAll = AlienFX.GetZoneByPosition(LFX_Position.LFX_All);	
				ChangeColor(Color.green);
			}
		}
		else
		{
			Debug.LogWarning("Alienware LightFX is not loaded");
		}
	}

	///<Summary>
	/// Get the current Color being used
	///</Summary>
	public Color getCurrentColor()
	{
		return zoneAll.color;
	}

	///<Summary>
	///Change the color of the lights
	///</Summary>
	///<Param>Color</Param>
	public void ChangeColor(Color newColor)
	{
		zoneAll.color = newColor;
	}

	/// <summary>
	/// Raises the destroy event and releases the Alienware Lights
	/// </summary>
	private void OnDestroy()
	{
		if (AlienFX.isLoaded || AlienFX.isInit)
		{
			AlienFX.RemoveZone (zoneAll);
		}
	}
}
