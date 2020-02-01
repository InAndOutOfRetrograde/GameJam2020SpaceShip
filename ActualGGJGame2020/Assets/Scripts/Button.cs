/* Author: Kyle Smart
 * Description: This code checks if the player is touching the button after the button has been activated after 
 * a time has past. The time will be set by a constant number and added on by a random number. 
 * Date last modified: 2/1/2020
 */


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    //Constants
    const int TIMER_COOLDOWN = 5;
    const int RANDOM_TIMER_LOWER_VALUE = 1;
    const int RANDOM_TIMER_UPPER_VALUE = 10;

    //Serialized Fields
    [SerializeField]
    GameObject player;

    //Vars
    BoxCollider2D playerBC2D;
    BoxCollider2D buttonBC2D;
    Timer timer;
    int randomCooldownAdd;
    bool buttonPressed = false;
    

    // Start is called before the first frame update
    void Start()
    {
        //Setting and getting required components
        timer = gameObject.AddComponent<Timer>();
        playerBC2D = player.GetComponent<BoxCollider2D>();
        buttonBC2D = gameObject.GetComponent<BoxCollider2D>();

        //Finding the random time and setting the timer
        randomCooldownAdd = Random.Range(RANDOM_TIMER_LOWER_VALUE, RANDOM_TIMER_UPPER_VALUE);
        timer.Duration = TIMER_COOLDOWN + randomCooldownAdd;
        timer.Run();
    }

    // Update is called once per frame
    void Update()
    {
        //Tells the player the button can be hit
        if (timer.Finished)
        {
            //Debug.Log("IM FUCKING BROKEN");
        }

        //Checks if the player is hitting the button
        if (buttonBC2D.IsTouching(playerBC2D) && timer.Finished)
        {
            buttonPressed = true;
        }
    }

    //Getter 
    public bool ButtonPressed
    {
        get { return buttonPressed; }
    }
}
