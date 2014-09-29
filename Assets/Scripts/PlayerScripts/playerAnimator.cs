using UnityEngine;
using System.Collections;

public class playerAnimator : MonoBehaviour {

	private Animator anim;
	private float XaxisValue, YAxisValue;
	private bool hurt, celebrate;

	//false = left, true = right
	private bool standing = true;

	//Animation Values:
	//0 - Xvelo
	//1 - Celebrate
	//2 - Death
	//3 - Hurt
	public string[] animationNames;
	public string[] collisionTags;

	// Use this for initialization
	void Start () {
		//get the Animator Component from the GameObject this is attached to
		//Without the Animator we can't Animate or use Mecanim Varables
		anim = GetComponent<Animator>();
		//Debug.Log ("The player is on the ground is: "+ground);

	}
	
	// Update is called once per frame
	void Update () {
	
		//get the horizontal input value so we can animate the player. Such as Run Left & Right
		XaxisValue = Input.GetAxis("Horizontal");

		//call the updateMecanimValues Every Frame so we never miss input
		updateMecanimValues();

		if(XaxisValue > 0 && !standing)
		{
			Flip();
		}
		else if(XaxisValue < 0 && standing)
		{
			Flip();
		}

	}

	private void Flip() {

		//standing = right !standing = left
		standing = !standing;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;

	}


	/// <summary>
	/// Toggles the standing position.
	/// </summary>
	private void toggleStandingPosition() {
		standing = !standing;
		anim.SetBool(animationNames[4], standing);
	}
	

	/// <summary>
	/// Raises the collision enter2 d event.
	/// </summary>
	/// <param name="coll">Collision2D value</param>
	void OnTriggerEnter2D(Collider2D coll) {

		for (int i = 0; i < collisionTags.Length; i++) {
			if(coll.transform.tag == collisionTags[i])
			{
				hurt = true;
				Debug.Log("Death!");
			}
		}

	}

	/// <summary>
	/// Celebrate the player.
	/// </summary>
	public void toggleCelebratePlayer() {
		celebrate = !celebrate;
	}

	/// <summary>
	/// Revives the player.
	/// </summary>
	public void toggleDeathPlayer() {
		hurt = !hurt;
	}

	/// <summary>
	/// Updates the mecanim values.
	/// </summary>
	private void updateMecanimValues() {
		anim.SetFloat(animationNames[0], Mathf.Abs(XaxisValue));
		anim.SetBool(animationNames[2], hurt);
		anim.SetBool(animationNames[1], celebrate);
	}

}
