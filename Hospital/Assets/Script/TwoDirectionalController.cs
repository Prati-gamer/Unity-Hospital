using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TwoDirectionalController : MonoBehaviour
{
    Animator animator;
    float velocityZ = 0.0f;
    float velocityX = 0.0f;
    public float acceleration = 2.0f;
    public float deceleration = 2.0f;

    // Start is called before the first frame update
    void Start()
    {
        //search the gameobject this script is attached to and get the animator component
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //input will be true if the player is pressing on the passed in key parameter
        //get key input from player
        bool forwardPresses = Input.GetKey("w");
        bool leftPressed = Input.GetKey("a");
        bool rightPressed = Input.GetKey("d");


        //if player presses forward, increase velocity in z direction
        if (forwardPresses && velocityZ < 0.5f)
        {
            velocityZ += Time.deltaTime * acceleration;
        }

        //increase velocity in left direction
        if (leftPressed && velocityX > -0.5f)
        {
            velocityX -= Time.deltaTime * acceleration;
        }

        //increase velocity in right direction
        if (rightPressed && velocityX < 0.5f)
        {
            velocityX += Time.deltaTime * acceleration;
        }


        //decrease velocityZ
        if (!forwardPresses && velocityZ > 0.0f)
        {
            velocityZ -= Time.deltaTime * deceleration;
        }

        //reset velocityZ
        if(!forwardPresses && velocityZ < 0.0f)
        {
            velocityZ = 0.0f;
        }

        //decrease velocityX if left is not pressed and velocityX < 0
        if(!leftPressed && velocityX < 0.0f)
        {
            velocityX += Time.deltaTime * deceleration;
        }

        //decrease velocityX if right is not pressed and velocityX > 0
        if (!rightPressed && velocityX > 0.0f)
        {
            velocityX -= Time.deltaTime * deceleration;
        }


        //reset velocityX
        if (!leftPressed && !rightPressed && velocityX != 0.0f && (velocityX > -0.05f && velocityX < 0.05f))
        {
            velocityX = 0.0f;
        }

        //set the parameters to our local variable values
        animator.SetFloat("Velocity z", velocityZ);
        animator.SetFloat("Velocity x", velocityX);
    }
}
