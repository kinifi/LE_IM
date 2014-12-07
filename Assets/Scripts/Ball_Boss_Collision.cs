using UnityEngine;
using System.Collections;

public class Ball_Boss_Collision : MonoBehaviour {

    //Set this to true and attach it to the Idle GameObject
    //Set this to False and attach it to the Ball GameObject
    public bool isIdle = false;
    //assign the parent boss object to this gameobject
    public GameObject Boss;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    private void OnPlayerDeath()
    {
        Debug.Log("Kill the player here");
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        
        if(!isIdle)
        {
            if (coll.gameObject.tag == "Player")
            {
                OnPlayerDeath();
            }
        }
        else if(isIdle)
        {
            //check to see if we are being hit by the arrow
            if (coll.gameObject.tag == "Arrow")
            {
                //call the hurt state on the boss
                Boss.GetComponent<Ball_Boss>().HurtState();
            }
        }
    }

}
