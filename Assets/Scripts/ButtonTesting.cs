using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonTesting : MonoBehaviour {
    public Canvas myCanvas;
    public FPSPlayerControler player;
    public Image dPadR;
    public Image dPadL;
    public Image dPadT;
    public Image dPadB;
    public GameObject menu;
    private bool menuIsActive = false;
    public InventoryManager inventoryManager;

    public Material deActive;
    public Material active;

    public Image Book;
    public EventSystem eventSystem;

    public Sprite[] books;
    private int count = 1;

    public Transform wandRotate;

    public GameObject fireball;
    public GameObject iceball;
    public GameObject explotion;
    public Transform playerPostion;

    private string lastTrigger = "none";
    private string currentTrigger = "none";

    public GameObject scanner;
    public GameObject wand;

    public PlayerInfo playerInfo;

    // Use this for initialization
    void Start () {
		
	}

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("working?");
        /*
         if (Input.GetKeyDown("joystick button 0"))
        {

        }
        */
        if (Input.GetKeyDown("joystick button 1"))
        {
            // eventSystem.GetComponent<EventSystem>().firstSelectedGameObject
        }

        if (Input.GetKeyDown("joystick button 2"))
        {
            Debug.Log("X pressed?");
            Book.sprite = books[count];
            count++;
            if (count > 9)
            {
                count = 0;
            }
            if (menuIsActive)
            {
                menu.SetActive(false);
                menuIsActive = false;
                player.isActive = true;
            }
            else
            {
                //inventoryManager.sortInventory();
                menu.SetActive(true);
                menuIsActive = true;
                player.isActive = false;
            }
        }
        /*
        if (Input.GetKeyDown("joystick button 3"))
        {

        }
        */

        //right
        if (Input.GetAxis("DPadX") == 1)
        {
            dPadR.material = active;
            //wand
            scanner.SetActive(false);
            wand.SetActive(true);
        }
        //left
        if (Input.GetAxis("DPadX") == -1)
        {
            dPadL.material = active;
            //scanner
            wand.SetActive(false);
            scanner.SetActive(true);
            
        }
        //left right reset
        if (Input.GetAxis("DPadX") == 0)
        {
            dPadR.material = null;
            dPadL.material = null;
        }
        //up
        if (Input.GetAxis("DPadY") == 1)
        {
            dPadT.material = active;
        }
        //down
        if (Input.GetAxis("DPadY") == -1)
        {
            dPadB.material = active;
        }
        //up down reset
        if (Input.GetAxis("DPadY") == 0)
        {
            dPadT.material = null;
            dPadB.material = null;
        }

        if (Input.GetKeyUp("joystick button 12"))
        {
            dPadB.material = deActive;
        }

        // Triggers 
        lastTrigger = currentTrigger;
        if (Input.GetAxis("RTrigger") == 1 && Input.GetAxis("LTrigger") == 1)
        {
            Debug.Log("both trigger");
            currentTrigger = "both";
        }
        else
        {
            if (Input.GetAxis("RTrigger") == 1)
            {
                Debug.Log("right trigger");
                currentTrigger = "right";
            }
            if (Input.GetAxis("LTrigger") == 1)
            {
                Debug.Log("left trigger");
                currentTrigger = "left";
            }
        }      
        if (Input.GetAxis("RTrigger") == 0 && Input.GetAxis("LTrigger") == 0)
        {
            currentTrigger = "none";
        }
        if ((lastTrigger != currentTrigger && currentTrigger == "right") && wand.active && playerInfo.currentFire > 24|| Input.GetKeyDown("1"))
        {
            playerInfo.currentFire -= 25;
            rotateWand();
            GameObject nm = Instantiate(fireball, playerPostion.position, playerPostion.rotation);
            nm.GetComponent<Rigidbody>().velocity = Camera.main.transform.forward * player.speed;
            Transform death = nm.transform;
            Destroy(nm, 4f);
        }
        if ((lastTrigger != currentTrigger && currentTrigger == "left") && wand.active && playerInfo.currentWater > 24 || Input.GetKeyDown("2"))
        {
            playerInfo.currentWater -= 10;
            rotateWand();
            GameObject nm = Instantiate(iceball, playerPostion.position, playerPostion.rotation);
            nm.GetComponent<Rigidbody>().velocity = Camera.main.transform.forward * player.speed;
            Transform death = nm.transform;
            Destroy(nm, 4f);
        }
        //sprint
        if (Input.GetKeyDown("joystick button 8") || Input.GetButtonDown("Shift"))
        {
            player.speed *= 2;
            player.rotationSpeed /= 3;
        }
        if (Input.GetKeyUp("joystick button 8") || Input.GetButtonUp("Shift"))
        {
            player.speed /= 2;
            player.rotationSpeed *= 3;
        }
    }

    public void rotateWand()
    {
        for (int i = 0; i < 30; i++)
        {
            wandRotate.Rotate(new Vector3(1, 0, 0));
        }
        for (int i = 0; i < 30; i++)
        {
            wandRotate.Rotate(new Vector3(-1, 0, 0));
        }
    }
}
