using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComputerRoomPowerButton : MonoBehaviour
{
    //variables
    private bool ComputerStartButtonPressed = false;
    [SerializeField]
    public GameObject appleClone;
    public bool ComputerRoomFixed = true;
    Timer spawnTimer;
    AppleEating appleEating;

    void Start()
    {
        spawnTimer = gameObject.AddComponent<Timer>();
        appleEating = appleClone.GetComponent<AppleEating>();

        spawnTimer.Duration = GetSpawnDelayLong();
        spawnTimer.Run();
    }
    
    //if the player hovers and collides into this, return a boolean that equals true.
    void OnTriggerEnter2D(Collider2D collision)
    {
        //makes it so the player cant spam place apples by checking for if the button has been pressed recently.
        if (collision.gameObject.name == "Player")
        {
            //do nothing if already pressed recently and main game loop isn't done yet.
            if(ComputerStartButtonPressed == true)
            {
                
            }
            else
            {
                ComputerStartButtonPressed = true;
                //calls the method that runs the minigame.
                StartComputerMiniGame();
            }
        }
    }

    //code that runs the main minigame loop here
    void StartComputerMiniGame()
    {
        //checks if the button has been presssed yet.
        if (ComputerStartButtonPressed == true)
        {
            //randomly picks 2 numbers for coordinates on screen.(CHANGE THESE TO FIT THE ACTUAL MINI GAME IN THE BIG SCENE)
            Vector2 position = new Vector2(Random.Range(46.0f, -64.0f), Random.Range(83.0f, 142.0f));
            //places the apple
            Instantiate(appleClone, position, Quaternion.identity);
        }
    }
    float GetSpawnDelayLong()
    {
        //time
        return 6;
    }
    // Update is called once per frame
    void Update()
    {
        //use a script attached to the apple to see if it has been eaten first.
        
        if (appleEating.GetAppleEaten == true)
        {
            Debug.Log("Apple is eaten!");
            //if so, set state to fixed
            ComputerRoomFixed = true;
            //change to happy sprite here
            //start a cooldown timer <---COOL DOWN TIMER IS HERE <-------------------------
            spawnTimer.Stop();
            spawnTimer.Duration = GetSpawnDelayLong();
            spawnTimer.Run();
            //checks to see if timer is done to let the player try again.

            appleEating.SetAppleEaten = false;
        }

        if (spawnTimer.Finished)
        {
            //lets the player press it again after the game loop.
            ComputerStartButtonPressed = false;
            ComputerRoomFixed = false;
        }
    }
}
