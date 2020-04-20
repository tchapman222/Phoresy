using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Used to make the teleport Door Fade in.

public class EmissMgr : MonoBehaviour
{
    public Light doorlight;
    public GameObject myDoor;
    Color color;
    public float i = 0f;

    // Start is called before the first frame update
    void Start()
    {
        myDoor.SetActive(false);
        doorlight.enabled = false;
        doorlight.intensity = 0;

        color = myDoor.GetComponent<MeshRenderer>().material.color;
        color.a = 0f;

    }

    private void OnTriggerEnter(Collider other)
    {
        StartCoroutine("Fade");
    }

    private IEnumerator Fade()
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

    }

    // Update is called once per frame
   
    private float Map(float value, float startMin, float startMax, float endMin, float endMax)
    {
        float diff = (value - startMin) / (startMax - startMin);

        float newValue = (endMin * (1 - diff)) + (endMax * diff);

        return newValue;
    }


}
