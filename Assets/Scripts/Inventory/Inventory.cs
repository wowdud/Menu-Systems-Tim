using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CanvasUI;

public class Inventory : MonoBehaviour
{
    public static int money;
    public Transform dropLocation;
    public static bool isInvOpen;
    public GameObject inventoryScreen;
    public static List<Item> inventory = new List<Item>();
    [System.Serializable]
    public struct EquipSlots
    {
        public string slotName;
        public Transform equipLocation;
        public GameObject equipItem;
    }
    public EquipSlots[] equipSlots;

    void Start()
    {
        
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyBindManager.keys["Inventory"]) && !PauseMenu.isPaused)
        {
            isInvOpen = !isInvOpen;
            if (isInvOpen)
            {
                //show cursor
                Cursor.visible = true;
                //unlock it
                Cursor.lockState = CursorLockMode.None;
                //pause time
                Time.timeScale = 0;
                //open the actual inventory
                inventoryScreen.SetActive(true);
            }
            else
            {
                //cursor cannot be seen
                Cursor.visible = false;
                //cursor is locked
                Cursor.lockState = CursorLockMode.Locked;
                //time unpaused
                Time.timeScale = 1;
                //close the inventory
                inventoryScreen.SetActive(false);
            }
        }
    }
}
