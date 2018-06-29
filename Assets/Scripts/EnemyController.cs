using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
	private GameObject player;
	private Rigidbody2D playerRB;

	public GameObject attack;
	private Rigidbody2D selfRB;

	private Vector2 dist;
	private Vector2 dir;
	private bool facingLeft;
	public float maxRange;
	public float atkRange;
	public float minRange;
	public float atkCD;
	private float nextAtk;

	public float maxMoveSpeedE;
	private float moveSpeedE;

	void Awake ()
	{
		// Find and get player's rigidbody
		player = GameObject.FindWithTag ("Player");
		playerRB = player.GetComponent<Rigidbody2D>();
		// Get self rigidbody
		selfRB = GetComponent<Rigidbody2D>();
		// Set starting variables
		moveSpeedE = maxMoveSpeedE;
		facingLeft = false;
		attack.SetActive (false);
	}

	void Update ()
	{
		dist = playerRB.position - selfRB.position; // Calculates a Vector2 pointing at the player
		dist.y = 0; // Make the dist vector horizontal
		dir = dist / dist.magnitude; // Calculates a unit vector from dist
		Debug.Log (dist.magnitude);

		if (dir.magnitude < 0) // Checks if player is to the left of the enemy, then flips it to the left if it is not already;
		{
			facingLeft = true;
		}
	}

	void FixedUpdate ()
	{
		if (dist.sqrMagnitude < minRange * minRange)
		{
			Debug.Log ("Retreating");
			// Retreat code
			transform.Translate (-dir * moveSpeedE * Time.deltaTime);
		}
		else if (dist.sqrMagnitude < atkRange * atkRange && Time.time > nextAtk) // Compare dist to attack range and maximum range
		{
			Debug.Log ("Stopping and attacking");
			moveSpeedE = 0; // Set move speed to zero
			StartCoroutine (EnemyAttack ()); // Initiate attack function
			nextAtk = Time.time + atkCD; // Increase next attack timer
		}
		else if (dist.sqrMagnitude < maxRange * maxRange) // Distance compared to maximum range
		{
			Debug.Log ("Chasing player");
			// Chase code
			transform.Translate (dir * moveSpeedE * Time.deltaTime);
		}
	}

	IEnumerator EnemyAttack ()
	{
		Debug.Log ("Activating attack");
		attack.SetActive (true);
		yield return new WaitForSeconds (atkCD / 3);
		Debug.Log ("Deactivating attack");
		attack.SetActive (false);
		Debug.Log ("Setting move speed to max");
		moveSpeedE = maxMoveSpeedE;
		StopCoroutine (EnemyAttack ());
	}
}
