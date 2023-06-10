using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerWeapons : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> playerWeapons = new List<GameObject>();
    [SerializeField]
    private List<CalcMyself> CommandList = new List<CalcMyself>();

    private bool flag=false;
    float timer=1f;

    //プレイヤーの子オブジェクトにある武器を全部取得
    //LRで使用する武器を変える
    //押されたらTimerが起動してリチャージ待ちになる
    
    void Update()
    {
        if(timer >= 1f){
        WeaponsChange();
        }else{timer += Time.deltaTime;}
    }

    private void WeaponsChange()
    {
        if (Gamepad.current.rightShoulder.wasPressedThisFrame)
        {
            //武器の切り替え
            //Debug.Log("押した");
            timer=0f;
            CommandBackStart();
        }
        if (Gamepad.current.leftShoulder.ReadValue() == 1f)
        {
            //武器の切り替え
            timer=0f;
            CommandForwardStart();
        }
    }

    private void CommandForwardStart(){
        foreach(CalcMyself num in CommandList)
        {
            num.WeaponsForwardChange();
        }
    }
    private void CommandBackStart(){
        foreach(CalcMyself num in CommandList)
        {
            num.WeaponsBackChange();
        }
    }
}
