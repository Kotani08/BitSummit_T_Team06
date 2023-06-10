using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class title : MonoBehaviour
{
    bool LoadSceneFlag=false;
    void Start()
    {
        StartCoroutine(LoadSceneAndWait());
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)){LoadSceneFlag = true;}
        
    }

    IEnumerator LoadSceneAndWait()
    {
        AsyncOperation ope = SceneManager.LoadSceneAsync("StageSelectScene");
        ope.allowSceneActivation = false;

        while(LoadSceneFlag == false)
        {
            yield return null;
        }
        ope.allowSceneActivation = true;
    }
}
