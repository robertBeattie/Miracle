using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResearchManager : MonoBehaviour {

    public List<Research> research;
    public GameObject iceResearch;
    public GameObject darkResearch;
    public GameObject magicResearch;
    public GameObject nm;
    public Transform researchPosition;
    public bool researchCreated = false;
    public bool first1 = false;
    public bool first2 = false;
    public bool first3 = false;

    void Update()
    {
        if (!research[0].completed && !researchCreated)
        {
            nm = Instantiate(iceResearch, researchPosition);
            researchCreated = true;
            first1 = true;
        }
        else if (!research[1].completed && !researchCreated)
        {
            nm = Instantiate(darkResearch, researchPosition);
            researchCreated = true;
            first2 = true;
        }
        else if (!research[2].completed && !researchCreated)
        {
            nm = Instantiate(magicResearch, researchPosition);
            researchCreated = true;
            first3 = true;
        }

        if (research[0].completed && first1)
        {
            Destroy(nm, 0f);
            first1 = false;
            researchCreated = false;
        }
        if (research[1].completed && first2)
        {
            Destroy(nm, 0f);
            first2 = false;
            researchCreated = false;
        }
        if (research[2].completed && first3)
        {
            Destroy(nm, 0f);
            first3 = false;
            researchCreated = false;
        }
        if (research[0].completed && research[1].completed && research[2].completed)
        {
            RestartDemo();
        }
    }

    void RestartDemo()
    {
        research[0].completed = false;
        research[1].completed = false;
        research[2].completed = false;
    }
}
