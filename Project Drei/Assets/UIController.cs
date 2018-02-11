using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour {

	public PlayerScript player;
	public Text score;
	public Image health;

	public void Start () {
			
	}

	// Update is called once per frame
	void Update () {
		UpdateHealth();
		UpdateScore();
	}

	void UpdateHealth () {
		health.fillAmount = player.currentHealth / (player.maxHealth * 1f);
	}

	void UpdateScore () {
		score.text = ScoreManager.Instance.score + "";
	}
}
