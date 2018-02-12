using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UITextEnemyCount : UITextBase<LevelScript> {

	private int current;
	public Vector2 originalScale;

	public override void Initialize() {
		current = 0;
		originalScale = transform.localScale;
	}

	// Update is called once per frame
	void Update () {
		int enemyCount = target.enemyCount;
		
		UpdateText(enemyCount + "");
		if ( current != enemyCount ) {
			current = enemyCount;
			Animate();
		}

		Vector2 scale = transform.localScale;
		scale = Vector2.Lerp(scale, originalScale, Time.deltaTime * 20);
		transform.localScale = scale;	
	}

	void Animate () {
		transform.localScale = originalScale * 5;
	}
}
