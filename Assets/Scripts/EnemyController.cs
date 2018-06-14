using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

	public float minRange;
	public float maxRange;
	public float moveSpeed;

	private float targetDistance;

	private Vector2 targetVector;

	private Rigidbody2D enemy_rb;
	private Rigidbody2D target_rb;

	private GameObject target;

	void Start ()
	{
		enemy_rb = GetComponent<Rigidbody2D>();
		target = GameObject.FindWithTag ("Player");
		target_rb = target.GetComponent<Rigidbody2D>();
		targetVector = enemy_rb.position - target_rb.position;
		targetDistance = targetVector.x;
	}

	void Update ()
	{
		if (targetDistance <= maxRange)
		{
			MoveEnemy (moveSpeed, enemy_rb);

			if (targetDistance >= minRange)
			{
				MoveEnemy (-moveSpeed, enemy_rb);
			}
		}
	}

	void MoveEnemy (float speed, Rigidbody2D rb)
	{
		Vector2 direction = Vector2.left;
		rb.velocity = (direction * speed);
	}

}
