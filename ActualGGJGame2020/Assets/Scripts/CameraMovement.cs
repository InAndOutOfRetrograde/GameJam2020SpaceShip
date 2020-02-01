/* Author: Kyle Smart (Discord: RxBaka#3988)
 * Date of last modification: 1/31/2020 10:06PM
 * Description: This checks the difference between the position of the player and the camera and then at the
 * end of the frame moves the camera with the player. 
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
