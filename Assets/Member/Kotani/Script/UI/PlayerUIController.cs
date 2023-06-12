using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using PlayerSaveData;

public class PlayerUIController : MonoBehaviour
{
    [SerializeField]
    PlayerData playerData;
    [SerializeField]
    StageResult stageResult;

    [SerializeField]
    private Text playerOxygenText,TasknumText;//PlayerHealthText;
    
    private int TaskObjectnum;

    void Start()
    {
        playerOxygenText.text = playerData.playerOxygen.ToString();
        StartCoroutine("functionName");
    }

    IEnumerator functionName()
    {
        while(true)
        {
        playerData.playerOxygen -= 1;
        playerOxygenText.text = playerData.playerOxygen.ToString();
        yield return new WaitForSeconds(1.0f);
        }
        //yield return null;
    }

    public void OxygenTextChange()
    {
        playerOxygenText.text = playerData.playerOxygen.ToString();
        StageFailure();
    }

    public void TaskObjecNumChange(int num)
    {
        TaskObjectnum+=num;
        TasknumText.text = TaskObjectnum.ToString();
        StageClear();
    }
    private void StageClear()
    {
        if(TaskObjectnum <=0){
        stageResult.TaskAllSuccess();
        }
    }
    private void StageFailure()
    {
        if(playerData.playerOxygen <=0){
            playerData.playerOxygen=0;
            stageResult.TaskFailed();
        }
    }
}
