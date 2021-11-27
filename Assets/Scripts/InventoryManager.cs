using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour {
    public Inventory inventory;
    public GameItem[] map = new GameItem[30];
    private GameItem[] lastMap;
    public Image[] imageMap;
    public Image[] amountIcons;
    private int maxSize = 30;
    public int openSpot = 0;
    public Sprite redCircle;
    public Sprite blank;
    // Update is called once per frame
    private void Start()
    {
        sortInventory();
        //map = inventory.inventory;

       // amountIcons[0].GetComponentInChildren<TextMeshProUGUI>().text = "100";
    }
    void Update () {
        inventory.inventory = map;
       
        
        //maxSize = inventory.maxSize;
    }
    public bool isFull()
    {
        if(openSpot < maxSize)
        {
            return false;
        }
        else
        {
            return true;
        }
    }
    public void addItem(GameItem item)
    {
        
        map[openSpot] = item;
        imageMap[openSpot].sprite = item.icon;
        amountIcons[openSpot].sprite = redCircle;
        amountIcons[openSpot].GetComponentInChildren<TextMeshProUGUI>().text = "" + map[openSpot].amount;
        openSpot++;
        betterSort();
    }
    
    public void removeItem(GameItem item)
    {

    }
    public void removeItem(Image item)
    {
        int numVal = Int32.Parse(item.name.ToString());
       
        imageMap[numVal].sprite = blank;
        inventory.inventory[numVal] = null;
        amountIcons[numVal].sprite = blank;
        amountIcons[numVal].GetComponentInChildren<TextMeshProUGUI>().text = "";
        // sortInventory();
        betterSort();
    }

    private void betterSort()
    {
        GameItem temp;
        for (int i = 0; i < 30; i++)
        {
            if (map[i] != null)
            {
                temp = map[i];
                map[i] = null;
                imageMap[i].sprite = blank;
                amountIcons[i].sprite = blank;
                amountIcons[i].GetComponentInChildren<TextMeshProUGUI>().text = "";

                for (int j = 0; j < 30; j++)
                {
                    if (map[j] == null)
                    {
                        map[j] = temp;
                        imageMap[j].sprite = temp.icon;
                        amountIcons[j].sprite = redCircle;
                        amountIcons[j].GetComponentInChildren<TextMeshProUGUI>().text = "" + map[j].amount;
                        break;
                    }
                }

            }
        }
        for (int k = 0; k < 30; k++)
        {
            if (map[k] == null)
            {
                openSpot = k;
                break;
            }
        }
    }

    public void sortInventory()
    {
        openSpot = 0;
        for (int i = 0; i < 30; i++)
        {
            if (inventory.inventory[i] != null)
            {
                map[openSpot] = inventory.inventory[i];
                imageMap[openSpot].sprite = inventory.inventory[i].icon;
                amountIcons[openSpot].sprite = redCircle;
                amountIcons[openSpot].GetComponentInChildren<TextMeshProUGUI>().text = "" + map[openSpot].amount;
                openSpot++;
            }
        }

        
    }

}
