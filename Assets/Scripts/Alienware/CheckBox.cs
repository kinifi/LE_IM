using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class CheckBox : MonoBehaviour {


	public GameObject confirmationPanel;
	public Toggle alienwareToggle;
	public GameObject AlienWareObject;

	// Use this for initialization
	void Start () {

		GameObject.Find("EventSystem").GetComponent<EventSystem>().SetSelectedGameObject(GameObject.Find("2_Accept"));

	}
	
	// Update is called once per frame
	void Update () {
	
		if(Input.GetButtonDown("Back"))
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
            HidePopUp();
            Debug.Log("Object Already Created");
		}
        
		
	}

	public void HidePopUp()
	{
		alienwareToggle.isOn = false;
		confirmationPanel.SetActive(false);
		Debug.Log("Hide PopUp");
	}

	public void ConfirmPopUp()
	{
		if(alienwareToggle.isOn == true)
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

