using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// クォータニオンで円運動の軌道を計算
/// </summary>
public class CalcMyself : MonoBehaviour
{
    // 中心点
    [SerializeField]
    private GameObject _center;

    //private Vector3 _axis;

    // 円運動周期
    [SerializeField] private float _period = 1;

    public bool flag=false;

    Quaternion angleAxis;

    public void WeaponsForwardChange()
    {
        StartCoroutine(WeaponsAiconChange(Vector3.forward));
    }

    public  void WeaponsBackChange()
    {
        StartCoroutine(WeaponsAiconChange(Vector3.back));
    }
    private IEnumerator WeaponsAiconChange(Vector3 Directions)
    {
        var _startPoj = transform.position;
        while(true){
        yield return null; // 1フレーム待つ
        var tr = transform;
        // 回転のクォータニオン作成
        angleAxis = Quaternion.AngleAxis(360 /_period/1000, Directions);
        // 円運動の位置計算
        var pos = tr.position;

        pos -= _center.transform.position;
        pos = angleAxis * pos;
        pos += _center.transform.position;

        tr.position = pos;

        if ((int)GetAim(_startPoj,tr.position) <= -89
            &&(int)GetAim(_startPoj,tr.position) >= -90)
        {
            if(Directions == Vector3.forward)
            tr.localPosition = new Vector3(-60,-60,0);
            if(Directions == Vector3.back)
            tr.localPosition = new Vector3(60,-60,0);
            break;
        }
        else if((int)GetAim(_startPoj,tr.position) <= 1
            &&(int)GetAim(_startPoj,tr.position) >= 0f)
        {
            if(Directions == Vector3.forward)
            tr.localPosition = new Vector3(60,-60,0);
            if(Directions == Vector3.back)
            tr.localPosition = new Vector3(60,60,0);
            break;
        }
        else if((int)GetAim(_startPoj,tr.position) <= 91
            &&(int)GetAim(_startPoj,tr.position) >= 90f)
        {
            if(Directions == Vector3.forward)
            tr.localPosition = new Vector3(60,60,0);
            if(Directions == Vector3.back)
            tr.localPosition = new Vector3(-60,60,0);
            break;
        }
        else if((int)GetAim(_startPoj,tr.position) <= 180
            &&(int)GetAim(_startPoj,tr.position) >= 179)
        {
            if(Directions == Vector3.forward)
            tr.localPosition = new Vector3(-60,60,0);
            if(Directions == Vector3.back)
            tr.localPosition = new Vector3(-60,-60,0);
            break;
        }
        }
    }

    public float GetAim(Vector2 p1, Vector2 p2) {
    float dx = p2.x - p1.x;
    float dy = p2.y - p1.y;
    float rad = Mathf.Atan2(dy, dx);
    return rad * Mathf.Rad2Deg;
  }
}
