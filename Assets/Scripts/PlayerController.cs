using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	public float moveSpeed;
	public float pyroCooldown;
	public float meleeCooldown;

	private float nextPyroAttack;

	public GameObject pyroAttack;
	public Transform pyroSpawn;

	public GameObject meleeAttack;

	private Rigidbody2D rb;

	void Start ()
	{
		rb = GetComponent<Rigidbody2D>();
		meleeAttack.SetActive (false);
	}

	void Update ()
	{
		if (Input.GetButtonDown("Fire2") && Time.time > nextPyroAttack)
		{
			nextPyroAttack = Time.time + pyroCooldown;
			PyroAttack();
		}

		StartCoroutine (MeleeAttack ());
	}

	void FixedUpdate ()
	{
		float moveHorizontal = Input.GetAxis ("Horizontal");

		Vector2 movement = new Vector2 (moveHorizontal,0.0f);
		rb.velocity = (movement * moveSpeed);
	}

// Attack Functions

// Ranged attack, planned to stun enemies (eventually).
	void PyroAttack ()
	{
		Instantiate(pyroAttack,pyroSpawn.position,pyroSpawn.rotation);
	}


// Close range attack, hits all zones.
	IEnumerator MeleeAttack ()
	{
		if (Input.GetButtonDown ("Fire1")) // Checks for when you press the left mouse button.
		{
			meleeAttack.SetActive (true); // Activates the attack.
			yield return new WaitForSeconds (meleeCooldown / 3);
			meleeAttack.SetActive (false); // Deactivates the attack.
		}
		yield return new WaitForSeconds (meleeCooldown); // Attack cooldown.
	}
}
