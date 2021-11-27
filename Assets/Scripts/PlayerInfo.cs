using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInfo : MonoBehaviour {

    public float maxHealth = 100f;
    public float currentHealth = 100f;

    public float maxWater = 100f;
    public float currentWater = 100f;

    public float maxEarth = 100f;
    public float currentEarth = 100f;

    public float maxFire = 100f;
    public float currentFire = 100f;

    public float maxAir = 100f;
    public float currentAir = 100f;

    public float maxOrder = 100f;
    public float currentOrder = 100f;


    public float maxEntropy = 100f;
    public float currentEntropy = 100f;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        currentHealth += 2f * Time.deltaTime;
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
        currentFire += 4f * Time.deltaTime;
        if (currentFire > maxFire)
        {
            currentFire = maxFire;
        }
        currentWater += 4f * Time.deltaTime;
        if (currentWater > maxWater)
        {
            currentWater = maxWater;
        }
    }
    public void damage(float x)
    {
        currentHealth -= x;
    }
}
