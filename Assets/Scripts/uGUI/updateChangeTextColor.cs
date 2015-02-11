using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class updateChangeTextColor : MonoBehaviour {

	public Text m_text;
	public Color m_highlightTextColor, m_normalTextColor;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		if(EventSystem.current.currentSelectedGameObject == this.gameObject)
		{
			m_text.color = m_highlightTextColor;
			//Debug.Log("fuck resume");
		}
		else
		{
			m_text.color = m_normalTextColor;
		}

	}


}
