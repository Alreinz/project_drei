using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : Actor {

	public Weapon weapon;
	public WeaponModel weaponModel;
	private Vector2 direction;
	public AudioSource audio;

	// Update is called once per frame
	void Update () {
		Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		Vector2 pos = transform.position;
		direction = (mousePos - pos).normalized;
		float rotateZ = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
		weaponModel.transform.rotation = Quaternion.Euler(0f, 0f, rotateZ);

		if( rotateZ > 90 || rotateZ < -90 ) {
			sprite.flipX = true;
		} else {
			sprite.flipX = false;
		}

		if( Input.GetKey(KeyCode.Mouse0) ) {
			Attack();
		}

		if( Input.GetKey(KeyCode.W) ) {
			MoveUp();
		}

		if( Input.GetKey(KeyCode.S) ) {
			MoveDown();
		}

		if( Input.GetKey(KeyCode.A) ) {
			MoveLeft();
		}

		if( Input.GetKey(KeyCode.D) ) {
			MoveRight();
		}
	}

	public void ResetPosition () {
		transform.position = new Vector2(0, 0);
	}

	public void MoveUp () {
		body.AddForce(new Vector2(0, speed));
	}

	public void MoveDown () {
		body.AddForce(new Vector2(0, -speed));
	}

	public void MoveLeft () {
		body.AddForce(new Vector2(-speed, 0));
	}

	public void MoveRight () {
		body.AddForce(new Vector2(speed, 0));
	}

	public void Attack () {
		if( weapon ) {
			weapon.transform.position = weaponModel.firePosition.position;
			weaponModel.GetComponent<SpriteRenderer>().sprite = weapon.sprite;
			bool weaponFired = weapon.Fire(direction);

			if( weaponFired ) {
				float recoil = weapon.recoil;
				body.AddForce(-direction * recoil, ForceMode2D.Impulse);
				weaponModel.Recoil(direction, recoil);
				ShootSFX();

				GameObject.Find("CameraShake").GetComponent<CameraShake>().shakeAmount = recoil / 100f;
				GameObject.Find("CameraShake").GetComponent<CameraShake>().shakeDuration = .1f;
			}
		}
	}

	void ShootSFX () {
		audio.clip = weapon.shootSFX;
		audio.Play();
	}

	public void TakeDamage ( int damage ) {
		if( damage > 0 ) {
			currentHealth -= damage;
			if( currentHealth <= 0 ) {
				Die();
			}
		}
	}

	public void Die () {
		if( currentHealth <= 0 ) {
			Destroy(this.gameObject);
			EventManager.TriggerEvent("LoseGame");
		}
	}

	private void OnCollisionEnter2D ( Collision2D collision ) {
		GameObject collided = collision.gameObject;
		if( collided.tag == "EnemyProjectile" ) {
			Projectile projectile = collided.GetComponent<Projectile>();
			int damage = projectile.damage;
			TakeDamage(damage);
		}
	}
}
