using UnityEngine;
using System.Collections;

public class DestroyObjectOvertime : MonoBehaviour {

	public float lifetime;

	void Start () 
	{
		
	}

	void Update () 
	{
		lifetime -= Time.deltaTime;

		if (lifetime < 0) 
		{
			Destroy (gameObject);
		}
	}
}
