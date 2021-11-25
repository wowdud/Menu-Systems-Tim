using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemHandler : MonoBehaviour
{
    public int itemID = 0;
    public ItemType itemType;
    public int amount = 1;
    /*
    public void OnCollection()
    {
        if (itemType == ItemType.Money)//is the item money?
        {
            Inventory.money += amount;
        }
        else if (itemType == ItemType.Trinket || itemType == ItemType.Misc || itemType == ItemType.Ingredient || itemType == ItemType.Food || itemType == ItemType.Scroll || itemType == ItemType.Material || itemType == ItemType.Potion)//is it stackable?
        {
            //do i have the item?
            int found = 0;
            //what is the index of the item?
            int addIndex = 0;
            //search our inventory
            for (int i = 0; i < Inventory.inventory.Count; i++)
            {
                if (itemID == Inventory.inventory[i].ID)
                {
                    found = 1;
                    addIndex = i;
                    break;
                }
            }
            //if i have the item, then increment the current item's Amount by the amount
            if (found == 1)
            {
                LinearInventory.inventory[addIndex].Amount += amount;
            }
            //if we don't have it, add the item and then set the Amount to equal the amount added
            else
            {
                LinearInventory.inventory.Add(ItemData.CreateItem(itemID));
                LinearInventory.inventory[LinearInventory.inventory.Count - 1].Amount = amount;
            }
        }
        else //if neither just add
        {
            LinearInventory.inventory.Add(ItemData.CreateItem(itemID));
        }
        Destroy(gameObject); //once picked up, destroy in world
    }
    */
}
