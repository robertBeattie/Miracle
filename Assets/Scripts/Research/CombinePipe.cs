using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombinePipe : MonoBehaviour {

	public GameObject input1;
	public GameObject input2;
	public Element output;
	public GameObject invObj;
	public Element def;

	void Start () {
		
	}

	// Combine pipe takes 2 input pipes and checks for an element combo and pushes that element through
	void Update () {
		if (input1.GetComponent<StraightPipe>() != null && input2.GetComponent<StraightPipe>() != null) {
			output = Combine(input1.GetComponent<StraightPipe>().GetElement(), input2.GetComponent<StraightPipe>().GetElement());
		} else if (input1.GetComponent<DupePipe>() != null && input2.GetComponent<DupePipe>() != null) {
			output = Combine(input1.GetComponent<DupePipe>().GetElement(), input2.GetComponent<DupePipe>().GetElement());
		} else if (input1.GetComponent<CombinePipe>() != null && input2.GetComponent<CombinePipe>() != null) {
			output = Combine(input1.GetComponent<CombinePipe>().GetElement(), input2.GetComponent<CombinePipe>().GetElement());
		} else if (input1.GetComponent<StraightPipe>() != null && input2.GetComponent<CombinePipe>() != null) {
			output = Combine(input1.GetComponent<StraightPipe>().GetElement(), input2.GetComponent<CombinePipe>().GetElement());
		} else if (input1.GetComponent<CombinePipe>() != null && input2.GetComponent<StraightPipe>() != null) {
			output = Combine(input1.GetComponent<CombinePipe>().GetElement(), input2.GetComponent<StraightPipe>().GetElement());
		} else if (input1.GetComponent<StraightPipe>() != null && input2.GetComponent<DupePipe>() != null) {
			output = Combine(input1.GetComponent<StraightPipe>().GetElement(), input2.GetComponent<DupePipe>().GetElement());
		} else if (input1.GetComponent<DupePipe>() != null && input2.GetComponent<StraightPipe>() != null) {
			output = Combine(input1.GetComponent<DupePipe>().GetElement(), input2.GetComponent<StraightPipe>().GetElement());
		}
        else if (input1.GetComponent<DupePipe>() != null && input2.GetComponent<StartPipeL>() != null)
        {
            output = Combine(input1.GetComponent<DupePipe>().GetElement(), input2.GetComponent<StartPipeL>().GetElement());
        }
        else if (input1.GetComponent<StartPipeL>() != null && input2.GetComponent<DupePipe>() != null)
        {
            output = Combine(input1.GetComponent<StartPipeL>().GetElement(), input2.GetComponent<DupePipe>().GetElement());
        }
    }
	
	public Element GetElement() {
		return this.output;
	}

	Element Combine(Element in1, Element in2) {
		invObj = GameObject.FindGameObjectsWithTag("ElementInventory")[0];
		ElementInventory readInvScript = invObj.GetComponent<ElementInventory>();
		foreach(Element e in readInvScript.elements) {
			if ((e.element1 == in1 && e.element2 == in2) || (e.element1 == in2 && e.element2 == in1)) {
				return e;
			}
		}
		return def;
	}
}
