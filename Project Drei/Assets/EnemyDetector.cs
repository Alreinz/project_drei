using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDetector : MonoBehaviour {

	private SpriteRenderer sprite;

	// Use this for initialization
	void Start () {
		sprite = GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
		GameObject player = GameObject.Find("Player");
		
		if ( player ) {
			Vector2 playerPos = player.transform.position;
			float nearest = 9999f;
			int index = 0;

			EnemyGrunt[] enemies = GameObject.FindObjectsOfType<EnemyGrunt>();
			
			for ( int i = 0; i < enemies.Length; i++ ) {
				Vector2 enemyPos = enemies[i].transform.position;
				float distance =  Vector2.Distance(playerPos, enemyPos);
				if ( distance < nearest ) {
					nearest = distance;
					index = i;
				}
			}
			
			Vector2 targetPos = enemies[index].transform.position;
			Vector2 direction =  (playerPos - targetPos).normalized;
			float rotateZ = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
			this.transform.rotation = Quaternion.Euler(0f, 0f, rotateZ);

			sprite.color = new Color(1,1,1,1);
		} else {
			sprite.color = new Color(1,1,1,0);
		}

	}
}
