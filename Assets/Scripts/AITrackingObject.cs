using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AITrackingObject : MonoBehaviour {
    public GameObject target;
    public bool IsActive = true;
    private NavMeshAgent agent;
    // Use this for initialization
    void Start () {
        agent = GetComponent<NavMeshAgent>();
    }
	
	// Update is called once per frame
	void Update () {
        if (IsActive)
        {
            agent.SetDestination(target.transform.position);
        }
	}

}
