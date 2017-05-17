using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Begin : MonoBehaviour
{
    private AudioSource audio;

    void Start()
    {
        audio = GetComponent<AudioSource>();
        End();
        
    }

    void End()
    {
        Destroy(this, audio.clip.length + 0.5f);
        Destroy(audio, audio.clip.length + 0.5f);
    }
}
