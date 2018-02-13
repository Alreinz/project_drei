using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSelection : MonoBehaviour {

	public new CameraFollowTarget camera;
	public GameObject characterSelected;
	public int index;

	public void Initialize () {
		index = 0;
		GameObject selection = transform.GetChild(index).gameObject;
		camera.target = selection;
		characterSelected = selection;
	}

	public void Reset () {
		camera.target = null;
		index = 0;
	} 

	public void NextCharacter () {
		index++;

		if ( index < transform.childCount ) {
			GameObject selection = transform.GetChild(index).gameObject;
			camera.target = selection;
			characterSelected = selection;
		} else {
			index--;
		}
	}

	public void PreviousCharacter () {
		index--;

		if ( index >= 0 ) {	
			GameObject selection = transform.GetChild(index).gameObject;
			camera.target = selection;
			characterSelected = selection;
		} else {
			index++;
		}
	}
}
