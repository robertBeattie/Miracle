using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ItemHolder))]
public class ItemPickUp : MonoBehaviour {
    // Use this for initialization
    private InventoryManager inventory;
    private ItemHolder itemHolder;
    private string playerTag = "Player";
    Scannable script;
    void Start()
    {
        inventory = FindObjectOfType<InventoryManager>();
        itemHolder = this.GetComponent<ItemHolder>();
        if (itemHolder == null)
            this.gameObject.AddComponent<ItemHolder>();
        script = this.GetComponent<Scannable>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(playerTag))
        {
            if (!script.Scanned)
            {
                for (int i = 0; i < script.elements.Count; i++)
                {
                    script.elements[i].amount += script.amounts[i];
                }
                script.Scanned = true;
            }

            for (int i = itemHolder.items.Length -1 ; i > -1; i--)
            {
                if (!inventory.isFull() && itemHolder.items[i] != null)
                {
                    inventory.addItem(itemHolder.items[i]);
                    itemHolder.items[i] = null;
                }
            }
            bool empty = true;
            if (itemHolder.items.Length != 0)
            {
                
                for (int j = 0; j < itemHolder.items.Length; j++)
                {
                    if (itemHolder.items[j] != null)
                    {
                        empty = false;
                    }
                }
                
            }
            if (empty)
            {
                Destroy(this.gameObject);
            }
        }
    }
}
