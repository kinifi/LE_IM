using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class setFirstSelected : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	public static void setFirstSelectedItem(GameObject _Go)
	{
		EventSystem.current.SetSelectedGameObject(_Go);
		Debug.Log("Set: " + _Go.name);
	}
}
