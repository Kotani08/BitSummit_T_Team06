using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoolTimeTimer : MonoBehaviour
{
    public GameObject CoolTimeCover;
    [SerializeField]
    private TextMeshProUGUI ViewTime;
    private float totalTime;
    public bool  CoolTimeFlag = false;

    public void GetCoolTimeCount(int num)
    {
        StartCoroutine(CoolTimeCount(num));
    }

    private IEnumerator CoolTimeCount(int CoolTime)
    {
        totalTime = CoolTime+1;
        //Debug.Log("aa");
        while(true)
        {
            totalTime -= Time.deltaTime;
            int i = (int)totalTime;
            ViewTime.text = i.ToString();
            yield return null;
            if(totalTime <= 1)
            {
                CoolTimeCover.SetActive(false);
                //Debug.Log("end");
                totalTime=0;
                CoolTimeFlag = false;
                break;
            }
        }
    }
}
