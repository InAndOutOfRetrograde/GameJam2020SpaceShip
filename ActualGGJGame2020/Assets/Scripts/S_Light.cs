using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_Light : MonoBehaviour
{
    // States of the button
    public enum State
    {
        off,
        On
    }

    [SerializeField]
    GameObject gameManager;

    public State _state;
    public Sprite red;
    public Sprite green;
    public SpriteRenderer spriteRenderer;
    S_Manager timerdone;
    private BoxCollider2D bc;
    private Rigidbody2D rb;
    public bool checkedOff;
    public int button = 0;
    
    // gets the sprite render, gets manager, gets rigidbody 2d
    public void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        timerdone = gameManager.GetComponent<S_Manager>();
        rb = GetComponent<Rigidbody2D>();
        bc = GetComponent<BoxCollider2D>();
       
        _state = State.On;
    }

    public void Update()
    {
        //timerdone.GetButtons == 12
        if (_state == State.On)
        {
            if (timerdone.Done() == true)
            {
                button = 0;
                _state = State.off;
                spriteRenderer.sprite = red;
                checkedOff = false;
                Debug.Log("false");
          
            }
            
        }

        if (checkedOff == true && timerdone.GetButtons == 12)
        {
            _state = State.On;
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log("works");
        Debug.Log("CheckedOff: " + checkedOff + "\nState: " + _state);
        if (_state == State.off && !checkedOff)
        {
            
            spriteRenderer.sprite = green;
            Debug.Log("green");
            checkedOff = true;
            
            //button++;
            timerdone.buttonAdder(); 
           

        }       
    }
    
    public bool buttonNum()
    {
        if(button == 1)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
  




}

// Update is called once per frame


