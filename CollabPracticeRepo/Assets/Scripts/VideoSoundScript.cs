using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class VideoSoundScript : MonoBehaviour
{
    public Toggle soundToggle;
    public VideoPlayer videoPlayer;

    void Start()
    {

    }

    private void Update()
    {
        if (soundToggle.isOn == true)
        {
            videoPlayer.SetDirectAudioMute(0, false);
        }
        else if (soundToggle.isOn == false)
        {
            videoPlayer.SetDirectAudioMute(0, true);
        }
    }
}
