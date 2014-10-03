using UnityEngine;
using System.Collections;

public class CheckBox : MonoBehaviour {

	public GameObject confirmationPanel;
	public UIToggle alienwareToggle;
	public GameObject AlienWareObject;

	// Use this for initialization
	void Start () {

#if !UNITY_STANDALONE_WIN
		alienwareToggle.enabled = false;
#endif

	}
	
	// Update is called once per frame
	void Update () {
	
		if(Input.GetButtonDown("Fire2"))
		{
			HidePopUp();
		}

	}

	public void confirmAlienware()
	{
		if(GameObject.Find("_Alien") == null)
		{
			GameObject alien;
			alien = Instantiate(AlienWareObject, new Vector2(0 ,0), Quaternion.identity) as GameObject;
			alien.name = "_Alien";
			Debug.Log("Created Alienware Object");
			HidePopUp();
		}
		else
		{
			Debug.Log("Object Already Created");
		}

		HidePopUp();
	}

	public void HidePopUp()
	{
		alienwareToggle.value = false;
		confirmationPanel.SetActive(false);
		Debug.Log("Cancel");
	}

	public void ConfirmPopUp()
	{
		if(alienwareToggle.value == true)
		{
			confirmationPanel.SetActive(true);
		}
		else
		{
			HidePopUp();
			confirmationPanel.SetActive(false);
		}
	}


}
