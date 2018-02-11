using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour {
	
	private static ScoreManager instance = new ScoreManager();
	private ScoreManager() { }
	public static ScoreManager Instance { get { return instance; } }
	
	public int score = 0;

	public void AddScore(int newScore) {
		score += newScore;
	}
}
