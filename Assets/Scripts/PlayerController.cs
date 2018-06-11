﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	public float moveSpeed;
	public float pyroCooldown;
	public float meleeCooldown;

	private float nextPyroAttack;
	private float nextMeleeAttack;

	public GameObject pyroAttack;
	public Transform pyroSpawn;

	private Rigidbody2D rb;

	void Start ()
	{
		rb = GetComponent<Rigidbody2D>();
	}

	void Update ()
	{
		if (Input.GetButtonDown("Fire2") && Time.time > nextPyroAttack)
		{
			PyroAttack();
		}

		if (Input.GetButtonDown("Fire1") && Time.time > nextMeleeAttack)
		{
			MeleeAttack();
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
		nextPyroAttack = Time.time + pyroCooldown;
		Instantiate(pyroAttack,pyroSpawn.position,pyroSpawn.rotation);
	}


// Close range attack, hits all zones.
	void MeleeAttack ()
	{
		nextMeleeAttack = Time.time + meleeCooldown;

		Debug.Log ("Melee Attack Successful");
	}
}
