using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AchievementText : MonoBehaviour {

	public TextMesh titleTextMesh;
	public TextMesh descriptionTextMesh;
	public float duration;

	public void Update () {
		Color color = titleTextMesh.color;
		color.a -= .001f;
		titleTextMesh.color = color;
		descriptionTextMesh.color = color;
	}

	public void SetText ( string title, string descriptipn ) {
		titleTextMesh.text = title;
		descriptionTextMesh.text = descriptipn;
		Invoke("Die", duration);
	}
	
	public void Die() {
		Destroy(this.gameObject);
	}
}
