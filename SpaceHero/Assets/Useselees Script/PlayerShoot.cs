using UnityEngine;
using System.Collections;

public class PlayerShoot : MonoBehaviour
{

	public GameObject shot;
	public int coolDown=0;

	public int typeShot = 1;
	private Vector3 shotPosition;
	private GameObject forGround;
	private int compteur=0;


	void Start () 
	{
		forGround = GameObject.FindGameObjectWithTag ("Foreground");
	
	}
	

	void FixedUpdate () 
	{
		if (Input.GetButton ("Fire1")) 
		{
			if (compteur<= 0)
			{
				shotPosition.x = this.gameObject.transform.position.x;
				shotPosition.y = this.gameObject.transform.position.y + 0.8f;
				shotPosition.z = this.gameObject.transform.position.z;

				AudioSource audio = GetComponent<AudioSource> ();
				audio.Play();

				switch (typeShot) 
				{
				case 1:
					GameObject instance = (GameObject)GameObject.Instantiate (shot, shotPosition, this.gameObject.transform.rotation);
					instance.name = shot.name;
					instance.transform.parent = forGround.transform.parent;
					break;
				case 2:
				default:
					GameObject instance2 = (GameObject)GameObject.Instantiate (shot, shotPosition, this.gameObject.transform.rotation);
					instance2.name = shot.name;
					instance2.transform.parent = forGround.transform.parent;
					GameObject instance3 = (GameObject)GameObject.Instantiate (shot, shotPosition, Quaternion.Euler(new Vector3(0,0,10)));
					instance3.name = shot.name;
					instance3.transform.parent = forGround.transform.parent;
					GameObject instance4 = (GameObject)GameObject.Instantiate (shot, shotPosition, Quaternion.Euler(new Vector3(0,0,-10)));
					instance4.name = shot.name;
					instance4.transform.parent = forGround.transform.parent;
					break;

				}
				compteur = coolDown;
			}
		}

		compteur -= 1;
	
	}

	void OnTriggerEnter(Collider col)
	{
		if ((col.tag == "EnemyShipTag") || (col.tag == "AsteroidTag")) 
		{
			Destroy (gameObject);
		}
	}
}
