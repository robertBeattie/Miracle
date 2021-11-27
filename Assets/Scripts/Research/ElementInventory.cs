using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElementInventory : MonoBehaviour {

	private static bool created = false;
	public List<Element> elements;

    void Awake() {
        if (!created)
        {
            DontDestroyOnLoad(this.gameObject);
            created = true;
            Debug.Log("Awake: " + this.gameObject);
        }
    }
}
