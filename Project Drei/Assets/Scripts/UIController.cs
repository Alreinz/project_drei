using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour {

	public PlayerScript player;
	public Image health;

	public void Start () {
		player = GameObject.Find("Player").GetComponent<PlayerScript>();
	}

	// Update is called once per frame
	void Update () {
		UpdateHealth();
	}

	void UpdateHealth () {
		health.fillAmount = player.currentHealth / (player.maxHealth * 1f);
	}

	public void ReturnToMainMenu () {
		SceneManager.LoadScene(0);
	}

	public void RestartGame () {
		SceneManager.LoadScene(1);
	}
}
