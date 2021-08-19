using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audioManager : MonoBehaviour
{
    [SerializeField] AudioClip roundWinner, gameWinner;
    AudioSource audio;
    
    void Start()
    {
        audio = GetComponent<AudioSource>();
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void playRoundWinner()
    {
      
        audio.clip = roundWinner;
        audio.Play();
    }

    
}
