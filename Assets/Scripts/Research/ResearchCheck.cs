using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResearchCheck : MonoBehaviour {

    public GameObject input;

    public Element output;
    public Element desiredElement;

    public Research research;
    
	// Update is called once per frame
	void Update () {
        if (input.GetComponent<StraightPipe>() != null)
        {
            output = input.GetComponent<StraightPipe>().GetElement();
        }
        else if (input.GetComponent<DupePipe>() != null)
        {
            output = input.GetComponent<DupePipe>().GetElement();
        }
        else if (input.GetComponent<CombinePipe>() != null)
        {
            output = input.GetComponent<CombinePipe>().GetElement();
        }
        else if (input.GetComponent<StartPipeY>() != null)
        {
            output = input.GetComponent<StartPipeY>().GetElement();
        }
        else if (input.GetComponent<StartPipeL>() != null)
        {
            output = input.GetComponent<StartPipeL>().GetElement();
        }
        else if (input.GetComponent<StartPipeR>() != null)
        {
            output = input.GetComponent<StartPipeR>().GetElement();
        }
        else if (input.GetComponent<EndPipe>() != null)
        {
            output = input.GetComponent<EndPipe>().GetElement();
        }

        if (output == desiredElement) {
            research.completed = true;
        }
    }
}
