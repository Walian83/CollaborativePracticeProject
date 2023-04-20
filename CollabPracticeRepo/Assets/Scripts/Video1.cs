using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;
using UnityEngine.UI;
using TMPro;

public class Video1 : MonoBehaviour 
{ 

public TMP_Text Overlay_Text;

public TMP_Text OBJ_Option_1_Text;
public TMP_Text OBJ_Option_2_Text;
public TMP_Text OBJ_Option_3_Text;
public TMP_Text OBJ_Option_4_Text;

public string Option_1_Text;
public string Option_2_Text;
public string Option_3_Text;
public string Option_4_Text;


public GameObject VideoPanel;
public GameObject VideoController;

public string Video_1;
public string Video_1_Help;

public GameObject Overlay;

public Button Option_1;
public Button Option_2;
public Button Option_3;
public Button Option_4;

//UI BUttons
public Button StartButton;
public Button NextButton;
public Button OkButton;

public Button Correct_Option_1;


// Start is called before the first frame update
void Start()
{
    VideoPanel.gameObject.SetActive(false);
    StartButton.gameObject.SetActive(false);

    OBJ_Option_1_Text.text = Option_1_Text;
    OBJ_Option_2_Text.text = Option_2_Text;
    OBJ_Option_3_Text.text = Option_3_Text;
    OBJ_Option_4_Text.text = Option_4_Text;

    VideoController.GetComponent<VideoPlayer>().url = Video_1;
    StartCoroutine(StartOverlay());
    Question_1(Correct_Option_1);


}
IEnumerator StartOverlay()
{
    Option_1.gameObject.SetActive(false);
    Option_2.gameObject.SetActive(false);
    Option_3.gameObject.SetActive(false);
    Option_4.gameObject.SetActive(false);
    OkButton.gameObject.SetActive(false);
    NextButton.gameObject.SetActive(false);

    Overlay_Text.text = "Welcome to Digital Detectives! Let's Test Your Investigative Skills.";
    //yield on a new YieldInstruction that waits for 5 seconds.
    yield return new WaitForSeconds(5);
    Overlay_Text.text = "Watch the Next Videos! Answer the Question Correctly";
    //yield on a new YieldInstruction that waits for 5 seconds.
    yield return new WaitForSeconds(5);
    Overlay_Text.text = "Good Luck! Press Start When Ready!";
    StartButton.gameObject.SetActive(true);
    Button strtBtn = StartButton.GetComponent<Button>();
    strtBtn.onClick.AddListener(StartVideo);
}
void StartVideo()
{
    Debug.Log("START GAME!");
    //Disable UI Panel
    StartButton.gameObject.SetActive(false);
    Overlay.gameObject.SetActive(false);
    //Enable Buttons
    Option_1.gameObject.SetActive(true);
    Option_2.gameObject.SetActive(true);
    Option_3.gameObject.SetActive(true);
    Option_4.gameObject.SetActive(true);
    //Enable Video
    VideoPanel.gameObject.SetActive(true);
    VideoController.GetComponent<VideoPlayer>().Play();
}
bool Question_1(Button _correctOption)
{
    Debug.Log(_correctOption);
    Button crctBtn = _correctOption.GetComponent<Button>();
    crctBtn.onClick.AddListener(CorrectOptionTask);
    //Wrong Options
    Button wrgBtn1 = Option_1.GetComponent<Button>();
    wrgBtn1.onClick.AddListener(WrongButtonTask);
    Button wrgBtn2 = Option_3.GetComponent<Button>();
    wrgBtn2.onClick.AddListener(WrongButtonTask);
    Button wrgBtn3 = Option_4.GetComponent<Button>();
    wrgBtn3.onClick.AddListener(WrongButtonTask);
    return true;
}
void CorrectOptionTask()
{
    //Pause Video
    VideoController.GetComponent<VideoPlayer>().Pause();
    //Enable UI
    Overlay.gameObject.SetActive(true);
    //Updates the score
    ScoreScript.scoreValue += 1;
    Debug.Log("Correct Option - Score: " + ScoreScript.scoreValue);
    Overlay_Text.text = "Good Job! that's the correct answer!";
    //Listen for Next Button Press
    NextButton.gameObject.SetActive(true);
    Button nxtBtn = NextButton.GetComponent<Button>();
    nxtBtn.onClick.AddListener(NextQuestion);
}
void WrongButtonTask()
{
    //Pause Video
    VideoController.GetComponent<VideoPlayer>().Pause();
    //Enable UI
    Overlay.gameObject.SetActive(true);
    OkButton.gameObject.SetActive(true);

    //Change Text
    Overlay_Text.text = "Wrong Answer! Here is a Clue!";
    //Listen for OK Button Press
    Button okBtn = OkButton.GetComponent<Button>();
    okBtn.onClick.AddListener(HelpTask);
}
void HelpTask()
{
    Overlay.gameObject.SetActive(false);
    OkButton.gameObject.SetActive(false);

    VideoController.GetComponent<VideoPlayer>().url = Video_1_Help;
    VideoController.GetComponent<VideoPlayer>().Play();
}
void NextQuestion()
{
    SceneManager.LoadScene(2);
}
}
