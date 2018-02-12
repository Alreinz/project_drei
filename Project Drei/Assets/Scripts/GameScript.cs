using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScript : MonoBehaviour {

	private static GameScript instance = new GameScript();
	private GameScript() { }
	public static GameScript Instance { get { return instance; } }

	public static int characterSelected;

	// Use this for initialization
	void Start () {
		DontDestroyOnLoad(this.gameObject);
	}
}
