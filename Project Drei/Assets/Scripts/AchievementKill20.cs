using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AchievementKill20 : Achievement {

	// Use this for initialization
	void Start () {
		LevelScript level = observableObject.GetComponent<LevelScript>();
		SetObservable(level, variableName);
	}
}
