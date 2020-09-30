using UnityEngine;
using System.Collections;

public class Parallax : MonoBehaviour {

	public Transform[] backgrounds;
	private float[] parallaxScales;
	public float smoothing;

	private Transform cam;


	void Start () 
	{
		cam = Camera.main.transform;


		parallaxScales = new float[backgrounds.Length];

		for (int i = 0; i < backgrounds.Length; i++) 
		{
			parallaxScales [i] = backgrounds [i].position.z * -1;
		}
	}

	void LateUpdate () {
		for (int i = 0; i < backgrounds.Length; i++) 
		{

			float parallax = cam.position.x - (cam.position.x / ((i+1)* 8));
			Vector3 pos = new Vector3(parallax,backgrounds[i].position.y, backgrounds[i].position.z);
			backgrounds[i].position = pos;

		}
}
}