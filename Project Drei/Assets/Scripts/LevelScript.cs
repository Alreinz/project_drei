using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelScript : MonoBehaviour {

	public int currentlevel;
	public int enemyCount;

	public Level[] levelList;

	public void Start () {
		enemyCount = 0;
	} 

	public void PrepareLevel () {

	}
}
