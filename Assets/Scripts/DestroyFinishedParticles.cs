using UnityEngine;
using System.Collections;

public class DestroyFinishedParticles : MonoBehaviour {

	private ParticleSystem thisParticleSystem;

	void Start () 
	{
		thisParticleSystem = GetComponent<ParticleSystem> ();
	}

	void Update () 
	{
		Destroy (gameObject, thisParticleSystem.duration);
	}
}
