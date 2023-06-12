using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerWeapons : MonoBehaviour
{
    [SerializeField]
    private PlayerMove playerMove;
    [SerializeField]
    private List<CalcMyself> CommandList = new List<CalcMyself>();

    float timer=1f;

    public int WeaponsNumber=0;

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

        if(Gamepad.current == null){
        if(Input.GetMouseButtonDown(1))
        {
            //武器の切り替え
            playerMove.PlayerWeapons[0].SetActive(false);
            timer=0f;
            CommandForwardStart();
        }if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            //武器の切り替え
            playerMove.PlayerWeapons[0].SetActive(false);
            timer=0f;
            CommandBackStart();
        }
        }else{
        if (Gamepad.current.rightShoulder.ReadValue() == 1f)
        {
            //武器の切り替え
            playerMove.PlayerWeapons[0].SetActive(false);
            timer=0f;
            CommandBackStart();
        }
        if (Gamepad.current.leftShoulder.ReadValue() == 1f)
        {
            //武器の切り替え
            playerMove.PlayerWeapons[0].SetActive(false);
            timer=0f;
            CommandForwardStart();
        }
        }
    }

    private void CommandForwardStart(){
        foreach(CalcMyself num in CommandList)
        {
            num.WeaponsForwardChange();
        }
        if(WeaponsNumber <= 2){
            WeaponsNumber++;
        }else{
            WeaponsNumber = 0;
        }
    }
    private void CommandBackStart(){
        foreach(CalcMyself num in CommandList)
        {
            num.WeaponsBackChange();
        }
        if(WeaponsNumber >= 1){
            WeaponsNumber--;
        }else{
            WeaponsNumber = CommandList.Count-1;
        }
    }
}
