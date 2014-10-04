using UnityEngine;
using System.Collections;

public class Success_Trigger_Alienware : MonoBehaviour
{

#if UNITY_STANDALONE_WIN

    private GameObject alien;

	// Use this for initialization
	void Start () {
	
	}
	
	void OnTriggerEnter2D (Collider2D coll) {

        if (coll.transform.name == "Player")
        {
            if(alienObject())
            {
                alien.GetComponent<AlienwareFX>().ChangeColor(Color.green);
            }
        }

	}

    private bool alienObject()
    {

        alien = GameObject.Find("_Alien");

        if(alien != null)
        {
            
            return true;
        }
        else
        {
            return false;
        }

    }

#endif
}
