using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Act : MonoBehaviour
{

    public string name;
    private bool cueActivated = false;
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    void Update()
    {
        CheckForCue();
    }

    void CheckForCue()
    {
        if (cueActivated)
            return;

        cueActivated = true;
        PlayAct();
    }

    void PlayAct()
    {
        audioSource.Play();
        EndAct();
     
    }


    void EndAct()
    {
        Destroy(this, audioSource.clip.length + 0.3f);
        Destroy(audioSource, audioSource.clip.length + 0.3f);
    }
}
