using UnityEngine;
using System.Collections;

public class MoveEnemy : MonoBehaviour 
{

	public float speedX = 0;
	public float speedY = -1;
	public GameObject EExplosion;
	private Vector3 position;
	private bool sens;
	public int scoreValue;//enemy points
	public ScoreManager scoreManager;

	void Start()
	{
		scoreManager=FindObjectOfType<ScoreManager>();
	}
	// Update is called once per frame
	void FixedUpdate () 
	{
		if (sens) {
			position.x = this.gameObject.transform.position.x + speedX;
			if (position.x >= 2.9f)
				sens = false;
		} 
		else
		{
			position.x = this.gameObject.transform.position.x - speedX;
			if (position.x <= -2.9f)
				sens = true;
		}

		position.y = this.gameObject.transform.position.y + speedY;
		position.z = this.gameObject.transform.position.z;

		this.gameObject.transform.position = position;

	}
	void OnTriggerEnter(Collider col)
	{
		if ((col.tag == "PlayerShipTag") || (col.tag == "Shoot1Tag")) 
		{
			PlayExplosion ();
			Destroy (gameObject);
			scoreManager.score+=scoreValue=100;//add points when destroy
		}
	}

	void PlayExplosion()
	{
		GameObject explosion = (GameObject)Instantiate (EExplosion);
		explosion.transform.position = transform.position;
	}
}
