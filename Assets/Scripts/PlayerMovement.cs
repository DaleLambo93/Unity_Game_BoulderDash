using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	public Rigidbody rb;

	public float jumpForce;
	public Animator anim;

	float testY; 

	public float speed = 5.0f;
	private float animationDurarion = 2.0f;
	private float startTime;

	private Vector3 moveVector;
	public bool isDead = false;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> (); // This get us access to the player rigidbody 
		anim = GetComponent<Animator>(); // This gets the players animator.

		startTime = Time.time;
	}

	// Update is called once per frame
	void Update () {

		if (isDead)
			return;

		if (Time.time - startTime < animationDurarion) 
		{
			rb.transform.Translate (Vector3.forward * speed * Time.deltaTime);
			return;
		}

		moveVector = Vector3.zero;
		// X Axis moves Left and Right
		if (Time.timeScale == 1) {
		GetComponent<AccelerometerManager> ().AccelerometerMove ();
		}
		//Z - Axis moves forward
		moveVector.z = speed;

		rb.transform.Translate (moveVector * Time.deltaTime);
	}

	public void SetSpeed(float modifier)
	{
		speed = 5.0f + modifier;
	}

	public void Jump(){
		// Checks player is not above or below certain Y axis and whether the game is paused and whether the time is greater than the starting animation time to stop player from jumping at the beginning.
		if (rb.transform.position.y > -0.06f && rb.transform.position.y < 0.05f && Time.timeScale == 1 && Time.time - startTime > animationDurarion)// Could do with finding a better way 
		{
			rb.AddForce (new Vector3 (0, jumpForce, 0));
			anim.Play ("JUMP00B", -1, 0f);
			// Add audio sound for player jumping
		}
	}

	public void Slide()
	{		
		// Checks whether the game is paused and whether the time is greater than the starting animation time to stop player from sliding at the beginning.
		if (Time.timeScale == 1 && Time.time - startTime > animationDurarion) 
		{
			anim.Play ("SLIDE00", -1, 0f);
			// Add audio sound for player sliding
		}
	}

	public void RotateRight()
	{
		rb.transform.Rotate(transform.position.x, transform.position.y - 90, transform.position.z);
	}

	public void RotateLeft()
	{
		rb.transform.Rotate(transform.position.x, transform.position.y + 90, transform.position.z);
	}

	// Players Collision
	void OnCollisionEnter(Collision col)
	{
		if (col.gameObject.tag == "Enemy") 
		{
			Death ();
		}
	}

	private void Death()
	{
		isDead = true;
		GetComponent<PlayerScore> ().OnDeath ();
		//Debug.Log("Dead"); // Test player death
	}
}
