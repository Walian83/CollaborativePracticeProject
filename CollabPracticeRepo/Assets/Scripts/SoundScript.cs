using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundScript : MonoBehaviour
{
    public Toggle soundToggle;
    public AudioSource audioSource;

    void Start()
    {

    }

    private void Update()
    {
        if (soundToggle.isOn == true)
        {
            audioSource.mute = false;
        }
        else if (soundToggle.isOn == false)
        {
            audioSource.mute = true;
        }
    }
}