using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour {


    private float coolDown = 0f;
    public PlayerInfo player;

	
	void Start () {
         player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInfo>();
    }

    public void attack()
    {
        if(coolDown <= 0)
        {
            player.damage(25);
            coolDown = 2f;
        } else
        {
            coolDown -= Time.deltaTime;
        }
    }
}
