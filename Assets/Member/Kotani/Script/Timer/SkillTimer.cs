using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillTimer : Timer
{
    //スキルのボタンが押されたら
    //CoverをOnにする
    //Timerをスタートする
    //Timerが0になったらリセットしてCoverをOffにする
    
    //private SkillButton _skillButton;
    [SerializeField]
    private GameObject SkillButtonCover;

    void Start()
    {
        //_skillButton = this.GetComponent<SkillButton>();
        //SetMaxTime(_skillButton.GetSkillCoolTime());
    }

    public void SkillTimerStart()
    {
        TimerReset();
        ButtonCoverOn();
    }
    private void ButtonCoverOn()
    {
        SkillButtonCover.SetActive(true);
        StartCoroutine("TimerObservation");
    }

    IEnumerator TimerObservation()
    {
        while (timerStop == false) {
            yield return null;
            if(timerStop == true)
            {
                SkillButtonCover.SetActive(false);
                break;
            }
        }
        yield return null;
    }
}
