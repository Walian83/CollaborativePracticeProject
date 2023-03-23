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
    public string Video_2;
    public string Video_3;



    public GameObject Overlay;

    public Button Option_1;
    public Button Option_2;
    public Button Option_3;
    public Button Option_4;
    
    public Button StartButton;

    public Button NextQuestion;

    public Button Correct_Option_1;
    public Button Correct_Option_2;
    public Button Correct_Option_3;
    public Button Correct_Option;

    private int QuestionNum = 1;

    // Start is called before the first frame update
    void Start()
    {
        VideoPanel.gameObject.SetActive(false);
        StartButton.gameObject.SetActive(false);

        if (QuestionNum == 1)
        {
            StartCoroutine(StartOverlay());
            Correct_Option = Correct_Option_1;
            Question_1(Correct_Option_1);
            VideoController.GetComponent<VideoPlayer>().url = Video_1;
        }
        else if (QuestionNum == 2)
        {
            StartCoroutine(Question2Overlay());
            Correct_Option = Correct_Option_2;
            Question_1(Correct_Option_2);
        }
        else if (QuestionNum == 3)
        {
            Correct_Option = Correct_Option_3;
            // Question_3(Correct_Option);
        }
    }
    IEnumerator StartOverlay()
    {
        Overlay_Text.text = "Welcome to Digital Detectives! Let's test you investigative skills.";

        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(5);
        Overlay_Text.text = "Watch the next videos! Answer the question correctly";

        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(5);

        Overlay_Text.text = "Good Luck! Press Start when ready!";
        StartButton.gameObject.SetActive(true);
    }

    IEnumerator Question2Overlay()
    {
        Overlay_Text.text = "Nice! Here is the Second Video";

        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(5);

        StartButton.gameObject.SetActive(true);
    }

    void StartButtonTask()
    {
        Debug.Log("Start Game!");

        StartButton.gameObject.SetActive(false);
        Overlay.gameObject.SetActive(false);

        Option_1.gameObject.SetActive(true);
        Option_2.gameObject.SetActive(true);
        Option_3.gameObject.SetActive(true);
        Option_4.gameObject.SetActive(true);

        VideoPanel.gameObject.SetActive(true);
        VideoController.GetComponent<VideoPlayer>().Play();
        //PlayVideo(CurrentVideo);

    }

    void Question_1(Button _correctOption) {

        Option_1.gameObject.SetActive(false);
        Option_2.gameObject.SetActive(false);
        Option_3.gameObject.SetActive(false);
        Option_4.gameObject.SetActive(false);

        NextQuestion.gameObject.SetActive(false);

        OBJ_Option_1_Text.text = Option_1_Text;
        OBJ_Option_2_Text.text = Option_2_Text;
        OBJ_Option_3_Text.text = Option_3_Text;
        OBJ_Option_4_Text.text = Option_4_Text;

        Button strtBtn = StartButton.GetComponent<Button>();
        strtBtn.onClick.AddListener(StartButtonTask);

        Button crctBtn = _correctOption.GetComponent<Button>();
        crctBtn.onClick.AddListener(CorrectOptionTask);

        void CorrectOptionTask()
        {
            Overlay.gameObject.SetActive(true);
            Overlay_Text.text = "Good Job! that's the correct answer!";
            NextQuestion.gameObject.SetActive(true);

            Button nxtBtn = NextQuestion.GetComponent<Button>();
            nxtBtn.onClick.AddListener(NextQuestionTask);
        }

        void NextQuestionTask()
        {
            QuestionNum++;
            Overlay_Text.text = "Good Job! that's the correct answer!";
            Start();
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
