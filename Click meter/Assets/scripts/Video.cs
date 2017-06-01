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
    public GameObject Pause;

    void Start () {
        GameObject camera = GameObject.Find("Main Camera");
        videoPlayer = camera.AddComponent<UnityEngine.Video.VideoPlayer>();

        //Selecteer een random video
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
        //Pauzeer de video als de gebruiker klikt
        if (Input.GetMouseButtonDown(0)) {
            if (videoPlayer.isPlaying)
            {
                videoPlayer.Pause();
                Pause.GetComponent<Renderer>().enabled = true;
            } else
            {
                videoPlayer.Play();
                Pause.GetComponent<Renderer>().enabled = false;
            }
        }

        //Wanneer de video afgelopen is
        if (videoPlayer.frame == (long)videoPlayer.frameCount)
        {
            Debug.Log("Video: " + vidID + " ended.");
            EndReached();
        }
    }

    //Functie om de Video scene te verlaten
    void EndReached()
    {
        SceneManager.LoadScene("MainMenu");
        Debug.Log("level loaded: MainMenu");
    }
}
