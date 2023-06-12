using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayerSaveData;

public class PalyerStatus : MonoBehaviour
{
    [SerializeField]
    PlayerData playerData;

    [SerializeField]
    private int playerOxygen,playerHealth;

    public int GetPlayerOxygen(){return playerOxygen;}
    public void SetPlayerOxygen(int num){playerOxygen = num;}

    void Awake()
    {
        playerData.playerOxygen = playerOxygen;
        playerData.playerHealth = playerHealth;
    }
}
