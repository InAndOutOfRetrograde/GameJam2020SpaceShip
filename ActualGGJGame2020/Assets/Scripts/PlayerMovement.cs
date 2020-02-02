/* Author: Kyle Smart (Discord: RxBaka#3988)
 * Date of last modification: 1/31/2020 10:06PM
 * Description: This code gets the input axis to detect the input from the user and move the player accordingly. Movement is achieved
 * by adding a force to the players rigidbody2D. By doing this, this gives the game a floaty movement feel, as if the player is in space. 
 */


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //CONSTANTS
    [SerializeField]
    const int SPEED = 150;

    //Vars
    Rigidbody2D rb2d;
    float XAxisInput;
    float YAxisInput;
    
    void Start()
    {
        //Getting the player's rigidbody2D
        rb2d = gameObject.GetComponent<Rigidbody2D>();
        rb2d.drag = 4;
    }

    void Update()
    {
        //Get the input axes 
        XAxisInput = Input.GetAxis("XAxisMovement");
        YAxisInput = Input.GetAxis("YAxisMovement");

        //Check if input is present and move accordingly.
        //XAxis
        if (XAxisInput != 0)
        {
            rb2d.AddForce(transform.right * SPEED * XAxisInput);
            
        }

        //YAxis
        if (YAxisInput != 0)
        {
            rb2d.AddForce(transform.up * SPEED * YAxisInput);
           
        }
    }
}
