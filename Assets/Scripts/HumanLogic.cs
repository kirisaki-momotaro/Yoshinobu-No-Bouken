using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanLogic : MonoBehaviour
{
    public float horSpeed = 0.7f;
    public float vertSpeed = 0.7f;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // We want to be able to move the human horizontally and vertically

        // GetAxis() returns the value of the virtual axis identified by axisName.
        // The value will be in the range -1...1 for keyboard and joystick input devices.
        // The meaning of this value depends on the type of input control.
        // For example with a joystick's horizontal axis a value of 1 means the stick is pushed all the way to the right
        // and a value of -1 means it's all the way to the left; a value of 0 means the joystick is in its neutral position.

        // If the keyboard is the source of input (by default arrow keys are used), the value is -1, 0, or 1,
        // because you can't "half push" a keyboard button.

        //The -1:1 scale makes it convenient for multiplication with a fixed direction; in other words, "move right -1" is equivalent to "move left" while "move right +1" actually moves right.

        // This is frame-rate independent; you do not need to be concerned about varying frame-rates when using this value

        //"Horizontal" and "Vertical" below are defined in Edit -> Project Settings -> Input Manager
        
        float hor = Input.GetAxis("Horizontal"); // x - axis
        float vert = Input.GetAxis("Vertical");  // z - axis

        // Try this first:
        // transform.position = new Vector3(transform.position.x + hor, transform.position.y, transform.position.z + vert);
        // Problem: If right arrow is pressed (returns 1) the human goes 1m right by frame. We cannot control the speed of the movement.

        transform.position = new Vector3(transform.position.x + (hor * horSpeed * Time.deltaTime), transform.position.y, transform.position.z + (vert * vertSpeed * Time.deltaTime));

        //We multiply by Time.deltaTime to be sure that the speed is m/sec, not m/frame.
        //Try to remove Time.deltaTime above and see what happens.
        //Time.deltaTime is the time difference between two updates. This way we avoid problems caused by a slow PC etc.

        // Alternatively, to move the object we could use the Translate function.
        // Move object along the object's x-axis and z-axis
        // transform.Translate(hor * horSpeed * Time.deltaTime, 0, vert * vertSpeed * Time.deltaTime);

    }
}
