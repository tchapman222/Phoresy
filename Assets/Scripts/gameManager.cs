using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

/*The general game manager for the game. Also took on managing of the lights. */

public class gameManager : MonoBehaviour
{
    private Vector3 teleportPointFromMenu= new Vector3(-0.32f, 1.13f, -5.45f);
    private Vector3 teleportPointFromOther= new Vector3(22.54f, 1.13f, 0f);
    public GameObject FPSController;
    public GameObject[] lightsOn;
    public GameObject[] lightsOff;
    private Scene scene;
    private Scene prevScene;
    private static bool firstLoad = true;
    public bool wentWest = false;
    
    // Start is called before the first frame update
    void Start()
    {
        scene = SceneManager.GetActiveScene();
        DontDestroyOnLoad(this);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        if (scene.name != "Menu")
        {
            if (FPSController == null)
            {
                FPSController = GameObject.FindGameObjectWithTag("Player");
                print("Setting FPS Controller to: " + FPSController);
                NewSceneCreation();
            }
        }
    }

    void NewSceneCreation()
    {
        //FPSController = GameObject.FindGameObjectWithTag("Player");
        //CursorLockMode desiredMode;
        prevScene = scene;
        scene = SceneManager.GetActiveScene();
        if (firstLoad == true)
        {
            FPSController.transform.position = teleportPointFromMenu;
            firstLoad = false;
            print("firstLoad: " + firstLoad);
        }
        else if (scene.name == "Main")
        {
            FPSController.transform.position = teleportPointFromOther;
            if (wentWest == true)
            {
                lightsOn = GameObject.FindGameObjectsWithTag("lightOn");
                for(int i = 0; i<lightsOn.Length;i++)
                {
                    lightsOn[i].GetComponent<Light>().enabled = true;
                    lightsOn[i].GetComponent<Animator>().enabled = true;
                }

                lightsOff = GameObject.FindGameObjectsWithTag("lightOff");
                for(int i = 0; i<lightsOff.Length;i++)
                {
                    lightsOff[i].GetComponent<Light>().enabled = false;
                }
            }
        }
        if (scene.name == "WesternScene")
        {
            wentWest = true;
        }
    }
}
