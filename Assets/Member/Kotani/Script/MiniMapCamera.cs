using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniMapCamera : MonoBehaviour
{
    [SerializeField]
    private GameObject player;

    // Update is called once per frame
    void Update()
    {
        transform.localPosition = new Vector3(player.transform.localPosition.x,transform.localPosition.y,player.transform.localPosition.z+3f);
    }
}
