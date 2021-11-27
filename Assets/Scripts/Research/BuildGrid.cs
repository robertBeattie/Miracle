using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using TMPro;

public class BuildGrid : MonoBehaviour {

	public GameObject ElementButton;
	public GameObject invObj;
	public GameObject EventSys;

	// Use this for initialization
	void Start () {
		ReloadElements(false);
		
	}

	public void ReloadElements(bool repeated) {
		if (repeated) {
			foreach (Transform child in transform) {
     		GameObject.Destroy(child.gameObject);
 			}
		}
		bool firstRun = true;

		invObj = GameObject.FindGameObjectsWithTag("ElementInventory")[0];
		ElementInventory readScript1 = invObj.GetComponent<ElementInventory>();

		foreach(Element element in readScript1.elements) {
			GameObject elementBtn = Instantiate(ElementButton) as GameObject;
 			elementBtn.transform.parent = this.transform;

			if (element.amount > 0) {
				ElementReader readScript2 = elementBtn.GetComponent<ElementReader>();
				readScript2.SetElement(element);

				GameObject amountCircle = elementBtn.transform.GetChild(0).gameObject;
				GameObject amountText = amountCircle.transform.GetChild(0).gameObject;
				TextMeshProUGUI textPro = amountText.GetComponent<TextMeshProUGUI>();
				textPro.text = "" + readScript2.element.amount;

				if (firstRun) {
					EventSys.GetComponent<EventSystem>().SetSelectedGameObject(elementBtn);
					firstRun = false;
				}
			} else {
				Destroy(elementBtn);
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
		/* Persistance Testing
		if (Input.GetKeyDown("space"))
			SceneManager.LoadScene("SampleScene");
		*/
	}
}
