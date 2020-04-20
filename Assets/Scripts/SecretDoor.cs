using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Manages the opening of the secred door in the bathroom.

public class SecretDoor : MonoBehaviour
{
    public Animation rightDoorAnim;
    public Animation leftDoorAnim;

    public gameManager myGameManager;
    // Start is called before the first frame update
    void Start()
    {
        myGameManager = FindObjectOfType<gameManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (myGameManager.wentWest)
        {
            rightDoorAnim.Play();
            leftDoorAnim.Play();
            gameObject.GetComponent<Collider>().enabled = false;
        }
    }
}
