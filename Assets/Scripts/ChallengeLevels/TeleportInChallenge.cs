using UnityEngine;
using System.Collections;

public class TeleportInChallenge : MonoBehaviour {

    public GameObject telaOut;
    void Start()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.transform.position = telaOut.transform.position;
            audio.Play();
        }
    }
}
