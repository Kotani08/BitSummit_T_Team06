using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMove : MonoBehaviour
{
    [SerializeField]
    private Camera cam;
    [SerializeField]
    private float moveSpeed = 10.0f;
    [SerializeField]
    private Rigidbody rb;
    private Animator animator;
    [SerializeField]
    private List<GameObject> playerWeapons = new List<GameObject>();

    public List<GameObject> PlayerWeapons => playerWeapons;

    public float MoveSpeed => moveSpeed;

    public float moveForceMultiplier;    // 移動速度の入力に対する追従度

    private PlayerWeapons playerWeapon;
    
    void Start() 
    {
        playerWeapon = transform.GetComponent<PlayerWeapons>();
        rb = GetComponent<Rigidbody>();
        animator = transform.GetComponent<Animator>();
    }
    
    void Update(){
       PlayerInputCatch();
    }

   private void PlayerInputCatch()
   {
    // ゲームパッドが接続されている場合はKey入力は受け付けない
       if (Gamepad.current != null){
        PadInputCatch();
       }
       else if(Gamepad.current == null)
       {
        KeyInputCatch();
       }
   }

    #region Pad入力の取得
    private void PadInputCatch()
    {
        //padのスティック入力を拾う
        float x = Gamepad.current.leftStick.ReadValue().x;
        float z = Gamepad.current.leftStick.ReadValue().y;
        if(x == 0f || z == 0f)
        {
            if(rb.velocity != Vector3.zero){rb.velocity = Vector3.zero;}
            animator.SetFloat("Speed",0f);
        }
        else{MoveBase(x,z);}

        if (Gamepad.current.buttonWest.wasPressedThisFrame)
        {
           PlayerWeaponsPressedAction();
        }
        if (Gamepad.current.buttonWest.wasReleasedThisFrame)
        {
           //Debug.Log("Button Southが離された！");
           PlayerWeaponsReleasedAction();
        }
    }
    #endregion

    #region キーボード入力の取得
    private void KeyInputCatch()
    {
        //キーボード入力を拾う
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        if (!Input.anyKey)
        {
            //if(rb.velocity != Vector3.zero){rb.velocity = Vector3.zero;}
            animator.SetFloat("Speed",0f);
        }
        else{MoveBase(x,z);}

        if (Input.GetMouseButtonDown(0))
        {
            //Debug.Log("左クリック");
            PlayerWeaponsPressedAction();
        }
        if(Input.GetMouseButtonUp(0))
        {
            //Debug.Log("左クリック上がった");
            PlayerWeaponsReleasedAction();
        }
    }
    #endregion

    #region プレイヤーキャラクターを動かす処理

    //上下移動の制限
    private void MoveBase(float x,float z)
    {
        //BlendTree用のアニメーションSpeed管理
        float current_speed = animator.GetFloat("Speed");

        if (x < 0) 
        {
          //transform.localScale = new Vector3(-1, 1, 1);
            animator.SetFloat("Speed", current_speed + Time.deltaTime * 10f);
            animator.SetFloat("Speed",1f);
        }
        else if (x > 0) 
        {
          //transform.localScale = new Vector3(1, 1, 1);
            animator.SetFloat("Speed", current_speed + Time.deltaTime * 10f);
            animator.SetFloat("Speed",1f);
        }
        else if (z > 0 || z < 0) 
        {
            animator.SetFloat("Speed", current_speed + Time.deltaTime * 10f);
            animator.SetFloat("Speed",1f);
        }
        // カメラの方向から、X-Z平面の単位ベクトルを取得
        Vector3 cameraForward = Vector3.Scale(Camera.main.transform.forward, new Vector3(1, 0, 1)).normalized;
 
        // 方向キーの入力値とカメラの向きから、移動方向を決定
        Vector3 moveForward = cameraForward * z + Camera.main.transform.right * x;

        //可変用にclassに切り分ける

        Vector3 moveVector = moveSpeed * (moveForward);

        rb.AddForce(moveForceMultiplier * (moveVector - rb.velocity));
 
        // キャラクターの向きを進行方向に
        if (moveForward != Vector3.zero) {
            transform.rotation = Quaternion.LookRotation(moveForward);
        }
    }
    #endregion

    void PlayerWeaponsPressedAction()
    {
        switch(playerWeapon.WeaponsNumber)
        {
            case 0:
            moveSpeed = moveSpeed/1.5f;
            playerWeapons[0].SetActive (true);
            break;
            case 1:
            playerWeapons[1].SetActive (true);
            break;
            case 2:
            playerWeapons[0].SetActive (true);
            break;
            case 3:
            playerWeapons[1].SetActive (true);
            break;
            default:
            break;
        }
    }

    void PlayerWeaponsReleasedAction()
    {
        switch(playerWeapon.WeaponsNumber)
        {
            case 0:
            moveSpeed = moveSpeed*1.5f;
            playerWeapons[0].SetActive (false);
            break;
            case 1:
            //playerWeapons[1].SetActive (false);
            //moveSpeed = moveSpeed/3;
            break;
            case 2:
            playerWeapons[0].SetActive (false);
            break;
            case 3:
            break;
            default:
            break;
        }
    }
}