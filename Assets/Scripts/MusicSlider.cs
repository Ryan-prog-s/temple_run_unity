using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicSlider : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioSource AudioSource;

    private float musicVolume = 1f;

    void Start()
    {
        AudioSource.Play();   
    }

    // Update is called once per frame
    public void updateVolume(float volume)
    {
        musicVolume = volume;  
    }
}
