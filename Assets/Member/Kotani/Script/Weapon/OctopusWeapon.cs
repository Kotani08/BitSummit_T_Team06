using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OctopusWeapon : WeaponBase
{
    //このオブジェクトがActiveになったら
    //速度を上げる
    [SerializeField]
    private PlayerMove playerMove;

    private float ActiveTime=1f;
    private float CoolTime=5f;
[SerializeField]
    private float totalTime;

    [SerializeField]
    private Rigidbody rb;
    private bool CoolTimeFlag=false;

    [SerializeField]
    private CoolTimeTimer coolTimeTimer;
    [SerializeField]
    private int coolTime;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnEnable() {
        if(coolTimeTimer.CoolTimeFlag == false){
        coolTimeTimer.GetCoolTimeCount(coolTime);
        coolTimeTimer.CoolTimeCover.SetActive(true);
		StartCoroutine("PlayerSpeedUp");
        }else{
            this.gameObject.SetActive(false);
            Debug.Log("CoolTime中");
        }
	}

    private IEnumerator PlayerSpeedUp(){
        //n秒間加速
        while(true)
        {
            rb.AddForce(rb.gameObject.transform.forward * 150, ForceMode.Force);
            totalTime += Time.deltaTime;
            yield return null;
            if(totalTime >= ActiveTime)
            {
                this.gameObject.SetActive(false);
                totalTime=0;
                coolTimeTimer.CoolTimeFlag = true;
                break;
            }
        }
    }
}
