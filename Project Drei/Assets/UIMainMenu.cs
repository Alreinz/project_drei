using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIMainMenu : MonoBehaviour {

	public GameObject characterSelectionScreen;
	public CharacterSelection characterSelectionScript;

	public void PlayGame() {
		characterSelectionScript.Initialize();
		characterSelectionScreen.SetActive(true);
		this.gameObject.SetActive(false);
	}

	public void ExitGame () {
		Application.Quit();
	}
}
