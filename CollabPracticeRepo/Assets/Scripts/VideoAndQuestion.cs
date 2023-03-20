using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;
using TMPro;


public class VideoAndQuestion : MonoBehaviour
{
    
    public TMP_Text OBJ_Option_1_Text;
    public TMP_Text OBJ_Option_2_Text;
    public TMP_Text OBJ_Option_3_Text;
    public TMP_Text OBJ_Option_4_Text;

    public string Option_1_Text;
    public string Option_2_Text;
    public string Option_3_Text;
    public string Option_4_Text;


    private VideoClip CurrentVideo;
    public VideoClip Video_Path_1;
    public VideoClip Video_Path_2;
    public VideoClip Video_Path_3;

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

    private int QuestionNum;

    // Start is called before the first frame update
    void Start()
    {

        if(QuestionNum == 1)
        {
            Correct_Option = Correct_Option_1;
            Question_1(Correct_Option);
        }else if(QuestionNum == 2)
        {
            Correct_Option = Correct_Option_2;
            Question_2(Correct_Option);
        }
        else if (QuestionNum == 3)
        {
            Correct_Option = Correct_Option_3;
            Question_3(Correct_Option);
        }

        Button nxtBtn = NextQuestion.GetComponent<Button>();
        nxtBtn.onClick.AddListener(NextQuestionTask);
    }

    void Question_1(Button _correctOption) {
        QuestionNum = 1;
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

        void StartButtonTask()
        {
            Debug.Log("Start Game!");

            StartButton.gameObject.SetActive(false);
            Overlay.gameObject.SetActive(false);

            Option_1.gameObject.SetActive(true);
            Option_2.gameObject.SetActive(true);
            Option_3.gameObject.SetActive(true);
            Option_4.gameObject.SetActive(true);

            CurrentVideo = Video_Path_1;
            PlayVideo(CurrentVideo);

        }
        void CorrectOptionTask()
        {
            Overlay.gameObject.SetActive(true);

            NextQuestion.gameObject.SetActive(true);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    void NextQuestionTask()
    {

    }
    void PlayVideo(VideoClip _currentVideo)
    {
        // Will attach a VideoPlayer to the main camera.
        GameObject camera = GameObject.Find("Main Camera");

        // VideoPlayer automatically targets the camera backplane when it is added
        // to a camera object, no need to change videoPlayer.targetCamera.
        var videoPlayer = camera.AddComponent<UnityEngine.Video.VideoPlayer>();

        // Play on awake defaults to true. Set it to false to avoid the url set
        // below to auto-start playback since we're in Start().
        videoPlayer.playOnAwake = false;

        // By default, VideoPlayers added to a camera will use the far plane.
        // Let's target the near plane instead.
        videoPlayer.renderMode = UnityEngine.Video.VideoRenderMode.CameraNearPlane;

        // This will cause our Scene to be visible through the video being played.
        videoPlayer.targetCameraAlpha = 0.5F;

        // Set the video to play. URL supports local absolute or relative paths.
        // Here, using absolute.
        videoPlayer.url = /*_currentVideo.ToString() + ".mp4"*/ /*"pexels-rodnae-productions-6124799"*/;

        // Skip the first 100 frames.
        videoPlayer.frame = 100;

        // Restart from beginning when done.
        videoPlayer.isLooping = false;

        // Each time we reach the end, we slow down the playback by a factor of 10.
        videoPlayer.loopPointReached += EndReached;

        // Start playback. This means the VideoPlayer may have to prepare (reserve
        // resources, pre-load a few frames, etc.). To better control the delays
        // associated with this preparation one can use videoPlayer.Prepare() along with
        // its prepareCompleted event.

        videoPlayer.Play();
    }
    void EndReached(UnityEngine.Video.VideoPlayer vp)
    {
        vp.playbackSpeed = vp.playbackSpeed / 10.0F;
    }

}
