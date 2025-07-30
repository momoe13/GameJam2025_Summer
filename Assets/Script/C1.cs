using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class C1: Character_Controller
{
    [SerializeField] int attackPower;
    bool targetFlg = true;
    Character_Controller controller;

    protected override void Attack()
    {
        //Debug.Log("�U���I");
        //�^�[�Q�b�g������^�[�Q�b�g�Ƃ��̃X�N���v�g���擾
        if(targetFlg)
        {
            controller = GameObject.Find(target).GetComponent<Character_Controller>();
            targetFlg = false;
        }

        //Damege�֐��Ăяo��
        controller.Damage(attackPower);

    }

  
}
