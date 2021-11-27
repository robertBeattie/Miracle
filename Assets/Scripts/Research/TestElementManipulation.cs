using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestElementManipulation : MonoBehaviour {

	public GameObject grid;
	private BuildGrid readScript;
	
	void Start () {
		readScript = grid.GetComponent<BuildGrid>();
	}

	void Update () {
		if (Input.GetButtonDown("XboxX")) {
			readScript.ReloadElements(true);
			
		}
	}
}
