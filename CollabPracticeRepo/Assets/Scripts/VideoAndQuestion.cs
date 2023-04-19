using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;
using TMPro;


public class VideoAndQuestion : MonoBehaviour
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
    public string Video_2;
    public string Video_3;
    public string Video_3_Help;

    public GameObject Overlay;

    public Button Option_1;
    public Button Option_2;
    public Button Option_3;
    public Button Option_4;
    
    public Button StartButton;

    public Button NextQuestion;
    public Button OkButton;

    public Button Correct_Option_1;
    public Button Correct_Option_2;
    public Button Correct_Option_3;
    private Button Correct_Option;

    private int QuestionNum = 1;

    // Start is called before the first frame update
    void Start()
    {
        VideoPanel.gameObject.SetActive(false);
        StartButton.gameObject.SetActive(false);

        OBJ_Option_1_Text.text = Option_1_Text;
        OBJ_Option_2_Text.text = Option_2_Text;
        OBJ_Option_3_Text.text = Option_3_Text;
        OBJ_Option_4_Text.text = Option_4_Text;

        switch (QuestionNum)
        {
            case 1:
                VideoController.GetComponent<VideoPlayer>().url = Video_1;
                StartCoroutine(StartOverlay());
                Question_1(Correct_Option_1);
                break;
            case 2:
                Debug.Log("Question 2");
                VideoController.GetComponent<VideoPlayer>().url = Video_2;
                StartCoroutine(Question2Overlay());
                Question_1(Correct_Option_2);
                break;
            case 3:
                Debug.Log("Question 3");
                VideoController.GetComponent<VideoPlayer>().url = Video_3;
                StartCoroutine(Question3Overlay());
                Question_1(Correct_Option_3);
                break;
        }
    }
    void StartButtonTask()
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
        switch (QuestionNum)
        {
            case 1:
                Debug.Log(_correctOption);
                Button strtBtn = StartButton.GetComponent<Button>();
                strtBtn.onClick.AddListener(StartButtonTask);
                //Correct Options
                Button crctBtn = _correctOption.GetComponent<Button>();
                crctBtn.onClick.AddListener(CorrectOptionTask);
                //Wrong Options
                Button wrgBtn1 = Option_1.GetComponent<Button>();
                wrgBtn1.onClick.AddListener(WrongButtonTask);
                Button wrgBtn2 = Option_3.GetComponent<Button>();
                wrgBtn2.onClick.AddListener(WrongButtonTask);
                Button wrgBtn3 = Option_4.GetComponent<Button>();
                wrgBtn3.onClick.AddListener(WrongButtonTask);
                break;
            case 2:
                Debug.Log(_correctOption);
                Button crctBtn_2 = _correctOption.GetComponent<Button>();
                crctBtn_2.onClick.AddListener(CorrectOptionTask);
                //Wrong Options
                Button wrgBtn4= Option_1.GetComponent<Button>();
                wrgBtn4.onClick.AddListener(WrongButtonTask);
                Button wrgBtn5 = Option_2.GetComponent<Button>();
                wrgBtn5.onClick.AddListener(WrongButtonTask);
                Button wrgBtn6 = Option_3.GetComponent<Button>();
                wrgBtn6.onClick.AddListener(WrongButtonTask);
                break;
            case 3:
                Debug.Log(_correctOption);
                Button crctBtn_3 = _correctOption.GetComponent<Button>();
                crctBtn_3.onClick.AddListener(CorrectOptionTask);
                //Wrong Options
                Button wrgBtn7 = Option_2.GetComponent<Button>();
                wrgBtn7.onClick.AddListener(WrongButtonTask);
                Button wrgBtn8 = Option_3.GetComponent<Button>();
                wrgBtn8.onClick.AddListener(WrongButtonTask);
                Button wrgBtn9 = Option_4.GetComponent<Button>();
                wrgBtn9.onClick.AddListener(WrongButtonTask);
                break;
        }
        return true;
    }
    void CorrectOptionTask()
    {
        OkButton.gameObject.SetActive(false);
        //Pause Video
        VideoController.GetComponent<VideoPlayer>().Pause();
        //Enable UI
        Overlay.gameObject.SetActive(true);
        Debug.Log("Correct Option"+QuestionNum);
        switch (QuestionNum)
        {
            case 1:
                if(Correct_Option_1)
                //Change Text
                NextQuestion.gameObject.SetActive(true);
                Overlay_Text.text = "Good Job! that's the correct answer!";
                //Listen for Next Button Press
                Button nxtBtn = NextQuestion.GetComponent<Button>();
                Debug.Log("Next 1");
                nxtBtn.onClick.AddListener(NextQuestionTask);
                break;
            case 2:
                //Change Text
                NextQuestion.gameObject.SetActive(true);
                Overlay_Text.text = "Good Job! that's the correct answer!";
                //Listen for Next Button Press
                Button nxtBtn2 = NextQuestion.GetComponent<Button>();
                Debug.Log("Next 2");
                nxtBtn2.onClick.AddListener(NextQuestionTask);
                break;
            case 3:
                //Change Text
                NextQuestion.gameObject.SetActive(true);
                Overlay_Text.text = "Good Job! that's the correct answer!";
                //Listen for Next Button Press
                Button nxtBtn3 = NextQuestion.GetComponent<Button>();
                //Console Log
                Debug.Log("Next 3");
                nxtBtn3.onClick.AddListener(EndGame);
                break;
        }
    }
    void WrongButtonTask()
    {
        NextQuestion.gameObject.SetActive(false);
        //Pause Video
        VideoController.GetComponent<VideoPlayer>().Pause();
        //Enable UI
        Overlay.gameObject.SetActive(true);
        OkButton.gameObject.SetActive(true);

        switch (QuestionNum)
        {
            case 1:
                //Change Text
                Overlay_Text.text = "Wrong Answer! Here is a Clue!";
                //Listen for OK Button Press
                Button okBtn = OkButton.GetComponent<Button>();
                okBtn.onClick.AddListener(HelpTask);
                break;
            case 2:
                //Change Text
                Overlay_Text.text = "Wrong Answer! Here is a Clue! Where do you think the video was first posted?";
                //Listen for OK Button Press
                Button okBtn2 = OkButton.GetComponent<Button>();
                okBtn2.onClick.AddListener(HelpTask);
                break;
            case 3:
                //Change Text
                Overlay_Text.text = "Wrong Answer! Here is a Clue! Help!";
                //Listen for OK Button Press
                Button okBtn3 = OkButton.GetComponent<Button>();
                okBtn3.onClick.AddListener(HelpTask);
                break;
        }
    }
    void HelpTask()
    {
        Overlay.gameObject.SetActive(false);
        OkButton.gameObject.SetActive(false);
        if (QuestionNum == 1)
        {
            //Play Help Video
            VideoController.GetComponent<VideoPlayer>().url = Video_1_Help;
            VideoController.GetComponent<VideoPlayer>().Play();
        }
    }
    void NextQuestionTask()
    {
        Debug.Log("Current Question" + QuestionNum);
        NextQuestion.gameObject.SetActive(false);
        //Increase Question Number
        //QuestionNum++;
        //Console Log
        //Call Start Function
        //Start();

        switch (QuestionNum)
        {
            case 1:
                QuestionNum++;
                Debug.Log("Next Question!" + QuestionNum);
                Debug.Log("Question 2");
                VideoController.GetComponent<VideoPlayer>().url = Video_2;
                StartCoroutine(Question2Overlay());
                Question_1(Correct_Option_2);
                break;
            case 2:
                QuestionNum++;
                Debug.Log("Next Question!" + QuestionNum);
                Debug.Log("Question 3");
                VideoController.GetComponent<VideoPlayer>().url = Video_3;
                StartCoroutine(Question3Overlay());
                Question_1(Correct_Option_3);
                break;
        }
    }
    void EndGame()
    {
        NextQuestion.gameObject.SetActive(false);
        //Pause Video
        VideoController.GetComponent<VideoPlayer>().Pause();
        //Enable UI
        Overlay.gameObject.SetActive(true);
        //Change Text
        Overlay_Text.text = "Thank You for Participating!";
    }

    //Before Video 1
    IEnumerator StartOverlay()
    {
        Option_1.gameObject.SetActive(false);
        Option_2.gameObject.SetActive(false);
        Option_3.gameObject.SetActive(false);
        Option_4.gameObject.SetActive(false);
        OkButton.gameObject.SetActive(false);
        NextQuestion.gameObject.SetActive(false);

        Overlay_Text.text = "Welcome to Digital Detectives! Let's test you investigative skills.";
        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(1);
        Overlay_Text.text = "Watch the next videos! Answer the question correctly";
        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(1);
        Overlay_Text.text = "Good Luck! Press Start when ready!";
        StartButton.gameObject.SetActive(true);
    }
    //Switching to Video 2
    IEnumerator Question2Overlay()
    {
        NextQuestion.gameObject.SetActive(false);
        Overlay.gameObject.SetActive(true);
        Overlay_Text.text = "Nice! Here is the Second Video";

        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(5);
        StartButton.gameObject.SetActive(true);
    }
    IEnumerator Question3Overlay()
    {
        NextQuestion.gameObject.SetActive(false);
        Overlay.gameObject.SetActive(true);
        Overlay_Text.text = "Nice! Here is the Third Video";

        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(5);
        StartButton.gameObject.SetActive(true);
    }
}
