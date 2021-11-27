using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OpenResearchTable : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetButton("XboxY"))
        {
            CheckForTable();
        }
	}

    void CheckForTable() {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, 3))
        {
            IsTable script = hit.collider.gameObject.GetComponent<IsTable>();
            if (script != null)
            {
                SceneManager.LoadScene("ResearchTesting", LoadSceneMode.Single);
            }
        }
    }
}
