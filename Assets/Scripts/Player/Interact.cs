using CanvasUI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//this script can be found in the Component section under Scrub Haus/Player Scripts/Player Interaction
[AddComponentMenu("Scrub Haus/Player Scripts/Player Interaction")]
public class Interact : MonoBehaviour
{
    #region Update   
    private void Update()
    {
        #region RayCasting Info
        //RAY - A ray is an infinite line starting at origin and going in some direction.
        //RAYCASTING - Casts a ray, from point origin, in direction direction, of length maxDistance, against all colliders in the Scene.
        //RAYCASTHIT - Structure used to get information back from a raycast
        #endregion
        //if our interact key is pressed
        //if (Input.GetKeyDown(MainMenu.keys["Interact"]))
        if (Input.GetKeyDown(KeyBindManager.keys["Interact"]))
        {
            //create ray
            Ray interact; //this is our line...Our Ray/Line doesnt have an origin, or a direction 
            //this ray is shooting out from the main cameras screen point center of screen
            //assigning origin
            interact = Camera.main.ScreenPointToRay(new Vector2(Screen.width/2, Screen.height/2));
            //create hit info
            RaycastHit hitInfo;
            //if this physics raycast hits something within 10 units
            if (Physics.Raycast(interact, out hitInfo,10))
            {
                #region Item
                if (hitInfo.collider.CompareTag("Item"))//and that hits info is tagged Item
                {
                    //Debug that we hit an Item  
                    Debug.Log("Our Interact ray hit an Item");
                    ItemHandler handler = hitInfo.transform.GetComponent<ItemHandler>();
                    if (handler != null)
                    {
                        //handler.OnCollection();
                    }
                }
                #endregion
                #region Chest
                if (hitInfo.collider.CompareTag("Chest"))//and that hits info is tagged Item
                {
                    //Debug that we hit an Item  
                    Debug.Log("Our Interact ray hit a Chest");
                    //LinearChest currentChest = hitInfo.transform.GetComponent<LinearChest>();
                    //if (currentChest != null)
                    {
                        //currentChest.isChestOpen = !currentChest.isChestOpen;
                    }
                }
                #endregion
            }
        }
    }
    #endregion
}
