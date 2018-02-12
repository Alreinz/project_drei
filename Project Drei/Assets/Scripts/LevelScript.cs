using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SpawnBatch {
	public GameObject enemyType;
	public int count;
}

[System.Serializable]
public class Level {
	public SpawnBatch[] spawnBatch;
	public MapScript map;

	public int SpawnEnemies () {
		int totalEnemyCount = 0;
		foreach ( SpawnBatch batch in spawnBatch ) {
			GameObject enemyType = batch.enemyType;
			int count = batch.count;
			totalEnemyCount += count;
			for ( int i = 0; i < count; i++ ) {
				GameObject newEnemy = GameObject.Instantiate(enemyType);
				newEnemy.transform.parent = GameObject.Find("EnemyGroup").transform;
				newEnemy.transform.position = Random.insideUnitCircle * Random.Range(5, (map.mapWidth / 2) - 1);
			}
		}
		return totalEnemyCount;
	}
}

public class LevelScript : MonoBehaviour {

	public int currentlevelIndex;
	public int enemyCount;
	
	public GameObject gameScreen;
	public UIEndGameScreen endGameScreen;

	[SerializeField]
	public Level[] levelList;

	public void Start () {
		enemyCount = 0;
		PrepareLevel();

		EventManager.StartListening("EnemyDied", EnemyDied);
		EventManager.StartListening("LoseGame", LoseGame);
	} 

	public void PrepareLevel () {
		if ( currentlevelIndex < levelList.Length ) {
			Level currentLevel = levelList[currentlevelIndex];
			enemyCount = currentLevel.SpawnEnemies();
			currentlevelIndex++;
		} else if ( currentlevelIndex == levelList.Length ) {
			WinGame();
		}
	}

	public void EnemyDied () {
		enemyCount--;

		if ( enemyCount <= 0 ) {
			PrepareLevel ();
		}
	}

	public void WinGame () {
		gameScreen.SetActive(false);
		endGameScreen.Activate(true);
	}

	public void LoseGame() {
		gameScreen.SetActive(false);
		endGameScreen.Activate(false);
	}
}
