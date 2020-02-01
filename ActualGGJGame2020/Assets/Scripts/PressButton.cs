//Script to handle a button being pressed by a player via collisions
//Written by Brandon Collins


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressButton : MonoBehaviour
{

    //pressed will be true when the button is pressed
    //False when it has not been pressed
    bool pressed;

    // initilizes pressed
    void Start()
    {
        pressed = false;
    }
    //
    void onCollisionEnter2D(Collision2D col)
    {
        if (!pressed)
        {
            pressed = true;
            var renderer = this.GetComponent<Renderer>();
            renderer.material.SetColor("_Color", Color.green);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
