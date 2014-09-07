using UnityEngine;
using System.Collections;

public class spikeshooting : MonoBehaviour {

	public float shotSpeed;
	public enum Shooting_Direction { Up, Down, Left, Right }
	public Shooting_Direction _shootingDirection;
	public GameObject ObjectToShootVertical, ObjectToShootHorizontal;

	public float shootingTime = 2.0f;
	private float secondaryShootingTime;

	void Start ()
	{
		secondaryShootingTime = shootingTime;
		
	}

	void Update() {

		shootingTime -= Time.deltaTime;

		if(shootingTime < 0)
		{
			shootingTime = secondaryShootingTime;
			shootObject();
		}

	}

	void OnCollisionEnter2D (Collision2D other)
	{
		if(other.gameObject.tag == "Player")
		{
			Destroy(this.gameObject);
		}
	}

	private void shootObject() {

		if(_shootingDirection == Shooting_Direction.Up)
		{
			GameObject _shootingObj;
			_shootingObj = Instantiate(ObjectToShootVertical, this.transform.position, Quaternion.identity) as GameObject;
			_shootingObj.rigidbody2D.AddForce(Vector2.up * shotSpeed);
		}
		else if(_shootingDirection == Shooting_Direction.Down)
		{
			GameObject _shootingObj;
			_shootingObj = Instantiate(ObjectToShootVertical, this.transform.position, Quaternion.identity) as GameObject;
			_shootingObj.transform.localScale = new Vector3(_shootingObj.transform.localScale.x, -_shootingObj.transform.localScale.y, _shootingObj.transform.localScale.z);
			_shootingObj.rigidbody2D.AddForce(-Vector2.up * shotSpeed);
		}
		else if(_shootingDirection == Shooting_Direction.Right)
		{
			GameObject _shootingObj;
			_shootingObj = Instantiate(ObjectToShootHorizontal, this.transform.position, Quaternion.identity) as GameObject;
			_shootingObj.transform.localScale = new Vector3(-_shootingObj.transform.localScale.x, _shootingObj.transform.localScale.y, _shootingObj.transform.localScale.z);
			_shootingObj.rigidbody2D.AddForce(Vector2.right * shotSpeed);
		}
		else if(_shootingDirection == Shooting_Direction.Left)
		{
			GameObject _shootingObj;
			_shootingObj = Instantiate(ObjectToShootHorizontal, this.transform.position, Quaternion.identity) as GameObject;
			_shootingObj.rigidbody2D.AddForce(-Vector2.right * shotSpeed);
		}
		
	}

}
