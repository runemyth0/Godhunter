using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	public float moveSpeed;
	public float pyroCooldown;
	public float meleeCooldown;

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
		StartCoroutine (PyroAttack());
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
	IEnumerator PyroAttack ()
	{
		if (Input.GetButtonDown ("Fire2")) // Checks for when the right mouse button is pressed.
		{
			Instantiate(pyroAttack,pyroSpawn.position,pyroSpawn.rotation); // Creates a clone of the pyroAttack game object (set in inspector).
		}
		yield return new WaitForSeconds (pyroCooldown); // Attack cooldown.
	}


// Close range attack, hits all zones.
	IEnumerator MeleeAttack ()
	{
		if (Input.GetButtonDown ("Fire1")) // Checks for when the left mouse button is pressed.
		{
			meleeAttack.SetActive (true); // Activates the attack.
			yield return new WaitForSeconds (meleeCooldown / 3);
			meleeAttack.SetActive (false); // Deactivates the attack.
		}
		yield return new WaitForSeconds (meleeCooldown); // Attack cooldown.
	}
}
