using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class TutorialShark_Move : MonoBehaviour
{
    public GameObject target;
    public GameObject eye;
    MeshCollider Shark_Collider;


    public float StartPos_x = 10f;//X�̏����z�u
    public float StartPos_y = 1f;//Y�̏����z�u
    public float StartPos_z = 25f;//Z�̏����z�u
    public float Startrot_x = 0f;//rotationX�̏����z�u
    public float Startrot_y = 90f;//rotationY�̏����z�u
    public float Startrot_z = 0f;//rotationZ�̏����z�u

    public float rotate_range = 0.01f;//��V�����̒����p�@0.01f�Ŕ͈͂���@0<=x<=11.4�A-5.7<=z<=5.7�@(x,z)=(0,0)�@�l��0.01��n�{�ɂȂ�ƁA��V������x��z��0.01�̎���n�{�ɂȂ�
    public float rotate_speed = 1f;//��]�̑����@1f�Ŏ�������13.5�b(FixedUpdate���)�@�l��0.1��n�{�ɂȂ�ƁA������0.1�̎���1/n�ɂȂ�
    public float Search_range = 10; //�G�l�~�[�̃v���C���[�����͈�
    public float sight_range = 50; //�G�l�~�[�̎���p
    public float sight_out = 20; //�G�l�~�[���v���C���[������������
    public float chase_speed = 0.1f;//�G�l�~�[���v���C���[��ǂ�������Ƃ��̑���
    public float return_speed = 0.1f;//�G�l�~�[���v���C���[���������Č������ꏊ�ɋA�鎞�̑���
    public float attacked_waittime = 1f;

    Vector3 Now_move0_position = new Vector3(0, 0, 0);
    Quaternion Now_move0_rotation = Quaternion.Euler(0, 0, 0);
    bool restart = false;
    bool attacked = false;
    public bool RightRote_is_T_and_LeftRote_is_F;//�E��](���v���)�Ȃ�true�A����](�����v���)�Ȃ�false
    int mode = 0;
    private void Start()
    {
        Transform mytransform = this.transform;
        Vector3 Firstpos = mytransform.position;
        Firstpos.x = StartPos_x;
        Firstpos.y = StartPos_y;
        Firstpos.z = StartPos_z;
        mytransform.position = Firstpos;
        Now_move0_position = Firstpos;

        Quaternion Firstrot = mytransform.rotation;
        Firstrot.x = Startrot_x;
        Firstrot.y = Startrot_y;
        Firstrot.z = Startrot_z;
        mytransform.rotation = Firstrot;
        Now_move0_rotation = Firstrot;

        Shark_Collider = GetComponent<MeshCollider>();
    }
    private void FixedUpdate()
    {
        float dis = Vector3.Distance(transform.position, target.transform.position);
        Vector3 vec_dis = target.transform.position - eye.transform.position;
        var angle = Vector3.Angle(transform.forward, vec_dis);
        if (dis <= Search_range & angle <= sight_range & attacked != true)
        {
            mode = 1;
        }
        if (mode == 1 & sight_out <= dis & attacked != true)
        {
            mode = 2;
        }
        if (mode == 2 & Vector3.Distance(transform.position, Now_move0_position) <= 1f & attacked != true)
        {
            mode = 0;
        }


        if (mode == 0)
        {
            mode0();
        }
        if (mode == 1)
        {
            mode1();
        }
        if (mode == 2)
        {
            mode2();
        }
        if (mode == 3)
        {
            ;//�������Ȃ�
        }


    }

    private void mode0()
    {
        if (restart == true)
        {
            transform.position = Now_move0_position;
            this.transform.rotation = Quaternion.Euler(Now_move0_rotation.x, Now_move0_rotation.y, Now_move0_rotation.z);
            restart = false;
        }
        else
        {
            if (RightRote_is_T_and_LeftRote_is_F == true)
            {
                transform.Rotate(new Vector3(0, 1, 0), rotate_speed);
                transform.position += transform.forward * rotate_range * rotate_speed * 10;
                Now_move0_position = transform.position;
                Now_move0_rotation.x = transform.localEulerAngles.x;
                Now_move0_rotation.y = transform.localEulerAngles.y;
                Now_move0_rotation.z = transform.localEulerAngles.z;
            }
            if (RightRote_is_T_and_LeftRote_is_F == false)
            {
                transform.Rotate(new Vector3(0, -1, 0), rotate_speed);
                transform.position += transform.forward * rotate_range * rotate_speed * 10;
                Now_move0_position = transform.position;
                Now_move0_rotation.x = transform.localEulerAngles.x;
                Now_move0_rotation.y = transform.localEulerAngles.y;
                Now_move0_rotation.z = transform.localEulerAngles.z;
            }

        }
    }
    private void mode1()
    {
        restart = true;
        Quaternion lookRotation = Quaternion.LookRotation(target.transform.position - transform.position, Vector3.up);



        transform.rotation = Quaternion.Lerp(transform.rotation, lookRotation, 0.1f);

        Vector3 p = new Vector3(0f, 0f, chase_speed);

        transform.Translate(p);
    }

    private void mode2()
    {
        Quaternion lookRotation = Quaternion.LookRotation(Now_move0_position - transform.position, Vector3.up);



        transform.rotation = Quaternion.Lerp(transform.rotation, lookRotation, 0.1f);

        Vector3 p = new Vector3(0f, 0f, return_speed);

        transform.Translate(p);
    }



    void OnTriggerEnter(Collider target)
    {
        StartCoroutine("afterAttacK");
    }

    IEnumerator afterAttacK()
    {
        int just_before = mode;
        Shark_Collider.enabled = false;
        attacked = true;
        mode = 3;
        yield return new WaitForSeconds(attacked_waittime);
        Shark_Collider.enabled = true;
        attacked = false;
        mode = just_before;
    }
}
