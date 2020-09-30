using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float moveSpeed;
	private float moveVelocity;
	public float jumpHeight;

	public Transform groundCheck;
	public float groundCheckRadius;
	public LayerMask whatIsGround;
	private bool grounded;

	private bool doubleJumped;

	private Animator anim;

	public Transform firePoint;
	public GameObject bullet;

	public float shotDelay;
	private float shotDelayCounter;

	public float knockback;
	public float knockbackLength;
	public float knockbackCount;
	public bool knockFromRight;

	void Start () 
	{
		anim = GetComponent<Animator> ();

	}

	void FixedUpdate()
	{
		grounded = Physics2D.OverlapCircle (groundCheck.position, groundCheckRadius, whatIsGround);
	}

	void Update () 
	{
		if (grounded)
			doubleJumped = false;

		anim.SetBool ("grounded", grounded);

		if(Input.GetKeyDown (KeyCode.UpArrow) && grounded)
		{
			//GetComponent<Rigidbody2D> ().velocity = new Vector2 (GetComponent<Rigidbody2D>().velocity.x, jumpHeight);
			Jump();
		}

		if(Input.GetKeyDown (KeyCode.UpArrow) && !doubleJumped && !grounded)
		{
			//GetComponent<Rigidbody2D> ().velocity = new Vector2 (GetComponent<Rigidbody2D>().velocity.x, jumpHeight);
			Jump();
			doubleJumped = true;
		}

		moveVelocity = 0f;

		if(Input.GetKey (KeyCode.RightArrow))
		{
			//GetComponent<Rigidbody2D> ().velocity = new Vector2 (moveSpeed, GetComponent<Rigidbody2D>().velocity.y);
			moveVelocity = moveSpeed;
		}

		if(Input.GetKey (KeyCode.LeftArrow))
		{
			//GetComponent<Rigidbody2D> ().velocity = new Vector2 (-moveSpeed, GetComponent<Rigidbody2D>().velocity.y);
			moveVelocity = -moveSpeed;
		}

		if (knockbackCount <= 0) {
			GetComponent<Rigidbody2D> ().velocity = new Vector2 (moveVelocity, GetComponent<Rigidbody2D> ().velocity.y);
		} else {
			if (knockFromRight)
				GetComponent<Rigidbody2D>().velocity = new Vector2 (-knockback, knockback);
			if(!knockFromRight)
				GetComponent<Rigidbody2D>().velocity = new Vector2 (knockback, knockback);
			knockbackCount -= Time.deltaTime;
		}

		anim.SetFloat ("speed", Mathf.Abs(GetComponent<Rigidbody2D> ().velocity.x));

		if (GetComponent<Rigidbody2D> ().velocity.x > 0)
			transform.localScale = new Vector3 (5f,5f,5f);
		else if (GetComponent<Rigidbody2D> ().velocity.x < 0)
			transform.localScale = new Vector3 (-5f,5f,5f);

		if (Input.GetKeyDown (KeyCode.Space)) 
		{
			Instantiate (bullet, firePoint.position, firePoint.rotation);
			shotDelayCounter = shotDelay;
		}
		if (Input.GetKey (KeyCode.Space)) 
		{
			shotDelayCounter -= Time.deltaTime;

			if (shotDelayCounter <= 0) 
			{
				shotDelayCounter = shotDelay;
				Instantiate (bullet, firePoint.position, firePoint.rotation);
			}
		}
	}

	public void Jump()
	{
		GetComponent<Rigidbody2D> ().velocity = new Vector2 (GetComponent<Rigidbody2D>().velocity.x, jumpHeight);
	}

	void OnCollisionEnter2D(Collision2D other)
	{
		if (other.transform.tag == "MovingPlatform") 
		{
			transform.parent = other.transform;
		}
	}

	void OnCollisionExit2D(Collision2D other)
	{
		if (other.transform.tag == "MovingPlatform") 
		{
			transform.parent = null;
		}
	}
}
