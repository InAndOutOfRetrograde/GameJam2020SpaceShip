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
    Button buttonCall;

    // Start is called before the first frame update
    void Start()
    {
        //Getting the button script to hear when the call is made that its been pressed
        buttonCall = startingButton.GetComponent<Button>();
    }

    // Update is called once per frame
    void Update()
    {
        //Checks if the button is pressed and moves the walls into place
        if (buttonCall.ButtonPressed)
        {
            //Debug.Log("MOVE THE WALL");
        }
    }
}
