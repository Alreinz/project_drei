using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AchievementSystem : MonoBehaviour {
	
	public Achievement[] achievementList;
	public GameObject achievementTextObject;
	public AudioClip achievementSound;
	public AudioSource audio;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		foreach ( Achievement achievement in achievementList ) {
			if ( achievement.isComplete && !achievement.isProcessed) {
				achievement.isProcessed = true;
				CreateScreenMessage(achievement);
			}
		}
	}

	void CreateScreenMessage (Achievement achievement) {
		GameObject newAchievementMessage = GameObject.Instantiate(achievementTextObject);
		AchievementText newAchievementMessageScript = newAchievementMessage.GetComponent<AchievementText>();
		newAchievementMessageScript.SetText( achievement.title, achievement.description);

		Vector2 pos = GameObject.Find("Player").transform.position;
		newAchievementMessage.transform.position = pos + new Vector2(0, 1.5f);
	
		audio.clip = achievementSound;
		audio.Play();
	}
}
