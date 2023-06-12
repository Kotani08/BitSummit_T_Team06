using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerCameraControl : MonoBehaviour
{
    private Camera cam;
    [SerializeField, Tooltip("ターゲットオブジェクト")]
    private GameObject targetObject;
    private Vector3 targetPos;
    private Vector3 offset;      //相対距離取得用

    [SerializeField]
    private float lookNum;

    void Start () {
        // MainCamera(自分自身)とplayerとの相対距離を求める
        offset = transform.position - targetObject.transform.position;
        cam = GetComponent<Camera>();
	}
    void Update()
    {
        if (targetObject == null) return;
        //transform.position = targetObject.transform.position+ offset; 
        transform.position += targetObject.transform.position - targetPos; 
        targetPos = targetObject.transform.position;

        if (Gamepad.current != null){
            //回転させる角度
            float x = Gamepad.current.rightStick.ReadValue().x/lookNum;
            //Cameraを引く動き
            float y = Gamepad.current.rightStick.ReadValue().y/lookNum;
            CameraMoveCore(x,y);
        }
        else if(Gamepad.current == null)
        {
            //マウスの方向でカメラ方向を決める
            //回転させる角度
            //float x = Gamepad.current.rightStick.ReadValue().x/10;
            //Cameraを引く動き
            //float y = Gamepad.current.rightStick.ReadValue().y/10;
            //CameraMoveCore(x,y);
        }
        //カメラの角度調整時もキャラクターを生面に表示するやつ
        //playerMove.CameraLookAt();
    }

    private void CameraMoveCore(float anglex,float angley)
    {
        //斜めのカメラワーク
        //斜め入力の場合、中心がずれる事故が多発

        //カメラを回転させる
        //transform.RotateAround(targetObject.transform.position, Vector3.up, anglex);
        //transform.RotateAround(targetObject.transform.position, Vector3.right, -angley);

        //cam.gameObject.transform.localEulerAngles = SetPoj;

        //Xの上限下限の設定
        if(cam.gameObject.transform.localEulerAngles.x > 15f && cam.gameObject.transform.localEulerAngles.x < 340f && Gamepad.current.rightStick.ReadValue().y < 0f ||
            cam.gameObject.transform.localEulerAngles.x > 30f && cam.gameObject.transform.localEulerAngles.x < 350f && Gamepad.current.rightStick.ReadValue().y > 0f)
            /*cam.gameObject.transform.localEulerAngles.y > 90f && cam.gameObject.transform.localEulerAngles.y < 100f && Gamepad.current.rightStick.ReadValue().x > 0f ||
            cam.gameObject.transform.localEulerAngles.y > 100 && cam.gameObject.transform.localEulerAngles.y < 270f && Gamepad.current.rightStick.ReadValue().x < 0f)*/
            {}else{
                transform.RotateAround(targetObject.transform.position, Vector3.up, anglex);
                //transform.RotateAround(targetObject.transform.position, Vector3.right, -angley);
        }

        //既定の範囲内ならRotateAroundで動かす
        //既定の範囲外なら停止
        //縦回転だけ範囲を決める


        //カメラがＺ回転すると酔うのＺ回転だけ無くす
        Vector3 comLimit = cam.gameObject.transform.localEulerAngles;
        comLimit.z = 0f;
        cam.gameObject.transform.localEulerAngles = comLimit;
    }
}
