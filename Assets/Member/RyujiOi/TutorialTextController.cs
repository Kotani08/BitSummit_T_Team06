using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.InputSystem;

public class TutorialTextController : MonoBehaviour
{
    RectTransform rect;
    public TextMeshProUGUI tutotext;

    public int textnumber = 0; // �e�L�X�g�̔ԍ�
    private string[] textlist = {"Qキーを押している間、ジンベエザメを使えるよ！","Qキーを押しながら、\n落ちているゴミに近づいてみよう！"};

    [SerializeField] public float max_position_x = -200f; // �e�L�X�g���ړ��ł���E�[
    [SerializeField] public float min_position_x = -2000f; // �e�L�X�g���ړ��ł��鍶�[
    [SerializeField] public bool isEntering = true; // �e�L�X�g���\������Ă��邩��\���t���O
    [SerializeField] public bool isOutgoing = false; // �e�L�X�g���ޏꒆ����\���t���O

    // Start is called before the first frame update
    void Start()
    {
        rect = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        // textnumber�̒l�ɂ���ăe�L�X�g�̓��e��ύX tutolist��(textnumber + 1)�Ԗڂ̃e�L�X�g��\��
        if (0 <= textnumber && textnumber < textlist.Length)
        {
            tutotext.text = textlist[textnumber];
        }

        // max_position_x�܂���min_poisition_x�܂Ńe�L�X�g���ړ�
        if (isEntering == true)
        {
            rect.anchoredPosition += new Vector2(5, 0);
        }
        if (isOutgoing == true)
        {
            rect.anchoredPosition += new Vector2(-5, 0);
        }

        // max_potition_x�܂���min_potition_x�𒴂�����e�L�X�g���~
        if (rect.anchoredPosition.x >= max_position_x)
        {
            isEntering = false;
        }
        if (rect.anchoredPosition.x <= min_position_x)
        {
            isOutgoing = false;
        }
        
    }
}
