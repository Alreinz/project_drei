using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(BoxCollider2D))]
public class Tile : MonoBehaviour {
	
	private SpriteRenderer spriteRenderer;
	private BoxCollider2D boxCollider;
	public Sprite sprite { get { return spriteRenderer.sprite; } }
	public float size;
	public bool isPassable;

	// Use this for initialization
	public void Initialize ( Sprite tilesprite, bool isPassable) {
		spriteRenderer = GetComponent<SpriteRenderer>();
		boxCollider = GetComponent<BoxCollider2D>();
		spriteRenderer.sprite = tilesprite;
		size = spriteRenderer.size.x;
		
		if ( isPassable ) {
			boxCollider.enabled = false;
			this.isPassable = true;
		} else {
			boxCollider.enabled = true;
			boxCollider.size = new Vector2(size, size);
		}
	}
}
