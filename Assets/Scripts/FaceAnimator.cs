using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This script was initially inteded to animate a character based off of their audio,
//but I decided to manually animate everything instead. -TC

public class FaceAnimator : MonoBehaviour
{

    public SkinnedMeshRenderer beardSkinnedMeshRenderer;
    public SkinnedMeshRenderer bodySkinnedMeshRenderer;
    //private float blendJaw = 0f;
    //private float blendBeard = 0f;
    private float startBlendVal = 0f;
    private float endBlendVal = 0f;
    public AudioSource myAudioSource;
    private AudioClip myClip;
    private float[] clipData;
    private int JawDownIndex = 23; //The index of the blend shape for Jaw_Down

    // Start is called before the first frame update
    void Awake()
    {
        myAudioSource = GetComponent<AudioSource>();
        myClip = myAudioSource.clip;
        clipData = new float[myAudioSource.clip.frequency];
    }

    private void Start()
    {
        InvokeRepeating("SoundToAnim", 0f, 1f);
    }

    void SoundToAnim()
    {
        myClip.GetData(clipData, 0);
        startBlendVal = endBlendVal;
        endBlendVal = myAudioSource.volume * 100;
        bodySkinnedMeshRenderer.SetBlendShapeWeight(23, Mathf.Lerp(startBlendVal, endBlendVal,1f));
        beardSkinnedMeshRenderer.SetBlendShapeWeight(23, 100);
        //print(myAudioSource.volume + ": " + endBlendVal);
        print(clipData[0]);
        print(myClip.GetData(clipData, 0));
        //StartCoroutine("Fade");
    }
    
    /*private IEnumerator Fade()
    {
        for (i = 0; i < 15f; i += Time.deltaTime)
        {
            myDoor.SetActive(true);
            doorlight.enabled = true;
            float mappedIntensity = Map(i, 0.0f, 5.0f, 0, 1f);
            float mappedAlpha = Map(i, 0.0f, 15.0f, 0, 1f);
            doorlight.intensity = Mathf.Lerp(0, 3.17f, mappedIntensity);
            color.a = Mathf.Lerp(0, 1f, mappedAlpha);
            myDoor.GetComponent<MeshRenderer>().material.color = color;
            yield return null;
        }

    }*/
}
