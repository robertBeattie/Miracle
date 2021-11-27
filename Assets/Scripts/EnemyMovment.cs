using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovment : MonoBehaviour {

    private Transform player;
    private Transform home;
    public Transform[] path;
    public int pathIndex = 0; 

    NavMeshAgent nav;
    public float agrroRange = 13;
    public float deAgrroRange = 17;
    public float attackRange = 2;

    private EnemyDamage damage;
    private float calmTime = 10f;
    private bool angry = false;

    private float distance;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        nav = GetComponent<UnityEngine.AI.NavMeshAgent>();
        damage = GetComponent<EnemyDamage>();
        home = path[0];
    }

    void Update()
    {
        if (path.Length != 0) { pathing(); }
        agrroCheck();
    }
    private void agrroCheck()
    {
        float distance = Vector3.Distance(player.position, transform.position);
        if (angry)  calming(); 

        //to far away deaggro
        if (distance > deAgrroRange) {
            nav.enabled = true;
            nav.SetDestination(home.position);
            angry = false;
        }
        //chase em down boi
        else if (distance <= agrroRange && distance > attackRange) {
            nav.enabled = true;
            nav.SetDestination(player.position);
        }
        //stop and attack
        else if (distance <= attackRange) {
            nav.enabled = false;       
            damage.attack();
        }   
    }

    public void angered()
    { 
        agrroRange *= 1.4f;
        deAgrroRange *= 1.3f;
        calmTime = 7f;
        angry = true;
    }

    private void calming()
    {
        if (calmTime <= 0)
        {
            angry = false;  
        }
        else
        {
            calmTime -= Time.deltaTime;
        }
    }

    private void pathing()
    {
        distance = Vector3.Distance(path[pathIndex].position, transform.position);
        if (distance <= 2f)
        {
            pathIndex++;
        }
        if (path != null)
        {
            if (pathIndex > path.Length - 1)
            {
                pathIndex = 0;
            }
            home = path[pathIndex];
        }

            
    }
}
