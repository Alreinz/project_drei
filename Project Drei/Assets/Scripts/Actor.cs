using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ActorState {
	IDLE,
	MOVE,
	ATTACK,
	SPECIAL,
	DEAD
}

[RequireComponent(typeof(Rigidbody2D))]
public class Actor : MonoBehaviour {
    
	private Rigidbody2D body;
    private SpriteRenderer sprite;

	[Header("Properties")]
	public ActorState state;
    public int maxHealth;
    private int currentHealth { get; set; }
    public float speed;
    public float speedLimit;
    
	public float jumpForce;
    
	private bool isJumping;

	protected virtual void Start () {
		state = ActorState.IDLE;
		body = GetComponent<Rigidbody2D>();
	}

    public void MoveUp () {
        body.AddForce(new Vector2(0, speed));
    }

    public void MoveDown() {
        body.AddForce(new Vector2(0, -speed));
    }

    public void MoveLeft () {
		body.AddForce(new Vector2(-speed, 0));
	}

	public void MoveRight () {
		body.AddForce(new Vector2(speed, 0));
	}
    
	protected virtual void OnCollisionStay ( Collision collision ) {
		if ( collision.gameObject.tag == "Terrain" ) {
			isJumping = false;
		}
	}
}
