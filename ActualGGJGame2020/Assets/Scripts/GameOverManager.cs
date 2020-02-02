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

    [SerializeField]
    GameObject OCLight;
    [SerializeField]
    GameObject SLight;
    [SerializeField]
    GameObject ALight;
    [SerializeField]
    Sprite green;
    [SerializeField]
    Sprite red;

    //Vars
    OC_Button OCGameBroken;
    S_Manager SGameBroken;
    ComputerRoomPowerButton AGameBroken;
    bool SIsBroken = false;
    bool OCIsBroken = false;
    bool AIsFixed = false;
    SpriteRenderer ALightSprite;
    SpriteRenderer OCLightSprite;
    SpriteRenderer SLightSprite;



    // Start is called before the first frame update
    void Start()
    {
        OCGameBroken = OCGame.GetComponent<OC_Button>();
        SGameBroken = SGame.GetComponent<S_Manager>();
        AGameBroken = AGame.GetComponent<ComputerRoomPowerButton>();

        ALightSprite = ALight.GetComponent<SpriteRenderer>();
        OCLightSprite = OCLight.GetComponent<SpriteRenderer>();
        SLightSprite = SLight.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        AIsFixed = AGameBroken.ComputerRoomFixed;
        SIsBroken = SGameBroken.Done();
        OCIsBroken = OCGameBroken.GetBrokenCall;

        if (!AIsFixed)
        {
            ALightSprite.sprite = red;
        } else
        {
            ALightSprite.sprite = green;
        }

        if (SIsBroken)
        {
            SLightSprite.sprite = red;
        }
        else
        {
            SLightSprite.sprite = green;
        }

        if (OCIsBroken)
        {
            OCLightSprite.sprite = red;
        } else
        {
            OCLightSprite.sprite = green;
        }

        if (OCIsBroken && SIsBroken && !AIsFixed)
        {
            //Debug.Log("Game Over!");
            Application.Quit();
        }
    }
}
