using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StageResult : MonoBehaviour
{
    [SerializeField]
    private GameObject resultBoard;
    [SerializeField]
    private TextMeshProUGUI resultText;
    [SerializeField]
    private TextMeshProUGUI resultTime;
    private float totalTime;
    private bool StopFlag=false;

    void Start()
    {
        StartCoroutine("WorldTimer");
    }

    public void TaskAllSuccess()
    {
        ResultPopUp("お掃除成功！");
        int minute = (int)totalTime/60;
        int second = (int)totalTime%60;
        if(minute == 0){resultTime.text = "クリア時間 ： "+second.ToString("00") +"秒";
        }else{resultTime.text = "クリア時間 ： "+minute.ToString("00") +"分"+second.ToString("00") +"秒";}
    }

    public void TaskFailed()
    {
        ResultPopUp("お掃除失敗...");
        resultTime.gameObject.SetActive(false);
    }

    private void ResultPopUp(string setText)
    {
        StopFlag = true;
        resultText.text = setText;
        resultBoard.SetActive(true);
        Time.timeScale = 0;//ゲームを停止させる
    }

     private IEnumerator WorldTimer(){
        while(true)
        {
            totalTime += Time.deltaTime;
            yield return null;
            if(StopFlag == true)
            {
                break;
            }
        }
    }
    void OnDestroy(){Time.timeScale = 1;}
}
