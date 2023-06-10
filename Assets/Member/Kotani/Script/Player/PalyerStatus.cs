using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PalyerStatus : MonoBehaviour
{
    [SerializeField]
    private int playerOxygen,playerHealth;

    public int GetPlayerOxygen(){return playerOxygen;}
    public void SetPlayerOxygen(int num){playerOxygen = num;}
}
