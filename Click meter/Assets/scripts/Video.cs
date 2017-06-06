using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class Video : MonoBehaviour
{

    VideoPlayer videoPlayer;
    string vidID;
    string randVid;
    string video1 = "Assets/Videos/testVideo.mp4";
    string video2 = "Assets/Videos/testVideo2.mp4";
    string video3 = "Assets/Videos/testVideo3.mp4";
    public GameObject Canvas;
    public GameObject Pause;
    public GameObject MuteButton;
    public GameObject UnmuteButton;
    public GameObject ExitButton;

    void Start()
    {
        GameObject camera = GameObject.Find("Main Camera");
        videoPlayer = camera.AddComponent<UnityEngine.Video.VideoPlayer>();

        //Select random video
        int random = Random.Range(1, 4);
        switch (random)
        {
            case 1:
                vidID = "video1";
                randVid = video1;
                break;
            case 2:
                vidID = "video2";
                randVid = video2;
                break;
            case 3:
                vidID = "video3";
                randVid = video3;
                break;
        }

        AudioListener.volume = 1;
        videoPlayer.url = randVid;
        videoPlayer.isLooping = false;
        videoPlayer.Play();
        Debug.Log("Video: " + randVid + " loaded.");
    }

    void Update()
    {
        //Pause video when user taps on screen
        if (Input.GetMouseButtonDown(0))
        {
            PauseCheck();
        }

        //When the video ends
        if (videoPlayer.frame == (long)videoPlayer.frameCount)
        {
            Debug.Log("Video: " + vidID + " ended.");
            Exit();
        }
    }

    //Method to check if the user correctly pressed the screen to pause the video
    void PauseCheck()
    {
        bool NotMuteX = false;
        bool NotMuteY = false;
        bool NotExitX = false;
        bool NotExitY = false;

        //MuteButton or UnmuteButton's position and radius as displayed on screen
        float MutePositionX;
        float MutePositionY;
        float MuteRadius;

        //When the video is not muted, use MuteButton's position
        if (AudioListener.volume == 1)
        {
            MutePositionX = MuteButton.GetComponent<RectTransform>().position.x;
            MutePositionY = MuteButton.GetComponent<RectTransform>().position.y;
            MuteRadius = MuteButton.GetComponent<RectTransform>().localScale.y * MuteButton.GetComponent<RectTransform>().sizeDelta.y / 2;
        }
        //When the video is muted, use UnmuteButton's position
        else
        {
            MutePositionX = UnmuteButton.GetComponent<RectTransform>().position.x;
            MutePositionY = UnmuteButton.GetComponent<RectTransform>().position.y;
            MuteRadius = UnmuteButton.GetComponent<RectTransform>().localScale.y * MuteButton.GetComponent<RectTransform>().sizeDelta.y / 2;
        }   

        //ExitButton's position and radius as displayed on screen
        float ExitPositionX = ExitButton.GetComponent<RectTransform>().position.x;
        float ExitPositionY = ExitButton.GetComponent<RectTransform>().position.y;
        float ExitRadius = ExitButton.GetComponent<RectTransform>().localScale.y * ExitButton.GetComponent<RectTransform>().sizeDelta.y / 2;

        //If-statements to check if the user is not pressing on any button
        if (Input.mousePosition.x > MutePositionX + MuteRadius) { NotMuteX = true; }
        if (Input.mousePosition.y > MutePositionY + MuteRadius) { NotMuteY = true; }

        if (Input.mousePosition.x < ExitPositionX - ExitRadius) { NotExitX = true; }
        if (Input.mousePosition.y < ExitPositionY - ExitRadius) { NotExitY = true; }


        //If the user is pressing in the middle of the screen
        if (NotMuteY && NotExitY) { PauseVideo(); }
        //If the user is pressing in the bottom right corner of the screen
        else if (!(NotMuteY) && NotMuteX && NotExitY) { PauseVideo(); }
        //If the user is pressing in the top left corner of the screen
        else if (!(NotExitY) && NotExitX && NotMuteY) { PauseVideo(); }
    }

    //Method to pause the video and toggle the pause icon on/off
    void PauseVideo()
    {
        if (videoPlayer.isPlaying)
        {
            videoPlayer.Pause();
            Pause.GetComponent<Renderer>().enabled = true;
        }
        else
        {
            videoPlayer.Play();
            Pause.GetComponent<Renderer>().enabled = false;
        }
    }

    //Method to leave the Video scene
    public void Exit()
    {
        SceneManager.LoadScene("MainMenu");
        Debug.Log("level loaded: MainMenu");
    }

    //Method called on MuteButton press
    public void Mute()
    {
        AudioListener.volume = 0;
        SwitchButtons();
        Debug.Log("Audio muted");
    }

    //Method called on UnmuteButton press
    public void Unmute()
    {
        AudioListener.volume = 1;
        SwitchButtons();
        Debug.Log("Audio unmuted");
    }

    //Method to move the pressed button off-screen, and the unused button on-screen
    void SwitchButtons()
    {
        Vector2 MuteButtonPos = MuteButton.GetComponent<RectTransform>().position;
        Vector2 UnmuteButtonPos = UnmuteButton.GetComponent<RectTransform>().position;
        MuteButton.GetComponent<RectTransform>().position = UnmuteButtonPos;
        UnmuteButton.GetComponent<RectTransform>().position = MuteButtonPos;
    }

}
