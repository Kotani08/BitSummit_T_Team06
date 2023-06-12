using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUIController : MonoBehaviour
{
    [SerializeField]
    private Text playerOxygenText,TasknumText;//PlayerHealthText;

    [SerializeField]
    private PalyerStatus playerStatus;
    
    private int TaskObjectnum;

    void Start()
    {
        playerOxygenText.text = playerStatus.GetPlayerOxygen().ToString();
        StartCoroutine("functionName");
    }

    IEnumerator functionName()
    {
        while(true)
        {
        playerStatus.SetPlayerOxygen(playerStatus.GetPlayerOxygen() - 1);
        playerOxygenText.text = playerStatus.GetPlayerOxygen().ToString();
        yield return new WaitForSeconds(1.0f);
        }
        //yield return null;
    }

    public void OxygenTextChange()
    {
        playerOxygenText.text = playerStatus.GetPlayerOxygen().ToString();
    }

    public void TaskObjecNumChange(int num)
    {
        TaskObjectnum+=num;
        TasknumText.text = TaskObjectnum.ToString();
    }
}
