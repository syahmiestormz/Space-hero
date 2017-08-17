using UnityEngine;
using System.Collections;

public class SpawnAsteroid : MonoBehaviour 
{
	public GameObject asteroid;
	public int coolDown = 20;
	private Vector3 asteroidPosition = new Vector3 (0, 5.5f, 0);
	private int compteur = 0;
	private int random=0;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
	  
		if (coolDown <= compteur) 
		{
			random = Mathf.RoundToInt (Random.Range (1, 1.99f));
			asteroidPosition.x = Random.Range (-3f, 3f);

			switch (random) 
			{
			case 1:
				GameObject instance = (GameObject)GameObject.Instantiate (asteroid, asteroidPosition, asteroid.transform.rotation);
				instance.transform.parent = GameObject.FindGameObjectWithTag ("Foreground").transform;
				break;
					
			}
			compteur = 0;
		}

		compteur += 1;
	}
}
