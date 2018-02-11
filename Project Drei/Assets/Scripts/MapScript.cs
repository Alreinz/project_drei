using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapScript : MonoBehaviour {
	
	public GameObject tileBase;
	public int sizeX;
	public int sizeY;
	public float tileSize;

	public Sprite[] tileSprite;

	public void Start () {
		PrepareMap();
	} 

	public void PrepareMap() {
		for ( int i = 0; i < sizeX + 2; i++ ) {
			for ( int j = 0; j < sizeY + 2; j++ ) {
				GameObject tile = GameObject.Instantiate(tileBase);
				tile.transform.parent = transform;
				tile.transform.position = new Vector3( ( i * tileSize) - ((sizeX * tileSize) / 2), (j * tileSize) - ((sizeY * tileSize) / 2), 0);
				Tile tileScript = tile.GetComponent<Tile>();
				if ( i == 0 || j == 0 || i == sizeX + 1 || j == sizeY + 1) {
					tileScript.Initialize(tileSprite[Random.Range(0, tileSprite.Length - 1)], false);
				} else {
					tileScript.Initialize(tileSprite[Random.Range(0, tileSprite.Length - 1)], true);
				}
			}
		}
		Debug.Log("Map Loaded");
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
