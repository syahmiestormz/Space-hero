using UnityEngine;
using System.Collections;

public class EnemyBullet : MonoBehaviour {

	float speed;
	Vector3 _direction;
	bool isReady;

	void Awake () 
	{
		speed = 5f;
		isReady = false;
	}

	public void SetDirection(Vector3 direction)
	{
		_direction=direction.normalized;
		isReady=true;
	}

	void Update () 
	{
		if (isReady)
		{
			Vector3 position = transform.position;
			position += _direction * speed * Time.deltaTime;
			transform.position = position;

			Vector3 min = Camera.main.ViewportToWorldPoint (new Vector3 (0, 0,0));
			Vector3 max = Camera.main.ViewportToWorldPoint (new Vector3 (1, 1,1));
	
			if ((transform.position.x < min.x) || (transform.position.x > max.x) ||
			   (transform.position.y < min.y) || (transform.position.y > max.y))
			{
				Destroy (gameObject);
			}
		}
	}
		
}
