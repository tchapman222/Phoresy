using System;
using System.Collections;
using System.Collections.Generic;
using UnitySampleAssets.CrossPlatformInput;
using UnityEngine;

//Manages the changing of colors when hovering over something (like the door handle)
//Pretty hacky way of doing it. I found certain values produced odd emmissions and colors
//so I took advantage of it.

public class OnMouseOverColor : MonoBehaviour
{
    //When the mouse hovers over the GameObject, it turns to this color (red)

    Color m_MouseOverColor = new Color(5f, 94f, 75f);


    //This stores the GameObject’s original color
    Color m_OriginalColor;

    //Get the GameObject’s mesh renderer to access the GameObject’s material and color
    MeshRenderer m_Renderer;
    Material mat;
    public Animator anim;
    public AudioSource myAudioSource;
    public bool switchAnim = false;
    public bool m_Select;
    public bool canSelect;

    void Start()
    {
        //Fetch the mesh renderer component from the GameObject
        m_Renderer = GetComponent<MeshRenderer>();
        mat = m_Renderer.material;
        //Fetch the original color of the GameObject
        m_OriginalColor = m_Renderer.material.color;
        
    }

    private void Update()
    {
        if (!m_Select)
        {
            m_Select = CrossPlatformInputManager.GetButtonDown("Fire1");
            
        }

        if (m_Select && canSelect)
        {
            m_Select = false;
            switchAnim = !switchAnim;
            anim.SetBool("isOpen", switchAnim);
            myAudioSource.Play();
        }
    }

    void OnMouseOver()
    {
        //mat.EnableKeyword("_EMISSION");
        // Change the color of the GameObject to red when the mouse is over GameObject
        m_Renderer.material.color = m_MouseOverColor;
        canSelect = true;
        m_Select = false;
    }

    void OnMouseExit()
    {
        //mat.DisableKeyword("_EMISSION");
        // Reset the color of the GameObject back to normal
        m_Renderer.material.color = m_OriginalColor;
        canSelect = false;
        m_Select = false;
    }

    /*private void OnMouseDown()
    {
        switchAnim = !switchAnim;
        anim.SetBool("isOpen", switchAnim);
        myAudioSource.Play();
    }*/
}
