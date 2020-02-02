using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverManager : MonoBehaviour
{
    [SerializeField]
    GameObject OCGame;

    //Vars
    OC_Button OCGameBroken;
    bool OCIsBroken = false;
    // Start is called before the first frame update
    void Start()
    {
        OCGameBroken = OCGame.GetComponent<OC_Button>();
    }

    // Update is called once per frame
    void Update()
    {       
        OCIsBroken = OCGameBroken.GetBrokenCall;
        if (OCIsBroken)
        {
            Debug.Log("Game Over. ");
        }
    }
}
