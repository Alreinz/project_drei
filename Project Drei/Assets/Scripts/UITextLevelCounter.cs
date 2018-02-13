using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UITextLevelCounter : UITextBase<LevelScript> {

	private int currentLevel;
	public Vector2 originalScale;

	public override void Initialize () {
		currentLevel = 0;
		originalScale = transform.localScale;
	}
	
	// Update is called once per frame
	void Update () {
		int newLevel = target.currentlevelIndex;
		
		UpdateText(currentLevel + "");
		if ( currentLevel != newLevel ) {
			currentLevel = newLevel;
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
