/* Author: Kyle Smart
 * Description: This code listens to the start and ends buttons and once it gets the call from them,
 * it moves the walls in the way or out of they way based on which button made the call. The direction
 * is also based on which direction the wall needs to move.
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

    // Start is called before the first frame update
    void Start()
    {
        //Getting the button script to hear when the call is made that its been pressed
        startButtonCall = startingButton.GetComponent<Button>();
        endButtonCall = endingButton.GetComponent<Button>();
    }

    // Update is called once per frame
    void Update()
    {
        //Checks if the start button is pressed and moves the walls into place
        if (startButtonCall.StartButtonPressed)
        {
            if (hideDirection == HideDirection.moveUp)
            {
                gameObject.transform.position = new Vector3(gameObject.transform.position.x, 12, 1);
            } else if (hideDirection == HideDirection.moveDown)
            {
                gameObject.transform.position = new Vector3(gameObject.transform.position.x, -12, 1);
            }
        }

        //Checks if the end button is pressed and moves the walls out of the way
        if (endButtonCall.EndButtonPressed)
        {
            if (hideDirection == HideDirection.moveUp)
            {
                gameObject.transform.position = new Vector3(gameObject.transform.position.x, 29, -10);
            }
            else if (hideDirection == HideDirection.moveDown)
            {
                gameObject.transform.position = new Vector3(gameObject.transform.position.x, -29, -10);
            }
        }
    }
}
