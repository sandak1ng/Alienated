using UnityEngine;
using System.Collections;

public class EnemyBulletController : MonoBehaviour {

	public float speed;

	public float rotationSpeed;

	public PlayerController player;

	public GameObject impactEffect;

	public int damageToGive;

	void Start () 
	{

		player = FindObjectOfType<PlayerController> ();

		if (player.transform.position.x < transform.position.x) 
		{
			speed = -speed;
			rotationSpeed = -rotationSpeed;
			transform.Rotate (0, -180, 0);
		}
	}

	void Update () 
	{
		GetComponent<Rigidbody2D> ().velocity = new Vector2 (speed, GetComponent<Rigidbody2D> ().velocity.y);

		GetComponent<Rigidbody2D> ().angularVelocity = rotationSpeed;
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.name == "Player") 
		{
			//Instantiate (enemyDeathEffect, other.transform.position, other.transform.rotation);
			//Destroy (other.gameObject);
			//ScoreManager.AddPoints (pointsForKill);

			HealthManager.HurtPlayer (damageToGive);
		}

		Instantiate (impactEffect, transform.position, transform.rotation);
		Destroy (gameObject);
	}
}
