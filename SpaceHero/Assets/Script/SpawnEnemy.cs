using UnityEngine;
using System.Collections;

public class SpawnEnemy : MonoBehaviour 
{

	public GameObject flea;
	public int coolDown = 20;
	public float movement = 0.01f;
	private bool sens = true;
	private Vector3 enemyPosition;
	private int compteur = 0;
	private float random;

	// Use this for initialization
	void Start () 
	{
		enemyPosition.z = 0;
		enemyPosition.y = 5.5f;
		enemyPosition.x = 0;

	}

	// Update is called once per frame
	void FixedUpdate () 
	{

		if (coolDown <= compteur) 
		{
			random = Random.Range (0, 100);

			if (random>=0) 
			{
				GameObject instance = (GameObject) GameObject.Instantiate (flea, enemyPosition, flea.transform.rotation);
				instance.transform.parent = GameObject.FindGameObjectWithTag ("Foreground").transform;

			}
			compteur = 0;
		}

		compteur += 1;
		if (sens) {
			enemyPosition.x += movement;
			if (enemyPosition.x >= 3)
				sens = false;
		} else 
		{
			enemyPosition.x -= movement;
			if (enemyPosition.x <= -3)
				sens = true;
		}
	}
}