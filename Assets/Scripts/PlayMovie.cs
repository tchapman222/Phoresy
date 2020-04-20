using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.Audio;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

//This script does more than it should.
//It started as a script to play my videos, then also turned into an end game script.

public class PlayMovie : MonoBehaviour
{
    // Start is called before the first frame update
    VideoPlayer videoPlay;
    public gameManager myGameManager;
    public VideoClip vidClip0;
    public VideoClip vidClip1;
    public VideoClip vidClip2;

    private GameObject myEventSystem;
    private GameObject myCanvas;
    private GameObject aliveBtn;
    private GameObject shutdownBtn;
    private GameObject crosshair;

    void Start()
    {
        if (gameObject.CompareTag("secretVideo"))
        {
            myEventSystem = GameObject.FindGameObjectWithTag("Events");
            myCanvas = GameObject.FindGameObjectWithTag("Canvas");
            aliveBtn = GameObject.FindGameObjectWithTag("AliveBtn");
            shutdownBtn = GameObject.FindGameObjectWithTag("ShutdownBtn");
            crosshair = GameObject.FindGameObjectWithTag("Crosshair");
            aliveBtn.SetActive(false);
            shutdownBtn.SetActive(false);

            
        }

        
        myGameManager = FindObjectOfType<gameManager>();
        videoPlay = GetComponent<VideoPlayer>();
        videoPlay.Pause();
        print("Video Length: " + Convert.ToInt32(videoPlay.GetComponent<VideoPlayer>().length));

    }

    private void OnTriggerEnter(Collider other)
    {
        if (videoPlay.isPaused == true || videoPlay.isPlaying == false)
        {
            if (gameObject.CompareTag("secretVideo") == true)
            {
                StartCoroutine(CoFunc(Convert.ToInt32(videoPlay.GetComponent<VideoPlayer>().length)));
                print("Video Length: " + Convert.ToInt32(videoPlay.GetComponent<VideoPlayer>().length));
                
            }
            else if (myGameManager.wentWest == false)
            {
                videoPlay.clip = vidClip0;
                
            }
            else
            {
                videoPlay.clip = vidClip1;
                print("Changed to video clip " + videoPlay.clip);
            }
            videoPlay.Play();
        }
    }

    private void Update()
    {
        if (videoPlay.clip == vidClip1 && videoPlay.isPrepared && videoPlay.isPlaying == false)
        {
            
            videoPlay.clip = vidClip2;
            videoPlay.isLooping = true;
            videoPlay.Play();
        }
    }
    
    IEnumerator CoFunc(int secondsToWait)
    {
        yield return new WaitForSeconds(secondsToWait);
        myEventSystem.GetComponent<EventSystem>().firstSelectedGameObject = shutdownBtn;
        crosshair.SetActive(false);
        myCanvas.GetComponent<VideoPlayer>().Play();
        aliveBtn.SetActive(true);
        shutdownBtn.SetActive(true);
        videoPlay.enabled = false;
        myGameManager.FPSController.GetComponent<CharacterController>().enabled = false;
        myGameManager.FPSController.GetComponent<FirstPersonController>().enabled = false;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Confined;
    }
    
    public void QuitGame()
    {
        print("Quitting Game");
        Application.Quit();
    }
}
