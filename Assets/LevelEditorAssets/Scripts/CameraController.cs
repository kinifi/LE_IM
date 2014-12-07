using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

    private float Hor, Vert;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        Hor = Input.GetAxis("Horizontal");
        Vert = Input.GetAxis("Vertical");

        this.transform.position += new Vector3(Hor, Vert, 0);

	}
}
