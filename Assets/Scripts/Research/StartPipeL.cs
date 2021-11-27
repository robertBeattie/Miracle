using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class StartPipeL : MonoBehaviour {

	public Element output;
	public GameObject EventSys;

	// Start pipe takes a button press to change element output
	void Update () {
		if (Input.GetButtonDown("LBumper")) {
			GameObject current = EventSystem.current.currentSelectedGameObject;
			output = current.GetComponent<ElementReader>().element;
		}

		this.GetComponent<Image>().sprite = output.icon;
	}
	
	public Element GetElement() {
		return this.output;
	}
}
