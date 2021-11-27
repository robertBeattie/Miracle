using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ElementReader : MonoBehaviour {

	public Element element;
	public string name;
	public Sprite icon;

	void Start () {
		icon = element.icon;
		this.GetComponent<Image>().sprite = icon;

		this.name = element.name;
	}

	public void SetElement(Element el) {
		element = el;
		Start();
	}
}
