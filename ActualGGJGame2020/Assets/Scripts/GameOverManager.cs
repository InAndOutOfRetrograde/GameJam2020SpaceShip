using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverManager : MonoBehaviour
{
    [SerializeField]
    GameObject OCGame;
    [SerializeField]
    GameObject SGame;
    [SerializeField]
    GameObject AGame;
    //Vars
    OC_Button OCGameBroken;
    S_Manager SGameBroken;
    ComputerRoomPowerButton AGameBroken;
    bool SIsBroken = false;
    bool OCIsBroken = false;
    bool AIsFixed = false;
    // Start is called before the first frame update
    void Start()
    {
        OCGameBroken = OCGame.GetComponent<OC_Button>();
        SGameBroken = SGame.GetComponent<S_Manager>();
        AGameBroken = AGame.GetComponent<ComputerRoomPowerButton>();
    }

    // Update is called once per frame
    void Update()
    {
        AIsFixed = AGameBroken.ComputerRoomFixed;
        SIsBroken = SGameBroken.Done();
        OCIsBroken = OCGameBroken.GetBrokenCall;
        if (OCIsBroken && SIsBroken && !AIsFixed)
        {
            Debug.Log("Game Over.");
        }
    }
}
