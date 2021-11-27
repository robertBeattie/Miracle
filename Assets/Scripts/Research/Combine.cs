using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Combine : MonoBehaviour {

	public Sprite empty;

	public string c1, c2;
	public Image comp1, comp2;
	private GameObject[] elementButtons;
	public GameObject grid;
	private BuildGrid readGridScript;
	public GameObject invObj;
    public Element element1;
    public Element element2;

	void Start () {
		readGridScript = grid.GetComponent<BuildGrid>();
		c1 = "";
		c2 = "";
		comp1.GetComponent<Image>().sprite = empty;
		comp2.GetComponent<Image>().sprite = empty;
		
		invObj = GameObject.FindGameObjectsWithTag("ElementInventory")[0];
		elementButtons = GameObject.FindGameObjectsWithTag("ElementButton");
	}
	
	void Update () {
		// Add to combiner
		if (Input.GetButtonDown("Submit")) {
			GameObject btnObj = EventSystem.current.currentSelectedGameObject;
			Button btn = btnObj.GetComponent<Button>();
			ElementReader readScript = btnObj.GetComponent<ElementReader>();
			AddToCombiner(readScript.name, readScript.icon);
		}

		// Remove from combiner
		if (Input.GetButtonDown("Cancel")) {
			if (c2 != "") {
				c2 = "";
				comp2.GetComponent<Image>().sprite = empty;
			} else {
				c1 = "";
				comp1.GetComponent<Image>().sprite = empty;
			}
		}

		// Combine
		if (Input.GetButtonDown("XboxX")) {
			//element1 = null;
		    //element2 = null;

			// Make sure 2 elements are selected
			if (c1 != c2 && c1 != "" && c2 != "") {
				ElementInventory readInvScript = invObj.GetComponent<ElementInventory>();
				foreach(Element element in readInvScript.elements) {
					if (element.name.Equals(c1)) {
						element1 = element;
                        Debug.Log("Element 1: " + element);

                    }
					else if (element.name.Equals(c2)) {
						element2 = element;
                        Debug.Log("Element 2: " + element);
                    }
				}

                // Remove 1 of each element
                Debug.Log("element1 amount = " + element1.amount);
                element1.amount -= 1;
                Debug.Log("element1 amount = " + element1.amount);

                Debug.Log("element2 amount = " + element2.amount);
                element2.amount -= 1;
                Debug.Log("element2 amount = " + element2.amount);


                // Add 1 of new element, if the combo exists
                foreach (Element i in readInvScript.elements) {
                    if (!(i.element1.name.Equals(i.element2.name)))
                    {
                        if (i.element1.name.Equals(c1) && i.element2.name.Equals(c2))
                        {
                            i.amount += 1;
                            Debug.Log(i.name + " amount = " + i.amount);
                            break;
                        }
                        else if (i.element1.name.Equals(c2) && i.element2.name.Equals(c1))
                        {
                            i.amount += 1;
                            Debug.Log(i.name + " amount = " + i.amount);
                            break;
                        }
                    }
                }

				// Remove from combiner if element is empty
				if (element1.amount <= 0 || element2.amount <= 0) {
					c1 = "";
					comp1.GetComponent<Image>().sprite = empty;
					c2 = "";
					comp2.GetComponent<Image>().sprite = empty;
				}

				// Reload grid
				readGridScript.ReloadElements(true);
			}
		}
	}

	void AddToCombiner(string element, Sprite icon) {
		Debug.Log(element);
		if (c1.Equals("")) {
			c1 = element;
			comp1.GetComponent<Image>().sprite = icon;
		} else {
			c2 = element;
			comp2.GetComponent<Image>().sprite = icon;
		}
	}
}
