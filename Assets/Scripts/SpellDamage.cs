using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellDamage : MonoBehaviour {
    public float damage = 25;
    public GameObject explotion;
    private EnemyInfo target;
    //private EnemyInfo[] targets;

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.tag == "Enemy")
        {
            GameObject nm = Instantiate(explotion, this.gameObject.transform);
            Destroy(nm, 4f);
            target = other.GetComponent<EnemyInfo>();
            damageTarget();
            Destroy(this.gameObject,.1f);
        }
        
    }

    private void damageTarget()
    {
        target.damage(damage);
    }
}
