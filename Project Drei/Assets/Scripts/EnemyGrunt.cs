using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyState {
	SEARCH, ATTACK, ROAM, IDLE
}

public class EnemyGrunt : Actor {

	[Header("Enemy Properties")]
	public EnemyState enemyState;
	public GameObject player;
	public int score;

	[Header("Attack Properties")]
	public GameObject attack;
	public int attackDamage;
	public float attackDelay;
	public bool attackReady;

	[Header("Behavior")]
	public Vector2 moveDirection;
	public float thinkDelay;
	public float searchTime;
	public float searchRange;
	public float maxMoveTime;
	public float minMoveTime;
	public bool isMoving;


	// Use this for initialization
	protected override void Start () {
		base.Start();
		enemyState = EnemyState.SEARCH;
		SearchPlayer();
		attackReady = true;
	}
	
	// Update is called once per frame
	void Update () {
		Debug.Log(enemyState);
		if ( enemyState == EnemyState.SEARCH ) {
			SearchPlayer();
		} else if ( enemyState == EnemyState.ATTACK ) {
			AttackPlayer();
			SearchPlayer();
		} else if ( enemyState == EnemyState.ROAM ) {
			MoveAround();
		} else {
			Invoke("SearchPlayer", thinkDelay);
		}
	}

	void SearchPlayer () {
		player = GameObject.Find("Player");
		Vector2 playerPos = player.transform.position;
		Vector2 pos = this.transform.position;
		Vector2 direction = (playerPos - pos).normalized;
		///Debug.Log( Vector2.Distance(playerPos, pos) );
		
		RaycastHit2D[] hits = new RaycastHit2D[2];
		GetComponent<BoxCollider2D>().enabled = false;
		RaycastHit2D hit = Physics2D.Raycast(pos, direction, searchRange);
		GetComponent<BoxCollider2D>().enabled = true;
		
		if ( hit.collider != null ) {
			if ( hit.collider.gameObject.name == "Player") {
				enemyState = EnemyState.ATTACK;
			}
		} else {
			player = null;
			enemyState = EnemyState.ROAM;
		}
	}

	void AttackPlayer() {
		if ( attackReady ) {
			state = ActorState.ATTACK;
			Vector2 playerPos = player.transform.position;
			Vector2 pos = transform.position;
			Vector2 direction = (playerPos - pos).normalized;

			GameObject attackObject = GameObject.Instantiate(attack);
			Projectile projectile = attackObject.GetComponent<Projectile>();
			projectile.Initialize(direction);
			projectile.transform.position = transform.position;
			projectile.damage = attackDamage;

			attackReady = false;
			Invoke("Reload", attackDelay);
		} 
	}

	void MoveAround () {
		if ( !isMoving ) {
			moveDirection = Random.insideUnitCircle; 
			body.AddForce(moveDirection * speed);
			float moveTime = Random.Range(minMoveTime, maxMoveTime);
			isMoving = true;
			Invoke("StopMoving", moveTime);
		} else {
			body.AddForce(moveDirection * speed);
		}
	}

	void StopMoving () {
		enemyState = EnemyState.IDLE;
		isMoving = false;
		body.velocity = Vector2.zero;
	}

	void Reload() {
		attackReady = true;
	}

	public void TakeDamage ( int damage ) {
		if ( damage > 0 ) {
			currentHealth -= damage;
			if ( currentHealth <= 0 ) {
				Die();
			}
		}
	}

	public void Die () {
		if ( currentHealth <= 0 ) {
			ScoreManager.Instance.AddScore(score);
			Destroy(this.gameObject);
		}
	}

	private void OnCollisionEnter2D ( Collision2D collision ) {
		GameObject collided = collision.gameObject;
		if ( collided.tag == "FriendlyProjectile" ) {
			Projectile projectile = collided.GetComponent<Projectile>();
			int damage = projectile.damage;
			TakeDamage(damage);
		}
	}
}
