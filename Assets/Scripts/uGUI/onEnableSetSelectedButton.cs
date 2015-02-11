using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class onEnableSetSelectedButton : MonoBehaviour {

	private void OnEnable()
	{
		GameObject.Find("EventSystem").GetComponent<EventSystem>().SetSelectedGameObject(this.gameObject);
	}
}
