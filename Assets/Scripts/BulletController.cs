using UnityEngine;
using System.Collections;

public class BulletController : MonoBehaviour {

	public float speed;

	public PlayerController player;

	public GameObject enemyDeathEffect;

	public GameObject impactEffect;

	public int pointsForKill;

	public int damageToGive;

	void Start () 
	{

		player = FindObjectOfType<PlayerController> ();

		if (player.transform.localScale.x < 0) 
		{
			speed = -speed;
			transform.Rotate (0, -180, 0);
		}
	}

	void Update () 
	{
		GetComponent<Rigidbody2D> ().velocity = new Vector2 (speed, GetComponent<Rigidbody2D> ().velocity.y);
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Enemy") 
		{
			//Instantiate (enemyDeathEffect, other.transform.position, other.transform.rotation);
			//Destroy (other.gameObject);
			//ScoreManager.AddPoints (pointsForKill);

			other.GetComponent<EnemyHealthManager> ().giveDamage (damageToGive);
		}

		Instantiate (impactEffect, transform.position, transform.rotation);
		Destroy (gameObject);
	}
}
