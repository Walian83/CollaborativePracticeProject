using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;

public class PauseScript : MonoBehaviour
{
    public GameObject VideoController;
    public GameObject VideoPanel;
    public Button Option_1;
    public Button Option_2;
    public Button Option_3;
    public Button Option_4;

    public void PauseGame()
    {
        Time.timeScale = 0;
        VideoController.GetComponent<VideoPlayer>().Pause();
        Option_1.interactable = false;
        Option_2.interactable = false;
        Option_3.interactable = false;
        Option_4.interactable = false;
    }

    public void ResumeGame()
    {
        if (VideoPanel.activeInHierarchy == false)
        {
            Time.timeScale = 1;
            Option_1.interactable = true;
            Option_2.interactable = true;
            Option_3.interactable = true;
            Option_4.interactable = true;
        }
        else
        {
            Time.timeScale = 1;
            VideoController.GetComponent<VideoPlayer>().Play();
            Option_1.interactable = true;
            Option_2.interactable = true;
            Option_3.interactable = true;
            Option_4.interactable = true;
        }

    }

}
