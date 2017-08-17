using UnityEngine;
using System.Collections;

public class MoveObject : MonoBehaviour 
{
	public float speedY=1;//speed of bullet
	public bool isRotated=false;

	void Start ()
	{
		if (isRotated) 
		{
			GetComponent<Rigidbody>().velocity = transform.right * speedY;
		}
		else
		{
			
		    GetComponent<Rigidbody>().velocity = transform.up * speedY;

		}
	
	}
	


}
