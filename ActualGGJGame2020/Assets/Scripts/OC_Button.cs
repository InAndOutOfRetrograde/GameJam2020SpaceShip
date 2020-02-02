/* Author: Kyle Smart
 * Description: This code checks if the player is touching the button after a timer has finished. 
 * The timer will be set by a constant number and added on by a random number. Once a button is pressed
 * it will set its boolean to true and the other buttons boolean to false.
 * Date last modified: 2/1/2020
 */


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OC_Button : MonoBehaviour
{
    enum ButtonName { startButton, endButton };
    //Constants
    const int TIMER_COOLDOWN = 15;
    const int RANDOM_TIMER_LOWER_VALUE = 1;
    const int RANDOM_TIMER_UPPER_VALUE = 10;

    //Serialized Fields
    [SerializeField]
    GameObject player;
    [SerializeField]
    ButtonName buttonname;

    //Vars
    BoxCollider2D playerBC2D;
    BoxCollider2D buttonBC2D;
    static Timer timer;
    int randomCooldownAdd;
    static bool startButtonPressed = false;
    static bool endButtonPressed = false;
    static bool messageSent = false;
    static bool brokenCall = false;
    

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
        if (timer.Finished && !messageSent)
        {
            brokenCall = true;
            messageSent = true;
        }

        //Checks if the player is hitting the start button
        if (buttonBC2D.IsTouching(playerBC2D) && timer.Finished && buttonname == ButtonName.startButton)
        {
            startButtonPressed = true;
            endButtonPressed = false;
        }

        //Checks if the player is touching the end button
        if (buttonBC2D.IsTouching(playerBC2D) && buttonname == ButtonName.endButton)
        {
            brokenCall = false;

            //End button is now pressed and start button is reset
            endButtonPressed = true;
            startButtonPressed = false;

            //Restarts the timer with a random time
            randomCooldownAdd = Random.Range(RANDOM_TIMER_LOWER_VALUE, RANDOM_TIMER_UPPER_VALUE);
            timer.Stop();
            timer.Duration = TIMER_COOLDOWN + randomCooldownAdd;
            timer.Run();

            //Resets message sent to player about this being broken
            messageSent = false;
        }
    }

    //Getters
    public bool GetStartButtonPressed
    {
        get { return startButtonPressed; }
    }

    public bool GetEndButtonPressed
    {
        get { return endButtonPressed; }
    }

    public bool GetBrokenCall
    {
        get { return brokenCall; }
    }

    //Setters
    public bool SetStartButtonPressed
    {
        set
        {
            startButtonPressed = value;
        }
    }

    public bool SetEndButtonPressed
    {
        set
        {
            endButtonPressed = value;
        }
    }

    public bool SetBrokenCall
    {
        set { brokenCall = value; }
    }
}
