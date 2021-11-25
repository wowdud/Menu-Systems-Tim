using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//this script can be found in the Component section under the option Scrub Haus/Player Scripts/ Mouse Look
[AddComponentMenu("Scrub Haus/Player Scripts/Mouse Look")]
public class MouseLook : MonoBehaviour
{
    //What are Enums???
    /*enums are what we call state value variables 
      they are comma separated lists of identifiers
      we can use them to create Types or Categorys*/
    #region RotationalAxis
    //Create a public enum called RotationalAxis
    public enum RotationalAxis
    {
        //MouseX, MouseY
        MouseX,
        MouseY
    }
    #endregion
    #region Variables
    [Header("Rotation")]
    //create a public link to the rotational axis called axis and set a defualt axis
    public RotationalAxis axis = RotationalAxis.MouseX;
    [Header("Sensitivity")]
    //public floats for our x and y sensitivity
    public static Vector2 sensitivity = new Vector2(300,300);//STATIC SO WE CAN PUT IT ON MENU!!! YEE
   // [Range(0, 100)]
    [Header("Y Rotation Clamp")]
    //max and min Y rotation
    public Vector2 rotationRangeY = new Vector2(-60, 60);
    //we will have to invert our mouse position later to calculate our mouse look correctly
    //float for rotation Y
    float _rotY;
    #endregion
    #region Start
    private void Start()
    {
        //Lock Cursor to middle of screen
        Cursor.lockState = CursorLockMode.Locked;
        //Hide Cursor from view
        Cursor.visible = false;
        //if our game object has a rigidbody attached to it
        if (GetComponent<Rigidbody>())
        {
            //set the rigidbodys freezeRotation to true
            GetComponent<Rigidbody>().freezeRotation = true;
        }
        //if our game object has a Camera attached to it
        if (GetComponent<Camera>())
        {
            //Set our rotation for a different axis
            axis = RotationalAxis.MouseY;
        }
    }
    #endregion
    #region Update
    private void Update()
    {
        #region Mouse X
        //if we are rotating on the X
        if (axis == RotationalAxis.MouseX)
        {
            //transform the rotation on our game objects Y by our Mouse input Mouse X times X sensitivity
            //x                y                          z
            transform.Rotate(0,Input.GetAxis("Mouse X")*sensitivity.x*Time.deltaTime,0);
        }
        #endregion
        #region Mouse Y
        else //else we are only rotating on the Y
        {
            //our rotation Y is plus equals  our mouse input for Mouse Y times Y sensitivity
            _rotY += Input.GetAxis("Mouse Y") * sensitivity.y*Time.deltaTime;
            //the rotation Y is clamped using Mathf and we are clamping the y rotation to the Y min and Y max
            _rotY = Mathf.Clamp(_rotY, rotationRangeY.x, rotationRangeY.y);
            //transform our local euler angle to the next vector3 rotation -rotY on the x axis 
            transform.localEulerAngles = new Vector3(-_rotY,0,0);
        }
        #endregion
    }
    #endregion
}
