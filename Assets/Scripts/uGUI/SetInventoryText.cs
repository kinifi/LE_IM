using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SetInventoryText : MonoBehaviour {

	//Text configs
	Text keyCountText;
	Text bowCountText;


	//Inventory Components to Get
	public int _keyInt;
	public int _arrowInt;

	// Use this for initialization
	void Start () 
	{
		//Get text components
		keyCountText = GameObject.Find ("KeyCountText").GetComponent<Text>();
		bowCountText = GameObject.Find ("BowCountText").GetComponent<Text>();
		Debug.Log ("This is the keyCountText: " + keyCountText + "This is the bowCountText: " + bowCountText);

		//Get inventory components
		_keyInt = GameObject.Find("Player").GetComponent<Inventory>().Keys;
		_arrowInt = GameObject.Find ("Player").GetComponent<Inventory>().Arrows;
	}
	
	// Update is called once per frame
	void Update () 
	{
		GetInventoryValues();
		SetValuesToText();
	}

	//Sets the temp variables to the Inventory values
	private void GetInventoryValues ()
	{
		_keyInt = GameObject.Find("Player").GetComponent<Inventory>().Keys;
		_arrowInt = GameObject.Find ("Player").GetComponent<Inventory>().Arrows;
	}

	private void SetValuesToText ()
	{
		keyCountText.text = _keyInt.ToString();
		bowCountText.text = _arrowInt.ToString();
	}
}
