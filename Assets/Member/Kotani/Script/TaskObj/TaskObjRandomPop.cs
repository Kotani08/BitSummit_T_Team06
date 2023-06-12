using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskObjRandomPop : MonoBehaviour
{
    [SerializeField]
    [Tooltip("生成するGameObject")]
    private GameObject createPrefab;

    [SerializeField]
    private float randomRange = 40f;

    [SerializeField]
    private int appNum=20;

    [SerializeField]
    private PlayerUIController playerUIController;

    // Start is called before the first frame update
    void Start()
    {
        for(int i=0; i <= appNum-1 ; i++)
        {
            ObjctPop();
        }
        playerUIController.TaskObjecNumChange(appNum);
        
    }

    // Update is called once per frame
    void ObjctPop()
    {
        float x = Random.Range(randomRange*-1f, randomRange);
        float z = Random.Range(randomRange*-1f, randomRange);
        // rangeAとrangeBのz座標の範囲内でランダムな数値を作成
        //float y = Random.Range(randomRange*-1f, randomRange);
        float y = 0.292f;

        // GameObjectを上記で決まったランダムな場所に生成
        var PrefabObj = Instantiate(createPrefab, new Vector3(x,y,z), createPrefab.transform.rotation);
        PrefabObj.transform.parent = this.gameObject.transform;
    }
}
