﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_Manager : MonoBehaviour
{
    // Start is called before the first frame update
   
    
    int buttons = 0;
    Timer spawnTimer;
    //Light buttonNum;
    void Start()
    {
        spawnTimer = gameObject.AddComponent<Timer>();
        //buttonNum = gameObject.AddComponent<Light>();
        spawnTimer.Duration = GetSpawnDelayLong();
        spawnTimer.Run();

        
    }

    // Update is called once per frame
    void Update()
    {
            if (GameObject.Find("button").GetComponent<S_Light>().checkedOff == false)
            {


            //if (buttonNum.buttonNum() == true)
            //{
            //    buttons++;
            //}

            
            }
        //Debug.Log(buttons);

        if (buttons == 12)
        {
            //spawnTimer.Stop();
            spawnTimer.Duration = GetSpawnDelayLong();
            spawnTimer.Run();
        }

    }
    public bool Done()
    {
        return spawnTimer.Finished;
    }

    float GetSpawnDelay()
    {
        buttons = 0;
        return 30;
    }
    float GetSpawnDelayLong()
    {
        buttons = 0;
        return 30;
    }

    //Adds 1 to buttons
    public void buttonAdder()
    {
        buttons++;
    }


    public int GetButtons
    {
        get { return buttons; }
    }
}
