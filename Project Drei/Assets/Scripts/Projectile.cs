using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]
public class Projectile : MonoBehaviour {
    
    public int damage;
    public float speed;
    private Vector2 direction;

    public void Initialize ( Vector2 direction ) {
        this.direction = direction;
        float rotateZ = (Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg);
        transform.rotation = Quaternion.Euler(0f, 0f, rotateZ);
        Debug.Log("bullet facing: " + rotateZ);
        GetComponent<Rigidbody2D>().AddForce(direction * speed, ForceMode2D.Impulse);
    }
	
	// Update is called once per frame
	void Update () {
	}

    public void OnCollisionEnter2D(Collision2D collision ) {
        Destroy(this.gameObject);
    }
}
