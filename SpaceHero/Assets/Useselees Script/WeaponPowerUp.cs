using UnityEngine;
using System.Collections;

public class WeaponPowerUp : MonoBehaviour 
{
	private int compteur = 300;

	// Use this for initialization
	void Start () {
	
	}
	

	void FixedUpdate () 
	{
		if (compteur <= 0)
		{
			Destroy (this.gameObject);

		}
	    
		compteur -= 1;
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.name == "Player")
		{
			Camera.main.gameObject.GetComponent<GameGUI>().addScore(1000);
			other.gameObject.GetComponent<PlayerShoot> ().typeShot += 1;
			Destroy (this.gameObject);

		}
	}

}
