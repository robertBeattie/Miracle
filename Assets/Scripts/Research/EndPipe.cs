using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class EndPipe : MonoBehaviour {

	public GameObject input;
	public Element output;


	// End pipe shows the final element and is compared to the asked element
	void Update () {
		if (input.GetComponent<StraightPipe>() != null) {
			output = input.GetComponent<StraightPipe>().GetElement();
		} else if (input.GetComponent<DupePipe>() != null) {
			output = input.GetComponent<DupePipe>().GetElement();
		} else if (input.GetComponent<CombinePipe>() != null) {
			output = input.GetComponent<CombinePipe>().GetElement();
		} else if (input.GetComponent<StartPipeY>() != null) {
            output = input.GetComponent<StartPipeY>().GetElement();
        } else if (input.GetComponent<StartPipeL>() != null) {
            output = input.GetComponent<StartPipeL>().GetElement();
        } else if (input.GetComponent<StartPipeR>() != null) {
            output = input.GetComponent<StartPipeR>().GetElement();
        }/*else if (input.GetComponent<SplitPipe> != null) {
			output = input.GetComponent<SplitPipe>().GetTopElement();
		} This one has to make sure its passing in the correct direction*/

        this.GetComponent<Image>().sprite = output.icon;
	}
	
	public Element GetElement() {
		return this.output;
	}
}
