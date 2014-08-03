using UnityEngine;
using System;

public class Quiver : MonoBehaviour {

	public int bow = 0;
	public GameObject[] blockbreaker;
	public Transform getTransform;

	private float RSX, RSY;

	void Update ()
	{
		RSX = Input.GetAxis("ShootHorizontal");
		RSY = Input.GetAxis("ShootVertical");

		if(bow > 0)
		{
			Transform shootTransform = getTransform;

			GameObject projectile;
			if(Input.GetKeyDown(KeyCode.W) || RSY > 0.8)
			{
				RSY = 0.0f;
				projectile = Instantiate(blockbreaker[0], shootTransform.position, Quaternion.identity) as GameObject;
				projectile.GetComponent<ArrowMover>().ShootUp();
				bow -= 1;
				deductArrows(1);
				//Debug.Log (bow);
			}
			if(Input.GetKeyDown(KeyCode.S) || RSY < -0.8)
			{
				RSY = 0.0f;
				projectile = Instantiate(blockbreaker[1], shootTransform.position, Quaternion.identity) as GameObject;
				projectile.GetComponent<ArrowMover>().ShootDown();
				bow -= 1;
				deductArrows(1);
				//Debug.Log (bow);
			}
			if(Input.GetKeyDown(KeyCode.D) || RSX > 0.8)
			{
				RSX = 0.0f;
				projectile = Instantiate(blockbreaker[2], shootTransform.position, Quaternion.identity) as GameObject;
				projectile.GetComponent<ArrowMover>().ShootRight();
				bow -= 1;
				deductArrows(1);
				//Debug.Log (bow);
  			}
			if(Input.GetKeyDown(KeyCode.A) || RSX < -0.8)
			{
				RSX = 0.0f;
				projectile = Instantiate(blockbreaker[3], shootTransform.position, Quaternion.identity) as GameObject;
				projectile.GetComponent<ArrowMover>().ShootLeft();
				bow -= 1;
				deductArrows(1);
				//Debug.Log (bow);
			}
		}
	}

	public void deductArrows(int value)
	{
		Inventory _inventory = GameObject.Find("Player").GetComponent<Inventory>();
		//bow -= value;
		_inventory.Arrows -= value;
		Debug.Log(_inventory.Arrows);
		_inventory.startCollectTimer = true;
	}

	public void addArrows(int value)
	{
		Inventory _inventory = GameObject.Find("Player").GetComponent<Inventory>();
		//bow += value;
		_inventory.Arrows += value;
		Debug.Log(_inventory.Arrows);
		_inventory.startCollectTimer = true;
	}


}
