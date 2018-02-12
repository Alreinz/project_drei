using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]
public class Projectile : MonoBehaviour {
    
    public int damage;
    public float speed;
	public float duration;
    private Vector2 direction;
	public bool isDestroyOnHit;

	[Header("Effects")]
	public GameObject effectOnFire;
	public GameObject effectDuring;
	public GameObject effectOnHit;

    public void Initialize ( Vector2 direction ) {
		this.transform.parent = GameObject.Find("BulletGroup").transform;
        this.direction = direction;
        float rotateZ = (Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg);
        transform.rotation = Quaternion.Euler(0f, 0f, rotateZ);
        GetComponent<Rigidbody2D>().AddForce(direction * speed, ForceMode2D.Impulse);
		PlayEffectOnFire();
		Invoke("Die", duration);
    }

	public void Die() {
		Destroy(this.gameObject);
	}

    public void OnCollisionEnter2D(Collision2D collision ) {
		if ( isDestroyOnHit ) {
			PlayEffectOnHit();
			Die();
		}
    }

	private void PlayEffectOnFire () {
		if ( effectOnFire ) {
			foreach(ParticleSystem particle in effectOnFire.GetComponentsInChildren<ParticleSystem>()) {
				particle.Play();
			}
		}
	}

	private void PlayEffectOnHit () {
		if ( effectOnHit ) {
			effectOnHit.transform.parent = null;
			effectOnHit.transform.localScale = new Vector3(1,1,1);
			foreach(ParticleSystem particle in effectOnHit.GetComponentsInChildren<ParticleSystem>()) {
				particle.Play();
			}
		}
	}
}
