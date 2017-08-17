
/// - Play Explosion Sound


using UnityEngine;
using System.Collections;

public class explosions_script : MonoBehaviour 
{
	// Use this for initialization
	void Start () 
	{
		GetComponent<AudioSource>().Play(); //Play Explosion Sound
	}
}
