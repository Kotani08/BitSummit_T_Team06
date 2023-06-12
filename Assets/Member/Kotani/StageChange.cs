using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageChange : MonoBehaviour
{
    [SerializeField]
    private string SceneName;

    // Update is called once per frame
    public void OnClick()
    {
        StartCoroutine(LoadScene());
    }

    IEnumerator LoadScene()
    {
        //ロード待ち
        AsyncOperation async = SceneManager.LoadSceneAsync(SceneName);
        while (!async.isDone)
        {
            yield return null;
        }
    }
}
