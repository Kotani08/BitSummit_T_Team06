using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayerSaveData;

public class PlayerHitBox : MonoBehaviour
{
    [SerializeField]
    PlayerUIController playerUIController;
    [SerializeField]
    PlayerData playerData;
    [SerializeField]
    private Rigidbody rb;
    private float totalTime;
    [SerializeField]
    private float ActiveTime;
    private bool CoolTimeFlag = true;



    void OnTriggerEnter(Collider target)
    {
        if(target.gameObject.tag == "Shark" && CoolTimeFlag)
        {
            CoolTimeFlag = false;
            playerData.playerOxygen -= 10;
            playerUIController.OxygenTextChange();
            StartCoroutine("CoolTimeFlagUp");
            AudioManager.Instance.PlaySE(SEName.SharkBite);
        }else{}
    }

    private IEnumerator CoolTimeFlagUp(){
        //n秒間加速
        while(true)
        {
            totalTime += Time.deltaTime;
            yield return null;
            if(totalTime >= ActiveTime)
            {
                totalTime=0;
                CoolTimeFlag = true;
                break;
            }
        }
    }
}
