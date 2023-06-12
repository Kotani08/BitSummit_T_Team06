using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayerSaveData;

public class WhaleSharkWeapon : WeaponBase
{
  [SerializeField]
    PlayerData playerData;
  //好感度による性能上昇、効果の処理
  [SerializeField]
  private PalyerStatus playerStatus;
  [SerializeField]
  private PlayerUIController playerUIController;

  [SerializeField]
  private int oxygenRecoveryNum;

  //Trigerで取得
    void OnEnable() {
      if(LikabilityLevel >= 1)
      {
        WeaponRangeList[0].SetActive(true);
      }
		  if(LikabilityLevel >= 2)
      {
        WeaponRangeList[1].SetActive(true);
      }
      if(LikabilityLevel >= 3)
      {
        WeaponRangeList[2].SetActive(true);
      }
	  }
    void OnTriggerEnter(Collider HitObj)
    {
    if(HitObj.tag == "TaskObject"){
      LikabilityLevelCheck(HitObj);
    }
    }
    private void LikabilityLevelCheck(Collider HitObj)
    {
      AudioManager.Instance.PlaySE(SEName.TaskSuccesses);
      HitObj.gameObject.SetActive (false);
      playerData.playerOxygen += oxygenRecoveryNum*LikabilityLevel;
      playerUIController.OxygenTextChange();
      playerUIController.TaskObjecNumChange(-1);
      LikabilityUp(30);
    }
}
