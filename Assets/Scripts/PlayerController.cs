using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	public float moveSpeed;
	public float meleeCooldown;
	public float fireCooldown;

	private	float nextMelee;
	private float nextFire;

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
		if (Input.GetButtonDown("Fire1") && Time.time > nextMelee)
		{
			StartCoroutine (MeleeAttack (meleeCooldown));
			nextMelee = Time.time + meleeCooldown;
		}
		else if (Input.GetButtonDown("Fire2") && Time.time > nextFire)
		{
			PyroAttack ();
			nextFire = Time.time + fireCooldown;
		}
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
		Instantiate(pyroAttack,pyroSpawn.position,pyroSpawn.rotation); // Creates a clone of the pyroAttack game object (set in inspector).
	}

// Close range attack, hits all zones.
	IEnumerator MeleeAttack (float cooldown)
	{
		meleeAttack.SetActive (true); // Activates the attack.
		yield return new WaitForSeconds (cooldown / 3);
		meleeAttack.SetActive (false); // Deactivates the attack.
		StopCoroutine (MeleeAttack(cooldown));
	}

}
