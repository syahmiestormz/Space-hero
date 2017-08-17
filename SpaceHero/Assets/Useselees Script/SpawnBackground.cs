using UnityEngine;
using System.Collections;

public class SpawnBackground : MonoBehaviour
{
	public GameObject backGround;
	public GameObject GiantIce;
	public GameObject dust1;
	public GameObject nebula1;

	public int compteur = 0;
	public int random = 0;
	private Vector3 randomPosition;

	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void FixedUpdate ()
	{
		if (compteur == 750 || compteur == 1500 || compteur == 1 || compteur == 2250 || compteur == 3000 || compteur == 3750) {
			random = Mathf.RoundToInt (Random.Range (1, 1));
			randomPosition.x = Random.Range (-4, 4);
			randomPosition.y = 7;
			randomPosition.z = 5;

			switch (random) {
			case(1):
				GameObject instance1 = (GameObject)GameObject.Instantiate (GiantIce, randomPosition, GiantIce.transform.rotation);
				instance1.transform.parent = GameObject.FindGameObjectWithTag ("Middleground").transform;

				break;
			}

			if (compteur == 500 || compteur == 1500 || compteur == 2500 || compteur == 3500) {
				random = Mathf.RoundToInt (Random.Range (1, 1));
				randomPosition.x = Random.Range (-4, 4);
				randomPosition.y = 7;
				randomPosition.z = 5;

				switch (random) {
				case(1):
					GameObject instance1 = (GameObject)GameObject.Instantiate (dust1, randomPosition, dust1.transform.rotation);
					instance1.transform.parent = GameObject.FindGameObjectWithTag ("Middleground").transform;

					break;
				}
				if (compteur == 400 || compteur == 2400) {
					random = Mathf.RoundToInt (Random.Range (1, 1));
					randomPosition.x = Random.Range (-4, 4);
					randomPosition.y = 10;
					randomPosition.z = 10;

					switch (random) {
					case(1):
						GameObject instance1 = (GameObject)GameObject.Instantiate (nebula1, randomPosition, nebula1.transform.rotation);
						instance1.transform.parent = GameObject.FindGameObjectWithTag ("Background").transform;

						break;
					}
				}
				
			}
			if (compteur >= 4000) {
				randomPosition.x = 0;
				randomPosition.y = 16;
				randomPosition.z = 10;

				GameObject instance = (GameObject)GameObject.Instantiate (backGround, randomPosition, backGround.transform.rotation);
				instance.transform.parent = GameObject.FindGameObjectWithTag ("Background").transform;
				compteur = 0;
			}

			compteur += 1;

	
		}
	}
}
