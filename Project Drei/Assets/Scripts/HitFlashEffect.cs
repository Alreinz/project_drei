using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitFlashEffect : MonoBehaviour {

	public Material hitFlashMaterial;
	public Material originalMaterial;
	private SpriteRenderer spriteRenderer;
	public float duration;

	private bool isActive;

	public void Activate (SpriteRenderer spriteRenderer) {
		if ( !isActive ) {
			isActive = true;
			this.spriteRenderer = spriteRenderer;
			originalMaterial = spriteRenderer.material;
			spriteRenderer.material = hitFlashMaterial;
			Invoke("Deactivate", duration);
		}
	}

	private void Deactivate () {
		isActive = false;
		spriteRenderer.material = originalMaterial;
	}
}
