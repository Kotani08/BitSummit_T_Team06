using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponBase : MonoBehaviour
{
    //共通機能
    //海洋生物のレベル、好感度、好感度上昇、Timerの呼び出し

    private int likabilityLevel = 1;
    public int  LikabilityLevel => likabilityLevel;

    private int likability;

    public int  Likability => likability;

    private int LevelUpTable=100;

    public List<GameObject> WeaponRangeList = new List<GameObject>();

    public void LikabilityUp(int elevation)
    {
        //好感度上昇用のクラス
        likability += elevation;
        if(likability >= LevelUpTable){
            //既定の値以上の時にレベルアップ
            likabilityLevel +=1;
        }

    }
}
