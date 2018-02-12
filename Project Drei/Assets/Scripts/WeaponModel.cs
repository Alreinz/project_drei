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
		pos = Vector2.Lerp(pos, originalPosition, Time.deltaTime * 25);
		transform.localPosition = pos;
		FaceMouseDirection();
	}

	public void Recoil (Vector2 direction, float recoil) {
		Vector2 pos = transform.localPosition;
		pos += -direction * (recoil / 4);
		transform.localPosition = pos;
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
