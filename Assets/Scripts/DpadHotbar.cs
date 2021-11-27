using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DpadHotbar : MonoBehaviour {

    public Image dPadRIcon;
    public Image dPadLIcon;
    public Image dPadTIcon;
    public Image dPadBIcon;

    public Sprite emptyIcon;

    public GameItem[] dpadList = new GameItem[4];

    public InventoryManager inventory;

    //R=1, L=2, T=3, B=4
    public int buttonPressed = 0;
    
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        
        
        

    }

    public void QuickSlot(Image image)
    {
        int index = Int32.Parse(image.name.ToString());
        GameItem item = inventory.map[index];

        getInput();

        if (buttonPressed == 1)
        {
            if(item != null)
            {
                //dPadRIcon.sprite = item.icon;
               //Dpadlist = item;
            }
            else
            {
                //dPadRIcon.sprite = emptyIcon;
            }
        }
        if (buttonPressed == 2)
        {
            if (item != null)
            {
                //dPadLIcon.sprite = item.icon;
            }
            else
            {
                //dPadLIcon.sprite = emptyIcon;
            }
        }
        if (buttonPressed == 3)
        {
            if (item != null)
            {
                dPadTIcon.sprite = item.icon;
            }
            else
            {
                dPadTIcon.sprite = emptyIcon;
            }
        }
        if (buttonPressed == 4)
        {
            if (item != null)
            {
                dPadBIcon.sprite = item.icon;
            }
            else
            {
                dPadBIcon.sprite = emptyIcon;
            }
        }
        
        
    }
    void getInput()
    {
        //up down reset
        if (Input.GetAxis("DPadY") == 0)
        {
            buttonPressed = 0;
        }
        //left right reset
        if (Input.GetAxis("DPadX") == 0)
        {
            buttonPressed = 0;
        }

        //right
        if (Input.GetAxis("DPadX") == 1)
        {
            buttonPressed = 1;
        }
        //left
        if (Input.GetAxis("DPadX") == -1)
        {
            buttonPressed = 2;
        }
        //up
        if (Input.GetAxis("DPadY") == 1)
        {
            buttonPressed = 3;
        }
        //down
        if (Input.GetAxis("DPadY") == -1)
        {
            buttonPressed = 4;
        }
    }
}
