using UnityEngine;
using System.Collections;

public class EnemyGun : MonoBehaviour 
{
	public GameObject EnemyBullet;

	// Use this for initialization
	void Start () 
	{
		Invoke ("FireEnemyBullet", 1f);
	}


	void FireEnemyBullet()
	{
		GameObject playerShip = GameObject.Find ("Player");

		if (playerShip != null)
		{
			GameObject bullet = (GameObject)Instantiate (EnemyBullet);
			bullet.transform.position = transform.position;

			Vector3 direction = playerShip.transform.position - bullet.transform.position;

			bullet.GetComponent<EnemyBullet> ().SetDirection (direction);
		}
	}
}
