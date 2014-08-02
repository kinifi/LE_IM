using UnityEngine;
using System.Collections;

public class SpringJump : MonoBehaviour {

	public Vector2 springing = new Vector2(0.0f, 325.0f);

	void OnCollisionEnter2D (Collision2D Player) {
		Player.gameObject.rigidbody2D.AddForce(springing);
		//Debug.Log ("Spring!!!");
	}
}
