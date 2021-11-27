using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scan : MonoBehaviour {

    public GameObject effect;
    public Transform playerPostion;

    // Update is called once per frame
    void Update () {
		if(Input.GetButton("RBumper"))
        {
            Scanner();
        }
	}

    void Scanner() {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, 3))
        {
            Scannable script = hit.collider.gameObject.GetComponent<Scannable>();
            if (script != null)
            {
                if (!script.Scanned)
                {
                    for (int i = 0; i < script.elements.Count; i++) {
                        script.elements[i].amount += script.amounts[i];
                    }

                    GameObject nm = Instantiate(effect, playerPostion.position, playerPostion.rotation);
                    Destroy(nm, 2f);

                    script.Scanned = true;
                }
            }
        }
    }
}
