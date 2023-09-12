using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VideoInicioController : MonoBehaviour
{
    public VideoPlayer video;
    public GameObject botonCnt;

    // Start is called before the first frame update
    void Start()
    {
        video.loopPointReached += FinVideo;
    }

    private void FinVideo(VideoPlayer vp) {
        vp.Pause();
        botonCnt.SetActive(true);
    }  
}
