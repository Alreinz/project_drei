using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class UITextBase<E> : MonoBehaviour {

	public E target;
	private Text text;

	// Use this for initialization
	void Start () {
		text = GetComponent<Text>();
		Initialize();
	}

	public abstract void Initialize();

	public void UpdateText(string newValue) {
		text.text = newValue;
	}
}
