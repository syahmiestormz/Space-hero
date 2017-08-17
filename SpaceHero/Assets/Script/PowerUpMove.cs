using UnityEngine;
using System.Collections;

public class PowerUpMove : MonoBehaviour {

	public float speed;	
	// Use this for initialization
	void Start ()
	{
		GetComponent<Rigidbody>().velocity = -1 * transform.up * speed;	//Enemy Ship Movement
	}
	

}
