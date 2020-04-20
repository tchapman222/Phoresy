using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//Pretty Self Explanatory.

public class ChangeScene : MonoBehaviour
{

    public string sceneName;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
