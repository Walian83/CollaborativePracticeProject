using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class SoundScript : MonoBehaviour
{
    public Toggle soundToggle;
    public VideoPlayer videoController;

    public void OnToggle()
    {
        if (soundToggle.isOn == true)
        {
            videoController.SetDirectAudioMute(0, false);
        }
        else if (soundToggle.isOn == false)
        {
            videoController.SetDirectAudioMute(0, true);
        }
        
    }
}