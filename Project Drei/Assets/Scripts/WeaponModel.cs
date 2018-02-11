using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class WeaponModel : MonoBehaviour {

    private SpriteRenderer spriteRenderer;
    public Transform firePosition;

	void Start () {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update() {
        float rotationZ = transform.localEulerAngles.z;
        if (rotationZ > 90 && rotationZ < 270) {
            spriteRenderer.flipY = true;
        } else {
            spriteRenderer.flipY = false;
        }
    }

    void SetWeaponSprite (Sprite weaponSprite ) {
        spriteRenderer.sprite = weaponSprite;
    }
}
