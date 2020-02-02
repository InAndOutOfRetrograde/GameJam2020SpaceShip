using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleEating : MonoBehaviour
{ 
    //variables
    static public bool appleEaten = false;
    [SerializeField]
    public GameObject Player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        appleEaten = true;
        Destroy(this.gameObject);
     }

    // Update is called once per frame
    void Update()
    {
        
    }

    //getter
    public bool GetAppleEaten
    {
        get { return appleEaten; }
    }

    //Setter
    public bool SetAppleEaten
    {
        set { appleEaten = value; }
    }
}
