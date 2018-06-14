using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
	public float targetRange;
	public float moveSpeed;

	private bool lifeCheck = true;

	private Vector2 playerDist;

	private Rigidbody2D rbEnemy;
	private Rigidbody2D rbTarget;

	private GameObject enemyTarget;

	void Awake ()
	{
		rbEnemy = GetComponent<Rigidbody2D>();
		enemyTarget = GameObject.FindWithTag ("Player");
		rbTarget = enemyTarget.GetComponent<Rigidbody2D>();
		playerDist = rbEnemy.position - rbTarget.position;
	}

	void Start ()
	{
		DetectPlayer (targetRange,moveSpeed,lifeCheck,rbEnemy,playerDist);
	}

	void LateUpdate ()
	{
		playerDist = rbEnemy.position - rbTarget.position;
	}

	void DetectPlayer (float range, float speed, bool alive, Rigidbody2D rb, Vector2 dist)
	{
		Vector2 dir = dist.normalized;

		while (alive == true)
		{
			if (dist.magnitude < range)
			{
				enemyMover (speed,rb,dir);
			}
			else
			{
				enemyMover (0.0f,rb,dir);
			}
		}
	}

	void enemyMover (float speed, Rigidbody2D rb, Vector2 dir)
	{
		Vector2 dirX = new Vector2 (dir.x,0.0f);
		rb.velocity = (dirX * speed);
	}
}
