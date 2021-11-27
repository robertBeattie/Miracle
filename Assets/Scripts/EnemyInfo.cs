using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyInfo : MonoBehaviour
{

	
    // Stats block 
    [SerializeField]
    private float hp = 10;
    [SerializeField]
    public float mp = 10;

    [SerializeField]
    public float att = 10;
    [SerializeField]
    public float def = 10;

    [SerializeField]
    public float agi = 10;
    [SerializeField]
    public float luc = 10;

    //Stats bases of the block get defined on start
    public float health;
    public float MaxHp;
    public float hpRegen;

    public float mana;
    public float MaxMana;
    public float manaRegen;

    public float speed;
    public bool movement = true;

    private EnemyMovment enemyMovment;
    // Use this for initialization
    void Start()
    {
        health = hp * 20f;
        MaxHp = health;
        hpRegen = hp * 0.25f;

        mana = mp * 20f;
        MaxMana = mana;
        manaRegen = mp * 0.25f;

        speed = agi * 0.6f;
        enemyMovment = gameObject.GetComponent<EnemyMovment>();
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
    public float getHealth() { return health; }
    public float getSpeed() { return speed; }
    public void setHealth(float h) { health = h; }
    public void setSpeed(float s) { speed = s; }
    public void damage(float x) { health -= x; enemyMovment.angered(); }
}
