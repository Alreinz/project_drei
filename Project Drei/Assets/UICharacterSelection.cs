using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UICharacterSelection : MonoBehaviour {

	public GameObject mainMenuScreen;
	public CharacterSelection selection;

	public void SelectCharacter () {
		GameScript.characterSelected = selection.index;
		SceneManager.LoadScene(1);
	}

	public void ReturnToMainMenu () {
		mainMenuScreen.SetActive(true);
		this.gameObject.SetActive(false);
	}
}
