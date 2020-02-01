/* Author: Kyle Smart (Discord: RxBaka#3988)
 * Date of last modification: 1/31/2020 10:06PM
 * Description: This code gets the input axis to detect the input from the user and move the player accordingly. Movement is achieved
 * by adding a force to the players rigidbody2D. By doing this, this gives the game a floaty movement feel, as if the player is in space. 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    //Vars 
    [SerializeField]
    GameObject player;
    Vector3 offset;

    void Start()
    {
        //This gets the difference in position between the camera and the player.
        offset = transform.position - player.transform.position;
    }

    void LateUpdate()
    {
        //This updates the camera's position based off the players new position.
        transform.position = player.transform.position + offset;
    }
}
