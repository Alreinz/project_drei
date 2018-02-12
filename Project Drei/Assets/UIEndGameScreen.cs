using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIEndGameScreen : MonoBehaviour {
	
	public GameObject contents;
	public UIEndGameText endGameText;
	public string loseMessage;
	public string winMessage;

	// Use this for initialization
	void Start () {
		if ( contents ) {
			contents.SetActive(false);
		}
	}

	public void Activate ( bool isWin ) {
		contents.SetActive(true);
		if ( isWin ) {
			endGameText.UpdateText(winMessage);
		} else {
			endGameText.UpdateText(loseMessage);
		}
	}
}
