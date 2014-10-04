using UnityEngine;
using System.Collections;

public class Menu_Color_Change : MonoBehaviour {

    private GameObject alien;

	// Use this for initialization
	void Start () {
	
	}

    public void menuSelection()
    {

#if UNITY_STANDALONE_WIN

        if (alienObject())
        {
            Invoke("changeGreen", 0.5f);
            Invoke("changeBlue", 1.5f);
        }

#endif

    }

    private void changeBlue()
    {
        alien.GetComponent<AlienwareFX>().ChangeColor(Color.blue);
    }

    private void changeGreen()
    {
        alien.GetComponent<AlienwareFX>().ChangeColor(Color.green);
    }

    private bool alienObject()
    {

        alien = GameObject.Find("_Alien");

        if (alien != null)
        {

            return true;
        }
        else
        {
            return false;
        }

    }

}
