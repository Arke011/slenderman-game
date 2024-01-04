using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PageManager : MonoBehaviour
{
    public int pages;
    public Enemy enemy;
    public AudioSource soundSource;

    public Flashlight flashlight;
    public FirstPersonMovement movement; 

    void OnTriggerEnter(Collider other)
    {
        Destroy(other.gameObject);
        pages++;

        if (pages == 1)
        {
            enemy.target = transform;
            
        }
        else if (pages == 2)
        {
            enemy.speed *= 1.5f; 
        }
        else if (pages == 3)
        {
            enemy.speed *= 1.5f; 
            PlaySound();
        }
        else if (pages == 4)
        {
            
           flashlight.batteryLevel -= 30f; 
            enemy.viewDistance += 1000; 
        }
        else if (pages == 5)
        {
            
            
            movement.speed -= 2f; 
            
        }
    }

    

    void PlaySound()
    {
        if (soundSource != null)
        {
            if (soundSource.clip != null)
            {
                soundSource.Play();
            }
        }
    }
}
