using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : Actor {

	// Update is called once per frame
	void Update () {
		if ( Input.GetKey(KeyCode.Space) && !isJumping) {
			Jump();
		}
		
		if ( Input.GetKey(KeyCode.D)) {
			MoveRight();
		}

		if ( Input.GetKey(KeyCode.A)) {
			MoveLeft();
		}
	}
}
