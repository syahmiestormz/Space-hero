using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour 
{
	public bool isEnnemy = false;
	public int damage=1;
	public int life =1;
	public int point = 100;
	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}

	void OnTriggerEnter(Collider other)
	{
		try
		{
			if(other.GetComponent<Health>().isEnnemy!=isEnnemy)
			{
				life -=other.GetComponent<Health>().damage;
				if(life<=0)
				{
					try
					{
						if(this.gameObject.name=="Player")
						{
							//Camera.main.gameObject.GetComponent<GameGUI>().setGameOverGUIVisible(true);
							Camera.main.gameObject.GetComponent<GameGUI>().alive= false;
						}
						else
						{
							Camera.main.gameObject.GetComponent<GameGUI>().addScore(point);
						}
					}
					catch
					{
						
					}
					
					Destroy(this.gameObject);
				}
			}
		}

		catch
		{
		}
	}
}
