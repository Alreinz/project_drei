using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class WeaponModel : MonoBehaviour {

	private Vector2 originalPosition;
    private SpriteRenderer spriteRenderer;
    public Transform firePosition;

	void Start () {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update() {
		ResetOriginalPosition();
		FaceMouseDirection();
    }

    void SetWeaponSprite (Sprite weaponSprite ) {
        spriteRenderer.sprite = weaponSprite;
    }

	void ResetOriginalPosition () {
		Vector2 pos = transform.localPosition;
		pos = Vector2.Lerp(pos, originalPosition, Time.deltaTime * 50);
		transform.localPosition = pos;
		FaceMouseDirection();
	}

	void FaceMouseDirection () {
        float rotationZ = transform.localEulerAngles.z;
        if (rotationZ > 90 && rotationZ < 270) {
            spriteRenderer.flipY = true;
        } else {
            spriteRenderer.flipY = false;
        }
	}
}
