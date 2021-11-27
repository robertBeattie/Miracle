using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerResources : MonoBehaviour {
    public PlayerInfo player;

    public RectTransform healthHight;
    public float maxHealth;
    public float currentHealth;

    public RectTransform waterHight;
    public float maxWater;
    public float currentWater;

    public RectTransform earthHight;
    public float maxEarth;
    public float currentEarth;

    public RectTransform fireHight;
    public float maxFire;
    public float currentFire;

    public RectTransform airHight;
    public float maxAir;
    public float currentAir;

    public RectTransform orderHight;
    public float maxOrder;
    public float currentOrder;

    public RectTransform entropyHight;
    public float maxEntropy;
    public float currentEntropy;

    private void Start()
    {
    maxHealth = player.maxHealth;
    currentHealth = player.currentHealth;

    maxWater = player.maxWater;
    currentWater = player.currentWater;

    maxEarth = player.maxEarth;
    currentEarth = player.currentEarth;

    maxFire = player.maxFire;
    currentFire = player.currentFire;

    maxAir = player.maxAir;
    currentAir = player.currentAir;

    maxOrder = player.maxOrder;
    currentOrder = player.currentOrder;

    maxEntropy = player.maxEntropy;
    currentEntropy = player.currentEntropy;
}

    private void Update()
    {
        currentHealth = player.currentHealth;
        currentWater = player.currentWater;
        currentEarth = player.currentEarth;
        currentFire = player.currentFire;
        currentAir = player.currentAir;
        currentOrder = player.currentOrder;
        currentEntropy = player.currentEntropy;

        healthHight.sizeDelta = new Vector2(50, 50f * (currentHealth / maxHealth));
        waterHight.sizeDelta = new Vector2(10, 10f * (currentWater / maxWater));
        earthHight.sizeDelta = new Vector2(10, 10f * (currentEarth / maxEarth));
        fireHight.sizeDelta = new Vector2(10, 10f * (currentFire / maxFire));
        airHight.sizeDelta = new Vector2(10, 10f * (currentAir / maxAir));
        orderHight.sizeDelta = new Vector2(10, 10f * (currentOrder / maxOrder));
        entropyHight.sizeDelta = new Vector2(10, 10f * (currentEntropy / maxEntropy));

       
    }
}

