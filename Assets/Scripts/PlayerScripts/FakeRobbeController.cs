using UnityEngine;
using System.Collections;

public class FakeRobbeController : MonoBehaviour {
	public float speed = 25.0f;
	public float airSpeed = 8.0f;
	public float maxSpeed = 4.0f;
	public float jumpForce = 500.0f;
	public float groundDrag = 1.0f;
	public float airDrag = 0.95f;

	//grounded setup
	public bool grounded = false;
	public bool doubleJump = false;
	public Transform groundCheck;
	public Transform groundCheck2;
	public LayerMask whatIsGround;

	public bool canMove = true;
	private Animator anim;


	void Start(){

		anim = GetComponent<Animator>();
	}

	void FixedUpdate()
	{
		grounded = Physics2D.OverlapArea(groundCheck.position, groundCheck2.position, whatIsGround);
		anim.SetBool("Grounded", grounded);
		//Debug.Log("grounded: " + grounded);
	}

	void Update()
	{



		if(canMove)
		{
			float moveHorizontal = Input.GetAxis("Horizontal");

			Vector2 movement = new Vector2(moveHorizontal, 0.0f);

			if(Mathf.Abs(rigidbody2D.velocity.x) < maxSpeed)
			{
				if(grounded)
				{
					rigidbody2D.AddRelativeForce (movement * speed);
					rigidbody2D.drag = groundDrag;
				}
				else
				{
					rigidbody2D.AddRelativeForce (movement * airSpeed);
					rigidbody2D.drag = airDrag;
				}
			}

			if(Input.GetKeyDown(KeyCode.Space) || Input.GetButtonDown("Jump"))
			{
				if(grounded == true)
				{
					Vector2 jumping = new Vector2(0.0f, jumpForce);
					rigidbody2D.AddRelativeForce(movement + jumping);
					doubleJump = true;
					SteamManager.StatsAndAchievements.incrementNumOfJumps();
					audio.Play();
				}
				else if(doubleJump == true)
				{
					doubleJump = false;
					float zeroV = 0.0f;
					float currentXV = rigidbody2D.velocity.x;
					rigidbody2D.velocity = new Vector2(currentXV, zeroV);
					Vector2 jumping = new Vector2(0.0f, jumpForce);
					rigidbody2D.AddRelativeForce(movement + jumping);
					SteamManager.StatsAndAchievements.incrementNumOfJumps();
					audio.Play();
				}

			}
		}
	}
}    