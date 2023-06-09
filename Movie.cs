using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;

public class Movie : MonoBehaviour
{
    public Text text_PlayOrPause;
    public Button button_PlayOrPause;
    private VideoPlayer videoPlayer;
    private RawImage rawImage;
    private int flag = 0;

    void Start()
    {
        videoPlayer = this.GetComponent<VideoPlayer>();
        //audioSource = this.GetComponent<AudioSource>();
        rawImage = this.GetComponent<RawImage>();
        button_PlayOrPause.onClick.AddListener(PlayorPause);
    }

    void Update()
    {
        if (flag == 0)
        {
            if (videoPlayer.texture == null)
            {
                return;
            }
            else
            {
                rawImage.texture = videoPlayer.texture;
                flag++;
            }
        }
    }
    void PlayorPause()
    {

        if (videoPlayer.isPlaying == true)
        {
            videoPlayer.Pause();
            //audioSource.Pause();
            text_PlayOrPause.text = "播放";
        }
        else
        {
            videoPlayer.Play();
            text_PlayOrPause.text = "暂停";
        }
    }
}