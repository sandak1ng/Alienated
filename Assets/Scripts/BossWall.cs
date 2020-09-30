using UnityEngine;
using System.Collections;

public class BossWall : MonoBehaviour {



	void Start () 
	{
		
	}

	void Update () 
	{
		if (FindObjectOfType<EnemyHealthManager> ()) 
		{
			return;
		}

		Destroy (gameObject);
	}
}
