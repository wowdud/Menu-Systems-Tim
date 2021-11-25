using CanvasUI;
using System.Collections;
using UnityEngine;

//this script can be found in the Component section under the option Scrub Haus/Player Scripts/ First Person Movement
[AddComponentMenu("Scrub Haus/Player Scripts/First Person Movement")]

//This script requires the component Character controller to be attached to the Game Object
[RequireComponent(typeof(CharacterController))]

public class Movement : MonoBehaviour
{
    #region Extra Study
    //Input Manager(https://docs.unity3d.com/Manual/class-InputManager.html)
    //Input(https://docs.unity3d.com/ScriptReference/Input.html)
    //CharacterController allows you to move the character kinda like Rigidbody (https://docs.unity3d.com/ScriptReference/CharacterController.html
    #endregion
    #region Variables
    [Header("Character")]
    //Vector3 called moveDir, we will use this to apply movement in worldspace
    public Vector3 moveDir = Vector3.zero;
    //Character controller called _charC  
    [SerializeField]
    private CharacterController _charC;
    [Header("Character Speeds")]
    /*public float variables speed,walk = 5, run = 10, crouch = 2.5, jumpSpeed = 8, gravity = 20 */
    public float speed;
    public float crouch = 2.5f, walk = 5, run = 10, jumpSpeed = 8, gravity = 20;
    public Vector2 input;

    #endregion
    #region Start  
    private void Start()
    {
        //_charc is set to the Character controller on this GameObject
        _charC = GetComponent<CharacterController>();
    }
    #endregion

    #region Update

    private void Update()
    {
        //MainMenu.keys 
        input.y = 0;
        Input.GetKey(KeyBindManager.keys["Forward"]);
        Input.GetKey(KeyBindManager.keys["Back"]);

        input.x = 0;
        Input.GetKey(KeyBindManager.keys["Left"]);
        Input.GetKey(KeyBindManager.keys["Right"]);

        speed = walk;
        Input.GetKey(KeyBindManager.keys["Sprint"]);
        Input.GetKey(KeyBindManager.keys["Crouch"]);


        input.y = Input.GetKey(KeyBindManager.keys["Forward"]) ? 1 : input.y = Input.GetKey(KeyBindManager.keys["Back"]) ? -1 : 0;
        input.x = Input.GetKey(KeyBindManager.keys["Right"]) ? 1 : input.x = Input.GetKey(KeyBindManager.keys["Left"]) ? -1 : 0;
        speed = Input.GetKey(KeyBindManager.keys["Sprint"]) ? run : speed = Input.GetKey(KeyBindManager.keys["Crouch"]) ? crouch : walk;

        //if our character is grounded
        if (_charC.isGrounded)
        {

            //set moveDir to the inputs direction
            moveDir = new Vector3(input.x, 0, input.y);
            //moveDir's forward is changed from global z (forward) to the Game Objects local Z (forward) - allows us to move where player is facing
            moveDir = transform.TransformDirection(moveDir);
            //moveDir is multiplied by speed so we move at a decent pace
            moveDir *= speed;
            //if the input button for jump is pressed then    
            if (Input.GetKey(KeyBindManager.keys["Jump"]))
            {
                //our moveDir.y is equal to our jump speed
                moveDir.y = jumpSpeed;
            }
        }
        //regardless of if we are grounded or not the players moveDir.y is always affected by gravity timesed my time.deltaTime to normalize it
        moveDir.y -= gravity * Time.deltaTime;
        //we then tell the character Controller that it is moving in a direction multiplied Time.deltaTime
        _charC.Move(moveDir * Time.deltaTime);
    }

    #endregion

}

