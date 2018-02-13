using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyState {
	SPAWNING, SEARCH, ATTACK, ROAM, IDLE
}

public class EnemyGrunt : Actor {

	[Header("Enemy Properties")]
	public EnemyState enemyState;
	public GameObject player;

	[Header("Attack Properties")]
	public GameObject attack;
	public int attackDamage;
	public float attackDelay;
	public float attackRange;
	public bool attackReady;

	[Header("Behavior")]
	public Vector2 moveDirection;
	public float thinkDelay;
	public float searchTime;
	public float searchRange;
	public float maxMoveTime;
	public float minMoveTime;

	[Header("Effects")]
	public ParticleSystem duringSpawn;
	public ParticleSystem effectOnSpawn;
	public ParticleSystem effectOnDeath;

	public bool isReady;
	public bool isMoving;


	// Use this for initialization
	protected override void Start () {
		base.Start();
		enemyState = EnemyState.SPAWNING;
		SearchPlayer();
		attackReady = true;
		isReady = false;
		Invoke("Activate", 3f);
		body.isKinematic = true;
		transform.localScale = new Vector3(1, 0, 1);
	}
	
	// Update is called once per frame
	void Update () {
		if ( isReady ) {
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
		} else {
			transform.localScale = Vector3.Lerp(transform.localScale, new Vector3(1, 1, 1), Time.deltaTime);
		}
	}

	public void Activate () {
		if ( effectOnSpawn ) {
			effectOnSpawn.Play();
		}
		body.isKinematic = false;
		isReady = true;
	}

	void SearchPlayer () {
		player = GameObject.Find("Player");
		if ( player ) {
			Vector2 playerPos = player.transform.position;
			Vector2 pos = this.transform.position;
			Vector2 direction = (playerPos - pos).normalized;

		
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

			
			if ( playerPos.x > pos.x ) {
				sprite.flipX = true;
			} else {
				sprite.flipX = false;
			}
		} else {
			enemyState = EnemyState.ROAM;
		}
	}

	void AttackPlayer() {
		if ( attackReady ) {
			state = ActorState.ATTACK;
			Vector2 playerPos = player.transform.position;
			Vector2 pos = transform.position;
			Vector2 direction = (playerPos - pos).normalized;
			if ( Vector2.Distance(playerPos, pos) <= attackRange ) {
				
				GameObject attackObject = GameObject.Instantiate(attack);
				Projectile projectile = attackObject.GetComponent<Projectile>();
				projectile.Initialize(direction);
				projectile.transform.position = transform.position;
				projectile.damage = attackDamage;

				attackReady = false;
				Invoke("Reload", attackDelay);
			} else {
				body.AddForce(direction * speed);
			}
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
			if ( effectOnDeath ) {
				effectOnDeath.transform.parent = null;
				effectOnDeath.Play();
			}

			EventManager.TriggerEvent("EnemyDied");
			Destroy(this.gameObject);
		}
	}

	private void OnCollisionEnter2D ( Collision2D collision ) {
		if ( isReady ) {
			GameObject collided = collision.gameObject;
			if ( collided.tag == "FriendlyProjectile" ) {
				Projectile projectile = collided.GetComponent<Projectile>();
				int damage = projectile.damage;
				TakeDamage(damage);
				GetComponent<HitFlashEffect>().Activate(sprite);
			}
		}
	}
}
