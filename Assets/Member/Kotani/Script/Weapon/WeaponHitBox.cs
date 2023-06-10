using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponHitBox : MonoBehaviour
{
  [SerializeField]
  private PalyerStatus playerStatus;
  [SerializeField]
  private PlayerUIController playerUIController;

  [SerializeField]
  private int oxygenRecoveryNum;
  

    void OnTriggerEnter(Collider HitObj)
    {
    if(HitObj.tag == "TaskObject"){
      AudioManager.Instance.PlaySE(SEName.TaskSuccesses);
      HitObj.gameObject.SetActive (false);
      playerStatus.SetPlayerOxygen(playerStatus.GetPlayerOxygen() + oxygenRecoveryNum);
      playerUIController.OxygenTextChange();
      playerUIController.TaskObjecNumChange(-1);
    }
    }
}
