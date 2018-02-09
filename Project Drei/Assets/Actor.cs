using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ActorState {
	IDLE,
	MOVE,
	ATTACK,
	SPECIAL,
	JUMP, 
	DEAD
}

[RequireComponent(typeof(Rigidbody))]
public class Actor : MonoBehaviour {

	[Header("References")]
	protected Rigidbody body;

	[Header("Properties")]
	[SerializeField]
	public ActorState state;

	[SerializeField]
	protected int maxHealth;
	protected int currentHealth;

	[SerializeField]
	protected float speed;

	[SerializeField]
	protected float speedLimit;

	[SerializeField]
	protected float acceleration;

	[SerializeField]
	protected float jumpForce;

	[SerializeField]
	protected bool isJumping;

	protected virtual void Start () {
		state = ActorState.IDLE;
		body = GetComponent<Rigidbody>();
	}

	public void MoveLeft () {
		body.AddForce(new Vector3(-speed, 0, 0));
	}

	public void MoveRight () {
		body.AddForce(new Vector3(speed, 0, 0));
	}

	public void Jump () {
		isJumping = true;
		body.AddForce(new Vector3(0, jumpForce, 0));
	}

	protected virtual void OnCollisionStay ( Collision collision ) {
		if ( collision.gameObject.tag == "Terrain" ) {
			isJumping = false;
		}
	}
}
