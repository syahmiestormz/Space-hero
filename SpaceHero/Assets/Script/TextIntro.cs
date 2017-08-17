using UnityEngine;
using System.Collections;

public class TextIntro : MonoBehaviour 
{
	public GameObject intro;


	void Start () 
	{
		StartGame ();
	
	}

	void StartGame ()
	{
		intro.SetActive (true);
		StartCoroutine (TextIn ());
	}

	IEnumerator TextIn ()
	{
		yield return new WaitForSeconds (1f);
		intro.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
