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
    
	[Header("References")]
	protected Rigidbody2D body;
    protected SpriteRenderer sprite;

	[Header("Properties")]
	public ActorState state;
    public int maxHealth;
    protected int currentHealth { get; set; }
    public float speed;
    public float speedLimit;


	protected virtual void Start () {
		state = ActorState.IDLE;
		currentHealth = maxHealth;
		body = GetComponent<Rigidbody2D>();
		sprite = GetComponentInChildren<SpriteRenderer>();
	}
  
}
