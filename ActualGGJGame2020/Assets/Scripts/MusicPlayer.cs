using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    
    AudioSource player;
    public
    AudioClip Music;
    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<AudioSource>();
        player.clip = Music;
        player.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
