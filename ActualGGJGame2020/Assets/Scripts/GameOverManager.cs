using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverManager : MonoBehaviour
{
    [SerializeField]
    GameObject OCGame;
    [SerializeField]
    GameObject SGame;

    //Vars
    OC_Button OCGameBroken;
    S_Manager SGameBroken;
    bool SIsBroken;
    bool OCIsBroken = false;
    // Start is called before the first frame update
    void Start()
    {
        OCGameBroken = OCGame.GetComponent<OC_Button>();
        SGameBroken = SGame.GetComponent<S_Manager>();
    }

    // Update is called once per frame
    void Update()
    {
        SIsBroken = SGameBroken.Done();
        OCIsBroken = OCGameBroken.GetBrokenCall;
        if (OCIsBroken && SIsBroken)
        {
            Debug.Log("Game Over. ");
        }
    }
}
