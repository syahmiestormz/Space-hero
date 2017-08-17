using UnityEngine;
using System.Collections;


public class Barrier : MonoBehaviour
{

	public GameObject RestartPanel;

	void OnTriggerEnter(Collider col)
	{
		if (col.tag == "LBoss") {
			Destroy (gameObject);
			RestartPanel.SetActive (true);
		}
	}
}
