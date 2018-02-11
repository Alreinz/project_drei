using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitializeScene : MonoBehaviour {

	public CameraFollowTarget camera;

	public GameObject[] characters;

	// Use this for initialization
	void Start () {
		GameObject character = characters[GameScript.characterSelected];
		GameObject player = GameObject.Instantiate(character);
		player.transform.position = new Vector3(0,0,0);
		player.name = "Player";

		camera.target = player;
	}
}
