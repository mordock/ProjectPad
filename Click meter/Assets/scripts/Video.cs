using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class Video : MonoBehaviour {

    VideoPlayer videoPlayer;
    string vidID;
    string randVid;
    string video1 = "Assets/Videos/testVideo.mp4";
    string video2 = "Assets/Videos/testVideo2.mp4";
    string video3 = "Assets/Videos/testVideo3.mp4";
    bool mute = false;

    void Start () {
        GameObject camera = GameObject.Find("Main Camera");
        videoPlayer = camera.AddComponent<UnityEngine.Video.VideoPlayer>();

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

        videoPlayer.url = randVid;
        videoPlayer.isLooping = false;
        videoPlayer.Play();
        Debug.Log("Video: " + randVid + " loaded.");
    }
	
	void Update () {
        if (Input.GetMouseButtonDown(0)) {
            if (videoPlayer.isPlaying)
            {
                videoPlayer.Pause();
            } else
            {
                videoPlayer.Play();
            }
        }

        if (videoPlayer.frame == (long)videoPlayer.frameCount)
        {
            Debug.Log("Video: " + vidID + " ended.");
            EndReached();
        }

        if (videoPlayer.frame <= 90 || !(videoPlayer.isPlaying) || mute)
        {
            MuteButton();
        }
    }

    void EndReached()
    {
        SceneManager.LoadScene("MainMenu");
        Debug.Log("level loaded: MainMenu");
    }

    void MuteButton()
    {

    }
}
