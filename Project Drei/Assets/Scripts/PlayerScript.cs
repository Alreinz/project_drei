using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : Actor {

    public Weapon weapon;
    public WeaponModel weaponModel;

    private Vector2 direction;

	// Update is called once per frame
	void Update () {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 pos = transform.position;
        direction = (mousePos - pos).normalized;
        float rotateZ = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        weaponModel.transform.rotation = Quaternion.Euler(0f, 0f, rotateZ);

        if ( Input.GetKey(KeyCode.Mouse0)) {
            Attack();
        }

		if ( Input.GetKey(KeyCode.W)) {
			MoveUp();
		}

		if ( Input.GetKey(KeyCode.S)) {
			MoveDown();
        }

        if (Input.GetKey(KeyCode.A)) {
            MoveLeft();
        }

        if (Input.GetKey(KeyCode.D)) {
            MoveRight();
        }
    }

    public void EquipWeapon ( Weapon weapon ) {

    }

    public void Attack() {
        if ( weapon != null ) {
            weapon.transform.position = weaponModel.firePosition.position;
            weaponModel.GetComponent<SpriteRenderer>().sprite = weapon.sprite;
            bool weaponFired = weapon.Fire(direction);
            if ( weaponFired ) {    
                float rotateZ = Mathf.Atan2(direction.normalized.y, direction.normalized.x) * Mathf.Rad2Deg;
                Debug.Log("player facing: " + rotateZ);
            }
        }
    }
}
