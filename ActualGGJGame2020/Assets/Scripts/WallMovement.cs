/* Author: Kyle Smart
 * Description: This code listens to the start and ends buttons and once it gets the call from them,
 * it moves the walls in the way or out of they way based on which button made the call. The direction enum
 * tells the code which direction the wall needs to move. Finally, the orientation of the blocks is 
 * dependent on what random number is picked. This orientation is saved so when the call is made to move
 * the walls out of the way it can be reset to its prior position.
 * Date: 2/1/2020  
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallMovement : MonoBehaviour
{
    //Enum
    enum HideDirection{ moveUp, moveDown };

    //Serialized Fields
    [SerializeField]
    GameObject startingButton;
    [SerializeField]
    GameObject endingButton;
    [SerializeField]
    HideDirection hideDirection;

    //Vars
    Button startButtonCall;
    Button endButtonCall;
    int positionPreset;
    int previousRotation;
    bool wallsMovedInTheWay;

    // Start is called before the first frame update
    void Start()
    {
        //Getting the button script to hear when the call is made that its been pressed
        startButtonCall = startingButton.GetComponent<Button>();
        endButtonCall = endingButton.GetComponent<Button>();
        wallsMovedInTheWay = false;
    }

    // Update is called once per frame
    void Update()
    {
        //Checks if the start button is pressed and if the walls are not in the way then moves the walls into place
        if (startButtonCall.GetStartButtonPressed && !wallsMovedInTheWay)
        {
            //Finds a random position preset to use
            positionPreset = movementPreset();

            //Checks which preset was picked, puts the wall in that position and saves the rotation it made.
            switch (positionPreset)
            {
                //Preset 1
                case 1:
                    if (hideDirection == HideDirection.moveUp)
                    {
                        gameObject.transform.position = new Vector3(gameObject.transform.position.x, 25, 1);
                        previousRotation = 0;
                    }
                    else if (hideDirection == HideDirection.moveDown)
                    {
                        gameObject.transform.position = new Vector3(gameObject.transform.position.x, -12, 1);
                        previousRotation = 0;
                    }
                    break;
                //Preset 2
                case 2:
                    if (hideDirection == HideDirection.moveUp)
                    {
                        gameObject.transform.position = new Vector3(gameObject.transform.position.x, 25, 1);
                        gameObject.transform.Rotate(0, 0, -36);
                        previousRotation = -36;
                    }
                    else if (hideDirection == HideDirection.moveDown)
                    {
                        gameObject.transform.position = new Vector3(gameObject.transform.position.x, -12, 1);
                        gameObject.transform.Rotate(0, 0, 50);
                        previousRotation = 50;
                    }
                    break;
                //Preset 3
                case 3:
                    if (hideDirection == HideDirection.moveUp)
                    {
                        gameObject.transform.position = new Vector3(gameObject.transform.position.x, 21, 1);
                        gameObject.transform.Rotate(0, 0, 90);
                        previousRotation = 90;
                    }
                    else if (hideDirection == HideDirection.moveDown)
                    {
                        gameObject.transform.position = new Vector3(gameObject.transform.position.x, -8, 1);
                        gameObject.transform.Rotate(0, 0, 90);
                        previousRotation = 90;
                    }
                    break;
                //Error
                default:
                    Debug.Log("Something has gone wrong!");
                    break;
            }

            //Walls are now in the way and start button is reset
            startButtonCall.SetStartButtonPressed = false;
            wallsMovedInTheWay = true;
        }

        //Checks if the end button is pressed and resets the walls to out of the way and 0 rotation.
        if (endButtonCall.GetEndButtonPressed && wallsMovedInTheWay)
        {
            if (hideDirection == HideDirection.moveUp)
            {
                gameObject.transform.position = new Vector3(gameObject.transform.position.x, 50, -10);
                gameObject.transform.Rotate(0, 0, -previousRotation);
            }
            else if (hideDirection == HideDirection.moveDown)
            {
                gameObject.transform.position = new Vector3(gameObject.transform.position.x, -29, -10);
                gameObject.transform.Rotate(0, 0, -previousRotation);
            }

            //Walls are not in the way and end button is reset.
            endButtonCall.SetEndButtonPressed = false;
            wallsMovedInTheWay = false;
        }
    }

    int movementPreset()
    {
        return Random.Range(1,4);
    }
}
