using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpenSFX : MonoBehaviour
{
    public static AudioSource sfx;
    // Start is called before the first frame update
    void Start()
    {
        sfx = GetComponent<AudioSource>();
    }
    
    public static void playSFX()
    {
        sfx.Play();  
    }
}
