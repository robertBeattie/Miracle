using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DupePipe : MonoBehaviour {

	public GameObject input;
	public Element output;

	// Dupe pipe takes 1 pipe in and pushes 2 identical elements to 2 different pipes
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
        } else if (input.GetComponent<EndPipe>() != null) {
            output = input.GetComponent<EndPipe>().GetElement();
        } /*else if (input.GetComponent<SplitPipe> != null) {
			output = input.GetComponent<SplitPipe>().GetTopElement();
		} This one has to make sure its passing in the correct direction*/
    }
	
	public Element GetElement() {
		return this.output;
	}
}

// Technically this can run exactly the same as the straight pipe, just 2 different
// pipes will need to use it as inputs